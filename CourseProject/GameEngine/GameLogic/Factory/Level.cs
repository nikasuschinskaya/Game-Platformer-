using System.Collections.Generic;
using System.Drawing;

namespace GameLogic
{
    /// <summary>
    /// Работа с уровнями.
    /// </summary>
    public class Level
    {
        /// <summary>
        /// Счетчик времени прыжка.
        /// </summary>
        public int CountOfJumpingTime = 0;

        /// <summary>
        /// Счетчик времени стрельбы.
        /// </summary>
        public int CountShootingTime = 0;

        /// <summary>
        /// Счетчик времени увеличения размеров недвигающегося врага.
        /// </summary>
        public int CountOfMEnemy = 0;

        /// <summary>
        /// Пули.
        /// </summary>
        public List<Bullet> bullets = new List<Bullet>();

        /// <summary>
        /// Координаты блоков.
        /// </summary>
        public Block[,] grid;

        /// <summary>
        /// Имя файла.
        /// </summary>
        public string filename;

        /// <summary>
        /// Начальная позиция игрока.
        /// </summary>
        public Point playerStartPos;

        /// <summary>
        /// Начальная позиция горизонтального врага.
        /// </summary>
        public List<Point> enemiesHorSpawn = new List<Point>();

        /// <summary>
        /// Начальная позиция стреляющего врага.
        /// </summary>
        public List<Point> enemiesShootSpawn = new List<Point>();

        /// <summary>
        /// Начальная позиция недвигающегося врага.
        /// </summary>
        public List<Point> enemiesMotionlessSpawn = new List<Point>();

        /// <summary>
        /// Работа с блоками.
        /// </summary>
        /// <param name="x">Координата x.</param>
        /// <param name="y">Координата y.</param>
        /// <returns>Блок.</returns>
        public Block this[int x, int y]
        {
            get
            {
                if (x >= 0 && y >= 0 && x < this.Width && y < this.Height)
                {
                    return grid[x, y];
                }
                else
                {
                    return new Block(BlockType.Solid, x, y);
                }
            }
            set
            {
                if (x >= 0 && y >= 0 && x < this.Width && y < this.Height)
                {
                    grid[x, y] = value;
                }
            }
        }

        /// <summary>
        /// Имя файла.
        /// </summary>
        public string FileName
        {
            get { return filename; }
        }

        /// <summary>
        /// Ширина блока.
        /// </summary>
        public int Width
        {
            get
            {
                return grid.GetLength(0);
            }
        }

        /// <summary>
        /// Высота блока.
        /// </summary>
        public int Height
        {
            get
            {
                return grid.GetLength(1);
            }
        }

        /// <summary>
        /// Конструктор по работе с уровнями.
        /// </summary>
        /// <param name="width">Ширина.</param>
        /// <param name="height">Высота.</param>
        public Level(int width, int height)
        {
            grid = new Block[width, height];
            filename = "none";
            playerStartPos = new Point(1, 1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        grid[x, y] = new Block(BlockType.Solid, x, y);
                    }
                    else
                    {
                        grid[x, y] = new Block(BlockType.Empty, x, y);

                    }
                }
            }
        }
    }
}
