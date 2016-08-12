// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace GuessIt
{
    [Register ("TileViewController")]
    partial class TileViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIWebView WebView1 { get; set; }

        [Action ("DismissView:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DismissView (UIKit.UIButton sender);

        [Action ("ShowHideInfo:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ShowHideInfo (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (WebView1 != null) {
                WebView1.Dispose ();
                WebView1 = null;
            }
        }
    }
}