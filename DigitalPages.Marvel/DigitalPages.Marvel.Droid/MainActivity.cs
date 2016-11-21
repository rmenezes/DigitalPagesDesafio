using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using DigitalPages.Marvel.Core;
using DigitalPages.Marvel.Core.Interfaces;
using DigitalPages.Marvel.Droid.Services;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace DigitalPages.Marvel.Droid
{
	[Activity(Label = "DigitalPages.Marvel.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			// Acr.UserDialogs
			UserDialogs.Init(() => (Activity)Forms.Context);

			LoadApplication(new App(new AndroidInitializer()));

			// Bug: Xamarin.Forms.Theme -> Could not file or assembly
			var x = typeof(Xamarin.Forms.Themes.LightThemeResources);
			x = typeof(Xamarin.Forms.Themes.Android.UnderlineEffect);
		}
	}

	public class AndroidInitializer : IPlatformInitializer
	{
		public void RegisterTypes(IUnityContainer container)
		{
			container.RegisterType<IMarvelService, MarvelDroidService>();
			//container.RegisterType<IMarvelService, MarvelMockData>();
		}
	}
}
