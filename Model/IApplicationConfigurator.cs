using System.ComponentModel;

namespace Model
{
    public interface IApplicationConfigurator : INotifyPropertyChanged
    {
        string Language { get; set; }
        string ReaderPath { get; set; }
        string DataBaseConnectionString { get; set; }

        void Save();
    }
}