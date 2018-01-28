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
        private List<OrderItem> itemList = new List<OrderItem>();

        public int OrderNo
        {
            get { return orderNo; }
            set { orderNo = value; }
        }
        public List<OrderItem> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }

        //Create constructors
        public Order() { }
        public void Add(OrderItem oi)
        {
            // Check if selected item in already in the cart
            int index = 0;
            bool flag = false;
            string check = "";

            // Get names of all products in productlist
            foreach (Product p in oi.Item.ProductList)
            {
                check += p.Name;
            }

            // For every menuitem in itemlist, get the names of all products in productlist and compare against product to add
            for (int i = 0; i < ItemList.Count; i++)
            {
                string original = "";
                foreach (Product p in ItemList[i].Item.ProductList)
                {
                    original += p.Name;
                }
                if (check == original)
                {
                    flag = true;
                    index = i;
                    break;
                }
            }

            // If the product already exists in the cart
            if (flag)
            {
                ItemList[index].AddQty();
            }

            // If product does not exist in cart
            else
            {
                oi.AddQty();
                ItemList.Add(oi);
            }
        }
        public void Remove(int index)
        {
            if (itemList[index].RemoveQty()) { }

            else
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
            String Items = "";

            String Final = "";

            for (int i = 0; i < ItemList.Count; i++)
            {
                Items = "";

                if (itemList[i].Item.ProductList.Count > 1)
                {
                    foreach (Product p in ItemList[i].Item.ProductList)
                    {
                        Items += "\t  " + p.Name + "\n";
                    }
                }
                Final += String.Format("{0} {1}${2:0.00}\n{3}\n", ItemList[i].Quantity.ToString().PadRight(5), itemList[i].Item.Name.PadRight(27), ItemList[i].GetItemTotalAmt(), Items);
            }
            return String.Format("Receipt #{0}\n{1:dd/MM/yyyy HH:mm}\n\n{2}\n{3}${4:0.00}", OrderNo.ToString().PadLeft(5, '0'), DateTime.Now, Final, "Total".PadRight(33), GetTotalAmt());
        }
    }
}
