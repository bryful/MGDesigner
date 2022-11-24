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
	public enum KagiStyle
	{
		TopLeft=0,
		TopRight,
		BottomRight,
		BottomLeft,
	}
	public partial class MGKagi : MGControl
	{
		private float m_kagiLineWeight = 1;
		[Category("_MG_Kagi")]
		public float kagiLineWeight
		{
			get { return m_kagiLineWeight; }
			set
			{
				m_kagiLineWeight = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_Kagi = MG_COLORS.White;
		[Category("_MG_Kagi")]
		public MG_COLORS Kagi
		{
			get { return m_Kagi; }
			set
			{
				m_Kagi = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_KagiLine = MG_COLORS.White;
		[Category("_MG_Kagi")]
		public MG_COLORS KagiLine
		{
			get { return m_KagiLine; }
			set
			{
				m_KagiLine = value;
				ChkOffScr();
			}
		}
		private double m_KagiOpacity = 100;
		[Category("_MG_Kagi")]
		public double KagiOpacity
		{
			get { return m_KagiOpacity; }
			set
			{
				m_KagiOpacity = value;
				ChkOffScr();
			}
		}
		private double m_KagiLineOpacity = 0;
		[Category("_MG_Kagi")]
		public double KagiLineOpacity
		{
			get { return m_KagiLineOpacity; }
			set
			{
				m_KagiLineOpacity = value;
				ChkOffScr();
			}
		}
		private float m_kagiWidth = 0;
		[Category("_MG_Kagi")]
		public float kagiWidth
		{
			get { return m_kagiWidth; }
			set
			{
				m_kagiWidth = value;
				ChkOffScr();
			}
		}
		private float m_kagiHeight = 0;
		[Category("_MG_Kagi")]
		public float kagiHeight
		{
			get { return m_kagiHeight; }
			set
			{
				m_kagiHeight = value;
				ChkOffScr();
			}
		}
		private float m_kagiWeightH = 5;
		[Category("_MG_Kagi")]
		public float kagiWeightH
		{
			get { return m_kagiWeightH; }
			set
			{
				m_kagiWeightH = value;
				ChkOffScr();
			}
		}
		private float m_kagiWeightV = 5;
		[Category("_MG_Kagi")]
		public float kagiWeightV
		{
			get { return m_kagiWeightV; }
			set
			{
				m_kagiWeightV = value;
				ChkOffScr();
			}
		}
		private KagiStyle m_kagiStyle = KagiStyle.BottomLeft;
		[Category("_MG_Kagi")]
		public KagiStyle kagiStyle
		{
			get { return m_kagiStyle; }
			set
			{
				m_kagiStyle = value;
				ChkOffScr();
			}
		}
		public MGKagi()
		{
			this.Size = new Size(30, 30);
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		private PointF[] KagiRegion(Rectangle r)
		{
			PointF[] ret = new PointF[6];
			float w = m_kagiWidth;
			if (w <= 0) w = (float)this.Width;
			float h = m_kagiHeight;
			if (h <= 0) h = (float)this.Height;
			float x = 0;
			float y = 0;
			switch (m_kagiStyle)
			{
				case KagiStyle.TopLeft:
					x = r.Left;
					y = r.Top;
					ret[0] = new PointF(x, y);
					ret[1] = new PointF(x + w, y);
					ret[2] = new PointF(x + w, y+m_kagiWeightV);
					ret[3] = new PointF(x + m_kagiWeightH, y + m_kagiWeightV);
					ret[4] = new PointF(x + m_kagiWeightH, y + h);
					ret[5] = new PointF(x , y + h);
					break;
				case KagiStyle.TopRight:
					x = r.Right-1;
					y = r.Top;
					ret[0] = new PointF(x , y);
					ret[1] = new PointF(x , y + h);
					ret[2] = new PointF(x - m_kagiWeightH , y + h);
					ret[3] = new PointF(x - m_kagiWeightH, y + m_kagiWeightV);
					ret[4] = new PointF(x - w, y + m_kagiWeightV);
					ret[5] = new PointF(x - w, y);
					break;
				case KagiStyle.BottomRight:
					x = r.Right - 1;
					y = r.Bottom -1;
					ret[0] = new PointF(x , y);
					ret[1] = new PointF(x - w, y);
					ret[2] = new PointF(x - w, y - m_kagiWeightV);
					ret[3] = new PointF(x - m_kagiWeightH, y - m_kagiWeightV);
					ret[4] = new PointF(x - m_kagiWeightH, y - h);
					ret[5] = new PointF(x, y - h);
					break;
				case KagiStyle.BottomLeft:
					x = r.Left;
					y = r.Bottom - 1;
					ret[0] = new PointF(x, y);
					ret[1] = new PointF(x, y-h);
					ret[2] = new PointF(x + m_kagiWeightH, y - h);
					ret[3] = new PointF(x + m_kagiWeightH, y - m_kagiWeightV);
					ret[4] = new PointF(x + w, y - m_kagiWeightV);
					ret[5] = new PointF(x + w, y);
					break;
			}

			return ret;
		}

		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			//base.Draw(g, rct, IsClear);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor);
			try
			{
				g.Clear(Color.Transparent);
				Rectangle rct2 = MarginRect(rct);

				PointF [] pnts = KagiRegion(rct2);

				if((m_KagiOpacity>0)&&(m_Kagi!=MG_COLORS.Transparent))
				{
					sb.Color = GetMG_Colors(m_Kagi, m_KagiOpacity);
					g.FillPolygon(sb, pnts);
				}
				if ((m_KagiLineOpacity > 0) && (m_KagiLine != MG_COLORS.Transparent))
				{
					p.Color = GetMG_Colors(m_KagiLine, m_KagiLineOpacity);
					p.Width = m_kagiLineWeight;
					g.FillPolygon(sb, pnts);
				}

			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}
		}
	}
}
