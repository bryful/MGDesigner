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

namespace MGDesigner
{


	public partial class MGTriangle : Z_MG
	{
		private MG_COLOR m_Triangle = MG_COLOR.White;
		[Category("_MG")]
		public MG_COLOR Triangle
		{
			get { return m_Triangle; }
			set
			{
				m_Triangle = value;
				this.Invalidate();
			}
		}
		private double m_TriangleOpacity = 100;
		[Category("_MG")]
		public double TriangleOpacity
		{
			get { return m_TriangleOpacity; }
			set
			{
				m_TriangleOpacity = value;
				this.Invalidate();
			}
		}
		private MG_COLOR m_TriangleFill = MG_COLOR.Gray;
		[Category("_MG")]
		public MG_COLOR TriangleFill
		{
			get { return m_TriangleFill; }
			set
			{
				m_TriangleFill = value;
				this.Invalidate();
			}
		}
		private double m_TriangleFillOpacity = 0;
		[Category("_MG")]
		public double TriangleFillOpacity
		{
			get { return m_TriangleFillOpacity; }
			set
			{
				m_TriangleFillOpacity = value;
				this.Invalidate();
			}
		}
		private float m_Length = 100;
		[Category("_MG")]
		public float Length
		{
			get { return m_Length; }
			set
			{ 
				m_Length = value;
				ChkRegion();
				this.Invalidate(); 
			}
		}
		private float m_rot = 0;
		[Category("_MG")]
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
		[Category("_MG")]
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
		private MG.TrainglrStyle m_TraiangleStyle = MG.TrainglrStyle.Top;
		[Category("_MG")]
		public MG.TrainglrStyle TrainglrStyle
		{
			get { return m_TraiangleStyle; }
			set
			{
				m_TraiangleStyle = value;
				ChkRegion();
				this.Invalidate();
			}
		}
		public MGTriangle()
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
		private void ChkRegion()
		{
			switch(m_TraiangleStyle)
			{
				case MG.TrainglrStyle.Center:
					PointF cnt = new PointF((float)this.Width / 2, (float)this.Height / 2);
					this.Region = MG.TriangleRegion(cnt, m_Length + m_weight+1 , m_rot);
					break;
				default:
					this.Region = MG.TriangleRegion(this.ClientRectangle, m_weight, m_TraiangleStyle);
					break;
			}
		}
		protected override void Draw(Graphics g)
		{
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			base.Draw(g);

			Pen p = new Pen(this.ForeColor);
			SolidBrush sb = new SolidBrush(this.ForeColor);
			try
			{
				Color c = GetMGColor(m_Triangle, m_TriangleOpacity, this.ForeColor);
				p.Width = m_weight;
				p.Color = c;
				Color fc = GetMGColor(m_TriangleFill, m_TriangleFillOpacity, this.BackColor);
				sb.Color = fc;

				switch (m_TraiangleStyle)
				{
					case MG.TrainglrStyle.Center:
						PointF cnt = new PointF((float)this.Width / 2, (float)this.Height / 2);
						MG.Triangle(g, p,sb, cnt, m_Length, m_rot);
						break;
					default:
						MG.Triangle(g, p, sb,this.ClientRectangle, m_weight, m_TraiangleStyle);
						break;
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
