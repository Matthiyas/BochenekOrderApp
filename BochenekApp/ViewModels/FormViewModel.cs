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
        
        private static DataModel temp = DataModel.ReadXML();

        public void checkState()
        {
            if (!DataModel.ReadXML().state)
            { 
                temp = DataModel.ReadXML();
                temp.state = true;
            }
        }

        public void SaveXML()
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(DataModel));
            StreamWriter wfile = new System.IO.StreamWriter(@"../../Models/TemporaryDataModel.xml");
            writer.Serialize(wfile, temp);
            wfile.Close();
        }

        public string ClientName
        {
            get { return DataModel.ReadXML().clientName; }
            set 
            {
                checkState();
                temp.clientName = value;
                SaveXML();
                temp = DataModel.ReadXML();
                NotifyOfPropertyChange(() => ClientName);
            }
        }
        public string Type
        {
            get { return DataModel.ReadXML().type; }
            set
            {
                checkState();
                temp.type = value;
                SaveXML();
                temp = DataModel.ReadXML();
                NotifyOfPropertyChange(() => Type);
            }
        }
        public string Number
        {
            get { return DataModel.ReadXML().number; }
            set
            {
                checkState();
                temp.number = value;
                SaveXML();
                temp = DataModel.ReadXML();
                NotifyOfPropertyChange(() => Number);
            }
        }
        public string Width
        {
            get { return DataModel.ReadXML().width; }
            set
            {
                checkState();
                temp.width = value;
                SaveXML();
                temp = DataModel.ReadXML();
                NotifyOfPropertyChange(() => Width);
            }
        }
        public string Height
        {
            get { return DataModel.ReadXML().height; }
            set
            {
                checkState();
                temp.height = value;
                SaveXML();
                temp = DataModel.ReadXML();
                NotifyOfPropertyChange(() => Height);
            }
        }
        public string Color
        {
            get { return DataModel.ReadXML().color; }
            set
            {
                checkState();
                temp.color = value;
                SaveXML();
                temp = DataModel.ReadXML();
                NotifyOfPropertyChange(() => Color);
            }
        }
        public string Notes
        {
            get { return DataModel.ReadXML().notes; }
            set
            {
                checkState();
                temp.notes = value;
                SaveXML();
                temp = DataModel.ReadXML();
                NotifyOfPropertyChange(() => Notes);
            }
        }
    }
}
