using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be
{
    public class ReTruco : Truco, ITruco
    {
        const int PUNTOS_QUERIDOS = 3;
        const int PUNTOS_NO_QUERIDOS = 2;

        private int puntosQueridos;

        public int PuntosQueridos
        {
            get { return PUNTOS_QUERIDOS; }
        }

        private int puntosNoQueridos;

        public int PuntosNoQueridos
        {
            get { return PUNTOS_NO_QUERIDOS; }
        }



        public string nombre { get; set; }
        public ITruco reCantar { get; set; }
    }
}
