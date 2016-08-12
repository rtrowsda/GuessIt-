using Foundation;
using System;
using UIKit;
using System.IO;

namespace GuessIt
{
    public partial class BullsEyeViewController : UIViewController
    {

		#region Variables
		public int maxSlider = 50;
		public int target;
		public int toLevel;
		public int score = 0;
		public int currentLevel;
		TileGameViewController tile = new TileGameViewController();
		#endregion


		#region event handlers
		partial void Attempt(UISlider sender)
		{
			int current = (int)Math.Round(sender.Value);
			int points = (Math.Abs(current - target));
			score += maxSlider - points;
			string title, message = string.Format("You Scored {0} points", score);
			if (points == 0)
				title = "Perfect!";
			else if (points < 5)
				title = "You almost had it";
			else if (points < 10)
				title = "Pretty good";
			else
				title = "Not even close";
			
			tile.NewAlert(title, message);

			if (score < toLevel)
				reset(sender);
			else
				LevelUp(sender);
		}
		partial void ShowHelp(UIButton sender)
		{
			if (WebView1.Hidden == true)
				WebView1.Hidden = false;
			else
				WebView1.Hidden = true;
		}
		#endregion


		#region Setup functions
		public void reset(UISlider sender)
		{
			newTarget();
			sender.Value = (maxSlider / 2);
			UpdateLabel();
		}

		public void newTarget()
		{
			Random targ = new Random();
			target = targ.Next(1, maxSlider - 1);
		}
		public void LevelUp(UISlider slider)
		{
			currentLevel += 1;

			maxSlider = maxSlider * 2;
			slider.MaxValue = maxSlider;
			slider.Value = maxSlider / 2;
			toLevel = maxSlider;
			score = 0;
			tile.NewAlert("Congratulations", "You leveled Up!");
			reset(slider);
		}
		#endregion


		#region basic functions
		public void UpdateLabel()
		{
			Llevel.Text = Convert.ToString(currentLevel);
			LlevelUp.Text = Convert.ToString(toLevel);
			Lscore.Text = Convert.ToString(score);
			Ltarget.Text = Convert.ToString(target);
		}
		public void LoadFile()
		{
			var text = File.ReadAllText("BullsEye.txt");
			if (text != "")
			{
				string[] read = text.Split(';');
				maxSlider = int.Parse(read[0]);
				score = int.Parse(read[1]);
				currentLevel = int.Parse(read[2]);
			}
		}
		partial void DismissView(UIButton sender)
		{
			DismissViewController(true, completionHandler: null);
		}
		public void SetWeb()
		{
			WebView1.LoadRequest(new NSUrlRequest(new NSUrl("BullsEyeInfo.html", false)));
			WebView1.ScalesPageToFit = false;
		}
		#endregion


		#region basic app functions
		public BullsEyeViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			LoadFile();
			newTarget();
			toLevel = maxSlider;
			currentLevel = 1;
			UpdateLabel();
			slider.SetThumbImage(UIImage.FromFile("Images/SliderThumb-Highlighted@2x.png"), UIControlState.Highlighted);
			slider.SetThumbImage(UIImage.FromFile("Images/SliderThumb-Normal@2x.png"), UIControlState.Normal);
			SetWeb();
		}
		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
			tile.SaveFile("BullsEye.txt", string.Format("{0};{1};{2}", maxSlider, score, currentLevel));
		}
		#endregion
    }
}