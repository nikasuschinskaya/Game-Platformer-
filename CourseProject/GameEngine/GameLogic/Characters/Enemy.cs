﻿using GameEngine;
using OpenTK;
using System.Drawing;

namespace GameLogic
{
    /// <summary>
    /// Базовый класс для врагов.
    /// </summary>
    public class Enemy : GameObject
    {
        /// <summary>
        /// Урон.
        /// </summary>
        public int damage;

        /// <summary>
        /// Спрайт.
        /// </summary>
        public Texture2D sprite;

        /// <summary>
        /// Повернут ли объект вправо, на земле ли.
        /// </summary>
        public bool facingRight, grounded;

        /// <summary>
        /// Инициализация врагов.
        /// </summary>
        /// <param name="startPos">Начальная позиция.</param>
        public Enemy(Vector2 startPos)
        {
            this.Position = startPos;
            this.facingRight = false;
            this.grounded = false;
            this.size = new Vector2(20, 30);
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
        public virtual void Update(ref Level level) { }
    }
}
