using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class EnumToBind
    {
        
        public IList<PaperFormat> PaperFormats
            {
                get
                {
                    // Will result in a list like {"Tester", "Engineer"}
                    return Enum.GetValues(typeof(PaperFormat)).Cast<PaperFormat>().ToList<PaperFormat>();
                }
            }
                public PaperFormat UserType
            {
                get;
                set;
            }
    }
       
}
