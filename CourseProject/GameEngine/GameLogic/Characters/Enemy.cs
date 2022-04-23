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
        private Texture2D sprite;
        private bool facingRight, grounded;

        public Enemy(Vector2 startPos) : base()
        {
            this.speed = Vector2.Zero;
            // this.speed += new Vector2(0, 0.5f);
            this.position = startPos;
            //this.position += speed;
            this.facingRight = true;
            this.grounded = false;
            this.size = new Vector2(15, 20);
            this.sprite = ContentPipe.LoadTexture("hedgehog_body.png");
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

        //public void Move()
        //{
            
        //}
    }
}
