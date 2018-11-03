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
    public partial class Form1 : Form
    {
        be.Partida partida;
        bll.Ronda rondaServices = new bll.Ronda();
        bll.Turno turnoServices = new bll.Turno();
        bll.Mano manoServices = new bll.Mano();
        bll.Truco trucoServices = new bll.Truco();
        bll.Envido envidoServices = new bll.Envido();
        frmTruco frmTruco;
        frmTruco frmReTruco;
        frmTruco frmValeCuatro;
        uMesa umesa;
        bool flor = false;

        List<be.Jugador> jugadores = new List<be.Jugador>(); 


        public Form1()
        {
            InitializeComponent();
            ToggleBotones(false);
            button8.Enabled = false;
            button9.Enabled = false;
        }

        public void ToggleBotones(bool enabled)
        {
            button1.Enabled = enabled;
            button2.Enabled = enabled;
            button4.Enabled = enabled;
            button5.Enabled = enabled;
            button6.Enabled = enabled;
            button7.Enabled = enabled;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            crearJugadores();

            if (jugadores.Count >= 2)
            {
                partida = trucoServices.IniciarJuego(jugadores, rondaServices);
                label1.Text = jugadores[0].Nombre;
                label2.Text = jugadores[1].Nombre;

            }

            this.trucoUserControlNuevaRonda();

            this.EnlazarEventoUCartas();

            trucoUserController2.bloquearCartas(); 

            crearUserControllMesa();

            ToggleBotones(true);

            MessageBox.Show("Partida iniciada: " + partida.Jugadores[0].Nombre + " vs " + partida.Jugadores[1].Nombre + " @ Turno de: " + partida.Turno.Jugador.Nombre);

        }

        private void crearJugadores()
        {
            if (textBox1.Text.Length > 0)
            {
                be.Jugador jugador = new be.Jugador(textBox1.Text);
                jugadores.Add(jugador);
            }

            if (textBox2.Text.Length > 0)
            {
                be.Jugador jugador = new be.Jugador(textBox2.Text);
                jugadores.Add(jugador);
            }
        }

        private void crearUserControllMesa()
        {
            umesa = new uMesa(partida);
            umesa.Size = new Size(460, 350);
            umesa.Location = new Point(365, 215);
            this.Controls.Add(umesa);
        }

        private void trucoUserControlNuevaRonda()
        {
            ToggleBotones(true);
            button8.Enabled = false;
            button9.Enabled = false;
            flor = false;
            trucoUserController1.setCartas(jugadores[0]);
            trucoUserController2.setCartas(jugadores[1]);
            trucoUserController1.nuevaRonda();
            trucoUserController2.nuevaRonda();
            if (umesa != null)
            {
                umesa.Limpiar();
            }
        }

        private void EnlazarEventoUCartas()
        {
            trucoUserController1.setCartas(jugadores[0]);
            trucoUserController2.setCartas(jugadores[1]);

            trucoUserController1.OnClick += tirarCarta;
            trucoUserController2.OnClick += tirarCarta;
        }

        private void tirarCarta(TrucoUserController uController, be.Carta carta)
        {
            bll.Jugador jugadorServices = new bll.Jugador(jugadores);

            int index = rondaServices.RondaActual;

            jugadorServices.TirarCarta(uController.Jugador, carta, rondaServices);

            umesa.mostrarCartaTirada(uController.Jugador, carta);

            label3.Text = "Manos Ganadas: " + jugadores[0].ManosGanadas;
            label4.Text = "Manos Ganadas: " + jugadores[1].ManosGanadas;

            if (jugadorServices.contarCartaJugadores(jugadores) == 0)
            {
                construirNuevaRonda();
            }

            bloquearCartasPorTurno();

        }

        private void bloquearCartasPorTurno()
        {
            if (partida.Turno.Jugador == jugadores[0])
            {
                trucoUserController1.desbloquearCartas();
                trucoUserController2.bloquearCartas();
            }
            else
            {
                trucoUserController2.desbloquearCartas();
                trucoUserController1.bloquearCartas();
            }
        }

        private void construirNuevaRonda()
        {
            rondaServices.AsignarPuntos(jugadores, partida.Rondas[rondaServices.RondaActual].Valor);

            rondaServices.nuevaRonda();
            this.trucoUserControlNuevaRonda();

            label5.Text = "Puntaje: " + jugadores[0].Puntaje;
            label6.Text = "Puntaje: " + jugadores[1].Puntaje;

            label3.Text = "Manos Ganadas: 0";
            label4.Text = "Manos Ganadas: 0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            be.Envido envido = new be.Envido();
            cantarEnvido(envido);
        }

        private void cantarEnvido(be.IEnvido ienvido)
        {
            try
            {
                if ((jugadores[1].ManosGanadas != 0 || jugadores[0].ManosGanadas != 0) || jugadores[0].Envido != null)
                {
                    throw new Exception("Envido solo en primera ronda o ya se canto.");
                }

                envidoServices.contarEnvido(jugadores);
                DialogResult dialogResult = MessageBox.Show(partida.Turno.Jugador.Nombre + " Te canto envido!", "Envido!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int envidoRespuesta = envidoServices.envidoAceptado(partida.Turno.Jugador, ienvido);
                    MessageBox.Show("Tengo: " + envidoRespuesta);
                    if (partida.Turno.Jugador.Envido.getPuntos() >= envidoRespuesta)
                    {
                        MessageBox.Show(partida.Turno.Jugador.Envido.getPuntos() + " son mejores!");
                    }
                    else
                    {
                        MessageBox.Show("Son buenas!");
                    }
                }
                else
                {
                    envidoServices.envidoNoQuerido(partida.Turno.Jugador);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Irse al mazo
        private void button5_Click(object sender, EventArgs e)
        {
            rondaServices.nuevaRonda();
            this.trucoUserControlNuevaRonda();
            rondaServices.seFueAlMazo(partida.Turno.Jugador, partida);

            label5.Text = "Puntaje: " + jugadores[0].Puntaje;
            label6.Text = "Puntaje: " + jugadores[1].Puntaje;

            label3.Text = "Manos Ganadas: 0";
            label4.Text = "Manos Ganadas: 0";

            bloquearCartasPorTurno();

            MessageBox.Show(partida.Turno.Jugador.Nombre + " se fue al mazo");



        }

        private void button6_Click(object sender, EventArgs e)
        {
            be.RealEnvido envido = new be.RealEnvido();
            cantarEnvido(envido);
        }

        private void FrmValeCuatroTruco_closing(object sender, FormClosingEventArgs e)
        {
            be.Truco truco = trucoServices.TrucoCantable();
            switch (frmValeCuatro.button)
            {
                case "y":
                    partida.Rondas[rondaServices.RondaActual].Valor = truco.reCantar.reCantar.PuntosQueridos;
                    button2.Enabled = false;
                    break;

                case "n":
                    noQuerido(truco.reCantar.reCantar.PuntosNoQueridos, partida.Turno.Jugador);
                    break;
            }

        }
        private void FrmReTruco_closing(object sender, FormClosingEventArgs e)
        {
            be.Truco truco = trucoServices.TrucoCantable();
            switch (frmReTruco.button)
            {
                case "y":
                    partida.Rondas[rondaServices.RondaActual].Valor = truco.reCantar.PuntosQueridos;
                    button9.Enabled = true;
                    button2.Enabled = false;
                    break;

                case "n":
                    noQuerido(truco.reCantar.PuntosNoQueridos, trucoServices.jugadorContrario(partida.Turno.Jugador, jugadores));
                    break;

                case "rc":
                    frmValeCuatro = new frmTruco(truco.reCantar.reCantar, partida.Turno.Jugador, false);
                    frmValeCuatro.FormClosing += FrmValeCuatroTruco_closing;
                    frmValeCuatro.ShowDialog();
                    break;
            }

        }
        private void FrmTruco_closing(object sender, FormClosingEventArgs e)
        {
            be.Truco truco = trucoServices.TrucoCantable();

            switch (frmTruco.button)
            {
                case "y":
                    partida.Rondas[rondaServices.RondaActual].Valor = truco.PuntosQueridos;
                    button8.Enabled = true;
                    button2.Enabled = false;
                    break;

                case "n":
                    noQuerido(truco.PuntosNoQueridos, partida.Turno.Jugador);
                    break;

                case "rc":
                    frmReTruco = new frmTruco(truco.reCantar, trucoServices.jugadorContrario(partida.Turno.Jugador, jugadores), true);
                    frmReTruco.FormClosing += FrmReTruco_closing;
                    frmReTruco.ShowDialog();

                    break;
            }

        }
        // cantar truco
        private void button2_Click(object sender, EventArgs e)
        {
            be.Truco truco = trucoServices.TrucoCantable();
            frmTruco = new frmTruco(truco, partida.Turno.Jugador, true);

            frmTruco.FormClosing += FrmTruco_closing;
            frmTruco.ShowDialog();
          
        }

        private void noQuerido(int puntosAlOtroJugador, be.Jugador jugador)
        {
            jugador.ManosGanadas = 99;
            rondaServices.AsignarPuntos(partida.Jugadores, puntosAlOtroJugador);

            rondaServices.nuevaRonda();
            this.trucoUserControlNuevaRonda();
            bloquearCartasPorTurno();


            label5.Text = "Puntaje: " + jugadores[0].Puntaje;
            label6.Text = "Puntaje: " + jugadores[1].Puntaje;

            label3.Text = "Manos Ganadas: 0";
            label4.Text = "Manos Ganadas: 0";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            be.FaltaEnvido envido = new be.FaltaEnvido();
            cantarEnvido(envido);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flor)
            {
                MessageBox.Show("Ya se canto Flor en la ronda");
                return;
            }

            if (envidoServices.calcularFlor(partida.Turno.Jugador))
            {
                flor = true;
                MessageBox.Show(partida.Turno.Jugador.Nombre + " cantó Flor");
            }
            else
            {
                MessageBox.Show("Para cantar Flor, tenes que tener las tres cartas del mismo palo");

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            be.Truco truco = trucoServices.TrucoCantable();
            frmReTruco = new frmTruco(truco.reCantar, partida.Turno.Jugador, true);
            frmReTruco.FormClosing += FrmReTrucoBtn_closing;
            frmReTruco.ShowDialog();
            button8.Enabled = false;
            button9.Enabled = true;
        }
        private void FrmReTrucoBtn_closing(object sender, FormClosingEventArgs e)
        {
            be.Truco truco = trucoServices.TrucoCantable();
            switch (frmReTruco.button)
            {
                case "y":
                    partida.Rondas[rondaServices.RondaActual].Valor = truco.reCantar.PuntosQueridos;
                    button9.Enabled = true;
                    button2.Enabled = false;
                    break;

                case "n":
                    noQuerido(truco.reCantar.PuntosNoQueridos, partida.Turno.Jugador);
                    break;

                case "rc":
                    frmValeCuatro = new frmTruco(truco.reCantar.reCantar, trucoServices.jugadorContrario(partida.Turno.Jugador, jugadores), false);
                    frmValeCuatro.FormClosing += FrmValeCuatroTrucoBtn_closing;
                    frmValeCuatro.ShowDialog();
                    break;
            }

        }
        private void FrmValeCuatroTrucoBtn_closing(object sender, FormClosingEventArgs e)
        {
            be.Truco truco = trucoServices.TrucoCantable();
            switch (frmValeCuatro.button)
            {
                case "y":
                    partida.Rondas[rondaServices.RondaActual].Valor = truco.reCantar.reCantar.PuntosQueridos;
                    button2.Enabled = false;
                    break;

                case "n":
                    noQuerido(truco.reCantar.reCantar.PuntosNoQueridos, trucoServices.jugadorContrario(partida.Turno.Jugador, jugadores));
                    break;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            be.Truco truco = trucoServices.TrucoCantable();
            frmValeCuatro = new frmTruco(truco.reCantar.reCantar, partida.Turno.Jugador, false);
            frmValeCuatro.FormClosing += FrmValeCuatroTruco_closing;
            frmValeCuatro.ShowDialog();
        }
    }
}
