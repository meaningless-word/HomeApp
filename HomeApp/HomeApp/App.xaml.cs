using Xamarin.Forms;
using HomeApp.Pages;

namespace HomeApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new LoginPage()); // прицепляем навигацию
			/*DeviceGroupListPage();*/
			/*DeviceListPage();*/
			/*BindingModePage();*/
			/*BindingPage();*/
			/*NewDevicePage();*/
			/*DeviceControlPage();*/
			/*RegisterPage();*/
			/*GridXamledPage();*/
			/*GridPage();*/
			/*AboutPage();*/
			/*ClimatePage();*/
			/*DevicesPage();*/
			/*LoginPage();*/
			/*SpanPage();*/
			/*LoadingPage();*/
			/*MainPage();*/
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
