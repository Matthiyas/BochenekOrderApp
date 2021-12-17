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
        private BindableCollection<DataModel> _types = new BindableCollection<DataModel>();
        private DataModel _selectedType;

        public FormViewModel()
        {
            Types.Add(new DataModel { TypesIndex = 0, TypesCombo = "Drzwi stalowe" });
            Types.Add(new DataModel { TypesIndex = 1, TypesCombo = "Brama uchylna" });
            Types.Add(new DataModel { TypesIndex = 2, TypesCombo = "Brama dwuskrzydłowa" });
        }

        public void checkState()
        {
            if (!DataModel.ReadXML().state)
            { 
                temp = DataModel.ReadXML();
                temp.state = true;
            }
        }

        public BindableCollection<DataModel> Types
        {
            get { return _types; }
            set 
            { 
                _types = value;
            }
        }
        
        public DataModel SelectedType
        {
            get { return _selectedType; }
            set 
            {
                _selectedType = value;
                NotifyOfPropertyChange(() => SelectedType);
                checkState();
                temp.type = value.TypesCombo;
                SaveXML();
                temp = DataModel.ReadXML();
                
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
            set {}
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
        public string Wid
        {
            get { return DataModel.ReadXML().wid; }
            set
            {
                checkState();
                temp.wid = value;
                SaveXML();
                temp = DataModel.ReadXML();
                NotifyOfPropertyChange(() => Wid);
            }
        }
        public string Heig
        {
            get { return DataModel.ReadXML().heig; }
            set
            {
                checkState();
                temp.heig = value;
                SaveXML();
                temp = DataModel.ReadXML();
                NotifyOfPropertyChange(() => Heig);
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
