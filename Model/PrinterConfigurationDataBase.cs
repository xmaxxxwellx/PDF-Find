using System;
using System.Data.Entity;
using System.Linq;

namespace Model
{
    public class PrinterConfigurationDataBase : DbContext
    {
        #region Properties

        protected virtual DbSet<ReportConfiguration> ReportConfigurations { get; set; }
        protected virtual DbSet<GroupConfiguration> GroupConfigurations { get; set; }
        public virtual DbSet<IFileOpeningData> FileOpeningDatas { get; set; }

        #endregion

        public PrinterConfigurationDataBase(string connectionString)
            : base(connectionString)
        {
        }

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException("Form db rules and formats");

            base.OnModelCreating(modelBuilder);
        }

        public ReportConfiguration FindReport(string reportName)
        {
            // todo exception localizations
            if (string.IsNullOrWhiteSpace(reportName))
                throw new ArgumentException("Argument is null or whitespace", nameof(reportName));

            ReportConfiguration.ValidateReportName(reportName);

            // todo inner db procedure
            return
                ReportConfigurations.FirstOrDefault(
                    configuration => configuration.ReportName.Equals(reportName));
        }

         public GroupConfiguration FindGroup(string reportName)
        {
            // todo exception localizations
            if (string.IsNullOrWhiteSpace(reportName))
                throw new ArgumentException("Argument is null or whitespace", nameof(reportName));

            // todo validation

            // todo inner db procedure
            return
                GroupConfigurations.LastOrDefault(
                    configuration => reportName.StartsWith(configuration.GroupName));
        }

        #endregion
    }
}