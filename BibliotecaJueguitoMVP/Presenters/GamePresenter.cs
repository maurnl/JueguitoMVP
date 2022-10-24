using Library.Models;
using System.Drawing;

namespace Library.Presenters
{
    public class GamePresenter : IGameView
    {
        // Para probar jugador es de tipo Entidad, luego hay que crear la clase Jugador
        private static Random random;
        private Player player;
        private List<Shark> enemies;
        private Task gameLoop;
        private IGameView gameView;

        static GamePresenter()
        {
            GamePresenter.random = new Random();
        }

        public GamePresenter(IGameView gameView)
        {
            this.gameView = gameView;
            this.enemies = new List<Shark>();
            this.player = new Player(new Point(gameView.ScreenSize.Width / 2, gameView.ScreenSize.Height / 2), new Size(60, 80), 12, 100);
            this.gameLoop = new Task(Loop);
            this.gameLoop.Start();
        }

        // No me termina de cerrar esta property
        public Size ScreenSize
        {
            get
            {
                return this.gameView.ScreenSize;
            }
        }

        private void Loop()
        {
            while (true)
            {
                Thread.Sleep(12);
                SpawnShark();
                Update();
                Render();
            }
        }

        private void SpawnShark()
        {
            if(GamePresenter.random.Next(1,100) == 12)
            {
                this.enemies.Add(new Shark(new Point(0, GamePresenter.random.Next(0, this.ScreenSize.Height)), new Size(35, 25), 10));
            }
        }

        private void Update()
        {
            // Actualizar estado del juego...
            this.player.MoveInFacingDirecion();
            foreach (EntityBase entidad in this.enemies)
            {
                entidad.MoveInFacingDirecion();
            }
        }

        private void Render()
        {
            // Renderizar entidades del juego... 
            RenderEntity(this.player);
            int sharksLen = this.enemies.Count;
            for (int i = sharksLen - 1; i >= 0; i--)
            {
                EntityBase shark = enemies[i];
                if(shark.Hitbox.X > this.ScreenSize.Width + 10)
                {
                    this.enemies.RemoveAt(i);
                    RemoveEntity(shark);
                } else
                {
                    RenderEntity(shark);
                }
            }
        }

        public void RenderEntity(EntityBase entity)
        {
            this.gameView.RenderEntity(entity);
        }

        public void ChangePlayerFacingDirection(char direction)
        {
            this.player.FacingDirection = direction;
        }

        public void RemoveEntity(EntityBase entity)
        {
            this.gameView.RemoveEntity(entity);
        }
    }
}