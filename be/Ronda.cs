using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be
{
    public class Ronda
    {   
        private List<be.Mano> manos;

        public List<be.Mano> Manos
        {
            get { return manos; }
            set { manos = value; }
        }

        private int ultimaManoJugada = 0;

        public int UltimaManoJugada
        {
            get { return ultimaManoJugada; }
            set { ultimaManoJugada = value; }
        }


    }
}
