using AssistAPurchase.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
