using BankingChallenge.Models;
using BankingChallenge.Repositories.Interfaces;
using BankingChallenge.Services.Interfaces;
using BankingChallenge.Services.Pages;

namespace BankingChallenge.Services
{
    public class ConsoleService: EasyConsoleCore.Program, IConsoleService
    {
        public ConsoleService(ILoanService loanService, IHistoryRepository historyRepository) : base("EasyConsole Demo", breadcrumbHeader: true)
        {
            _loanService = loanService;
            _historyRepository = historyRepository;
            _defaultTerms = new Term
            {
                AdministrationFeePercent = 1,
                Interest = 5,
                MaxAdministrationFee = 10000
            };

            _effectiveTerm = new Term();
        }

        private readonly ILoanService _loanService;
        private readonly IHistoryRepository _historyRepository;

        private readonly Term _defaultTerms;
        private readonly Term _effectiveTerm;

        public void Init()
        {
            var welcome = new WelcomePage(this, _defaultTerms, _effectiveTerm);
            var optionToChangeTerms = new DefaultTermsOptionPage(this, _defaultTerms);
            var changeTerms = new ChangeTermsPage(this, _effectiveTerm);
            var calculateLoan = new CalculateLoanPage(this, _effectiveTerm, _loanService);
            var about = new AboutPage(this);
            var history = new HistoryPage(this, _historyRepository);

            AddPage(welcome);
            AddPage(optionToChangeTerms);
            AddPage(changeTerms);
            AddPage(calculateLoan);
            AddPage(about);
            AddPage(history);

            SetPage<WelcomePage>();

            welcome.Display();
        }
    }
}