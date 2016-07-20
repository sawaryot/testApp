using System;

using UIKit;

// 以下追加分
using Foundation;
//using CoreGraphics;

// 追加分終了

namespace testApp.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			Button.AccessibilityIdentifier = "myButton";
			Button.TouchUpInside += delegate
			{
				var title = string.Format("{0} clicks!", count++);
				Button.SetTitle(title, UIControlState.Normal);
			};

			//以下追加分
			/*
			CalcButton.TouchUpInside += (sender, e) =>
			{
				double d;
				if (Double.TryParse(PriceText.Text, out d))
					TotalPriceText.Text = string.Format("{0}円", MyClass.GetTax(d));
			};
			*/
			// 追加分終了

			//以下追加分
			string translatedNumber = "";
			TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				// Convert the phone number with text to a number 
				// using PhoneTranslator.cs
				translatedNumber = testApp.iOS.PhoneTranslator.ToNumber(
				PhoneNumberText.Text);
				// Dismiss the keyboard if text field was tapped
				PhoneNumberText.ResignFirstResponder();
				if (translatedNumber == "")
				{
					CallButton.SetTitle("Call", UIControlState.Normal);
					CallButton.Enabled = false;
				}
				else {
					CallButton.SetTitle("Call " + translatedNumber, UIControlState.Normal);
					CallButton.Enabled = true;
				}
			};
			// 追加分終了

			// 以下追加分
			CallButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				var url = new NSUrl("tel:" + translatedNumber);
				// Use URL handler with tel: prefix to invoke Apple's Phone app, 
				// otherwise show an alert dialog                
				if (!UIApplication.SharedApplication.OpenUrl(url))
				{
					var av = new UIAlertView("Not supported",
								"Scheme 'tel:' is not supported on this device",
								null,
								"OK",
								null);
					av.Show();
				}
			};
			// 追加分終了


		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
