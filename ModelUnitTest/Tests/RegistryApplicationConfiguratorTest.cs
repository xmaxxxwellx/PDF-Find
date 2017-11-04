using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;

namespace Model.Tests.Tests
{
    [TestClass]
    public class RegistryApplicationConfiguratorTest
    {
        private const string Key = "PdfFindTest";

        [TestMethod]
        public void ConstructorTest()
        {
            var regAppConfig = new RegistryApplicationConfigurator(Key);

            Assert.IsNotNull(regAppConfig);
        }

        [TestMethod]
        public void SaveMethodTest() 
        {
            var regAppConfig = new RegistryApplicationConfigurator(Key)
            {
                Language = "ukrainian",
                ReaderPath = @"C:\Program Files\TotalCommander\TOTALCMD64.EXE",
                DataBaseConnectionString = "conectionSTR"
            };


            regAppConfig.Save();

            regAppConfig = new RegistryApplicationConfigurator(Key);

            Assert.AreEqual(regAppConfig.Language, "ukrainian");
            Assert.AreEqual(regAppConfig.ReaderPath, @"C:\Program Files\TotalCommander\TOTALCMD64.EXE");
            Assert.AreEqual(regAppConfig.DataBaseConnectionString, "conectionSTR");
        }

        [TestCleanup]
        public void CleanUpRegistry() => Registry.CurrentUser.DeleteSubKey(Key);
    }
}
