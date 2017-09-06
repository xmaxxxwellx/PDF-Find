using System;
using System.ComponentModel;
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
        private Language _language;

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

        #endregion
    }
}