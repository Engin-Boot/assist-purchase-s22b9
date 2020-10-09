using AssistAPurchase.Models;
using AssistAPurchase.Repository;
using System.Collections.Generic;

namespace AssistAPurchaseWebApiTest
{
    class MonitoringProductTestRepository:IMonitoringProductRepository
    {
        private readonly List<MonitoringItems> monitoringItems = new List<MonitoringItems>();

        public MonitoringProductTestRepository()
        {
            Add(new MonitoringItems { ProductNumber = "X3", ProductName = "IntelliVue" });
            Add(new MonitoringItems { ProductNumber = "MX40", ProductName = "IntelliVue" });
            Add(new MonitoringItems { ProductNumber = "MX750", ProductName = "IntelliVue" });
            Add(new MonitoringItems { ProductNumber = "MP2", ProductName = "IntelliVue" });
            Add(new MonitoringItems { ProductNumber = "CM", ProductName = "Efficia" });
            Add(new MonitoringItems { ProductNumber = "G40E", ProductName = "Goldway" });
        }

        public IEnumerable<MonitoringItems> GetAll()
        {
            return monitoringItems;
        }

        public void Add(MonitoringItems product)
        {
            monitoringItems.Add(product);
        }

        public MonitoringItems Find(string productNumber)
        {
            foreach (MonitoringItems item in monitoringItems)
            {
                if (item.ProductNumber == productNumber)
                    return item;
            }
            /*
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].ProductNumber == productNumber)
                    return monitoringItems[i];
            }*/
            return null;
        }

        public MonitoringItems Remove(string productNumber)
        {
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].ProductNumber == productNumber)
                {
                    MonitoringItems currentProduct = new MonitoringItems();
                    currentProduct = monitoringItems[i];
                    monitoringItems.RemoveAt(i);
                    return currentProduct;
                }
            }
            return null;
        }

        public string Update(MonitoringItems product)
        {
            string currentProductNumber = product.ProductNumber;
            string message = "";
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].ProductNumber == currentProductNumber)
                {
                    monitoringItems.RemoveAt(i);
                    monitoringItems.Add(product);
                    message = "Updated Sucessfully";
                    return message;
                }
            }
            message = "No Items Matches!!";
            return message;
        }
    }
}
