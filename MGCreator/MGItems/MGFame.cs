using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public partial class MGFame : MGControl
	{
		// **************************************************************
		private MG_COLORS m_Line = MG_COLORS.White;
		[Category("_MG")]
		public MG_COLORS Line
		{
			get { return m_Line; }
			set
			{
				m_Line = value;
				ChkOffScr();
			}
		}
		private float m_LineWeight = 2;
		[Category("_MG")]
		public float LineWeight
		{
			get { return m_LineWeight; }
			set
			{
				m_LineWeight = value;
				ChkOffScr();
			}
		}
		// **************************************************************
		private float m_LineOpacity = 100;
		[Category("_MG")]
		public float LineOpacity
		{
			get { return m_LineOpacity; }
			set
			{
				m_LineOpacity = value;
				ChkOffScr();
			}
		}           
		// **************************************************************
		private MG_COLORS m_Fill = MG_COLORS.Yellow;
		[Category("_MG")]
		public MG_COLORS Fill
		{
			get { return m_Fill; }
			set
			{
				m_Fill = value;
				ChkOffScr();
			}
		}
		// **************************************************************
		private float m_FillOpacity = 100;
		[Category("_MG")]
		public float FillColorOpacity
		{
			get { return m_FillOpacity; }
			set
			{
				m_FillOpacity = value;
				ChkOffScr();
			}
		}       
		// **************************************************************
		public MGFame()
		{
			InitializeComponent();
			ChkOffScr();
		}

		// ************************************************************
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		// ************************************************************
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			if (IsClear) g.Clear(Color.Transparent);
			Pen pen = new Pen(this.ForeColor, 3);
			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{
				Rectangle rct2 = MarginRect(rct);
				sb.Color = GetColors(m_Fill, m_FillOpacity);
				g.FillRectangle(sb, rct2);

				pen.Color = GetColors(m_Line, m_LineOpacity);
				MGC.DrawFrame(g, pen, (int)m_LineWeight, rct2);
				pen.Color = Color.Red;
				g.DrawLine(pen,rct2.Left,rct2.Top, rct2.Right, rct2.Bottom);
			}
			finally
			{
				sb.Dispose();
				pen.Dispose();
			}
		}
	}
}
