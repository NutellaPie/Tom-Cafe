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

        
    }
}
