using BuelinApp.Model;

namespace TestProject
{
    [TestClass]
    public sealed class TestBuelin
    {


        [TestMethod]
        public void TestBuelinGetPreu_Erronis()
        {
            Buelin b = new Buelin();
            Assert.Throws<Exception>(() => { b.getSobrecostPerEquipatge([10, 10], 15, null, false); });
            Assert.Throws<Exception>(() => { b.getSobrecostPerEquipatge([10, 10, 10, 10], 15, null, false); });
            Assert.Throws<Exception>(() => { b.getSobrecostPerEquipatge([10, -10, 10], 15, null, false); });
            Assert.Throws<Exception>(() => { b.getSobrecostPerEquipatge([10, 10, 0], 15, null, false); });
            Assert.Throws<Exception>(() => { b.getSobrecostPerEquipatge([10, 10, 10], 15, null, false); });
            Assert.Throws<Exception>(() => { b.getSobrecostPerEquipatge([10, 10, 10], 15, null, false); });
            Assert.Throws<Exception>(() => { b.getSobrecostPerEquipatge(null, 10, null, false); });
            Assert.Throws<Exception>(() => { b.getSobrecostPerEquipatge(null, null, [10, -10], false); });
            Assert.Throws<Exception>(() => { b.getSobrecostPerEquipatge(null, null, [10, 0], false); });
        }
         [TestMethod]
        public void TestBuelinGetPreu()
        {
            Buelin b;
            b = new Buelin();
            

            Assert.AreEqual(0m, b.getSobrecostPerEquipatge(null, null, null, false));
            Assert.AreEqual(0m, b.getSobrecostPerEquipatge([30, 30, 30], null, null, false));
            Assert.AreEqual(60m, b.getSobrecostPerEquipatge([31, 30, 30], null, null, false));
            Assert.AreEqual(60m, b.getSobrecostPerEquipatge([30, 31, 30], null, null, false));
            Assert.AreEqual(60m, b.getSobrecostPerEquipatge([30, 30, 31], null, null, false));
            Assert.AreEqual(20m, b.getSobrecostPerEquipatge([30, 30, 30], null, null, false));
            Assert.AreEqual(0m, b.getSobrecostPerEquipatge(null, 20, [20, 20], false));
            Assert.AreEqual(20m, b.getSobrecostPerEquipatge(null, 20, [20, 21], false));
            Assert.AreEqual(200m, b.getSobrecostPerEquipatge(null, 20, [20, 20, 20], false));
            Assert.AreEqual(220m, b.getSobrecostPerEquipatge(null, 20, [20, 21, 20], false));
            Assert.AreEqual(280m, b.getSobrecostPerEquipatge([30, 31, 30,], 20, [20, 21, 20], false));
            Assert.AreEqual(282m, b.getSobrecostPerEquipatge([30, 31, 30,], 20, [20, 21, 20], true));
            Assert.AreEqual(0m, b.getSobrecostPerEquipatge(null, null, null, true));
        }
    }
}
