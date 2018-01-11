using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCafe
{
    abstract class Product
    {
        //Properties
        private string name;
        private double price;

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

        //Constructors
        public Product() { }
        public Product(string n, double p)
        {
            Name = n;
            Price = p;
        }

        //Methods
        public abstract double GetPrice();
        public override string ToString()
        {
            return String.Format("Name: {0}\tPrice: {1}", Name, Price);
        }
    }
}
