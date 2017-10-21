using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using Model;

namespace ModelUnitTest.Tests
{
    [TestClass]
    public class RegistryApplicationConfiguratorTest
    {
        private static string key = "PdfFindTest";

        [TestMethod]
        public void ConstructorTest()
        {
            RegistryApplicationConfigurator regAppConfig = new RegistryApplicationConfigurator(key);

            Assert.IsNotNull(regAppConfig);
        }

        [TestMethod]
        public void SaveMethodTest() 
        {
            RegistryApplicationConfigurator regAppConfig = new RegistryApplicationConfigurator(key);

            regAppConfig.Language = "ukrainian";
            regAppConfig.ReaderPath = @"C:\Program Files\TotalCommander\TOTALCMD64.EXE";
            regAppConfig.DataBaseConnectionString = "conectionSTR";

            regAppConfig.Save();

            regAppConfig = new RegistryApplicationConfigurator(key);

            Assert.AreEqual(regAppConfig.Language, "ukrainian");
            Assert.AreEqual(regAppConfig.ReaderPath, @"C:\Program Files\TotalCommander\TOTALCMD64.EXE");
            Assert.AreEqual(regAppConfig.DataBaseConnectionString, "conectionSTR");
        }

        [TestCleanup]
        public void CleanUpRegistry() {
            RegistryKey currentUserKey = Registry.CurrentUser;
            currentUserKey.DeleteSubKey(key);
        }
    }
}
