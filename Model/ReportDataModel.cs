using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Model
{
    public class ReportDataModel
    {
        #region Properties

        private PrinterConfigurationDataBase DataBase { get; }

        private IApplicationConfigurator ApplicationConfigurator { get; }

        #endregion
        
        public ReportDataModel(IApplicationConfigurator applicationConfigurator,  PrinterConfigurationDataBase dataBase)
        {
            ApplicationConfigurator = applicationConfigurator;
            DataBase = dataBase;
        }

        #region Methods

        /// <summary>
        /// opens file in prf reader
        /// </summary>
        public void OpenInReader(string filePath)
        {
            DataBase.FileOpeningDatas.Add(new FileReadingData { FileName = Path.GetFileNameWithoutExtension(filePath), Opening = DateTime.Now });
            if (Path.GetExtension(filePath) == "pdf")
                // todo locale    // todo exception type
                throw new ArgumentException("File must be .pdf only", nameof(filePath));

            if (!File.Exists(filePath))
                // todo locale
                throw new FileNotFoundException("Can't find file", filePath);

            new Process { StartInfo = { FileName = ApplicationConfigurator.ReaderPath, Arguments = Path.GetFullPath(filePath) } }.Start();
        }

        /// <summary>
        ///              delegates file to printer with <paramref name="configuration"/>
        /// </summary>
        public void OpenForPrint(string filePath, ReportConfiguration configuration)
        {
            configuration.AddFile(Path.GetFileNameWithoutExtension(filePath));
            throw new NotImplementedException("delegate to printer");
        }

        /// <summary>
        ///     Tryes to find report by it's name in DB. Returns <c>null</c> if no one;
        /// </summary>
        public ReportConfiguration FindReport(string reportName)
        {
            // todo exception localizations
            if (string.IsNullOrWhiteSpace(reportName))
                throw new ArgumentException("Argument is null or whitespace", nameof(reportName));

            // todo inner db procedure
            return
                DataBase.ReportConfigurations.FirstOrDefault(
                    configuration => configuration.ReportName.Equals(reportName));
        }

        /// <summary>
        ///     Tryes to find report group by it's name in DB. Return LAST of the list or <c>null</c> if no one;
        /// </summary>
        public GroupConfiguration FindGroup(string reportName)
        {
            // todo exception localizations
            if (string.IsNullOrWhiteSpace(reportName))
                throw new ArgumentException("Argument is null or whitespace", nameof(reportName));
            
            // todo inner db procedure
            return
                DataBase.GroupConfigurations.LastOrDefault(
                    configuration => reportName.StartsWith(configuration.GroupName));
        }

        #endregion
    }
}