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

            TextBlock typ = (TextBlock)FindName("typ");
            TextBlock num = (TextBlock)FindName("num");
            TextBlock client = (TextBlock)FindName("client");
            TextBlock wid = (TextBlock)FindName("wid");
            TextBlock heig = (TextBlock)FindName("heig");
            TextBlock col = (TextBlock)FindName("col");
            TextBlock note = (TextBlock)FindName("note");

            typ.Text = DataModel.ReadXML().type;
            num.Text = DataModel.ReadXML().number+"szt.";
            client.Text = DataModel.ReadXML().clientName;
            wid.Text = DataModel.ReadXML().wid;
            heig.Text = DataModel.ReadXML().heig;
            col.Text = DataModel.ReadXML().color;
            note.Text = DataModel.ReadXML().notes;

            return uc;
        }
        
        public TableView()
        {
            InitializeComponent();
            
            //UserControl uc = (UserControl)FindName("Table");

            //Rect rect = new Rect(0, 0, uc.Width, uc.Height);

            //RenderTargetBitmap rtb = new RenderTargetBitmap((int)uc.Width, (int)uc.Height, 96, 96, PixelFormats.Pbgra32);

            //uc.Arrange(rect);
            //rtb.Render(uc);

            //PngBitmapEncoder png = new PngBitmapEncoder();
            //png.Frames.Add(BitmapFrame.Create(rtb));
            //var stream = File.Create(@"C:\Users\Maciek\source\repos\BochenekApp\order.bmp");
            //png.Save(stream);

        }
    }
}
