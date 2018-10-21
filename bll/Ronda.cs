using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using be;

namespace bll
{
    public class Ronda
    {
        private be.Partida partida;

        public void AsignarPartida(be.Partida Partida)
        {
            partida = Partida;
        }
            
        public be.Ronda CrearRonda()
        {
            be.Ronda ronda = new be.Ronda();
            ronda.Manos = bll.Mano.crearManos();
            partida.Rondas.Add(ronda);

            return ronda;
        }

        public void AsignarPuntos(List<be.Jugador> jugadores)
        {
            if (jugadores[0].ManosGanadas > jugadores[1].ManosGanadas)
            {
                jugadores[0].Puntaje = jugadores[0].Puntaje + 1;
            } else
            {
                jugadores[1].Puntaje = jugadores[0].Puntaje + 1;

            }
        }

        public void RepartirCartas(List<be.Jugador> jugadores)
        {

            jugadores[0].Cartas = null;
            jugadores[1].Cartas = null;

            jugadores[0].Cartas = new List<be.Carta>();
            jugadores[1].Cartas = new List<be.Carta>();

            bll.Mazo mazo = new bll.Mazo(new be.Mazo());


            jugadores[0].Cartas.Add(mazo.darCarta());
            jugadores[0].Cartas.Add(mazo.darCarta());
            jugadores[0].Cartas.Add(mazo.darCarta());
            jugadores[1].Cartas.Add(mazo.darCarta());
            jugadores[1].Cartas.Add(mazo.darCarta());
            jugadores[1].Cartas.Add(mazo.darCarta());

        }




    
    }
}
