using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGDesigner
{
	public partial class MGLabel : Z_MG
	{
		private MG_COLOR m_Label = MG_COLOR.White;
		[Category("_MG")]
		public MG_COLOR Label
		{
			get { return m_Label; }
			set
			{
				m_Label = value;
				this.Invalidate();
			}
		}
		[Category("_MG")]
		public Font MGFont
		{
			get { return this.Font; }
			set
			{
				this.Font = value;
				this.Invalidate();
			}
		}
		private double m_LabelOpacity = 100;
		[Category("_MG")]
		public double LabelOpacity
		{
			get { return m_LabelOpacity; }
			set
			{
				m_LabelOpacity = value;
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
		private double m_BackOpacity = 0;
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
		private StringFormat m_sf = new StringFormat();
		[Category("_MG")]
		public StringAlignment StringAlignment
		{
			get { return m_sf.Alignment; }
			set
			{
				m_sf.Alignment = value;
				this.Invalidate();
			}
		}
		[Category("_MG")]
		public StringAlignment StringLineAlignment
		{
			get { return m_sf.LineAlignment; }
			set
			{
				m_sf.LineAlignment = value;
				this.Invalidate();
			}
		}
		[Category("_MG")]
		public string MGText
		{
			get { return this.Text; }
			set
			{
				this.Text = value;
				this.Invalidate();
			}
		}
		private int m_MGTextMargion = 0;
		[Category("_MG")]
		public int MGTextMargion
		{
			get { return m_MGTextMargion; }
			set
			{
				m_MGTextMargion = value;
				this.Invalidate();
			}
		}
		private int m_LeftMargion = 10;
		[Category("_MG")]
		public int LeftMargion
		{
			get { return m_LeftMargion; }
			set
			{
				m_LeftMargion = value;
				this.Invalidate();
			}
		}
		private Size m_LeftBox = new Size(12, 12);
		[Category("_MG")]
		public Size LeftBox
		{
			get { return m_LeftBox; }
			set
			{
				m_LeftBox = value;
				this.Invalidate();
			}
		}
		private Size m_RightBox = new Size(0, 0);
		[Category("_MG")]
		public Size RightBox
		{
			get { return m_RightBox; }
			set
			{
				m_RightBox = value;
				this.Invalidate();
			}
		}
		private int m_FrameWeight = 2;
		[Category("_MG")]
		public int FrameWeight
		{
			get { return m_FrameWeight; }
			set
			{
				m_FrameWeight = value;
				this.Invalidate();
			}
		}
		private MG_COLOR m_Frame = MG_COLOR.Gray;
		[Category("_MG")]
		public MG_COLOR Frame
		{
			get { return m_Frame; }
			set
			{
				m_Frame = value;
				this.Invalidate();
			}
		}
		private double m_FramelOpacity = 100;
		[Category("_MG")]
		public double FramelOpacity
		{
			get { return m_FramelOpacity; }
			set
			{
				m_FramelOpacity = value;
				this.Invalidate();
			}
		}
		public MGLabel()
		{
			m_sf.Alignment = StringAlignment.Near;
			m_sf.LineAlignment = StringAlignment.Center;
			this.Size = new Size(150, 25);
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

			Color c = GetMGColor(m_Label, m_LabelOpacity, this.ForeColor);
			SolidBrush sb = new SolidBrush(c);
			Pen p = new Pen(c);
			Rectangle rct = new Rectangle(m_LeftMargion, 0,this.Width-10,this.Height);
			try
			{
				if(m_BackOpacity>0)
				{
					Color c2 = GetMGColor(m_Back, m_BackOpacity, this.BackColor);
					sb.Color = c2;
					g.FillRectangle(sb, this.ClientRectangle);
				}

				int ml = m_LeftMargion;
				if(m_FrameWeight>0)
				{
					Color cp = GetMGColor(m_Frame, m_FramelOpacity, this.ForeColor);
					p.Color = cp;
					MG.Frame(g, p, m_FrameWeight, this.ClientRectangle);
					ml += m_FrameWeight;
				}
				if((m_LeftBox.Width>0)&& (m_LeftBox.Width > 0))
				{
					Rectangle r1 = new Rectangle(m_LeftMargion, (this.Height- m_LeftBox.Height)/2, m_LeftBox.Width, m_LeftBox.Height);
					sb.Color = c;
					g.FillRectangle(sb, r1);
					ml += m_LeftBox.Width;
				}
				if (this.Text!="")
				{
					ml += m_MGTextMargion;
					rct = new Rectangle(ml, 0, this.Width - ml, this.Height);
					sb.Color = c;
					g.DrawString(this.Text, this.Font, sb, rct, m_sf);
				}
			}
			catch
			{
				MessageBox.Show("a");
			}
			finally
			{
				p.Dispose();
				sb.Dispose();
			}
		}

	}
}
