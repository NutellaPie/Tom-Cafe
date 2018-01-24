using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCafe
{
    class Order
    {
        //Create properties
        private int orderNo;

        public int OrderNo
        {
            get { return orderNo; }
            set { orderNo = value; }
        }

        private List<OrderItem> itemList = new List<OrderItem>();

        public List<OrderItem> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }

        //Create constructors
        public Order() { }

        public void Add(OrderItem oi)
        {
            ItemList.Add(oi);
        }

        public void Remove(int index)
        {
            itemList[index].Quantity -= 1;
        }

        public double GetTotalAmt()
        {
            double price = 0;

            foreach (OrderItem o in ItemList)
            {
                price += o.GetItemTotalAmt();
            }

            return price;
        }

        public override string ToString()
        {
            return base.ToString() + "Order Number: " + OrderNo + "Item List: " + ItemList;
        }

    }
}
