﻿using GameEngine;
using OpenTK;
using System;
using System.Drawing;

namespace GameLogic
{
    /// <summary>
    /// Пуля.
    /// </summary>
    public class Bullet : GameObject, ICollisionable, IMovable
    {
        /// <summary>
        /// Врезалась ли пуля.
        /// </summary>
        public bool IsBumped = false;

        /// <summary>
        /// Урон.
        /// </summary>
        public readonly int damage = 10;

        /// <summary>
        /// Спрайт.
        /// </summary>
        public Texture2D sprite;

        /// <summary>
        /// Повернут ли объект вправо.
        /// </summary>
        public bool facingRight;

        /// <summary>
        /// Скорость.
        /// </summary>
        public Vector2 Speed { get; private set; }

        /// <summary>
        /// Инициализация пули. 
        /// </summary>
        /// <param name="startPos">Начальная позиция.</param>
        public Bullet(Vector2 startPos)
        {
            this.Position = startPos;
            this.Speed += new Vector2(1.5f, 0);
            this.facingRight = false;
            this.size = new Vector2(10, 10);
            this.sprite = ContentPipe.LoadTexture("bullet.jpg");
        }

        /// <summary>
        /// Отрисовка.
        /// </summary>
        public void Draw()
        {
            RectangleF rec = DrawRec;
            if (!facingRight)
            {
                rec.X += rec.Width;
                rec.Width = -rec.Width;
            }
            Spritebatch.Draw(sprite, rec);
        }

        /// <summary>
        /// Обновление.
        /// </summary>
        /// <param name="level">Уровень.</param>
        public void Update(ref Level level)
        {
            Move();
            ResolveCollision(ref level);
        }

        /// <summary>
        /// Коллизии.
        /// </summary>
        /// <param name="level">Уровень.</param>
        public void ResolveCollision(ref Level level)
        {
            int minX = (int)Math.Floor((this.Position.X - size.X / 2.0f) / Gridsize);
            int minY = (int)Math.Floor((this.Position.Y - size.Y / 2.0f) / Gridsize);
            int maxX = (int)Math.Ceiling((this.Position.X + size.X / 2.0f) / Gridsize);
            int maxY = (int)Math.Ceiling((this.Position.Y + size.Y / 2.0f) / Gridsize);

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    RectangleF blockRec = new RectangleF(x * Gridsize, y * Gridsize, Gridsize, Gridsize);
                    if ((level[x, y].IsLadder || level[x, y].IsSolid || level[x, y].IsPlatform || level[x, y].IsSpike) &&
                        this.ColRec.IntersectsWith(blockRec))
                    {
                        IsBumped = true;
                    }
                }
            }
        }

        /// <summary>
        /// Метод движения.
        /// </summary>
        public void Move()
        {
            this.Position += Speed;
        }
    }
}
