using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochenekApp.Models;
using System.Windows;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using BochenekApp.Views;

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

        public void ClearData()
        {
            System.Windows.Forms.DialogResult dialog = System.Windows.Forms.MessageBox.Show("Na pewno wyczyścić dane?", "Dane", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                DataModel.ClearData();
                ActivateItemAsync(new TableViewModel());
            }
        }


        public System.Windows.Controls.UserControl TableViewModel { get; set; }
        public void SaveOrder()
        {
            
            //System.Windows.MessageBox.Show(this.TableViewModel);
            

            DialogResult dialog = System.Windows.Forms.MessageBox.Show("Na pewno utworzyć nowe zamówienie?", "Dane", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                ActivateItemAsync(new TableViewModel(true));
            }
        }
    }
}
