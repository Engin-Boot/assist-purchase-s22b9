using AssistAPurchase.Models;
using System.Collections.Generic;


namespace AssistAPurchase.Repository
{
    public class AlertRepository : IAlertRepository
    {
        private static List<AlertModel> _alerts;

        public AlertRepository() {

            _alerts = new List<AlertModel>();
        }
        public void Add(AlertModel alert) {

            _alerts.Add(alert);
        }
        public AlertModel FindByCustomerName(string customerName)
        {
            foreach (AlertModel alert in _alerts)
            {
                if (customerName == alert.CustomerName)
                    return alert;
            }
            return null;
        }
    }
}
