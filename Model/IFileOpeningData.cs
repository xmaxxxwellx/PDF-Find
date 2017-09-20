using System;

namespace Model
{
    public interface IFileOpeningData
    {
         DateTime Opening { get;  set; }
         string FileName { get;  set; }
    }
}
