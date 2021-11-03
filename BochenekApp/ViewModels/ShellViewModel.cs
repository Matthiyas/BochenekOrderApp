using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BochenekApp.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
       
        public ShellViewModel()
        {

        }


        public void LoadPageOne()
        {
            ActivateItemAsync(new FormViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItemAsync(new TableViewModel());
        }
    }
}
