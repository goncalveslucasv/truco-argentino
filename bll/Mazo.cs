using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using be;

namespace bll
{
    public class Mazo
    {
        private be.Mazo mazoActual;

        public Mazo(be.Mazo nuevoMazo)
        {
            mazoActual = nuevoMazo;
            
        }

        public be.Carta darCarta()
        {
            Random random = new Random();
            int index = random.Next(mazoActual.Cartas.Count);
            be.Carta carta = mazoActual.Cartas[index];
            mazoActual.Cartas.RemoveAt(index);
            return carta;
        }
    }
}