using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSmartHouse.ViewModels.AdaptInterfacies
{
    public interface IIncDecTemperatureAble
    {
        int Temperature { get; set; }
        void IncreaseTemperature();
        void DecreaseTemperature();
    }
}