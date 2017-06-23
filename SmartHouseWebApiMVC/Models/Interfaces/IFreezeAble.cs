using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseWebApiMVC.Models.Interfaces
{
    interface IFreezeAble<T>
    {
       T FreezeMode { get; set; }
    }
}
