using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class GamePoint : EntityBase
    {
        public GamePoint(Point posicionInicial, Size tamanio) : base(posicionInicial, tamanio, 0)
        {
        }
    }
}
