using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syncart
{
    public class CustomerDetails
    {
        private static int s_customerId=1000;
        //property
        public string CustomerId{get;set;}
        public string Name{get;set;}
        public string City{get;set;}
        public string MobileNumber{get;set;}
        public double WalletBalance{get;set;}
        public string EmailId{get;set;}
        //constructor
        public CustomerDetails(string name,string city,string mobileno,double walletBalance,string emailId)
        {
            s_customerId++;
            CustomerId="CID"+s_customerId;
            Name=name;
            City=city;
            MobileNumber=mobileno;
            WalletBalance=walletBalance;
            EmailId=emailId;
            
        }
        //methods
        public double  WalletRecharge(double recharge)
        {
            WalletBalance+=recharge;
            return WalletBalance;
        }
        public double  DeductBalance(double recharge)
        {
            WalletBalance-=recharge;
            return WalletBalance;
        }
    }
}