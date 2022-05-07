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
        private int _number = DataModel.ReadXML().number;
        private string _clientName = DataModel.ReadXML().clientName;
        private string _wid = DataModel.ReadXML().wid;
        private string _heig = DataModel.ReadXML().heig;
        private string _color = DataModel.ReadXML().color;
        private string _trapeze = DataModel.ReadXML().trapeze;
        private string _trapeType = DataModel.ReadXML().trapeType;
        private string _notes = DataModel.ReadXML().notes;
        private string _options = DataModel.ReadXML().options;

        public TableViewModel(bool isSaving=false)
        {

            if (isSaving == true)
            {
                
                UserControl uc = GetImage();
                
                Rect rect = new Rect(20, 20, 1280, 1080);

                RenderTargetBitmap rtb = new RenderTargetBitmap(3300, 2280, 240, 220, PixelFormats.Pbgra32);

                uc.Arrange(rect);
                rtb.Render(uc);

                PngBitmapEncoder png = new PngBitmapEncoder();
                png.Frames.Add(BitmapFrame.Create(rtb));

                string path = @"./Zlecenia/zlecenie"+_counter+".png";
                var stream = File.Create(path);

                png.Save(stream);
                stream.Close();

            }        
        }

        public string Counter
        {
            get { return " Numer: "+_counter.ToString(); }
        }

        public string Today
        {
            get { return DateTime.Today.ToString("dddd ")+ DateTime.Today.ToString("d"); }
        }
        public string Type
        {
            get { return _type; }
        }
        public string Number
        {
            get { return _number+" szt."; }
        }
        public string ClientName
        {
            get { return _clientName; }
        }
        public string Wid
        {
            get { return _wid; }
        }
        public string Heig
        {
            get { return _heig; }
        }
        public string Color
        {
            get { return _color; }
        }
        public string Trapeze
        {
            get { return _trapeze; }
        }
        public string TrapeType
        {
            get { return _trapeType; }
        }
        public string Notes
        {
            get { return _notes; }
        }
        public string Options
        {
            get
            {
                string temp = _options;
                temp = temp.Replace("*", "\n-");
                if (temp == "") return temp;
                return "-" + temp;
            }
        }
        public int RecH
        {
            get
            {
                if (_type == "Brama uchylna") return 270;
                else if (_type == "Drzwi stalowe") return 350;
                else if (_type == "Brama dwuskrzydłowa") return 280;
                else return 0;
            }
        }
        public int RecW
        {
            get 
            {
                if (_type == "Brama uchylna") return 450;
                else if (_type == "Drzwi stalowe") return 200;
                else if (_type == "Brama dwuskrzydłowa") return 480;
                else return 0;
            }
        }
        public string RecFill
        {
            get
            {
                if (_trapeType == "Poziomy") return "Visible";
                else return "Hidden";
            }
        }
    }
}
