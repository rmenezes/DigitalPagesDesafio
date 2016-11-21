using Acr.UserDialogs;
using DigitalPages.Marvel.Views;
using Prism.Unity;
using Microsoft.Practices.Unity;

namespace DigitalPages.Marvel
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) 
			: base(initializer) 
		{ 
		}

		protected override void OnInitialized()
		{
			InitializeComponent();

			//NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
			NavigationService.NavigateAsync("MarvelNavigationPage");
		}

		protected override void RegisterTypes()
		{
			//Container.RegisterTypeForNavigation<MasterDetailPage>();
			Container.RegisterTypeForNavigation<MarvelNavigationPage>();
			Container.RegisterTypeForNavigation<MainPage>();
			Container.RegisterTypeForNavigation<DetailsPage>();

			Container.RegisterInstance<IUserDialogs>(UserDialogs.Instance);
		}
	}
}

