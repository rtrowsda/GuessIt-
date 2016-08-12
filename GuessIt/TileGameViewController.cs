using Foundation;
using System;
using UIKit;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace GuessIt
{
    public partial class TileGameViewController : UIViewController
    {
		#region Variables
		int[] xPos = new int[11] {0, 35,  70, 105, 140, 175, 210, 245, 280, 315, 350};
		int[] yPos = new int[5] { 15, 50, 85, 120, 155 };
		List<int> bomb = new List<int>();
		int Level = 1;
		int buttons = 0;
		int bombsHit = 0;
		#endregion
		#region Button Setup
		public void NewButton(int x, int y, string title)
		{
			buttons++;
			UIButton button = new UIButton();
			button.Frame = new RectangleF(x, y, 30f, 30f);
			button.SetTitle(title, UIControlState.Normal);
			button.SetTitleColor(UIColor.Clear, UIControlState.Normal);
			button.SetBackgroundImage(UIImage.FromFile("Images/tile.png"), UIControlState.Normal);
			button.TouchUpInside += (sender, e) =>
			{
				Attempt(button);
			};
			View.UserInteractionEnabled = true;
			View.Add(button);
		}
		public void CreateNewButtons()
		{
			int count = 0;
			for (int i = 0; i < 5; i++)
			{
				for (int k = 0; k < 11; k++)
				{
					NewButton(xPos[k], yPos[i], Convert.ToString(count));
					count++;
				}
			}
		}
		public void Attempt(UIButton sender)
		{
				int title = int.Parse(sender.CurrentTitle);
				bool hit = false;
				buttons--;
				foreach (int i in bomb)
				{
					if (i == title)
					{
						sender.SetBackgroundImage(UIImage.FromFile("Images/bomb.png"), UIControlState.Normal);
						bombsHit++;
						hit = true;
						if (bomb.Count == bombsHit)
							HitBomb();
						else
							NewAlert("BOMB HIT!!", "You've Hit a Bomb");
						break;
					}
				}
				if (hit == false)
				{
					sender.SetBackgroundImage(UIImage.FromFile("Images/nobomb.png"), UIControlState.Normal);
				}
				sender.UserInteractionEnabled = false;
			if (buttons == 0 && bombsHit != bomb.Count)
					GameWin();
		}
		#endregion

		#region Bomb setup/handler
		public void HitBomb()
		{
			NewAlert("BOMB HIT!!", "You've Hit a Bomb\nClick to Restart");
			ResetGame();
		}
		public void CreateBomb(int level)
		{
			Random rnd = new Random();
			int temp;
			bool match = false;
			for (int i = 0; i < level; i++)
			{
				temp = rnd.Next(0, 54);
				foreach (int k in bomb)
				{
					if (temp == k)
					{
						i--;
						match = true;
						break;
					}
				}
				if(match == false)
					bomb.Add(temp);
			}
			if (bomb.Count > level)
				bomb.RemoveAt(level);
		}
		#endregion

		#region Game functions
		public void ResetGame()
		{
			buttons = 0;
			bombsHit = 0;
			bomb.Clear();
			CreateNewButtons();
			CreateBomb(Level);
			buttons -= bomb.Count;
		}
		public void GameWin()
		{
			if (Level < 54)
			{
				string s = String.Format("You've Won The Game\nClick To Advance To \nLevel {0}", Level);
				NewAlert("Congratulations", s);
				Level++;
				ResetGame();
			}
			else {
				NewAlert("Amazing", "You've Won The Game!!\nStarting A New Game");
				Level = 1;
				ResetGame();
			}
		}
		#endregion
		#region background functions
		public void NewAlert(string title, string message)
		{
			UIAlertView alert = new UIAlertView()
			{
				Title = title,
				Message = message
			};
			alert.AddButton("OK");
			alert.Show();
		}
		public int GetLevel()
		{
			return Level;
		}
		public int LoadFile()
		{
			var text = File.ReadAllText("TileLevel.txt");
			if (text != "")
				return int.Parse(text);
			return 1;
		}
		public void SaveFile(string file, string write)
		{
			File.WriteAllText(file, write);
		}
		#endregion
		#region basic app functions
		public TileGameViewController(IntPtr handle) : base(handle)
		{
		}

		public TileGameViewController()
		{
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Level = LoadFile();
			ResetGame();
			string s = string.Format("You Are Playing\nLevel {0}", Level);
			NewAlert("Welcome", s);
		}
		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
			SaveFile("TileLevel.txt", Convert.ToString(Level));
		}
		#endregion
    }
}