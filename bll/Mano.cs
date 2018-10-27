using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bll
{
    public class Mano
    {
        public delegate void delOnClick(be.Carta uController, be.Carta carta);
        public event delOnClick OnClick;
        public static List<be.Mano> crearManos()
        {
            List<be.Mano> manos = new List<be.Mano>();
            manos.Add(new be.Mano());
            manos.Add(new be.Mano());
            manos.Add(new be.Mano());
            return manos;
        }

        public bool manoCompleta(be.Mano mano, be.Partida partida)
        {
            bll.Truco trucoServices = new bll.Truco();
            if(mano.Jugadores.Count == 2)
            {
                trucoServices.CompararMano(mano, partida);
                return true;

            }
            return false;

        }


    }
}