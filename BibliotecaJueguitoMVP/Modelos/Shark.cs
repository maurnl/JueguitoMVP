using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class Shark : EntityBase
    {
        public Shark(Point posicionInicial, Size tamanio, int velocidad) : base(posicionInicial, tamanio, velocidad)
        {
            this.facingDirection = 'e';
        }
    }
}
