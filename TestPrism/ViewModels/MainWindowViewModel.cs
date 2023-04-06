using Prism.Mvvm;
using Prism.Regions;
using TestPrism.Views;

namespace TestPrism.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private readonly IRegionManager _regionManager;
		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public MainWindowViewModel(IRegionManager regionManager)
		{
			this._regionManager = regionManager;
			regionManager.RegisterViewWithRegion("ContentRegion", typeof(LoginView));
		}
	}
}
