using System;
using System.Data.Entity;

namespace Model
{
    internal class PrinterConfigurationDataBase : DbContext
    {
        #region Properties

        public virtual DbSet<ReportConfiguration> ReportConfigurations { get; set; }
        public virtual DbSet<GroupConfiguration> GroupConfigurations { get; set; }
        public virtual DbSet<IFileOpeningData> FileOpeningDatas { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException("Form db rules and formats");

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}