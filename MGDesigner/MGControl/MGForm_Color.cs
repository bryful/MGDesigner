using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDesigner
{
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
		public Color Red
		{
			get { return m_Colors[(int)MG_COLOR.Red]; }
			set { SetColor(MG_COLOR.Red, value); }
		}
		[Category("_MGColors")]
		public Color Green
		{
			get { return m_Colors[(int)MG_COLOR.Green]; }
			set { SetColor(MG_COLOR.Green, value); }
		}
		[Category("_MGColors")]
		public Color Blue
		{
			get { return m_Colors[(int)MG_COLOR.Blue]; }
			set { SetColor(MG_COLOR.Blue, value); }
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
		public Color C0
		{
			get { return m_Colors[(int)MG_COLOR.C0]; }
			set { SetColor(MG_COLOR.C0, value); }
		}
		[Category("_MGColors")]
		public Color C1
		{
			get { return m_Colors[(int)MG_COLOR.C1]; }
			set { SetColor(MG_COLOR.C1, value); }
		}
		[Category("_MGColors")]
		public Color C2
		{
			get { return m_Colors[(int)MG_COLOR.C2]; }
			set { SetColor(MG_COLOR.C2, value); }
		}
		[Category("_MGColors")]
		public Color C3
		{
			get { return m_Colors[(int)MG_COLOR.C3]; }
			set { SetColor(MG_COLOR.C3, value); }
		}
		[Category("_MGColors")]
		public Color C4
		{
			get { return m_Colors[(int)MG_COLOR.C4]; }
			set { SetColor(MG_COLOR.C4, value); }
		}
		[Category("_MGColors")]
		public Color C5
		{
			get { return m_Colors[(int)MG_COLOR.C5]; }
			set { SetColor(MG_COLOR.C5, value); }
		}
		[Category("_MGColors")]
		public Color C6
		{
			get { return m_Colors[(int)MG_COLOR.C6]; }
			set { SetColor(MG_COLOR.C6, value); }
		}
		[Category("_MGColors")]
		public Color C7
		{
			get { return m_Colors[(int)MG_COLOR.C7]; }
			set { SetColor(MG_COLOR.C7, value); }
		}
		[Category("_MGColors")]
		public Color C8
		{
			get { return m_Colors[(int)MG_COLOR.C8]; }
			set { SetColor(MG_COLOR.C8, value); }
		}
		[Category("_MGColors")]
		public Color C9
		{
			get { return m_Colors[(int)MG_COLOR.C9]; }
			set { SetColor(MG_COLOR.C9, value); }
		}
		#endregion
		public void InitColor()
		{
			m_Colors[(int)MG_COLOR.White] = Color.FromArgb(0xD9, 0xC5, 0xC5);
			m_Colors[(int)MG_COLOR.Black] = Color.FromArgb(10, 10, 10);
			m_Colors[(int)MG_COLOR.Gray] = Color.FromArgb(0x71, 0x71, 0x71);
			m_Colors[(int)MG_COLOR.GrayDrak] = Color.FromArgb(0x22, 0x22, 0x22);
			m_Colors[(int)MG_COLOR.GrayLight] = Color.FromArgb(0x97, 0x97, 0x97);

			m_Colors[(int)MG_COLOR.Red] = Color.FromArgb(0x9C, 0x09, 0x09);
			m_Colors[(int)MG_COLOR.Green] = Color.FromArgb(0x39, 0xA4, 0x6B);
			m_Colors[(int)MG_COLOR.Blue] = Color.FromArgb(0x2A, 0x4F, 0x8D);
			m_Colors[(int)MG_COLOR.Cyan] = Color.FromArgb(0x28, 0x8C, 0x9B);
			m_Colors[(int)MG_COLOR.Yellow] = Color.FromArgb(0xBA, 0xB3, 0x46);
			m_Colors[(int)MG_COLOR.Magenta] = Color.FromArgb(0x9F, 0x47, 0xAF);
			m_Colors[(int)MG_COLOR.Orange] = Color.FromArgb(0xBD, 0x7E, 0x2C);

			m_Colors[(int)MG_COLOR.RedDark] = Color.FromArgb(0x2F, 0x03, 0x03);
			m_Colors[(int)MG_COLOR.GreenDark] = Color.FromArgb(0x11, 0x31, 0x20);
			m_Colors[(int)MG_COLOR.BlueDark] = Color.FromArgb(0x0D, 0x18, 0x2A);
			m_Colors[(int)MG_COLOR.CyanDark] = Color.FromArgb(0x0C, 0x2A, 0x2F);
			m_Colors[(int)MG_COLOR.YellowDark] = Color.FromArgb(0x38, 0x36, 0x15);
			m_Colors[(int)MG_COLOR.MagentaDark] = Color.FromArgb(0x30, 0x15, 0x35);
			m_Colors[(int)MG_COLOR.OrangeDark] = Color.FromArgb(0x39, 0x26, 0x0D);

			m_Colors[(int)MG_COLOR.RedLight] = Color.FromArgb(0xB7, 0x4B, 0x4B);
			m_Colors[(int)MG_COLOR.GreenLight] = Color.FromArgb(0x6E, 0xBD, 0x93);
			m_Colors[(int)MG_COLOR.BlueLight] = Color.FromArgb(0x64, 0x7F, 0xAC);
			m_Colors[(int)MG_COLOR.CyanLight] = Color.FromArgb(0x6A, 0xBE, 0xCB);
			m_Colors[(int)MG_COLOR.YellowLight] = Color.FromArgb(0xCD, 0xC8, 0x78);
			m_Colors[(int)MG_COLOR.MagentaLight] = Color.FromArgb(0xB9, 0x79, 0xC5);
			m_Colors[(int)MG_COLOR.OrangeLight] = Color.FromArgb(0xCF, 0xA1, 0x65);


		}
		public void InitColorC()
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
