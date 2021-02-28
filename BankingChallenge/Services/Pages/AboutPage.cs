using System;
using System.Linq;
using BankingChallenge.Repositories.Interfaces;
using EasyConsoleCore;

namespace BankingChallenge.Services.Pages
{
    public class AboutPage : Page
    {
        public AboutPage(EasyConsoleCore.Program program) : base("Calculations history", program)
        {
        }
        

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Made by: Džiugas Petkevičius");
            Output.WriteLine("2021-02-28");
            Output.WriteLine(string.Empty);
            Output.WriteLine(string.Empty);


            Input.ReadString("Press [enter] to return to main page!");


            Program.NavigateHome();
        }
    }
}
