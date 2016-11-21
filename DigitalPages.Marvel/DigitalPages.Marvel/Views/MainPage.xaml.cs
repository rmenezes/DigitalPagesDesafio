using DigitalPages.Marvel.Core.Models;
using DigitalPages.Marvel.ViewModels;
using Xamarin.Forms;

namespace DigitalPages.Marvel.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Desde que o Xamarin.Forms não tem os Commands para cada funcionalidade, é necessário 
		/// gerar um através do binding direto do evento
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public void Handle_TextChanged(object sender, TextChangedEventArgs e)
		{
			var bindingContext = (BindingContext as MainPageViewModel);
			bindingContext?.SearchCommand?.Execute(null);
		}

		public void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var bindingContext = (BindingContext as MainPageViewModel);
			bindingContext?.ItemTappedCommand?.Execute((Character)e.Item);
		}
	}
}

