using GameEngine;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    /// <summary>
    /// Недвигающийся враг.
    /// </summary>
    public class MotionlessEnemy : EnemyDecorator, ICollisionable
    {
        private Vector2 speed;
        /// <summary>
        /// Инициализация недвигающегося врага.
        /// </summary>
        /// <param name="enemy">Враг.</param>
        /// <param name="startPos">Начальная позиция.</param>
        public MotionlessEnemy(Enemy enemy, Vector2 startPos) : base(enemy, startPos)
        {
            this.speed = Vector2.Zero;
            this.position = startPos;
            this.enemy = enemy;
            this.sprite = ContentPipe.LoadTexture("ladybug_move.png");
        }
        /// <summary>
        /// Метод обновления.
        /// </summary>
        /// <param name="level">Уровень.</param>
        public override void Update(ref Level level)
        {
           
            if (level.CountOfMEnemy > 180)
            {
                this.size = new Vector2(60, 70);
            }
            else
            {
                this.position = new Vector2(this.position.X, this.position.Y + 15.0f);
                this.size = new Vector2(20, 30);
            }
            ResolveCollision(ref level);
        }

        /// <summary>
        /// Метод, обрабатывающий коллизии.
        /// </summary>
        /// <param name="level">Уровень.</param>
        public void ResolveCollision(ref Level level)
        {
            int minX = (int)Math.Floor((this.position.X - size.X / 2.0f) / Gridsize);
            int minY = (int)Math.Floor((this.position.Y - size.Y / 2.0f) / Gridsize);
            int maxX = (int)Math.Ceiling((this.position.X + size.X / 2.0f) / Gridsize);
            int maxY = (int)Math.Ceiling((this.position.Y + size.Y / 2.0f) / Gridsize);

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
                            this.position += minDirection * min;
                        }
                        #endregion
                    }

                }
            }
        }
    }
}
