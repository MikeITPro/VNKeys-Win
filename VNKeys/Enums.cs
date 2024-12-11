using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNKeys
{
    internal enum AccentType
    {
        SAC, //  ' á
        HUYEN, // ` à 
        HOI, // ? ả
        NGA, // ~ ã
        NANG, // . ạ
        MU, // ^ â
        MOC, // * ơ
        TRANG, // ( ă
        NGANG,  // - đ
        NONE,
    }    

    internal enum KieuGoType
    {
        AUTO,
        TELEX,
        VIQR,
        VNI,
        USER,        
    }
}
