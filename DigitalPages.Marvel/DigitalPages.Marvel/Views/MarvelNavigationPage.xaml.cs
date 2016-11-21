using Prism.Navigation;
using Xamarin.Forms;

namespace DigitalPages.Marvel.Views
{
	public partial class MarvelNavigationPage : NavigationPage
	{
		public MarvelNavigationPage()
			:base(new MainPage())
		{
			InitializeComponent();
		}
	}
}

