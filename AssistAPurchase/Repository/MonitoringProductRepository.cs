using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using AssistAPurchase.Models;
using AssistAPurchase.DataBase;

namespace AssistAPurchase.Repository
{
    public class MonitoringProductRepository : IMonitoringProductRepository
    {
        private static List<MonitoringItems> monitoringItems = new List<MonitoringItems>();

        public MonitoringProductRepository()
        {
            List<MonitoringItems> products = new MonitoringProductsGetter().Products;
            for (int index = 0; index < products.Count; index++)
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
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].ProductNumber == productNumber)
                    return monitoringItems[i];
            }
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
