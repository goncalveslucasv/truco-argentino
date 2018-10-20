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
            Random random = new Random(generarSeed());
            int index = random.Next(mazoActual.Cartas.Count);
            be.Carta carta = mazoActual.Cartas[index];
            mazoActual.Cartas.RemoveAt(index);
            return carta;
        }

        private int generarSeed()
        {
            var guid = Guid.NewGuid();
            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(justNumbers.Substring(0, 4));
            return seed;
        }
    }
}
