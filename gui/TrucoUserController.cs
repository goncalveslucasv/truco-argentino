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
        public be.Jugador Jugador;
        public delegate void delOnClick(TrucoUserController uController, be.Carta carta);
        public event delOnClick OnClick;

        public TrucoUserController()
        {
            InitializeComponent();
        }

        public void nuevaRonda()
        {
            pictureBox1.Show();
            pictureBox2.Show();
            pictureBox3.Show();
        }
        public void setCartas(be.Jugador jugador)
        {
            Jugador = jugador;

           

            pictureBox1.Image = Image.FromFile(@"C:\Users\casVicente.Goncalves\Desktop\img\"+ jugador.Cartas[0].getImageName());
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Image.FromFile(@"C:\Users\casVicente.Goncalves\Desktop\img\"+ jugador.Cartas[1].getImageName());
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = Image.FromFile(@"C:\Users\casVicente.Goncalves\Desktop\img\"+ jugador.Cartas[2].getImageName());
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.OnClick(this, Jugador.Cartas[2]);
            pictureBox3.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(this, Jugador.Cartas[0]);
            pictureBox1.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.OnClick(this, Jugador.Cartas[1]);
            pictureBox2.Hide();

        }
    }
}
