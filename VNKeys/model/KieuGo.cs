using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNKeys.model
{
    [Serializable]
    internal class KieuGo
    {
        private string _name;
        private string _mapString;

        // Properties 
        public string name { get { return this.getName(); } set { this.setName(value); } }
        // Setter & Getter 
        public string getName()
        {
            return this._name;
        }
        public void setName(string name)
        {
            this._name = name;
        }

        // Properties 
        public string mapString { get { return this.getMapString(); } set { this.setMapString(value); } }
        // Setter & Getter 
        public string getMapString()
        {
            return this._mapString;
        }
        public void setMapString(string mapString)
        {
            this._mapString = mapString;
        }

    }
}
