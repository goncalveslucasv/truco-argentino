using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll
{
    public class Envido
    {
        private List<be.Jugador> Jugadores;
    
        public int envidoAceptado(be.Jugador Jugador, be.IEnvido ienvido)
        {
            envidoGanador(ienvido);

            foreach (be.Jugador jugador in Jugadores)
            {
                if(jugador != Jugador)
                {
                    return jugador.Envido.getPuntos();
                }
            }
            return -1;

        }
        public void envidoNoQuerido(be.Jugador jugador)
        {
            jugador.Puntaje = jugador.Puntaje+1;
        }


        public void contarEnvido(List<be.Jugador> jugadores)
        {
            Jugadores = jugadores;
            foreach(be.Jugador jugador in jugadores)
            {
                be.Envido envido = new be.Envido();
                List<be.Carta> cartas = coleccionarCartasJugador(jugador);
                envido.setPuntos(this.calcular(cartas));
                jugador.Envido = envido;
            }
        }
        private void envidoGanador(be.IEnvido envido)
        {
            be.Jugador jugador = jugadorGanador();
            jugador.Puntaje = jugador.Puntaje + envido.Valor();
        }

        private be.Jugador jugadorGanador()
        {
            return (Jugadores[0].Envido.getPuntos() > Jugadores[1].Envido.getPuntos()) ? Jugadores[0] : Jugadores[1];
        }


        private List<be.Carta> coleccionarCartasJugador(be.Jugador jugador)
        {
            List<be.Carta> cartas = new List<be.Carta>();

            foreach (be.Carta carta in jugador.Cartas)
            {
                if (carta == null)
                {
                    cartas.Add(jugador.CartaJugada);
                    continue;
                }
                cartas.Add(carta);
            }
            return cartas;
        }

        private int calcular(List<be.Carta> cartas)
        {
            try
            {
                return Math.Max(
                        Math.Max(calculoParcial(cartas[0], cartas[1]),
                                calculoParcial(cartas[0], cartas[2])),
                        calculoParcial(cartas[1], cartas[2]));
            }
            catch (Exception e)
            {
                throw new Exception("Enivdo debe ser en priemra mano");
            }
        }

        private int valor(be.Carta carta)
        {
            return carta.Numero < 10 ? carta.Numero : 0;
        }

        private int calculoParcial(be.Carta c1, be.Carta c2)
        {
            return (c1.palo == c2.palo) ? valor(c1) + valor(c2) + 20 : Math.Max(valor(c1), valor(c2));
        }

    }
}
