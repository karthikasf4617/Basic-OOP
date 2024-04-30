using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syncart
{
    public class ProductDetails
    {
        //field
        private static int s_productId=100;
        public string ProductId{get;set;}
        public string ProductName{get;set;}
        public double Price{get;set;}
        public double Stock{get;set;}
        public double ShippingDuration{get;set;}
        public ProductDetails(string productName,double price,double stock,double shippingDuration)
        {
            s_productId++;
            ProductId="PID"+s_productId;
            ProductName=productName;
            Price=price;
            Stock=stock;
            ShippingDuration=shippingDuration;
        }
    }
}