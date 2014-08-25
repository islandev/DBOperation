using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBOperation.Resource;
using DBOperation.Class;
using System.Reflection;
using System.Text.RegularExpressions;


namespace DBOperation.Class
{
  public  static class IniBeanWriter
    {
      public static void WriteCfg(this IParamBean bean, string filePath)
      {
          var raw =
              new ReadAndWriteIniFilesClass(filePath);

          string typeName = bean.GetType().Name;
          PropertyInfo[] propInfos =
              bean.GetType().GetProperties();

          if (propInfos.Select(x => x.Name.Equals("Title")) == null)
              throw new Exception("头信息必须存在！");
          else
          {
              typeName = bean.Title;
          }
          foreach (PropertyInfo prop in propInfos)
          {
              if (!prop.Name.Equals("Title") || !prop.Name.Equals("Path"))
              {
                  var attr =
                      (ParamAttribute)(Attribute.GetCustomAttribute(prop, typeof(ParamAttribute)));

                  string paramName = string.Empty;
                  if (attr == null) continue;
                  if (string.IsNullOrEmpty(attr.ParamName))
                  {
                      paramName = prop.Name;
                  }
                  else
                  {
                      paramName = attr.ParamName;
                  }
                  if (prop.GetType().ToString().Equals("System.Int32"))
                  {
                      raw.WriteInteger(
                          attr.ParamType,
                          paramName,
                          Int32.Parse(prop.GetValue(bean, null).ToString())
                          );
                  }
                  else if (prop.GetType().ToString().Equals("System.DateTime"))
                  {
                      raw.WriteString(
                          attr.ParamType,
                          paramName,
                          ((DateTime)(prop.GetValue(bean, null))).ToString("YYYY-mm-DD")
                          );
                  }
                  else if (prop.GetValue(bean, null) != null)
                  {
                      var value = prop.GetValue(bean, null).ToString();
                      if (Regex.IsMatch(value, @"\\"))
                          value = Regex.Replace(value, @"\\", "\\\\");                 // 替换路径分割符
                      raw.WriteString(
                          attr.ParamType,
                          paramName,
                          value
                          );
                  }
              }
          }
      }
    }
}
