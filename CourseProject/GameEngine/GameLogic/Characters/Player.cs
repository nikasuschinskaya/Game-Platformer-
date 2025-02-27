﻿using GameEngine;
using OpenTK;
using System;
using System.Drawing;

namespace GameLogic
{
    /// <summary>
    /// Главный герой.
    /// </summary>
    public class Player : GameObject, ICollisionable, IMovable
    {

        private Vector2 gravity;
        private Vector2 speed;
        private Texture2D sprite, spriteClimb;

        /// <summary>
        /// Ползёт ли объект, повернут ли объект вправо, на лестнице ли объект, на земле ли объект.
        /// </summary>
        public bool climbing, facingRight, onLadder, grounded;

        /// <summary>
        /// Количество жизней.
        /// </summary>
        public int LivesCount
        {
            get;
            set;
        }

        /// <summary>
        /// Очки здоровья для одной жизни.
        /// </summary>
        public int Health
        {
            get;
            set;
        }


        /// <summary>
        /// Количество ключей.
        /// </summary>
        public int Key
        {
            get;
            set;
        }

        /// <summary>
        /// Скорость.
        /// </summary>
        public Vector2 Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

        /// <summary>
        /// Инициализация начальных характеристик для игрока.
        /// </summary>
        /// <param name="startPos">Начальная позиция игрока.</param>
        /// <param name="gravity">Гравитация.</param>
        /// <param name="key">Количество ключей игрока</param>
        public Player(Vector2 startPos, Vector2 gravity, int key)
        {
            this.gravity = gravity;
            this.Position = startPos;
            this.speed = Vector2.Zero;
            this.LivesCount = 10;
            this.Health = 100;
            this.Key = key;
            this.climbing = false;
            this.facingRight = true;
            this.onLadder = false;
            this.grounded = false;
            this.size = new Vector2(20, 40);
            this.sprite = ContentPipe.LoadTexture("player.png");
            this.spriteClimb = ContentPipe.LoadTexture("playerClimb.png");

        }

        /// <summary>
        /// Метод обновления уровня.
        /// </summary>
        /// <param name="level">Уровень.</param>
        public void Update(ref Level level)
        {
            Move();

            if (speed.X < -5f)
                speed.X = -5f;
            if (speed.X > 5f)
                speed.X = 5f;

            if (!climbing)
                this.speed += gravity;
            this.Position += speed;
            ResolveCollision(ref level);
        }

        /// <summary>
        /// Метод движения, управления персонажем.
        /// </summary>
        public void Move()
        {
            if (!onLadder)
                climbing = false;
            else if ((Input.KeyDown(OpenTK.Input.Key.Up) || Input.KeyDown(OpenTK.Input.Key.Down)) && onLadder)
                climbing = true;

            if (grounded)
            {
                this.speed.X *= 0.9f;
            }
            else if (climbing)
            {
                this.speed.X *= 0.5f;
                this.speed.Y = 0f;
                if (Input.KeyDown(OpenTK.Input.Key.Up))
                {
                    this.speed.Y -= 5f;
                }
                if (Input.KeyDown(OpenTK.Input.Key.Down))
                {
                    this.speed.Y += 5f;
                }
            }

            if (grounded && !Input.KeyDown(OpenTK.Input.Key.Up))
            {
                climbing = false;
            }

            if (Input.KeyDown(OpenTK.Input.Key.Right))
            {
                if (climbing)
                {
                    this.speed.X = 2f;
                }
                else if (grounded)
                {
                    this.speed.X += 0.5f;
                }
                else
                {
                    this.speed.X += 0.2f;
                }
                facingRight = true;
            }
            if (Input.KeyDown(OpenTK.Input.Key.Left))
            {
                if (climbing)
                {
                    this.speed.X = -2f;
                }
                else if (grounded)
                {
                    this.speed.X -= 0.5f;
                }
                else
                {
                    this.speed.X -= 0.2f;
                }
                facingRight = false;
            }

            if (Input.KeyPress(OpenTK.Input.Key.Space) && (grounded || climbing))
            {
                this.speed.Y = -12;
                this.climbing = false;
            }

        }

        /// <summary>
        /// Метод, обрабатывающий коллизии с игровыми объектами.
        /// </summary>
        /// <param name="level">Уровень.</param>
        public void ResolveCollision(ref Level level)
        {
            int minX = (int)Math.Floor((this.Position.X - size.X / 2.0f) / Gridsize);
            int minY = (int)Math.Floor((this.Position.Y - size.Y / 2.0f) / Gridsize);
            int maxX = (int)Math.Ceiling((this.Position.X + size.X / 2.0f) / Gridsize);
            int maxY = (int)Math.Ceiling((this.Position.Y + size.Y / 2.0f) / Gridsize);

            this.grounded = false;
            this.onLadder = false;

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    RectangleF blockRec = new RectangleF(x * Gridsize, y * Gridsize, Gridsize, Gridsize);
                    if (level[x, y].IsSolid && this.ColRec.IntersectsWith(blockRec))
                    {
                        #region Collision Resolve
                        float[] depths = new float[4]
                        {
                            blockRec.Right - ColRec.Left, //PosX
							blockRec.Bottom - ColRec.Top, //PosY
							ColRec.Right - blockRec.Left, //NegX
							ColRec.Bottom - blockRec.Top  //NegY
						};

                        if (level[x + 1, y].IsSolid)
                            depths[0] = -1;
                        if (level[x, y + 1].IsSolid || level[x, y].IsPlatform)
                            depths[1] = -1;
                        if (level[x - 1, y].IsSolid)
                            depths[2] = -1;
                        if (level[x, y - 1].IsSolid)
                            depths[3] = -1;

                        float min = float.MaxValue;
                        Vector2 minDirection = Vector2.Zero;
                        for (int i = 0; i < 4; i++)
                        {
                            if (depths[i] >= 0 && depths[i] < min)
                            {
                                min = depths[i];
                                switch (i)
                                {
                                    case 0:
                                        minDirection = new Vector2(1, 0);
                                        break;
                                    case 1:
                                        minDirection = new Vector2(0, 1);
                                        break;
                                    case 2:
                                        minDirection = new Vector2(-1, 0);
                                        break;
                                    default:
                                        minDirection = new Vector2(0, -1);
                                        break;
                                }
                            }
                        }

                        if (minDirection != Vector2.Zero)
                        {
                            this.Position += minDirection * min;
                            if (this.speed.X * minDirection.X < 0)
                                this.speed.X = 0;
                            if (this.speed.Y * minDirection.Y < 0)
                                this.speed.Y = 0;

                            if (minDirection == new Vector2(0, -1))
                                grounded = true;
                        }
                        #endregion
                    }
                    if (this.speed.Y > 0 && !Input.KeyDown(OpenTK.Input.Key.Down) && level[x, y].IsPlatform && this.ColRec.IntersectsWith(blockRec))
                    {
                        if (this.Position.Y - this.speed.Y + this.size.Y / 2f <= blockRec.Top) //if we were above last frame
                        {
                            this.speed.Y = 0;
                            Vector2 pos = new Vector2(Position.X, blockRec.Top - this.size.Y / 2f);
                            this.Position = pos;
                            grounded = true;
                        }
                    }
                    if (level[x, y].IsLadder && this.ColRec.IntersectsWith(blockRec))
                    {
                        this.onLadder = true;
                    }
                    if (level[x, y].IsSpike && this.ColRec.IntersectsWith(blockRec))
                    {
                        LivesCount -= 1;
                    }
                    if (level[x, y].IsKey && this.ColRec.IntersectsWith(blockRec))
                    {
                        Key += 1;
                    }
                }
            }

        }

        /// <summary>
        /// Отрисовка персонажа.
        /// </summary>
        public void Draw()
        {
            RectangleF rec = DrawRec;
            if (!facingRight)
            {
                rec.X += rec.Width;
                rec.Width = -rec.Width;
            }

            if (climbing)
            {
                Spritebatch.Draw(spriteClimb, rec);
            }
            else if (grounded)
            {
                Spritebatch.Draw(sprite, rec);
            }
            else
            {
                Spritebatch.Draw(sprite, rec);
            }
        }

        /// <summary>
        /// Метод, преобразующий объект класса в строку.
        /// </summary>
        /// <returns>Строка.</returns>
        public override string ToString()
        {
            return $"Количество жизней: {LivesCount.ToString()}, Очки здоровья: {Health.ToString()}, Ключи: {(Key - 1).ToString()}";
        }
    }
}
