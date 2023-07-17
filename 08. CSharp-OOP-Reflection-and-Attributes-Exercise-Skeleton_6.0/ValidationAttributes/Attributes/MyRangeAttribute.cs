using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes
{
    public  class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public int MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }


        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        public override bool IsValid(object obj)
      => (int)obj >= minValue && (int)obj < maxValue;
    }
}
