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
	public partial class MGLabel : MGControl
	{
		#region Label
		private StringFormat m_sf = new StringFormat();
		[Category("_MG_Label")]
		public StringAlignment StringAlignment
		{
			get { return m_sf.Alignment; }
			set
			{
				m_sf.Alignment = value;
				ChkOffScr();
			}
		}
		[Category("_MG_Label")]
		public StringAlignment StringLineAlignment
		{
			get { return m_sf.LineAlignment; }
			set
			{
				m_sf.LineAlignment = value;
				ChkOffScr();
			}
		}
		[Category("_MG_Label")]
		public string MGText
		{
			get { return this.Text; }
			set
			{
				this.Text = value;
				ChkOffScr();
			}
		}
		private Padding m_TextMargion = new Padding(0,0,0,0);
		[Category("_MG_Label")]
		public Padding TextMargion
		{
			get { return m_TextMargion; }
			set
			{
				m_TextMargion = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_LeftBoxColor = MG_COLORS.White;
		[Category("_MG_Label")]
		public MG_COLORS LeftBoxColor
		{
			get { return m_LeftBoxColor; }
			set
			{
				m_LeftBoxColor = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_RightBoxColor = MG_COLORS.White;
		[Category("_MG_Label")]
		public MG_COLORS RightBoxColor
		{
			get { return m_RightBoxColor; }
			set
			{
				m_RightBoxColor = value;
				ChkOffScr();
			}
		}
		private Size m_LeftBox = new Size(12, 12);
		[Category("_MG_Label")]
		public Size LeftBox
		{
			get { return m_LeftBox; }
			set
			{
				m_LeftBox = value;
				ChkOffScr();
			}
		}
		private Size m_RightBox = new Size(0, 0);
		[Category("_MG_Label")]
		public Size RightBox
		{
			get { return m_RightBox; }
			set
			{
				m_RightBox = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_Label = MG_COLORS.White;
		[Category("_MG_Label")]
		public MG_COLORS Label
		{
			get { return m_Label; }
			set
			{
				m_Label = value;
				ChkOffScr();
			}
		}
		[Category("_MG_Label")]
		public Font MGFont
		{
			get { return this.Font; }
			set
			{
				this.Font = value;
				ChkOffScr();
			}
		}
		private double m_LabelOpacity = 100;
		[Category("_MG_Label")]
		public double LabelOpacity
		{
			get { return m_LabelOpacity; }
			set
			{
				m_LabelOpacity = value;
				ChkOffScr();
			}
		}
		#endregion
		#region Back
		private MG_COLORS m_Back = MG_COLORS.Transparent;
		[Category("_MG_Label")]
		public MG_COLORS Back
		{
			get { return m_Back; }
			set
			{
				m_Back = value;
				ChkOffScr();
			}
		}
		private double m_BackOpacity = 0;
		[Category("_MG_Label")]
		public double BackOpacity
		{
			get { return m_BackOpacity; }
			set
			{
				m_BackOpacity = value;
				ChkOffScr();
			}
		}
		#endregion
		#region Frame
		private int m_FrameWeight = 0;
		[Category("_MG_Label")]
		public int FrameWeight
		{
			get { return m_FrameWeight; }
			set
			{
				m_FrameWeight = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_Frame = MG_COLORS.Gray;
		[Category("_MG_Label")]
		public MG_COLORS Frame
		{
			get { return m_Frame; }
			set
			{
				m_Frame = value;
				ChkOffScr();
			}
		}
		private double m_FramelOpacity = 100;
		[Category("_MG_Label")]
		public double FramelOpacity
		{
			get { return m_FramelOpacity; }
			set
			{
				m_FramelOpacity = value;
				ChkOffScr();
			}
		}
		private int m_LefMargint = 5;
		[Category("_MG_Label")]
		public int LeftMargin
		{
			get { return m_LefMargint; }
			set
			{
				m_LefMargint = value;
				ChkOffScr();
			}
		}
		private int m_RightMargin = 5;
		[Category("_MG_Label")]
		public int RightMargin
		{
			get { return m_RightMargin; }
			set
			{
				m_RightMargin = value;
				ChkOffScr();
			}
		}
		#endregion
		public MGLabel()
		{
			this.Size = new Size(150, 35);
			InitializeComponent();
			m_sf.Alignment = StringAlignment.Near;
			m_sf.LineAlignment = StringAlignment.Center;
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{

			Color c = GetMG_Colors(m_Label, m_LabelOpacity);

			SolidBrush sb = new SolidBrush(c);
			Pen p = new Pen(c);
			try
			{
				if (IsClear) g.Clear(Color.Transparent);
				Rectangle rct2 = MarginRect(rct);

				if ((m_BackOpacity > 0)&&(m_Back!=MG_COLORS.Transparent))
				{
					sb.Color = GetMG_Colors(m_Back, m_BackOpacity);
					g.FillRectangle(sb, rct2);
				}

				int lm = 0;
				int rm = 0;
				if ((m_LeftBox.Width > 0) && (m_LeftBox.Height > 0))
				{
					Rectangle r1 = new Rectangle(
						rct2.Left+m_LefMargint, 
						rct2.Top + (rct2.Height - m_LeftBox.Height) / 2, 
						m_LeftBox.Width, m_LeftBox.Height
						);
					sb.Color = GetMG_Colors(m_LeftBoxColor,100);
					g.FillRectangle(sb, r1);
					lm += m_LeftBox.Width + m_LefMargint;
				}
				if ((m_RightBox.Width > 0) && (m_RightBox.Height > 0))
				{
					Rectangle r2 = new Rectangle(
						rct2.Right - m_RightBox.Width -m_RightMargin,
						rct2.Top + (rct2.Height - m_RightBox.Height) / 2,
						m_RightBox.Width, m_RightBox.Height
						);
					sb.Color = GetMG_Colors(m_RightBoxColor, 100);
					g.FillRectangle(sb, r2);
					rm += m_RightBox.Width + m_RightMargin;
				}

				if (this.Text != "")
				{
					Rectangle r3 = new Rectangle
						(
						rct2.Left + lm + m_TextMargion.Left,
						rct2.Top + m_TextMargion.Top+ m_FrameWeight/2,
						rct2.Width - lm - rm - m_TextMargion.Left - m_TextMargion.Right,
						rct2.Height - m_TextMargion.Top - m_TextMargion.Bottom -m_FrameWeight
						) ;
					sb.Color = c;
					g.DrawString(this.Text, this.Font, sb, r3, m_sf);
				}
				if ((m_FrameWeight > 0)&&(m_Frame!=MG_COLORS.Transparent))
				{
					p.Color = GetMG_Colors(m_Frame, m_FramelOpacity);
					MG.Frame(g, p, m_FrameWeight, this.ClientRectangle);
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
