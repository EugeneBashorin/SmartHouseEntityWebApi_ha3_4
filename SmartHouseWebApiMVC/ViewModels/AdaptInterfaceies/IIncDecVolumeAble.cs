using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSmartHouse.ViewModels.AdaptInterfacies
{
    public interface IIncDecVolumeAble
    {
        int Volume { get; set; }
        void IncreaseVolume();
        void DecreaseVolume();
    }
}
