using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface ISizesService
    {
        public List<Size> GetAll();
        public Size GetById(int id);
        public Size Add(Size size);
    }
}
