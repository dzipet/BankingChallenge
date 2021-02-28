using BankingChallenge.Models;
using EasyConsoleCore;

namespace BankingChallenge.Services.Pages
{
    public class WelcomePage : MenuPage
    {
        public WelcomePage(EasyConsoleCore.Program program, Term defaultTerm, Term effectiveTerm) : base("Cloud Engineer Banking Challenge", program, new []
        {
            new Option("Calculate", () => program.NavigateTo<DefaultTermsOptionPage>()),
            new Option("Calculation history", () => program.NavigateTo<HistoryPage>()),
            new Option("About", () => program.NavigateTo<AboutPage>()),
        })
        {
            effectiveTerm.MaxAdministrationFee = defaultTerm.MaxAdministrationFee;
            effectiveTerm.AdministrationFeePercent = defaultTerm.AdministrationFeePercent;
            effectiveTerm.Interest = defaultTerm.Interest;
        }
    }
}
