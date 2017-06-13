using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSmartHouse.ViewModels.AdaptInterfacies
{
    public interface IIncDecChannelAble
    {
        int Channel { get; set; }
        void IncreaseChannel();
        void DecreaseChannel();
    }
}