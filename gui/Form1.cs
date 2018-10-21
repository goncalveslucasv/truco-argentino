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
        be.Ronda ronda;
        be.Turno turno;
        bll.Ronda rondaServices = new bll.Ronda();
        bll.Turno turnoServices = new bll.Turno();
        bll.Mano manoServices = new bll.Mano();
        bll.Truco trucoServices = new bll.Truco();

        List<be.Jugador> jugadores = new List<be.Jugador>();


        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                be.Jugador jugador = new be.Jugador(textBox1.Text);
                jugadores.Add(jugador);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                be.Jugador jugador = new be.Jugador(textBox2.Text);
                jugadores.Add(jugador);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (jugadores.Count >= 2)
            {
                partida = trucoServices.IniciarJuego(jugadores);
                label1.Text = jugadores[0].Nombre;
                label2.Text = jugadores[1].Nombre;

                MessageBox.Show("Partida iniciada: " + partida.Jugadores[0].Nombre + " vs " + partida.Jugadores[1].Nombre);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rondaServices.AsignarPartida(partida);

            crearRonda();

            this.EnlazarEventoUCartas();

            MessageBox.Show("Primera ronda - Turno de: " + turno.Jugador.Nombre);

        }

     

        private void button5_Click(object sender, EventArgs e)
        {
            crearRonda();

            MessageBox.Show("Nueva ronda - Turno de: " + turno.Jugador.Nombre);

        }

        private void crearRonda()
        {
            ronda = rondaServices.CrearRonda();
            turno = turnoServices.cambiarTurno(new be.Turno(), jugadores[0]);
            rondaServices.RepartirCartas(jugadores);
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            trucoUserController1.setCartas(jugadores[0]);
            trucoUserController2.setCartas(jugadores[1]);
            trucoUserController1.nuevaRonda();
            trucoUserController2.nuevaRonda();
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
            //sacar esta responsabilidad del front

            int index = partida.Rondas.Count - 1;
            jugadorServices.TirarCarta(uController.Jugador, carta, partida.Rondas[index].Manos[partida.Rondas[index].UltimaManoJugada]);
            //sacar esta responsabilidad del front

            turnoServices.alternarTurno(turno, partida);

            if(uController.Jugador == jugadores[0])
            {
                listBox7.Items.Add(jugadores[0].CartaJugada);
            }
            else
            {
                listBox8.Items.Add(jugadores[1].CartaJugada);
            }
            MessageBox.Show("Ahora es turno de: " + turno.Jugador.Nombre);
        }

    
        private void button11_Click(object sender, EventArgs e)
        {
            //sacar esta responsabilidad del front

            int index = partida.Rondas.Count - 1;

            //sacar esta responsabilidad del front

            trucoServices.CompararMano(partida.Rondas[index].Manos[partida.Rondas[index].UltimaManoJugada], partida);
            label3.Text = "Manos Ganadas: "+ jugadores[0].ManosGanadas;
            label4.Text = "Manos Ganadas: "+ jugadores[1].ManosGanadas;

            bll.Jugador jugadorServices = new bll.Jugador(jugadores);


            if (jugadorServices.contarCartas(jugadores[0]) == 0 && jugadorServices.contarCartas(jugadores[1]) == 0)
            {

                crearRonda();
                //sacar esta responsabilidad del front

                rondaServices.AsignarPuntos(jugadores);

                //sacar esta responsabilidad del front
                jugadores[0].ManosGanadas = 0;
                jugadores[1].ManosGanadas = 0;

                label5.Text = "Puntaje: "+jugadores[0].Puntaje;
                label6.Text = "Puntaje: "+jugadores[1].Puntaje;

                label3.Text = "Manos Ganadas: 0";
                label4.Text = "Manos Ganadas: 0";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

     
    }
}
