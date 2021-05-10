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
            panel1.AutoScroll = true;
            popoutPB.Image = img;
        }

        private void popoutPB_Click(object sender, EventArgs e)
        {

        }
    }
}
