namespace BankingChallenge.Models
{
    public class PaymentOverview : Term
    {
        public PaymentOverview(Term term)
        {
            Interest = term.Interest;
            AdministrationFeePercent = term.AdministrationFeePercent;
            MaxAdministrationFee = term.MaxAdministrationFee;
        }

        public double LoanAmount { get; set; }
        public int LoanDuration { get; set; }
        public double Installment { get; set; }
        public double TotalPaidAmount { get; set; }
        public double TotalPaidInterest { get; set; }
        public double AdministrationFee { get; set; }
        public double APR { get; set; }
    }
}
