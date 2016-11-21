using Xamarin.Forms;

namespace DigitalPages.Marvel.Views
{
	public partial class DetailsPage : ContentPage
	{
		public DetailsPage()
		{
			InitializeComponent();
		}

		protected override void OnDisappearing()
		{
			Title = string.Empty;

			base.OnDisappearing();
		}

		protected override void OnAppearing()
		{
			Title = "Personagens";
			base.OnAppearing();
		}
	}
}

