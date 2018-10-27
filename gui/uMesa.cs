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
    public partial class uMesa : UserControl
    {
        private be.Partida partida;
        private List<be.Carta> cartas1 = new List<be.Carta>();
        private List<be.Carta> cartas2 = new List<be.Carta>();
        public uMesa(be.Partida Partida)
        {
            InitializeComponent();
            partida = Partida;
            pictureBox1.Size = new Size(0,0);
            pictureBox2.Size = new Size(0,0);
            pictureBox3.Size = new Size(0,0);
            pictureBox4.Size = new Size(0,0);
            pictureBox5.Size = new Size(0,0);
            pictureBox6.Size = new Size(0,0);
        }
        public void Limpiar()
        {
            pictureBox1.Size = new Size(0, 0);
            pictureBox2.Size = new Size(0, 0);
            pictureBox3.Size = new Size(0, 0);
            pictureBox4.Size = new Size(0, 0);
            pictureBox5.Size = new Size(0, 0);
            pictureBox6.Size = new Size(0, 0);
            cartas1 = null;
            cartas2 = null;
            cartas1 = new List<be.Carta>();
            cartas2 = new List<be.Carta>();
    }
        public void mostrarCartaTirada(be.Jugador jugador, be.Carta carta)
        {
            if(jugador == partida.Jugadores[0])
            {
                cartas1.Add(carta);
            } else
            {
                cartas2.Add(carta);
            }

            Enlazar();
            

        }
        private void Enlazar()
        {
            if(cartas1.Count() == 1)
            {
                pictureBox1.Image = Image.FromFile(@"imagenes\" + cartas1[0].getImageName());
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Size = new Size(150, 200);
            }
            if (cartas1.Count() == 2)
            {
                pictureBox2.Image = Image.FromFile(@"imagenes\" + cartas1[1].getImageName());
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Size = new Size(150, 200);
            }
            if (cartas1.Count() == 3)
            {
                pictureBox3.Image = Image.FromFile(@"imagenes\" + cartas1[2].getImageName());
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.Size = new Size(150, 200);
            }
            if (cartas2.Count() == 1)
            {
                pictureBox4.Image = Image.FromFile(@"imagenes\" + cartas2[0].getImageName());
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox4.Size = new Size(150, 200);
            }
            if (cartas2.Count() == 2)
            {
                pictureBox5.Image = Image.FromFile(@"imagenes\" + cartas2[1].getImageName());
                pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox5.Size = new Size(150, 200);
            }
            if (cartas2.Count() == 3)
            {
                pictureBox6.Image = Image.FromFile(@"imagenes\" + cartas2[2].getImageName());
                pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox6.Size = new Size(150, 200);
            }

        }

        private void uMesa_Load(object sender, EventArgs e)
        {

        }
    }
}
