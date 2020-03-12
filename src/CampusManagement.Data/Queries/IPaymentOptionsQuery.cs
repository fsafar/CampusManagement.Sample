using System.Collections.Generic;
using CampusManagement.Data.Models;

namespace CampusManagement.Data.Queries
{
    public interface IPaymentOptionsQuery
    {
        IList<PaymentOptionModel> Execute(int customerId);
    }
}
