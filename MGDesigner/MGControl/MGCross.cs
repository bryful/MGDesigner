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
	public partial class MGCross : MGControl
	{
		private MG_COLORS m_CrossFill = MG_COLORS.White;
		[Category("_MG_Cross")]
		public MG_COLORS CrossFill
		{
			get { return m_CrossFill; }
			set
			{
				m_CrossFill = value;
				ChkOffScr();
			}
		}
		private double m_CrossFillOpacity = 100;
		[Category("_MG_Cross")]
		public double CrossFillOpacity
		{
			get { return m_CrossFillOpacity; }
			set
			{
				m_CrossFillOpacity = value;
				ChkOffScr();
			}
		}
		private float m_CrossWeight = 6;
		[Category("_MG_Cross")]
		public float CrossWeight
		{
			get { return m_CrossWeight; }
			set
			{
				m_CrossWeight = value;
				ChkOffScr();
			}
		}
		private float m_CrossWidth = 0;
		[Category("_MG_Cross")]
		public float CrossWidth
		{
			get { return m_CrossWidth; }
			set
			{
				m_CrossWidth = value;
				ChkOffScr();
			}
		}
		private float m_CrossHeight = 0;
		[Category("_MG_Cross")]
		public float CrossHeight
		{
			get { return m_CrossHeight; }
			set
			{
				m_CrossHeight = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_CrossLine = MG_COLORS.White;
		[Category("_MG_Cross")]
		public MG_COLORS CrossLine
		{
			get { return m_CrossLine; }
			set
			{
				m_CrossLine = value;
				ChkOffScr();
			}
		}
		private double m_CrossLineOpacity = 0;
		[Category("_MG_Cross")]
		public double CrossLineOpacity
		{
			get { return m_CrossLineOpacity; }
			set
			{
				m_CrossLineOpacity = value;
				ChkOffScr();
			}
		}
		private float m_CrossLineWeight = 2;
		[Category("_MG_Cross")]
		public float CrossLineWeight
		{
			get { return m_CrossLineWeight; }
			set
			{
				m_CrossLineWeight = value;
				ChkOffScr();
			}
		}
		public MGCross()
		{
			this.Size = new Size(50, 50);
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear=true)
		{
			Color f = GetMG_Colors(m_CrossFill, m_CrossFillOpacity);
			SolidBrush sb = new SolidBrush(f);
			Color l = GetMG_Colors(m_CrossLine, m_CrossLineOpacity);
			Pen p = new Pen(l);
			try
			{
				if (IsClear) g.Clear(Color.Transparent);
				Rectangle rct2 = MarginRect(rct);
				float w = m_CrossWidth;
				if (w <= 0) w = rct2.Width;
				float h = m_CrossHeight;
				if (h <= 0) h = rct2.Height;
				float cx = rct2.Left + (float)rct2.Width / 2;
				float cy = rct2.Top + (float)rct2.Height / 2;

				PointF[] points;
				if ((m_CrossFillOpacity>0)&&(m_CrossFill!=MG_COLORS.Transparent)&&(m_CrossWeight>0))
				{
					points = MG.CrossRegion
						(
						new PointF(cx, cy),
						w / 2,
						h / 2,
						m_CrossWeight
						);
					sb.Color = GetMG_Colors(m_CrossFill,m_CrossFillOpacity);

					g.FillPolygon(sb, points);

				}
				if ((m_CrossLineOpacity > 0) && (m_CrossLine != MG_COLORS.Transparent) && (m_CrossLineWeight > 0))
				{
					w -= m_CrossLineWeight;
					h -= m_CrossLineWeight;
					points = MG.CrossRegion
						(
						new PointF(cx, cy),
						w / 2,
						h / 2,
						m_CrossWeight - m_CrossLineWeight
						); ;
					p.Color = GetMG_Colors(m_CrossLine, m_CrossLineOpacity);
					p.Width = m_CrossLineWeight;
					g.DrawPolygon(p, points);

				}



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
