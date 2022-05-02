namespace GameEngine
{
    /// <summary>
    /// Свойства текстуры.
    /// </summary>
    public class Texture2D : GameComponent
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

        /// <summary>
        /// Метод, сравнивающий текущий объект с переданным в параметр (нужен для тестов).
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>Да, если равны, в противном случае - нет.</returns>
        public override bool Equals(object obj)
        {
            return obj is Texture2D d &&
                   ID == d.ID &&
                   Width == d.Width &&
                   Height == d.Height;
        }
    }
}
