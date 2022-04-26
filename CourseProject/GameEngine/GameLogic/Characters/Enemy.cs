using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using GameEngine;
using System.Drawing;

namespace GameLogic
{
    public class Enemy : GameObject
    {

        public int damage;
        public Vector2 speed;

        public int Gridsize = 32;
        public Texture2D sprite;
        public bool facingRight, grounded;

        public Enemy()
        {
            this.speed = Vector2.Zero;
            this.facingRight = false;
            this.grounded = false;
            this.size = new Vector2(20, 30);
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

        public virtual void Update(ref Level level) { }
    }
}
