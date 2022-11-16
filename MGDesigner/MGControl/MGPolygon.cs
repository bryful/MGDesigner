using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGDesigner
{


	public partial class MGPolygon : MGNone
	{
		private MG_COLOR m_Polygon = MG_COLOR.White;
		[Category("_MG_Polygon")]
		public MG_COLOR Polygon
		{
			get { return m_Polygon; }
			set
			{
				m_Polygon = value;
				ChkRegion();
				this.Invalidate();
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
				ChkRegion();
				this.Invalidate();
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
				ChkRegion();
				this.Invalidate();
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
				ChkRegion();
				this.Invalidate(); 
			}
		}
		private float m_weight = 3;
		[Category("_MG_Polygon")]
		public float Weight
		{
			get { return m_weight; }
			set
			{
				m_weight = value;
				ChkRegion();
				this.Invalidate();
			}
		}
		private MG_COLOR m_PolygonFill = MG_COLOR.Gray;
		[Category("_MG_Polygon")]
		public MG_COLOR PolygonFill
		{
			get { return m_PolygonFill; }
			set
			{
				m_PolygonFill = value;
				ChkRegion();
				this.Invalidate();
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
				ChkRegion();
				this.Invalidate();
			}
		}
		public MGPolygon()
		{
			InitializeComponent();
			ChkRegion();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkRegion();
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Draw(pe.Graphics);
		}
		private float Radius()
		{
			float length = this.Width;
			if (length > this.Height) length = this.Height;
			length -= m_weight;
			length /= 2;
			return length;
		}
		private void ChkRegion()
		{
			PointF cntr = new PointF((float)this.Width / 2, (float)this.Height / 2);
			this.Region = MG.PolygonRegion(m_PolygonCount, cntr, Radius() +2, m_rot);
		}
		protected override void Draw(Graphics g)
		{
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			base.Draw(g);

			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor);
			try
			{
				PointF cnt = new PointF((float)this.Width / 2, (float)this.Height / 2);

				Color fc = GetMGColor(m_PolygonFill, m_PolygonFillOpacity, this.BackColor);
				sb.Color = fc;
				Color c = GetMGColor(m_Polygon, m_PolygonOpacity, this.ForeColor);
				p.Width = m_weight;
				p.Color = c;
				MG.Polygon(g, p,sb,m_PolygonCount, cnt, Radius(), m_rot);

			}
			catch
			{
				MessageBox.Show("a");
			}
			finally
			{
				p.Dispose();
				sb.Dispose();
			}
		}
	}
}
