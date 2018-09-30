using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bll
{
    public class Mazo
    {
        static be.Mazo mazo;
        static Mazo()
        {
            mazo = new be.Mazo();
        }

        public static be.Carta darCarta()
        {
            Random random = new Random();
            random.Next(20);
            be.Carta carta = mazo.Cartas[int.Parse(random.ToString())];
            mazo.Cartas.Remove(carta);
            return carta;
        }
    }
}