using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
   public interface IParametrAble
    {
        int Max { get;}
        int Min { get;}
        int Current { get; set; }
    }
}
