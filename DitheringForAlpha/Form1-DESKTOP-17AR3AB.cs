using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DitheringForAlpha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool opened = false;


        private void open_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult_ = openFileDialog1.ShowDialog();
            if (dialogResult_ == DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

                Console.WriteLine("height " + pictureBox1.Image.Height + "\n" + "width " + pictureBox1.Image.Width + "\n");

                opened = true;

            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (opened)
            {
                SaveFileDialog saveFileDialog_ = new SaveFileDialog(); //lol figuer it out yourself meathead
                saveFileDialog_.Filter = "Images| * .png;*.bmp;*.jpg"; //I have no fucking idea of what this does
                ImageFormat imageFormat_ = ImageFormat.Png; //deafult value I think
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
                    pictureBox1.Image.Save(saveFileDialog_.FileName, imageFormat_);
                }
            }
        }
        private void dither_Click(object sender, EventArgs e)
        {
            Bitmap pb1 = (Bitmap)pictureBox1.Image;
            Color OldPixel;
            Color NewPixel;
            Color tmp;

            for (int y = 0; y < pb1.Height - 1; y++)
            {
                Console.WriteLine(y);
                for (int x = 1; x < pb1.Width - 1; x++)
                {
                    OldPixel = Color.FromArgb(pb1.GetPixel(x, y).ToArgb());

                        NewPixel = LimitColors(x, y, OldPixel, 4);
                        pb1.SetPixel(x, y, NewPixel); //uncomment for cool effect lol
                        Vector4 qErr = GetErr(x, y, OldPixel, NewPixel);

                        tmp = pb1.GetPixel(x + 1, y);
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
        private void ditherAlpha_Click(object sender, EventArgs e)
        {
            Bitmap pb1 = (Bitmap)pictureBox1.Image;
            Color OldPixel;
            Color NewPixel;
            Color tmp;


            for (int y = 0; y < pb1.Height - 1; y++)
            {
                Console.WriteLine(y);
                for (int x = 1; x < pb1.Width - 1; x++)
                {

                    OldPixel = Color.FromArgb(pb1.GetPixel(x, y).ToArgb());
                    if (OldPixel.A < 254)
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
            pictureBox1.Image = pb1;


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
        static Color LimitAlpha(int x,int y, Color OldPixel, int factor)
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

        
    }
}
