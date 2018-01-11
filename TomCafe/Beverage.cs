using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCafe
{
    class Beverage:Product
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

        public Beverage(string n, double p, double ti):base(n, p, ti)
        {
            TradeIn = ti;
        }

        public override double GetPrice()
        {
            return Price;
        }

        public override string ToString()
        {
            return TradeIn + base.ToString() + "\tTrade in amount $";
        }

    }
}
