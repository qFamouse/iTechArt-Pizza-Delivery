﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Domain.Requests.Payment
{
    public class PaymentAddRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
