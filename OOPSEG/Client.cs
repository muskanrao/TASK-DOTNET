namespace oopseg
{
    class Client
    {
        public static void Main()
        {
            Permanent e1 = new Permanent();  
            e1.AcceptDetails();
            e1.CalculateSalary();
            e1.DisplayDetails(); 
            //e1.Salary = 100;
            //Console.WriteLine("Salary intial "+e1.Salary);
            //e1.GetDetails();
            //e1.ShowDetails();
            //Console.WriteLine("salary after cal: "+e1.Salary);

            Trainee t1 = new Trainee();
            t1.AcceptDetails();
            t1.CalculateSalary();
            t1.DisplayDetails();
            //Console.WriteLine("salary initial2 : "+e1.Salary);
           // t1.Salary = 200;
           // Console.WriteLine("salary trainee : "+e1.Salary);
           // t1.GetTraineeDetails();
            //t1.ShowTraineeDetails();
            //Console.WriteLine("salary afer cal: "+e1.Salary);

        }
    }
}