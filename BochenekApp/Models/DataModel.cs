using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BochenekApp.Models
{
    public class DataModel
    {
        public bool state;
        public string type;
        public string number;
        public string clientName;
        public string width;
        public string height;
        public string color;
        public string notes;

        public DataModel()
        {
            state = false;
            type = "";
            number = "";
            clientName = "";
            width = "";
            height = "";
            color = "";
            notes = "";
        }

        public static DataModel ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(DataModel));
            System.IO.StreamReader file = new System.IO.StreamReader(@"../../Models/TemporaryDataModel.xml");
            DataModel overview = (DataModel)reader.Deserialize(file);
            file.Close();

            return overview;
        }
        public static void ClearData()
        {
            DataModel emptyData = new DataModel();
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(DataModel));
            StreamWriter wfile = new System.IO.StreamWriter(@"../../Models/TemporaryDataModel.xml");
            writer.Serialize(wfile, emptyData);
            wfile.Close();
        }
    }

}
