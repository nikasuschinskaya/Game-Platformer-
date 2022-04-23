using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using System.IO;
using System.Drawing;
using System.Xml;

namespace GameLogic
{
    /// <summary>
    /// Работа с уровнями.
    /// </summary>
    public class Level
    {
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
        /// Начальнаяя позиция горизонтального врага.
        /// </summary>
        public List<Point> enemiesHorSpawn = new List<Point>();

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

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
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

        //public Level(string filePath)
        //{
            //    try
            //    {
            //        using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //        {
            //            XmlDocument doc = new XmlDocument();
            //            doc.Load(stream);

            //            int width = int.Parse(doc.DocumentElement.GetAttribute("width"));
            //            int height = int.Parse(doc.DocumentElement.GetAttribute("height"));

            //            grid = new Block[width, height];
            //            this.filename = filePath;

            //            playerStartPos = new Point(1, 1);

            //            XmlNode tileLayer = doc.DocumentElement.SelectSingleNode("layer[@name='Tile Layer 1']");
            //            XmlNodeList tiles = tileLayer.SelectSingleNode("data").SelectNodes("tile");

            //            int x = 0, y = 0;
            //            for (int i = 0; i < tiles.Count; i++)
            //            {
            //                int gid = int.Parse(tiles[i].Attributes["gid"].Value);

            //                switch (gid)
            //                {
            //                    case 2:
            //                        grid[x, y] = new Block(BlockType.Solid, x, y);
            //                        break;
            //                    case 3:
            //                        grid[x, y] = new Block(BlockType.Ladder, x, y);
            //                        break;
            //                    case 4:
            //                        grid[x, y] = new Block(BlockType.LadderPlatform, x, y);
            //                        break;
            //                    case 5:
            //                        grid[x, y] = new Block(BlockType.Platform, x, y);
            //                        break;
            //                    case 6:
            //                        grid[x, y] = new Block(BlockType.SpikeUp, x, y);
            //                        break;
            //                    case 7:
            //                        grid[x, y] = new Block(BlockType.SpikeRight, x, y);
            //                        break;
            //                    case 8:
            //                        grid[x, y] = new Block(BlockType.SpikeDown, x, y);
            //                        break;
            //                    case 9:
            //                        grid[x, y] = new Block(BlockType.SpikeLeft, x, y);
            //                        break;
            //                    case 10:
            //                        grid[x, y] = new Block(BlockType.Key, x, y);
            //                        break;
            //                    case 11:
            //                        grid[x, y] = new Block(BlockType.Door, x, y);
            //                        break;
            //                    default:
            //                        grid[x, y] = new Block(BlockType.Empty, x, y);
            //                        break;
            //                }

            //                x++;
            //                if(x >= width)
            //                {
            //                    x = 0;
            //                    y++;
            //                }
            //            }

            //            XmlNode objectGroup = doc.DocumentElement.SelectSingleNode("objectgroup[@name='Object Layer 1']");
            //            XmlNodeList objects = objectGroup.SelectNodes("object");

            //            for(int i = 0; i < objects.Count; i++)
            //            {
            //                int xPos = int.Parse(objects[i].Attributes["x"].Value);
            //                int yPos = int.Parse(objects[i].Attributes["y"].Value);

            //                switch (objects[i].Attributes["name"].Value)
            //                {
            //                    case "playerStartPos":
            //                        this.playerStartPos = new Point((int)(xPos / 128), (int)(yPos / 128));
            //                        break;                                
            //                }

            //            }
            //        }
            //    }
            //    catch(Exception e)
            //    {
            //        System.Windows.MessageBox.Show($"Что-то плохое случилось с загрузкой файла \n Ошибка: {0}",
            //            e.Message);
            //    }
        //}
    }
}
