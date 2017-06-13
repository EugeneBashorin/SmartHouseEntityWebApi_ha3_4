using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
     interface IChannelAble
    {
        int Channel { get; set; }
        void IncreaseChannel();
        void DecreaseChannel();
        void HandSetChannel(int inputData);
    }
}
