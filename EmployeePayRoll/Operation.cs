using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    
    public class Operation
    {
        static EmployeeDetails currentuser;
        static List<EmployeeDetails> employeeList=new List<EmployeeDetails>();
         public static void MainMenu()
        {
            Console.WriteLine("************Welcome*************");
            string option="yes";
            do{
                Console.WriteLine("Selcet your option\n1. Employee Registration\n2. Employee Login \n3.Exit");
                int choice=int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                    {
                        Console.WriteLine("*********Employee Registration************");
                        EmployeeRegistration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("**********Employee Login************");
                        EmployeeLogin();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Thank you ");
                        option="no";
                        break;
                    }
                }
            }while(option=="yes");

        }
        public static void EmployeeRegistration()
        {
            Console.Write("Enter Your Fullname : ");
            string employeeName=Console.ReadLine();
            Console.Write("Enter Your Role : ");
            string role=Console.ReadLine();
            Console.Write("Select Your WorkLocation");
            WorkLocation workLocation=Enum.Parse<WorkLocation>(Console.ReadLine(),true);
            Console.Write("Enter Your TeamName : ");
            string teamName=Console.ReadLine();
            Console.Write("Enter your Date Of Joining");
            DateTime date=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter No of Working Days ");
            double NoofWorkingDays=double.Parse(Console.ReadLine());
            Console.Write("Enter No of leave Taken :");
            double noOfLeaveTaken=double.Parse(Console.ReadLine());
            Console.Write("Select gender : ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            EmployeeDetails employee=new EmployeeDetails(employeeName,role,workLocation,teamName,date,NoofWorkingDays,noOfLeaveTaken,gender);
            employeeList.Add(employee);
            Console.WriteLine($"You have successfully registered amd your Id is {employee.EmployeeId}");

        }
        public static void EmployeeLogin()
        {
            Console.WriteLine("Enter loginId :");
            string loginId=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(EmployeeDetails employee in employeeList)
            {
                if(employee.EmployeeId.Equals(loginId))
                {
                    currentuser=employee;
                    flag=false;
                    Console.WriteLine("Logged In Succesfully");
                    Submenu();
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid LoginId");
            }
        }
        public static void Submenu()
        {
            string option="yes";
            do
            {
            Console.WriteLine("Select an option\n1. Calculate salary\n2. display details\n3. exit");
            int suboption=int.Parse(Console.ReadLine());
            switch(suboption)
            {
                case 1:
                {
                    Console.WriteLine("Calculating Salary");
                    Calculatesalary();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Displaying Details");
                    ShowDetails();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("Exiting Sub Menu");
                    option="no";
                    break;
                }
            }
            }while(option =="yes");
        }
        public static void Calculatesalary()
        {
            double Result=currentuser.Calculatesalarymethod();
            Console.WriteLine("Your Salary is :"+Result);
        }
        public static void ShowDetails()
        {
            foreach(EmployeeDetails employee in employeeList)
            {
                if(employee.EmployeeId.Equals(currentuser.EmployeeId))
                {
                    Console.WriteLine($"|{employee.EmployeeId}|{employee.EmployeeName}|{employee.Role}|{employee.Date}|{employee.NoOfWorkingDays}|{employee.NoOfWorkingDays}|{employee.TeamName}");
                }
            }
        }
    }
}