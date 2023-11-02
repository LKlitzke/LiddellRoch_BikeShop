using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Utility
{
    public class StripeSettings
    {
        public string SecretKey { get; set; }
        public string PublishableKey { get; set; }
    }

    public class MailJetSettings
    {
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
    }
}
