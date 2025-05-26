using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Models
{
    class clsImages
    {
        public string ImageName { get; set; }
        public string ImageType { get; set; }
        public Image Image { get; set; }
        public object MemberImage { get; internal set; }
    }
}
