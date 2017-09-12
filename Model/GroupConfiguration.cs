using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class GroupConfiguration : PrinterConfiguration
    {
        #region Fields

        private string _groupName;

        #endregion

        #region Properties

        public ICollection<ReportConfiguration> Reports { get; set; }

        public string GroupName
        {
            get { return _groupName; }
            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Argument is null or whitespace", nameof(value));
                _groupName = value;
            }
        }

        #endregion

        #region Methods

        internal ReportConfiguration CreateReport(string reportName)
        {
            ReportConfiguration.Validate(reportName);

            // todo exception localizations
            // todo exception type
            if (!reportName.StartsWith(GroupName))
                throw new ArgumentException($"{nameof(reportName)} is not from this group.");

            var reportConfiguration = new ReportConfiguration
            {
                ReportName = reportName,
                PrinterName = PrinterName,
                Duplex = Duplex,
                PaperFormat = PaperFormat
            };

            if (Reports.Count > 0)
            {
                var first = Reports.First();
                if (Reports.All(configuration => configuration.PrinterName == first.PrinterName))
                    reportConfiguration.PrinterName = first.PrinterName;
                if (Reports.All(configuration => configuration.Duplex == first.Duplex))
                    reportConfiguration.Duplex = first.Duplex;
                if (Reports.All(configuration => configuration.PaperFormat == first.PaperFormat))
                    reportConfiguration.PaperFormat = first.PaperFormat;
            }

            Reports.Add(reportConfiguration);
            return reportConfiguration;
        }

        #endregion
    }
}