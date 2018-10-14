using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bll
{
    public class Jugador
    {
        private List<be.Jugador> jugadores = new List<be.Jugador>();

        public Jugador(List<be.Jugador> Jugadores)
        {
            jugadores = Jugadores;
        }

        public void TirarCarta(be.Jugador jugador, be.Carta carta, be.Mano mano)
        {
            jugador.CartaJugada = carta;
            mano.Jugadores.Add(jugador);

        }

    }
}