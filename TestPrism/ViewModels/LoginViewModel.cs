using DryIoc;
using IBLL;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace TestPrism.ViewModels
{
	public class LoginViewModel : BindableBase
	{

		private Model.User _userInfo;

		public Model.User UserInfo
		{
			get { return _userInfo; }
			set { SetProperty(ref _userInfo, value); }
		}


		private Entity.UserInfo _user;

		public Entity.UserInfo User
		{
			get { return _user; }
			set { SetProperty(ref _user, value); }
		}


		public DelegateCommand LoginCommand { get; set; }
		public DelegateCommand LogoutCommand { get; set; }



		public LoginViewModel()
		{
			//UserInfo = new Model.User();
			User = new Entity.UserInfo();

			LoginCommand = new DelegateCommand(Login);
			LogoutCommand = new DelegateCommand(Logout);
		}


		void Login()
		{
			try
			{
				//Entity.UserInfo user = new Entity.UserInfo();
				//user.UserName = UserInfo.UserName;
				//user.Password = UserInfo.Password;
				//Factory.FactoryBLL bllfact = new Factory.FactoryBLL();
				IBLL.IUserBLL ibll = new BLL.UserBLL();//=bllfact.CreateBLL();

				if (ibll.Login(User))
				{
					MessageBox.Show("登陆成功");
				}
				else
				{
					MessageBox.Show("登陆错误");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		void Logout()
		{
			Environment.Exit(0);
		}


		////////*****************************************************
		//private void button1_Click(object sender, EventArgs e)
		//{
		//	if (UserTxt.Text == "")
		//	{
		//		MessageBox.Show("用户名为空");
		//	}
		//	if (PwdTxt.Text == "")
		//	{
		//		MessageBox.Show("密码为空");
		//	}
		//	try
		//	{
		//		Entity.UserInfo user = new Entity.UserInfo();
		//		user.UserName = UserTxt.Text.Trim();
		//		user.Password = PwdTxt.Text;
		//		Factory.FactoryBLL bllfact = new Factory.FactoryBLL();
		//		IBLL.IUserBLL ibll = bllfact.CreateBLL();
		//		if (ibll.Login(user))
		//		{
		//			UserTxt.Clear();
		//			PwdTxt.Clear();
		//			MessageBox.Show("登陆成功");
		//		}
		//		else
		//		{

		//			UserTxt.Clear();
		//			PwdTxt.Clear();
		//			MessageBox.Show("登陆错误");
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show(ex.ToString());
		//	}
		//}

		//private void button2_Click(object sender, EventArgs e)
		//{
		//	Application.Exit();
		//}








	}
}
