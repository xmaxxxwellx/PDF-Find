using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace Model
{
    public enum Language
    {
        English,
        Ukrainian
    }

    public class ApplicationConfigurator : INotifyPropertyChanged
    {
        #region Fields

        private Language _language;
        private string _readerPath;

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
                    throw new ArgumentException("Argument is null or whitespace", nameof(value)); // todo locale
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

        #endregion

        public ApplicationConfigurator()
        {
            throw new NotImplementedException("Open Registry to take/write data");
        }

        #region Methods

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        internal void Open(string filePath)
        {
            if (Path.GetExtension(filePath) == "pdf")
                // todo locale    // todo exception type
                throw new ArgumentException("File must be .pdf only", nameof(filePath));

            if (!File.Exists(filePath))
                // todo locale
                throw new FileNotFoundException("Can't find file", ReaderPath);

            new Process {StartInfo = {FileName = ReaderPath, Arguments = Path.GetFullPath(filePath)}}.Start();
        }

        #endregion
    }
}