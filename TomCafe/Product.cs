using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCafe
{
    abstract class Product
    {
        public Product() { }

        public Product(string n, double p)
        {
            Name = n;
            Price = p;
        }
    }
}
