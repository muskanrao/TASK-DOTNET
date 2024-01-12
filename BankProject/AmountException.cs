namespace BankProject
{
    public class AmountInvalidException :  ApplicationException
    {
        public AmountInvalidException(string message):base(message){}
    }

    public class BankingInputs
    {
        public decimal Amount{get;set;}
        public void CheckAmount(decimal amt){
            if(amt<0)
            {
                throw new AmountInvalidException("Sorry! Entered amount is invalid");
            }
        }
    }
}