using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGDesigner
{
	public enum RotValue
	{
		Rot2_5 = 25,
		Rot5 = 50,
		Rot10 = 100,
		Rot15 = 150,
		Rot30 = 300,
		Rot90 = 900
	}
	public partial class MGCircleScale : MGNone
	{
		private RotValue m_RotValue = RotValue.Rot10;
		[Category("_MG")]
		public RotValue RotValue
		{
			get { return m_RotValue; }
			set
			{
				m_RotValue = value;
				this.Invalidate();
			}
		}
		private MG_COLOR m_ScaleA = MG_COLOR.White;
		[Category("_MG")]
		public MG_COLOR ScaleA
		{
			get { return m_ScaleA; }
			set
			{
				m_ScaleA = value;
				this.Invalidate();
			}
		}
		private MG_COLOR m_ScaleB = MG_COLOR.GrayLight;
		[Category("_MG")]
		public MG_COLOR ScaleB
		{
			get { return m_ScaleB; }
			set
			{
				m_ScaleB = value;
				this.Invalidate();
			}
		}
		private MG_COLOR m_ScaleC = MG_COLOR.Gray;
		[Category("_MG")]
		public MG_COLOR ScaleC
		{
			get { return m_ScaleC; }
			set
			{
				m_ScaleC = value;
				this.Invalidate();
			}
		}
		private float m_Weight = 15;
		[Category("_MG")]
		public float Weight
		{
			get { return m_Weight; }
			set
			{
				m_Weight = value;
				ChkRegopn();
				this.Invalidate();
			}
		}
		private float m_LineWeight = 2;
		[Category("_MG")]
		public float LineWeight
		{
			get { return m_LineWeight; }
			set
			{
				m_LineWeight = value;
				this.Invalidate();
			}
		}
		public MGCircleScale()
		{
			InitializeComponent();
			ChkRegopn();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkRegopn();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Draw(pe.Graphics);
		}
		private void ChkRegopn()
		{
			GraphicsPath path = new GraphicsPath();

			float cx = (float)this.Width / 2;
			float cy = (float)this.Height / 2;
			float l1 = cx;
			if (l1 > cy) l1 = cy;
			float l2 = l1 - m_Weight;
			path.AddEllipse(new Rectangle((int)(cx - l1 - 1), (int)(cy - l1 - 1), (int)(l1 * 2 + 2), (int)(l1 * 2 + 2)));
			path.AddEllipse(new Rectangle((int)(cx - l2 + 1), (int)(cy - l2 + 1), (int)(l2 * 2 - 2), (int)(l2 * 2 - 2)));

			this.Region = new Region(path);
		}
		protected override void Draw(Graphics g)
		{
			base.Draw(g);
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			Color ca = GetMGColor(m_ScaleA, 100, this.ForeColor);
			Color cb = GetMGColor(m_ScaleB, 100, this.ForeColor);
			Color cc = GetMGColor(m_ScaleC, 100, this.ForeColor);
			Pen p = new Pen(ca);
			float rot = (float)m_RotValue /10;
			try
			{
				float cx = (float)this.Width / 2;
				float cy = (float)this.Height / 2;
				float l1 = cx;
				if (l1 > cy) l1 = cy;
				float l2 = l1 - m_Weight;
				int cnt = (int)(360 / rot);
				for(int i=0; i < cnt; i++)
				{
					float r = i * rot;
					double xd = Math.Sin(r * Math.PI / 180);
					double yd = Math.Cos(r * Math.PI / 180);
					float x0 = (float)(cx + l1 * xd);
					float y0 = (float)(cy + l1 * yd);
					if( (r % 90)==0)
					{
						l2 = l1 - m_Weight;
						p.Color = ca;
						p.Width = m_LineWeight;
					}
					if ((r % 30) == 0)
					{
						l2 = l1 - m_Weight*0.7f;
						p.Color = cb;
						p.Width = m_LineWeight;
					}
					else
					{
						l2 = l1 - m_Weight * 0.4f;
						p.Color = cc;
						p.Width = m_LineWeight * 0.75f;
					}
					float x1 = (float)(cx + l2 * xd);
					float y1 = (float)(cy + l2 * yd);
					PointF [] pnts = new PointF[] {new PointF(x0,y0), new PointF(x1, y1) };
					g.DrawLines(p, pnts);

				}
			}
			catch
			{
				MessageBox.Show("a");
			}
			finally
			{
				p.Dispose();
			}
		}
	}
}
