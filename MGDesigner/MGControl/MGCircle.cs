using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace MGDesigner
{
	public partial class MGCircle : MGNone
	{
		private float m_Weight = 4;
		[Category("_MG_Circle")]
		public float Weight
		{
			get { return m_Weight; }
			set
			{
				m_Weight = value;
				ChkCircle();
				this.Invalidate();
			}
		}
		private MG_COLOR m_Circle = MG_COLOR.White;
		[Category("_MG_Circle")]
		public MG_COLOR Circle
		{
			get { return m_Circle; }
			set
			{
				m_Circle = value;
				ChkCircle();
				this.Invalidate();
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
				ChkCircle();
				this.Invalidate();
			}
		}
		private MG_COLOR m_CircleFill = MG_COLOR.Gray;
		[Category("_MG_Circle")]
		public MG_COLOR CircleFill
		{
			get { return m_CircleFill; }
			set
			{
				m_CircleFill = value;
				this.Invalidate();
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
				ChkCircle();
				this.Invalidate();
			}
		}
		private float CRadius()
		{
			float ret = this.Width / 2 - m_Weight / 2;
			float h = this.Height / 2 - m_Weight / 2;
			if (ret > h) ret = h;
			return ret;
		}
		public MGCircle()
		{
			this.Size = new Size(50, 50);
			InitializeComponent();
			ChkCircle();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkCircle();
			this.Invalidate();
		}
		private void ChkCircle()
		{
			float r = (float)this.Width;
			if (r > (float)this.Height) r = (float)this.Height;

			GraphicsPath path =new GraphicsPath();
			float cx = (float)this.Width / 2;
			float cy = (float)this.Height / 2;


			path.AddEllipse(new RectangleF(cx - r / 2, cy - r / 2, r, r));
			if ((m_CircleFillOpacity == 0) || (m_Circle == MG_COLOR.Transparent))
			{
				float r2 = r - m_Weight;
				path.AddEllipse(new RectangleF(cx - r2 / 2, cy - r2 / 2, r2, r2));
			}
			this.Region = new Region(path);
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Graphics g = pe.Graphics;
			if (Anti) g.SmoothingMode = SmoothingMode.AntiAlias;
			Draw(g);
		}
		private RectangleF CircleRect(float r)
		{
			float cx = this.Width / 2;
			float cy = this.Height / 2;

			return new RectangleF(cx-r, cy-r, r*2, r*2);
		}
		protected override void Draw(Graphics g)
		{
			base.Draw(g);

			Pen p = new Pen(this.ForeColor);
			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{
				RectangleF rct = CircleRect(CRadius());
				if ((m_CircleFillOpacity > 0)&&(m_Circle != MG_COLOR.Transparent))
				{
					Color f = GetMGColor(m_CircleFill, m_CircleFillOpacity, this.BackColor);
					sb.Color = f;
					g.FillEllipse(sb, rct);
				}

				p.Color = GetMGColor(m_Circle, m_CircleOpacity, this.ForeColor);
				p.Width = m_Weight;
				g.DrawEllipse(p, rct);

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
