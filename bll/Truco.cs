using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll
{
    public class Truco
    {
        private be.Truco truco;
        private be.Partida partida;

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

        public be.Carta CompararCarta(be.Carta carta1, be.Carta carta2)
        {
            if(carta1.Valor > carta2.Valor)
            {
                return carta1;
            } else
            {
                return carta2;
            }


        }


    }
}
