using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll
{
    public class Truco
    {
        public void IniciarJuego()
        {
            Truco truco = new Truco();
            truco.IniciarJuego();

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
