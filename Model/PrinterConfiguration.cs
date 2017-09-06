namespace Model
{
    public class PrinterConfiguration
    {
        #region Properties

        public string PrinterName { get; set; }

        public bool Duplex { get; set; }

        public PaperFormat PaperFormat { get; set; }

        #endregion
    }
}