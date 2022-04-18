using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    /// <summary>
    /// Свойства текстуры.
    /// </summary>
    public class Texture2D
    {
        private int id;
        private int width;
        private int height;

        /// <summary>
        /// Номер текстуры.
        /// </summary>
        public int ID 
        { 
            get { return id; }
        }

        /// <summary>
        /// Ширина.
        /// </summary>
        public int Width
        {
            get { return width; }
        }

        /// <summary>
        /// Высота.
        /// </summary>
        public int Height
        {
            get { return height; }
        }

        /// <summary>
        /// Инициализатор текстуры.
        /// </summary>
        /// <param name="id"> Номер текстуры. </param>
        /// <param name="width"> Ширина. </param>
        /// <param name="height"> Высота. </param>
        public Texture2D(int id, int width, int height)
        {
            this.id = id;
            this.width = width;
            this.height = height;
        }
    }
}
