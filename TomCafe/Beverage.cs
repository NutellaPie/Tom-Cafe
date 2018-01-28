using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCafe
{
    class Beverage : Product
    {
        //Create properties
        private double tradeIn;

        public double TradeIn
        {
            get { return tradeIn; }
            set { tradeIn = value; }
        }

        //Create constructors
        public Beverage() { }

        public Beverage(string n, double p, double ti) : base(n, p)
        {
            TradeIn = ti;
        }

        //Create methods
        public override double GetPrice()
        {
            if ((Price - TradeIn) > 0)
            {
                return Price - TradeIn;
            }
            else
            {
                return 0.00;
            }

        }

        // Method to clone Beverage
        public Beverage Copy()
        {
            return new Beverage(this.Name, this.Price, this.TradeIn);
        }

        public override string ToString()
        {
            return String.Format("{0}\n${1:0.00}", Name, GetPrice());
        }

    }
}
