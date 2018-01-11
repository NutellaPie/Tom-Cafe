using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCafe
{
    class OrderItem
    {
        //Properties
        private int quantity;
        private MenuItem item;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public MenuItem Item
        {
            get { return item; }
            set { item = value; }
        }

        //Constructors
        public OrderItem() { }
        public OrderItem(MenuItem i)
        {
            Item = i;
        }

        //Methods
        public void AddQty()
        {
            Quantity += 1;
        }
        public bool RemoveQty()
        {
            if (Quantity >= 1)
            {
                Quantity -= 1;
                return true;
            }
            else
            {
                return false;
            }
        }
        public double GetItemTotalAmt()
        {
            return Item.Price * Quantity;
        }
        public override string ToString()
        {
            return String.Format("Quantity: {0}\tItem: {1}", Quantity, Item);
        }
    }
}
