using BankingChallenge.Models;
using EasyConsoleCore;

namespace BankingChallenge.Services.Pages
{
    public class DefaultTermsOptionPage : MenuPage
    {
        public DefaultTermsOptionPage(EasyConsoleCore.Program program, Term defaultTerm) : base("Calculate loan payments", program, new[]
        {
            new Option("No", () => program.NavigateTo<CalculateLoanPage>()),
            new Option("Yes", () => program.NavigateTo<ChangeTermsPage>()),
        })
        {
            _defaultTerm = defaultTerm;
        }

        private readonly Term _defaultTerm;

        public override void Display()
        {
            Output.WriteLine("===============================");
            Output.WriteLine("Loan calculation default terms:");
            Output.WriteLine("===============================");
            Output.WriteLine(string.Empty);
            Output.WriteLine($"Annual Interest rate: {_defaultTerm.Interest}%");
            Output.WriteLine($"Administration fee: {_defaultTerm.AdministrationFeePercent}%");
            Output.WriteLine($"Highest administration fee: {_defaultTerm.MaxAdministrationFee} kr.");
            Output.WriteLine(string.Empty);
            Output.WriteLine(string.Empty);
            Output.WriteLine("Do you want to change default terms?");
            Output.WriteLine(string.Empty);

            base.Display();
        }
    }
}
