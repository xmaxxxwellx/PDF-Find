using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace ModelUnitTest.Tests
{
    [TestClass]
    public class ReportDataModelTest
    {
        [TestMethod]
        public void Constructor()
        {
            try
            {
                new ReportDataModel(null, null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                // ignore
            }

            // todo add database
            new ReportDataModel(new TestApplicationConfigurator(), null);

        }
      
    }
}
