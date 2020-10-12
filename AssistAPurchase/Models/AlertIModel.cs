using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistAPurchase.Models
{
    public class AlertModel
    {
        public string CustomerName { get; set; }
        public string CustonmerMailId { get; set; }
        public string ItemPurchased { get; set; }
        public string CustomerphoneNumber { get; set; }
        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
