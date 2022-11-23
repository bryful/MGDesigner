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
	public partial class MGSheet : MGControl
	{
		#region Col
		private int m_col = 80;
		[Category("_MG_Sheet")]
		public int Col
		{
			get { return m_col; }
			set
			{
				SetCol(value);
				ChkOffScr();
			}
		}
		private void chkCol()
		{
			float w = 0;
			int idx = -1;
			if (m_cols.Length > 0)
			{
				for (int i = 0; i < m_cols.Length; i++)
				{
					w += m_cols[i];
					if (w > this.Width)
					{
						idx = i;
						break;
					}
				}
			}
			if ((idx >= 0) && (idx < m_cols.Length))
			{
				Array.Resize(ref m_cols, idx + 1);
			}
			else if (w < this.Width)
			{
				int a = (int)((this.Width - w) / m_col);
				if (a > 0)
				{
					int d = m_cols.Length;
					Array.Resize(ref m_cols, d + a);
					for (int i = d; i < m_cols.Length; i++)
					{
						m_cols[i] = m_col;
					}
				}
			}
		}
		private void SetCol(int v)
		{
			m_col = v;
			if (m_cols.Length > 0)
			{
				for (int i = 0; i < m_cols.Length; i++)
				{
					if (m_cols[i] < m_col)
					{
						m_cols[i] = m_col;
					}
				}
			}
			chkCol();
		}
		private float[] m_cols = new float[] { 80, 80, 80, 80 };
		[Category("_MG_Sheet")]
		public float[] Cols
		{
			get { return m_cols; }
			set
			{
				m_cols = value;
				chkCol();
				ChkOffScr();
			}
		}
		#endregion

		#region Row
		private int m_Row = 25;
		[Category("_MG_Sheet")]
		public int Row
		{
			get { return m_Row; }
			set
			{
				SetRow(value);
				ChkOffScr();
			}
		}
		private void ChkRow()
		{
			float h = 0;
			int idx = -1;
			if (m_Rows.Length > 0)
			{
				for (int i = 0; i < m_Rows.Length; i++)
				{
					h += m_Rows[i];
					if (h > this.Height)
					{
						idx = i;
						break;
					}
				}
			}
			if ((idx >= 0) && (idx < m_Rows.Length))
			{
				Array.Resize(ref m_Rows, idx + 1);
			}
			else if (h < this.Height)
			{
				int a = (int)((this.Height - h) / m_Row);
				if (a > 0)
				{
					int d = m_Rows.Length;
					Array.Resize(ref m_Rows, d + a);
					for (int i = d; i < m_Rows.Length; i++)
					{
						m_Rows[i] = m_Row;
					}
				}
			}
		}
		private void SetRow(int v)
		{
			m_Row = v;
			if (m_Rows.Length > 0)
			{
				for (int i = 0; i < m_Rows.Length; i++)
				{
					if (m_Rows[i] < m_Row)
					{
						m_Rows[i] = m_Row;
					}
				}
			}
			ChkRow();
		}
		private float[] m_Rows = new float[] { 25, 25, 25, 25 };
		[Category("_MG_Sheet")]
		public float[] Rows
		{
			get { return m_Rows; }
			set
			{
				m_Rows = value;
				ChkRow();
				ChkOffScr();
			}
		}
		#endregion

		private MG_COLORS m_Frame = MG_COLORS.White;
		[Category("_MG_Sheet")]
		public MG_COLORS Frame
		{
			get { return m_Frame; }
			set
			{
				m_Frame = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_Line = MG_COLORS.GrayLight;
		[Category("_MG_Sheet")]
		public MG_COLORS Line
		{
			get { return m_Line; }
			set
			{
				m_Line = value;
				ChkOffScr();
			}
		}
		private double m_LineOpacity = 100;
		[Category("_MG_Sheet")]
		public double LineOpacity
		{
			get { return m_LineOpacity; }
			set
			{
				m_LineOpacity = value;
				ChkOffScr();
			}
		}
		private int m_LineWeight = 2;
		[Category("_MG_Sheet")]
		public int LineWeight
		{
			get { return m_LineWeight; }
			set
			{
				m_LineWeight = value;
				ChkOffScr();
			}
		}
		private int m_FrameWeight = 2;
		[Category("_MG_Sheet")]
		public int FrameWeight
		{
			get { return m_FrameWeight; }
			set
			{
				m_FrameWeight = value;
				ChkOffScr();
			}
		}
		private double m_FrameOpacity = 100;
		[Category("_MG_Sheet")]
		public double FrameOpacity
		{
			get { return m_FrameOpacity; }
			set
			{
				m_FrameOpacity = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_Back = MG_COLORS.Transparent;
		[Category("_MG_Frame")]
		public MG_COLORS Back
		{
			get { return m_Back; }
			set
			{
				m_Back = value;
				ChkOffScr();
			}
		}
		private double m_BackOpacity = 100;
		[Category("_MG_Sheet")]
		public double BackOpacity
		{
			get { return m_BackOpacity; }
			set
			{
				m_BackOpacity = value;
				ChkOffScr();
			}
		}
		public MGSheet()
		{
			InitializeComponent();
		}
		protected override void OnResize(EventArgs e)
		{
			chkCol();
			ChkRow();
			base.OnResize(e);
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{

			Color c = GetMG_Colors(m_Frame, m_FrameOpacity);
			Color l = GetMG_Colors(m_Line, m_LineOpacity);
			Color b = GetMG_Colors(m_Back, m_BackOpacity);
			Pen p = new Pen(c);
			SolidBrush sb = new SolidBrush(b);
			try
			{
				if(IsClear)g.Clear(Color.Transparent);
				Rectangle rct2 = MarginRect(rct);
				if (m_BackOpacity > 0)
				{
					g.FillRectangle(sb, rct2);

				}
				p.Color = l;
				p.Width = m_LineWeight;
				float y = 0;
				for (int i = 0; i < m_Rows.Length; i++)
				{
					y += m_Rows[i];
					g.DrawLine(p, 0, y, this.Width, y);
				}
				float x = 0;
				for (int i = 0; i < m_cols.Length; i++)
				{
					x += m_cols[i];
					g.DrawLine(p, x, 0, x, this.Height);
				}

				p.Color = c;
				MG.Frame(g, p, m_FrameWeight, rct2);
			}
			catch
			{
			}
			finally
			{
			sb.Dispose();
				p.Dispose();
			}
		}
	}
}
