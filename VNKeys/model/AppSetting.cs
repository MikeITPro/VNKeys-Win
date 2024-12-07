using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNKeys.model
{
    [Serializable]
    internal class AppSetting
    {
        public bool minToTray { get; set; }
        public string typingMode { get; set; }
        public bool confirmOnExit { get; set; }
        
    }
}
