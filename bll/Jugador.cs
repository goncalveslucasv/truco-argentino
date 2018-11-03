using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bll
{
    public class Jugador
    {
        private List<be.Jugador> jugadores = new List<be.Jugador>();

        public Jugador(List<be.Jugador> Jugadores)
        {
            jugadores = Jugadores;
        }

        public int contarCartaJugadores(List<be.Jugador> jugadores)
        {
            int cantidadDeCartas = 0;
            foreach(be.Jugador jugador in jugadores)
            {
                cantidadDeCartas += this.contarCartas(jugador);
            }

            return cantidadDeCartas;
        }

        public int contarCartas(be.Jugador jugador)
        {
            foreach (be.Carta carta in jugador.Cartas)
            {
                if(carta != null)
                {
                    return 1;
                }
            }
            return 0;
        }




        public void TirarCarta(be.Jugador jugador, be.Carta carta, bll.Ronda rondaServices)
        {
            be.Partida partida = rondaServices.getPartida();
            int index = rondaServices.RondaActual;
            be.Mano mano = partida.Rondas[index].Manos[partida.Rondas[index].UltimaManoJugada];
            jugador.CartaJugada = carta;
            rondaServices.alternarTurno();

            int indice = jugador.Cartas.IndexOf(carta);
            jugador.Cartas[indice] = null;
            mano.Jugadores.Add(jugador);    

            bll.Mano manoServices = new bll.Mano();
            manoServices.manoCompleta(mano, partida);



        }

    }
}