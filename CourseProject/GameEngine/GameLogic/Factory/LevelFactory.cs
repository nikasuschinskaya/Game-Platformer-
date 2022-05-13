using System;
using System.Drawing;
using System.IO;
using System.Xml;

namespace GameLogic
{
    /// <summary>
    /// Фабрика уровней.
    /// </summary>
    public class LevelFactory : Level
    {
        /// <summary>
        /// Инициализатор. Нужен только для тестирования.
        /// </summary>
        public LevelFactory() : base(0, 0)
        {
            grid = new Block[1, 1];
        }
        /// <summary>
        /// Фабрика по созданию уровней.
        /// </summary>
        /// <param name="width">Ширина блока.</param>
        /// <param name="height">Высота блока.</param>
        /// <param name="filePath">Имя файла.</param>
        public LevelFactory(int width, int height, string filePath) : base(width, height)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(stream);

                    width = int.Parse(doc.DocumentElement.GetAttribute("width"));
                    height = int.Parse(doc.DocumentElement.GetAttribute("height"));

                    grid = new Block[width, height];
                    this.filename = filePath;

                    playerStartPos = new Point(1, 1);

                    XmlNode tileLayer = doc.DocumentElement.SelectSingleNode("layer[@name='Tile Layer 1']");
                    XmlNodeList tiles = tileLayer.SelectSingleNode("data").SelectNodes("tile");

                    int x = 0, y = 0;
                    for (int i = 0; i < tiles.Count; i++)
                    {
                        int gid = int.Parse(tiles[i].Attributes["gid"].Value);

                        Blocks(gid, x, y);

                        x++;
                        if (x >= width)
                        {
                            x = 0;
                            y++;
                        }
                    }

                    XmlNode objectGroup = doc.DocumentElement.SelectSingleNode("objectgroup[@name='Object Layer 1']");
                    XmlNodeList objects = objectGroup.SelectNodes("object");
                    enemiesStartPosition.Clear();

                    for (int i = 0; i < objects.Count; i++)
                    {
                        int xPos = int.Parse(objects[i].Attributes["x"].Value);
                        int yPos = int.Parse(objects[i].Attributes["y"].Value);

                        switch (objects[i].Attributes["name"].Value)
                        {
                            case "playerStartPos":
                                this.playerStartPos = new Point((int)(xPos / 128), (int)(yPos / 128));
                                break;
                            case "HorizontalEnemySpawn":
                                enemiesTypes.Add(EnemyType.Horizontal);
                                Point p = new Point((int)(xPos / 128), (int)(yPos / 128));
                                this.enemiesStartPosition.Add(p);
                                break;
                            case "ShootEnemySpawn":
                                enemiesTypes.Add(EnemyType.Shoot);
                                Point p2 = new Point((int)(xPos / 128), (int)(yPos / 128));
                                this.enemiesStartPosition.Add(p2);
                                break;
                            case "MotionlessEnemySpawn":
                                enemiesTypes.Add(EnemyType.Motionless);
                                Point p3 = new Point((int)(xPos / 128), (int)(yPos / 128));
                                this.enemiesStartPosition.Add(p3);
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show($"Что-то плохое случилось с загрузкой файла \n Ошибка: {0}",
                    e.Message);
            }
        }

        /// <summary>
        /// Создание блоков (метод сделан публичным для тестов).
        /// </summary>
        /// <param name="gid">id</param>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        public void Blocks(int gid, int x, int y)
        {
            switch (gid)
            {
                case 2:
                    grid[x, y] = new Block(BlockType.Solid, x, y);
                    break;
                case 3:
                    grid[x, y] = new Block(BlockType.Ladder, x, y);
                    break;
                case 4:
                    grid[x, y] = new Block(BlockType.LadderPlatform, x, y);
                    break;
                case 5:
                    grid[x, y] = new Block(BlockType.Platform, x, y);
                    break;
                case 6:
                    grid[x, y] = new Block(BlockType.SpikeUp, x, y);
                    break;
                case 7:
                    grid[x, y] = new Block(BlockType.SpikeRight, x, y);
                    break;
                case 8:
                    grid[x, y] = new Block(BlockType.SpikeDown, x, y);
                    break;
                case 9:
                    grid[x, y] = new Block(BlockType.SpikeLeft, x, y);
                    break;
                case 10:
                    grid[x, y] = new Block(BlockType.Key, x, y);
                    break;
                default:
                    grid[x, y] = new Block(BlockType.Empty, x, y);
                    break;
            }
        }
    }
}
