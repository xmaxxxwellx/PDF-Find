using System;

namespace Model
{
    public class ReportDataModel
    {
        #region Properties

        private ApplicationConfigurator ApplicationConfigurator { get; }

        #endregion

        public ReportDataModel()
        {
            ApplicationConfigurator = new ApplicationConfigurator();
        }

        #region Methods

        public void OpenInReader(string filePath) => ApplicationConfigurator.Open(filePath);

        public void OpenForPrint(string filePath, PrinterConfiguration configuration)
        {
            throw new NotImplementedException("delegate to windows pdf printer");
        }

        /// <summary>
        ///     Tryes to find report by it's name in DB. Returns <c>null</c> if no one;
        /// </summary>
        public ReportConfiguration FindReport(string reportName)
        {
            ReportConfiguration.Validate(reportName);

            throw new NotImplementedException("Find in DB");
        }

        /// <summary>
        ///     Tryes to find report group by it's name in DB. Returns <c>null</c> if no one;
        /// </summary>
        public GroupConfiguration FindGroup(string groupName)
        {
            // todo exception localizations
            if (string.IsNullOrWhiteSpace(groupName))
                throw new ArgumentException("Argument is null or whitespace", nameof(groupName));

            throw new NotImplementedException("Find in DB");
        }

        #endregion
    }
}