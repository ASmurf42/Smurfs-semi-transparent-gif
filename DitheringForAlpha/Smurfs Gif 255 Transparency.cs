using AlphaDithering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SmurfsAlphaDithering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Smurfs Alpha Dithering"; //idk how to change application name through visual studio so this will have to do...
        }

        bool opened = false; //used for when saving and doing some checks
        List<Image> AllFrames = new List<Image>(); //contains all frames for when animation is used
        string path; //needed to use a string for it when saving mutiple images to one path
        List<Image> AllOrginal_ = new List<Image>(); //A list of all imported images, for redundancy
        bool isAllowedToPlayback = true; //global variable used to kill animation thread when dithering start, to avoid object allready in use err
        int completedOperations; //needs to be globals
        int totalOperations; // needs to be global
        int currentFrame_; //global variable of the current frame

        private void open_Click(object sender, EventArgs e) //lets the user add/import images. Got this code from another projeckt, but might have stolen it from a tutorial...
        {
            currentFrame_ = (int)current_frame.Value; //can't set it when it's created so I set it here

            openFileDialog1.Filter = "All Files|*.*|PNG|*.png|JPEG|*.jpg|BMP|*.bmp"; //filter for which files are allowed to be open
            DialogResult dialogResult_ = openFileDialog1.ShowDialog();

            if (dialogResult_ == DialogResult.OK)
            {
                path = Path.GetDirectoryName(openFileDialog1.FileName); 
                foreach (String file in openFileDialog1.FileNames) //for all paths/files that were opened in openFileDialog1
                {
                    Image loadedImage = Image.FromFile(file); //tmp variable 
                    pictureBox1.Image = loadedImage; 
                    AllFrames.Add(loadedImage); 
                    AllOrginal_.Add(loadedImage); 

                    Dith_all.Text = "Dither all in list (" + AllFrames.Count + ")"; //sets the text of the "Dither all frames" button with the ammount of frames it will dither
                }

                current_frame.Maximum = AllFrames.Count - 1; //sets the correct range for the induvidual frame viewr thingy (play around with the program, you'll figure it out) so it dosen't get a index out of range
                
                PBOrginal_.Image = AllOrginal_[0]; //sets the first frame as the one original one, this is kinda reduntant tbh

                Console.WriteLine("height " + pictureBox1.Image.Height + Environment.NewLine + "width " + pictureBox1.Image.Width + "\n"); 

                groupBox_Dithering.Enabled = true; //enables the buttons for dithering
                groupBox_Dithering_A.Enabled = true; //enables the buttons for Alpha dithering
                save.Enabled = true; //enables save
                pictureBox1.Enabled = true; //enabels the main picturebox, (so you can click and pop out a new window)

                if (AllFrames.Count > 1)
                {
                    groupBox_Animation.Enabled = true; //enables animation if more than 1 image is added. So the user isn't confused what all the stuff in the animation section does
                }


                opened = true;
                
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (opened) //just saves stuff, it works RN, don't fuck with it. I only know how my part of it works
            {
                SaveFileDialog saveFileDialog_ = new SaveFileDialog(); 
                saveFileDialog_.Filter = "Images| * .png;*.bmp;*.jpg"; 
                ImageFormat imageFormat_ = ImageFormat.Png; 
                if (saveFileDialog_.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string extensios_ = Path.GetExtension(saveFileDialog_.FileName); 
                    switch (extensios_)
                    {
                        case ".jpg":
                            imageFormat_ = ImageFormat.Jpeg;
                            break;
                        case ".png":
                            imageFormat_ = ImageFormat.Png;
                            break;
                        case ".bmp":
                            imageFormat_ = ImageFormat.Bmp; /*wtf is bmp?*/

                            break;
                    }

                    //variables used in saving files and givving them correct names
                    int i = 0;
                    string inputPath = saveFileDialog_.FileName; 
                    string path = Path.GetDirectoryName(inputPath);
                    string filename = Path.GetFileName(inputPath);
                    string extension = Path.GetExtension(inputPath);

                    foreach (Image item in AllFrames) //saves all files with user specified name plus a number for each frame
                    {
                        item.Save(path + @"\" + filename.Substring(0, filename.Length - extension.Length) + i + extension);

                        i++;
                    }
                }
            }
        }

        private void dither_Click(object sender, EventArgs e)
        {
            //if (pictureBox1.Image.Width > 700 || pictureBox1.Image.Height > 700) //shit dosen't work, have to make a custom version of the setup for the algorithm to make it work with multithreading, just expect slow times for now
            //{
            //    Thread ditherRowR = new Thread(() => DoDitherR());
            //    ditherRowR.Start();

            //    Thread ditherRowG = new Thread(() => DoDitherR());
            //    ditherRowG.Start();

            //    Thread ditherRowB = new Thread(() => DoDitherR());
            //    ditherRowB.Start();

            //    //botched af way to do make it work, preferably it would need a rewetie of the way I do all the stuff do "setup" the algorithm (for loops and stuff)
            //}
            //else

            pictureBox1.Image = DoDither(AllOrginal_[(int)current_frame.Value]); //Dithers the original version of the current displayed frame 
            
            //note to future self, inplument multithreading for lare immages, both of single dithering/AlphaD, maybe even for DitherAllFrames() as well
        }
        

        Bitmap DoDither(Image toDither) //normal floyd steinberg dithering, semi optemised, read the wiki on it and code trains vid for an explinatio of the algo
        {
            isAllowedToPlayback = false; //sets a global variable used for playback to false, this is supposed to stop the animation thread to avoind mutiple things trying to referance the frames but in reality this dosen't work

            Bitmap pb1 = new Bitmap(toDither); //creates a non instanced version of the currently displayed image
            Color OldPixel; //used later in the algorithem, see wiki for pseudocode
            Color NewPixel; //used later in the algorithem, see wiki for pseudocode
            Color tmp; //used to avoid calling mutiple times for the same color object, just a tmp thingy

            if (opened)
            {
                if (GreyScale.Checked) //greyscales the image if the checkbox is checked (they way I greyscale is kinda flawd)
                    GreyScaleImage(pb1);

                for (int y = 0; y < pb1.Height - 1; y++)
                {
                    Console.WriteLine(y); //writes the current line it's working on
                    for (int x = 1; x < pb1.Width - 1; x++)
                    {
                        OldPixel = Color.FromArgb(pb1.GetPixel(x, y).ToArgb()); //sets the "oldpixel" to the color of the unedited version of the pixel (unedited as in before the algorithem is run)

                        NewPixel = LimitColors(x, y, OldPixel, (int)dither_steps.Value); //Limits or rounds the color, 0 and 255 for example
                        pb1.SetPixel(x, y, NewPixel); //uncomment for cool effect lol
                        Vector4 qErr = GetErr(x, y, OldPixel, NewPixel); //gets the quant error for the current pixel

                        //the algorithem, see wiki for a clearer pesudo code version
                        tmp = pb1.GetPixel(x + 1, y); //pretty sure .GetPixel was a kinda slow operatio so I save it to a varible to be used 4 times per step
                        pb1.SetPixel(
                            x + 1, y, Color.FromArgb(
                            (int)Clamp(tmp.A + qErr.A * (7 / 16f)),
                            (int)Clamp(tmp.R + qErr.R * (7 / 16f)),
                            (int)Clamp(tmp.G + qErr.G * (7 / 16f)),
                            (int)Clamp(tmp.B + qErr.B * (7 / 16f))
                            ));

                        tmp = pb1.GetPixel(x - 1, y + 1);
                        pb1.SetPixel(
                            x - 1, y + 1, Color.FromArgb(
                            (int)Clamp(tmp.A + qErr.A * (3 / 16f)),
                            (int)Clamp(tmp.R + qErr.R * (3 / 16f)),
                            (int)Clamp(tmp.G + qErr.G * (3 / 16f)),
                            (int)Clamp(tmp.B + qErr.B * (3 / 16f))
                            ));

                        tmp = pb1.GetPixel(x, y + 1);
                        pb1.SetPixel(
                            x, y + 1, Color.FromArgb(
                            (int)Clamp(tmp.A + qErr.A * (5 / 16f)),
                            (int)Clamp(tmp.R + qErr.R * (5 / 16f)),
                            (int)Clamp(tmp.G + qErr.G * (5 / 16f)),
                            (int)Clamp(tmp.B + qErr.B * (5 / 16f))
                            ));

                        tmp = pb1.GetPixel(x + 1, y + 1);
                        pb1.SetPixel(
                            x + 1, y + 1, Color.FromArgb(
                            (int)Clamp(tmp.A + qErr.A * (1 / 16f)),
                            (int)Clamp(tmp.R + qErr.R * (1 / 16f)),
                            (int)Clamp(tmp.G + qErr.G * (1 / 16f)),
                            (int)Clamp(tmp.B + qErr.B * (1 / 16f))

                            ));
                    }
                }
            }
            
            return pb1; //returns the dithered image
        }

        private void GreyScaleImage(Bitmap pb1)
        {
            Color OldPixel;
            int tmp = 0;
            for (int y = 0; y < pb1.Height; y++)
            {
                for (int x = 0; x < pb1.Width; x++)
                {
                    OldPixel = pb1.GetPixel(x, y);
                    tmp = (int)((OldPixel.R + OldPixel.G + OldPixel.B) / 3f);
                    pb1.SetPixel(x, y, Color.FromArgb(
                        tmp, tmp, tmp
                        ));
                }
            }
        }

        private void ditherAlpha_Click(object sender, EventArgs e) //Dithers only the alpha channel
        {
            int important_ish;
            if (opened)
            {
                isAllowedToPlayback = false;

                Bitmap pb1 = new Bitmap(AllOrginal_[(int)current_frame.Value]);
                important_ish = (int)current_frame.Value;
                Color OldPixel;
                Color NewPixel;
                Color tmp;

                for (int y = 0; y < pb1.Height - 1; y++)
                {
                    Console.WriteLine(y);
                    for (int x = 1; x < pb1.Width - 1; x++)
                    {

                        OldPixel = Color.FromArgb(pb1.GetPixel(x, y).ToArgb());
                        if (OldPixel.A != 255)
                        {
                            NewPixel = LimitAlpha(x, y, OldPixel, 1);
                            pb1.SetPixel(x, y, NewPixel); //uncomment for cool effect lol
                            Vector4 qErr = GetErr(x, y, OldPixel, NewPixel);

                            tmp = pb1.GetPixel(x + 1, y);
                            pb1.SetPixel(
                                x + 1, y, Color.FromArgb(
                                (int)Clamp(tmp.A + qErr.A * (7 / 16f)), tmp.R,
                                tmp.G,
                                tmp.B

                                ));

                            tmp = pb1.GetPixel(x - 1, y + 1);
                            pb1.SetPixel(
                                x - 1, y + 1, Color.FromArgb(
                                (int)Clamp(tmp.A + qErr.A * (3 / 16f)), tmp.R,
                                tmp.G,
                                tmp.B

                                ));

                            tmp = pb1.GetPixel(x, y + 1);
                            pb1.SetPixel(
                                x, y + 1, Color.FromArgb(
                                (int)Clamp(tmp.A + qErr.A * (5 / 16f)), tmp.R,
                                tmp.G,
                                tmp.B

                                ));

                            tmp = pb1.GetPixel(x + 1, y + 1);
                            pb1.SetPixel(
                                x + 1, y + 1, Color.FromArgb(
                                (int)Clamp(tmp.A + qErr.A * (1 / 16f)),
                                tmp.R,
                                tmp.G,
                                tmp.B

                                ));
                        }
                        else
                        {
                            pb1.SetPixel(x, y, Color.FromArgb(255, OldPixel));
                        }

                    }
                }
                if (Alpha_err_fix.Checked)
                    FixAlphaErr((Bitmap)AllOrginal_[important_ish], pb1);
                pictureBox1.Image = pb1;
                AllFrames[important_ish] = pb1;

                isAllowedToPlayback = true;
            }

        }

        static Color LimitColors(int x, int y, Color OldPixel, int factor)
        {
            return Color.FromArgb(
                (int)(Math.Round(factor * (double)(OldPixel.A / 255f)) * (255f / factor)),
                (int)(Math.Round(factor * (double)(OldPixel.R / 255f)) * (255f / factor)),
                (int)(Math.Round(factor * (double)(OldPixel.G / 255f)) * (255f / factor)),
                (int)(Math.Round(factor * (double)(OldPixel.B / 255f)) * (255f / factor))
                );
        }

        static Color LimitAlpha(int x, int y, Color OldPixel, int factor)
        {
            return Color.FromArgb((int)(Math.Round(factor * (double)(OldPixel.A / 255f)) * (255f / factor)), OldPixel);
        }

        static Vector4 GetErr(int x, int y, Color OldPixel, Color NewPixel)
        {
            return new Vector4(
                OldPixel.A - NewPixel.A,
                OldPixel.R - NewPixel.R,
                OldPixel.G - NewPixel.G,
                OldPixel.B - NewPixel.B
                );
        }

        static float Clamp(float num) //not fully sure how to implument this, I might just make it clamp between 0 and 255... it's 4 am and I'm very hungry
                                      //for future dev, if you want to change the range, change 0 and 255. Idealy you pass in a vector2 when you call the function to determine the range
        {
            if (num > 255)
                return 255;
            if (num < 0)
                return 0;
            else
                return num;

        }

        
        void FixAlphaErr(Bitmap Original, Bitmap pb1) //old implumentation that works with multi threading. Dosen't allow for re dithering for all frames but that's asking a bit much imo. if I would implument something like Orginal_ but for all frames it would porbably need a copy of the list AllFrames
        {
            for (int y = 0; y < pb1.Height; y++)
            {
                for (int x = 0; x < pb1.Width; x++)
                {
                    Color OldPixel = Original.GetPixel(x, y);
                    if (OldPixel.A == 255)
                    {
                        pb1.SetPixel(x, y, OldPixel);
                    }

                }
            }
            fixAlgorithmError(pb1);
        }
        void fixAlgorithmError(Bitmap pb1)
        {
            if (fix_Algorithm_err.Checked)
            {
                for (int x = 0; x < pb1.Width - 1; x++)
                {
                    pb1.SetPixel(x, pb1.Height - 1, Color.Transparent);
                }
                for (int y = 0; y < pb1.Height - 1; y++)
                {
                    pb1.SetPixel(pb1.Width - 1, y, Color.Transparent);
                }
            }
        }
        private void reset_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = AllFrames.ElementAt((int)current_frame.Value);
        }

        void Dith_all_Click(object sender, EventArgs e)
        {
            if (opened)
            {
                isAllowedToPlayback = false;

                
                Thread finished = new Thread(() => loadingBar());
                finished.Start();
                int i = 0;
                foreach (var item in AllOrginal_)
                {
                    Thread thread1 = new Thread(() => Dither_All_Frames(item, Alpha_err_fix, openFileDialog1, pictureBox1, i)); //ughh.... passing all thoes things feels wrong
                    thread1.Start();
                    i++;
                }

                Console.WriteLine("Finished initializing all frames");

                //for (int i = 0; i < AllOrginal_.Count; i++)
                //{
                //    Thread thread1 = new Thread(() => Dither_All_Frames(AllOrginal_[i], Alpha_err_fix, openFileDialog1, pictureBox1, i)); //ughh.... passing all thoes things feels wrong
                //    thread1.Start();
                //}

            }
        }

        void loadingBar()
        {
            completedOperations = 0;
            totalOperations = AllFrames.Count * 2;
            while (completedOperations < totalOperations + 1)
            {
                if (completedOperations == totalOperations)
                {
                    Console.WriteLine("\nfinished!\n");
                    isAllowedToPlayback = true;
                    completedOperations += 10;
                }
            }
        }

        void Dither_All_Frames(Image OGframe, CheckBox Alpha_err_fix, OpenFileDialog openFileDialog1, PictureBox pictureBox1, int i)
        {
            Console.WriteLine("Started dithering frame " + i);
            completedOperations++;
            Bitmap orginal_frame = new Bitmap(OGframe);
            Bitmap pb1 = new Bitmap(OGframe);
            Color OldPixel;
            Color NewPixel;
            Color tmp;

            for (int y = 0; y < pb1.Height - 1; y++)
            {
                for (int x = 1; x < pb1.Width - 1; x++)
                {

                    OldPixel = Color.FromArgb(pb1.GetPixel(x, y).ToArgb());
                    if (OldPixel.A != 255)
                    {
                        
                        //Console.WriteLine(i + " y " + y + "  x " + x);
                        NewPixel = LimitAlpha(x, y, OldPixel, 1);
                        pb1.SetPixel(x, y, NewPixel); //uncomment for cool effect lol
                        Vector4 qErr = GetErr(x, y, OldPixel, NewPixel);

                        tmp = pb1.GetPixel(x + 1, y);
                        pb1.SetPixel(
                            x + 1, y, Color.FromArgb(
                            (int)Clamp(tmp.A + qErr.A * (7 / 16f)), tmp.R,
                            tmp.G,
                            tmp.B
                            ));


                        tmp = pb1.GetPixel(x - 1, y + 1);
                        pb1.SetPixel(
                            x - 1, y + 1, Color.FromArgb(
                            (int)Clamp(tmp.A + qErr.A * (3 / 16f)), tmp.R,
                            tmp.G,
                            tmp.B
                            ));

                        tmp = pb1.GetPixel(x, y + 1);
                        pb1.SetPixel(
                            x, y + 1, Color.FromArgb(
                            (int)Clamp(tmp.A + qErr.A * (5 / 16f)), tmp.R,
                            tmp.G,
                            tmp.B
                            ));

                        tmp = pb1.GetPixel(x + 1, y + 1);
                        pb1.SetPixel(
                            x + 1, y + 1, Color.FromArgb(
                            (int)Clamp(tmp.A + qErr.A * (1 / 16f)),
                            tmp.R,
                            tmp.G,
                            tmp.B
                            ));
                    }
                    else
                    {
                        pb1.SetPixel(x, y, Color.FromArgb(255, OldPixel));
                    }

                }
            }
            if (Alpha_err_fix.Checked)
                FixAlphaErr(orginal_frame, pb1);
            pictureBox1.Image = pb1;
            AllFrames[i - 1] = pb1;
            Console.WriteLine("Complated dithering frame " + i);
            completedOperations++;

        }

        private void animate_CheckedChanged(object sender, EventArgs e) //sets the correct state of the animation, basically turn it of and on correctly
        {
             //current frame

            Thread animate_woork = new Thread(() => wooooooork(playback_fps, current_frame, animate, AllFrames, pictureBox1));

            if (animate.Checked)
            {
                isAllowedToPlayback = true;
                animate_woork.Start();
            }
            else { 
                animate_woork.Abort();
                current_frame.Value = currentFrame_ - 1;
            }

        }

        void wooooooork (NumericUpDown playback_fps, NumericUpDown numericUpDown2, CheckBox animate, List<Image> AllFrames, PictureBox pictureBox1) //if you want to use a new thread you need to make it a seperate fucntion
        {
            while (animate.Checked) //this is all kinda garbage code but it seems to run 50 and 60 fps well so not planning on fixing it ;p
            {
                pictureBox1.Image = AllFrames[currentFrame_ - 1];
                Thread.Sleep(1000 / (int)playback_fps.Value);
                if (currentFrame_ < AllFrames.Count)
                    currentFrame_++;
                else
                    currentFrame_ = 1;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) //code for zooming in on pictubebox1 when its clicked, if possible it should zoom in on the cursors possition
        {
            //if (!isZoomed)
            //{
            //    Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            //    PictureBox zoomed = pictureBox1;
            //    zoomed.Height = zoomed.Height * 2;
            //    zoomed.Width = zoomed.Width * 2;
            //    graphics.DrawImage(zoomed.Image, new Rectangle(-1 * (int)(zoomed.Width * 0.5f), -1 * (int)(zoomed.Width * 0.5f), zoomed.Width, zoomed.Height));
            //    isZoomed = true;
            //}
            //else
            //{
            //    Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            //    Bitmap zoomed = pictureBox1;
            //    zoomed.Height = (int)(zoomed.Height * 0.5);
            //    zoomed.Width = (int)(zoomed.Width * 0.5);
            //    //graphics.DrawImage(zoomed.Image, new Rectangle(-100, -100, zoomed.Width, zoomed.Height));



            //    pictureBox1.Image = zoomed.Image;
            //    isZoomed = false;
            //}

            //pictureBox1.ClientSize = new Size(pictureBox1.Width / 2, pictureBox1.Height / 2);

            //PictureBox tmpZoom = Original_;

            //tmpZoom.Height *= 2;

            PopupForm popup = new PopupForm(pictureBox1.Image);
            popup.Show(this);
            
        }

        private void open_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Press to Open an image or images", open);
        }

        private void save_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Press to Save all loaded images", save);
        }

        private void reset_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Restart the program, nothing will be saved", reset);
        }

        private void dither_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Dither current image using normal Floyd Steinberg Dithering \n Mainly here for fun lol", dither);
        }
        private void ditherAlpha_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("Dithers the Alpha (transparency) of the current image", ditherAlpha);
        }

        private void Dith_all_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Dithers the Alpha (transparency) of All loaded frames", Dith_all);

        }
    }
}