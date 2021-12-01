using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BochenekApp.Models
{
    public class DataModel
    {
        public bool state;
        public int counter;
        public string type;
        public string number;
        public string clientName;
        public string wid;
        public string heig;
        public string color;
        public string notes;

        public DataModel()
        {
            state = false;
            type = "";
            number = "";
            clientName = "";
            wid = "";
            heig = "";
            color = "";
            notes = "";
        }

        public static DataModel ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(DataModel));
            StreamReader file = new StreamReader(@"../../Models/TemporaryDataModel.xml");
            DataModel overview = (DataModel)reader.Deserialize(file);
            file.Close();

            return overview;
        }
        public static void ClearData(bool isNewOrder=false)
        {
            int c = ReadXML().counter;
            if (isNewOrder)
            {
                c += Int32.Parse(ReadXML().number);
            }    
            
            DataModel emptyData = new DataModel();
            emptyData.counter = c;
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(DataModel));
            StreamWriter wfile = new StreamWriter(@"../../Models/TemporaryDataModel.xml");
            writer.Serialize(wfile, emptyData);
            wfile.Close();
        }
    }
}
