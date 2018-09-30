using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be
{
    public class Carta
    {
        private string Palo;

        public string palo
        {
            get { return Palo; }
            set { Palo = value; }
        }

        private int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private int valor;

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }



        public Carta(string Palo, int Numero, int Valor)
        {
            this.palo = Palo;
            this.numero = Numero;
            this.valor = Valor;
        }



    }
}