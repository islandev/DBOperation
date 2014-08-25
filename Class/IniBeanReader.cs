using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBOperation.Resource;



namespace DBOperation.Class
{
  public static class IniBeanReader
    {
        public static IParamBean ReadCfg(this IParamBean bean, string filePath)
        {
            var raw =
                new ReadAndWriteIniFilesClass(filePath);

            try
            {
                var propertyInfos =
                    bean.GetType().GetProperties();
                
                foreach (var prop in propertyInfos)
                {
                    var attr =
                            (ParamAttribute)(Attribute.GetCustomAttribute(prop, typeof(ParamAttribute)));

                    if (attr.ParamName == null)
                    {

                        if (prop.ToString().Equals("System.String" + " " + prop.Name))
                        {
                            var str = raw.ReadString(attr.ParamType, prop.Name, string.Empty);
                            str = str.Replace(@"\\", @"\");
                            prop.SetValue(bean, str, null);
                        }
                        else if (prop.ToString().Equals("Int32" + " " + prop.Name))
                        {
                            prop.SetValue(
                                    bean, raw.ReadInteger(attr.ParamType, prop.Name, 0), null
                                );
                        }
                        else
                        {
                            prop.SetValue(
                                    bean, Double.Parse(raw.ReadString(attr.ParamType, prop.Name, "0.0")), null
                                );
                        }
                    }
                    else
                    {
                        if (prop.ToString().Equals("System.String" + " " + prop.Name))
                        {
                            var str = raw.ReadString(attr.ParamType, attr.ParamName, string.Empty);
                            str = str.Replace(@"\\", @"\");
                            prop.SetValue(bean, str, null);
                        }
                        else if (prop.ToString().Equals("Int32" + " " + prop.Name))
                        {
                            prop.SetValue(
                                    bean, raw.ReadInteger(attr.ParamType, attr.ParamName, 0), null
                                );
                        }
                        else
                        {
                            prop.SetValue(
                                    bean, Double.Parse(raw.ReadString(attr.ParamType, attr.ParamName, "0.0")), null
                                );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return bean;
            }
            return bean;
        }
    }
}
