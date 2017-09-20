using System;
using System.Collections.Generic;

namespace Model
{
    public class ReportConfiguration : PrinterConfiguration
    {

        #region Fields

        private string _reportName;

        #endregion

        #region Properties

        public string ReportName
        {
            get { return _reportName; }
            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Argument is null or whitespace", nameof(value));
                if (value.Length < 12)
                    throw new ArgumentException("Report name can'be less that 12 symbols", nameof(value));

                _reportName = value;
            }
        }

        public ICollection<ReportPrintData> Openings { get; internal set; }
        
        #endregion

        public void AddFile(string fileName)
            => Openings.Add(new ReportPrintData {FileName = fileName, Opening = DateTime.Now, Report = this});
    }
}