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

        private string _type = DataModel.ReadXML().type;
        private string _number = DataModel.ReadXML().number;
        private string _clientName = DataModel.ReadXML().clientName;
        private string _width = DataModel.ReadXML().width;
        private string _height = DataModel.ReadXML().height;
        private string _color = DataModel.ReadXML().color;
        private string _notes = DataModel.ReadXML().notes;
   
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
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
    }


}
