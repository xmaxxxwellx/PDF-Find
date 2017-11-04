using System;
using System.Data.Entity.Validation;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Entities;

namespace Model.Tests
{
    [TestClass]
    public class PrinterConfigurationDataBaseTest
    {
        [TestMethod]
        public void Constructor()
        {
            new PrinterConfigurationDataBase("PdfFindTestBase");
        }

        [TestMethod]
        // todo !!!
        public void AddReport()
        {
            var dataBase = new PrinterConfigurationDataBase("PdfFindTestBase");

            var reportConfigurations = new[]
            {
                new ReportConfiguration(),
                new ReportConfiguration {Group = null},
                new ReportConfiguration {Group = new GroupConfiguration()}
            };

            foreach (var configuration in reportConfigurations)
            {
                try
                {
                    dataBase.ReportConfigurations.Add(configuration);
                    if (dataBase.SaveChanges() != 1)
                        throw new Exception();
                }
                catch (DbEntityValidationException)
                {
                    dataBase.ReportConfigurations.Remove(configuration);
                }
            }

            try
            {
                dataBase.ReportConfigurations.Add(new ReportConfiguration { Group = new GroupConfiguration {GroupName = "Group#1"}, ReportName = "ReportName#1"});
                dataBase.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var dbValidationError = e.EntityValidationErrors.First().ValidationErrors.First();
                throw new Exception((dbValidationError.ErrorMessage) + " : " + (dbValidationError.PropertyName) 
                    + " : " + dataBase.ReportConfigurations.Count() 
                    + " : " + ((GroupConfiguration)(e.EntityValidationErrors.First().Entry.Entity)).GroupName, e);
            }
        }
    }
}
