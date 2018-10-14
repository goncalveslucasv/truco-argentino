using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be
{
    public class Jugador
    {
        private be.Carta cartaJugada;

        public be.Carta CartaJugada
        {
            get { return cartaJugada; }
            set { cartaJugada = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private int puntaje;

        public int Puntaje
        {
            get { return puntaje; }
            set { puntaje = value; }
        }

        private List<Carta> cartas = new List<Carta>();

        public List<Carta> Cartas
        {
            get { return cartas; }
            set { cartas = value; }
        }

        public Jugador(string Nombre)
        {
            this.nombre = Nombre;

        }






    }
}