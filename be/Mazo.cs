using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be
{
    public class Mazo
    {
        private List<be.Carta> cartas = new List<be.Carta>();

        public List<be.Carta> Cartas
        {
            get { return cartas; }
            set { cartas = value; }
        }

        public Mazo()
        {

            string[] palos = { "Espada", "Oro", "Basto", "Copa" };

            cartas.Add(new be.Carta("Espada", 1, 1));
            cartas.Add(new be.Carta("Basto", 2, 2));
            cartas.Add(new be.Carta("Espada", 7, 3));
            cartas.Add(new be.Carta("Oro", 7, 4));

            foreach(string palo in palos)
            {
                cartas.Add(new be.Carta(palo, 3, 5));
            }
            foreach (string palo in palos)
            {
                cartas.Add(new be.Carta(palo, 2, 6));
            }
            cartas.Add(new be.Carta("Oro", 1, 7));
            cartas.Add(new be.Carta("Copa", 1, 8));

            foreach (string palo in palos)
            {
                cartas.Add(new be.Carta(palo, 12, 9));
            }
            foreach (string palo in palos)
            {
                cartas.Add(new be.Carta(palo, 11, 10));
            }
            foreach (string palo in palos)
            {
                cartas.Add(new be.Carta(palo, 10, 11));
            }
            cartas.Add(new be.Carta("Copa", 7, 12));
            cartas.Add(new be.Carta("Basto", 7, 13));
            foreach (string palo in palos)
            {
                cartas.Add(new be.Carta(palo, 6, 14));
            }
            foreach (string palo in palos)
            {
                cartas.Add(new be.Carta(palo, 5, 15));
            }
            foreach (string palo in palos)
            {
                cartas.Add(new be.Carta(palo, 4, 16));
            }

        }

    }
}