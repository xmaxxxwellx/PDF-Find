using System;
using System.IO;
using System.Linq;

namespace Model
{
    public class ReportDataModel
    {
        #region Properties

        private PrinterConfigurationDataBase DataBase { get; }

        private ApplicationConfigurator ApplicationConfigurator { get; }

        #endregion

        public ReportDataModel()
        {
            ApplicationConfigurator = new ApplicationConfigurator();
            DataBase = new PrinterConfigurationDataBase();
        }

        #region Methods

        /// <summary>
        /// opens file in prf reader
        /// </summary>
        public void OpenInReader(string filePath)
        {
            DataBase.FileOpeningDatas.Add(new FileReadingData { FileName = Path.GetFileNameWithoutExtension(filePath), Opening = DateTime.Now });
            ApplicationConfigurator.Open(filePath);
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