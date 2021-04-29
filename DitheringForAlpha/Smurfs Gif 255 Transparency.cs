﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DitheringForAlpha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Smurs Alpha Dithering"; //idk how to change application name through visual studio so this will have to do...
        }

        bool opened = false; //used for when saving and doing some checks
        List<Image> AllFrames = new List<Image>(); //contains all frames for when animation is used
        string path; //needed to use a string for it when saving mutiple images to one path
        PictureBox Original_;

        private void open_Click(object sender, EventArgs e) //lets the user add/import images. Got this code from another projeckt, but might have stolen it from a tutorial...
        {
            DialogResult dialogResult_ = openFileDialog1.ShowDialog();

            if (dialogResult_ == DialogResult.OK)
            {
                path = Path.GetDirectoryName(openFileDialog1.FileName);
                foreach (String file in openFileDialog1.FileNames)
                {
                    PictureBox pb = new PictureBox(); //creates a new picture box for each new frame, works fine now but could be improved upon for better ram usage potentially. 
                    Image loadedImage = Image.FromFile(file);
                    pictureBox1.Image = Image.FromFile(file);

                    AllFrames.Add(loadedImage);
                    pb.Height = loadedImage.Height; //some nessesary stuff to get images put into objects correctly
                    pb.Width = loadedImage.Width;
                    pb.Image = loadedImage;
                    Dith_all.Text = "Dither all in list (" + AllFrames.Count + ")";
                }

                current_frame.Maximum = AllFrames.Count - 1; //sets the correct range for the induvidual frame viewr thingy (play around with the program, you'll figure it out) so it dosen't get a index out of range
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                Original_ = pictureBox1;
                Console.WriteLine("height " + pictureBox1.Image.Height + "\n" + "width " + pictureBox1.Image.Width + "\n"); 

                groupBox_Dithering.Enabled = true; //enables the buttons for dithering
                groupBox_Dithering_A.Enabled = true; //enables the buttons for Alpha dithering
                save.Enabled = true; //enables save

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
                    string ext /*????*/ = Path.GetExtension(saveFileDialog_.FileName);
                    switch (ext)
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
                    //FileStream fs = new FileStream(Path.GetExtension(saveFileDialog_.FileName), new FileMode());
                    int i = 1;
                    string path = saveFileDialog_.FileName;
                    foreach (Image item in AllFrames) //saves all files with user specified name plus a number for each frame
                    {
                        item.Save(path.Split('.')[0] + i + "." + path.Split('.')[1]); //magic string trickery to get the number in place correctly while still beaing searchable by the user
                        //Console.WriteLine(i + saveFileDialog_.FileName, imageFormat_);
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
            DoDither();


            //note to future self, inplument multithreading for lare immages, both of single dithering/AlphaD, maybe even for DitherAllFrames() as well
        }
        //void DoDitherR() 
        //{
        //    if (opened)
        //    {
        //        Bitmap pb1 = (Bitmap)pictureBox1.Image;
        //        Color OldPixel;
        //        Color NewPixel;
        //        Color tmp;
        //        if (GreyScale.Checked)
        //            GreyScaleImage(pb1);

        //        for (int y = 0; y < pb1.Height - 1; y++)
        //        {
        //            Console.WriteLine(y);
        //            for (int x = 1; x < pb1.Width - 1; x++)
        //            {
        //                OldPixel = Color.FromArgb(pb1.GetPixel(x, y).ToArgb());

        //                NewPixel = LimitColors(x, y, OldPixel, (int)numericUpDown1.Value);
        //                pb1.SetPixel(x, y, NewPixel); //uncomment for cool effect lol
        //                Vector4 qErr = GetErr(x, y, OldPixel, NewPixel);

        //                tmp = pb1.GetPixel(x + 1, y);
        //                pb1.SetPixel(
        //                    x + 1, y, Color.FromArgb(
        //                    (int)Clamp(tmp.R + qErr.R * (7 / 16f)),
        //                    tmp.G,
        //                    tmp.B

        //                    ));

        //                tmp = pb1.GetPixel(x - 1, y + 1);
        //                pb1.SetPixel(
        //                    x - 1, y + 1, Color.FromArgb(
        //                    (int)Clamp(tmp.R + qErr.R * (3 / 16f)),
        //                    tmp.G,
        //                    tmp.B

        //                    ));

        //                tmp = pb1.GetPixel(x, y + 1);
        //                pb1.SetPixel(
        //                    x, y + 1, Color.FromArgb(
        //                    (int)Clamp(tmp.R + qErr.R * (5 / 16f)),
        //                    tmp.G,
        //                    tmp.B

        //                    ));

        //                tmp = pb1.GetPixel(x + 1, y + 1);
        //                pb1.SetPixel(
        //                    x + 1, y + 1, Color.FromArgb(
        //                    (int)Clamp(tmp.R + qErr.R * (1 / 16f)),
        //                    tmp.G,
        //                    tmp.B

        //                    ));

        //            }
        //        }

        //        pictureBox1.Image = pb1;
        //    }
        //}
        //void DoDitherG()
        //{
        //    if (opened)
        //    {
        //        Bitmap pb1 = (Bitmap)pictureBox1.Image;
        //        Color OldPixel;
        //        Color NewPixel;
        //        Color tmp;
        //        if (GreyScale.Checked)
        //            GreyScaleImage(pb1);

        //        for (int y = 0; y < pb1.Height - 1; y++)
        //        {
        //            Console.WriteLine(y);
        //            for (int x = 1; x < pb1.Width - 1; x++)
        //            {
        //                OldPixel = Color.FromArgb(pb1.GetPixel(x, y).ToArgb());

        //                NewPixel = LimitColors(x, y, OldPixel, (int)numericUpDown1.Value);
        //                pb1.SetPixel(x, y, NewPixel); //uncomment for cool effect lol
        //                Vector4 qErr = GetErr(x, y, OldPixel, NewPixel);

        //                tmp = pb1.GetPixel(x + 1, y);
        //                pb1.SetPixel(
        //                    x + 1, y, Color.FromArgb(
        //                    tmp.R,
        //                    (int)Clamp(tmp.G + qErr.G * (7 / 16f)),
        //                    tmp.B

        //                    ));

        //                tmp = pb1.GetPixel(x - 1, y + 1);
        //                pb1.SetPixel(
        //                    x - 1, y + 1, Color.FromArgb(
        //                    tmp.R,
        //                    (int)Clamp(tmp.G + qErr.G * (3 / 16f)),
        //                    tmp.B

        //                    ));

        //                tmp = pb1.GetPixel(x, y + 1);
        //                pb1.SetPixel(
        //                    x, y + 1, Color.FromArgb(
        //                    tmp.R,
        //                    (int)Clamp(tmp.G + qErr.G * (5 / 16f)),
        //                    tmp.B

        //                    ));

        //                tmp = pb1.GetPixel(x + 1, y + 1);
        //                pb1.SetPixel(
        //                    x + 1, y + 1, Color.FromArgb(
        //                    tmp.R,
        //                    (int)Clamp(tmp.G + qErr.G * (1 / 16f)),
        //                    tmp.B

        //                    ));

        //            }
        //        }

        //        pictureBox1.Image = pb1;
        //    }
        //}
        //void DoDitherB()
        //{
        //    if (opened)
        //    {
        //        Bitmap pb1 = (Bitmap)pictureBox1.Image;
        //        Color OldPixel;
        //        Color NewPixel;
        //        Color tmp;
        //        if (GreyScale.Checked)
        //            GreyScaleImage(pb1);

        //        for (int y = 0; y < pb1.Height - 1; y++)
        //        {


        //            Console.WriteLine(y);
        //            for (int x = 1; x < pb1.Width - 1; x++)
        //            {
        //                OldPixel = Color.FromArgb(pb1.GetPixel(x, y).ToArgb());

        //                NewPixel = LimitColors(x, y, OldPixel, (int)numericUpDown1.Value);
        //                pb1.SetPixel(x, y, NewPixel); //uncomment for cool effect lol
        //                Vector4 qErr = GetErr(x, y, OldPixel, NewPixel);

        //                tmp = pb1.GetPixel(x + 1, y);
        //                pb1.SetPixel(
        //                    x + 1, y, Color.FromArgb(
        //                    tmp.R,
        //                    tmp.G,
        //                    (int)Clamp(tmp.B + qErr.B * (7 / 16f))

        //                    ));

        //                tmp = pb1.GetPixel(x - 1, y + 1);
        //                pb1.SetPixel(
        //                    x - 1, y + 1, Color.FromArgb(
        //                    tmp.R,
        //                    tmp.G,
        //                    (int)Clamp(tmp.B + qErr.B * (3 / 16f))

        //                    ));

        //                tmp = pb1.GetPixel(x, y + 1);
        //                pb1.SetPixel(
        //                    x, y + 1, Color.FromArgb(
        //                    tmp.R,
        //                    tmp.G,
        //                    (int)Clamp(tmp.B + qErr.B * (5 / 16f))

        //                    ));

        //                tmp = pb1.GetPixel(x + 1, y + 1);
        //                pb1.SetPixel(
        //                    x + 1, y + 1, Color.FromArgb(
        //                    tmp.R,
        //                    tmp.G,
        //                    tmp.B

        //                    ));

        //            }
        //        }

        //        pictureBox1.Image = pb1;
        //    }
        //}

        void DoDither() //normal floyd steinberg dithering, semi optemised, read the wiki on it and code trains vid for an explinatio of the algo
        {
            if (opened)
            {
                Bitmap pb1 = (Bitmap)Original_.Image;
                Color OldPixel;
                Color NewPixel;
                Color tmp;
                if (GreyScale.Checked)
                    GreyScaleImage(pb1);

                for (int y = 0; y < pb1.Height - 1; y++)
                {
                    Console.WriteLine(y);
                    for (int x = 1; x < pb1.Width - 1; x++)
                    {
                        OldPixel = Color.FromArgb(pb1.GetPixel(x, y).ToArgb());

                        NewPixel = LimitColors(x, y, OldPixel, (int)dither_steps.Value);
                        pb1.SetPixel(x, y, NewPixel); //uncomment for cool effect lol
                        Vector4 qErr = GetErr(x, y, OldPixel, NewPixel);

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

                pictureBox1.Image = pb1; 
            }
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
            if (opened)
            {
                Bitmap pb1 = (Bitmap)Original_.Image;
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
                    FixAlphaErr((Bitmap)Image.FromFile(openFileDialog1.FileName), pb1);
                pictureBox1.Image = pb1;
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
            return Color.FromArgb(
                (int)(Math.Round(factor * (double)(OldPixel.A / 255f)) * (255f / factor)), OldPixel
                );
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

        static void FixAlphaErr(Bitmap pre_limitColor, Bitmap pb1)
        {
            for (int y = 0; y < pb1.Height; y++)
            {
                for (int x = 0; x < pb1.Width; x++)
                {
                    Color OldPixel = pre_limitColor.GetPixel(x, y);
                    if (OldPixel.A == 255)
                    {
                        pb1.SetPixel(x, y, OldPixel);
                    }

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

        private void Dith_all_Click(object sender, EventArgs e)
        {
            if (opened)
            {
                int i = 0;
                foreach (Image item in AllFrames)
                {
                    //Console.WriteLine("started thread " + i);
                    Thread thread1 = new Thread(() => Dither_All_Frames(Alpha_err_fix, openFileDialog1, pictureBox1, item, i)); //ughh.... passing all thoes things feels wrong
                    thread1.Start();
                    i++;
                }
            }
        }

        static void Dither_All_Frames(CheckBox Alpha_err_fix, OpenFileDialog openFileDialog1, PictureBox pictureBox1, Image item, int i)
        {
            Bitmap pb1 = (Bitmap)item;
            Color OldPixel;
            Color NewPixel;
            Color tmp;

            for (int y = 0; y < pb1.Height - 1; y++)
            {
                //Console.WriteLine(y);
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
                FixAlphaErr((Bitmap)Image.FromFile(openFileDialog1.FileName), pb1);
            pictureBox1.Image = pb1;
            Console.WriteLine(i);
        }

        private void animate_CheckedChanged(object sender, EventArgs e) //sets the correct state of the animation, basically turn it of and on correctly
        {
            Thread animate_woork = new Thread(() => wooooooork(playback_fps, current_frame, animate, AllFrames, pictureBox1));

            if (animate.Checked)
            {
                animate_woork.Start();
            }
            else
                animate_woork.Abort();
        }
        void wooooooork (NumericUpDown playback_fps, NumericUpDown numericUpDown2, CheckBox animate, List<Image> AllFrames, PictureBox pictureBox1) //if you want to use a new thread you need to make it a seperate fucntion
        {

            int i = (int)numericUpDown2.Value; //current frame
            while (animate.Checked || i<AllFrames.Count - 1) //this is all kinda garbage code but it seems to run 50 and 60 fps well so not planning on fixing it ;p
            {
                Thread.Sleep(1000 / (int)playback_fps.Value);
                if (i < AllFrames.Count)
                    i++;
                else
                    i = 1;
                pictureBox1.Image = AllFrames.ElementAt(i - 1);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) //code for zooming in on pictubebox1 when its clicked, if possible it should zoom in on the cursors possition
        {
            //if (!isZoomed) { 
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
        }
    }
}
