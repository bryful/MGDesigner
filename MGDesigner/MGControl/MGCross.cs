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
	public partial class MGCross : MGPlate
	{
		private MG_COLOR m_Cross = MG_COLOR.White;
		[Category("_MG")]
		public MG_COLOR Cross
		{
			get { return m_Cross; }
			set
			{
				m_Cross = value;
				this.Invalidate();
			}
		}
		private double m_CrossOpacity = 100;
		[Category("_MG")]
		public double CrossOpacity
		{
			get { return m_CrossOpacity; }
			set
			{
				m_CrossOpacity = value;
				this.Invalidate();
			}
		}
		private int m_CrossWeight = 5;
		[Category("_MG")]
		public int CrossWeight
		{
			get { return m_CrossWeight; }
			set
			{
				m_CrossWeight = value;
				ChkRegion();
				this.Invalidate();
			}
		}
		public MGCross()
		{
			InitializeComponent();
			ChkRegion();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkRegion();
			this.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Draw(pe.Graphics);
		}
		private void ChkRegion()
		{
			Point[] pnts = new Point[12];
			byte[] types = new byte[12];
			for (int i = 0; i < 12; i++) types[i] = (byte)PathPointType.Line;
			float cx = (float)this.Width / 2;
			float cy = (float)this.Height / 2;
			float cw = m_CrossWeight / 2;
			pnts[0] = new Point((int)(cx - cw), 0);
			pnts[1] = new Point((int)(cx + cw), 0);
			pnts[2] = new Point((int)(cx + cw), (int)(cy - cw));
			pnts[3] = new Point(this.Width, (int)(cy - cw));
			pnts[4] = new Point(this.Width, (int)(cy + cw));
			pnts[5] = new Point((int)(cx + cw), (int)(cy + cw));
			pnts[6] = new Point((int)(cx + cw), this.Height);
			pnts[7] = new Point((int)(cx - cw), this.Height);
			pnts[8] = new Point((int)(cx - cw), (int)(cy + cw));
			pnts[9] = new Point(0, (int)(cy + cw));
			pnts[10] = new Point(0, (int)(cy - cw));
			pnts[11] = new Point((int)(cx - cw), (int)(cy - cw));
			GraphicsPath path = new GraphicsPath(pnts, types);
			this.Region = new Region(path);

		}
		protected override void Draw(Graphics g)
		{
			base.Draw(g);

			Color c = GetMGColor(m_Cross, m_CrossOpacity, this.ForeColor);
			SolidBrush sb = new SolidBrush(c);
			try
			{
				PointF [] pnts = new PointF[12];
				float cx = (float)this.Width / 2;
				float cy = (float)this.Height / 2;
				float cw = m_CrossWeight / 2;
				pnts[0] = new PointF(cx - cw, 0);
				pnts[1] = new PointF(cx + cw, 0);
				pnts[2] = new PointF(cx + cw, cy - cw);
				pnts[3] = new PointF(this.Width, cy - cw);
				pnts[4] = new PointF(this.Width, cy + cw);
				pnts[5] = new PointF(cx + cw, cy + cw);
				pnts[6] = new PointF(cx + cw, this.Height);
				pnts[7] = new PointF(cx - cw, this.Height);
				pnts[8] = new PointF(cx - cw, cy + cw);
				pnts[9] = new PointF(0, cy + cw);
				pnts[10] = new PointF(0, cy - cw);
				pnts[11] = new PointF(cx-cw, cy - cw);
				g.FillPolygon(sb, pnts);
			}
			catch
			{
				MessageBox.Show("a");
			}
			finally
			{
				sb.Dispose();
			}
		}
	}
}
