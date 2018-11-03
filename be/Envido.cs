using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be
{
    public class Envido : IEnvido
    {
        
      
        private int puntos;

      
        private int valor = 2;

        public int Valor()
        {
            return valor;
        }

        public void setValor(int Valor)
        {
            valor = 2;
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
