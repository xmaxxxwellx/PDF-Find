using System;

namespace Model.Entities
{
    public abstract class PrinterConfiguration
    {
        #region Properties

        public Guid Id { get; set; }

        public string PrinterName { get; set; }

        public bool Duplex { get; set; }

        public PaperFormat PaperFormat { get; set; }

        #endregion
    }
}