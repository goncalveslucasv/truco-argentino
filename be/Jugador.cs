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

        private string contraseña;

        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }

        private int puntaje;

        public int Puntaje
        {
            get { return puntaje; }
            set { puntaje = value; }
        }

        private List<Carta> Cartas;

        public List<Carta> cartas
        {
            get { return Cartas; }
            set { Cartas = value; }
        }






    }
}