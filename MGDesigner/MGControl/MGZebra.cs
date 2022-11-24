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
	public partial class MGZebra : MGControl
	{
		private MG_COLORS m_Zebra = MG_COLORS.Red;
		[Category("_MG_Zebra")]
		public MG_COLORS Zebra
		{
			get { return m_Zebra; }
			set
			{
				m_Zebra = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_ZebraBack = MG_COLORS.Black;
		[Category("_MG_Zebra")]
		public MG_COLORS ZebraBack
		{
			get { return m_ZebraBack; }
			set
			{
				m_ZebraBack = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_ZebraFrame = MG_COLORS.Black;
		[Category("_MG_Zebra")]
		public MG_COLORS ZebraFrame
		{
			get { return m_ZebraFrame; }
			set
			{
				m_ZebraFrame = value;
				ChkOffScr();
			}
		}
		private float m_Rot = 45;
		[Category("_MG_Zebra")]
		public float Rot
		{
			get { return m_Rot; }
			set
			{
				m_Rot = value;
				if (m_Rot < -45) m_Rot = -45;
				else if (m_Rot > 45) m_Rot = 45;
				ChkOffScr();
			}
		}
		private float m_ZebraWeight = 20;
		[Category("_MG_Zebra")]
		public float ZebraWeight
		{
			get { return m_ZebraWeight; }
			set
			{
				m_ZebraWeight = value;
				if (m_ZebraWeight < 1) m_ZebraWeight = 1;
				ChkOffScr();
			}
		}
		private float m_ZebraFrameWeight = 2;
		[Category("_MG_Zebra")]
		public float ZebraFrameWeight
		{
			get { return m_ZebraFrameWeight; }
			set
			{
				m_ZebraFrameWeight = value;
				ChkOffScr();
			}
		}
		private double m_ZebraOpacity = 100;
		[Category("_MG_Zebra")]
		public double ZebraOpacity
		{
			get { return m_ZebraOpacity; }
			set
			{
				m_ZebraOpacity = value;
				ChkOffScr();
			}
		}
		private double m_ZebraBackOpacity = 100;
		[Category("_MG_Zebra")]
		public double ZebraBackOpacity
		{
			get { return m_ZebraBackOpacity; }
			set
			{
				m_ZebraBackOpacity = value;
				ChkOffScr();
			}
		}
		private double m_ZebraFrameOpacity = 100;
		[Category("_MG_Zebra")]
		public double ZebraFrameOpacity
		{
			get { return m_ZebraFrameOpacity; }
			set
			{
				m_ZebraFrameOpacity = value;
				ChkOffScr();
			}
		}
		public MGZebra()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear=true)
		{
			Color c = GetMG_Colors(m_Zebra, m_ZebraOpacity);
			Color b = GetMG_Colors(m_ZebraBack, m_ZebraBackOpacity);

			SolidBrush sb = new SolidBrush(b);
			Pen p = new Pen(c);
			try
			{
				if(IsClear)g.Clear(Color.Transparent);

				Rectangle rct2 = MarginRect(rct);
				Point[] ps = new Point[]
				{
					new Point(rct2.Left,rct2.Top),
					new Point(rct2.Right,rct2.Top),
					new Point(rct2.Right,rct2.Bottom),
					new Point(rct2.Left,rct2.Bottom)
				};
				GraphicsPath path = new GraphicsPath();
				path.AddPolygon(ps);
				Region region = new Region(path);
				g.SetClip(region, CombineMode.Replace);

				if ((m_ZebraBackOpacity > 0)&&(m_ZebraBack !=MG_COLORS.Transparent))
				{
					sb.Color = b;
					g.FillRectangle(sb, rct2);
				}
				if (m_ZebraOpacity > 0)
				{
					sb.Color = c;
					MG.DrawZebra(g, sb, rct2, m_ZebraWeight, m_Rot);
				}
				if ((m_ZebraFrameOpacity > 0) && (m_ZebraFrame != MG_COLORS.Transparent)
					&&(m_ZebraFrameWeight>0))
				{
					p.Color = GetMG_Colors(m_ZebraFrame, m_ZebraFrameOpacity);
					p.Width = m_ZebraFrameWeight;
					int w = (int)(m_ZebraFrameWeight / 2+0.5);
					if ((w <= 0) && (m_ZebraFrameWeight > 0)) w = 1;
					int w2 = w * 2; 
					Rectangle rct3 = new Rectangle
						(
							rct2.Left + w,
							rct2.Top + w,
							rct2.Width - w2,
							rct2.Height - w2
						); 
					g.DrawRectangle(p, rct3);
				}

			}
			catch
			{
			}
			finally
			{
				//p.Dispose();
				sb.Dispose();
			}



		}
	}
}
