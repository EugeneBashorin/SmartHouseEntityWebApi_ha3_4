using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSmartHouse.ViewModels.AdaptInterfacies
{
   public interface IWarmModeAble
    {
         void SetMaxMode();
         void SetMiddleMode();
         void SetMinMode();
         void SetAutoMode();
    }
}
