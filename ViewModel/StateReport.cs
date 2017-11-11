
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class StateReport
   {
       public static StateReport Instance { get; } = new StateReport();

        private ReportConfiguration report;

        public ReportConfiguration CurrentReportConfiguration
        {
            get { return report; }
            set
            {
                if (value == null) return;
                report = value;
            }
       }

       public  ICommand SaveCommand { get; private set; }

       private StateReport()
       {
           SaveCommand = new Prism.Commands.DelegateCommand(Save);
       }
       
       private void Save()
       {
           var db = new Model.DataBase(new RegistryApplicationConfigurator(null).DataBaseConnectionString);
           db.ReportConfigurations.Add(CurrentReportConfiguration);
           db.SaveChanges();
            
       }
    }
}
