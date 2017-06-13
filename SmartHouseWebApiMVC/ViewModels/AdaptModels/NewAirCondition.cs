using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleSmartHouse1._0;
using MVCSmartHouse.ViewModels.AdaptInterfacies;

namespace MVCSmartHouse.ViewModels.AdaptModels
{
    class NewAirCondition : AirCondition, IHandSetTempColdAble, IColdModeAble, IIncDecTemperatureAble
    {
        private Mode mode;       
        public NewAirCondition(string name, bool state, Mode mode, IParametrAble temperatureParam, IChangeSettingAble сhangeParams) : base(name, state, mode, temperatureParam, сhangeParams)
        {
            Name = name;
            State = state;
            this.mode = mode;
            TemperatureParam = temperatureParam;
            ChangeParams = сhangeParams;
        }
    }
}