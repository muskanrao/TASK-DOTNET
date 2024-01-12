using System.Data.SqlTypes;
using System.Runtime.Intrinsics.Arm;

namespace BankProject
{
    class BankRepository : IBankRepository
    {
        List<SBAccount> l1 = new List<SBAccount>();
        List<SBTransaction> l2 = new List<SBTransaction>();
        

        public void NewTransactions(SBTransaction sm)
        {
            l2.Add(sm);
        }    

        
        public void NewAccount(SBAccount s){
            l1.Add(s);
        }
        public  SBAccount GetAccountDetails(int accno)
        {
            foreach(SBAccount sa in l1)
            {
                if(sa.AccountNumber == accno){
                    return sa;
                }
            }
            return null;//throw exception
        }

        public List<SBAccount> GetAllAccounts()
        {
            List<SBAccount> l = new List<SBAccount>();
            foreach(SBAccount si in l1){
                l.Add(si);
            }
            return l;
        }

        public void DepositAmount(int accno, decimal amt)
        {
            foreach(SBAccount sn in l1)
            {
                if(sn.AccountNumber == accno)
                {
                    sn.CurrentBalance += amt;
                    Console.WriteLine(sn.CurrentBalance);
                    break;
                }
            }
           
        }

        public void WithdrawAmount(int accno,decimal amt)
        {
            foreach(SBTransaction st in l2)
            {
                if(st.AccountNumber == accno){
                    if(st.Amount < amt)
                    {
                        Console.WriteLine("Not enough amount for withdrawal");
                        //Exception
                    }else{
                        st.Amount -= amt;
                        Console.WriteLine(st.Amount);
                    }
                    break;
                }
            }
        }

        public List<SBTransaction> GetTransactions(int accno)
        {
            List<SBTransaction> l3 = new List<SBTransaction>();
            foreach(SBTransaction sw in l2)
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
