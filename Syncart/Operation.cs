using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Syncart
{
    public class Operation
    {
        public static CustomerDetails currentLoggedInuser;
        static List<CustomerDetails> customerList=new List<CustomerDetails>();
        static List<OrderDetails> orderList=new List<OrderDetails>();
        static List<ProductDetails> productList=new List<ProductDetails>();
        //mainmenu starts here
        public static void MainMenu()
        {
            Console.WriteLine("************Welcome*************");
            string option="yes";
            do{
                Console.WriteLine("Selcet your option\n1. Customer Registration\n2. Customer Login \n3.Exit");
                int choice=int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                    {
                        Console.WriteLine("*********Customer Registration************");
                        CustomerRegistration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("**********Customer Login************");
                        CustomerLogin();
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

        }//maimenu ends here
        //customer registration starts here
        public static void CustomerRegistration()
        {
            Console.Write("Enter Your Fullname : ");
            string Name=Console.ReadLine();
            Console.Write("Enter your City : ");
            string City=Console.ReadLine();
            Console.Write("Enter your MobileNumber");
            string MobileNumber=Console.ReadLine();
            Console.Write("Enter your MailId : ");
            string MailId=Console.ReadLine();
            Console.Write("Enter your WaalteBalance :");
            double WaalteBalance=double.Parse(Console.ReadLine());
            CustomerDetails customer=new CustomerDetails(Name,City,MobileNumber,WaalteBalance,MailId);
            customerList.Add(customer);
            Console.WriteLine($"You have successfully registered amd your Id is {customer.CustomerId}");

        }//customer registrations ends here
        //customer login starts here
        public static void CustomerLogin()
        {
            Console.Write("Enter your Login ID : ");
            string loginId=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(CustomerDetails  customer in customerList)
            {
                if(loginId.Equals(customer.CustomerId))
                {
                    currentLoggedInuser=customer;
                    flag=false;
                    Console.WriteLine("Logged in successfully");
                    SubMenu();
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("InvalidUser");
            }
        }//customer login ends here
        //submenu starts here
        public static void SubMenu()
        {
            string option1="yes";
            do{
                Console.WriteLine("********SubMenu*********");
                Console.WriteLine("Select your option\n1. Purchase \n2.Order History\n3. Cancel Order\n4.Wallet Balance\n5.Wallet Recharge \n6. Exit");
                int subMenuOption=int.Parse(Console.ReadLine());
                switch(subMenuOption)
                {
                    case 1:
                    {
                        Console.WriteLine("*******Purchase********");
                        Purchase();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("*********Order History***********");
                        OrderHistory();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("************Cancel Order***********");
                        CancelOrder();
                        break;
                    }
                     case 4:
                    {
                        Console.WriteLine("************Wallet Balance***********");
                        WalletBalance();
                        break;
                    }
                     case 5:
                    {
                        Console.WriteLine("************Wallet Recharge ***********");
                        WalletRecharge ();
                        break;
                    }
                    case 6:
                    {
                        Console.WriteLine("**********Exiting SubMenu***********");
                        option1="no";
                        break;
                    }
                }

            }while(option1=="yes");
        }//submenu ends here
        //purchase method starts here
        public static void Purchase()
        {
            foreach(ProductDetails product in productList)
            {
                Console.WriteLine($"|{product.ProductId}|{product.ProductName}|{product.Stock}|{product.Price}|{product.ShippingDuration}|");
            }
            Console.Write("Select a productId : ");
            string productId=Console.ReadLine().ToUpper();
            bool flag=true;
            bool flag1=true;
            bool flag2=true;
            foreach(ProductDetails product1 in productList)
            {
                if(product1.ProductId.Equals(productId))
                {
                    flag=false;
                    Console.Write("Enter a quantity : ");
                    double quantity=double.Parse(Console.ReadLine());
                    if(product1.Stock>=quantity)
                    {
                        flag1=false;
                        double totalamount=product1.Price*quantity+50;
                        if(totalamount<=currentLoggedInuser.WalletBalance)
                        {
                            flag2=false;
                            currentLoggedInuser.WalletBalance-=totalamount;
                            product1.Stock-=quantity;
                            OrderDetails order=new OrderDetails(currentLoggedInuser.CustomerId,product1.ProductId,totalamount,DateTime.Now,quantity,OrderStatus.Ordered);
                            orderList.Add(order);
                            Console.WriteLine("Your Order Placed Succesfullyy..Your Order Id is :"+order.OrderId);
                        }
                        if(flag2)
                        {
                            Console.WriteLine("WalletBalance is Insufficient..");
                            break;
                        }
                    }
                    if(flag1)
                    {
                        Console.WriteLine("Entered Quantity stock is unavalible..");
                        break;
                    }

                }
                if(flag)
                {
                    Console.WriteLine("Invalid ProductId..");
                    break;
                }
            }
        }//purchase method ends here
        //orderhistory methods starts here
        public static void OrderHistory()
        {
            foreach(OrderDetails order in orderList)
            {
                if(currentLoggedInuser.CustomerId.Equals(order.CustomerId))
                {
                    Console.WriteLine($"|{order.OrderId}|{order.CustomerId}|{order.ProductId}|{order.TotalPrice}|{order.Quantity}|{order.PurchaseDate}|{order.OrderStatus}");
                }
            }
        }//orderhistory method ends here
        //cancelordder methods starts here
        public static void CancelOrder()
        {
            foreach(OrderDetails order in orderList)
            {
                if(currentLoggedInuser.CustomerId.Equals(order.CustomerId))
                {
                    if(order.OrderStatus.Equals(OrderStatus.Ordered))
                    {
                    Console.WriteLine($"|{order.OrderId}|{order.CustomerId}|{order.ProductId}|{order.TotalPrice}|{order.Quantity}|{order.PurchaseDate}|{order.OrderStatus}");
                    }
                }

            }
            Console.WriteLine("select orderId to cancel..");
            string orderid=Console.ReadLine().ToUpper();
            foreach(OrderDetails order1 in orderList)
            {
                if(order1.OrderId.Equals(orderid))
                {
                    currentLoggedInuser.WalletBalance-=order1.TotalPrice;
                    order1.OrderStatus=OrderStatus.Cancelled;
                    Console.WriteLine($"Your Order {order1.OrderId} cancelled successfully.." );
                }
            }


        }//cancelorder ends here
        //WalletBalance starts here
        public static void WalletBalance()
        {
            Console.WriteLine("Your Balance is : "+currentLoggedInuser.WalletBalance);
        }//walletbalance ends here
        //walletrecharge starts here
        public static void WalletRecharge()
        {
            Console.WriteLine("Enter Recharge Amount :");
            double Recharge=double.Parse(Console.ReadLine());
            double result=currentLoggedInuser.WalletRecharge(Recharge);
            Console.WriteLine("TYour Balance is : "+result);
        }//wallet reccharge ends here
        //adddefaultmethod starts here
        public static void AddDefault()
        {
            CustomerDetails customer1=new CustomerDetails("Ravi	","Chennai","9885858588",50000,"ravi@mail.com");
            CustomerDetails customer2=new CustomerDetails("Baskaran","Chennai","9888475757",60000,"baskaran@mail.com");
            customerList.AddRange(new List<CustomerDetails>{customer1,customer2});
            ProductDetails product1=new ProductDetails("Mobile (Samsung)",	10,	10000,	3);
            ProductDetails product2=new ProductDetails("Tablet (Lenovo)"	,5,	15000,	2);
            ProductDetails product3=new ProductDetails("Camara (Sony)",	3,	20000,	4);
            ProductDetails product4=new ProductDetails("Laptop (Lenovo I3)	",3	,40000,	3);
            ProductDetails product5=new ProductDetails("HeadPhone (Boat)"	,5	,1000,	2);
            ProductDetails product6=new ProductDetails("Speakers (Boat)"	,4	,500,	2);
            productList.AddRange(new List<ProductDetails>{product1,product2,product3,product4,product5,product6});
            OrderDetails order1=new OrderDetails(customer1.CustomerId,product1.ProductId,20000,DateTime.Now,2,OrderStatus.Ordered);
            OrderDetails order2=new OrderDetails(customer2.CustomerId,product2.ProductId,40000,DateTime.Now,2,OrderStatus.Ordered);
            orderList.AddRange(new List<OrderDetails>{order1,order2});
        }//adddefault method ends here
    }
}