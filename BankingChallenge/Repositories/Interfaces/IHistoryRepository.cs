using System.Collections.Generic;
using System.Diagnostics;
using BankingChallenge.Models;

namespace BankingChallenge.Repositories.Interfaces
{
    public interface IHistoryRepository
    {
        List<PaymentOverview> GetAll();
        void Insert(PaymentOverview overview);
    }
}
