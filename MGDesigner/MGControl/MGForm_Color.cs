using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDesigner
{
	public enum MG_COLOR
	{
		White,
		WhiteTrue,
		Black,
		BLackTrue,
		Gray,
		GrayLight,
		GrayDrak,
		GrayDrakDark,
		Red,
		RedLight,
		RedDark,
		Blood,
		Pink,
		Green,
		GreenTrue,
		GreenLight,
		GreenDark,
		Emerald,
		Blue,
		BlueTrue,
		BlueLight,
		BlueDark,
		SkayBlue,
		Cyan,
		CyanLight,
		CyanDark,
		Yellow,
		YellowLight,
		YellowDark,
		YellowGreen,
		Cream,
		Magenta,
		MagentaLight,
		MagentaDark,
		Orange,
		OrangeLight,
		OrangeDark,
		RedTrue,
		ForeColor,
		BackColor,
		Transparent
	}
	partial class MGForm
	{
		public event EventHandler? ColorChangedEvent;
		protected virtual void OnColorChangedEvent(EventArgs e)
		{
			if (ColorChangedEvent != null)
			{
				ColorChangedEvent(this, e);
			}
		}
		// *****************************************************************************
		private Color[] m_Colors = new Color[(int)MG_COLOR.ForeColor];
		// *****************************************************************************
		public Color GetColor(MG_COLOR v, Color f, Color b, double opa)
		{
			Color ret = this.ForeColor;
			int v2 = (int)v;
			if ((v2 >= 0) && (v2 < (int)MG_COLOR.ForeColor))
			{
				ret = m_Colors[v2];
			}
			else if (v == MG_COLOR.BackColor)
			{
				ret = b;
			}
			else if (v == MG_COLOR.ForeColor)
			{
				ret = f;
			}
			else if (v == MG_COLOR.Transparent)
			{
				ret = Color.Transparent;
			}
			if(opa<100)
			{
				ret = Color.FromArgb((int)((double)ret.A * opa / 100), ret.R, ret.G, ret.B);
			}
			return ret;
		}
		public Color GetColor(MG_COLOR v, double opa)
		{
			return GetColor(v, this.ForeColor, this.BackCol, opa);
		}
		public void SetColor(MG_COLOR v, Color c)
		{
			if ((v >= 0) && (v < MG_COLOR.ForeColor))
			{
				if (m_Colors[(int)v].Equals(c) == false)
				{
					m_Colors[(int)v] = c;
					OnColorChangedEvent(EventArgs.Empty);
				}
			}
		}
		#region Prop
		[Category("_MGColors")]
		public Color White
		{
			get { return m_Colors[(int)MG_COLOR.White]; }
			set
			{
				if ((value.R == 1) && (value.G == 2) && (value.B == 3) && (value.A == 0))
				{
					Init();
					OnColorChangedEvent(EventArgs.Empty);
				}
				else
				{
					SetColor(MG_COLOR.White, value);
				}
			}
		}
		[Category("_MGColors")]
		public Color Black
		{
			get { return m_Colors[(int)MG_COLOR.Black]; }
			set
			{
				if ((value.R == 1) && (value.G == 2) && (value.B == 3) && (value.A == 0))
				{
					Init();
					OnColorChangedEvent(EventArgs.Empty);
				}
				else
				{
					SetColor(MG_COLOR.Black, value);
				}
			}
		}
		[Category("_MGColors")]
		public Color Gray
		{
			get { return m_Colors[(int)MG_COLOR.Gray]; }
			set { SetColor(MG_COLOR.Gray, value); }
		}
		[Category("_MGColors")]
		public Color GrayDrak
		{
			get { return m_Colors[(int)MG_COLOR.GrayDrak]; }
			set { SetColor(MG_COLOR.GrayDrak, value); }
		}
		[Category("_MGColors")]
		public Color GrayLight
		{
			get { return m_Colors[(int)MG_COLOR.GrayLight]; }
			set { SetColor(MG_COLOR.GrayLight, value); }
		}
		[Category("_MGColors")]
		public Color GrayDrakDark
		{
			get { return m_Colors[(int)MG_COLOR.GrayDrakDark]; }
			set { SetColor(MG_COLOR.GrayDrakDark, value); }
		}

		[Category("_MGColors")]
		public Color Red
		{
			get { return m_Colors[(int)MG_COLOR.Red]; }
			set { SetColor(MG_COLOR.Red, value); }
		}
		[Category("_MGColors")]
		public Color Blood
		{
			get { return m_Colors[(int)MG_COLOR.Blood]; }
			set { SetColor(MG_COLOR.Blood, value); }
		}
		[Category("_MGColors")]
		public Color Pink
		{
			get { return m_Colors[(int)MG_COLOR.Pink]; }
			set { SetColor(MG_COLOR.Pink, value); }
		}

		[Category("_MGColors")]
		public Color Green
		{
			get { return m_Colors[(int)MG_COLOR.Green]; }
			set { SetColor(MG_COLOR.Green, value); }
		}
		[Category("_MGColors")]
		public Color Emerald
		{
			get { return m_Colors[(int)MG_COLOR.Emerald]; }
			set { SetColor(MG_COLOR.Emerald, value); }
		}
		[Category("_MGColors")]
		public Color Blue
		{
			get { return m_Colors[(int)MG_COLOR.Blue]; }
			set { SetColor(MG_COLOR.Blue, value); }
		}
		[Category("_MGColors")]
		public Color SkayBlue
		{
			get { return m_Colors[(int)MG_COLOR.SkayBlue]; }
			set { SetColor(MG_COLOR.SkayBlue, value); }
		}
		[Category("_MGColors")]
		public Color Cyan
		{
			get { return m_Colors[(int)MG_COLOR.Cyan]; }
			set { SetColor(MG_COLOR.Cyan, value); }
		}
		[Category("_MGColors")]
		public Color Yellow
		{
			get { return m_Colors[(int)MG_COLOR.Yellow]; }
			set { SetColor(MG_COLOR.Yellow, value); }
		}
		[Category("_MGColors")]
		public Color YellowGreen
		{
			get { return m_Colors[(int)MG_COLOR.YellowGreen]; }
			set { SetColor(MG_COLOR.YellowGreen, value); }
		}
		[Category("_MGColors")]
		public Color Cream
		{
			get { return m_Colors[(int)MG_COLOR.Cream]; }
			set { SetColor(MG_COLOR.Cream, value); }
		}
		[Category("_MGColors")]
		public Color Magenta
		{
			get { return m_Colors[(int)MG_COLOR.Magenta]; }
			set { SetColor(MG_COLOR.Magenta, value); }
		}
		[Category("_MGColors")]
		public Color Orange
		{
			get { return m_Colors[(int)MG_COLOR.Orange]; }
			set { SetColor(MG_COLOR.Orange, value); }
		}

		[Category("_MGColors")]
		public Color RedDark
		{
			get { return m_Colors[(int)MG_COLOR.RedDark]; }
			set { SetColor(MG_COLOR.RedDark, value); }
		}
		[Category("_MGColors")]
		public Color GreenDark
		{
			get { return m_Colors[(int)MG_COLOR.GreenDark]; }
			set { SetColor(MG_COLOR.GreenDark, value); }
		}
		[Category("_MGColors")]
		public Color BlueDark
		{
			get { return m_Colors[(int)MG_COLOR.BlueDark]; }
			set { SetColor(MG_COLOR.BlueDark, value); }
		}
		[Category("_MGColors")]
		public Color CyanDark
		{
			get { return m_Colors[(int)MG_COLOR.CyanDark]; }
			set { SetColor(MG_COLOR.CyanDark, value); }
		}
		[Category("_MGColors")]
		public Color YellowDark
		{
			get { return m_Colors[(int)MG_COLOR.YellowDark]; }
			set { SetColor(MG_COLOR.YellowDark, value); }
		}
		[Category("_MGColors")]
		public Color MagentaDark
		{
			get { return m_Colors[(int)MG_COLOR.MagentaDark]; }
			set { SetColor(MG_COLOR.MagentaDark, value); }
		}
		[Category("_MGColors")]
		public Color OrangeDark
		{
			get { return m_Colors[(int)MG_COLOR.OrangeDark]; }
			set { SetColor(MG_COLOR.OrangeDark, value); }
		}

		[Category("_MGColors")]
		public Color RedLight
		{
			get { return m_Colors[(int)MG_COLOR.RedLight]; }
			set { SetColor(MG_COLOR.RedLight, value); }
		}
		[Category("_MGColors")]
		public Color GreenLight
		{
			get { return m_Colors[(int)MG_COLOR.GreenLight]; }
			set { SetColor(MG_COLOR.GreenLight, value); }
		}
		[Category("_MGColors")]
		public Color BlueLight
		{
			get { return m_Colors[(int)MG_COLOR.BlueLight]; }
			set { SetColor(MG_COLOR.BlueLight, value); }
		}
		[Category("_MGColors")]
		public Color CyanLight
		{
			get { return m_Colors[(int)MG_COLOR.CyanLight]; }
			set { SetColor(MG_COLOR.CyanLight, value); }
		}
		[Category("_MGColors")]
		public Color YellowLight
		{
			get { return m_Colors[(int)MG_COLOR.YellowLight]; }
			set { SetColor(MG_COLOR.YellowLight, value); }
		}
		[Category("_MGColors")]
		public Color MagentaLight
		{
			get { return m_Colors[(int)MG_COLOR.MagentaLight]; }
			set { SetColor(MG_COLOR.MagentaLight, value); }
		}
		[Category("_MGColors")]
		public Color OrangeLight
		{
			get { return m_Colors[(int)MG_COLOR.OrangeLight]; }
			set { SetColor(MG_COLOR.OrangeLight, value); }
		}
		[Category("_MGColors")]
		public Color BLackTrue
		{
			get { return m_Colors[(int)MG_COLOR.BLackTrue]; }
			set { SetColor(MG_COLOR.BLackTrue, value); }
		}
		[Category("_MGColors")]
		public Color RedTrue
		{
			get { return m_Colors[(int)MG_COLOR.RedTrue]; }
			set { SetColor(MG_COLOR.RedTrue, value); }
		}
		[Category("_MGColors")]
		public Color GreenTrue
		{
			get { return m_Colors[(int)MG_COLOR.GreenTrue]; }
			set { SetColor(MG_COLOR.GreenTrue, value); }
		}
		[Category("_MGColors")]
		public Color BlueTrue
		{
			get { return m_Colors[(int)MG_COLOR.BlueTrue]; }
			set { SetColor(MG_COLOR.BlueTrue, value); }
		}
		[Category("_MGColors")]
		public Color WhiteTrue
		{
			get { return m_Colors[(int)MG_COLOR.WhiteTrue]; }
			set { SetColor(MG_COLOR.WhiteTrue, value); }
		}
		#endregion
		public void InitColor()
		{
			m_Colors[(int)MG_COLOR.White] = Color.FromArgb(231, 226, 226);
			m_Colors[(int)MG_COLOR.Black] = Color.FromArgb(10, 10, 10);
			m_Colors[(int)MG_COLOR.Gray] = Color.FromArgb(95, 95, 95);
			m_Colors[(int)MG_COLOR.GrayDrak] = Color.FromArgb(60, 60, 60);
			m_Colors[(int)MG_COLOR.GrayLight] = Color.FromArgb(172, 158, 158);
			m_Colors[(int)MG_COLOR.GrayDrakDark] = Color.FromArgb(30, 30, 30);

			m_Colors[(int)MG_COLOR.Red] = Color.FromArgb(193, 74, 74);
			m_Colors[(int)MG_COLOR.RedDark] = Color.FromArgb(116, 54, 54);
			m_Colors[(int)MG_COLOR.RedLight] = Color.FromArgb(219, 151, 151);
			m_Colors[(int)MG_COLOR.Blood] = Color.FromArgb(121, 50, 73);
			m_Colors[(int)MG_COLOR.Pink] = Color.FromArgb(202, 167, 216);

			m_Colors[(int)MG_COLOR.Green] = Color.FromArgb(83, 138, 68);
			m_Colors[(int)MG_COLOR.GreenDark] = Color.FromArgb(143, 211, 125);
			m_Colors[(int)MG_COLOR.GreenLight] = Color.FromArgb(58, 85, 49);
			m_Colors[(int)MG_COLOR.Emerald] = Color.FromArgb(68, 138, 117);

			m_Colors[(int)MG_COLOR.Blue] = Color.FromArgb(67, 82, 128);
			m_Colors[(int)MG_COLOR.BlueDark] = Color.FromArgb(47, 55, 79);
			m_Colors[(int)MG_COLOR.BlueLight] = Color.FromArgb(121, 145, 211);
			m_Colors[(int)MG_COLOR.SkayBlue] = Color.FromArgb(107, 172, 202);

			m_Colors[(int)MG_COLOR.Cyan] = Color.FromArgb(81, 146, 140);
			m_Colors[(int)MG_COLOR.CyanDark] = Color.FromArgb(55, 88, 85);
			m_Colors[(int)MG_COLOR.CyanLight] = Color.FromArgb(134, 214, 207);

			m_Colors[(int)MG_COLOR.Magenta] = Color.FromArgb(116, 76, 131);
			m_Colors[(int)MG_COLOR.MagentaDark] = Color.FromArgb(72, 50, 80);
			m_Colors[(int)MG_COLOR.MagentaLight] = Color.FromArgb(189, 123, 211);

			m_Colors[(int)MG_COLOR.Yellow] = Color.FromArgb(119, 117, 66);
			m_Colors[(int)MG_COLOR.YellowDark] = Color.FromArgb(73, 71, 45);
			m_Colors[(int)MG_COLOR.YellowLight] = Color.FromArgb(209, 206, 116);
			m_Colors[(int)MG_COLOR.YellowGreen] = Color.FromArgb(77, 195, 91);
			m_Colors[(int)MG_COLOR.Cream] = Color.FromArgb(212, 218, 165);

			m_Colors[(int)MG_COLOR.Orange] = Color.FromArgb(195, 154, 77);
			m_Colors[(int)MG_COLOR.OrangeDark] = Color.FromArgb(118, 96, 56);
			m_Colors[(int)MG_COLOR.OrangeLight] = Color.FromArgb(219, 196, 153);
			m_Colors[(int)MG_COLOR.BLackTrue] = Color.FromArgb(0x00, 0x00, 0x00);
			m_Colors[(int)MG_COLOR.RedTrue] = Color.FromArgb(0xFF, 0x00, 0x00);
			m_Colors[(int)MG_COLOR.GreenTrue] = Color.FromArgb(0x00, 0xFF, 0x00);
			m_Colors[(int)MG_COLOR.BlueTrue] = Color.FromArgb(0x00, 0x00, 0xFF);
			m_Colors[(int)MG_COLOR.WhiteTrue] = Color.FromArgb(0xFF, 0xFF, 0xFF);

		}
	}
}
