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
		Rot20 = 200,
		Rot30 = 300,
		Rot45 = 450,
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
		private MG_COLORS m_ScaleColor = MG_COLORS.White;
		[Category("_MG_CircleScale")]
		public MG_COLORS ScaleColor
		{
			get { return m_ScaleColor; }
			set
			{
				m_ScaleColor = value;
				ChkOffScr();
			}
		}
		private double m_ScaleOpacity = 100;
		[Category("_MG_CircleScale")]
		public double ScaleOpacity
		{
			get { return m_ScaleOpacity; }
			set
			{
				m_ScaleOpacity = value;
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
		private MGCircleScale? m_MGCircleScale = null;
		[Category("_MG_CircleScale")]
		public MGCircleScale? CircleScale
		{
			get { return m_MGCircleScale; }
			set
			{
				if (value == this) return;
				m_MGCircleScale = value;
				if(m_MGCircleScale!=null)
				{
					SetLoc();
					m_MGCircleScale.LocationChanged += M_MGCircleScale_LocationChanged;
					m_MGCircleScale.SizeChanged += M_MGCircleScale_LocationChanged;
				}
			}
		}
		private void SetLoc()
		{
			if (m_MGCircleScale == null) return;
			int cx = m_MGCircleScale.Left + m_MGCircleScale.Width / 2;
			int cy = m_MGCircleScale.Top + m_MGCircleScale.Height / 2;

			this.Location = new Point(cx - this.Width/2, cy- this.Height/2);

		}
		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
			SetLoc();
			ChkOffScr();

		}
		protected override void OnResize(EventArgs e)
		{
			if(m_MGCircleScale!=null)
			{
				SetLoc();
				ChkOffScr();
			}
			else
			{
				base.OnResize(e);
			}
		}
		private void M_MGCircleScale_LocationChanged(object? sender, EventArgs e)
		{
			SetLoc();
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
			Pen p = new Pen(this.ForeColor);
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
				p.Width = m_LineWeight;
				p.Color = GetMG_Colors(m_ScaleColor, m_ScaleOpacity);
				for (int i = 0; i < cnt; i++)
				{
					float r = i * rot;
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
