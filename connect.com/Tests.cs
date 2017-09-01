using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace connect.com
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			app.Tap("button_sign_in");
			app.Screenshot("Let's start by Tapping the 'Sign in' Button");

			app.Tap("dgts__countryCode");
			app.Screenshot("Then, we Tapped on the 'Country Code' Button");

			app.Tap("Denmark +45");
			app.Screenshot("We Tapped on our country code, Denmark");

			app.EnterText("38 15 38 15");
			app.Screenshot("Next, we entered in our phone number");

			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap("dgts__state_button");
			app.Screenshot("Then, we Tapped the 'Send Code' Button");

			Thread.Sleep(30000);
			app.EnterText("232323");
			app.Screenshot("We entered in our code");

			app.Tap("dgts__state_button");
			app.Screenshot("We Tapped on the 'Create Account' Button");
		}



	}
}
