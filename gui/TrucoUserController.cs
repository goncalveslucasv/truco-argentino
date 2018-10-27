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

        private bool cardLock;

        public bool CardLock
        {
            get { return cardLock; }
            set { cardLock = value; }
        }


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

        public void bloquearCartas()
        {
            if (Jugador.Cartas[0] != null) { pictureBox1.Image = Image.FromFile(@"imagenes\lock.png"); }
            if (Jugador.Cartas[1] != null) { pictureBox2.Image = Image.FromFile(@"imagenes\lock.png"); }
            if (Jugador.Cartas[2] != null) { pictureBox3.Image = Image.FromFile(@"imagenes\lock.png"); }
            cardLock = true;
        }

        public void desbloquearCartas()
        {
            if (Jugador.Cartas[0] != null) { pictureBox1.Image = Image.FromFile(@"imagenes\" + Jugador.Cartas[0].getImageName()); }
            if (Jugador.Cartas[1] != null) { pictureBox2.Image = Image.FromFile(@"imagenes\" + Jugador.Cartas[1].getImageName()); }
            if (Jugador.Cartas[2] != null) { pictureBox3.Image = Image.FromFile(@"imagenes\" + Jugador.Cartas[2].getImageName());}
            cardLock = false;
        }


        public void setCartas(be.Jugador jugador)
        {
            Jugador = jugador;
            
            pictureBox1.Image = Image.FromFile(@"imagenes\" + jugador.Cartas[0].getImageName());
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Image.FromFile(@"imagenes\" + jugador.Cartas[1].getImageName());
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = Image.FromFile(@"imagenes\" + jugador.Cartas[2].getImageName());
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(cardLock == false) { 
                pictureBox3.Hide();
                this.OnClick(this, Jugador.Cartas[2]);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (cardLock == false)
            {
                pictureBox1.Hide();
                this.OnClick(this, Jugador.Cartas[0]);
                
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (cardLock == false)
            {
                pictureBox2.Hide();
                this.OnClick(this, Jugador.Cartas[1]);
            }

        }
    }
}
