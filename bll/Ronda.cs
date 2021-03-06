﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using be;

namespace bll
{
    public class Ronda
    {
        private be.Partida partida;

        public be.Partida getPartida()
        {
            return partida;
        }

        private int rondaActual;

        public int RondaActual
        {
            get { return partida.Rondas.Count - 1;  }
        }


        public void AsignarPartida(be.Partida Partida)
        {
            partida = Partida;
        }   
            
        public be.Ronda CrearRonda()
        {
            be.Ronda ronda = new be.Ronda();
            ronda.Manos = bll.Mano.crearManos();
            partida.Rondas.Add(ronda);
            resetearValoresParciales();
            return ronda;
        }

        private void resetearValoresParciales()
        {
            partida.Jugadores[0].ManosGanadas = 0;
            partida.Jugadores[1].ManosGanadas = 0;
            partida.Jugadores[0].CartaJugada = null;
            partida.Jugadores[1].CartaJugada = null;
            partida.Jugadores[0].Envido = null;
            partida.Jugadores[1].Envido = null;
        }

        public void AsignarPuntos(List<be.Jugador> jugadores, int puntos)
        {
            if (jugadores[0].ManosGanadas > jugadores[1].ManosGanadas)
            {
                jugadores[0].Puntaje = jugadores[0].Puntaje + puntos;
            } else
            {
                jugadores[1].Puntaje = jugadores[1].Puntaje + puntos;

            }
        }
        public void nuevaRonda()
        {
            this.CrearRonda();
            this.RepartirCartas(partida.Jugadores);
        }

        public void seFueAlMazo(be.Jugador jugador, be.Partida partida)
        {
            foreach(be.Jugador Jugador in partida.Jugadores)
            {
                if(Jugador != jugador)
                {
                    Jugador.Puntaje = Jugador.Puntaje + 1;
                }
            }
        }

        public void alternarTurno()
        {
            if (partida.Turno.Jugador == partida.Jugadores[0])
            {
                partida.Turno.Jugador = partida.Jugadores[1];
            }
            else
            {
                partida.Turno.Jugador = partida.Jugadores[0];
            }

        }

        public void RepartirCartas(List<be.Jugador> jugadores)
        {

            jugadores[0].Cartas = null;
            jugadores[1].Cartas = null;

            jugadores[0].Cartas = new List<be.Carta>();
            jugadores[1].Cartas = new List<be.Carta>();

            bll.Mazo mazo = new bll.Mazo(new be.Mazo());


            jugadores[0].Cartas.Add(mazo.darCarta());
            jugadores[0].Cartas.Add(mazo.darCarta());
            jugadores[0].Cartas.Add(mazo.darCarta());
            jugadores[1].Cartas.Add(mazo.darCarta());
            jugadores[1].Cartas.Add(mazo.darCarta());
            jugadores[1].Cartas.Add(mazo.darCarta());

        }




    
    }
}
