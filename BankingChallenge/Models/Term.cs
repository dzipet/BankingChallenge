namespace BankingChallenge.Models
{
    public class Term
    {
        public double Interest { get; set; }
        public double AdministrationFeePercent { get; set; }
        public double MaxAdministrationFee { get; set; }

        //todo Interest rate calculated monthly?
    }
}
