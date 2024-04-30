using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syncart
{
    //Enum
    public enum OrderStatus{Default,Ordered,Cancelled}
    public class OrderDetails
    {
        private static int s_orderId=1000;
        //property
        public string OrderId{get;set;}
        public string CustomerId{get;set;}
        public string ProductId{get;set;}
        public double TotalPrice{get;set;}
        public DateTime PurchaseDate{get;set;}
        public double Quantity{get;set;}
        public OrderStatus OrderStatus{get;set;}
        //Constructor
        public OrderDetails(string customerId,string productId,double totalPrice,DateTime purchaseDate,double quantity,OrderStatus orderstatus)
        {
            s_orderId++;
            OrderId="OID"+s_orderId;
            CustomerId=customerId;
            ProductId=productId;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            OrderStatus=orderstatus;
        }



    }
}