using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Formats.Asn1;
using System.Reflection.Emit;
namespace BankAccountOpening
{
    class Program 
    {
        public static void Main(string[] args)
        {
                         List<AccountDetails> customerList=new  List<AccountDetails>();
                         Console.WriteLine("Welcome To HDFC Bank");
                         string option="yes";
                        do
                        {
                            Console.WriteLine("Select Option \n1.Registration \n2.Login \n3.Exit");
                             int choice = int.Parse(Console.ReadLine());  
                        switch(choice)
                        {
                            case 1:
                            {
                                Console.WriteLine("Enter Your Name");
                                string customerName = Console.ReadLine();
                                Console.WriteLine("Enter Your Balance");
                                long balance = long.Parse(Console.ReadLine());
                                Console.WriteLine("Select Your Gender 1.Male , 2.Female ,3.Transgender");
                                Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
                                Console.WriteLine("Enter Your MailId");
                                string mailId = Console.ReadLine();
                                Console.WriteLine("Enter Your PhoneNumber");
                                long phoneNumber = long.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Your DateOfBirth");
                                DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                                AccountDetails customer = new AccountDetails(customerName, balance, gender, phoneNumber, mailId, dob);
                                customerList.Add(customer);
                                Console.WriteLine($"You Have Registered and Your Login Id is{customer.CustomerId}");
                                break;
                            }
                            case 2:
                            {
                                    Console.WriteLine("Enter your Login Id");
                                    string LoginId=Console.ReadLine().ToUpper();
                                    bool flag=true;
                                    foreach(AccountDetails number in customerList)
                                    {
                                        if(number.CustomerId==LoginId)
                                        {
                                        flag=false;
                                        Console.WriteLine("Select your option \n 1.Deposit \n2.Withdraw \n3.BalanceCheck \n4.Exit");
                                        int select=int.Parse(Console.ReadLine());
                                        if(select==1)
                                        {
                                            Console.WriteLine("Enter deposit Amount");
                                            long deposit=long.Parse(Console.ReadLine());
                                            long total=deposit+number.Balance;
                                            Console.WriteLine($"Balance = {total}");
                                        }
                                        if(select==2)
                                        {
                                            Console.WriteLine("Enter withdraw Amount");
                                            long withdraw=long.Parse(Console.ReadLine());
                                            long total=withdraw-number.Balance;
                                            Console.WriteLine($"Balance = {total}");

                                        }
                                        if(select==3)
                                        {
                                            Console.WriteLine($"Balance = {number.Balance}");
                                        }
                                        if(select==4)
                                        {
                                            Console.WriteLine("Thank You");
                                        }
                                        }
                            
                                    }
                                    if(flag )
                                    {
                                    Console.WriteLine("Invalid LoginId");
                                    }
                                    break;
                                }
                                case 3:
                                {
                                     Console.WriteLine("Thanks for Visiting");
                                     option="no";
                                     break;
                                }
                            
                            }
                        
        
                        }while(option=="yes");
        }
                      
                        
    }

        }
    
           

    
    
