using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model.Entities;

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

       public ICommand SaveCommand { get; }

       private StateReport()
       {
          
       }
    }
}
