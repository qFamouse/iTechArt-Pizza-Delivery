using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Configurations
{
    public class ResourceConfiguration
    {
        /// <summary>
        /// Returns path to the application resources
        /// </summary>
        public string ResourcePath { get; set; }
        /// <summary>
        /// Returns the name of the resource folder
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Returns the name of the folder for pizza images
        /// </summary>
        public string PizzaImageName { get; set; }

        /// <summary>
        /// Returns limit of size for images
        /// </summary>
        public long ImageSizeLimit { get; set; }

        /// <summary>
        /// Return string array with allowed image extensions
        /// </summary>
        public string[] AllowedImageContentTypes { get; set; }

    }
}
