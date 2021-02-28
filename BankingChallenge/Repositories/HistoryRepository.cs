using System.Collections.Generic;
using BankingChallenge.Models;
using BankingChallenge.Repositories.Interfaces;

namespace BankingChallenge.Repositories
{
    public class HistoryRepository: IHistoryRepository
    {
        private readonly List<PaymentOverview> _data;

        public HistoryRepository()
        {
            _data = new List<PaymentOverview>();
        }

        public List<PaymentOverview> GetAll()
        {
            return _data;
        }

        public void Insert(PaymentOverview overview)
        {
            _data.Add(overview);
        }
    }
}
