using AssistAPurchase.Models;
using System.Collections.Generic;


namespace AssistAPurchase.Repository
{
    public class AlertRepository : IAlertRepository
    {
        private static List<AlertModel> alerts;

        public AlertRepository() {

            alerts = new List<AlertModel>();
        }
        public void Add(AlertModel alert) {

            alerts.Add(alert);
        }
        public AlertModel FindByCustomerName(string customerName) {

            for (int i = 0; i < alerts.Count; i++)
            {
                if (customerName == alerts[i].CustomerName)
                    return alerts[i];
            }
            return null;
        }
    }
}
