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
	public partial class MGCross : MGNone
	{
		private MG_COLOR m_CrossFill = MG_COLOR.White;
		[Category("_MG")]
		public MG_COLOR CrossFill
		{
			get { return m_CrossFill; }
			set
			{
				m_CrossFill = value;
				this.Invalidate();
			}
		}
		private double m_CrossFillOpacity = 100;
		[Category("_MG")]
		public double CrossFillOpacity
		{
			get { return m_CrossFillOpacity; }
			set
			{
				m_CrossFillOpacity = value;
				this.Invalidate();
			}
		}
		private int m_CrossWeight = 6;
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
		private MG_COLOR m_CrossLine = MG_COLOR.White;
		[Category("_MG")]
		public MG_COLOR CrossLine
		{
			get { return m_CrossLine; }
			set
			{
				m_CrossLine = value;
				this.Invalidate();
			}
		}
		private double m_CrossLineOpacity = 0;
		[Category("_MG")]
		public double CrossLineOpacity
		{
			get { return m_CrossLineOpacity; }
			set
			{
				m_CrossLineOpacity = value;
				this.Invalidate();
			}
		}
		private float m_CrossLineWeight = 2;
		[Category("_MG")]
		public float CrossLineWeight
		{
			get { return m_CrossLineWeight; }
			set
			{
				m_CrossLineWeight = value;
				this.Invalidate();
			}
		}
		public MGCross()
		{
			this.Size = new Size(40, 40);
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
			Graphics g = pe.Graphics;
			if (Anti) g.SmoothingMode = SmoothingMode.AntiAlias;
			Draw(g);
		}
		private void ChkRegion()
		{
			byte[] types = new byte[12];
			for (int i = 0; i < 12; i++) types[i] = (byte)PathPointType.Line;


			PointF[] pnts  = MG.CrossRegion(
					new Point(this.Width / 2, this.Height / 2),
					this.Width / 2 + m_CrossWeight/2,
					this.Height / 2 + m_CrossWeight / 2,
					m_CrossWeight
					);
			GraphicsPath path = new GraphicsPath(pnts, types);
			this.Region = new Region(path);

		}
		protected override void Draw(Graphics g)
		{
			base.Draw(g);

			Color f = GetMGColor(m_CrossFill, m_CrossFillOpacity, this.ForeColor);
			SolidBrush sb = new SolidBrush(f);
			Color l = GetMGColor(m_CrossLine, m_CrossLineOpacity, this.ForeColor);
			Pen p = new Pen(l);
			p.Width = m_CrossLineWeight;
			try
			{
				MG.Cross(g, p, sb,
					new Point(this.Width / 2 , this.Height / 2 ),
					this.Width / 2 - m_CrossWeight/2,
					this.Height / 2 - m_CrossWeight/2,
					m_CrossWeight
					);
			}
			catch
			{
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}
		}
	}
}
