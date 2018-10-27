using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class Truco
    {
        be.Truco truco;
        be.Partida partida;
        List<be.Jugador> jugadores = new List<be.Jugador>();
        be.Ronda ronda;

        

        [TestMethod]
        public void IniciarPartidaDeTruco()
        {
            bll.Truco trucoServices = new bll.Truco();

            jugadores.Add(new be.Jugador("Pedro"));
            jugadores.Add(new be.Jugador("Juan"));

            partida = trucoServices.IniciarJuego(jugadores);

            Assert.IsInstanceOfType(partida, typeof(be.Partida));
        }

        [TestMethod]
        public void CrearRonda()
        {
            jugadores.Add(new be.Jugador("Pedro"));
            jugadores.Add(new be.Jugador("Juan"));

            be.Partida partida = new be.Partida(jugadores);
            bll.Ronda rondaServices = new bll.Ronda();
            rondaServices.AsignarPartida(partida);
            ronda = rondaServices.CrearRonda();

            Assert.IsInstanceOfType(ronda, typeof(be.Ronda));

        }

        [TestMethod]
        public void RepartirCartasTest()
        {
            List<be.Jugador> jugadores = new List<be.Jugador>();

            jugadores.Add(new be.Jugador("Pedro"));
            jugadores.Add(new be.Jugador("Juan"));

            be.Partida partida = new be.Partida(jugadores);
            bll.Ronda rondaServices = new bll.Ronda();
            rondaServices.AsignarPartida(partida);
            ronda = rondaServices.CrearRonda();

            rondaServices.RepartirCartas(jugadores);

            Assert.IsInstanceOfType(jugadores[0].Cartas[0], typeof(be.Carta));
            Assert.IsInstanceOfType(jugadores[0].Cartas[1], typeof(be.Carta));
            Assert.IsInstanceOfType(jugadores[0].Cartas[2], typeof(be.Carta));
            Assert.IsInstanceOfType(jugadores[1].Cartas[0], typeof(be.Carta));
            Assert.IsInstanceOfType(jugadores[1].Cartas[1], typeof(be.Carta));
            Assert.IsInstanceOfType(jugadores[1].Cartas[2], typeof(be.Carta));
        }

        [TestMethod]
        public void TirarCarta()
        {
            List<be.Jugador> jugadores = new List<be.Jugador>();

            jugadores.Add(new be.Jugador("Pedro"));
            jugadores.Add(new be.Jugador("Juan"));

            be.Partida partida = new be.Partida(jugadores);
            bll.Ronda rondaServices = new bll.Ronda();
            bll.Turno turnoServices = new bll.Turno();
            rondaServices.AsignarPartida(partida);
            ronda = rondaServices.CrearRonda();

            be.Turno turno = turnoServices.cambiarTurno(new be.Turno(), jugadores[0]);
            rondaServices.RepartirCartas(jugadores);


            bll.Jugador jugadorServices = new bll.Jugador(jugadores);
            jugadorServices.TirarCarta(jugadores[0], jugadores[0].Cartas[1], ronda.Manos[0]);
            turnoServices.alternarTurno(turno, partida);

            Assert.IsInstanceOfType(ronda.Manos[0].Jugadores[0].CartaJugada, typeof(be.Carta));
        }


    }
}
