using System.Drawing;

namespace Library.Models
{
    public abstract class EntityBase
    {
        protected Rectangle hitbox;
        protected char facingDirection;
        protected int speed;

        public EntityBase(Point initialPosition, Size size, int speed)
        {
            this.hitbox.Location = initialPosition;
            this.hitbox.Size = size;
            this.hitbox = new Rectangle(initialPosition, size);
            this.speed = speed;
            this.facingDirection = 'n';
        }

        public delegate void LoadSprite(EntityBase entity, char direction);

        public event LoadSprite FacingDirectionChanged;

        public Size Size
        {
            get
            {
                return this.hitbox.Size;
            }
        }

        public Point Position
        {
            get
            {
                return this.hitbox.Location;
            }
        }

        public Rectangle Hitbox
        {
            get
            {
                return this.hitbox;
            }
        }

        public char FacingDirection
        {
            get
            {
                return this.facingDirection;
            }
            set
            {
                this.facingDirection = value;
                FacingDirectionChanged(this, this.facingDirection);
            }
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }
        }

        public void MoveInFacingDirecion()
        {
            if(this.speed == 0)
            {
                return;
            }

            switch (facingDirection)
            {
                case 'n':
                    this.hitbox.Location = new Point(this.hitbox.Location.X, this.hitbox.Location.Y - speed);
                    break;
                case 's':
                    this.hitbox.Location = new Point(this.hitbox.Location.X, this.hitbox.Location.Y + speed);
                    break;
                case 'e':
                    this.hitbox.Location = new Point(this.hitbox.Location.X + speed, this.hitbox.Location.Y);
                    break;
                case 'w':
                    this.hitbox.Location = new Point(this.hitbox.Location.X - speed, this.hitbox.Location.Y);
                    break;
                default:
                    break;
            }
        }

        public bool CollidesWith(EntityBase entity)
        {
            return this.hitbox.IntersectsWith(entity.Hitbox);
        }
    }
}
