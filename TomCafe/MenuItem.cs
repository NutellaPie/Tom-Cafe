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
        private List<Product> productList = new List<Product> { };

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
            int Index = ProductList.FindIndex(x => x is Beverage);
            // To only add price during trade in of bundle meal
            if ((Index != -1) && (ProductList.Count > 1) && (Name != "Customise Bundle"))
            {
                return Price + ProductList[Index].GetPrice();
            }
            return Price;
        }

        public MenuItem Copy()
        {
            MenuItem m = new MenuItem(this.Name, this.Price);
            foreach (Product p in this.ProductList)
            {
                m.ProductList.Add(p);
            }
            return m;
        }

        public override string ToString()
        {
            if (Name == "Customise Bundle")
            {
                return String.Format("Customise Bundle\n(One Value Meal, One Side, One Beverage)\nGet 10% off regular prices");
            }
            else
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
}
