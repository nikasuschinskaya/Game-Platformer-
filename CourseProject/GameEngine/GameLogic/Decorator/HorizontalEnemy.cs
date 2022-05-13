using GameEngine;
using OpenTK;
using System;
using System.Drawing;

namespace GameLogic
{
    /// <summary>
    /// Враг, движущийся горизонтально.
    /// </summary>
    public class HorizontalEnemy : EnemyDecorator, ICollisionable, IMovable
    {

        /// <summary>
        /// Скорость.
        /// </summary>
        public Vector2 Speed { get; private set; }

        /// <summary>
        /// Инициализация врага, движущегося горизонтально.
        /// </summary>
        /// <param name="enemy">Враг.</param>
        /// <param name="startPos">Начальная позиция.</param>
        public HorizontalEnemy(Enemy enemy, Vector2 startPos) : base(enemy, startPos)
        {
            this.Speed = new Vector2(0.5f, 0);
            this.Position = startPos;
            this.enemy = enemy;
            this.sprite = ContentPipe.LoadTexture("snail_move.png");
        }

        /// <summary>
        /// Метод обновления уровня.
        /// </summary>
        /// <param name="level">Уровень.</param>
        public override void Update(ref Level level)
        {
            Move();
            ResolveCollision(ref level);
        }

        /// <summary>
        /// Метод, обрабатывающий коллизии.
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
                    if ((level[x, y].IsLadder || level[x, y].IsSolid || level[x, y].IsPlatform || level[x, y].IsSpike) && this.ColRec.IntersectsWith(blockRec))
                    {
                        ChangeOnIntersect();
                    }
                }
            }
        }

        private void ChangeOnIntersect()
        {
            this.Speed = -Speed;
            if (facingRight)
                facingRight = false;
            else
                facingRight = true;
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
