using System;
using System.Collections.Generic;
using System.Web;
using ZartCartItem;
/// <summary>
/// Summary description for ShoppingCart
/// </summary>
/// 
namespace ZartShopping
{
    [Serializable]
    public class ShoppingCart
    {
        private DateTime _dateCreated;
        private DateTime _lastUpdated;
        private List<CartItem> _items;

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

           public void discount( double d)
        {
            CartItem NewItem = new CartItem();
            if (d == 0)
            {
                NewItem.discount =1;
                _lastUpdated = DateTime.Now;
            }
            else
            {
                NewItem.discount = d;
                _lastUpdated = DateTime.Now;
            }
        }

        public void Insert(int ProductID, string name, string pimage,int quantity, double discount, string color, string size, string brand ,double price, double tax)
        {
            int ItemIndex = ItemIndexOfID(ProductID);
            if (ItemIndex == -1)
            {
                CartItem NewItem = new CartItem();
                NewItem.ProductId = ProductID;
                NewItem.ProductName = name;
                NewItem.ProductImageUrl = pimage;
                NewItem.quantity = quantity;
                NewItem.discount = discount;
                NewItem.Color = color;
                NewItem.Size = size;
                NewItem.Brand = brand;
                NewItem.price = price;
            
                NewItem.Tax = tax;
                _items.Add(NewItem);
            }
            else
            {
              
                _items[ItemIndex].quantity =_items[ItemIndex].quantity + quantity;
            }
            _lastUpdated = DateTime.Now;
        }
        

        public void updatetest(double tax,double shipping)
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
            _lastUpdated = DateTime.Now;
        }
        
        public void QtyUpdate(int RowID, int ProductID, int quantity)
        {
            CartItem Item = _items[RowID];
            Item.ProductId = ProductID;
            Item.quantity = quantity;
        
            _lastUpdated = DateTime.Now;
        }
        public void ColorUpdate(int RowID, int ProductID, string color)
        {
            CartItem Item = _items[RowID];
            Item.ProductId = ProductID;
            Item.Color = color;

            _lastUpdated = DateTime.Now;
        }
        public void SizeUpdate(int RowID, int ProductID, string size)
        {
            CartItem Item = _items[RowID];
            Item.ProductId = ProductID;
            Item.Size = size;

            _lastUpdated = DateTime.Now;
        }
        public void Update1(double discount)
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

    
        public double Total
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
        
    }
    }

