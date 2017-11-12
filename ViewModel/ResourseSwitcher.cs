using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;

namespace ViewModel
{
    public class ResourceSwitcher
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<CultureInfo> Cultures { get; }

        private CultureInfo Current { get; set; }

        public Properties.Resources Resources { get; private set; }

        public IEnumerable<CultureInfo> CultureList => Cultures;

        public CultureInfo CurrentCulture
        {
            get
            {
                return Current;
            }
            set
            {
                if (value == null || value == CurrentCulture)
                    return;
                Current = value;
                if (CultureList.Contains(Current))
                {
                    Properties.Resources.Culture = Current;
                    Resources = new Properties.Resources();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
                }
            }
        }

        public ResourceSwitcher()
        {
            Cultures = new List<CultureInfo>();
            if (Cultures.Any()) return;

            var resourceName = Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name)
                + ".resources.dll";

            foreach (string dir in Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory))
            {
                try
                {
                    DirectoryInfo dirinfo = new DirectoryInfo(dir);
                    var culture = CultureInfo.GetCultureInfo(dirinfo.Name);

                    if (dirinfo.GetFiles(resourceName).Any())
                        Cultures.Add(culture);
                }
                catch (ArgumentException)
                {
                    //ignore
                }
            }
            CurrentCulture = null;// todo read from reg  Properties.Settings.Default.DefaultCulture;
        }
    }
}