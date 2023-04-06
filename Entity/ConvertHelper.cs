using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
namespace Entity
{
	public class ConvertHelper        //查询结果转换成泛型集合  
	{
		public static IList<T> convertToList<T>(DataTable dt) where T : new()
		{
			List<T> ts = new List<T>();
			string tempName = "";

			foreach (DataRow dr in dt.Rows)
			{
				T t = new T();
				PropertyInfo[] propertys = t.GetType().GetProperties();
				foreach (PropertyInfo pi in propertys)
				{
					tempName = pi.Name;
					if (dt.Columns.Contains(tempName))
					{
						if (!pi.CanWrite)
						{
							continue;
						}
						object value = dr[tempName];

						if (value != null)
						{
							pi.SetValue(t, value, null);
						}
					}
				}
				ts.Add(t);
			}
			return ts;
		}
	}
}
