using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MGCreator
{
	public enum MG_COLORS
	{
		White,
		WhiteTrue,
		Black,
		BLackTrue,
		Gray,
		GrayLight,
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
		YellowLight,
		Yellow,
		YellowDark,
		YellowGreen,
		Cream,
		MagentaLight,
		Magenta,
		MagentaDark,
		OrangeLight,
		Orange,
		OrangeDark,
		Transparent
	}
	partial class MGForm
	{
		// *****************************************************************************
		private Color[] m_Colors = new Color[(int)MG_COLORS.Transparent];
		private Color[] m_ColorsBackup = new Color[(int)MG_COLORS.Transparent];
		// *****************************************************************************
		public void PushColors() { m_ColorsBackup = Colors(); }
		public void PopColors() { SetColors(m_ColorsBackup); }
		[Category("_MG")]
		public int TargetIndex
		{
			get { return Layers.TargetIndex; }
			set
			{
				Layers.TargetIndex = value;
			}
		}

		private bool m_Anti = false;
		[Category("_MG")]
		public bool Anti
		{
			get { return m_Anti; }
			set
			{
				m_Anti = value;
				//DrawAll();
			}
		}

		// *****************************************************************************
		public string[] MGColorsName()
		{
			string [] sa = Enum.GetNames(typeof(MG_COLORS));
			List<string> ret = new List<string>();
			foreach(string s in sa)
			{
				if(s!= "Transparent")
				{
					ret.Add(s);
				}
			}
			return ret.ToArray();
		}
		public Color[] Colors()
		{
			Color[] colors = new Color[(int)MG_COLORS.Transparent];
			for(int i=0;i< (int)MG_COLORS.Transparent;i++)
			{
				colors[i] = m_Colors[i];
			}
			return colors;
		}
		// *****************************************************************************
		public void SetColors(Color[] cols)
		{
			if(cols.Length != m_Colors.Length) return;
			for (int i = 0; i < (int)MG_COLORS.Transparent; i++)
			{
				m_Colors[i] = cols[i];
			}
			DrawAll();
			this.Invalidate();
		}
		// *****************************************************************************
		public JsonArray MGColorsToJson()
		{
			JsonArray jsonArray = new JsonArray();
			foreach(Color c in m_Colors)
			{
				jsonArray.Add(MGj.ColorToJson(c));
			}
			return jsonArray;
		}
		static public Color[]? FormJsonToColors(JsonArray ja)
		{
			//JsonArray? ja = jo.AsArray();
			if (ja == null) return null;
			if (ja.Count < (int)MG_COLORS.Transparent) return null;
			int idx = 0;
			Color[] colors = new Color[(int)MG_COLORS.Transparent];
			foreach (var o in ja)
			{
				if (idx >= (int)MG_COLORS.Transparent) break;
				if(o == null) continue;
				Color? c = MGj.JsonToColor(o.AsArray());
				if (c != null)
				{
					colors[idx] = (Color)c;
				}
				idx++;
			}
			return colors;
		}
		public bool FormJsonToMGColors(JsonArray jo)
		{
			JsonArray? ja = jo.AsArray();
			if(ja ==null) return false;
			if(ja.Count < m_Colors.Length) return false;
			InitColor();
			int idx = 0;
			foreach(var o in ja)
			{
				if (idx >= m_Colors.Length) break;
				Color? c = MGj.JsonToColor(o.AsArray());
				if(c!=null)
				{
					m_Colors[idx] = (Color)c;
				}
				idx++;
			}
			return true;
		}
		public JsonObject MGColorsJson()
		{
			JsonObject jo = new JsonObject();
			jo.Add("Colors", MGColorsToJson());
			return jo;
		}
		// *****************************************************************************
		public Color GetMGColors(MG_COLORS v, double opa = 100)
		{
			Color ret = Color.White;
			int v2 = (int)v;
			if ((v2 >= 0) && (v2 < (int)MG_COLORS.Transparent))
			{
				ret = m_Colors[v2];
			}
			else if (v == MG_COLORS.Transparent)
			{
				ret = Color.Transparent;
			}
			if (opa < 100)
			{
				ret = Color.FromArgb((int)((double)ret.A * opa / 100), ret.R, ret.G, ret.B);
			}
			return ret;
		}
		public void SetMG_Colors(MG_COLORS v, Color c)
		{
			if ((v >= 0) && (v < MG_COLORS.Transparent))
			{
				byte r = c.R;
				byte g = c.G;
				byte b = c.B;
				m_Colors[(int)v] = Color.FromArgb(r, g, b);
				this.Invalidate();
			}
		}
		public void InitColor()
		{
			m_Colors[(int)MG_COLORS.White] = Color.FromArgb(231, 226, 226);
			m_Colors[(int)MG_COLORS.WhiteTrue] = Color.FromArgb(0xFF, 0xFF, 0xFF);
			m_Colors[(int)MG_COLORS.Black] = Color.FromArgb(10, 10, 10);
			m_Colors[(int)MG_COLORS.BLackTrue] = Color.FromArgb(0x00, 0x00, 0x00);
			m_Colors[(int)MG_COLORS.Gray] = Color.FromArgb(95, 95, 95);
			m_Colors[(int)MG_COLORS.GrayDrak] = Color.FromArgb(60, 60, 60);
			m_Colors[(int)MG_COLORS.GrayLight] = Color.FromArgb(172, 158, 158);
			m_Colors[(int)MG_COLORS.GrayDrakDark] = Color.FromArgb(30, 30, 30);

			m_Colors[(int)MG_COLORS.Red] = Color.FromArgb(193, 74, 74);
			m_Colors[(int)MG_COLORS.RedTrue] = Color.FromArgb(0xFF, 0x00, 0x00);
			m_Colors[(int)MG_COLORS.RedDark] = Color.FromArgb(116, 54, 54);
			m_Colors[(int)MG_COLORS.RedLight] = Color.FromArgb(219, 151, 151);
			m_Colors[(int)MG_COLORS.Blood] = Color.FromArgb(121, 50, 73);
			m_Colors[(int)MG_COLORS.Pink] = Color.FromArgb(202, 167, 216);

			m_Colors[(int)MG_COLORS.Green] = Color.FromArgb(83, 138, 68);
			m_Colors[(int)MG_COLORS.GreenTrue] = Color.FromArgb(0x00, 0xFF, 0x00);
			m_Colors[(int)MG_COLORS.GreenDark] = Color.FromArgb(143, 211, 125);
			m_Colors[(int)MG_COLORS.GreenLight] = Color.FromArgb(58, 85, 49);

			m_Colors[(int)MG_COLORS.Emerald] = Color.FromArgb(68, 138, 117);
			m_Colors[(int)MG_COLORS.EmeraldLight] = Color.FromArgb(68+100, 138+100, 117+100);
			m_Colors[(int)MG_COLORS.EmeraldDark] = Color.FromArgb(68 - 50, 138 -50, 117 - 50);

			m_Colors[(int)MG_COLORS.Blue] = Color.FromArgb(67, 82, 128);
			m_Colors[(int)MG_COLORS.BlueTrue] = Color.FromArgb(0x00, 0x00, 0xFF);
			m_Colors[(int)MG_COLORS.BlueDark] = Color.FromArgb(47, 55, 79);
			m_Colors[(int)MG_COLORS.BlueLight] = Color.FromArgb(121, 145, 211);
			m_Colors[(int)MG_COLORS.SkayBlue] = Color.FromArgb(107, 172, 202);

			m_Colors[(int)MG_COLORS.Cyan] = Color.FromArgb(81, 146, 140);
			m_Colors[(int)MG_COLORS.CyanDark] = Color.FromArgb(55, 88, 85);
			m_Colors[(int)MG_COLORS.CyanLight] = Color.FromArgb(134, 214, 207);

			m_Colors[(int)MG_COLORS.Magenta] = Color.FromArgb(116, 76, 131);
			m_Colors[(int)MG_COLORS.MagentaDark] = Color.FromArgb(72, 50, 80);
			m_Colors[(int)MG_COLORS.MagentaLight] = Color.FromArgb(189, 123, 211);

			m_Colors[(int)MG_COLORS.Yellow] = Color.FromArgb(167, 164, 97);
			m_Colors[(int)MG_COLORS.YellowDark] = Color.FromArgb(117, 114, 72);
			m_Colors[(int)MG_COLORS.YellowLight] = Color.FromArgb(222, 220, 156);
			m_Colors[(int)MG_COLORS.YellowGreen] = Color.FromArgb(77, 195, 91);
			m_Colors[(int)MG_COLORS.Cream] = Color.FromArgb(212, 218, 165);

			m_Colors[(int)MG_COLORS.Orange] = Color.FromArgb(195, 154, 77);
			m_Colors[(int)MG_COLORS.OrangeDark] = Color.FromArgb(118, 96, 56);
			m_Colors[(int)MG_COLORS.OrangeLight] = Color.FromArgb(219, 196, 153);
	
		}

		private MG_COLORS m_Back = MG_COLORS.Black;
		[Category("_MG")]
		public MG_COLORS Back
		{
			get { return m_Back; }
			set
			{
				m_Back = value;
				this.Invalidate();
			}
		}

		#region Prop
		[Category("_MG_Colors")]
		public Color White
		{
			get { return m_Colors[(int)MG_COLORS.White]; }
			set
			{
				if ((value.R == 1) && (value.G == 2) && (value.B == 3) && (value.A == 0))
				{
					InitColor();
				}
				else
				{
					SetMG_Colors(MG_COLORS.White, value);
				}
			}
		}
		[Category("_MG_Colors")]
		public Color Black
		{
			get { return m_Colors[(int)MG_COLORS.Black]; }
			set
			{
				if ((value.R == 1) && (value.G == 2) && (value.B == 3) && (value.A == 0))
				{
					InitColor();
				}
				else
				{
					SetMG_Colors(MG_COLORS.Black, value);
				}
			}
		}
		[Category("_MG_Colors")]
		public Color Gray
		{
			get { return m_Colors[(int)MG_COLORS.Gray]; }
			set { SetMG_Colors(MG_COLORS.Gray, value); }
		}
		[Category("_MG_Colors")]
		public Color GrayDrak
		{
			get { return m_Colors[(int)MG_COLORS.GrayDrak]; }
			set { SetMG_Colors(MG_COLORS.GrayDrak, value); }
		}
		[Category("_MG_Colors")]
		public Color GrayLight
		{
			get { return m_Colors[(int)MG_COLORS.GrayLight]; }
			set { SetMG_Colors(MG_COLORS.GrayLight, value); }
		}
		[Category("_MG_Colors")]
		public Color GrayDrakDark
		{
			get { return m_Colors[(int)MG_COLORS.GrayDrakDark]; }
			set { SetMG_Colors(MG_COLORS.GrayDrakDark, value); }
		}

		[Category("_MG_Colors")]
		public Color Red
		{
			get { return m_Colors[(int)MG_COLORS.Red]; }
			set { SetMG_Colors(MG_COLORS.Red, value); }
		}
		[Category("_MG_Colors")]
		public Color Blood
		{
			get { return m_Colors[(int)MG_COLORS.Blood]; }
			set { SetMG_Colors(MG_COLORS.Blood, value); }
		}
		[Category("_MG_Colors")]
		public Color Pink
		{
			get { return m_Colors[(int)MG_COLORS.Pink]; }
			set { SetMG_Colors(MG_COLORS.Pink, value); }
		}

		[Category("_MG_Colors")]
		public Color Green
		{
			get { return m_Colors[(int)MG_COLORS.Green]; }
			set { SetMG_Colors(MG_COLORS.Green, value); }
		}
		[Category("_MG_Colors")]
		public Color Emerald
		{
			get { return m_Colors[(int)MG_COLORS.Emerald]; }
			set { SetMG_Colors(MG_COLORS.Emerald, value); }
		}
		[Category("_MG_Colors")]
		public Color EmeraldLight
		{
			get { return m_Colors[(int)MG_COLORS.EmeraldLight]; }
			set { SetMG_Colors(MG_COLORS.EmeraldLight, value); }
		}
		[Category("_MG_Colors")]
		public Color EmeraldDark
		{
			get { return m_Colors[(int)MG_COLORS.EmeraldDark]; }
			set { SetMG_Colors(MG_COLORS.EmeraldDark, value); }
		}
		[Category("_MG_Colors")]
		public Color Blue
		{
			get { return m_Colors[(int)MG_COLORS.Blue]; }
			set { SetMG_Colors(MG_COLORS.Blue, value); }
		}
		[Category("_MG_Colors")]
		public Color SkayBlue
		{
			get { return m_Colors[(int)MG_COLORS.SkayBlue]; }
			set { SetMG_Colors(MG_COLORS.SkayBlue, value); }
		}
		[Category("_MG_Colors")]
		public Color Cyan
		{
			get { return m_Colors[(int)MG_COLORS.Cyan]; }
			set { SetMG_Colors(MG_COLORS.Cyan, value); }
		}
		[Category("_MG_Colors")]
		public Color Yellow
		{
			get { return m_Colors[(int)MG_COLORS.Yellow]; }
			set { SetMG_Colors(MG_COLORS.Yellow, value); }
		}
		[Category("_MG_Colors")]
		public Color YellowGreen
		{
			get { return m_Colors[(int)MG_COLORS.YellowGreen]; }
			set { SetMG_Colors(MG_COLORS.YellowGreen, value); }
		}
		[Category("_MG_Colors")]
		public Color Cream
		{
			get { return m_Colors[(int)MG_COLORS.Cream]; }
			set { SetMG_Colors(MG_COLORS.Cream, value); }
		}
		[Category("_MG_Colors")]
		public Color Magenta
		{
			get { return m_Colors[(int)MG_COLORS.Magenta]; }
			set { SetMG_Colors(MG_COLORS.Magenta, value); }
		}
		[Category("_MG_Colors")]
		public Color Orange
		{
			get { return m_Colors[(int)MG_COLORS.Orange]; }
			set { SetMG_Colors(MG_COLORS.Orange, value); }
		}

		[Category("_MG_Colors")]
		public Color RedDark
		{
			get { return m_Colors[(int)MG_COLORS.RedDark]; }
			set { SetMG_Colors(MG_COLORS.RedDark, value); }
		}
		[Category("_MG_Colors")]
		public Color GreenDark
		{
			get { return m_Colors[(int)MG_COLORS.GreenDark]; }
			set { SetMG_Colors(MG_COLORS.GreenDark, value); }
		}
		[Category("_MG_Colors")]
		public Color BlueDark
		{
			get { return m_Colors[(int)MG_COLORS.BlueDark]; }
			set { SetMG_Colors(MG_COLORS.BlueDark, value); }
		}
		[Category("_MG_Colors")]
		public Color CyanDark
		{
			get { return m_Colors[(int)MG_COLORS.CyanDark]; }
			set { SetMG_Colors(MG_COLORS.CyanDark, value); }
		}
		[Category("_MG_Colors")]
		public Color YellowDark
		{
			get { return m_Colors[(int)MG_COLORS.YellowDark]; }
			set { SetMG_Colors(MG_COLORS.YellowDark, value); }
		}
		[Category("_MG_Colors")]
		public Color MagentaDark
		{
			get { return m_Colors[(int)MG_COLORS.MagentaDark]; }
			set { SetMG_Colors(MG_COLORS.MagentaDark, value); }
		}
		[Category("_MG_Colors")]
		public Color OrangeDark
		{
			get { return m_Colors[(int)MG_COLORS.OrangeDark]; }
			set { SetMG_Colors(MG_COLORS.OrangeDark, value); }
		}

		[Category("_MG_Colors")]
		public Color RedLight
		{
			get { return m_Colors[(int)MG_COLORS.RedLight]; }
			set { SetMG_Colors(MG_COLORS.RedLight, value); }
		}
		[Category("_MG_Colors")]
		public Color GreenLight
		{
			get { return m_Colors[(int)MG_COLORS.GreenLight]; }
			set { SetMG_Colors(MG_COLORS.GreenLight, value); }
		}
		[Category("_MG_Colors")]
		public Color BlueLight
		{
			get { return m_Colors[(int)MG_COLORS.BlueLight]; }
			set { SetMG_Colors(MG_COLORS.BlueLight, value); }
		}
		[Category("_MG_Colors")]
		public Color CyanLight
		{
			get { return m_Colors[(int)MG_COLORS.CyanLight]; }
			set { SetMG_Colors(MG_COLORS.CyanLight, value); }
		}
		[Category("_MG_Colors")]
		public Color YellowLight
		{
			get { return m_Colors[(int)MG_COLORS.YellowLight]; }
			set { SetMG_Colors(MG_COLORS.YellowLight, value); }
		}
		[Category("_MG_Colors")]
		public Color MagentaLight
		{
			get { return m_Colors[(int)MG_COLORS.MagentaLight]; }
			set { SetMG_Colors(MG_COLORS.MagentaLight, value); }
		}
		[Category("_MG_Colors")]
		public Color OrangeLight
		{
			get { return m_Colors[(int)MG_COLORS.OrangeLight]; }
			set { SetMG_Colors(MG_COLORS.OrangeLight, value); }
		}
		[Category("_MG_Colors")]
		public Color BLackTrue
		{
			get { return m_Colors[(int)MG_COLORS.BLackTrue]; }
			set { SetMG_Colors(MG_COLORS.BLackTrue, value); }
		}
		[Category("_MG_Colors")]
		public Color RedTrue
		{
			get { return m_Colors[(int)MG_COLORS.RedTrue]; }
			set { SetMG_Colors(MG_COLORS.RedTrue, value); }
		}
		[Category("_MG_Colors")]
		public Color GreenTrue
		{
			get { return m_Colors[(int)MG_COLORS.GreenTrue]; }
			set { SetMG_Colors(MG_COLORS.GreenTrue, value); }
		}
		[Category("_MG_Colors")]
		public Color BlueTrue
		{
			get { return m_Colors[(int)MG_COLORS.BlueTrue]; }
			set { SetMG_Colors(MG_COLORS.BlueTrue, value); }
		}
		[Category("_MG_Colors")]
		public Color WhiteTrue
		{
			get { return m_Colors[(int)MG_COLORS.WhiteTrue]; }
			set { SetMG_Colors(MG_COLORS.WhiteTrue, value); }
		}
		#endregion

	}
}
