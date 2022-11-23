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
	public partial class MGCircle : MGControl
	{
		private float m_Weight = 4;
		[Category("_MG_Circle")]
		public float Weight
		{
			get { return m_Weight; }
			set
			{
				m_Weight = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_Circle = MG_COLORS.White;
		[Category("_MG_Circle")]
		public MG_COLORS Circle
		{
			get { return m_Circle; }
			set
			{
				m_Circle = value;
				ChkOffScr();
			}
		}
		private double m_CircleOpacity = 100;
		[Category("_MG_Circle")]
		public double CircleOpacity
		{
			get { return m_CircleOpacity; }
			set
			{
				m_CircleOpacity = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_CircleFill = MG_COLORS.Gray;
		[Category("_MG_Circle")]
		public MG_COLORS CircleFill
		{
			get { return m_CircleFill; }
			set
			{
				m_CircleFill = value;
				ChkOffScr();
			}
		}
		private double m_CircleFillOpacity = 0;
		[Category("_MG_Circle")]
		public double CircleFillOpacity
		{
			get { return m_CircleFillOpacity; }
			set
			{
				m_CircleFillOpacity = value;
				ChkOffScr();
			}
		}
		public MGCircle()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
		}
		public override void Draw(Graphics g, Rectangle rct,bool IsClear=true)
		{
			Rectangle rct2 = MarginRect(rct);
			Pen p = new Pen(this.ForeColor);
			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{
				if (IsClear) g.Clear(Color.Transparent);
				float radius = rct2.Width / 2;
				float h = rct2.Height / 2;
				if (radius > h) radius = h;
				float cx = rct2.X + rct2.Width / 2;
				float cy = rct2.Y + rct2.Height / 2;
				if ((m_CircleFillOpacity > 0) && (m_CircleFill != MG_COLORS.Transparent))
				{
					Color f = GetMG_Colors(m_CircleFill, m_CircleFillOpacity);
					sb.Color = f;
					g.FillEllipse(sb, new RectangleF(cx - radius, cy - radius, radius * 2, radius * 2));
				}

				if ((m_CircleOpacity > 0) && (m_Circle != MG_COLORS.Transparent)&&(m_Weight>0))
				{
					p.Color = GetMG_Colors(m_Circle, m_CircleOpacity);
					p.Width = m_Weight;
					radius -= m_Weight / 2; 
					g.DrawEllipse(p, new RectangleF(cx - radius, cy - radius, radius * 2, radius * 2));
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
