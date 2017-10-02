using System.ComponentModel;

namespace Model
{
    public enum Language
    {
        English,
        Ukrainian
    }

    public interface IApplicationConfigurator : INotifyPropertyChanged
    {
        Language Language { get; set; }
        string ReaderPath { get; set; }
        string DataBaseConnectionString { get; set; }
    }
}