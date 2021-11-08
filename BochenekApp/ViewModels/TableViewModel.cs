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

        private string _clientName = ReadXML().title;
        private string _number = ReadXML().number;

        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }
    }


}
