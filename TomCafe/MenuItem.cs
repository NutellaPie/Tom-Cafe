using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCafe
{
    class MenuItem
    {
        //Properties
        private string name;
        private double price;
        private List<Product> productList;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public List<Product> ProductList
        {
            get { return productList; }
            set { productList = value; }
        }

        //Constructors
        public MenuItem() { }
        public MenuItem(string n, double p)
        {
            Name = n;
            Price = p;
        }

        //Methods
        public double GetTotalPrice()
        {
            return Price;
        }

        public override string ToString()
        {
            String Items = "";
            foreach (Product p in ProductList)
            {
                Items += p.Name + ", ";
            }

            Items = Items.Trim(' ').Trim(',');

            return String.Format("{0}\n({1})\n${2:0.00}", Name, Items, Price);
        }
    }
}
