using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using System.Linq;

namespace UnimOs.Service
{
    public static class Convert
    {
        public static List<T> ToList<T>(DataTable dt)
        {
            List<T> lst = new System.Collections.Generic.List<T>();
            Type tClass = typeof(T);
            PropertyInfo[] pClass = tClass.GetProperties();
            T cn = default(T);
            //var list =dt.Select().ToList();
            foreach (DataRow item in dt.Rows)
            {
                cn = Activator.CreateInstance<T>();

                foreach (PropertyInfo pc in pClass)
                {
                    if (dt.Columns.Contains(pc.Name))
                    {
                        if (item[pc.Name] != System.DBNull.Value)
                        {
                            //System.Convert.ChangeType(item[pc.Name], pc.PropertyType);
                            //pc.SetValue(cn, item[pc.Name], null);

                            if (pc.PropertyType.FullName.ToString()=="System.Single")
                            {
                                pc.SetValue(cn, System.Convert.ChangeType(item[pc.Name], pc.PropertyType), null);
                            }
                            else
                            {
                                pc.SetValue(cn, item[pc.Name], null);
                            }
                        }
                    }
                    else
                    {
                        
                    }
                }
                lst.Add(cn);
            }
            return lst;
        }
    }
}