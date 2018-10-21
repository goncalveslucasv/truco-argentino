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
            if(textBox1.Text.Length > 0)
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

                MessageBox.Show("Partida iniciada: "+partida.Jugadores[0].Nombre+ " vs "+ partida.Jugadores[1].Nombre);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rondaServices.AsignarPartida(partida);
            ronda = rondaServices.CrearRonda();
            turno = turnoServices.cambiarTurno(new be.Turno(), jugadores[0]);
            rondaServices.RepartirCartas(jugadores);

            listBox1.Items.Clear();
            listBox6.Items.Clear();

            listBox7.Items.Clear();
            listBox8.Items.Clear();


            this.AsignarCartas();


            MessageBox.Show("Turno de: " + turno.Jugador.Nombre);

        }

        private void AsignarCartas()
        {
            listBox1.Items.Add(jugadores[0].Cartas[0]);
            listBox1.Items.Add(jugadores[0].Cartas[1]);
            listBox1.Items.Add(jugadores[0].Cartas[2]);

            listBox6.Items.Add(jugadores[1].Cartas[0]);
            listBox6.Items.Add(jugadores[1].Cartas[1]);
            listBox6.Items.Add(jugadores[1].Cartas[2]);




        }

        private void button5_Click(object sender, EventArgs e)
        {
            bll.Jugador jugadorServices = new bll.Jugador(jugadores);

            be.Carta carta = (be.Carta)listBox1.SelectedItem;
            int index = partida.Rondas.Count - 1;
            jugadorServices.TirarCarta(jugadores[0], carta, partida.Rondas[index].Manos[partida.Rondas[index].UltimaManoJugada]);
            turnoServices.alternarTurno(turno, partida);



            listBox7.Items.Add(jugadores[0].CartaJugada);
            listBox1.Items.Remove(carta);
            MessageBox.Show("Ahora es turno de: " + turno.Jugador.Nombre);

        }

  

     

        private void button10_Click(object sender, EventArgs e)
        {
            bll.Jugador jugadorServices = new bll.Jugador(jugadores);

            be.Carta carta = (be.Carta)listBox6.SelectedItem;
            int index = partida.Rondas.Count - 1;
            jugadorServices.TirarCarta(jugadores[1], carta, partida.Rondas[index].Manos[partida.Rondas[index].UltimaManoJugada]);
            turnoServices.alternarTurno(turno, partida);

            listBox8.Items.Add(jugadores[1].CartaJugada);
            listBox6.Items.Remove(carta);
            MessageBox.Show("Ahora es turno de: " + turno.Jugador.Nombre);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int index = partida.Rondas.Count - 1;
    

            trucoServices.CompararMano(partida.Rondas[index].Manos[partida.Rondas[index].UltimaManoJugada], partida);
            label3.Text = "Manos Ganadas: "+ jugadores[0].ManosGanadas;
            label4.Text = "Manos Ganadas: "+ jugadores[1].ManosGanadas;

            if (jugadores[0].Cartas.Count == 0 && jugadores[1].Cartas.Count == 0)
            {

                // sumar puntos de ronda aquí 
                ronda = rondaServices.CrearRonda();
                rondaServices.RepartirCartas(jugadores);
                rondaServices.AsignarPuntos(jugadores);

                listBox1.Items.Clear();
                listBox6.Items.Clear();

                listBox7.Items.Clear();
                listBox8.Items.Clear();

                this.AsignarCartas();


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
