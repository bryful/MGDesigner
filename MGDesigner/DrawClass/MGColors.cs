using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGDesigner
{
	public enum MG_COLOR
	{
		White=0,
		Black,
		Gray,
		Red,
		Green,
		Blue,
		Cyan,
		Yellow,
		Magenta,
		Orange,

		GrayDrak,
		RedDark,
		GreenDark,
		BlueDark,
		CyanDark,
		YellowDark,
		MagentaDark,
		OrangeDark,

		GrayLight,
		RedLight,
		GreenLight,
		BlueLight,
		CyanLight,
		YellowLight,
		MagentaLight,
		OrangeLight,
		C0,
		C1,
		C2,
		C3,
		C4,
		C5,
		C6,
		C7,
		C8,
		C9,
		ForeColor,
		BackColor,
		Transparent
	}

	public partial class MGColors : Component
	{
		// *****************************************************************************
		public event EventHandler? ColorChangedEvent;
		protected virtual void OnColorChangedEvent(EventArgs e)
		{
			if (ColorChangedEvent != null)
			{
				ColorChangedEvent(this, e);
			}
		}
		// *****************************************************************************
		private Color [] m_Colors = new Color [(int)MG_COLOR.ForeColor];
		// *****************************************************************************
		public Color? GetColor(MG_COLOR v,Color f,Color b)
		{
			Color? ret = null;
			if(((int)v>=0)&&(v< MG_COLOR.ForeColor))
			{
				ret = m_Colors[(int)v];
			}else if(v==MG_COLOR.BackColor)
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
			return ret;
		}
		public Color? GetColor(MG_COLOR v)
		{
			Color? ret = null;
			if (((int)v >= 0) && (v < MG_COLOR.ForeColor))
			{
				ret = m_Colors[(int)v];
			}
			return ret;
		}
		public void SetColor(MG_COLOR v, Color c)
		{
			if ((v >= 0) && (v < MG_COLOR.ForeColor))
			{
				if(m_Colors[(int)v].Equals(c)==false)
				{
					m_Colors[(int)v] = c;
					OnColorChangedEvent(EventArgs.Empty);
				}
			}
		}
		#region Prop
		public Color White { 
			get { return m_Colors [(int)MG_COLOR.White]; }
			set 
			{
				if((value.R==1)&& (value.G == 2)&& (value.B == 3)&&(value.A == 0))
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
		public Color Gray
		{
			get { return m_Colors[(int)MG_COLOR.Gray]; }
			set { SetColor(MG_COLOR.Gray, value); }
		}
		public Color GrayDrak
		{
			get { return m_Colors[(int)MG_COLOR.GrayDrak]; }
			set { SetColor(MG_COLOR.GrayDrak, value); }
		}
		public Color GrayLight
		{
			get { return m_Colors[(int)MG_COLOR.GrayLight]; }
			set { SetColor(MG_COLOR.GrayLight, value); }
		}


		public Color Red
		{
			get { return m_Colors[(int)MG_COLOR.Red]; }
			set { SetColor(MG_COLOR.Red, value); }
		}
		public Color Green
		{
			get { return m_Colors[(int)MG_COLOR.Green]; }
			set { SetColor(MG_COLOR.Green, value); }
		}
		public Color Blue
		{
			get { return m_Colors[(int)MG_COLOR.Blue]; }
			set { SetColor(MG_COLOR.Blue, value); }
		}
		public Color Cyan
		{
			get { return m_Colors[(int)MG_COLOR.Cyan]; }
			set { SetColor(MG_COLOR.Cyan, value); }
		}
		public Color Yellow
		{
			get { return m_Colors[(int)MG_COLOR.Yellow]; }
			set { SetColor(MG_COLOR.Yellow, value); }
		}
		public Color Magenta
		{
			get { return m_Colors[(int)MG_COLOR.Magenta]; }
			set { SetColor(MG_COLOR.Magenta, value); }
		}
		public Color Orange
		{
			get { return m_Colors[(int)MG_COLOR.Orange]; }
			set { SetColor(MG_COLOR.Orange, value); }
		}

		public Color RedDark
		{
			get { return m_Colors[(int)MG_COLOR.RedDark]; }
			set { SetColor(MG_COLOR.RedDark, value); }
		}
		public Color GreenDark
		{
			get { return m_Colors[(int)MG_COLOR.GreenDark]; }
			set { SetColor(MG_COLOR.GreenDark, value); }
		}
		public Color BlueDark
		{
			get { return m_Colors[(int)MG_COLOR.BlueDark]; }
			set { SetColor(MG_COLOR.BlueDark, value); }
		}
		public Color CyanDark
		{
			get { return m_Colors[(int)MG_COLOR.CyanDark]; }
			set { SetColor(MG_COLOR.CyanDark, value); }
		}
		public Color YellowDark
		{
			get { return m_Colors[(int)MG_COLOR.YellowDark]; }
			set { SetColor(MG_COLOR.YellowDark, value); }
		}
		public Color MagentaDark
		{
			get { return m_Colors[(int)MG_COLOR.MagentaDark]; }
			set { SetColor(MG_COLOR.MagentaDark, value); }
		}
		public Color OrangeDark
		{
			get { return m_Colors[(int)MG_COLOR.OrangeDark]; }
			set { SetColor(MG_COLOR.OrangeDark, value); }
		}

		public Color RedLight
		{
			get { return m_Colors[(int)MG_COLOR.RedLight]; }
			set { SetColor(MG_COLOR.RedLight, value); }
		}
		public Color GreenLight
		{
			get { return m_Colors[(int)MG_COLOR.GreenLight]; }
			set { SetColor(MG_COLOR.GreenLight, value); }
		}
		public Color BlueLight
		{
			get { return m_Colors[(int)MG_COLOR.BlueLight]; }
			set { SetColor(MG_COLOR.BlueLight, value); }
		}
		public Color CyanLight
		{
			get { return m_Colors[(int)MG_COLOR.CyanLight]; }
			set { SetColor(MG_COLOR.CyanLight, value); }
		}
		public Color YellowLight
		{
			get { return m_Colors[(int)MG_COLOR.YellowLight]; }
			set { SetColor(MG_COLOR.YellowLight, value); }
		}
		public Color MagentaLight
		{
			get { return m_Colors[(int)MG_COLOR.MagentaLight]; }
			set { SetColor(MG_COLOR.MagentaLight, value); }
		}
		public Color OrangeLight
		{
			get { return m_Colors[(int)MG_COLOR.OrangeLight]; }
			set { SetColor(MG_COLOR.OrangeLight, value); }
		}
		public Color C0
		{
			get { return m_Colors[(int)MG_COLOR.C0]; }
			set { SetColor(MG_COLOR.C0, value); }
		}
		public Color C1
		{
			get { return m_Colors[(int)MG_COLOR.C1]; }
			set { SetColor(MG_COLOR.C1, value); }
		}
		public Color C2
		{
			get { return m_Colors[(int)MG_COLOR.C2]; }
			set { SetColor(MG_COLOR.C2, value); }
		}
		public Color C3
		{
			get { return m_Colors[(int)MG_COLOR.C3]; }
			set { SetColor(MG_COLOR.C3, value); }
		}
		public Color C4
		{
			get { return m_Colors[(int)MG_COLOR.C4]; }
			set { SetColor(MG_COLOR.C4, value); }
		}
		public Color C5
		{
			get { return m_Colors[(int)MG_COLOR.C5]; }
			set { SetColor(MG_COLOR.C5, value); }
		}
		public Color C6
		{
			get { return m_Colors[(int)MG_COLOR.C6]; }
			set { SetColor(MG_COLOR.C6, value); }
		}
		public Color C7
		{
			get { return m_Colors[(int)MG_COLOR.C7]; }
			set { SetColor(MG_COLOR.C7, value); }
		}
		public Color C8
		{
			get { return m_Colors[(int)MG_COLOR.C8]; }
			set { SetColor(MG_COLOR.C8, value); }
		}
		public Color C9
		{
			get { return m_Colors[(int)MG_COLOR.C9]; }
			set { SetColor(MG_COLOR.C9, value); }
		}
		#endregion
		// *****************************************************************************
		public MGColors()
		{
			InitializeComponent();
			Init();
			InitC();
		}
		// *****************************************************************************
		public void Init()
		{
			m_Colors[(int)MG_COLOR.White] = Color.FromArgb(0xD9, 0xC5, 0xC5);
			m_Colors[(int)MG_COLOR.Black] = Color.FromArgb(10, 10, 10);
			m_Colors[(int)MG_COLOR.Gray] = Color.FromArgb(0x71,0x71,0x71);
			m_Colors[(int)MG_COLOR.GrayDrak] = Color.FromArgb(0x22, 0x22, 0x22);
			m_Colors[(int)MG_COLOR.GrayLight] = Color.FromArgb(0x97,0x97,0x97);

			m_Colors[(int)MG_COLOR.Red] = Color.FromArgb(0x9C,0x09,0x09);
			m_Colors[(int)MG_COLOR.Green] = Color.FromArgb(0x39,0xA4,0x6B);
			m_Colors[(int)MG_COLOR.Blue] = Color.FromArgb(0x2A,0x4F,0x8D);
			m_Colors[(int)MG_COLOR.Cyan] = Color.FromArgb(0x28,0x8C,0x9B);
			m_Colors[(int)MG_COLOR.Yellow] = Color.FromArgb(0xBA, 0xB3, 0x46);
			m_Colors[(int)MG_COLOR.Magenta] = Color.FromArgb(0x9F, 0x47, 0xAF);
			m_Colors[(int)MG_COLOR.Orange] = Color.FromArgb(0xBD, 0x7E, 0x2C);

			m_Colors[(int)MG_COLOR.RedDark] = Color.FromArgb(0x2F, 0x03, 0x03);
			m_Colors[(int)MG_COLOR.GreenDark] = Color.FromArgb(0x11,0x31,0x20);
			m_Colors[(int)MG_COLOR.BlueDark] = Color.FromArgb(0x0D,0x18,0x2A);
			m_Colors[(int)MG_COLOR.CyanDark] = Color.FromArgb(0x0C,0x2A,0x2F);
			m_Colors[(int)MG_COLOR.YellowDark] = Color.FromArgb(0x38,0x36,0x15);
			m_Colors[(int)MG_COLOR.MagentaDark] = Color.FromArgb(0x30,0x15,0x35);
			m_Colors[(int)MG_COLOR.OrangeDark] = Color.FromArgb(0x39,0x26,0x0D);

			m_Colors[(int)MG_COLOR.RedLight] = Color.FromArgb(0xB7,0x4B,0x4B);
			m_Colors[(int)MG_COLOR.GreenLight] = Color.FromArgb(0x6E,0xBD,0x93);
			m_Colors[(int)MG_COLOR.BlueLight] = Color.FromArgb(0x64,0x7F,0xAC);
			m_Colors[(int)MG_COLOR.CyanLight] = Color.FromArgb(0x6A,0xBE,0xCB);
			m_Colors[(int)MG_COLOR.YellowLight] = Color.FromArgb(0xCD,0xC8,0x78);
			m_Colors[(int)MG_COLOR.MagentaLight] = Color.FromArgb(0xB9,0x79,0xC5);
			m_Colors[(int)MG_COLOR.OrangeLight] = Color.FromArgb(0xCF,0xA1,0x65);


		}
		public void InitC()
		{
			m_Colors[(int)MG_COLOR.C0] = Color.FromArgb(0x00, 0x00, 0x00);
			m_Colors[(int)MG_COLOR.C1] = Color.FromArgb(0xFF, 0x00, 0x00);
			m_Colors[(int)MG_COLOR.C2] = Color.FromArgb(0x00, 0xFF, 0x00);
			m_Colors[(int)MG_COLOR.C3] = Color.FromArgb(0x00, 0x00, 0xFF);
			m_Colors[(int)MG_COLOR.C4] = Color.FromArgb(0xFF, 0xFF, 0x00);
			m_Colors[(int)MG_COLOR.C5] = Color.FromArgb(0xFF, 0x00, 0xFF);
			m_Colors[(int)MG_COLOR.C6] = Color.FromArgb(0x00, 0xFF, 0xFF);
			m_Colors[(int)MG_COLOR.C7] = Color.FromArgb(0xFF, 0xFF, 0xFF);
			m_Colors[(int)MG_COLOR.C8] = Color.FromArgb(0x7F, 0x7F, 0x7F);
			m_Colors[(int)MG_COLOR.C9] = Color.FromArgb(0x3F, 0x3F, 0x3F);

		}

	}
}
