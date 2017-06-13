using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
   public interface IChangeSettingAble
    {
        int Increase(int temperature);
        int Decrease(int temperature);
        int HandSet(int temperature);
    }
}
