using BankingChallenge.Repositories;
using BankingChallenge.Repositories.Interfaces;
using BankingChallenge.Services;
using BankingChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BankingChallenge
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //repositories
            services.AddSingleton<IHistoryRepository, HistoryRepository>();

            //services
            services.AddSingleton<IConsoleService, ConsoleService>();
            services.AddSingleton<ILoanService, LoanService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConsoleService consoleService)
        {
            consoleService.Init();
        }
    }
}
