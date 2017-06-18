using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
   public class Parametr : IParametrAble
    {
        public int Max { get;}       
        public int Min { get;}
        public /*private*/ int current;//Special to WEBApi
        public int Current
        {
            get {return current;}
            set {if (Max < value)
                {
                    current = Max;
                }
                else if (Min > value)
                {
                    current = Min;
                }
                else
                {
                    current = value;
                }
            }
        }
        
        public Parametr(int min, int max, int current)
        {
            Min = min;
            Max = max;
            Current = current;
        }
    }
}

