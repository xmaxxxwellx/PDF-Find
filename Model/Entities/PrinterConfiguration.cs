using System;

namespace Model.Entities
{
    public abstract class PrinterConfiguration
    {
        #region Properties

        internal Guid Id { get; private set; }

        public string PrinterName { get; set; }

        public bool Duplex { get; set; }

        public PaperFormat PaperFormat { get; set; }

        #endregion
    }
}