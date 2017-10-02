
using System.ComponentModel;
using Model;

namespace ModelUnitTest
{
    public class TestApplicationConfigurator : IApplicationConfigurator
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Language Language
        {
            get { return Language.English; }
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
