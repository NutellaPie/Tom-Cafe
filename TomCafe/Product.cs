using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCafe
{
    abstract class Product
    {
        private string name;
        private double prize;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Prize
        {
            get { return prize; }
            set { prize = value; }
        }
    }
}
