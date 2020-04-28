using DDToolKit.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDToolKitUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestPlayerSize()
        {
            SavesController c = new SavesController();
            string temp = "average";

            string expected = "average";
            string result = c.PlayerAttributeFiller(temp);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPlayerSizeFalse()
        {
            SavesController c = new SavesController();

            string temp = null;

            string expected = "No Data";

            string result = c.PlayerAttributeFiller(temp);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestFirstSpellName()
        {
            CreaturesController c = new CreaturesController();

            string temp = "Acid Arrow";

            string expected = "Acid Arrow";

            string result = c.IsString(temp);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestFirstSpellNameFalse()
        {
            CreaturesController c = new CreaturesController();

            string temp = null;

            string expected = "Name is null";

            string result = c.IsString(temp);
            Assert.AreEqual(expected, result);
        }
    }
}
