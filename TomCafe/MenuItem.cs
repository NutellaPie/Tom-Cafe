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
            return String.Format("Name: {0}\tPrice: {1}\tProduct List: {2}", Name, Price, ProductList);
        }
    }
}
