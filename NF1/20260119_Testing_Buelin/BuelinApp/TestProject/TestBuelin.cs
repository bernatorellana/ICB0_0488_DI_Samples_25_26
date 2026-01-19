using BuelinApp.Model;

namespace TestProject
{
    [TestClass]
    public sealed class TestBuelin
    {
        [TestMethod]
        public void TestBuelinGetPreu()
        {
            Buelin b;
            b = new Buelin();
            ;

            Assert.AreEqual(0m, b.getSobrecostPerEquipatge([null, ,], , [null, null], FALSE));
            Assert.AreEqual(0m, b.getSobrecostPerEquipatge([30, 30, 30], , [20, null], FALSE));
            Assert.AreEqual(60m, b.getSobrecostPerEquipatge([31, 30, 30], , [20, null], FALSE));
            Assert.AreEqual(60m, b.getSobrecostPerEquipatge([30, 31, 30], , [20, null], FALSE));
            Assert.AreEqual(60m, b.getSobrecostPerEquipatge([30, 30, 31], , [20, null], FALSE));
            Assert.AreEqual(20m, b.getSobrecostPerEquipatge([30, 30, 30], , [21, null], FALSE));
            Assert.AreEqual(0m, b.getSobrecostPerEquipatge([null, ,], , [null, 20], FALSE));
            Assert.AreEqual(20m, b.getSobrecostPerEquipatge([null, ,], , [null, 20], FALSE));
            Assert.AreEqual(200m, b.getSobrecostPerEquipatge([null, ,], , [null, 20], FALSE));
            Assert.AreEqual(220m, b.getSobrecostPerEquipatge([null, ,], , [null, 20], FALSE));
            Assert.AreEqual(280m, b.getSobrecostPerEquipatge([30, 31, 30], , [20, 20], FALSE));
            Assert.AreEqual(282m, b.getSobrecostPerEquipatge([30, 31, 30], , [20, 20], TRUE));
            Assert.AreEqual(0m, b.getSobrecostPerEquipatge([null, ,], , [null, null], TRUE));
        }
    }
}
