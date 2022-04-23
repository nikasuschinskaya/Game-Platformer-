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
    //public abstract class Enemy : GameObject
    public class Enemy : GameObject
    {

        private int damage;
        private Vector2 speed;

        private int Gridsize = 32;
        public Texture2D sprite;
        private bool facingRight, grounded;

        public Enemy()
        {
            this.speed = Vector2.Zero;
            // this.speed += new Vector2(0, 0.5f);
            //this.position += speed;
            this.facingRight = true;
            this.grounded = false;
            this.size = new Vector2(15, 20);
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

        public virtual void Move() { }
        //public void Move()
        //{
            
        //}
    }
}
