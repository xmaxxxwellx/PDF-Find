using System.Collections.Generic;

namespace Model
{
    public class GroupConfiguration : PrinterConfiguration
    {
        public string GroupName { get; set; }

        public ICollection<ReportConfiguration> Reports { get; set; }
    }
}