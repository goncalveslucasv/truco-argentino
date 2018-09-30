using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be
{
    public class Mano
    {
        private List<be.Jugador> jugadores = new List<Jugador>();

        public List<be.Jugador> Jugadores
        {
            get { return jugadores; }
            set { jugadores = value; }
        }

    }
}