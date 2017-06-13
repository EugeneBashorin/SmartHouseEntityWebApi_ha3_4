using MVCSmartHouse.ViewModels.AdaptInterfacies;
using SimpleSmartHouse1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSmartHouse.ViewModels.AdaptModels
{
   public class NewHeater: Heater, IHandSetTempWarmAble, IWarmModeAble, IIncDecTemperatureAble
    {
        private Mode mode;
        public NewHeater()
        { }
        public NewHeater(string name, bool state, Mode mode, /*IParametrAble*/ Parametr temperatureParam, /*IChangeSettingAble*/ChangeSetting сhangeParams) : base(name, state, mode, temperatureParam, сhangeParams)
        {
            Name = name;
            State = state;
            this.mode = mode;
            TemperatureParam = temperatureParam;
            ChangeParams = сhangeParams;
        }
    }
}