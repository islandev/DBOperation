using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DBOperation.Config
{
    public   class VariblesPool
    {
        private static VariblesPool _pool = null;
        private IDictionary<string, object> VarTable { set; get; }
        private VariblesPool()
        {
            VarTable = new Dictionary<string, object>();
        }
        public static VariblesPool GetVariblesPool()
        {
            var key = new object();
            if (_pool==null)
            {
                lock (key)  
                {
                    _pool = new VariblesPool();
                }
            }
            return _pool;
        }
        public void SetVaribles(string name,object value)
        {
            if (!VarTable.ContainsKey(name))
            {
                VarTable.Add(name, value);
            }
            else VarTable[name]=value;
         }
        public object GetVarible(string name)
        {
            if (!VarTable.ContainsKey(name))
            {
                return null;
            }
            else return VarTable[name];
        }
        public void ClearVarible(string name)
        {
            if (VarTable.ContainsKey(name))
                VarTable.Remove(name);
        }
        public bool IsContainName(string name)
        {
            if (VarTable.ContainsKey(name))
                return true;
            else return false;
        }
       /// <summary>
       /// 检查数据是否为空//未完成
       /// </summary>
       /// <returns></returns>
        public bool CheckVarible()
        {
            
            foreach (var kvp in VarTable)
            {
                Type t = kvp.Value.GetType();
                
             

                
           }
            return true;
        }
    }
}
