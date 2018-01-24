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
            itemList.RemoveAt(index);
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
            String OrderList = "";
            foreach (OrderItem o in ItemList)
            {
                OrderList += String.Format("{0} {1} ${2:0.00}", o.Quantity.ToString().PadRight(5), o.Item.Name.PadRight(30), o.GetItemTotalAmt()) + "\n";
            }

            return String.Format("Receipt #{0}\n{1:dd/MM/yyyy HH:mm}\n\n{2}\n{3}${4:0.00}", OrderNo.ToString().PadLeft(5, '0'), DateTime.Now, OrderList, "Total".PadRight(37), GetTotalAmt());
        }

    }
}
