﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Requests.Pizza
{
    public class PizzaUpdateRequest
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}