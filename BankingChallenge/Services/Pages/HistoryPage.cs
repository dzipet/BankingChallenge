using System.Linq;
using BankingChallenge.Repositories.Interfaces;
using EasyConsoleCore;

namespace BankingChallenge.Services.Pages
{
    public class HistoryPage : Page
    {
        public HistoryPage(EasyConsoleCore.Program program, IHistoryRepository historyRepository) : base("Calculations history", program)
        {
            _historyRepository = historyRepository;
        }

        private readonly IHistoryRepository _historyRepository;

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Press [enter] to return to main page");
            Output.WriteLine(string.Empty);
            Output.WriteLine(string.Empty);

            var loans = _historyRepository.GetAll();

            if (loans.Any())
            {
                Output.WriteLine("=========================");

                foreach (var loan in loans)
                {
                    Printer.Print(loan);
                    Output.WriteLine("=========================");
                }
            }
            else
            {
                Output.WriteLine("=========================");
                Output.WriteLine("You do not have any history :(");
                Output.WriteLine("=========================");
            }

            Output.WriteLine(string.Empty);
            Output.WriteLine(string.Empty);

            Input.ReadString("Press [enter] to return to main page!");

            Program.NavigateHome();
        }
    }
}
