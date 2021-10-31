using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface ISizeRepository
    {
        public List<Size> GetAll();
        public Size GetById(int id);
        public bool Add(Size size);
    }
}
