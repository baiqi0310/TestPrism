using System;
using System.Collections.Generic;
using System.Reflection;

namespace BLL
{
	public class UserBLL : IBLL.IUserBLL
	{
		public bool Login(Entity.UserInfo user)
		{
			//Factory.FactoryDAL fact = new Factory.FactoryDAL();
			IDAL.IUserDAL idal = new DAL.UserDAL();//fact.CreateDAL();
			IList<Entity.UserInfo> userList = idal.GetAll(user);
			bool flag;
			if (userList.Count == 1)
			{
				flag = true;
			}
			else
			{
				flag = false;
			}
			return flag;
		}
	}

}
