using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using BochenekApp.Models;

namespace BochenekApp.ViewModels
{
    public class TableViewModel
    {
        public static DataModel ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(DataModel));
            System.IO.StreamReader file = new System.IO.StreamReader(@"../../Models/TemporaryDataModel.xml");
            DataModel overview = (DataModel)reader.Deserialize(file);
            file.Close();

            return overview;
        }

        private string _type = ReadXML().type;
        private string _number = ReadXML().number;
        private string _clientName = ReadXML().clientName;
        private string _width = ReadXML().width;
        private string _height = ReadXML().height;
   
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
        public string Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public string Height
        {
            get { return _height; }
            set { _height = value; }
        }
    }


}
