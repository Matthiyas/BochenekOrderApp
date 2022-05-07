using BochenekApp.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace BochenekApp.ViewModels
{
    class FormViewModel : Conductor<object>
    {
        
        private static DataModel temp = DataModel.ReadXML();


        //lists of types and colors
        private BindableCollection<DataModel> _types = new BindableCollection<DataModel>();
        private DataModel _selectedType;

        private BindableCollection<DataModel> _colors = new BindableCollection<DataModel>();
        private DataModel _selectedColor;

        private BindableCollection<DataModel> _trapezes = new BindableCollection<DataModel>();
        private DataModel _selectedTrapeze;

        private BindableCollection<DataModel> _trapeTypes = new BindableCollection<DataModel>();
        private DataModel _selectedTrapeType;

        public FormViewModel()
        {
            Types.Add(new DataModel { TypesIndex = "0", TypesCombo = "Drzwi stalowe" });
            Types.Add(new DataModel { TypesIndex = "1", TypesCombo = "Brama uchylna" });
            Types.Add(new DataModel { TypesIndex = "2", TypesCombo = "Brama dwuskrzydłowa" });

            Colors.Add(new DataModel { ColorsIndex = 0, ColorsCombo = "Orzech" });
            Colors.Add(new DataModel { ColorsIndex = 1, ColorsCombo = "Złoty dąb" });
            Colors.Add(new DataModel { ColorsIndex = 2, ColorsCombo = "Multigloss" });
            Colors.Add(new DataModel { ColorsIndex = 3, ColorsCombo = "Winchester" });
            Colors.Add(new DataModel { ColorsIndex = 4, ColorsCombo = "Ciemny dąb" });

            Colors.Add(new DataModel { ColorsIndex = 5, ColorsCombo = "RAL 7016 połysk(grafit)" });
            Colors.Add(new DataModel { ColorsIndex = 6, ColorsCombo = "RAL 7016 mat(antracyt)" });
            Colors.Add(new DataModel { ColorsIndex = 7, ColorsCombo = "RAL 7024 mat(jasny grafit)" });
            Colors.Add(new DataModel { ColorsIndex = 8, ColorsCombo = "RAL 8017 połysk(brąz)" });
            Colors.Add(new DataModel { ColorsIndex = 9, ColorsCombo = "RAL 8017 mat(brąz)" });
            Colors.Add(new DataModel { ColorsIndex = 10, ColorsCombo = "RAL 8019 mat(ciemny brąz)" });
            Colors.Add(new DataModel { ColorsIndex = 11, ColorsCombo = "RAL 9005 mat" });
            Colors.Add(new DataModel { ColorsIndex = 12, ColorsCombo = "RAL 9005 połysk" });
            Colors.Add(new DataModel { ColorsIndex = 13, ColorsCombo = "RAL 6020 mat" });
            Colors.Add(new DataModel { ColorsIndex = 14, ColorsCombo = "RAL 6020 połysk" });
            Colors.Add(new DataModel { ColorsIndex = 15, ColorsCombo = "RAL 6005 połysk(zielony jasny)" });
            Colors.Add(new DataModel { ColorsIndex = 16, ColorsCombo = "RAL 6005 mat(zielony jasny)" });
            Colors.Add(new DataModel { ColorsIndex = 17, ColorsCombo = "RAL 3009 połysk(wiśniowy)" });
            Colors.Add(new DataModel { ColorsIndex = 18, ColorsCombo = "RAL 3009 mat(wiśniowy)" });
            Colors.Add(new DataModel { ColorsIndex = 19, ColorsCombo = "RAL 3011 połysk(czerwony)" });
            Colors.Add(new DataModel { ColorsIndex = 20, ColorsCombo = "RAL 3011 mat(czerwony)" });
            Colors.Add(new DataModel { ColorsIndex = 21, ColorsCombo = "RAL 3005 połysk(burgund)"});
            Colors.Add(new DataModel { ColorsIndex = 22, ColorsCombo = "RAL 3005 mat(burgund)"});
            Colors.Add(new DataModel { ColorsIndex = 23, ColorsCombo = "RAL 8004 mat(ceglasty)"});
            Colors.Add(new DataModel { ColorsIndex = 24, ColorsCombo = "RAL 8004 połysk (ceglasty)"});
            Colors.Add(new DataModel { ColorsIndex = 25, ColorsCombo = "RAL 9010 połysk(biały)"});
            Colors.Add(new DataModel { ColorsIndex = 26, ColorsCombo = "RAL 9006 połysk(srebrny)"});
            Colors.Add(new DataModel { ColorsIndex = 27, ColorsCombo = "RAL 1002 połysk(piaskowy)"});
            Colors.Add(new DataModel { ColorsIndex = 28, ColorsCombo = "RAL 1021 połysk(żółty)"});
            Colors.Add(new DataModel { ColorsIndex = 29, ColorsCombo = "RAL 5010 połysk(niebieski)"});
            Colors.Add(new DataModel { ColorsIndex = 30, ColorsCombo = "Ocynk"});

            Trapezes.Add(new DataModel { TrapezesIndex = "0", TrapezesCombo = "R-8" });
            Trapezes.Add(new DataModel { TrapezesIndex = "1", TrapezesCombo = "R-13" });
            
            TrapeTypes.Add(new DataModel { TrapeTypesIndex = "0", TrapeTypesCombo = "Pionowy" });
            TrapeTypes.Add(new DataModel { TrapeTypesIndex = "1", TrapeTypesCombo = "Poziomy" });
        }
        
        public void SaveXML()
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(DataModel));
            StreamWriter wfile = new System.IO.StreamWriter(@"./Files/TemporaryDataModel.xml");
            writer.Serialize(wfile, temp);
            wfile.Close();
        }

        public void checkState()
        {
            if (!DataModel.ReadXML().state)
            { 
                temp = DataModel.ReadXML();
                temp.number = 1;
                temp.state = true;
            }
        }

        private string opt="";
        public void addOption()
        {
            if (opt == "") return;
            if (opt!="")
            {
                checkState();
                if (temp.options != "")
                {
                    temp.options += "*"+opt;
                }
                else
                {
                    temp.options = opt;
                }
                
                SaveXML();
                temp = DataModel.ReadXML();
                opt = "";
                Refresh();
            }
        }
        public void clearOption()
        {
            if (temp.options.LastIndexOf("*") != -1)
            {
                temp.options = temp.options.Substring(0, temp.options.LastIndexOf("*"));
                SaveXML();
                temp = DataModel.ReadXML();
                Refresh();
            }
            else if (temp.options.LastIndexOf("*") == -1 && temp.options != "")
            {
                temp.options = "";
                SaveXML();
                temp = DataModel.ReadXML();
                Refresh();
            }
            else return;
        }

        //Combobox types
        public BindableCollection<DataModel> Types
        {
            get { return _types; }
            set 
            { 
                _types = value;
            }
        }
        public string CurrentType
        {
            get 
            { 
                return DataModel.ReadXML().typeIndex;
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
                temp.typeIndex = value.TypesIndex;
                temp.type = value.TypesCombo;
                SaveXML();
                temp = DataModel.ReadXML();
            }
        }

        //Combobox colors
        public BindableCollection<DataModel> Colors
        {
            get { return _colors; }
            set
            {
                _colors = value;
            }
        }
        public int CurrentColor
        {
            get
            {
                return DataModel.ReadXML().colorIndex;
            }
        }
        public DataModel SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                NotifyOfPropertyChange(() => SelectedColor);
                checkState();
                temp.colorIndex = value.ColorsIndex;
                temp.color = value.ColorsCombo;
                SaveXML();
                temp = DataModel.ReadXML();
            }
        }

        //combobox Trapezes
        public BindableCollection<DataModel> Trapezes
        {
            get { return _trapezes; }
            set
            {
                _trapezes = value;
            }
        }
        public string CurrentTrapeze
        {
            get
            {
                return DataModel.ReadXML().trapezeIndex;
            }
        }
        public DataModel SelectedTrapeze
        {
            get { return _selectedTrapeze; }
            set
            {
                _selectedTrapeze = value;
                NotifyOfPropertyChange(() => SelectedTrapeze);
                checkState();
                temp.trapezeIndex = value.TrapezesIndex;
                temp.trapeze = value.TrapezesCombo;
                SaveXML();
                temp = DataModel.ReadXML();
            }
        }

        //combobox trapetypes
        public BindableCollection<DataModel> TrapeTypes
        {
            get { return _trapeTypes; }
            set
            {
                _trapeTypes = value;
            }
        }
        public string CurrentTrapeType
        {
            get
            {
                return DataModel.ReadXML().trapeTypeIndex;
            }
        }
        public DataModel SelectedTrapeType
        {
            get { return _selectedTrapeType; }
            set
            {
                _selectedTrapeType = value;
                NotifyOfPropertyChange(() => SelectedTrapeType);
                checkState();
                temp.trapeTypeIndex = value.TrapeTypesIndex;
                temp.trapeType = value.TrapeTypesCombo;
                SaveXML();
                temp = DataModel.ReadXML();
            }
        }

        
        //Textblocks
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
        }

        public int Number
        {
            get { return DataModel.ReadXML().number; }
            set
            {
                value = Convert.ToInt32(value);
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
        public string Options
        {
            get 
            {
                return opt;
            }
            set
            {
                checkState();
                opt = value;
                NotifyOfPropertyChange(() => Options);
            }
        }
        public string OptionsShow
        {
            get 
            {
                string temp=DataModel.ReadXML().options;
                temp = temp.Replace('*', '\n');
                return temp;
            }
        }
    }
}
