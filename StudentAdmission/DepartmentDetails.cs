using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class DepartmentDetails
    {
        //static field
        private static int s_departmentId=100; 
        //properties
        public string DepartmentId{get;}
        public string DepartmentName{get; set;}
        public int NoOfSeats{get; set;}

        //constructor
        public DepartmentDetails(string departmentName,int noOfSeats)
        {
            s_departmentId++;
            DepartmentId="DID"+s_departmentId;
            DepartmentName=departmentName;
            NoOfSeats=noOfSeats;
        }

    }
}