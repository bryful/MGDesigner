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
	public enum RotValue
	{
		Rot2_5 = 25,
		Rot5 = 50,
		Rot10 = 100,
		Rot15 = 150,
		Rot30 = 300,
		Rot90 = 900
	}
	public partial class MGCircleScale : MGControl
	{
		private RotValue m_RotValue = RotValue.Rot10;
		[Category("_MG_CircleScale")]
		public RotValue RotValue
		{
			get { return m_RotValue; }
			set
			{
				m_RotValue = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_ScaleA = MG_COLORS.White;
		[Category("_MG_CircleScale")]
		public MG_COLORS ScaleA
		{
			get { return m_ScaleA; }
			set
			{
				m_ScaleA = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_ScaleB = MG_COLORS.GrayLight;
		[Category("_MG_CircleScale")]
		public MG_COLORS ScaleB
		{
			get { return m_ScaleB; }
			set
			{
				m_ScaleB = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_ScaleC = MG_COLORS.Gray;
		[Category("_MG_CircleScale")]
		public MG_COLORS ScaleC
		{
			get { return m_ScaleC; }
			set
			{
				m_ScaleC = value;
				ChkOffScr();
			}
		}
		private float m_Length = 20;
		[Category("_MG_CircleScale")]
		public float Length
		{
			get { return m_Length; }
			set
			{
				m_Length = value;
				ChkOffScr();
			}
		}
		private float m_Len90 = 1;
		[Category("_MG_CircleScale")]
		public float Len90
		{
			get { return m_Len90 * 100; }
			set
			{
				m_Len90 = value/100;
				ChkOffScr();
			}
		}
		private float m_Len45 = 0.6f;
		[Category("_MG_CircleScale")]
		public float Len45
		{
			get { return m_Len45 * 100; }
			set
			{
				m_Len45 = value / 100;
				ChkOffScr();
			}
		}
		private float m_Len30 = 0.45f;
		[Category("_MG_CircleScale")]
		public float Len30
		{
			get { return m_Len30 * 100; }
			set
			{
				m_Len30 = value / 100;
				ChkOffScr();
			}
		}
		private float m_Len15 = 0.35f;
		[Category("_MG_CircleScale")]
		public float Len15
		{
			get { return m_Len15 * 100; }
			set
			{
				m_Len15 = value / 100;
				ChkOffScr();
			}
		}

		private float m_LenEtc = 0.2f;
		[Category("_MG_CircleScale")]
		public float LenETc
		{
			get { return m_LenEtc * 100; }
			set
			{
				m_LenEtc = value / 100;
				ChkOffScr();
			}
		}
		private float m_Weight90 = 1;
		[Category("_MG_CircleScale")]
		public float Weight90
		{
			get { return m_Weight90 * 100; }
			set
			{
				m_Weight90 = value / 100;
				ChkOffScr();
			}
		}
		private float m_Weight45 = 1;
		[Category("_MG_CircleScale")]
		public float Weight45
		{
			get { return m_Weight45 * 100; }
			set
			{
				m_Weight45 = value / 100;
				ChkOffScr();
			}
		}
		private float m_Weight30 = 1;
		[Category("_MG_CircleScale")]
		public float Weight30
		{
			get { return m_Weight30 * 100; }
			set
			{
				m_Weight30 = value / 100;
				ChkOffScr();
			}
		}
		private float m_Weight15 = 1;
		[Category("_MG_CircleScale")]
		public float Weight15
		{
			get { return m_Weight15 * 100; }
			set
			{
				m_Weight15 = value / 100;
				ChkOffScr();
			}
		}

		private float m_WeightEtc = 1;
		[Category("_MG_CircleScale")]
		public float WeightEtc
		{
			get { return m_WeightEtc * 100; }
			set
			{
				m_WeightEtc = value / 100;
				ChkOffScr();
			}
		}
		private float m_LineWeight = 2;
		[Category("_MG_CircleScale")]
		public float LineWeight
		{
			get { return m_LineWeight; }
			set
			{
				m_LineWeight = value;
				ChkOffScr();
			}
		}
		public MGCircleScale()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			Color ca = GetMG_Colors(m_ScaleA, 100);
			Color cb = GetMG_Colors(m_ScaleB, 100);
			Color cc = GetMG_Colors(m_ScaleC, 100);
			Pen p = new Pen(ca);
			float rot = (float)m_RotValue / 10;
			try
			{
				if (IsClear) g.Clear(Color.Transparent);

				Rectangle rct2 = MarginRect(rct);
				float cx = rct2.Left + (float)rct2.Width / 2;
				float cy = rct2.Top + (float)rct2.Height / 2;
				float l1 = (float)rct2.Width;
				if (l1 > (float)rct2.Height) l1 = (float)rct2.Height;
				l1 /= 2;
				float l2 = l1 - m_Length;
				int cnt = (int)(360 / rot);
				for (int i = 0; i < cnt; i++)
				{
					float r = i * rot;
					if (((int)r % 90) == 0)
					{
						l2 = l1 - m_Length*m_Len90;
						p.Color = ca;
						p.Width = m_LineWeight*m_Weight90;
					}
					else if (((int)r % 45) == 0)
					{
						l2 = l1 - m_Length * m_Len45;
						p.Color = cb;
						p.Width = m_LineWeight * m_Weight45;
					}
					else if (((int)r % 30) == 0)
					{
						l2 = l1 - m_Length * m_Len30;
						p.Color = cb;
						p.Width = m_LineWeight * m_Weight30;
					}
					else if ((int)(r % 15) == 0)
					{
						l2 = l1 - m_Length * m_Len15;
						p.Color = cb;
						p.Width = m_LineWeight * m_Weight15;
					}

					else
					{
						l2 = l1 - m_Length * m_LenEtc;
						p.Color = cc;
						p.Width = m_LineWeight * m_WeightEtc;
					}
					double xd = Math.Sin(r * Math.PI / 180);
					double yd = Math.Cos(r * Math.PI / 180);
					float x0 = (float)(cx + l1 * xd);
					float y0 = (float)(cy + l1 * yd);
					float x1 = (float)(cx + l2 * xd);
					float y1 = (float)(cy + l2 * yd);
					PointF[] pnts = new PointF[] { new PointF(x0, y0), new PointF(x1, y1) };
					g.DrawLines(p, pnts);

				}
			}
			catch
			{
			}
			finally
			{
				p.Dispose();
			}
		}
	}
}
