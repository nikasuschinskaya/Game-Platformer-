using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using OpenTK;

namespace GameLogic
{
    public class Bullet : GameObject, ICollisionable
    {
        public bool IsBumped = false;
        public int damage = 10;
        public Vector2 speed;
        private int Gridsize = 32;
        public Texture2D sprite;
        public bool facingRight;

        public Bullet(Vector2 startPos)
        {
            this.position = startPos;
            this.speed += new Vector2(1.5f, 0);
            this.facingRight = false;
            this.size = new Vector2(10, 10);
            this.sprite = ContentPipe.LoadTexture("bullet.jpg");
        }

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

        public void Update(ref Level level)
        {
            this.position += speed;
            ResolveCollision(ref level);
        }

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
                    if ((level[x, y].IsLadder || level[x, y].IsSolid || level[x, y].IsPlatform || level[x, y].IsSpike) && this.ColRec.IntersectsWith(blockRec))
                    {
                        IsBumped = true;
                    }
                }
            }
        }
    }
}
