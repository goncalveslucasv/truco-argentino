using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be
{
    public class FaltaEnvido : IEnvido
    {


        private int puntos;


        private int valor;

        public int Valor()
        {
            return valor;
        }
        public void setValor(int Valor)
        {
            valor = Valor;
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
