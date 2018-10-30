using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be
{
    public class RealEnvido : IEnvido
    {
        
      
        private int puntos;

      
        private int valor = 4;

        public int Valor()
        {
            return valor;
        }

        public int getPuntos()
        {
            return puntos;
        }

        public void setPuntos(int Puntos)
        {
            puntos = Puntos;
        }

    }
}
