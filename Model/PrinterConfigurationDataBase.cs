using System;
using System.Data.Entity;

namespace Model
{
    internal class PrinterConfigurationDataBase : DbContext
    {
        public virtual DbSet<ReportConfiguration> ReportConfigurations { get; set; }
        public virtual DbSet<GroupConfiguration> GroupConfigurations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException("Form db rules and formats");

            base.OnModelCreating(modelBuilder);
        }
    }
}