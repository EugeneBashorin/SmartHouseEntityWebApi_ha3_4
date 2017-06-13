using MVCSmartHouse.ViewModels.AdaptInterfacies;
using SimpleSmartHouse1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSmartHouse.ViewModels.AdaptModels
{
    class NewRadio: Radio, IHandSetRadioChannelAble, IHandSetRadioVolumeAble, IIncDecVolumeAble, IShowLoadListAble, IIncDecChannelAble
    {
        public NewRadio(string name, bool state, IParametrAble channelParam, IParametrAble volumeParam, IChangeSettingAble changeParams, IListOrderAble listFunction) : base (name, state,  channelParam,  volumeParam, changeParams, listFunction)
        {
            State = state;
            ChannelParam = channelParam;
            VolumeParam = volumeParam;
            ChangeParams = changeParams;
            ListFunction = listFunction;
        }
    }
}