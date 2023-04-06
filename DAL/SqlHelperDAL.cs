using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;
using System.Diagnostics.Metrics;
using System.Configuration;

namespace DAL
{
	public class SqlHelperDAL
	{
		public DataTable ExecuteSQLList(string cmdTxt, CommandType cmdType, SQLiteParameter[] param)
		{
			string StrDB = @"Data Source =D:\MyDB.db";
			string StrDB1 = ConfigurationManager.AppSettings["ConnStr"];
			SQLiteConnection conn = new SQLiteConnection(StrDB);
			SQLiteCommand cmd = new SQLiteCommand(cmdTxt, conn);
			cmd.CommandText = cmdTxt;
			cmd.CommandType = cmdType;
			cmd.Parameters.AddRange(param);
			DataTable dt = new DataTable();
			DataSet ataset = new DataSet();

			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();
				SQLiteDataAdapter adaptor = new SQLiteDataAdapter(cmd);
				adaptor.Fill(ataset);
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.ToString());
			}
			finally
			{
				conn.Close();
			}
			return ataset.Tables[0];

		}
	}

}
