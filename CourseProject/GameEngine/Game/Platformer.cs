using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using GameEngine;
using GameLogic;


namespace Game
{
    /// <summary>
    /// Работа с игровым окном.
    /// </summary>
    public class Platformer : GameWindow
    {

        Texture2D tileset;
        View view;
        Level level;
        Player player;
        List<Enemy> enemyList = new List<Enemy>();
        Enemy enemyMotionless, enemyShoot;
        HorizontalEnemy enemyHorizontal;
        int levelNum = 0;
        List<string> lvlNames = new List<string>()
        {
            "FirstLevel.tmx",
            "Level.tmx",
            "Level3Test1.tmx"
        };
        private int livesCount, health, keys;
        private int GRIDSIZE = 32, TILESIZE = 128;

        /// <summary>
        /// Конструктор с параметрами окна.
        /// </summary>
        public Platformer() : base(
              640, 480, new OpenTK.Graphics.GraphicsMode(32, 24, 0, 8), "Platformer", 
              GameWindowFlags.FixedWindow,
              DisplayDevice.Default, 4, 3, GraphicsContextFlags.Debug
              )
        {
            CursorVisible = false;
            VSync = VSyncMode.On;
            GL.Enable(EnableCap.Texture2D);
            //Для учёта альфа-канала
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            view = new View(Vector2.Zero, 0.0, 1.0f);
            Input.Initialize(this);
        }

        /// <summary>
        /// Инициализация ресурсов.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadNewLvl();
        }

        /// <summary>
        /// Загрузка нового уровня.
        /// </summary>
        protected void LoadNewLvl()
        {
            enemyList.Clear();
            tileset = ContentPipe.LoadTexture("FullTilesSet.png");
            level = new LevelFactory(20, 20, $"Content/{lvlNames[levelNum]}");
            player = new Player(new Vector2(level.playerStartPos.X + 0.5f,
                level.playerStartPos.Y + 0.5f) * GRIDSIZE, new Vector2(0, 0.5f), keys+1);
            AddEnemies();
        }

        private void AddEnemies()
        {
            foreach (Point p in level.enemiesHorSpawn)
            {
                enemyList.Add(new HorizontalEnemy(new Enemy(), new Vector2(p.X + 0.5f, p.Y + 0.5f) * GRIDSIZE));
            }
            foreach (Point p in level.enemiesShootSpawn)
            {
                enemyList.Add(new ShootEnemy(new Enemy(), new Vector2(p.X + 0.5f, p.Y + 0.5f) * GRIDSIZE));
            }
            foreach (Point p in level.enemiesMotionlessSpawn)
            {
                enemyList.Add(new MotionlessEnemy(new Enemy(), new Vector2(p.X + 0.5f, p.Y + 0.5f) * GRIDSIZE));
            }
        }

        /// <summary>
        /// Проверка изменений расширений экрана.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        /// <summary>
        /// Учет обновлений кадров.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            keys = player.Key;
            ImplemOfMEnemies();
            ImplemOfFalling();
            AreBulsIntersectWithPlayer();
            ImplemOfShooting();

            livesCount = player.LivesCount;
            health = player.Health;
            IsIntersectsWithEnemies();
            IsHealthAboveZero();
            
            foreach (Enemy he in enemyList)
                he.Update(ref level);
            foreach (Bullet b in level.bullets)
                b.Update(ref level);
            int n = level.bullets.Count;
            for (int i = 0; i < n; i++)
            {
                if (level.bullets[i].IsBumped)
                {
                    level.bullets.Remove(level.bullets[i]);
                    n--;
                    i--;
                }
            }

            player.Update(ref level);
            
            if (livesCount != player.LivesCount)
            {
                ForcedRespawn();
            }

            if (livesCount - player.LivesCount > 1)
                player.LivesCount = player.LivesCount + (livesCount - player.LivesCount - 1);

            if (player.LivesCount <= 0)
            {
                System.Windows.MessageBox.Show("Вы проиграли!");
                RestartWindow restart = new RestartWindow();
                restart.Show();
                this.Close();

                //тут всполывающее окно "Вы проиграли" и кнопка начать заново
                //livesCount = 10;
                player.LivesCount = 10;
            }

            ImplemOfKeys();

            view.SetPosition(player.position, TweenType.QuarticOut, 15);

            Respawn();

            Input.Update();
            view.Update();

            Title = player.ToString();
        }

        private void AreBulsIntersectWithPlayer()
        {
            foreach (Bullet b in level.bullets)
            {
                if (Math.Abs(player.position.X - b.position.X) < 20 && Math.Abs(player.position.Y - b.position.Y) < 20)
                {
                    player.Health -= b.damage;
                    b.IsBumped = true;
                }
            }
            
        }

        private void ImplemOfShooting()
        {
            level.CountShootingTime++;
            if (level.CountShootingTime > 90)
            {
                foreach (Enemy e in enemyList)
                {
                    if (e is ShootEnemy shootEnemy)
                    {
                        level.bullets.Add(new Bullet(shootEnemy.position));
                    }
                }
                level.CountShootingTime = 0;
            }
        }

        private void ImplemOfFalling()
        {
            if (player.climbing == false && player.grounded == false && player.onLadder == false)
            {
                level.CountOfJumpingTime++;
            }
            else
            {
                if (level.CountOfJumpingTime > 50)
                {
                    player.Health -= level.CountOfJumpingTime - 40;
                }
                level.CountOfJumpingTime = 0;
            }
        }

        private void ImplemOfKeys()
        {
            if (keys != player.Key)
            {
                if (levelNum < lvlNames.Count - 1)
                {
                    levelNum++;
                }
                else
                    levelNum = 0;
                LoadNewLvl();
            }
        }

        private void ImplemOfMEnemies()
        {
            level.CountOfMEnemy++;
            if (level.CountOfMEnemy > 360)
            {
                level.CountOfMEnemy = 0;
            }
        }

        private void ForcedRespawn()
        {
            player.position =
                new Vector2(level.playerStartPos.X + 0.5f, level.playerStartPos.Y + 0.5f) * GRIDSIZE;
            player.speed = Vector2.Zero;
        }

        private void Respawn()
        {
            if (Input.KeyPress(OpenTK.Input.Key.R))
            {
                player.position =
                    new Vector2(level.playerStartPos.X + 0.5f, level.playerStartPos.Y + 0.5f) * GRIDSIZE;
                player.speed = Vector2.Zero;
            }
        }

        /// <summary>
        /// Отрисовка кадра.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(0.258f, 0.149f, 0.094f, 1.0f);

            Spritebatch.Begin(this.Width, this.Height);
            view.ApplyTransform();

            for(int x = 0; x < level.Width; x++)
            {
                for(int y = 0; y < level.Height; y++)
                {
                    RectangleF source = new RectangleF(0, 0, 0, 0);

                    switch(level[x, y].Type)
                    {
                        case BlockType.Ladder:
                            source = new RectangleF(2 * TILESIZE, 0 * TILESIZE, TILESIZE, TILESIZE);
                            break;
                        case BlockType.LadderPlatform:
                            source = new RectangleF(3 * TILESIZE, 0 * TILESIZE, TILESIZE, TILESIZE);
                            break;
                        case BlockType.Solid:
                            source = new RectangleF(1 * TILESIZE, 0 * TILESIZE, TILESIZE, TILESIZE);
                            break;
                        case BlockType.Platform:
                            source = new RectangleF(0 * TILESIZE, 1 * TILESIZE, TILESIZE, TILESIZE);
                            break;
                        case BlockType.SpikeUp:
                            source = new RectangleF(1 * TILESIZE, 1 * TILESIZE, TILESIZE, TILESIZE);
                            break;
                        case BlockType.SpikeRight:
                            source = new RectangleF(2 * TILESIZE, 1 * TILESIZE, TILESIZE, TILESIZE);
                            break;
                        case BlockType.SpikeDown:
                            source = new RectangleF(3 * TILESIZE, 1 * TILESIZE, TILESIZE, TILESIZE);
                            break;
                        case BlockType.SpikeLeft:
                            source = new RectangleF(0 * TILESIZE, 2 * TILESIZE, TILESIZE, TILESIZE);
                            break;
                        case BlockType.Key:
                            source = new RectangleF(1 * TILESIZE, 2 * TILESIZE, TILESIZE, TILESIZE);
                            break;
                        case BlockType.Door:
                            source = new RectangleF(2 * TILESIZE, 2 * TILESIZE, TILESIZE, TILESIZE);
                            break;
                    }
                    Spritebatch.Draw(tileset, new Vector2(x * GRIDSIZE, y * GRIDSIZE), new Vector2((float)
                        GRIDSIZE / TILESIZE), Color.White, Vector2.Zero, source);
                }
            }
            foreach (Enemy en in enemyList)
                en.Draw();
            foreach (Bullet b in level.bullets)
                b.Draw();
            player.Draw();
            SwapBuffers();
        }

        private void IsIntersectsWithEnemies()
        {
            if (enemyList.Count > 0)
            {
                foreach (Enemy e in enemyList)
                {
                    if (Math.Abs(player.position.Y - e.position.Y) < 20 && Math.Abs(player.position.X - e.position.X) < 25)
                        player.Health -= 1;
                    if (Math.Abs(player.position.Y - e.position.Y) < 20 && Math.Abs(player.position.X - e.position.X) < 20)
                        player.Health -= 1;
                    if (Math.Abs(player.position.Y - e.position.Y) < 20 && Math.Abs(player.position.X - e.position.X) < 20)
                        player.Health -= 1;
                }
            }
        }

        private void IsHealthAboveZero()
        {
            if (player.Health <= 0)
            {
                player.Health = 100;
                player.LivesCount -= 1;
                ForcedRespawn();
            }
                
        }

        /// <summary>
        /// Удаление загруженных ресурсов.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }
    }
}
         
