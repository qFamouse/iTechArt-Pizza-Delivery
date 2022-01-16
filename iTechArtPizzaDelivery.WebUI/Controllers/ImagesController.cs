using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Configurations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ResourceConfiguration config;

        public ImagesController(IWebHostEnvironment webHostEnvironment, IOptions<ResourceConfiguration> config)
        {
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            this.config = config.Value ?? throw new ArgumentNullException(nameof(config));
        }


        public class File
        {
            public int Id { get; set; }
            public string Catalog { get; set; }
        }

        public class Image
        {
            public int Id { get; set; }
            public int FileId { get; set; }
            public string Filename { get; set; }
        }

        [HttpPost]
        public async Task<ActionResult> LoadImageAsync(IFormFile file)
        {
            var image = System.IO.File.OpenRead("C:\\Users\\Famouse\\Desktop\\5mb.jpg");
            return File(image, "image/png");

            //return new FileStreamResult(image, "image/jpeg");

            //await using (var image = System.IO.File.OpenRead("C:\\Users\\Famouse\\Desktop\\popa.jpg"))
            //{
            //}

            var time = new DateTime(637779414119051580);

            var ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                  "\\iTechArtPizzaDelivery";

            string ImageFolder = "\\Images\\";


            var projhectpath = Directory.CreateDirectory(config.ApplicationDataPath);

            //var imgs = projhectpath.CreateSubdirectory(config./*ImageName*/);



            //string path = $"{imgs}\\{file.FileName}";


            //string ImageDirectory = ApplicationData + ImageFolder;

            //if (!Directory.Exists(ImageDirectory))
            //{
            //    Directory.CreateDirectory(ImageDirectory);
            //}
            //string path = ApplicationData + ImageDirectory + file.FileName;


            //var fileStream = new FileStream(path, FileMode.Create);
            //await file.CopyToAsync(fileStream);

        }
    }
}
