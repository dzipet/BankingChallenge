using BankingChallenge.Models;
using EasyConsoleCore;

namespace BankingChallenge.Services.Pages
{
    public class ChangeTermsPage : Page
    {
        public ChangeTermsPage(EasyConsoleCore.Program program, Term effectiveTerm) : base("Calculate loan payments", program)
        {
            _effectiveTerm = effectiveTerm;
        }

        private readonly Term _effectiveTerm;

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Please enter new terms:");
            _effectiveTerm.Interest = Input.ReadInt($"Annual Interest rate (between 1 and 100):", 1, 100);
            _effectiveTerm.AdministrationFeePercent = Input.ReadInt($"Administration fee percent (between 1 and 100):", 1, 100);
            _effectiveTerm.MaxAdministrationFee = Input.ReadInt($"Highest administration fee (between 1 and 1 million):", 1, 1000000);
            Output.WriteLine(string.Empty);
            Output.WriteLine(string.Empty);

            Program.NavigateTo<CalculateLoanPage>();
        }
    }
}
