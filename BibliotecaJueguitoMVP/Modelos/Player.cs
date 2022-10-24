using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class Player : EntityBase
    {
        private int puntosDeVida;

        public Player(Point posicionInicial, Size tamanio, int velocidad, int puntosDeVida) : base(posicionInicial, tamanio, velocidad)
        {
            this.puntosDeVida = puntosDeVida;
        }

        public int PuntosDeVida
        {
            get
            {
                return this.puntosDeVida;
            }
        }

        public bool EstaVivo
        {
            get
            {
                return this.puntosDeVida > 0;
            }
        }

        public void RecibirDanio(int valor)
        {
            this.puntosDeVida -= valor;
        }
    }
}
