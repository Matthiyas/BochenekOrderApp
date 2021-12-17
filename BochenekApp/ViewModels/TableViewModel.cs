using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using BochenekApp.Models;
using BochenekApp.Views;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Markup;
using System.Windows;
using System.Drawing;

namespace BochenekApp.ViewModels
{
    public class TableViewModel : TableView
    {
        private int _counter = DataModel.ReadXML().counter;
        private string _type = DataModel.ReadXML().type;
        private string _number = DataModel.ReadXML().number;
        private string _clientName = DataModel.ReadXML().clientName;
        private string _wid = DataModel.ReadXML().wid;
        private string _heig = DataModel.ReadXML().heig;
        private string _color = DataModel.ReadXML().color;
        private string _notes = DataModel.ReadXML().notes;
        private int _recH = 0;
        private int _recW = 0;
        


        public TableViewModel(bool isSaving=false)
        {

            if (isSaving == true)
            {
                
                UserControl uc = GetImage();
                
                Rect rect = new Rect(20, 20, uc.Width, uc.Height);

                RenderTargetBitmap rtb = new RenderTargetBitmap(3508, 2480, 240, 220, PixelFormats.Pbgra32);

                uc.Arrange(rect);
                rtb.Render(uc);

                PngBitmapEncoder png = new PngBitmapEncoder();
                png.Frames.Add(BitmapFrame.Create(rtb));

                string path = @"../../Zlecenia/zlecenie"+_counter+".png";
                var stream = File.Create(path);

                png.Save(stream);
                stream.Close();

            }        
        }

        public string Counter
        {
            get { return " Numer: "+_counter.ToString(); }
            set { _counter = Int32.Parse(value); }
        }

        public string Today
        {
            get { return DateTime.Today.ToString("dddd ")+ DateTime.Today.ToString("d"); }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Number
        {
            get { return _number+" szt."; }
            set { _number = value; }
        }
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }
        public string Wid
        {
            get { return _wid; }
            set { _wid = value; }
        }
        public string Heig
        {
            get { return _heig; }
            set { _heig = value; }
        }
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
        public int RecH
        {
            get
            {
                if (_type == "Brama uchylna") return 270;
                else if (_type == "Drzwi stalowe") return 350;
                else return _recW;
            }
            set { _recH = value; }
        }
        public int RecW
        {
            get 
            {
                if (_type == "Brama uchylna") return 450;
                else if (_type == "Drzwi stalowe") return 200;
                else return _recH;
            }
            set { _recW = value; }
        }
    }
}
