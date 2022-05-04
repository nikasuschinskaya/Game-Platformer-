using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameLogic
{
    /// <summary>
    /// Тестирование фабрики.
    /// </summary>
    [TestClass()]
    public class LevelFactoryTests
    {
        /// <summary>
        /// Тестирование создания блоков.
        /// </summary>
        [TestMethod()]
        public void BlocksTest()
        {
            LevelFactory lf = new LevelFactory();
            lf.Blocks(1, 0, 0);
            Assert.AreEqual(lf.grid[0, 0].Type, BlockType.Empty);
            lf.Blocks(2, 0, 0);
            Assert.AreEqual(lf.grid[0, 0].Type, BlockType.Solid);
            lf.Blocks(3, 0, 0);
            Assert.AreEqual(lf.grid[0, 0].Type, BlockType.Ladder);
            lf.Blocks(4, 0, 0);
            Assert.AreEqual(lf.grid[0, 0].Type, BlockType.LadderPlatform);
            lf.Blocks(5, 0, 0);
            Assert.AreEqual(lf.grid[0, 0].Type, BlockType.Platform);
            lf.Blocks(6, 0, 0);
            Assert.AreEqual(lf.grid[0, 0].Type, BlockType.SpikeUp);
            lf.Blocks(7, 0, 0);
            Assert.AreEqual(lf.grid[0, 0].Type, BlockType.SpikeRight);
            lf.Blocks(8, 0, 0);
            Assert.AreEqual(lf.grid[0, 0].Type, BlockType.SpikeDown);
            lf.Blocks(9, 0, 0);
            Assert.AreEqual(lf.grid[0, 0].Type, BlockType.SpikeLeft);
            lf.Blocks(10, 0, 0);
            Assert.AreEqual(lf.grid[0, 0].Type, BlockType.Key);
        }
    }
}