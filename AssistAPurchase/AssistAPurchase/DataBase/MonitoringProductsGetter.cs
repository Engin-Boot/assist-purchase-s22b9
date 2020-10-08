using System.Collections.Generic;
using AssistAPurchase.Models;
using System;
namespace AssistAPurchase.DataBase
{
    public class MonitoringProductsGetter
    {
        public List<MonitoringItems> Products { get; set; }

        public MonitoringProductsGetter() {

            this.getAllItems();
            Console.WriteLine(Products.Count);

        }
        private void getAllItems()
        {
            List<MonitoringItems> monitoringItems = new List<MonitoringItems>();
            monitoringItems.Add(new MonitoringItems { ProductNumber = "X3",ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MX40", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MX750", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MP2", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MP5", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MX450", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MX700", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MMSX2", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MX500", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MP90", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MX550", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MX400", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MX800", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MP5T", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "MX100", ProductName = "IntelliVue" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "CM", ProductName= "Efficia" });
            monitoringItems.Add(new MonitoringItems { ProductNumber = "G40E", ProductName = "Goldway" });
            this.Products = monitoringItems;
        }
    }
}
