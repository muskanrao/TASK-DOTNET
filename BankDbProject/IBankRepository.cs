//using BankDbProject.Models;

using BankDbProject.Models;

namespace BankProject
{
    public interface IBankRepository
    {
        void NewAccount(SbaccountM acc);
        List<SbaccountM> GetAllAccounts();
        void NewTransactions(SbtransactionM acc);
        SbaccountM GetAccountDetails(int accno);
        void DepositAmount(int accno, decimal amt);
        void WithdrawAmount(int accno, decimal amt);
        List<SbtransactionM> GetTransactions(int accno);
       
    }
}