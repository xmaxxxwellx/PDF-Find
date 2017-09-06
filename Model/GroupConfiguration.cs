using System.Collections.Generic;
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
    }
}