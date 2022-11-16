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
	public partial class MGZebra : MGNone
	{
		private MG_COLOR m_Zebra = MG_COLOR.Red;
		[Category("_MG_Zebra")]
		public MG_COLOR Zebra
		{
			get { return m_Zebra; }
			set
			{
				m_Zebra = value;
				this.Invalidate();
			}
		}
		private MG_COLOR m_Back = MG_COLOR.Black;
		[Category("_MG_Zebra")]
		public MG_COLOR Back
		{
			get { return m_Back; }
			set
			{
				m_Back = value;
				ChkRegopn();
				this.Invalidate();
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
				ChkRegopn();
				this.Invalidate();
			}
		}
		private float m_Weight = 20;
		[Category("_MG_Zebra")]
		public float Weight
		{
			get { return m_Weight; }
			set
			{
				m_Weight = value;
				if (m_Weight < 5) m_Weight = 5;
				ChkRegopn(); 
				this.Invalidate();
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
				ChkRegopn();
				this.Invalidate();
			}
		}
		private double m_BackOpacity = 100;
		[Category("_MG_Zebra")]
		public double BackOpacity
		{
			get { return m_BackOpacity; }
			set
			{
				m_BackOpacity = value;
				ChkRegopn();
				this.Invalidate();
			}
		}
		public MGZebra()
		{
			InitializeComponent();
			ChkRegopn();
		}
		private void ChkRegopn()
		{
			if ((m_BackOpacity == 0) || (m_Back == MG_COLOR.Transparent))
			{
				this.Region = MG.ZebraRegion(this.ClientRectangle, m_Weight, m_Rot);
			}
			else
			{
				GraphicsPath path = new GraphicsPath();
				path.AddRectangle(this.ClientRectangle);
				this.Region = new Region(path);
			}
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkRegopn();
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
			Color c  = GetMGColor(m_Zebra, m_ZebraOpacity, this.ForeColor);
			Color b = GetMGColor(m_Back, m_BackOpacity, this.BackColor);

			SolidBrush sb = new SolidBrush(b);
			//Pen p = new Pen(c);
			try
			{

				if(m_BackOpacity > 0)
				{
					sb.Color = b;
					g.FillRectangle(sb, this.ClientRectangle);
				}
				if(m_ZebraOpacity>0)
				{
					sb.Color = c;
					MG.DrawZebra(g, sb, this.ClientRectangle, m_Weight, m_Rot);
					//int cnt = this.Width
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
