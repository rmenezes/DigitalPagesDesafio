﻿using DigitalPages.Marvel.Core;
using DigitalPages.Marvel.Core.Interfaces;
using DigitalPages.Marvel.iOS.Services;
using Foundation;
using Microsoft.Practices.Unity;
using Prism.Unity;
using UIKit;

namespace DigitalPages.Marvel.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App(new iOSInitializer()));

			// Bug: Xamarin.Forms.Theme -> Could not file or assembly
			var x = typeof(Xamarin.Forms.Themes.LightThemeResources);
			x = typeof(Xamarin.Forms.Themes.iOS.UnderlineEffect);

			return base.FinishedLaunching(app, options);
		}
	}

	public class iOSInitializer : IPlatformInitializer
	{
		public void RegisterTypes(IUnityContainer container)
		{
			container.RegisterType<IMarvelService, MarveliOSService>();
			//container.RegisterType<IMarvelService, MarvelMockData>();
		}
	}
}
