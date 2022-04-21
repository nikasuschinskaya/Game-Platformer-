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
        Enemy enemy;
        int levelNum = 0;
        List<string> lvlNames = new List<string>()
        {
            "TiledLevel.tmx",
            "Level.tmx",
            //"Level3.tmx"
        };
        private int health, keys;
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
            tileset = ContentPipe.LoadTexture("FullTilesSet.png");
            level = new LevelFactory(20, 20, $"Content/{lvlNames[levelNum]}");
            player = new Player(new Vector2(level.playerStartPos.X + 0.5f,
                level.playerStartPos.Y + 0.5f) * GRIDSIZE, new Vector2(0, 0.5f), keys+1);
            enemy = new Enemy(new Vector2(level.playerStartPos.X + 0.5f, level.playerStartPos.Y + 0.5f) * GRIDSIZE);
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
            health = player.LivesCount;
            keys = player.Key;
            player.Update(ref level);
            
            if (health != player.LivesCount)
            {
                ForcedRespawn();
            }

            if(keys != player.Key)
            {
                if (levelNum < lvlNames.Count - 1)
                {
                    levelNum++;
                }
                else
                    levelNum = 0;
                LoadNewLvl();
            }
            
            if (health - player.LivesCount > 1)
                player.LivesCount = player.LivesCount + (health - player.LivesCount - 1);

            if (player.LivesCount <= 0)
            {
                System.Windows.MessageBox.Show("Вы проиграли!");
                RestartWindow restart = new RestartWindow();
                restart.Show();
                this.Close();
                
                //тут всполывающее окно "Вы проиграли" и кнопка начать заново
                //health = 10;
                //player.LivesCount = 10;
            }

            view.SetPosition(player.position, TweenType.QuarticOut, 15);

            Respawn();

            Input.Update();
            view.Update();

            Title = player.ToString();
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
            enemy.Draw();
            player.Draw();
            SwapBuffers();
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
         
