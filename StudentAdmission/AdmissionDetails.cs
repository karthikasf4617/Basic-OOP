using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //enum declaration
    public enum AdmissionStatus{select,Admitted,Cancelled}
    public class AdmissionDetails
    {
        //Field
        private static int s_admissionId=1000;
        //property
        public string AdmissionId{get;}
        public string StudentId{get; set;}
        public string DepartmentId{get; set;}
        public DateTime Date{get;set;}
        public AdmissionStatus AdmissionStatus{get; set;}

        //constructor
        public AdmissionDetails(string studentId, string departmentId,DateTime date,AdmissionStatus admissionStatus)
        {
            s_admissionId++;
            AdmissionId="AID"+s_admissionId;
            StudentId=studentId;
            DepartmentId=departmentId;
            Date=date;
            AdmissionStatus=admissionStatus;

        }

    }
}