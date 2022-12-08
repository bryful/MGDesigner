using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MGCreator
{

    partial class MGForm
	{
		// *****************************************************************************
		private Color[] m_Colors = new Color[(int)MG_COL.Transparent];
		private Color[] m_ColorsBackup = new Color[(int)MG_COL.Transparent];
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
			string [] sa = Enum.GetNames(typeof(MG_COL));
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
			Color[] colors = new Color[(int)MG_COL.Transparent];
			for(int i=0;i< (int)MG_COL.Transparent;i++)
			{
				colors[i] = m_Colors[i];
			}
			return colors;
		}
		// *****************************************************************************
		public void SetColors(Color[] cols)
		{
			if(cols.Length != m_Colors.Length) return;
			if (MGColor.ChkColors(cols) == false) return;
			for (int i = 0; i < (int)MG_COL.Transparent; i++)
			{
				m_Colors[i] = cols[i];
			}
			DrawAll();
			this.Invalidate();
		}
		// *****************************************************************************
		public bool ChkColors()
		{
			bool b = true;
			int cnt = 0;
			for (int i = 0; i < (int)MG_COL.Transparent; i++)
			{
				if((m_Colors[i].ToArgb() ==0)|| (m_Colors[i].ToArgb() == 0xFF000000))
				{
					cnt++;
				}
			}
			return (cnt != (int)MG_COL.Transparent);
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
			if (ja.Count < (int)MG_COL.Transparent) return null;
			int idx = 0;
			Color[] colors = new Color[(int)MG_COL.Transparent];
			foreach (var o in ja)
			{
				if (idx >= (int)MG_COL.Transparent) break;
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
		public Color GetMGColors(MG_COL v, double opa = 100)
		{
			Color ret = Color.White;
			int v2 = (int)v;
			if ((v2 >= 0) && (v2 < (int)MG_COL.Transparent))
			{
				ret = m_Colors[v2];
			}
			else if (v == MG_COL.Transparent)
			{
				ret = Color.Transparent;
			}
			if (opa < 100)
			{
				ret = Color.FromArgb((int)((double)ret.A * opa / 100), ret.R, ret.G, ret.B);
			}
			return ret;
		}
		public void SetMG_Colors(MG_COL v, Color c)
		{
			if ((v >= 0) && (v < MG_COL.Transparent))
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
			m_Colors = MGColor.InitColors();
		}

		private MG_COL m_Back = MG_COL.Black;
		[Category("_MG")]
		public MG_COL Back
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
			get { return m_Colors[(int)MG_COL.White]; }
			set
			{
				SetMG_Colors(MG_COL.White, value);
			}
		}
		[Category("_MG_Colors")]
		public Color WhiteTrue
		{
			get { return m_Colors[(int)MG_COL.WhiteTrue]; }
			set { SetMG_Colors(MG_COL.WhiteTrue, value); }
		}
		[Category("_MG_Colors")]
		public Color Black
		{
			get { return m_Colors[(int)MG_COL.Black]; }
			set
			{
					SetMG_Colors(MG_COL.Black, value);
			}
		}
		[Category("_MG_Colors")]
		public Color BLackTrue
		{
			get { return m_Colors[(int)MG_COL.BLackTrue]; }
			set { SetMG_Colors(MG_COL.BLackTrue, value); }
		}


		[Category("_MG_Colors")]
		public Color GrayLight
		{
			get { return m_Colors[(int)MG_COL.GrayLight]; }
			set { SetMG_Colors(MG_COL.GrayLight, value); }
		}
		[Category("_MG_Colors")]
		public Color Gray
		{
			get { return m_Colors[(int)MG_COL.Gray]; }
			set { SetMG_Colors(MG_COL.Gray, value); }
		}
		[Category("_MG_Colors")]
		public Color GrayDrak
		{
			get { return m_Colors[(int)MG_COL.GrayDrak]; }
			set { SetMG_Colors(MG_COL.GrayDrak, value); }
		}
		[Category("_MG_Colors")]
		public Color GrayDrakDark
		{
			get { return m_Colors[(int)MG_COL.GrayDrakDark]; }
			set { SetMG_Colors(MG_COL.GrayDrakDark, value); }
		}

		[Category("_MG_Colors")]
		public Color RedLight
		{
			get { return m_Colors[(int)MG_COL.RedLight]; }
			set { SetMG_Colors(MG_COL.RedLight, value); }
		}
		[Category("_MG_Colors")]
		public Color Red
		{
			get { return m_Colors[(int)MG_COL.Red]; }
			set { SetMG_Colors(MG_COL.Red, value); }
		}
		[Category("_MG_Colors")]
		public Color RedDark
		{
			get { return m_Colors[(int)MG_COL.RedDark]; }
			set { SetMG_Colors(MG_COL.RedDark, value); }
		}
		[Category("_MG_Colors")]
		public Color RedTrue
		{
			get { return m_Colors[(int)MG_COL.RedTrue]; }
			set { SetMG_Colors(MG_COL.RedTrue, value); }
		}
		[Category("_MG_Colors")]
		public Color Blood
		{
			get { return m_Colors[(int)MG_COL.Blood]; }
			set { SetMG_Colors(MG_COL.Blood, value); }
		}
		[Category("_MG_Colors")]
		public Color Pink
		{
			get { return m_Colors[(int)MG_COL.Pink]; }
			set { SetMG_Colors(MG_COL.Pink, value); }
		}

		[Category("_MG_Colors")]
		public Color GreenLight
		{
			get { return m_Colors[(int)MG_COL.GreenLight]; }
			set { SetMG_Colors(MG_COL.GreenLight, value); }
		}
		[Category("_MG_Colors")]
		public Color Green
		{
			get { return m_Colors[(int)MG_COL.Green]; }
			set { SetMG_Colors(MG_COL.Green, value); }
		}
		[Category("_MG_Colors")]
		public Color GreenDark
		{
			get { return m_Colors[(int)MG_COL.GreenDark]; }
			set { SetMG_Colors(MG_COL.GreenDark, value); }
		}
		[Category("_MG_Colors")]
		public Color GreenTrue
		{
			get { return m_Colors[(int)MG_COL.GreenTrue]; }
			set { SetMG_Colors(MG_COL.GreenTrue, value); }
		}
		[Category("_MG_Colors")]
		public Color EmeraldLight
		{
			get { return m_Colors[(int)MG_COL.EmeraldLight]; }
			set { SetMG_Colors(MG_COL.EmeraldLight, value); }
		}
		[Category("_MG_Colors")]
	
		public Color Emerald
		{
			get { return m_Colors[(int)MG_COL.Emerald]; }
			set { SetMG_Colors(MG_COL.Emerald, value); }
		}
		[Category("_MG_Colors")]
		public Color EmeraldDark
		{
			get { return m_Colors[(int)MG_COL.EmeraldDark]; }
			set { SetMG_Colors(MG_COL.EmeraldDark, value); }
		}
		[Category("_MG_Colors")]
		public Color BlueLight
		{
			get { return m_Colors[(int)MG_COL.BlueLight]; }
			set { SetMG_Colors(MG_COL.BlueLight, value); }
		}
		[Category("_MG_Colors")]
		public Color Blue
		{
			get { return m_Colors[(int)MG_COL.Blue]; }
			set { SetMG_Colors(MG_COL.Blue, value); }
		}
		[Category("_MG_Colors")]
		public Color BlueDark
		{
			get { return m_Colors[(int)MG_COL.BlueDark]; }
			set { SetMG_Colors(MG_COL.BlueDark, value); }
		}
		[Category("_MG_Colors")]
		public Color BlueTrue
		{
			get { return m_Colors[(int)MG_COL.BlueTrue]; }
			set { SetMG_Colors(MG_COL.BlueTrue, value); }
		}
		[Category("_MG_Colors")]
		public Color SkayBlue
		{
			get { return m_Colors[(int)MG_COL.SkayBlue]; }
			set { SetMG_Colors(MG_COL.SkayBlue, value); }
		}
		[Category("_MG_Colors")]
		public Color CyanLight
		{
			get { return m_Colors[(int)MG_COL.CyanLight]; }
			set { SetMG_Colors(MG_COL.CyanLight, value); }
		}
		[Category("_MG_Colors")]
		public Color Cyan
		{
			get { return m_Colors[(int)MG_COL.Cyan]; }
			set { SetMG_Colors(MG_COL.Cyan, value); }
		}
		[Category("_MG_Colors")]
		public Color CyanDark
		{
			get { return m_Colors[(int)MG_COL.CyanDark]; }
			set { SetMG_Colors(MG_COL.CyanDark, value); }
		}
		[Category("_MG_Colors")]
		public Color CyanTrue
		{
			get { return m_Colors[(int)MG_COL.CyanTrue]; }
			set { SetMG_Colors(MG_COL.CyanTrue, value); }
		}
		[Category("_MG_Colors")]
		public Color YellowLight
		{
			get { return m_Colors[(int)MG_COL.YellowLight]; }
			set { SetMG_Colors(MG_COL.YellowLight, value); }
		}
		[Category("_MG_Colors")]
		public Color Yellow
		{
			get { return m_Colors[(int)MG_COL.Yellow]; }
			set { SetMG_Colors(MG_COL.Yellow, value); }
		}
		[Category("_MG_Colors")]
		public Color YellowDark
		{
			get { return m_Colors[(int)MG_COL.YellowDark]; }
			set { SetMG_Colors(MG_COL.YellowDark, value); }
		}
		[Category("_MG_Colors")]
		public Color YellowTrue
		{
			get { return m_Colors[(int)MG_COL.YellowTrue]; }
			set { SetMG_Colors(MG_COL.YellowTrue, value); }
		}
		[Category("_MG_Colors")]
		public Color YellowGreen
		{
			get { return m_Colors[(int)MG_COL.YellowGreen]; }
			set { SetMG_Colors(MG_COL.YellowGreen, value); }
		}
		[Category("_MG_Colors")]
		public Color Cream
		{
			get { return m_Colors[(int)MG_COL.Cream]; }
			set { SetMG_Colors(MG_COL.Cream, value); }
		}
		[Category("_MG_Colors")]
		public Color MagentaLight
		{
			get { return m_Colors[(int)MG_COL.MagentaLight]; }
			set { SetMG_Colors(MG_COL.MagentaLight, value); }
		}
		[Category("_MG_Colors")]
		public Color Magenta
		{
			get { return m_Colors[(int)MG_COL.Magenta]; }
			set { SetMG_Colors(MG_COL.Magenta, value); }
		}
		[Category("_MG_Colors")]
		public Color MagentaDark
		{
			get { return m_Colors[(int)MG_COL.MagentaDark]; }
			set { SetMG_Colors(MG_COL.MagentaDark, value); }
		}
		[Category("_MG_Colors")]
		public Color MagentaTrue
		{
			get { return m_Colors[(int)MG_COL.MagentaTrue]; }
			set { SetMG_Colors(MG_COL.MagentaTrue, value); }
		}
		[Category("_MG_Colors")]
		public Color OrangeLight
		{
			get { return m_Colors[(int)MG_COL.OrangeLight]; }
			set { SetMG_Colors(MG_COL.OrangeLight, value); }
		}
		[Category("_MG_Colors")]
		public Color Orange
		{
			get { return m_Colors[(int)MG_COL.Orange]; }
			set { SetMG_Colors(MG_COL.Orange, value); }
		}
		[Category("_MG_Colors")]
		public Color OrangeDark
		{
			get { return m_Colors[(int)MG_COL.OrangeDark]; }
			set { SetMG_Colors(MG_COL.OrangeDark, value); }
		}









	

	

		#endregion

	}
}
