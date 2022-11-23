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
	public partial class MGPolygon : MGControl
	{
		private MG_COLORS m_PolygonLine = MG_COLORS.White;
		[Category("_MG_Polygon")]
		public MG_COLORS PolygonLine
		{
			get { return m_PolygonLine; }
			set
			{
				m_PolygonLine = value;
				ChkOffScr();
			}
		}
		private int m_PolygonCount = 4;
		[Category("_MG_Polygon")]
		public int PolygonCount
		{
			get { return m_PolygonCount; }
			set
			{
				m_PolygonCount = value;
				ChkOffScr();
			}
		}
		private double m_PolygonOpacity = 100;
		[Category("_MG_Polygon")]
		public double PolygonOpacity
		{
			get { return m_PolygonOpacity; }
			set
			{
				m_PolygonOpacity = value;
				ChkOffScr();
			}
		}
		private float m_rot = 0;
		[Category("_MG_Polygon")]
		public float Rot
		{
			get { return m_rot; }
			set
			{
				m_rot = value;
				ChkOffScr();
			}
		}
		private float m_PolygonLineWeight = 3;
		[Category("_MG_Polygon")]
		public float PolygonLineWeight
		{
			get { return m_PolygonLineWeight; }
			set
			{
				m_PolygonLineWeight = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_PolygonFill = MG_COLORS.Gray;
		[Category("_MG_Polygon")]
		public MG_COLORS PolygonFill
		{
			get { return m_PolygonFill; }
			set
			{
				m_PolygonFill = value;
				ChkOffScr();
			}
		}
		private double m_PolygonFillOpacity = 0;
		[Category("_MG_Polygon")]
		public double PolygonFillOpacity
		{
			get { return m_PolygonFillOpacity; }
			set
			{
				m_PolygonFillOpacity = value;
				ChkOffScr();
			}
		}
		private double m_PolygonLineOpacity = 0;
		[Category("_MG_Polygon")]
		public double PolygonLineOpacity
		{
			get { return m_PolygonLineOpacity; }
			set
			{
				m_PolygonLineOpacity = value;
				ChkOffScr();
			}
		}
		public MGPolygon()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{

			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor);
			try
			{
				if (IsClear) g.Clear(Color.Transparent);
				Rectangle rct2 = MarginRect(rct);
				float radius = (float)rct2.Width-2;
				if (radius > (float)rct2.Height-2) radius = (float)rct2.Height - 2;
				radius /= 2;

				float cx = rct2.Left + (float)rct2.Width / 2;
				float cy = rct2.Top + (float)rct2.Height / 2;
				if ((m_PolygonFillOpacity>0)&&(m_PolygonFill!=MG_COLORS.Transparent))
				{
					sb.Color = GetMG_Colors(m_PolygonFill, m_PolygonFillOpacity);
					PointF[] pnts = MG.PolygonPolygon(m_PolygonCount,new PointF(cx,cy), radius, m_rot);
					g.FillPolygon(sb, pnts);

				}
				if ((m_PolygonLineOpacity > 0) && (m_PolygonLine != MG_COLORS.Transparent)&&(m_PolygonLineWeight>0))
				{
					p.Color = GetMG_Colors(m_PolygonLine, m_PolygonLineOpacity);
					p.Width = m_PolygonLineWeight;
					PointF[] pnts = MG.PolygonPolygon(m_PolygonCount, new PointF(cx, cy), radius- m_PolygonLineWeight/2, m_rot);
					g.DrawPolygon(p, pnts);

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
