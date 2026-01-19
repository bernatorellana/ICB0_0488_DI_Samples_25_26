using WpfTestingTeatre.Model;

namespace TestProject
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestGetPreu_ForaRang()
        {
            int[,] valors = new int[,] {
                                    { 1,-15},
                                    { -1,40},
                                    { 0,40},
                                    { 5,40},
                                    { 1,-1},
                                    { 1,0},
                                    { 1,120} };

            for (int i = 0; i < valors.GetLength(0); i++)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Throws<Exception>(() =>
                {
                    TarifesTeatre.getPreu(valors[i, 0], valors[i, 1]);
                });
            }
        }




        [TestMethod]
        public void TestGetPreu()
        {

            Assert.AreEqual(0, TarifesTeatre.getPreu(1, 3));
            Assert.AreEqual(45, TarifesTeatre.getPreu(1, 4));
            Assert.AreEqual(45, TarifesTeatre.getPreu(1, 7));
            Assert.AreEqual(60, TarifesTeatre.getPreu(1, 12));
            Assert.AreEqual(60, TarifesTeatre.getPreu(1, 13));
            Assert.AreEqual(60, TarifesTeatre.getPreu(1, 40));
            Assert.AreEqual(30, TarifesTeatre.getPreu(1, 60));
            Assert.AreEqual(30, TarifesTeatre.getPreu(1, 61));
            Assert.AreEqual(30, TarifesTeatre.getPreu(1, 78));
            Assert.AreEqual(0, TarifesTeatre.getPreu(2, 3));
            Assert.AreEqual(37.5m, TarifesTeatre.getPreu(2, 4));
            Assert.AreEqual(37.5m, TarifesTeatre.getPreu(2, 7));
            Assert.AreEqual(50, TarifesTeatre.getPreu(2, 12));
            Assert.AreEqual(50, TarifesTeatre.getPreu(2, 13));
            Assert.AreEqual(50, TarifesTeatre.getPreu(2, 40));
            Assert.AreEqual(10, TarifesTeatre.getPreu(2, 60));
            Assert.AreEqual(10, TarifesTeatre.getPreu(2, 61));
            Assert.AreEqual(10, TarifesTeatre.getPreu(2, 78));
            Assert.AreEqual(0, TarifesTeatre.getPreu(3, 3));
            Assert.AreEqual(30, TarifesTeatre.getPreu(3, 4));
            Assert.AreEqual(30, TarifesTeatre.getPreu(3, 7));
            Assert.AreEqual(40, TarifesTeatre.getPreu(3, 12));
            Assert.AreEqual(40, TarifesTeatre.getPreu(3, 13));
            Assert.AreEqual(40, TarifesTeatre.getPreu(3, 40));
            Assert.AreEqual(8, TarifesTeatre.getPreu(3, 60));
            Assert.AreEqual(8, TarifesTeatre.getPreu(3, 61));
            Assert.AreEqual(8, TarifesTeatre.getPreu(3, 78));
            Assert.AreEqual(0, TarifesTeatre.getPreu(4, 3));
            Assert.AreEqual(22.5m, TarifesTeatre.getPreu(4, 4));
            Assert.AreEqual(22.5m, TarifesTeatre.getPreu(4, 7));
            Assert.AreEqual(30, TarifesTeatre.getPreu(4, 12));
            Assert.AreEqual(30, TarifesTeatre.getPreu(4, 13));
            Assert.AreEqual(30, TarifesTeatre.getPreu(4, 40));
            Assert.AreEqual(6, TarifesTeatre.getPreu(4, 60));
            Assert.AreEqual(6, TarifesTeatre.getPreu(4, 61));
            Assert.AreEqual(6, TarifesTeatre.getPreu(4, 78));



        }
    }
}
