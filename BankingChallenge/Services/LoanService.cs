using System;
using BankingChallenge.Models;
using BankingChallenge.Repositories.Interfaces;
using BankingChallenge.Services.Interfaces;

namespace BankingChallenge.Services
{
    public class LoanService: ILoanService
    {
        private readonly IHistoryRepository _historyRepository;

        public LoanService(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        // https://www.kasasa.com/blog/how-to-calculate-loan-payments-in-3-easy-steps
        // Loan Payment (P) = Amount (A) / Discount Factor (D)
        // A = Total loan amount
        // D = {[(1 + r)n] - 1} / [r(1 + r)n]
        private double CalculateInstallment(double amount, int duration, Term term)
        {
            var rate = GetPeriodicInterestRate(term.Interest, 12);
            var factor = GetDiscountFactor(rate, duration);

            return amount / factor;
        }

        private double CalculateAdministrationFee(Term term, double amount)
        {
            var fee = amount * (term.AdministrationFeePercent / 100);

            if (fee > term.MaxAdministrationFee)
            {
                fee = term.MaxAdministrationFee;
            }

            return fee;
        }

        private double CalculateTotalPaidInterest(double totalPaid, double loanAmount)
        {
            return totalPaid - loanAmount;
        }

        public PaymentOverview CreateOverview(double amount, int duration, Term term)
        {
            var overview = new PaymentOverview(term)
            {
                LoanAmount = amount,
                LoanDuration = duration
            };

            overview.Installment = CalculateInstallment(overview.LoanAmount, overview.LoanDuration, term);
            overview.TotalPaidAmount = CalculateTotalAmount(overview.Installment, overview.LoanDuration);
            overview.AdministrationFee = CalculateAdministrationFee(term, overview.LoanAmount);
            overview.TotalPaidInterest = CalculateTotalPaidInterest(overview.TotalPaidAmount, overview.LoanAmount);

            _historyRepository.Insert(overview);

            return overview;
        }

        private double CalculateTotalAmount(double installment, double payments)
        {
            return installment * payments;
        }

        private double CalculateAPR(PaymentOverview overview)
        {
            //todo how to calculate APR? 
            return 0;
        }


        // r in formula
        private double GetPeriodicInterestRate(double interest, double payments)
        {
            return (interest / 100) / payments;
        }

        private double GetDiscountFactor(double periodicInterestRate, int totalPayments)
        {
            // {[(1 + r)n] - 1}
            var left = Math.Pow((1 + periodicInterestRate), totalPayments) - 1;

            // [r(1 + r)n]
            var right = periodicInterestRate * Math.Pow((1 + periodicInterestRate), totalPayments);

            return left / right;
        }
    }
}