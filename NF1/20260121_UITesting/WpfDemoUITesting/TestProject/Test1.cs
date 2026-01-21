using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.UIA3;

namespace TestProject
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //====================================================================
            // Engeguem l'aplicació 
            //====================================================================
            // ☞☞☞☞ WARNING: per a que això funcioni cal que el projecte de testing
            // referencii al projecte principal.
            string path = System.IO.Directory.GetCurrentDirectory();
            var app = FlaUI.Core.Application.Launch(path + "\\WpfDemoUITesting.exe");
            //app = FlaUI.Core.Application.Launch( "C:\\Program Files\\Mozilla Firefox\\firefox.exe");



            app.WaitWhileMainHandleIsMissing(TimeSpan.FromSeconds(5));

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                TextBox? t1 = window.FindFirstDescendant(cf => cf.ByAutomationId("txtOp1"))?.AsTextBox();
                TextBox? t2 = window.FindFirstDescendant(cf => cf.ByAutomationId("txtOp2"))?.AsTextBox();
                TextBox? t_res = window.FindFirstDescendant(cf => cf.ByAutomationId("txtRes"))?.AsTextBox();
                Button? b = window.FindFirstDescendant(cf => cf.ByClassName("Button"))?.AsButton();

                t1.Focus();
                Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.NUMPAD6);
                // t1.Text = "1";
                t2.Text = "4";
                b.Click();
                Assert.AreEqual("5", t_res.Text);

            }
        }
    }
}
