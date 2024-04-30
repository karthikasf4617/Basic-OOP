using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //static class
    //no need to create object
    public static class Operations
    {
        //Local /Global object creation
        static StudentDetails currentLoggedInStudent;
         //static list
             static List<StudentDetails> studentList=new List<StudentDetails>();
             static List<DepartmentDetails> departmentList=new List<DepartmentDetails>();
             static List<AdmissionDetails> admissionList=new List<AdmissionDetails>();

             // Main Menu
            public static void MainMenu()
            {
                Console.WriteLine("*******Welcome*******");
                string mainchoice="yes";
                
               do
               {
                //Need to Show the Main menu option
                Console.WriteLine("MainMenu\n1. Registration\n2. Login\n3. Departmentwise Seat Avalibility\n4. Exit\n");
                //Need to get an input from user and validate
                Console.Write("Select an option :");
                int mainoption=int.Parse(Console.ReadLine());

                 //Need to create mainmenu structure
                switch(mainoption)
                {
                    case 1:
                    {
                        Console.WriteLine("*******Student Registration********");
                        StudentRegistartion();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("********Login********");
                        StudentLogin();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("*********Departmentwise Seat Avaliblity*******");
                        DepartmentWiseSeatAvaliblity();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("**********Application Exited Successfully***********");
                        mainchoice ="no";
                        break;
                    }
                }
                //Need to iterate untill the option is exit.
                }while(mainchoice=="yes");
            }//Main Menu ends

            //student Registration
            public static void StudentRegistartion()
            {
                //Need to get required details
                Console.Write("Enter Your Name : ");
                string studentName=Console.ReadLine();
                Console.Write("Enter your Father Name : ");
                string fatherName=Console.ReadLine();
                Console.Write("Enter your DOB as dd/MM/yyyy");
                DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                Console.Write("Enter your gender : ");
                Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
                Console.Write("Enter your Physics Mark : ");
                int physics=int.Parse(Console.ReadLine());
                Console.Write("Enter your Chemistry Mark : ");
                int chemistry=int.Parse(Console.ReadLine());
                Console.Write("Enter your Maths Mark : ");
                int maths=int.Parse(Console.ReadLine());
                //Need to crate an object
                StudentDetails student=new StudentDetails(studentName,fatherName,dob,gender,physics,chemistry,maths);
                //Need to add to list
                studentList.Add(student);
                //Need to display confirmation message and customerId
                Console.WriteLine($"You have successfully registered and your ID is {student.StudentId}");

                //Need to create an object
                //Need to add in the list
                //Need to display confirmation message and Id

            }//student registration ends

            //Student Login
            public static void StudentLogin()
            {
                //need to get login input
                Console.Write("Enter your student ID : ");
                string loginId=Console.ReadLine().ToUpper();
                //validate by its presence in the list
                bool flag=true;
                foreach(StudentDetails student in studentList)
                {
                    if(loginId.Equals(student.StudentId))
                    {
                        flag=false;
                        //assign current use
                        currentLoggedInStudent=student;
                        Console.WriteLine("Logged in Successfully");
                        SubMenu();
                        break;
                        //Need to call submenu
                    }
                }
                if(flag)
                {
                    Console.WriteLine("Invalid User");
                }
                //if not-Invalid


            }//student login ends

            //submenu
            public static void SubMenu()
            {
                string subChoice="yes";
                do{
                    Console.WriteLine("******SubMenu********");
                      //Need to show submenu options
                    Console.WriteLine("Select an option.\n1. Check Eligiblity \n2. Show Details\n3. Take Admission\n4. Cancel Admisssion \n5. Admisiion Details \n6.Exit");
                    //Getting user option
                    Console.Write("Enter your option :");
                    int subOption=int.Parse(Console.ReadLine());
                    //Need to create sub menu structure
                    switch(subOption)
                    {
                        case 1:
                        {
                            Console.WriteLine("***************Check Eligiblity**********");
                            CheckEligiblity();
                            break;
                        }
                         case 2:
                        {
                            Console.WriteLine("***************Show Details**********");
                            ShowDetails();
                            break;
                        }
                         case 3:
                        {
                            Console.WriteLine("***************Take Admission**********");
                            TakeAdmission();
                            break;
                        }
                         case 4:
                        {
                            Console.WriteLine("***************Cancel Admission*************");
                            CancelAdmission();
                            break;
                        }
                         case 5:
                        {
                            Console.WriteLine("*************Admission Details**********");
                            AdmissionDetails();
                            break;
                        }
                         case 6:
                        {
                            Console.WriteLine("**************Taking Back to Main Menu**********");
                            subChoice="no";
                            break;
                        }
                    }
                    //Iterate till the option is exit

                }while(subChoice=="yes");

            }//submenu ends
            //Check Eligiblity
            public static void CheckEligiblity()
            {
                //Get the cut off value as input
                Console.Write("Enter the cutoff value : ");
                double cutoff=double.Parse(Console.ReadLine());
                //check eligible or not
                if(currentLoggedInStudent.CheckEligiblity(cutoff))
                {
                    Console.WriteLine("Student is eligible ");
                }
                else
                {
                    Console.WriteLine("Student is not eligible");
                }

            }//Check Eligiblity ends
            // show details
            public static void ShowDetails()
            {
                //Printing the data
                   Console.WriteLine("|Student Id | Studentname|Fathername|DOB|Gender|Physicsmark|Chemistrymark|Mathsmark|");
                    Console.WriteLine($"|{currentLoggedInStudent.StudentId}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.Physics}|{currentLoggedInStudent.Chemistry}|{currentLoggedInStudent.Maths}");
    
                }

            // show details ends
            //take admission
            public static void TakeAdmission()
            {
                //Need to show avalible department details
                DepartmentWiseSeatAvaliblity();
                //Ask department ID from user
                Console.Write("Select a department ID");
                string departmentId=Console.ReadLine().ToUpper();
                //check Id is present or not
                bool flag=true;
                foreach(DepartmentDetails department in departmentList)
                {
                    if(departmentId.Equals(department.DepartmentId))
                    {
                        flag=false;
                        //check the student is eligible or not
                        if(currentLoggedInStudent.CheckEligiblity(75.0))
                        {
                            //check the seat avalible or not
                            if(department.NoOfSeats>0)
                            {
                                //check student already taken any admission
                                int count=0;
                                foreach(AdmissionDetails admission in admissionList)
                                {
                                    if(currentLoggedInStudent.StudentId.Equals(admission.StudentId)&& admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                    {
                                        count++;
                                    }
                                }
                                if(count==0)
                                {
                                    //create admission object 
                                    AdmissionDetails admissionTaken= new AdmissionDetails(currentLoggedInStudent.StudentId,department.DepartmentId,DateTime.Now,AdmissionStatus.Admitted);
                                    //Reduce seat count
                                    department.NoOfSeats--;
                                    //add to the admission list
                                    admissionList.Add(admissionTaken);
                                    //Display admission successful message
                                    Console.WriteLine($"Yo have taken admission succesfully. Admission Id : {admissionTaken.AdmissionId}");
                                }
                                else
                                {
                                    Console.WriteLine("You have already taken an admission");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("Seats are not avalible");
                            }         
                        }
                        else
                        {
                            Console.WriteLine("You are not eligible due to low cutoff");

                        }
                        
                        break;
                    }
                }
                if(flag)
                {
                    Console.WriteLine("Invalid User Id");
                        
                }
                
            }  //take admission ends
            // cancel admission
            public static void CancelAdmission()
            {
                //check the student is taken any admission and display it
                bool flag =true;
                foreach(AdmissionDetails admission in admissionList)
                {
                    if(currentLoggedInStudent.StudentId.Equals(admission.StudentId)&& admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                    {
                         //cancel the found admisiion
                         admission.AdmissionStatus=AdmissionStatus.Cancelled;
                        //return the seat to department.
                        foreach(DepartmentDetails department in departmentList)
                        {
                            if(admission.DepartmentId.Equals(department.DepartmentId))
                            {
                                department.NoOfSeats++;
                                break;
                            }
                        }
                        break;
                    }
                }
                if(flag)
                {
                    Console.WriteLine("You have not admmision to cancel");
                }
               

            } // cancel admission ends
            //Admission Details
            public static void AdmissionDetails()
            {
                Console.WriteLine("|AdmissionId | Student Id | Department Id| Admission Date| Admission Status|");
                //Need to show current logged in student admission details
                 foreach(AdmissionDetails admission in admissionList)
                {
                    if(currentLoggedInStudent.StudentId.Equals(admission.StudentId))
                    {
                    Console.WriteLine($"|{admission.AdmissionId}|{admission.StudentId}|{admission.DepartmentId}|{admission.Date}|{admission.AdmissionStatus}");
                     }
                }
            } //Admission Details ends
            

            //Departmentwise seat avaliblity
            public static void DepartmentWiseSeatAvaliblity()
            {
                //need to count element in department list

                //need to show department details
                Console.WriteLine("| DepartmentID | DepartmentName| NoOfSeats |");
                foreach(DepartmentDetails department in departmentList)
                {

                    Console.WriteLine($"|{department.DepartmentId}|{department.DepartmentName}|{department.NoOfSeats}|");
                }
                Console.WriteLine();
            }
             //Adding Default Data
             public static void AddDefaultData()
             {
                StudentDetails student1=new StudentDetails("Ravichandran","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
                StudentDetails student2=new StudentDetails("Baskaran","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
                studentList.AddRange(new List<StudentDetails>{student1,student2,});
                DepartmentDetails department1=new DepartmentDetails("EEE",29);
                DepartmentDetails department2=new DepartmentDetails("CSE",29);
                DepartmentDetails department3=new DepartmentDetails("MECH",30);
                DepartmentDetails department4=new DepartmentDetails("ECE",30);
                departmentList.AddRange(new List<DepartmentDetails>{department1,department2,department3,department4});
                AdmissionDetails totaldetails1=new AdmissionDetails(student1.StudentId,department1.DepartmentId,new DateTime(2022/11/05),AdmissionStatus.Admitted);
                AdmissionDetails totaldetails2=new AdmissionDetails("SF3002","DID102",new DateTime(2022/12/05),AdmissionStatus.Admitted);
                admissionList.AddRange(new List<AdmissionDetails>{totaldetails1,totaldetails2});

                
                

               
             }

    }
}