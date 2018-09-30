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
            bll.Truco trucoLogica = new bll.Truco();

            jugadores.Add(new be.Jugador("Pedro"));
            jugadores.Add(new be.Jugador("Juan"));

            partida = trucoLogica.IniciarJuego(jugadores);

            Assert.IsInstanceOfType(partida, typeof(be.Partida));
        }

        [TestMethod]
        public void CrearRonda()
        {
            jugadores.Add(new be.Jugador("Pedro"));
            jugadores.Add(new be.Jugador("Juan"));

            be.Partida partida = new be.Partida(jugadores);
            bll.Ronda rondaLogica = new bll.Ronda();
            ronda = rondaLogica.CrearRonda(partida);

            Assert.IsInstanceOfType(ronda, typeof(be.Ronda));

        }

        [TestMethod]
        public void RepartirCartas()
        {

            jugadores.Add(new be.Jugador("Pedro"));
            jugadores.Add(new be.Jugador("Juan"));

            bll.Ronda rondaLogica = new bll.Ronda();
            be.Mano mano = rondaLogica.RepartirCartas(jugadores, ronda.Manos[0]);

            Assert.IsInstanceOfType(mano.Jugadores[0].Cartas[0], typeof(be.Carta));
            Assert.IsInstanceOfType(mano.Jugadores[0].Cartas[1], typeof(be.Carta));
            Assert.IsInstanceOfType(mano.Jugadores[0].Cartas[2], typeof(be.Carta));

            Assert.IsInstanceOfType(mano.Jugadores[1].Cartas[0], typeof(be.Carta));
            Assert.IsInstanceOfType(mano.Jugadores[1].Cartas[1], typeof(be.Carta));
            Assert.IsInstanceOfType(mano.Jugadores[1].Cartas[2], typeof(be.Carta));
        }

        [TestMethod]
        public void TirarCarta()
        { 



        }


    }
}
