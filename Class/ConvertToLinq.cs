using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DBOperation.Resource;

namespace DBOperation.Class
{
   public class ConvertToLinq
    {
       private SearchBean searchBean;
       private Dictionary<string,Object> searchDic;
       public ConvertToLinq(SearchBean src)
       {
           this.searchBean = src;
       }
      
    }
}
