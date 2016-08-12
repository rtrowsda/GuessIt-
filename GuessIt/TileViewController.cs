using Foundation;
using System;
using UIKit;

namespace GuessIt
{
    public partial class TileViewController : UIViewController
	{

		#region background app functions
		partial void ShowHideInfo(UIButton sender)
		{
			if (WebView1.Hidden == true)
				WebView1.Hidden = false;
			else
				WebView1.Hidden = true;
		}
		public void SetWeb()
		{
			WebView1.LoadRequest(new NSUrlRequest(new NSUrl("TileInfo.html", false)));
			WebView1.ScalesPageToFit = false;
		}
		partial void DismissView(UIButton sender)
		{
			DismissViewController(true, completionHandler: null);
		}
		#endregion


		#region Basic app functions
		public TileViewController (IntPtr handle) : base (handle)
        {
        }

		public TileViewController()
		{
		}

		public override void ViewDidLoad()
		{
			SetWeb();
			base.ViewDidLoad();
		}
		#endregion
    }
}