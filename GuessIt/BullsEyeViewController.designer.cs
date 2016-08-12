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
    [Register ("BullsEyeViewController")]
    partial class BullsEyeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView IVbackground { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Llevel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LlevelUp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Lscore { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Ltarget { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider slider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIWebView WebView1 { get; set; }

        [Action ("Attempt:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Attempt (UIKit.UISlider sender);

        [Action ("DismissView:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DismissView (UIKit.UIButton sender);

        [Action ("ShowHelp:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ShowHelp (UIKit.UIButton sender);

        [Action ("UIButton1mN47B69_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton1mN47B69_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (IVbackground != null) {
                IVbackground.Dispose ();
                IVbackground = null;
            }

            if (Llevel != null) {
                Llevel.Dispose ();
                Llevel = null;
            }

            if (LlevelUp != null) {
                LlevelUp.Dispose ();
                LlevelUp = null;
            }

            if (Lscore != null) {
                Lscore.Dispose ();
                Lscore = null;
            }

            if (Ltarget != null) {
                Ltarget.Dispose ();
                Ltarget = null;
            }

            if (slider != null) {
                slider.Dispose ();
                slider = null;
            }

            if (WebView1 != null) {
                WebView1.Dispose ();
                WebView1 = null;
            }
        }
    }
}