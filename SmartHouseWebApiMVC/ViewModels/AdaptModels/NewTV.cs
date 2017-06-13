using MVCSmartHouse.ViewModels.AdaptInterfacies;
using SimpleSmartHouse1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSmartHouse.ViewModels.AdaptModels
{
     class NewTV: TV, IHandSetTVChannelAble, IHandSetTVVolumeAble, IIncDecVolumeAble, IShowLoadListAble, IIncDecChannelAble, IMultimediaBrightAble
    {
        private BrightnessLevel bright { get; set; }
        public NewTV(string name, bool state, IParametrAble channelParam, IParametrAble volumeParam, IChangeSettingAble changeParams, BrightnessLevel bright, IListOrderAble listFunction) : base (name, state, channelParam, volumeParam, changeParams, bright, listFunction)
        {
            Name = name;
            State = state;
            ChannelParam = channelParam;
            VolumeParam = volumeParam;
            ChangeParams = changeParams;
            this.bright = bright;
            ListFunction = listFunction;
        }
    }
}