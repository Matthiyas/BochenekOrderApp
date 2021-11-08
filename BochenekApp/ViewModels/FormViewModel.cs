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
        
        public void SaveClientName(string title)
        {
            temp.title = title;
        }
        public void SaveNumber(string number)
        {
            temp.number = number;
        }

        public string ClientName
        {
            get { return ReadXML().title; }
            set 
            {
                SaveClientName(value);
                SaveXML();
                NotifyOfPropertyChange(() => ClientName);
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
    }
}
