using System;

namespace Model
{
    public class ReportPrintData : IFileOpeningData
    {
        public DateTime Opening { get; set; }
        public string FileName { get; set; }
        public ReportConfiguration Report { get; internal set; }
    }
}