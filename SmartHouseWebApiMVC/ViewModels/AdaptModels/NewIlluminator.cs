using MVCSmartHouse.ViewModels.AdaptInterfacies;
using SimpleSmartHouse1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSmartHouse.ViewModels.AdaptModels
{
    class NewIlluminator: Illuminator, IlluminatorModeAble
    {
        private IlluminatorBrightness bright;

        public NewIlluminator(string name, bool state, IlluminatorBrightness bright): base(name, state,bright)
        {
            Name = name;
            State = state;
            this.bright = bright;
        }
    }
}