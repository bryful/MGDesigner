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
	public partial class MGKagiEdge : MGControl
	{
		
		private float m_kagiLineWeight = 1;
		[Category("_MG_Kagi")]
		public float kagiLineWeight
		{
			get { return m_kagiLineWeight; }
			set
			{
				m_kagiLineWeight = value;
				if (m_kagiLineWeight < 0) m_kagiLineWeight = 0f;
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
		private float m_kagiWidth = 40;
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
		private float m_kagiHeight = 40;
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
		private bool[] m_DrawPos = new bool[4];
		[Category("_MG_Kagi")]
		public bool[] DrawPos
		{
			get { return m_DrawPos; }
			set
			{
				if (m_DrawPos.Length >= 4)
				{
					if (value.Length > 0) m_DrawPos[0] = value[0];
					if (value.Length > 1) m_DrawPos[1] = value[1];
					if (value.Length > 2) m_DrawPos[2] = value[2];
					if (value.Length > 3) m_DrawPos[3] = value[3];
				}
			}
		}


		public MGKagiEdge()
		{
			m_DrawPos[0] = true;
			m_DrawPos[1] = true;
			m_DrawPos[2] = true;
			m_DrawPos[3] = true;
			this.Size = new Size(400, 300);
			InitializeComponent();
		}
		private PointF[] KagiRegion(Rectangle r,KagiStyle ks)
		{
			PointF[] ret = new PointF[6];
			float w = m_kagiWidth;
			if (w <= 0) w = (float)this.Width;
			float h = m_kagiHeight;
			if (h <= 0) h = (float)this.Height;
			float x = 0;
			float y = 0;
			switch (ks)
			{
				case KagiStyle.TopLeft:
					x = r.Left;
					y = r.Top;
					ret[0] = new PointF(x, y);
					ret[1] = new PointF(x + w, y);
					ret[2] = new PointF(x + w, y + m_kagiWeightV);
					ret[3] = new PointF(x + m_kagiWeightH, y + m_kagiWeightV);
					ret[4] = new PointF(x + m_kagiWeightH, y + h);
					ret[5] = new PointF(x, y + h);
					break;
				case KagiStyle.TopRight:
					x = r.Right - 1;
					y = r.Top;
					ret[0] = new PointF(x, y);
					ret[1] = new PointF(x, y + h);
					ret[2] = new PointF(x - m_kagiWeightH, y + h);
					ret[3] = new PointF(x - m_kagiWeightH, y + m_kagiWeightV);
					ret[4] = new PointF(x - w, y + m_kagiWeightV);
					ret[5] = new PointF(x - w, y);
					break;
				case KagiStyle.BottomRight:
					x = r.Right - 1;
					y = r.Bottom - 1;
					ret[0] = new PointF(x, y);
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
					ret[1] = new PointF(x, y - h);
					ret[2] = new PointF(x + m_kagiWeightH, y - h);
					ret[3] = new PointF(x + m_kagiWeightH, y - m_kagiWeightV);
					ret[4] = new PointF(x + w, y - m_kagiWeightV);
					ret[5] = new PointF(x + w, y);
					break;
			}

			return ret;
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			//base.Draw(g, rct, IsClear);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor);
			try
			{
				if(IsClear) g.Clear(Color.Transparent);
				Rectangle rct2 = MarginRect(rct);

				for (int i = 0; i <= 3; i++)
				{
					if (m_DrawPos[i] == true)
					{
						PointF[] pnts = KagiRegion(rct2, (KagiStyle)i);
						if ((m_KagiOpacity > 0) && (m_Kagi != MG_COLORS.Transparent))
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
