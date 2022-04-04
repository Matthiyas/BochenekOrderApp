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
        public string typeIndex;
        public string number;
        public string clientName;
        public string wid;
        public string heig;
        public string color;
        public int colorIndex;
        public string trapeze;
        public string trapezeIndex;
        public string trapeType;
        public string trapeTypeIndex;
        public string notes;
        public string TypesCombo { get; set; }
        public string TypesIndex { get; set; }

        public string ColorsCombo { get; set; }
        public int ColorsIndex { get; set; }

        public string TrapezesCombo { get; set; }
        public string TrapezesIndex { get; set; }

        public string TrapeTypesCombo { get; set; }
        public string TrapeTypesIndex { get; set; }

        public DataModel()
        {
            state = false;
            type = "";
            typeIndex = "-1";
            number = "";
            clientName = "";
            wid = "";
            heig = "";
            color = "";
            colorIndex = -1;
            trapeze = "";
            trapezeIndex = "-1";
            notes = "";
        }

        public static DataModel ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(DataModel));
            StreamReader file = new StreamReader(@"./Files/TemporaryDataModel.xml");
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
            StreamWriter wfile = new StreamWriter(@"./Files/TemporaryDataModel.xml");
            writer.Serialize(wfile, emptyData);
            wfile.Close();
        }

    }
}
