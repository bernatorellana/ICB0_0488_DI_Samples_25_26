using WpfTestingTeatre.Model;

namespace TestProject
{
    [TestClass]
    public sealed class TestTheIncredibleMachine
    {
        [TestMethod]
        public void Test_TIM()
        {
            TheIncredibleMachine tim = new TheIncredibleMachine();
            int[] data = { 2, 3, 3, 3, 3, 3, 3, 5, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 1, 13 };
            tim.crunch(data);
        }

        [TestMethod]
        public void Test_TIM2()
        {
            TheIncredibleMachine tim = new TheIncredibleMachine();
            tim.crunch([-1, 10]);
        }
    }
}
