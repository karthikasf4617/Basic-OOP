using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountOpening
{
    /// <summary>
    /// Datatypr Gender used to select instance for student <see cref="AccountDetails"/> 
    ///Refer documentation on <see href="www.syncfusion.com"/>  
    /// </summary>
    public enum Gender{select,Male,Female,Transgender}
     /// <summary>
         /// class AccountDetails used to create instance for student <see cref="AccountDetails"/> 
         ///Refer documentation on <see href="www.syncfusion.com"/>  
        /// </summary>
    public class AccountDetails
    {
         
        /// <summary>
        /// static field s_customerId used to auto increment customerID of the instance of the <see cref="AccountDetails"/> 
        /// </summary>
        private static int s_customerId=1001;
        public string CustomerId{get;}
        /// <summary>
        /// FirstName property used o hold cutomerName of instance of <see cref="AccountDetails"/>  
        /// </summary>
        public string CustomerName {get; set;}
        public long Balance{get; set;}

        public Gender Gender{get; set;}
        public long PhoneNumber {get; set;}
        public string MailId {get; set;}
        public DateTime DOB {get; set;}
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AccountDetails()
        {           
            CustomerName="Enter your Name";
            Gender=Gender.select;
        }
        /// <summary>
        /// Constructor CustomerDetails used to initialize parameter values to its propertied.
        /// </summary>
        /// <param name="customerName"></param>customername parameter used to assign to its associated property</param>
        /// <param name="balance"></param>
        /// <param name="gender"></param>
        /// <param name="phoneNumber1"></param>
        /// <param name="mailId"></param>
        /// <param name="dob"></param>
        public AccountDetails(string customerName,long balance,
        Gender gender,long phoneNumber1,string mailId,DateTime dob)
        {
            
            CustomerId="HDFC"+s_customerId;
            s_customerId++;
            CustomerName=customerName;
            Balance=balance;
            Gender=gender;
            phoneNumber1=PhoneNumber;
            mailId=MailId;
            DOB=dob;
        }
        ///Methods
        ///<summary>
        /// Method methodname used to calcualte operation of instance of <see cref="AccountDetails"/> 
        ///</summary>
        ///<returns>Return value
    }
    
}