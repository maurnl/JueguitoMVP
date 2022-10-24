using Biblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Presentadores
{
    public interface IGameView
    {
        public Size ScreenSize { get; }
        void RenderEntity(EntityBase entidad);
        void RemoveEntity(EntityBase entidad);
        void ChangePlayerFacingDirection(char direccion);
    }
}
