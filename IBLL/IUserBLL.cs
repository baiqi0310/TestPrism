using System;

namespace IBLL
{
	public interface IUserBLL
	{
		bool Login(Entity.UserInfo user);
	}
}
