using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class TrucoUserController : UserControl
    {
        public TrucoUserController()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile("img\\1c.jpg");
            pictureBox2.Image = Image.FromFile("img\\1e.jpg");
            pictureBox3.Image = Image.FromFile("img\\1o.jpg");
        }
    }
}
