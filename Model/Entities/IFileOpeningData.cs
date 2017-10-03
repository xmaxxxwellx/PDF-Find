using System;

namespace Model.Entities
{
    public interface IFileOpeningData
    {
         DateTime Opening { get;  set; }
         string FileName { get;  set; }
    }
}
