using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class Truco
    {
        be.Truco truco;
        be.Ronda ronda;

        [TestMethod]
        public void IniciarPartidaDeTruco()
        {
            bll.Truco trucoLogica = new bll.Truco();
            be.Partida partida = trucoLogica.IniciarPartida(List<be.Jugador> jugadores);

            Assert.IsInstanceOfType(partida, typeof(be.Partida));
        }

        [TestMethod]
        public void CrearRonda()
        {
            bll.Ronda rondaLogica = new bll.Ronda();
            ronda = rondaLogica.crearRonda();

            Assert.IsInstanceOfType(ronda, typeof(be.Ronda));
            Assert.IsInstanceOfType(ronda.Mano[0], typeof(be.Mano));
            Assert.IsInstanceOfType(ronda.Mano[1], typeof(be.Mano));
            Assert.IsInstanceOfType(ronda.Mano[2], typeof(be.Mano));

        }

        [TestMethod]
        public void RepartirCartas()
        {
        
            bll.Ronda rondaLogica = new bll.Ronda();
            rondaLogica.repartirCartas(be.Mano mano);



        }
    }
}
