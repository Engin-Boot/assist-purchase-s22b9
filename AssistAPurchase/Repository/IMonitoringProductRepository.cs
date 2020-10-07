using AssistAPurchase.Models;
using System.Collections.Generic;


namespace AssistAPurchase.Repository
{
    public interface IMonitoringProductRepository
    {
        void Add(MonitoringItems monitoringItems);
        IEnumerable<MonitoringItems> GetAll();
        MonitoringItems Find(string productNumber);
        MonitoringItems Remove(string productNumber);
        string Update(MonitoringItems monitoringItems);
    }
}
