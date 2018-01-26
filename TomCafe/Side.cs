using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCafe
{
    class Side:Product
    {
        //Constructors
        public Side() { }
        public Side(string n, double p) : base(n, p) { }

        //Methods
        public override double GetPrice()
        {
            return Price;
        }
        public override Product Copy()
        {
            return new Side(this.Name, this.Price);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
