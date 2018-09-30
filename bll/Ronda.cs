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
        public be.Ronda CrearRonda(be.Partida partida)
        {
            be.Ronda ronda = new be.Ronda();
            ronda.Manos = bll.Mano.crearManos();
            partida.Rondas.Add(ronda);

            return ronda;
        }

        public be.Mano RepartirCartas(List<be.Jugador> jugadores, be.Mano mano)
        {

            mano.Jugadores = jugadores;
            mano.Jugadores[0].Cartas.Add(bll.Mazo.darCarta());
            mano.Jugadores[0].Cartas.Add(bll.Mazo.darCarta());
            mano.Jugadores[0].Cartas.Add(bll.Mazo.darCarta());
            mano.Jugadores[1].Cartas.Add(bll.Mazo.darCarta());
            mano.Jugadores[1].Cartas.Add(bll.Mazo.darCarta());
            mano.Jugadores[1].Cartas.Add(bll.Mazo.darCarta());

            return mano;



        }



    
    }
}
