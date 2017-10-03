using System;

namespace Model.Entities
{
    public class FileReadingData : IFileOpeningData
    {
        public DateTime Opening { get; set; }
        public string FileName { get; set; }
    }
}