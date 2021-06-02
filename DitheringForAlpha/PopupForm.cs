using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

namespace AlphaDithering
{
    public partial class PopupForm : Form
    {
        Bitmap IMAGE;

        public PopupForm(Image img)
        {
            
            InitializeComponent();

            AdjustSeize();
            trackBar1.Value = 8;
            panel1.AutoScroll = true;
            popoutPB.Image = new Bitmap(img, img.Width, img.Height);
            IMAGE = (Bitmap)img;
            label1.Text = (trackBar1.Value / 8f).ToString();

        }

        private void PopupForm_SizeChanged(object sender, EventArgs e)
        {
            AdjustSeize();
        }

        void AdjustSeize()
        {
            panel1.Height = Height - 95; //these number just work, don't mess with them
            panel1.Width = Width - 15;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Console.WriteLine(trackBar1.Value / 8f);
            Bitmap img = (Bitmap)popoutPB.Image;
            
            
            popoutPB.Image = new Bitmap(IMAGE, (int)(IMAGE.Width * (trackBar1.Value / 8f)), (int)(IMAGE.Height * (trackBar1.Value / 8f)));
            
            label1.Text = (trackBar1.Value / 8f).ToString();
        }
    }
}
