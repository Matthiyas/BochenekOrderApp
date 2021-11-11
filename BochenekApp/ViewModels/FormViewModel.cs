using BochenekApp.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BochenekApp.ViewModels
{
    class FormViewModel : Conductor<object>
    {
        private static DataModel temp = ReadXML();
        public static DataModel ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(DataModel));
            System.IO.StreamReader file = new System.IO.StreamReader(@"../../Models/TemporaryDataModel.xml");
            DataModel overview = (DataModel)reader.Deserialize(file);
            file.Close();

            return overview;
        }
        public void SaveXML()
        { 
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(DataModel));
            StreamWriter wfile = new System.IO.StreamWriter(@"../../Models/TemporaryDataModel.xml");
            writer.Serialize(wfile, temp);
            wfile.Close();
        }
        public void SaveType(string type)
        {
            temp.type = type;
        }
        public void SaveNumber(string number)
        {
            temp.number = number;
        }
        public void SaveClientName(string clientName)
        {
            temp.clientName = clientName;
        }
        public void SaveWidth(string width)
        {
            temp.width = width;
        }
        public void SaveHeight(string height)
        {
            temp.height = height;
        }

        public string ClientName
        {
            get { return ReadXML().clientName; }
            set 
            {
                SaveClientName(value);
                SaveXML();
                NotifyOfPropertyChange(() => ClientName);
            }
        }
        public string Type
        {
            get { return ReadXML().type; }
            set
            {
                SaveType(value);
                SaveXML();
                NotifyOfPropertyChange(() => Type);
            }
        }
        public string Number
        {
            get { return ReadXML().number; }
            set
            {
                SaveNumber(value);
                SaveXML();
                NotifyOfPropertyChange(() => Number);
            }
        }
        public string Width
        {
            get { return ReadXML().width; }
            set
            {
                SaveWidth(value);
                SaveXML();
                NotifyOfPropertyChange(() => Width);
            }
        }
        public string Height
        {
            get { return ReadXML().height; }
            set
            {
                SaveHeight(value);
                SaveXML();
                NotifyOfPropertyChange(() => Height);
            }
        }
    }
}
