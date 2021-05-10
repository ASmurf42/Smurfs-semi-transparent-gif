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
            popoutPB.Image = img;
        }

        private void popoutPB_Click(object sender, EventArgs e)
        {

        }
    }
}
