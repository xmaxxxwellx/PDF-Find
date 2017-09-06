using System;

namespace Model
{
    public class ReportDataModel
    {
        #region Static

        /// <summary>
        ///     Checks if fileName can be either Report Name or Report Group Name
        /// </summary>
        public static bool Validate(string reportName) // todo ? check on exstention ?
            => ReportConfiguration.Validate(reportName) || GroupConfiguration.Validate(reportName);

        #endregion

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
            // todo exception localizations
            // todo exception type
            if (!ReportConfiguration.Validate(reportName))
                throw new ArgumentException($"Invalid {nameof(reportName)}");

            throw new NotImplementedException("Find in DB");
        }

        /// <summary>
        ///     Tryes to find report group by it's name in DB. Returns <c>null</c> if no one;
        /// </summary>
        public GroupConfiguration FindGroup(string groupName)
        {
            // todo exception localizations
            // todo exception type
            if (!GroupConfiguration.Validate(groupName))
                throw new ArgumentException($"Invalid {nameof(groupName)}");

            throw new NotImplementedException("Find in DB");
        }

        #endregion
    }
}