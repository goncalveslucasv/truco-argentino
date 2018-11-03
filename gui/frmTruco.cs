using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class frmTruco : Form
    {
        private be.ITruco truco;

        public be.ITruco Truco
        {
            get { return truco; }
            set { truco = value; }
        }

        public string button { get; set; }

        public frmTruco(be.ITruco truco, be.Jugador jugador, bool reCantar)
        {
            InitializeComponent();
            label1.Text = jugador.Nombre;
            if (reCantar)
            {
                button3.Text = "Quiero " + truco.reCantar.nombre;
            } else
            {
                button3.Hide();
            }
            label2.Text = "Te canto "+ truco.nombre;
        }

        public void seleccionarOpcion(object sender, EventArgs e)
        {
            button = (sender as Button).Tag.ToString();
            this.Close();

        }

      
    }
}
