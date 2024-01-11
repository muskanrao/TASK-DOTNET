namespace oopseg
{
    class Employee
    {
        int empid;
         string empname;
        float salary;
        DateTime doj;

        public int Empid{
            set{empid = value;}
            get{return empid;}
        }
        public string Empname{
            set{empname = value;}
            get{return empname;}
        }
        public float Salary{
            set{
                if(value <= 0){
                    salary = 0;
                }else{
                    salary = value;
                }
            }
            get{return salary;}
        }

        public void AcceptDetails()
        {
            Console.WriteLine("Enter empid: ");
            Empid  = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter empname: ");
            Empname = Console.ReadLine();
            Console.WriteLine("Enter salary: ");
            Salary = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter doj: ");
            doj = Convert.ToDateTime(Console.ReadLine());
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Empid: {0}",Empid);
            Console.WriteLine("Empname: "+Empname);
            Console.WriteLine("salary: "+Salary);
            Console.WriteLine("DOJ: "+doj);
        }

        public virtual void CalculateSalary(){}

    }

    class Permanent : IEmployee 
    {
        float Salary;
        float basicpay;
        float hra;
        float da;
        float pf;
        public float Basicpay{
            set{
                if(value < 0){
                    basicpay = 0;
                }else{
                    basicpay = value;
                }
            }
            get{return basicpay;}
        }
        public float HRA{
            set{
                if(value < 0){
                    hra = 0;
                }else{
                    hra = value;
                }
            }
            get{return hra;}
        }
        public float DA{
            set{
                if(value <= 0){
                    da = 0;
                }else{
                    da = value;
                }
            }
            get{return da;}
        }
        public float PF{
            set{
                if(value <= 0){
                    pf = 0;
                }else{
                    pf = value;
                }
            }
            get{return pf;}
        }
        public void AcceptDetails()
        {
            Console.WriteLine("Enter Salary: ");
            Salary = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Basicpay: ");
            Basicpay  = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter HRA: ");
            HRA= float.Parse(Console.ReadLine());
            Console.WriteLine("Enter DA: ");
            DA = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter PF: ");
            PF = float.Parse(Console.ReadLine());
        }

         /*public void GetDetails()
        {
            Console.WriteLine("Enter Basicpay: ");
            Basicpay  = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter HRA: ");
            HRA= float.Parse(Console.ReadLine());
            Console.WriteLine("Enter DA: ");
            DA = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter PF: ");
            PF = float.Parse(Console.ReadLine());
        }*/
        public  void CalculateSalary(){
            //base.CalculateSalary();
            Salary = Salary + basicpay + HRA + DA - PF ;
        }
        public void DisplayDetails()
        {
            Console.WriteLine("Salary: {0}",Salary);
            Console.WriteLine("Basicpay: {0}",Basicpay);
            Console.WriteLine("HRA: "+HRA);
            Console.WriteLine("DA: "+DA);
            Console.WriteLine("PF: "+PF);
        }

       /* public void ShowDetails()
        {
            Console.WriteLine("Basicpay: {0}",Basicpay);
            Console.WriteLine("HRA: "+HRA);
            Console.WriteLine("DA: "+DA);
            Console.WriteLine("PF: "+PF);
        }*/
        

    }

    class Trainee: IEmployee
    {
        float Salary;
        float bonus;
        string projectname;
        public string Projectname{
            get{return projectname;}
            set{projectname = value;}
        }
        public void AcceptDetails()
        {
            Console.WriteLine("Enter Salary: ");
            Salary = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Bonus: ");
            bonus  = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Projectname: ");
            Projectname = Console.ReadLine();
        }

        /* public void GetTraineeDetails()
        {
            Console.WriteLine("Enter Bonus: ");
            bonus  = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Projectname: ");
            Projectname = Console.ReadLine();
        }*/

         public void CalculateSalary()
        {
            //base.CalculateSalary();
            string name = Projectname.ToLower();
            if(name.Equals("banking",StringComparison.OrdinalIgnoreCase)){
                bonus +=  Salary * (5/100);
            }else if(name.Equals("insurance",StringComparison.OrdinalIgnoreCase)){
                bonus +=  Salary * (10/100);
            }
        }
        public void DisplayDetails()
        {
            Console.WriteLine("Bonus: {0}",bonus);
            Console.WriteLine("Projectname: "+Projectname);
        }

       /* public void ShowTraineeDetails()
        {
            Console.WriteLine("Bonus: {0}",bonus);
            Console.WriteLine("Projectname: "+Projectname);
        }*/

       

    }
}