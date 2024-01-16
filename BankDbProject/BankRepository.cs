using System.Data.Common;
using System.Data.SqlTypes;
using System.Runtime.Intrinsics.Arm;
using BankDbProject.Models;

namespace BankProject
{
    class BankRepository : IBankRepository
    {
        BankingInputs ba = new BankingInputs();
        List<SbaccountM> l1 = new List<SbaccountM>();
        List<SbtransactionM> l2 = new List<SbtransactionM>();
        private static Ace52024Context db = new Ace52024Context();
        

        public void NewTransactions(SbtransactionM sm)
        {
            //l2.Add(sm);
            db.SbtransactionMs.Add(sm);
            db.SaveChanges();
        }    

        
        public void NewAccount(SbaccountM s){
            //l1.Add(s);
            db.SbaccountMs.Add(s);
            db.SaveChanges();
        }
        public  SbaccountM GetAccountDetails(int accno)
        {
           
            SbaccountM sb1 = (SbaccountM)db.SbaccountMs.Where(x=>x.AccountNumber == accno).SingleOrDefault();
            return sb1;
            // ba.CheckAccount();
        }

        public List<SbaccountM> GetAllAccounts()
        {
            List<SbaccountM> l = new List<SbaccountM>();
            foreach(SbaccountM item in db.SbaccountMs){
                l.Add(item);
            }
            return l;
        }

        public void DepositAmount(int accno, decimal amt)
        {
            foreach(SbaccountM sn in db.SbaccountMs)
            {
                if(sn.AccountNumber == accno)
                {
                    sn.CurrentBalance += amt;
                    Console.WriteLine("Your current Balance after Deposit: "+sn.CurrentBalance);
                    break;
                }
            }
           
        }

        public void WithdrawAmount(int accno,decimal amt)
        {
            foreach(SbtransactionM st in db.SbtransactionMs)
            {
                if(st.AccountNumber == accno){
                    if(amt<0)
                    {
                        ba.CheckAccount();
                        //Exception
                    }else{
                        st.CurrentBalance -= amt;
                        
                        Console.WriteLine("Your Balance after Withdraw :"+st.CurrentBalance);
                    }
                    break;
                }
            }
        }

        public List<SbtransactionM> GetTransactions(int accno)
        {
            List<SbtransactionM> l3 = new List<SbtransactionM>();
            foreach(SbtransactionM sw in db.SbtransactionMs)
            {
                if(sw.AccountNumber == accno)
                {
                    l3.Add(sw);
                }
            }
            return l3;
        }



    }
}