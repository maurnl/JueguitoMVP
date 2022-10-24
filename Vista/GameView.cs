using Library.Models;
using Library.Presenters;
using Views.Properties;

namespace Vista
{
    public partial class GameView : Form, IGameView
    {
        private GamePresenter gamePresenter;
        private Dictionary<EntityBase, PictureBox> entitiesRenders;
        private Dictionary<string, Image> sprites;

        public GameView()
        {
            InitializeComponent();
            this.gamePresenter = new GamePresenter(this);
            this.sprites = new Dictionary<string, Image>();
            this.entitiesRenders = new Dictionary<EntityBase, PictureBox>();
        }

        public Size ScreenSize
        {
            get
            {
                return this.Size;
            }
        }

        private void GameView_Load(object sender, EventArgs e)
        {
            this.Text = "JueguitoMVP";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 800);
            this.BackColor = Color.LightSkyBlue;
            this.sprites.Add("crucero-n", (Image)Resources.ResourceManager.GetObject("crucero-north")!);
            this.sprites.Add("crucero-s", (Image)Resources.ResourceManager.GetObject("crucero-south")!);
            this.sprites.Add("crucero-w", (Image)Resources.ResourceManager.GetObject("crucero-west")!);
            this.sprites.Add("crucero-e", (Image)Resources.ResourceManager.GetObject("crucero-east")!);
            this.sprites.Add("tiburon-e", (Image)Resources.ResourceManager.GetObject("tiburon-east")!);
            this.sprites.Add("punto-n", (Image)Resources.ResourceManager.GetObject("punto-east")!);
        }

        public void RenderEntity(EntityBase entity)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EntityBase>(RenderEntity), entity);

            }
            else
            {
                if (this.entitiesRenders.ContainsKey(entity))
                {
                    this.entitiesRenders[entity].Bounds = entity.Hitbox;
                    this.label1.Text = entitiesRenders.Count.ToString();
                }
                else
                {
                    this.entitiesRenders.Add(entity, new PictureBox { Bounds = entity.Hitbox, BackgroundImageLayout = ImageLayout.Stretch });
                    this.Controls.Add(this.entitiesRenders[entity]);
                    LoadEntitySprite(entity, entity.FacingDirection);
                    entity.FacingDirectionChanged += LoadEntitySprite;
                }
            }
        }
        public void ChangePlayerFacingDirection(char direccion)
        {
            this.gamePresenter.ChangePlayerFacingDirection(direccion);
        }

        private void GameView_KeyDown(object sender, KeyEventArgs e)
        {
            char direction = 'n';
            if(e.KeyCode == Keys.W)
            {
                direction = 'n';
            } else if(e.KeyCode == Keys.S)
            {
                direction = 's';
            } else if(e.KeyCode == Keys.A)
            {
                direction = 'w';
            } else if(e.KeyCode == Keys.D)
            {
                direction = 'e';
            }
            ChangePlayerFacingDirection(direction);
        }
        private void LoadEntitySprite(EntityBase entity, char direccion)
        {
            if(entity is Player)
            {
                this.entitiesRenders[entity].BackgroundImage = sprites[$"crucero-{direccion}"];
            } else if(entity is Shark)
            {
                this.entitiesRenders[entity].BackgroundImage = sprites[$"tiburon-{direccion}"];
            } else if(entity is GamePoint)
            {
                this.entitiesRenders[entity].BackgroundImage = sprites[$"punto-{direccion}"];
            }
        }

        public void RemoveEntity(EntityBase entity)
        {
            if (InvokeRequired)
            {
                Action<EntityBase> removeEntityAction = RemoveEntity;
                Invoke(removeEntityAction, entity);
            } else
            {
                this.Controls.Remove(this.entitiesRenders[entity]);
                this.entitiesRenders.Remove(entity);
            }
        }
    }
}
