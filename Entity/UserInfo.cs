using System;

namespace Entity
{
	//定义用户实体
	[Serializable]
	public class UserInfo
	{
		public string? UserName { get; set; }
		public string? Password { get; set; }
	}
}
