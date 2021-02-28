using System;
using BankingChallenge.Models;
using EasyConsoleCore;

namespace BankingChallenge.Services.Pages
{
    public static class Printer
    {
        public static void Print(PaymentOverview overview)
        {
            Output.WriteLine($"Loan amount: {overview.LoanAmount} kr.");
            Output.WriteLine($"Loan duration: {overview.LoanDuration} months");
            Output.WriteLine($"Monthly payment: {Math.Round(overview.Installment, 2)} kr.");
            Output.WriteLine($"Total paid amount (without administrative fee): {Math.Round(overview.TotalPaidAmount, 2)} kr.");
            Output.WriteLine($"Total paid interest: {Math.Round(overview.TotalPaidInterest, 2)} kr.");

            Output.WriteLine($"Administrative fee (one time): {Math.Round(overview.AdministrationFee, 2)} kr.");
        }
    }
}
