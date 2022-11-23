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

namespace MGDesigner
{
	public partial class MGGridcs : MGControl
	{
		private MG_COLORS m_Frame = MG_COLORS.White;
		[Category("_MG_Frame")]
		public MG_COLORS Frame
		{
			get { return m_Frame; }
			set
			{
				m_Frame = value;
				ChkOffScr();
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
				ChkOffScr();
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
				ChkOffScr();
			}
		}
		private MG_COLORS m_FrameBack = MG_COLORS.Transparent;
		[Category("_MG_Frame")]
		public MG_COLORS FrameBack
		{
			get { return m_FrameBack; }
			set
			{
				m_FrameBack = value;
				ChkOffScr();
			}
		}
		private double m_FrameBackOpacity = 100;
		[Category("_MG_Frame")]
		public double FrameBackOpacity
		{
			get { return m_FrameBackOpacity; }
			set
			{
				m_FrameBackOpacity = value;
				ChkOffScr();
			}
		}
		// *******************************************
		private MG_COLORS m_Grid = MG_COLORS.Gray;
		[Category("_MG_Grid")]
		public MG_COLORS Grid
		{
			get { return m_Grid; }
			set
			{
				m_Grid = value;
				ChkOffScr();
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
				ChkOffScr();
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
				ChkOffScr();
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
				ChkOffScr();
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
				ChkOffScr();
			}
		}
		private PointF m_GridCenterOffset = new PointF(0,0);
		[Category("_MG_Grid")]
		public PointF GridCenterOffset
		{
			get { return m_GridCenterOffset; }
			set
			{
				m_GridCenterOffset = value;
				ChkOffScr();
			}
		}
		[Category("_MG_Grid")]
		public float GridCenterOffsetX
		{
			get
			{
				return m_GridCenterOffset.X;
			}
			set
			{
				m_GridCenterOffset = new PointF(value, m_GridCenterOffset.Y);
				ChkOffScr();
			}
		}
		[Category("_MG_Grid")]
		public float GridCenterOffsetY
		{
			get
			{
				return m_GridCenterOffset.Y;
			}
			set
			{
				m_GridCenterOffset = new PointF( m_GridCenterOffset.X,value);
				ChkOffScr();
			}
		}
		public MGGridcs()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor);
			try
			{
				if(IsClear) g.Clear(Color.Transparent);
				Rectangle rct2 = MarginRect(rct);
				float cx = (float)rct2.Left + (float)rct2.Width / 2 + m_GridCenterOffset.X;
				float cy = (float)rct2.Top + (float)rct2.Height / 2 + m_GridCenterOffset.Y;

				//GraphicsPath path = new GraphicsPath();
				//path.AddRectangle(rct2);
				//g.SetClip(new Region(path), CombineMode.Replace);

				if((m_FrameBackOpacity>0)&&(m_FrameBack!=MG_COLORS.Transparent))
				{
					sb.Color = GetMG_Colors(m_FrameBack, m_FrameBackOpacity);
					g.FillRectangle(sb, rct2);
				}
				if ((m_GridOpacity > 0) && (m_Grid != MG_COLORS.Transparent)&&(m_GridWeight>0))
				{
					p.Color = GetMG_Colors(m_Grid, m_GridOpacity);
					p.Width = m_GridWeight;

					// 水平線
					float y = cy;
					while (y>=rct2.Top)
					{
						g.DrawLine(p, rct2.Left, y, rct2.Right, y);
						y-=m_GridHeight;
					}
					y = cy +m_GridHeight;
					while (y < rct2.Bottom)
					{
						g.DrawLine(p, rct2.Left, y, rct2.Right, y);
						y += m_GridHeight;
					}
					float x = cx;
					while (x >= rct2.Left)
					{
						g.DrawLine(p, x, rct2.Top, x,rct2.Bottom);
						x -= m_GridWidth;
					}
					x = cx + m_GridWidth;
					while (x < rct2.Right)
					{
						g.DrawLine(p, x, rct2.Top, x, rct2.Bottom);
						x += m_GridWidth;
					}
				}


				if ((m_FrameOpacity > 0) && (m_Frame != MG_COLORS.Transparent) && (m_FramedWeight > 0))
				{
					p.Color = GetMG_Colors(m_Frame, m_FrameOpacity);
					MG.Frame(g, p, (int)m_FramedWeight, rct2);
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
