namespace BankProject
{
    public class SBAccount
    {
        int accountNumber;
        string customerName;
        string customerAddress;
        decimal currentBalance;

        public int AccountNumber{get{return accountNumber;}set{accountNumber=value;}}
        public string CustomerName{get{return customerName;}set{customerName=value;}}
        public string CustomerAddress{get{return customerAddress;}set{customerAddress=value;}}
        public decimal CurrentBalance{get{return currentBalance;}set{currentBalance =value;}}
        public SBAccount(int num, string name,string add,decimal balance)
        {
            AccountNumber = num;
            CustomerName = name;
            CustomerAddress = add;
            CurrentBalance = balance;
        }
    }

    public class SBTransaction
    {
        int transactionId;
        DateTime transactionDate;
        int accountNumber;
        decimal amount;
        string transactionType;
        public int TransactionId{
            get{
                return transactionId;
            }
            set{transactionId=value;}}
        public DateTime TransactionDate
        {
            get{return transactionDate;}
            set{transactionDate =value;}
        }
        public  int AccountNumber{
            get{return accountNumber;}
            set{accountNumber=value;}
        }
        public decimal Amount{
            get{return amount;}
            set{amount=value;}
        }
        public string TransactionType{get{return transactionType;}set{transactionType=value;}}
        public SBTransaction(int id ,DateTime date, int acc,decimal amount,string ttype){
            TransactionId = id;
            TransactionDate = date;
            AccountNumber = acc;
            Amount = amount;
            TransactionType = ttype;
        }
    }


}
