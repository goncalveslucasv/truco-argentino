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

        public void RepartirCartas(List<be.Jugador> jugadores)
        {
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
