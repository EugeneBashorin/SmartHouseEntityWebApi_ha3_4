using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
   public interface IListOrderAble
    {
        string ShowList(List<string> tempList, string tempListString);
        void ListLoad(List<string> tempListLoad, string tempListLocation);
    } 
}
