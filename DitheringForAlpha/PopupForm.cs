using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaDithering
{
    public partial class PopupForm : Form
    {
        public PopupForm(Image img)
        {
            
            InitializeComponent();

            AdjustSeize();

            panel1.AutoScroll = true;
            popoutPB.Image = new Bitmap(img, img.Width * 2, img.Height * 2);
            
        }

        private void PopupForm_SizeChanged(object sender, EventArgs e)
        {
            AdjustSeize();
        }

        void AdjustSeize()
        {
            panel1.Height = Height - 35;
            panel1.Width = Width - 15;
        }
    }
}
