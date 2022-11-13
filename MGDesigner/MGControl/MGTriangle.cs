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


	public partial class MGTriangle : MGPlate
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
					this.Region = MG.TriangleRegion(cnt, m_Length + m_weight , m_rot);
					break;
				default:
					this.Region = MG.TriangleRegion(this.ClientRectangle, m_weight, m_TraiangleStyle);
					break;
			}
		}
		protected override void Draw(Graphics g)
		{
			base.Draw(g);

			Pen p = new Pen(this.ForeColor);
			try
			{
				Color c = GetMGColor(m_Triangle, m_TriangleOpacity, this.ForeColor);
				p.Width = m_weight;
				p.Color = c;

				switch (m_TraiangleStyle)
				{
					case MG.TrainglrStyle.Center:
						PointF cnt = new PointF((float)this.Width / 2, (float)this.Height / 2);
						MG.Triangle(g, p, cnt, m_Length, m_rot);
						break;
					default:
						MG.Triangle(g, p, this.ClientRectangle, m_weight, m_TraiangleStyle);
						break;
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
