namespace BankProject
{
    public class AccountInvalidException :  ApplicationException
    {
        public AccountInvalidException(string message):base(message){}
    }

    public class BankingInputs
    {
        public decimal Amount{get;set;}
        public void CheckAccount(){
            throw new AccountInvalidException("Sorry! Entered Account is invalid");
        }
    }
}