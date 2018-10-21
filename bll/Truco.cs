using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll
{
    public class Truco
    {

        public be.Partida IniciarJuego(List<be.Jugador> jugadores)
        {
           be.Truco truco = new be.Truco();
           return new be.Partida(jugadores);
        }

        public be.Mazo CrearMazo()
        {
            be.Mazo mazo = new be.Mazo();
            return mazo;
        }


        public void CompararMano(be.Mano mano, be.Partida partida)
        {
            if(mano.Jugadores[0].CartaJugada.Valor < mano.Jugadores[1].CartaJugada.Valor)
            {
                AsignarPuntos(mano.Jugadores[0]);
            }
            else
            {
                AsignarPuntos(mano.Jugadores[1]);

            }
            partida.Rondas[partida.Rondas.Count() - 1].UltimaManoJugada++;

        }
        private void AsignarPuntos(be.Jugador jugador)
        {
            jugador.ManosGanadas++;

        }

        public be.Carta CompararCarta(be.Carta carta1, be.Carta carta2)
        {
            if(carta1.Valor < carta2.Valor)
            {
                return carta1;
            } else
            {
                return carta2;
            }
        }
    }
}
