using System;

namespace Model
{
    public class ReportConfiguration : PrinterConfiguration
    {
        #region Static

        internal static void Validate(string reportName)
        {
            if (string.IsNullOrWhiteSpace(reportName))
                throw new ArgumentException("Argument is null or whitespace", nameof(reportName));
            const int minNameLength = 2;
            if (reportName.Length < minNameLength)
                throw new ArgumentException($"{nameof(ReportName)} must be {minNameLength} or more symbols length",
                    nameof(reportName));
        }

        #endregion

        #region Fields

        private string _reportName;

        #endregion

        #region Properties

        public string ReportName
        {
            get { return _reportName; }
            internal set
            {
                Validate(value);
                _reportName = value;
            }
        }

        #endregion
    }
}