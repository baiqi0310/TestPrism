using System;
using System.Collections.Generic;

namespace IDAL
{
	public interface IUserDAL
	{
		IList<Entity.UserInfo> GetAll(Entity.UserInfo user);
	}

}
