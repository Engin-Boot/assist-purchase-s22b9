using AssistAPurchase.Models;
namespace AssistAPurchase.Repository
{
    public interface IAlertRepository
    {
        void Add(AlertModel alert);
        AlertModel FindByCustomerName(string customerName);
    }
}
