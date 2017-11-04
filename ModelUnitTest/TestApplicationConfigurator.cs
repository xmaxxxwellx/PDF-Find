using System.ComponentModel;

namespace Model.Tests
{
    public class TestApplicationConfigurator : IApplicationConfigurator
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Language
        {
            get { return "English"; }
            set { throw new System.NotImplementedException(); }
        }

        public string ReaderPath
        {
            get { return string.Empty; }
            set { throw new System.NotImplementedException(); }
        }

        public string DataBaseConnectionString
        {
            get { return string.Empty; }
            set { throw new System.NotImplementedException(); }
        }
    }
}
