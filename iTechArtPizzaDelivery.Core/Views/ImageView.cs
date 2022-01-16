using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Views
{
    public class ImageView
    {
        public FileStream Image { get; set; }
        public string ContentType { get; set; }
    }
}
