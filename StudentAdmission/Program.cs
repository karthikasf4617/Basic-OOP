using System;
using System.Collections.Generic;
using System.Runtime.Serialization.DataContracts;
using System.Security.Cryptography.X509Certificates;
namespace StudentAdmission
{
    class Program
    {
        public static void Main(string[] args)
        {
           //Default Data Calling
           Operations.AddDefaultData();


           //Calling Main Menu
           Operations.MainMenu();
        }
    }
}
