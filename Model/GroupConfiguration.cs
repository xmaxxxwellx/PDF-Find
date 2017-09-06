using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Model
{
    public class GroupConfiguration : PrinterConfiguration
    {
        #region Static

        internal static bool Validate(string reportName) => Regex.IsMatch(reportName, "\\b[\\w[\\d]]{2}\\d{4}.*\\B");

        #endregion

        #region Properties

        public string GroupName { get; set; }

        public ICollection<ReportConfiguration> Reports { get; set; }

        #endregion

        #region Methods

        internal ReportConfiguration CreateReport(string reportName)
        {
            // todo exception localizations
            // todo exception type
            if (!ReportConfiguration.Validate(reportName))
                throw new ArgumentException($"Invalid {nameof(reportName)}.");

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