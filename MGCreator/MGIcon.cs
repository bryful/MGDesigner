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

namespace MGCreator
{
	public partial class MGIcon : Control
	{
		public enum IconStyle
		{
			LeftArrow,
			TopArrow,
			RightArrow,
			BottomArrow
		}
		private IconStyle m_sytle = IconStyle.TopArrow;
		public IconStyle Style
		{
			get { return m_sytle; }
			set {m_sytle = value;this.Invalidate(); }
		}
		private Color m_ForeColorRev = Color.FromArgb(50, 50, 50);
		private Color m_BackColorRev = Color.FromArgb(160,160,160);
		public MGIcon()
		{
			this.Size = new Size(20, 20);
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.FromArgb(150,150,150);
			InitializeComponent();
		}
		static public PointF[] DrawIcon(IconStyle st, Rectangle rct, float inter = 4)
		{
			PointF[] pF;
			float w = (float)rct.Width;
			float h = (float)rct.Height;
			float t = (float)rct.Top;
			float l = (float)rct.Left;
			switch (st)
			{
				case IconStyle.TopArrow:
					pF = new PointF[3];
					pF[0] = new PointF(l+w / 2, t + inter);
					pF[1] = new PointF(l + w - inter, t + h - inter);
					pF[2] = new PointF(l + inter, t + h - inter);
					break;
				case IconStyle.RightArrow:
					pF = new PointF[3];
					pF[0] = new PointF(l + inter, t + inter);
					pF[1] = new PointF(l + w - inter, t + h / 2);
					pF[2] = new PointF(l + inter, t + h - inter);

					break;
				case IconStyle.BottomArrow:
					pF = new PointF[3];
					pF[0] = new PointF(l + inter, t + inter);
					pF[1] = new PointF(l + w - inter, t + inter);
					pF[2] = new PointF(l + w / 2, t + h - inter);
					break;
				case IconStyle.LeftArrow:
				default:
					pF = new PointF[3];
					pF[0] = new PointF(l + w - inter, t + inter);
					pF[1] = new PointF(l + inter, t + h / 2);
					pF[2] = new PointF(l + w - inter, t + h - inter);
					break;

			}
			return pF;
		}
		private bool m_IsPushed = false;
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Color bc = this.BackColor;
			Color fc = this.ForeColor;
			if(m_IsPushed)
			{
				bc = Color.FromArgb(bc.ToArgb() ^ 0x00FFFFFF);
				fc = Color.FromArgb(fc.ToArgb() ^ 0x00FFFFFF);
			}
			SolidBrush sb = new SolidBrush(this.ForeColor);
			Pen p = new Pen(this.ForeColor);
			Graphics g = pe.Graphics;
			g.SmoothingMode = SmoothingMode.AntiAlias;
			try
			{
				//back
				g.Clear(bc);

				//
				PointF[] pF = DrawIcon(m_sytle,this.ClientRectangle,4);
				sb.Color = fc;
				g.FillPolygon(sb, pF);

				//outline
				Rectangle f = new Rectangle(1,1,this.Width-2,this.Height-2);
				p.Color = fc;
				p.Width = 1;
				g.DrawRectangle(p, f);
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			m_IsPushed = true;
			this.Invalidate();
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			m_IsPushed = false;
			this.Invalidate();
		}
	}
}
