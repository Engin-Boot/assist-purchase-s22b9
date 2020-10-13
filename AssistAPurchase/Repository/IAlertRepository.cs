using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistAPurchase.Models;
namespace AssistAPurchase.Repository
{
    public interface IAlertRepository
    {
        void Add(AlertModel alert);
        AlertModel FindByCustomerName(string customerName);
    }
}
