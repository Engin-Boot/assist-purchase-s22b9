using System.Collections.Generic;
using AssistAPurchase.DataBase;
using AssistAPurchase.Models;

namespace AssistAPurchase.Repository
{
    public class MonitoringProductRepository : IMonitoringProductRepository
    {
        public List<MonitoringItems> monitoringItems = new List<MonitoringItems>();

        public MonitoringProductRepository()
        {
            var products = new MonitoringProductsGetter().Products;
            for (var index = 0; index < products.Count; index++)
                Add(products[index]);
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
            for (var i = 0; i < monitoringItems.Count; i++)
                if (monitoringItems[i].ProductNumber == productNumber)
                    return monitoringItems[i];
            return null;
        }

        public MonitoringItems Remove(string productNumber)
        {
            for (var i = 0; i < monitoringItems.Count; i++)
                if (monitoringItems[i].ProductNumber == productNumber)
                {
                    var currentProduct = new MonitoringItems();
                    currentProduct = monitoringItems[i];
                    monitoringItems.RemoveAt(i);
                    return currentProduct;
                }

            return null;
        }

        public string Update(MonitoringItems product)
        {
            var currentProductNumber = product.ProductNumber;
            var message = "";
            for (var i = 0; i < monitoringItems.Count; i++)
                if (monitoringItems[i].ProductNumber == currentProductNumber)
                {
                    monitoringItems.RemoveAt(i);
                    monitoringItems.Add(product);
                    message = "Updated Sucessfully";
                    return message;
                }

            message = "No Items Matches!!";
            return message;
        }
    }
}