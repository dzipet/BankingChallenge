using BankingChallenge.Models;

namespace BankingChallenge.Services.Interfaces
{
    public interface ILoanService
    {
        PaymentOverview CreateOverview(double amount, int duration, Term term);
    }
}