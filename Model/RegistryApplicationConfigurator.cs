using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Model
{
    public class RegistryApplicationConfigurator : IApplicationConfigurator
    {
        #region Fields

        private Language _language;
        private string _readerPath;
        private string _dataBaseConnectionString;

        #endregion

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        public Language Language
        {
            get { return _language; }
            set
            {
                if (!Enum.IsDefined(typeof (Language), value)) throw new ArgumentOutOfRangeException(nameof(value));
                if (_language == value) return;
                _language = value;
                // todo change in Registry
                OnPropertyChanged();
            }
        }

        public string ReaderPath
        {
            get { return _readerPath; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    // todo locale
                    throw new ArgumentException("Argument is null or whitespace", nameof(value));
                if (_readerPath == value)
                    return;
                if (!File.Exists(value))
                    throw new FileNotFoundException("Reader wasn't found", value); // todo locale
                if (Path.GetExtension(value) != "exe")
                    // todo locale            // todo exception type
                    throw new ArgumentException("Reader must be *.exe application", nameof(value));

                // use fullPath or name if program writen in Path?

                _readerPath = Path.GetFullPath(value);
                // todo set to Registry
                OnPropertyChanged();
            }
        }

        public string DataBaseConnectionString
        {
            get { return _dataBaseConnectionString; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    // todo locale
                    throw new ArgumentException("Argument is null or whitespace", nameof(value));
                _dataBaseConnectionString = value;
                // todo set to Registry
                OnPropertyChanged();
            }
        }

        #endregion

        public RegistryApplicationConfigurator()
        {
            throw new NotImplementedException("Open Registry to take/write data");
        }

        #region Methods

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}