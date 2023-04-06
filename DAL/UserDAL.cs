using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DAL
{
	public class UserDAL : IDAL.IUserDAL
	{
		public IList<Entity.UserInfo> GetAll(Entity.UserInfo user)
		{
			SqlHelperDAL sqlHelper = new SqlHelperDAL();
			string sql = "select *from User_Info where UserName=@UserName and Password=@Password";
			//SqlParameter[] sqlparams = { new SqlParameter("@UserName", user.UserName), new SqlParameter("@Password", user.Password) };

			SQLiteParameter[] sqliteParameters = { new SQLiteParameter("@UserName", user.UserName), new SQLiteParameter("@Password", user.Password) };

			return Entity.ConvertHelper.convertToList<Entity.UserInfo>(sqlHelper.ExecuteSQLList(sql, CommandType.Text, sqliteParameters));


		}
	}

}
