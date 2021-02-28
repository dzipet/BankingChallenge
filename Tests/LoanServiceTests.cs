using System;
using BankingChallenge.Models;
using BankingChallenge.Repositories.Interfaces;
using BankingChallenge.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class LoanServiceTests
    {
        private Mock<IHistoryRepository> _historyMock = new Mock<IHistoryRepository>();


        [DataTestMethod]
        [DataRow(500000, 120, 10000, 1, 5, 636393.09, 5000, 5303.28, 136393.09)]
        [DataRow(500000, 120, 4000, 1, 5, 636393.09, 4000, 5303.28, 136393.09)]
        public void TestMethod1(double amount, int duration, double maxAdministrationFee, double administrationFeePercent, double interest, 
            double expectedTotalPaidAmount, double expectedAdministration, double expectedInstallment, double expectedTotalInterest)
        {
            var service = new LoanService(_historyMock.Object);

            var term = new Term
            {
                MaxAdministrationFee = maxAdministrationFee,
                AdministrationFeePercent = administrationFeePercent,
                Interest = interest
            };

            var result = service.CreateOverview(amount, duration, term);

            Assert.AreEqual(expectedTotalPaidAmount, Math.Round(result.TotalPaidAmount, 2), "TotalPaidAmount");
            Assert.AreEqual(expectedAdministration, Math.Round(result.AdministrationFee, 2), "AdministrationFee");
            Assert.AreEqual(expectedInstallment, Math.Round(result.Installment, 2), "Installment");
            Assert.AreEqual(amount, result.LoanAmount, "LoanAmount");
            Assert.AreEqual(duration, result.LoanDuration, "LoanDuration");
            Assert.AreEqual(maxAdministrationFee, result.MaxAdministrationFee, "MaxAdministrationFee");
            Assert.AreEqual(administrationFeePercent, result.AdministrationFeePercent, "AdministrationFeePercent");
            Assert.AreEqual(expectedTotalInterest, Math.Round(result.TotalPaidInterest, 2), "TotalPaidInterest");
            Assert.AreEqual(interest, result.Interest, "Interest");
        }
    }
}
