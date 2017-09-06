using System;

namespace Model
{
    public class ReportDataModel
    {
        #region Static

        /// <summary>
        ///     Checks if fileName can be either Report Name or Report Group Name
        /// </summary>
        public static bool Validate(string fileName)
            => ReportConfiguration.Validate(fileName) || GroupConfiguration.Validate(fileName);

        #endregion

        #region Methods

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