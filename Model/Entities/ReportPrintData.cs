using System;

namespace Model.Entities
{
    public class ReportPrintData : IFileOpeningData
    {
        public Guid Id { get; set; }
        public DateTime Opening { get; set; }
        public string FileName { get; set; }
        public ReportConfiguration Report { get; internal set; }
    }
}