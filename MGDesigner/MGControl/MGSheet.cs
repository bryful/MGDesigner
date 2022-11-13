﻿using System;
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


	public partial class MGSheet : MGPlate
	{
		#region Col
		private int m_col = 80;
		[Category("_MG")]
		public int Col
		{
			get { return m_col; }
			set 
			{
				SetCol(value);
				this.Invalidate();
			}
		}
		private void chkCol()
		{
			int w = 0;
			int idx = -1;
			if (m_cols.Length > 0)
			{
				for (int i = 0; i < m_cols.Length; i++)
				{
					w += m_cols[i];
					if(w>this.Width)
					{
						idx = i;
						break;
					}
				}
			}
			if((idx>=0)&&(idx< m_cols.Length))
			{
				Array.Resize(ref m_cols, idx+1);
			}
			else if (w < this.Width)
			{
				int a = (this.Width - w) / m_col;
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
			m_col=v;
			if(m_cols.Length>0)
			{
				for(int i=0; i<m_cols.Length; i++)
				{
					if (m_cols[i]<m_col)
					{
						m_cols[i] = m_col;
					}
				}
			}
			chkCol();
		}
		private int[] m_cols = new int[] { 80, 80, 80, 80 };
		[Category("_MG")]
		public int[] Cols
		{
			get { return m_cols; }
			set
			{
				m_cols = value;
				chkCol();
				this.Invalidate();
			}
		}
		#endregion

		#region Row
		private int m_Row = 25;
		[Category("_MG")]
		public int Row
		{
			get { return m_Row; }
			set
			{
				SetRow(value);
				this.Invalidate();
			}
		}
		private void ChkRow()
		{
			int h = 0;
			int idx = -1;
			if (m_Rows.Length > 0)
			{
				for (int i = 0; i < m_Rows.Length; i++)
				{
					h += m_Rows[i];
					if(h>this.Height)
					{
						idx = i;
						break;
					}
				}
			}
			if((idx>=0)&&(idx< m_Rows.Length))
			{
				Array.Resize(ref m_Rows, idx+1);
			}
			else if (h < this.Height)
			{
				int a = (this.Height - h) / m_Row;
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
		private int[] m_Rows = new int[] { 25, 25, 25, 25 };
		[Category("_MG")]
		public int[] Rows
		{
			get { return m_Rows; }
			set
			{
				m_Rows = value;
				ChkRow();
				this.Invalidate();
			}
		}
		#endregion

		private MG_COLOR m_Frame = MG_COLOR.White;
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
		private MG_COLOR m_Line = MG_COLOR.GrayLight;
		[Category("_MG")]
		public MG_COLOR Line
		{
			get { return m_Line; }
			set
			{
				m_Line = value;
				this.Invalidate();
			}
		}
		private double m_LineOpacity = 100;
		[Category("_MG")]
		public double LineOpacity
		{
			get { return m_LineOpacity; }
			set
			{
				m_LineOpacity = value;
				this.Invalidate();
			}
		}
		private int m_LineWeight = 2;
		[Category("_MG")]
		public int LineWeight
		{
			get { return m_LineWeight; }
			set
			{
				m_LineWeight = value;
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
		private double m_FrameOpacity = 100;
		[Category("_MG")]
		public double FrameOpacity
		{
			get { return m_FrameOpacity; }
			set
			{
				m_FrameOpacity = value;
				this.Invalidate();
			}
		}
		public MGSheet()
		{
			InitializeComponent();
			Back = MG_COLOR.Transparent;
			chkCol();
			ChkRow();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			chkCol();
			ChkRow();
			this.Invalidate();
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Draw(pe.Graphics);
		}
		
		protected override void Draw(Graphics g)
		{
			base.Draw(g);

			Color c = GetMGColor(m_Frame, m_FrameOpacity, this.ForeColor);
			Color l = GetMGColor(m_Line, m_LineOpacity, this.ForeColor);
			Pen p = new Pen(c);
			try
			{
				p.Color = l;
				p.Width = m_LineWeight;
				int y = 0;
				for(int i = 0; i < m_Rows.Length; i++)
				{
					y += m_Rows[i];
					g.DrawLine(p, 0, y, this.Width, y);
				}
				int x = 0;
				for (int i = 0; i < m_cols.Length; i++)
				{
					x += m_cols[i];
					g.DrawLine(p, x, 0, x, this.Height);
				}

				p.Color = c;
				MG.Frame(g, p, m_FrameWeight, this.ClientRectangle);
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