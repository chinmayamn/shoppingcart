using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce.Models
{
    public class Ecom
    {

    }
    public class Product
    {
        private int id;
        private string name;
        private string image;
        private string category;
        private double price;
        private double discount;
        private string rating;
        private string desc;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public string Category { get => category; set => category = value; }
        public double Price { get => price; set => price = value; }
        public double Discount { get => discount; set => discount = value; }
        public string Rating { get => rating; set => rating = value; }
        public string ProdDesc { get => desc; set => desc = value; }
    }

    [Serializable]
    public class CartItem
    {
        private int _rowid;
        private int _productID;
        private string _productName;
        private string _productImageUrl;
        private int _quantity;
        private double _price;
        private double _linetotal;
        private string _date;
        private double _discount;

        public void New()
        {

        }
        public void New(int productId, string productName, string productImage, double price, int quantity, double discount)
        {
            _productID = ProductId;
            _productName = ProductName;
            _productImageUrl = productImage;
            _quantity = quantity;
            _price = price;
            if(discount==0)
                _linetotal = quantity * price;
            else
            _linetotal = quantity * (price * discount);

        }
        [Key]
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
        public int RowId
        {
            get
            {
                return _rowid;
            }
            set
            {
                _rowid = value;
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

        public double Linetotal
        {
            get
            {
                // return (_quantity * _price) + (_tax * _quantity)+(_shipping*Quantity);
                if (_discount == 0)
                {
                    return (_quantity * _price);
                }
                else
                {
                    double temp = _quantity * _price;
                    double temp1 = (temp * _discount) / 100;
                    return temp - temp1;

                }
            }
        }
        
    }

    [Serializable]
    public class ShoppingCart
    {
        private DateTime _dateCreated;
        private DateTime _lastUpdated { get; set; }
        private List<CartItem> _items;
        public double DeliveryCharge { get; set; }
        public double FinalDiscount { get; set; }
        public double GST { get; set; }
      
        public ShoppingCart()
        {
            if (this._items == null)
            {
                this._items = new List<CartItem>();
                this._dateCreated = DateTime.Now;
            }
        }

        public List<CartItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        public void discount(double d)
        {
            CartItem NewItem = new CartItem();
            if (d == 0)
            {
                NewItem.discount = 1;
                _lastUpdated = DateTime.Now;
            }
            else
            {
                NewItem.discount = d;
                _lastUpdated = DateTime.Now;
            }
        }

        public void Insert(int ProductID, string name, string pimage, double price, int quantity, double discount)
        {
            int ItemIndex = ItemIndexOfID(ProductID);
            if (ItemIndex == -1)
            {
                CartItem NewItem = new CartItem();
                NewItem.ProductId = ProductID;
                NewItem.quantity = quantity;
                NewItem.price = price;
                NewItem.ProductName = name;
                NewItem.ProductImageUrl = pimage;
                NewItem.discount = discount;
               
                _items.Add(NewItem);
            }
            else
            {

                _items[ItemIndex].quantity = _items[ItemIndex].quantity + quantity;
            }
            _lastUpdated = DateTime.Now;
        }


        public void UpdateTax(double tax, double shipping)
        {
            foreach (CartItem Item in _items)
            {
            }
        }
        public void Update(int RowID, int ProductID, int quantity, double price)
        {
            CartItem Item = _items[RowID];
            Item.ProductId = ProductID;
            Item.quantity = quantity;
            Item.price = price;
            _lastUpdated = DateTime.Now; ;
        }
        public void QuantityUpdate(int RowID, int ProductID, int quantity)
        {
            CartItem Item = _items[RowID];
            Item.ProductId = ProductID;
            Item.quantity = quantity;

            _lastUpdated = DateTime.Now;
        }
        public void UpdateDiscount(double discount)
        {
            foreach (CartItem item in _items)
            {
                item.discount = discount;

            }
            _lastUpdated = DateTime.Now;
        }

        public void UpdateDate(string date)
        {
            foreach (CartItem item in _items)
            {
                item.Date = date;

            }
            _lastUpdated = DateTime.Now;
        }


        public void DeleteItem(int rowID)
        {
            _items.RemoveAt(rowID);
            _lastUpdated = DateTime.Now;
        }

        private int ItemIndexOfID(int ProductID)
        {
            int index = 0;
            foreach (CartItem item in _items)
            {
                if (item.ProductId == ProductID)
                {
                    return index;
                }
                index += 1;
            }
            return -1;
        }

        public double SubTotal
        {
            get
            {
                double t = 0;

                if (_items == null)
                {
                    return 0;
                }
                foreach (CartItem Item in _items)
                {
                    t += Item.Linetotal;
                }
                return t;
            }
        }

        public double FinalTotal
        {
            get
            {
                double t = 0;

                if (_items == null)
                {
                    return 0;
                }
                foreach (CartItem Item in _items)
                {
                    t += Item.Linetotal;
                }

                t = t + DeliveryCharge + FinalDiscount + GST;
                return t;
            }
        }
    }

    //implementing interface
    interface IShopCore
    {
        ActionResult MyOrders();
        ActionResult Cart();
    }

}