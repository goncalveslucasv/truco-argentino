using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bll
{
    public class Turno
    {
        public be.Turno cambiarTurno(be.Turno turno, be.Jugador jugador)
        {
            turno.Jugador = jugador;
            return turno;

        }

        public void alternarTurno(be.Turno turno, be.Partida partida)
        {
            if (turno.Jugador == partida.Jugadores[0])
            {
                turno.Jugador = partida.Jugadores[1];
            }
            else {
                turno.Jugador = partida.Jugadores[0];
            }

        }
    }
}