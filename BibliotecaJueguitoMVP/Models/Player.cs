using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Player : EntityBase
    {
        private int hitPoints;

        public Player(Point initialPosition, Size size, int speed, int hitPoints) : base(initialPosition, size, speed)
        {
            this.hitPoints = hitPoints;
        }

        public int HitPoints
        {
            get
            {
                return this.hitPoints;
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.hitPoints > 0;
            }
        }

        public void RecibirDanio(int value)
        {
            this.hitPoints -= value;
        }
    }
}
