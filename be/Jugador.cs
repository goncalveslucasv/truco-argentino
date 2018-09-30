using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be
{
    public class Jugador
    {
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

        private List<Carta> cartas;

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