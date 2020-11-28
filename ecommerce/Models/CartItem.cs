using System;
using System.Collections.Generic;
//////using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartItem
/// </summary>
namespace ZartCartItem
{
    [Serializable]
    public class CartItem
    {
        private int _productID;
        private string _productName;
        private string _productImageUrl;
        private int _quantity;
        private double _discount;
        private double _linetotal;
        private string _color;
        private string _size;
        private double _price;
        private string _brand;
        private string _date;
      
        private double _tax;

        public void New()
        {

        }
        public void New(int productId, string productName, string productImage, int quantity, double discount, string color, string size, string brand, double price,double tax)
        {
            _productID = ProductId;
            _productName = ProductName;
            _productImageUrl = productImage;
            _quantity = quantity;
            _discount = discount;
            _color = color;
            _size = size;
            _brand = brand;
            _price = price;

            double temp = quantity * price;
            double temp2 = temp * (tax / 100);

            double temp3 = temp * (discount / 100);
            _linetotal = (temp + temp2) - temp3;


          
           
            _tax = tax;
        }



        public int ProductId
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
            }
        }

        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
            }
        }

        public string ProductImageUrl
        {
            get
            {
                return _productImageUrl;
            }
            set
            {
                _productImageUrl = value;
            }
        }


        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }


        public int quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }
        public double discount
        {
            get
            {
                return _discount;
            }
            set
            {
               _discount = value;
            }
        }
        public double price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
      
        public double Tax
        {
            get
            {
                return _tax;
            }
            set
            {
                _tax = value;
            }
        }


        public string Color
        {

            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public string Size
        {

            get
            {
                return _size;
            }
            set
            {

                _size = value;
            }
        }

        public string Brand
        {

            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
            }
        }

        public double Linetotal
        {
            get
            {
             
             

                if (_discount == 0)
                {
                    return (_quantity * _price) + ( (_quantity *_price)* (_tax/100));
                }
                else
                {
                    double temp=_quantity * _price;
                    double temp2 = temp * (_tax / 100);
                 
                    double temp3 = temp * (_discount / 100);
                    return (temp + temp2) - temp3;
                }
            }
        }
      


      
    }
}
