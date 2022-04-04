using BochenekApp.Models;
using BochenekApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace BochenekApp.Views
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : UserControl
    {
        
        public UserControl GetImage()
        {
            UserControl uc = (UserControl)FindName("Table");

            TextBlock count = (TextBlock)FindName("count");
            TextBlock typ = (TextBlock)FindName("typ");
            TextBlock num = (TextBlock)FindName("num");
            TextBlock client = (TextBlock)FindName("client");
            TextBlock wid = (TextBlock)FindName("wid");
            TextBlock heig = (TextBlock)FindName("heig");
            TextBlock col = (TextBlock)FindName("col");
            TextBlock tra = (TextBlock)FindName("tra");
            TextBlock traType = (TextBlock)FindName("traType");
            TextBlock note = (TextBlock)FindName("note");
            TextBlock currentDate = (TextBlock)FindName("currentDate");

            //Canvas///////////////////////////////////////////////////////////////////////
            //Canvas can = (Canvas)FindName("rec");
            //Rectangle recBorder = new Rectangle();
            Rectangle recBorder = (Rectangle)FindName("bord");

            if (DataModel.ReadXML().trapeType== "Poziomy")
            {
                recBorder.Visibility = Visibility.Hidden;
                recBorder = (Rectangle)FindName("bordPo");
                recBorder.Visibility = Visibility.Visible;
            }
            else
            {
                Rectangle off = (Rectangle)FindName("bordPo");
                off.Visibility = Visibility.Hidden;
            }

            double recW,recH;
            if (DataModel.ReadXML().type == "Brama uchylna") recH = 270;
            else if (DataModel.ReadXML().type == "Drzwi stalowe") recH = 350;
            else if (DataModel.ReadXML().type == "Brama dwuskrzydłowa") recH = 280;
            else recH = 0;
            
            if (DataModel.ReadXML().type == "Brama uchylna") recW = 450;
            else if(DataModel.ReadXML().type == "Drzwi stalowe") recW = 200;
            else if (DataModel.ReadXML().type == "Brama dwuskrzydłowa") recW = 480;
            else recW = 0;

            recBorder.Width = recW;
            recBorder.Height = recH;
            recBorder.Stroke = System.Windows.Media.Brushes.Black; 
            recBorder.StrokeThickness = 3;

            //can.Children.Add(recBorder);



            ///////////////////////////////////////////////////////////////////////////////////

            count.Text = " Numer: "+DataModel.ReadXML().counter.ToString();
            typ.Text = DataModel.ReadXML().type;
            num.Text = DataModel.ReadXML().number+"szt.";
            client.Text = DataModel.ReadXML().clientName;
            wid.Text = DataModel.ReadXML().wid;
            heig.Text = DataModel.ReadXML().heig;
            col.Text = DataModel.ReadXML().color;
            tra.Text = DataModel.ReadXML().trapeze;
            traType.Text = DataModel.ReadXML().trapeType;
            note.Text = DataModel.ReadXML().notes;
            currentDate.Text = DateTime.Today.ToString("dddd ") + DateTime.Today.ToString("d");

            return uc;
        }
        
        public TableView()
        {
            InitializeComponent();
        }
    }
}
