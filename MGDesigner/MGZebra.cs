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
	public partial class MGZebra : Z_MG
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


				this.Invalidate();
			}
		}
		private float m_Weight = 45;
		[Category("_MG_Zebra")]
		public float Weight
		{
			get { return m_Weight; }
			set
			{
				m_Weight = value;
				if (m_Weight < 5) m_Weight = 5;
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
				this.Invalidate();
			}
		}
		public MGZebra()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Draw(pe.Graphics);
		}
		protected override void Draw(Graphics g)
		{
			base.Draw(g);
			Color c  = GetMGColor(m_Zebra, m_ZebraOpacity, this.ForeColor);
			Color b = GetMGColor(m_Back, m_BackOpacity, this.BackColor);

			SolidBrush sb = new SolidBrush(b);
			Pen p = new Pen(c);
			try
			{

				if(m_BackOpacity > 0)
				{
					g.FillRectangle(sb, this.ClientRectangle);
				}
				if(m_ZebraOpacity>0)
				{
					//int cnt = this.Width
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
