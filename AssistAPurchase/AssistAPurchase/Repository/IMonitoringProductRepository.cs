using AssistAPurchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistAPurchase.Repository
{
    public interface IMonitoringProductRepository
    {
        void Add(MonitoringItems monitoringProducts);
        IEnumerable<MonitoringItems> GetAll();
        MonitoringItems Find(int productNumber);
        MonitoringItems Remove(int productNumber);
        void Update(MonitoringItems monitoringItems);
    }
}
