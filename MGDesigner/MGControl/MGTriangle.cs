using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGDesigner
{
	public partial class MGTriangle : MGControl
	{
		private MG_COLORS m_Triangle = MG_COLORS.White;
		[Category("_MG_Triangle")]
		public MG_COLORS Triangle
		{
			get { return m_Triangle; }
			set
			{
				m_Triangle = value;
				ChkOffScr();
			}
		}

		private double m_TriangleOpacity = 100;
		[Category("_MG_Triangle")]
		public double TriangleOpacity
		{
			get { return m_TriangleOpacity; }
			set
			{
				m_TriangleOpacity = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_TriangleFill = MG_COLORS.Gray;
		[Category("_MG_Triangle")]
		public MG_COLORS TriangleFill
		{
			get { return m_TriangleFill; }
			set
			{
				m_TriangleFill = value;
				ChkOffScr();
			}
		}
		private double m_TriangleFillOpacity = 0;
		[Category("_MG_Triangle")]
		public double TriangleFillOpacity
		{
			get { return m_TriangleFillOpacity; }
			set
			{
				m_TriangleFillOpacity = value;
				ChkOffScr();
			}
		}
		private float m_TriangleLineWeigth = 2;
		[Category("_MG_Triangle")]
		public float TriangleLineWeigth
		{
			get { return m_TriangleLineWeigth; }
			set
			{
				m_TriangleLineWeigth = value;
				ChkOffScr();
			}
		}
		private float m_rot = 0;
		[Category("_MG_Triangle")]
		public float Rot
		{
			get { return m_rot; }
			set
			{
				m_rot = value;
				ChkOffScr();
			}
		}
		private MG.TrainglrStyle m_TraiangleStyle = MG.TrainglrStyle.Top;
		[Category("_MG_Triangle")]
		public MG.TrainglrStyle TrainglrStyle
		{
			get { return m_TraiangleStyle; }
			set
			{
				m_TraiangleStyle = value;
				ChkOffScr();
			}
		}
		public MGTriangle()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public override void Draw(Graphics g, Rectangle rct,bool IsClear=true)
		{

			Pen p = new Pen(this.ForeColor);
			SolidBrush sb = new SolidBrush(this.ForeColor);
			try
			{
				if(IsClear) g.Clear(Color.Transparent);
				Rectangle rct2 = MarginRect(rct);
				float cx = rct2.Left + (float)rct2.Width / 2;
				float cy = rct2.Top + (float)rct2.Height / 2;
				float radius = (float)rct2.Width;
				if (radius > (float)rct2.Height) radius = (float)rct2.Height;
				radius /= 2;
				switch (m_TraiangleStyle)
				{
					case MG.TrainglrStyle.Center:

						if((m_TriangleFillOpacity>0)&&(m_TriangleFill != MG_COLORS.Transparent))
						{
							PointF[] t1 = MG.TrianglePolygon(new PointF(cx, cy), radius, m_rot);
							sb.Color = GetMG_Colors(m_TriangleFill, m_TriangleFillOpacity);
							g.FillPolygon(sb, t1);
						}
						if ((m_TriangleOpacity > 0) && (m_Triangle != MG_COLORS.Transparent)&&(m_TriangleLineWeigth>0))
						{ 
							PointF[] t2 = MG.TrianglePolygon(new PointF(cx, cy), radius- m_TriangleLineWeigth / 2, m_rot);
							p.Color = GetMG_Colors(m_Triangle, m_TriangleOpacity);
							p.Width = m_TriangleLineWeigth;
							g.DrawPolygon(p, t2);
						}
						break;
					default:
						if ((m_TriangleFillOpacity > 0) && (m_TriangleFill != MG_COLORS.Transparent))
						{

							PointF[] t2 = MG.TrianglePolygon(rct2, m_TraiangleStyle);
							sb.Color = GetMG_Colors(m_TriangleFill, m_TriangleFillOpacity);
							g.FillPolygon(sb, t2);
						}
						if ((m_TriangleOpacity > 0) && (m_Triangle != MG_COLORS.Transparent) && (m_TriangleLineWeigth > 0))
						{
							RectangleF rct3 = new RectangleF(
								(float)rct2.Left + m_TriangleLineWeigth / 2,
								(float)rct2.Top + m_TriangleLineWeigth / 2,
								(float)rct2.Width - m_TriangleLineWeigth,
								(float)rct2.Height - m_TriangleLineWeigth
								);

							PointF[] t3 = MG.TrianglePolygon(rct3, m_TraiangleStyle);
							p.Color = GetMG_Colors(m_Triangle, m_TriangleOpacity);
							p.Width = m_TriangleLineWeigth;
							g.DrawPolygon(p, t3);
						}

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
