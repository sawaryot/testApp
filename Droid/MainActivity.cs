using Android.App;
using Android.Widget;
using Android.OS;

namespace testApp.Droid
{
	[Activity(Label = "testApp", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

			button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

			// 以下追加分
			var totalPriceText = FindViewById<TextView>(Resource.Id.TotalPriceText);
			var priceText = FindViewById<EditText>(Resource.Id.PriceText);
			var calcButton = FindViewById<Button>(Resource.Id.CalcButton);
			calcButton.Click += (sender, e) =>
			{
				double d;
				if (double.TryParse(priceText.Text, out d))
				{
					totalPriceText.Text = string.Format("{0}円", MyClass.GetTax(d);
				}
			};
			// 追加分終了

		}
	}
}