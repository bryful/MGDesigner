using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
	public partial class MGParallelogram : MGNone
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
				this.Invalidate();
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
				this.Invalidate();
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
				this.Invalidate();
			}
		}

		private float m_TopLeft = 0;
		[Category("_MG_Tetragon_corner")]
		public float TopLeft
		{
			get { return m_TopLeft; }
			set
			{
				m_TopLeft = value;
				if (m_TopLeft < 0) m_TopLeft = 0;
				else if (m_TopLeft > m_TopRight) m_TopLeft = m_TopRight;
				this.Invalidate();
			}
		}
		private float m_TopRight = 100;
		[Category("_MG_Tetragon_corner")]
		public float TopRight
		{
			get { return m_TopRight; }
			set
			{
				m_TopRight = value;
				if (m_TopRight > 100) m_TopRight = 100;
				else if(m_TopRight < m_TopLeft) m_TopRight = m_TopLeft;
				this.Invalidate();
			}
		}
		private float m_BottomLeft = 0;
		[Category("_MG_Tetragon_corner")]
		public float BottomLeft
		{
			get { return m_BottomLeft; }
			set
			{
				m_BottomLeft = value;
				if (m_BottomLeft < 0) m_BottomLeft = 0;
				else if (m_BottomLeft > m_BottomRight) m_BottomLeft = m_BottomRight;
				this.Invalidate();
			}
		}
		private float m_BottomRight = 100;
		[Category("_MG_Tetragon_corner")]
		public float BottomRight
		{
			get { return m_BottomRight; }
			set
			{
				m_BottomRight = value;
				if (m_BottomRight > 100) m_BottomRight = 100;
				else if (m_BottomRight < m_BottomLeft) m_BottomRight = m_BottomLeft;
				this.Invalidate();
			}
		}


		private MG_COLOR m_Back = MG_COLOR.Black;
		[Category("_MG_Tetragon")]
		public MG_COLOR Back
		{
			get { return m_Back; }
			set
			{
				m_Back = value;
				//ChkRegopn();
				this.Invalidate();
			}
		}
		private double m_BackOpacity = 100;
		[Category("_MG_Tetragon")]
		public double BackOpacity
		{
			get { return m_BackOpacity; }
			set
			{
				m_BackOpacity = value;
				//ChkRegopn();
				this.Invalidate();
			}
		}
		public MGParallelogram()
		{
			InitializeComponent();
		}
		private PointF[] Tetragon()
		{
			PointF[] ret = new PointF[4];

			ret[0] = new PointF(this.Width * m_TopLeft / 100, 0);
			ret[1] = new PointF(this.Width * m_TopRight / 100, 0);
			ret[2] = new PointF(this.Width * m_BottomRight / 100, this.Height);
			ret[3] = new PointF(this.Width * m_BottomLeft / 100, this.Height);
			return ret;
		}
		private PointF[] Parallelogram()
		{
			PointF[] ret = new PointF[4];

			float lt;
			float rt;
			float lb;
			float rb;
			if (m_Mode==TetragonMode.Hor)
			{
				lt = 0;
				rt = this.Width;
				lb = 0;
				rb = this.Width;

				float l = Tan(this.Height, m_LeftSkew);
				if (l >= 0)
				{
					lt = l;
					if (lt > this.Width) lt = this.Width;
				}
				else
				{
					lb = -l;
					if (lb > this.Width) lb = this.Width;
				}
				float r = Tan(this.Height, m_RightSkew);
				if (r>=0)
				{
					rb = this.Width - r;
					if (rb < 0)  rb = 0;
				}
				else
				{
					rt = this.Width - r;
					if (rt < 0) rt = 0;
				}
				ret[0] = new PointF(lt, 0);
				ret[1] = new PointF(rt, 0);
				ret[2] = new PointF(rb, this.Height);
				ret[3] = new PointF(lb, this.Height);
			}
			else
			{
				lt = 0;
				rt = 0;
				lb = this.Height;
				rb = this.Height;
				float l = Tan(this.Width, m_LeftSkew);
				if (l >= 0)
				{
					lt = l;
					if (lt > this.Height) lt = this.Height;
				}
				else
				{
					rt = -l;
					if (rt > this.Height) rt = this.Height;
				}
				float r = Tan(this.Width, m_RightSkew);
				if (r >= 0)
				{
					rb = this.Height - (r);
					if (rb < 0) rb = 0;

				}
				else
				{
					lb = this.Height - (-r);
					if (lb < 0) lb = 0;
				}
				ret[0] = new PointF(0, lt);
				ret[1] = new PointF(this.Width, rt);
				ret[2] = new PointF(this.Width, rb);
				ret[3] = new PointF(0, lb);

				//ret[1] = new PointF(this.Width, rt);
				//ret[2] = new PointF(this.Width, rb);
				//ret[3] = new PointF(0, lb);
			}

			return ret;
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			if (Anti) g.SmoothingMode = SmoothingMode.AntiAlias;
			Draw(g);
		}
		protected override void Draw(Graphics g)
		{
			base.Draw(g);
			Color b = GetMGColor(m_Back, m_BackOpacity, this.BackColor);

			SolidBrush sb = new SolidBrush(b);
			//Pen p = new Pen(c);
			try
			{
				//PointF[] points = Tetragon();
				PointF[] points = Parallelogram();

				if (m_BackOpacity > 0)
				{
					sb.Color = b;
					g.FillPolygon(sb, points);
				}
			}
			catch
			{
			}
			finally
			{
				//p.Dispose();
				sb.Dispose();
			}
		}
	}
}
