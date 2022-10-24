using Library.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Presenters
{
    public interface IGameView
    {
        public Size ScreenSize { get; }
        void RenderEntity(EntityBase entity);
        void RemoveEntity(EntityBase entity);
        void ChangePlayerFacingDirection(char direction);
    }
}
