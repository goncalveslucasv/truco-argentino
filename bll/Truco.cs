using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll
{
    public class Truco
    {
        private be.Turno turno;

        public be.Turno Turno { get; set; }
        public be.Partida IniciarJuego(List<be.Jugador> jugadores, bll.Ronda rondaServices)
        {
            be.Truco truco = new be.Truco();
            be.Partida partida = new be.Partida(jugadores);
            be.Turno turno = new be.Turno();
            turno.Jugador = jugadores[0];
            partida.Turno = turno;

            rondaServices.AsignarPartida(partida);
            rondaServices.CrearRonda();
            rondaServices.RepartirCartas(jugadores);

            return partida;
        }

      
        public void CompararMano(be.Mano mano, be.Partida partida)
        {
            if(mano.Jugadores[0].CartaJugada.Valor < mano.Jugadores[1].CartaJugada.Valor)
            {
                AsignarPuntos(mano.Jugadores[0]);
                partida.Turno.Jugador = mano.Jugadores[0];
            }
            else
            {
                AsignarPuntos(mano.Jugadores[1]);
                partida.Turno.Jugador = mano.Jugadores[1];
            }

            partida.Rondas[partida.Rondas.Count() - 1].UltimaManoJugada++;

        }
        
        private void AsignarPuntos(be.Jugador jugador)
        {
            jugador.ManosGanadas++;

        }

  
    }
}
