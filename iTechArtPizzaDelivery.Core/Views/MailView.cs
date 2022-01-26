using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Views
{
    public class MailView
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
        public List<string> To { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(new
            {
                subject = Subject,
                test = Text,
                html = Html,
                to = To
            });
        }
    }
}
