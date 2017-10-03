using System;

namespace Model.Entities
{
    public interface IFileOpeningData
    {
        Guid Id { get; set; }
        DateTime Opening { get; set; }
        string FileName { get; set; }
    }
}
