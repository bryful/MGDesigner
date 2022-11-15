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
	public partial class MGTetragon : MGNone
	{
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
		public MGTetragon()
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
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Draw(pe.Graphics);
		}
		protected override void Draw(Graphics g)
		{
			base.Draw(g);
			Color b = GetMGColor(m_Back, m_BackOpacity, this.BackColor);

			SolidBrush sb = new SolidBrush(b);
			//Pen p = new Pen(c);
			try
			{
				PointF[] points = Tetragon();

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
