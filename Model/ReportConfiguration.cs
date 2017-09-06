using System.Text.RegularExpressions;

namespace Model
{
    public class ReportConfiguration : PrinterConfiguration
    {
        #region Static

        internal static bool Validate(string reportName)
            => GroupConfiguration.Validate(reportName) && Regex.IsMatch(reportName, "\\b.{5}\\d{2}[\\w[\\d]]{2}\\B");

        #endregion

        #region Properties

        public string ReportName { get; set; }

        #endregion
    }
}