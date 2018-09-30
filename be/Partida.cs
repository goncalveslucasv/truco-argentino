using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be
{
    public class Partida
    {
        private List<be.Ronda> rondas = new List<Ronda>();

        public List<be.Ronda> Rondas
        {
            get { return rondas; }
            set { rondas = value; }
        }



        private List<be.Jugador> jugadores;

        public List<be.Jugador> Jugadores
        {
            get { return jugadores; }
            set { jugadores = value; }
        }

        public Partida(List <be.Jugador> jugadores)
        {
            this.jugadores = jugadores;
        }




    }
}
