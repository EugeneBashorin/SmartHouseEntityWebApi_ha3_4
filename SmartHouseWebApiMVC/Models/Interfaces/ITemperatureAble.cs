using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
  public interface ITemperatureAble
    {
        int Temperature { get; set; }
        void IncreaseTemperature();
        void DecreaseTemperature();
        void HandSetTemperature(int inputData);
    }
}
