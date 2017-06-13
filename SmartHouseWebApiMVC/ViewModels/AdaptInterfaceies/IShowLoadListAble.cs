using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSmartHouse.ViewModels.AdaptInterfacies
{
    public interface IShowLoadListAble
    {
        void LoadChannel();
        string ShowChannelList();
    }
}