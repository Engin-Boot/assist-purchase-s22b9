using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AssistAPurchase.Models
{
    public class Mailer 
    {
        public IEnumerable<string> ProductNameList { get; set; }
        public string CustomerEmailId { get; set; }
    }
}
