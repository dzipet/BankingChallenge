using BankingChallenge.Models;
using BankingChallenge.Services.Interfaces;
using EasyConsoleCore;

namespace BankingChallenge.Services.Pages
{
    public class CalculateLoanPage : Page
    {
        public CalculateLoanPage(EasyConsoleCore.Program program, Term effectiveTerm, ILoanService loanService) : base("Calculate loan payments", program)
        {
            _effectiveTerm = effectiveTerm;
            _loanService = loanService;
        }

        private readonly ILoanService _loanService;
        private readonly Term _effectiveTerm;

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Please enter your loan details:");

            var amount = Input.ReadDouble("Please enter your loan amount (between 1 and 10 billion)", 1, 10000000000);
            var duration = Input.ReadInt("Please enter your loan duration in months (between 1 and 1200)", 1, 1200);

            var overview = _loanService.CreateOverview(amount, duration, _effectiveTerm);

            Output.WriteLine("==================");
            Output.WriteLine("Your loan overview");
            Output.WriteLine("==================");
            Output.WriteLine(string.Empty);

            Printer.Print(overview);

            Output.WriteLine(string.Empty);
            Input.ReadString("Press [enter] to return to main page!");

            Program.NavigateHome();
        }
    }
}
