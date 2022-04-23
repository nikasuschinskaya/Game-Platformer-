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

        private int Gridsize = 32;
        public Texture2D sprite;
        public bool facingRight, grounded;

        public Enemy()
        {
            this.speed = Vector2.Zero;
            // this.speed += new Vector2(0, 0.5f);
            //this.position += speed;
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

        public virtual void Move() { }
    }
}
