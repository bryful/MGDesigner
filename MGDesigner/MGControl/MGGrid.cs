using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGDesigner
{


	public partial class MGGrid : MGNone
	{
		private MG_COLOR m_Frame = MG_COLOR.White;
		[Category("_MG_Frame")]
		public MG_COLOR Frame
		{
			get { return m_Frame; }
			set
			{
				m_Frame = value;
				this.Invalidate();
			}
		}
		private int m_FramedWeight = 2;
		[Category("_MG_Frame")]
		public int FramedWeight
		{
			get { return m_FramedWeight; }
			set
			{
				m_FramedWeight = value;
				this.Invalidate();
			}
		}
		private double m_FrameOpacity = 100;
		[Category("_MG_Frame")]
		public double FrameOpacity
		{
			get { return m_FrameOpacity; }
			set
			{
				m_FrameOpacity = value;
				this.Invalidate();
			}
		}
		private MG_COLOR m_Back = MG_COLOR.Transparent;
		[Category("_MG")]
		public MG_COLOR Back
		{
			get { return m_Back; }
			set
			{
				m_Back = value;
				this.Invalidate();
			}
		}
		private double m_BackOpacity = 100;
		[Category("_MG")]
		public double BackOpacity
		{
			get { return m_BackOpacity; }
			set
			{
				m_BackOpacity = value;
				this.Invalidate();
			}
		}
		// *******************************************
		private MG_COLOR m_Grid = MG_COLOR.Gray;
		[Category("_MG_Grid")]
		public MG_COLOR Grid
		{
			get { return m_Grid; }
			set
			{
				m_Grid = value;
				this.Invalidate();
			}
		}
		private float m_GridWeight = 1;
		[Category("_MG_Grid")]
		public float GridWeight
		{
			get { return m_GridWeight; }
			set
			{
				m_GridWeight = value;
				if (m_GridWeight < 0) m_GridWeight = 0;
				this.Invalidate();
			}
		}
		private double m_GridOpacity = 100;
		[Category("_MG_Grid")]
		public double GridOpacity
		{
			get { return m_GridOpacity; }
			set
			{
				m_GridOpacity = value;
				this.Invalidate();
			}
		}
		private float m_GridWidth = 50;
		[Category("_MG_Grid")]
		public float GridWidth
		{
			get { return m_GridWidth; }
			set
			{
				m_GridWidth = value;
				this.Invalidate();
			}
		}
		private float m_GridHeight = 50;
		[Category("_MG_Grid")]
		public float GridHeight
		{
			get { return m_GridHeight; }
			set
			{
				m_GridHeight = value;
				this.Invalidate();
			}
		}
		public MGGrid()
		{
			InitializeComponent();
		}
		
		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			if (Anti) g.SmoothingMode = SmoothingMode.AntiAlias;
			Draw(g);
		}
		
		protected override void Draw(Graphics g)
		{
			base.Draw(g);


			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor);
			try
			{
				if(m_BackOpacity>0)
				{
					sb.Color = GetMGColor(m_Back, m_BackOpacity, this.BackColor);
					g.FillRectangle(sb, this.ClientRectangle);
				}
				if (m_GridWeight > 0)
				{
					p.Color = GetMGColor(m_Grid, m_GridOpacity, this.ForeColor);
					p.Width = m_GridWeight;
					MG.Grid(g, p, m_GridWidth, m_GridHeight, this.ClientRectangle);
				}
				if (m_FrameOpacity > 0)
				{
					p.Color = GetMGColor(m_Frame, m_FrameOpacity, this.ForeColor);
					MG.Frame(g, p, m_FramedWeight, this.ClientRectangle);
				}
			}
			catch
			{
			}
			finally
			{
				p.Dispose();
			}
		}
		
	}
}
