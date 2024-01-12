namespace BankProject
{
    class BankClient
    {
        public static void Main()
        {
            BankRepository b = new BankRepository();
            SBAccount s1 = new SBAccount(1,"ABC","123abc",123.2m);
            SBAccount s2 = new SBAccount(2,"DEF","123abc",123.2m);
            SBAccount s3 = new SBAccount(3,"GHI","123abc",123.2m);

            SBTransaction st1 = new SBTransaction(1,new DateTime(2022,12,12),12,123.3m,"abc");
            SBTransaction st2 = new SBTransaction(12,new DateTime(2022,11,12),12,123.3m,"abc");
            SBTransaction st3 = new SBTransaction(13,new DateTime(2022,10,12),12,123.3m,"abc");

            b.NewAccount(s1);
            b.NewAccount(s2);
            b.NewAccount(s3);

            b.NewTransactions(st1);
            b.NewTransactions(st2);
            b.NewTransactions(st3);

            List<SBAccount> l1 = b.GetAllAccounts();
            // displaying Account details
            Console.WriteLine("Displaying all Account details");
            foreach(SBAccount sa in l1)
            {
                Console.WriteLine(sa.AccountNumber+" "+sa.CustomerName+" "+sa.CurrentBalance);
            }
            Console.WriteLine("Displaying all Account details for accno: ");
            //to get account details for accno: 1
            SBAccount se = b.GetAccountDetails(1);

            Console.WriteLine("Amout after Deposit& Withdrawal: ");
            b.DepositAmount(1,12m);
            b.WithdrawAmount(2,10m);

            //getting transaction for particular account number

            Console.WriteLine("Getting transaction for accno");
            List<SBTransaction> st = b.GetTransactions(12);
            
        }
    }
}
