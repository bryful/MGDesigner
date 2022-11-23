using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGDesigner
{
	public enum TetragonMode
	{
		Hor,
		Vur
	}
	public partial class MGParallelogram : MGControl
	{
		private float Tan(float h, float rot)
		{
			float r = Math.Abs(rot);
			if (r > 60) r = 60;
			float v = 1;
			if (rot < 0) v = -1;
			return (float)Math.Tan((double)r * Math.PI / 180) * h * v;
		}
		private TetragonMode m_Mode = TetragonMode.Hor;
		[Category("_MG_Parallelogram")]
		public TetragonMode Mode
		{
			get { return m_Mode; }
			set
			{
				m_Mode = value;
				ChkOffScr();
			}
		}
		private float m_LeftSkew = 0;
		[Category("_MG_Parallelogram")]
		public float LeftSkew
		{
			get { return m_LeftSkew; }
			set
			{
				m_LeftSkew = value;
				if (m_LeftSkew < -60) m_LeftSkew = -60;
				else if (m_LeftSkew > 60) m_LeftSkew = 60;
				ChkOffScr();
			}
		}
		private float m_RightSkew = 0;
		[Category("_MG_Parallelogram")]
		public float RightSkew
		{
			get { return m_RightSkew; }
			set
			{
				m_RightSkew = value;
				if (m_RightSkew < -60) m_RightSkew = -60;
				else if (m_RightSkew > 60) m_RightSkew = 60;
				ChkOffScr();
			}
		}

		private MG_COLORS m_Parallelogram = MG_COLORS.White;
		[Category("_MG_Parallelogram")]
		public MG_COLORS Parallelogram
		{
			get { return m_Parallelogram; }
			set
			{
				m_Parallelogram = value;
				ChkOffScr();
			}
		}
		private double m_ParallelogramOpacity = 100;
		[Category("_MG_Parallelogram")]
		public double ParallelogramOpacity
		{
			get { return m_ParallelogramOpacity; }
			set
			{
				m_ParallelogramOpacity = value;
				ChkOffScr();
			}
		}
		private float m_ParallelogramWeight = 1;
		[Category("_MG_Parallelogram")]
		public float ParallelogramWeight
		{
			get { return m_ParallelogramWeight; }
			set
			{
				m_ParallelogramWeight = value;
				ChkOffScr();
			}
		}


		private MG_COLORS m_Back = MG_COLORS.Black;
		[Category("_MG_Parallelogram")]
		public MG_COLORS Back
		{
			get { return m_Back; }
			set
			{
				m_Back = value;
				ChkOffScr();
			}
		}
		private double m_BackOpacity = 100;
		[Category("_MG_Parallelogram")]
		public double BackOpacity
		{
			get { return m_BackOpacity; }
			set
			{
				m_BackOpacity = value;
				ChkOffScr();
			}
		}
		public MGParallelogram()
		{
			InitializeComponent();
		}
		private PointF[] ParallelogramCalc(RectangleF rct)
		{
			PointF[] ret = new PointF[4];

			float lt;
			float rt;
			float lb;
			float rb;
			if (m_Mode == TetragonMode.Hor)
			{
				lt = 0;
				rt = rct.Width;
				lb = 0;
				rb = rct.Width;

				float l = Tan(rct.Height, m_LeftSkew);
				if (l >= 0)
				{
					lt = l;
					if (lt > rct.Width) lt = rct.Width;
				}
				else
				{
					lb = -l;
					if (lb > this.Width) lb = this.Width;
				}
				float r = Tan(rct.Height, m_RightSkew);
				if (r >= 0)
				{
					rb = rct.Width - r;
					if (rb < 0) rb = 0;
				}
				else
				{
					rt = this.Width - r;
					if (rt < 0) rt = 0;
				}
				ret[0] = new PointF(lt, 0);
				ret[1] = new PointF(rt, 0);
				ret[2] = new PointF(rb, rct.Height);
				ret[3] = new PointF(lb, rct.Height);
			}
			else
			{
				lt = 0;
				rt = 0;
				lb = rct.Height;
				rb = rct.Height;
				float l = Tan(rct.Width, m_LeftSkew);
				if (l >= 0)
				{
					lt = l;
					if (lt > rct.Height) lt = rct.Height;
				}
				else
				{
					rt = -l;
					if (rt > rct.Height) rt = rct.Height;
				}
				float r = Tan(rct.Width, m_RightSkew);
				if (r >= 0)
				{
					rb = rct.Height - (r);
					if (rb < 0) rb = 0;

				}
				else
				{
					lb = rct.Height - (-r);
					if (lb < 0) lb = 0;
				}
				ret[0] = new PointF(0, lt);
				ret[1] = new PointF(rct.Width, rt);
				ret[2] = new PointF(rct.Width, rb);
				ret[3] = new PointF(0, lb);


			}

			return ret;
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			Color b = GetMG_Colors(m_Back, m_BackOpacity);
			Color l = GetMG_Colors(m_Parallelogram, m_ParallelogramOpacity);

			SolidBrush sb = new SolidBrush(b);
			Pen p = new Pen(l);
			//Pen p = new Pen(c);
			try
			{
				if(IsClear) g.Clear(Color.Transparent);
				Rectangle rct2 = MarginRect(rct);

				if ((m_BackOpacity > 0)&&(m_Back!=MG_COLORS.Transparent))
				{
					PointF[] points2 = ParallelogramCalc(rct2);
					sb.Color = b;
					g.FillPolygon(sb, points2);
				}
				if ((m_ParallelogramOpacity > 0) && (m_ParallelogramWeight > 0))
				{
					float ww = m_ParallelogramWeight / 2;
					RectangleF rct3 = new RectangleF(
						rct2.Left+ww,
						rct2.Top+ww,
						rct2.Width-m_ParallelogramWeight,
						rct2.Height - m_ParallelogramWeight
						);
					PointF[] points3 = ParallelogramCalc(rct3);
					p.Color = l;
					p.Width = m_ParallelogramWeight;
					g.DrawPolygon(p, points3);

				}
			}
			catch
			{
			}
			finally
			{
				p.Dispose();
				sb.Dispose();
			}
		}
	}
}
