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
        uMesa umesa;

        List<be.Jugador> jugadores = new List<be.Jugador>(); 


        public Form1()
        {
            InitializeComponent();

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

            rondaServices.nuevaRonda();
            this.trucoUserControlNuevaRonda();
            rondaServices.AsignarPuntos(jugadores);

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

        // cantar truco
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(partida.Turno.Jugador.Nombre + " Te canto truco!", "Truco!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
               
            }
            else
            {
                partida.Turno.Jugador.ManosGanadas = 99;
                rondaServices.AsignarPuntos(partida.Jugadores);

                rondaServices.nuevaRonda();
                this.trucoUserControlNuevaRonda();
                bloquearCartasPorTurno();
      

                label5.Text = "Puntaje: " + jugadores[0].Puntaje;
                label6.Text = "Puntaje: " + jugadores[1].Puntaje;

                label3.Text = "Manos Ganadas: 0";
                label4.Text = "Manos Ganadas: 0";

            }
        }
    }
}
