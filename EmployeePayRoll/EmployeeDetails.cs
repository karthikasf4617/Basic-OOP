using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    public enum WorkLocation{select,Chennai,Coimbatore,Bangalore,Thiruvarur,Thanjavur,Trichy};
    public enum Gender{select,Male,Female,Transgender}
    public class EmployeeDetails
    {
        /*EmployeeID - (SF1001), Employee name, Role, WorkLocation (enum), Team name, Date of Joining,
         Number of Working Days in Month, Number of Leave Taken, Gender (enum – Male, Female )*/
         private static int s_employeeId=1000;
         public string EmployeeId{get;}
         public string EmployeeName{get;set;}
         public string Role{get;set;}
         public WorkLocation WorkLocation{get; set;}
         public string TeamName{get;set;}
         public DateTime Date{get;set;}
         public double NoOfWorkingDays{get;set;}
         public double NoOfLeaveTaken{get;set;}
         public Gender Gender{get;set;}

         public EmployeeDetails(string employeeName,string role,WorkLocation workLocation,string teamName,DateTime date,double noOfWorkingDays,double noOfLeaveTaken,Gender gender)
         { s_employeeId++;
            EmployeeId="SF"+s_employeeId;
            EmployeeName=employeeName;
            Role=role ;
            WorkLocation=WorkLocation;
            TeamName=teamName;
            Date=date;
            NoOfWorkingDays=noOfWorkingDays;
            NoOfLeaveTaken=noOfLeaveTaken;
            Gender=gender;
         }
         public double Calculatesalarymethod()
         {
            double totalsalary=NoOfWorkingDays*500;
            double leavetaken=NoOfLeaveTaken*500;
            double result=totalsalary-leavetaken;
            return result;
         }


    }
}