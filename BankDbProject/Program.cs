using System.Diagnostics;
using BankDbProject.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace BankProject
{
    public class Program
    {
        private static Ace52024Context db = new Ace52024Context();
        public static void Main()
        {
            IBankRepository b = new BankRepository();
            bool value = true;
            
            while(true)
            {
                Console.WriteLine("1 : Add new account in SBAccount");
                Console.WriteLine("2 : Add new Transaction in SBTransaction");
                Console.WriteLine("3 : To get specific Account's Details");
                Console.WriteLine("4 : To Get Details of All Accounts");
                Console.WriteLine("5 : To Deposit Amount");
                Console.WriteLine("6 : To Withdraw Ammount");
                Console.WriteLine("7 : To Get specific Account's Transaction");
                Console.WriteLine("8 : To Exit");

                Console.WriteLine("\nEnter your Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                    SbaccountM ac = new SbaccountM();
                    Console.Write("Enter Account Number : ");
                    ac.AccountNumber = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Customer Name : ");
                    ac.CustomerName = (Console.ReadLine());
                    Console.Write("Enter Customer Address : ");
                    ac.CustomerAddress = (Console.ReadLine());
                    Console.Write("Enter Current Balance : ");
                    ac.CurrentBalance = Convert.ToInt32(Console.ReadLine());
                    b.NewAccount(ac);
                    break;
                    case 2:
                    SbtransactionM tc = new SbtransactionM();
                    Console.Write("Enter Transaction Id : ");
                    tc.TransactionId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Transaction Date : ");
                    tc.TransactionDate = DateOnly.FromDateTime(Convert.ToDateTime(Console.ReadLine()));
                    Console.Write("Enter Account Number : ");
                    tc.AccountNumber = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Current Balance : ");
                    tc.CurrentBalance = Convert.ToInt32(Console.ReadLine());
                    b.NewTransactions(tc);
                    break;
                    case 3:
                    Console.WriteLine("Enter the Account Number to get Details: ");
                    int accno = Convert.ToInt32(Console.ReadLine());
                    b.GetAccountDetails(accno);
                    break;
                    case 4:
                    Console.WriteLine("All Accounts Details: ");
                    List<SbaccountM> scc = b.GetAllAccounts();
                    foreach(SbaccountM item in scc)
                    {
                        Console.WriteLine(item.AccountNumber+" "+item.CustomerName+" "+item.CustomerAddress+" "+item.CurrentBalance);
                    }
                    break;
                    case 5:
                    Console.WriteLine("Enter the Accno & Amount to Deposit: ");
                    int accn = Convert.ToInt32(Console.ReadLine());
                    decimal sal = Convert.ToDecimal(Console.ReadLine());
                    b.DepositAmount(accn,sal);
                    break;
                    case 6:
                    Console.WriteLine("Enter Accno & Withdrawal Amount: ");
                    int acc = Convert.ToInt32(Console.ReadLine());
                    decimal salary = Convert.ToDecimal(Console.ReadLine());
                    b.WithdrawAmount(acc,salary);
                    break;
                    case 7:
                    Console.WriteLine("Enter Account number to get Transaction's Details: ");
                    int acno = Convert.ToInt32(Console.ReadLine());
                    b.GetTransactions(acno);
                    break;
                    case 8:
                    value = false;
                    break;
                    default:
                    Console.WriteLine("Default Case run");
                    break;
                    
                }   
            }
        }
    }
}