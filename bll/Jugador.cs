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

        public int contarCartas(be.Jugador jugador)
        {
            foreach (be.Carta carta in jugador.Cartas)
            {
                if(carta != null)
                {
                    return 1;
                }
            }
            return 0;
        }

        public void TirarCarta(be.Jugador jugador, be.Carta carta, be.Mano mano)
        {
            jugador.CartaJugada = carta;

            int indice = jugador.Cartas.IndexOf(carta);
            jugador.Cartas[indice] = null;
            mano.Jugadores.Add(jugador);

        }

    }
}