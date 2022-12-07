using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MGCreator
{
	public enum MG_COL
	{
		White,
		WhiteTrue,
		Black,
		BLackTrue,
		GrayLight,
		Gray,
		GrayDrak,
		GrayDrakDark,
		RedLight,
		Red,
		RedDark,
		RedTrue,
		Blood,
		Pink,
		GreenLight,
		Green,
		GreenDark,
		GreenTrue,
		EmeraldLight,
		Emerald,
		EmeraldDark,
		BlueLight,
		Blue,
		BlueDark,
		BlueTrue,
		SkayBlue,
		CyanLight,
		Cyan,
		CyanDark,
		CyanTrue,
		YellowLight,
		Yellow,
		YellowDark,
		YellowTrue,
		YellowGreen,
		Cream,
		MagentaLight,
		Magenta,
		MagentaDark,
		MagentaTrue,
		OrangeLight,
		Orange,
		OrangeDark,
		Transparent
	}
	public class MGColor
	{
		public Color[] Colors = new Color[(int)MG_COL.Transparent];
		public MGColor()
		{
			Colors = InitColors();

		}
		static public bool ChkColors(Color[] cols)
		{
			if (cols.Length != (int)MG_COL.Transparent) return false;
			int cnt = 0;
			foreach(Color c in cols)
			{
				if((c.ToArgb()==0))
				{
					cnt++;
				}
			}
			return  (cnt != cols.Length);
		}
		static public  Color[] InitColors()
		{
			Color[] ret = new Color[(int)MG_COL.Transparent];
			ret[(int)MG_COL.White] = Color.FromArgb(231, 226, 226);
			ret[(int)MG_COL.WhiteTrue] = Color.FromArgb(255, 255, 255);
			ret[(int)MG_COL.Black] = Color.FromArgb(10, 10, 10);
			ret[(int)MG_COL.BLackTrue] = Color.FromArgb(0, 0, 0);
			ret[(int)MG_COL.GrayLight] = Color.FromArgb(226, 213, 213);
			ret[(int)MG_COL.Gray] = Color.FromArgb(172, 158, 158);
			ret[(int)MG_COL.GrayDrak] = Color.FromArgb(60, 60, 60);
			ret[(int)MG_COL.GrayDrakDark] = Color.FromArgb(30, 30, 30);
			ret[(int)MG_COL.RedLight] = Color.FromArgb(246, 106, 106);
			ret[(int)MG_COL.Red] = Color.FromArgb(203, 20, 20);
			ret[(int)MG_COL.RedDark] = Color.FromArgb(118, 22, 22);
			ret[(int)MG_COL.RedTrue] = Color.FromArgb(255, 0, 0);
			ret[(int)MG_COL.Blood] = Color.FromArgb(160, 32, 77);
			ret[(int)MG_COL.Pink] = Color.FromArgb(209, 148, 233);
			ret[(int)MG_COL.GreenLight] = Color.FromArgb(135, 199, 118);
			ret[(int)MG_COL.Green] = Color.FromArgb(83, 138, 68);
			ret[(int)MG_COL.GreenDark] = Color.FromArgb(40, 74, 31);
			ret[(int)MG_COL.GreenTrue] = Color.FromArgb(0, 255, 0);
			ret[(int)MG_COL.EmeraldLight] = Color.FromArgb(94, 215, 208);
			ret[(int)MG_COL.Emerald] = Color.FromArgb(34, 166, 158);
			ret[(int)MG_COL.EmeraldDark] = Color.FromArgb(16, 116, 110);
			ret[(int)MG_COL.BlueLight] = Color.FromArgb(126, 152, 230);
			ret[(int)MG_COL.Blue] = Color.FromArgb(79, 105, 184);
			ret[(int)MG_COL.BlueDark] = Color.FromArgb(27, 46, 105);
			ret[(int)MG_COL.BlueTrue] = Color.FromArgb(0, 0, 255);
			ret[(int)MG_COL.SkayBlue] = Color.FromArgb(117, 148, 244);
			ret[(int)MG_COL.CyanLight] = Color.FromArgb(108, 216, 232);
			ret[(int)MG_COL.Cyan] = Color.FromArgb(43, 159, 176);
			ret[(int)MG_COL.CyanDark] = Color.FromArgb(27, 109, 121);
			ret[(int)MG_COL.CyanTrue] = Color.FromArgb(0, 255, 255);
			ret[(int)MG_COL.YellowLight] = Color.FromArgb(233, 230, 158);
			ret[(int)MG_COL.Yellow] = Color.FromArgb(203, 199, 107);
			ret[(int)MG_COL.YellowDark] = Color.FromArgb(129, 126, 58);
			ret[(int)MG_COL.YellowTrue] = Color.FromArgb(255, 255, 0);
			ret[(int)MG_COL.YellowGreen] = Color.FromArgb(138, 228, 65);
			ret[(int)MG_COL.Cream] = Color.FromArgb(219, 228, 117);
			ret[(int)MG_COL.MagentaLight] = Color.FromArgb(201, 139, 224);
			ret[(int)MG_COL.Magenta] = Color.FromArgb(165, 99, 189);
			ret[(int)MG_COL.MagentaDark] = Color.FromArgb(124, 68, 145);
			ret[(int)MG_COL.MagentaTrue] = Color.FromArgb(255, 0, 255);
			ret[(int)MG_COL.OrangeLight] = Color.FromArgb(244, 187, 114);
			ret[(int)MG_COL.Orange] = Color.FromArgb(243, 140, 7);
			ret[(int)MG_COL.OrangeDark] = Color.FromArgb(175, 104, 12);

			return ret;
		}
		// **************************************************************************************
		static public bool SaveColorPict(Color[] cols, string p)
		{
			int w = 50;
			int cnt = cols.Length;
			if (cnt <= 0) return false;
			Bitmap bmp = new Bitmap(w*3, w * cols.Length);
			Graphics g = Graphics.FromImage(bmp);
			//g.SmoothingMode = SmoothingMode.AntiAlias;
			g.Clear(Color.Black);
			SolidBrush sb = new SolidBrush(Color.Black);
			string[] n = Enum.GetNames(typeof(MG_COL));
			Font font = new Font("System", 10);
			for (int i=0; i<cnt;i++)
			{
				Rectangle rct = new Rectangle(0, w * i, w, w);
				sb.Color = cols[i];
				g.FillRectangle(sb, rct);
				Rectangle rct2 = new Rectangle(w, w * i, w*2, w);
				sb.Color = Color.White;
				g.DrawString(n[i], font, sb, rct2);
			}
			bmp.Save(p,ImageFormat.Png);
			return (File.Exists(p));
		}
		// **************************************************************************************
		static public Color[]? LoadColorPict(string p)
		{
			if (File.Exists(p) == false) return null;
			Bitmap bmp = new Bitmap(p);
			int w = 50;
			if ((bmp.Width<w)|| (bmp.Height < w*(int)MG_COL.Transparent)) return null;
			int cnt = bmp.Height / 50;
			Color[] ret = new Color[cnt];
			for (int i = 0; i < cnt; i++)
			{
				ret[i] = bmp.GetPixel(w / 2, w / 2 + w * i);
			}
			return ret;
		}
		// **************************************************************************************
		static public bool ColorPictToClip(string p)
		{
			Color[]? ret = LoadColorPict(p);
			if(ret == null) return false;
			//ret[(int)MG_COL.White] = Color.FromArgb(231, 226, 226);
			string s = "";
			string[] n = Enum.GetNames(typeof(MG_COL));
			if(ret.Length == (int)MG_COL.Transparent)
			{
				for(int i= 0; i < (int)MG_COL.Transparent; i++)
				{
					string c = n[i];
					int r = ret[i].R;
					int g = ret[i].G;
					int b = ret[i].B;
					s += $"ret[(int)MG_COL.{c}] = Color.FromArgb({r}, {g}, {b});\r\n";
				}
			}
			Clipboard.SetText(s);
			return true;
		}
		static public bool SaveMGColors(string p, Color[] cols)
		{
			bool ret = false;
			if((p == null)||(p=="")||(cols.Length!=(int)MG_COL.Transparent)) return ret;
			try
			{
				JsonObject jo = new JsonObject();
				JsonArray ja = new JsonArray();
				foreach (Color c in cols)
				{
					JsonArray a = new JsonArray();
					a.Add(c.R);
					a.Add(c.G);
					a.Add(c.B);
					ja.Add(a);
				}
				jo.Add("MGColors", ja);
				File.WriteAllText(p, jo.ToJsonString());
				ret = (File.Exists(p));
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		static public Color[]? OpenMGColors(string p)
		{
			Color[]? ret = null;
			if ((p == null) || (p == "")||(File.Exists(p)==false)) return ret;
			try
			{
				string s = File.ReadAllText(p);
				var doc = JsonNode.Parse(s);
				if (doc != null)
				{
					JsonObject? jo = doc.AsObject();
					if (jo != null)
					{
						string key = "MGColors";
						if (jo.ContainsKey(key))
						{
							JsonArray? ja = jo[key].AsArray();
							if ((ja != null) && (ja.Count > 0))
							{
								List<Color> lst = new List<Color>();
								foreach (var c in ja)
								{
									if (c is JsonArray)
									{
										JsonArray a = (JsonArray)c;
										if (a.Count >= 3)
										{
											int? r = a[0].GetValue<int?>();
											int? g = a[1].GetValue<int?>();
											int? b = a[2].GetValue<int?>();
											if ((r != null) && (g != null) && (b != null))
											{
												lst.Add(Color.FromArgb((int)r, (int)g, (int)b));
											}
										}
									}
								}
								if(lst.Count==(int)MG_COL.Transparent)
								{
									ret = lst.ToArray();
								}
							}
						}
					}
				}
			}
			catch
			{
				ret = null;
			}
			return ret;
		}
	}
}
