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
	public enum PosSet
	{
		TopLeft,
		Top,
		TopRight,
		Left,
		Center,
		Right,
		BottomLeft,
		Bottom,
		BottomRight,
		None
	}
	public class PosSetEventArgs : EventArgs
	{
		public PosSet PosSet= PosSet.None;
		Point Pos = new Point(0, 0);
		public PosSetEventArgs(PosSet ps)
		{
			PosSet = ps;
		}
	}
	public partial class PosSetGrid : Control
	{
		// ****************************************************************************
		public delegate void PosSetedHandler(object sender, PosSetEventArgs e);
		public event PosSetedHandler? PosSeted;
		protected virtual void OnPosSeted(PosSetEventArgs e)
		{
			if (PosSeted != null)
			{
				PosSeted(this, e);
			}
		}
		public PosSetGrid()
		{
			this.Size = new Size(6 * 3 + 2, 6 * 3 + 2);
			this.MinimumSize = new Size(6 * 3 + 2, 6 * 3 + 2);
			this.MaximumSize = new Size(6 * 3 + 2, 6 * 3 + 2);
			InitializeComponent();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);
		}
		private void DrawGrid(int x, int y, Graphics g, SolidBrush sb)
		{
			int sz = 20;

			int xx = x + 1;
			int yy = y + 1;
			for (int j = 0; j < 3; j++)
			{
				xx = x + 1;
				for (int i = 0; i < 3; i++)
				{
					int v = j * 3 + i;
					if ((m_isMD)&&(v == (int)m_PosSet))
					{
						sb.Color = Color.White;
					}
					else
					{
						sb.Color = Color.DarkGray;
					}
					Rectangle r = new Rectangle(xx, yy, 5, 5);
					g.FillRectangle(sb, r);
					xx += 6;
				}
				yy += 6;

			}


		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			Pen p = new Pen(this.ForeColor);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Graphics g = pe.Graphics;
			try
			{
				DrawGrid(0, 0, g, sb);
			}
			finally
			{
				p.Dispose();
				sb.Dispose();
			}
		}

		private bool m_isMD = false;
		private PosSet m_PosSet = PosSet.None;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if ((e.X >= 0) && (e.X < 18))
				{
					int x = e.X / 6;
					if (x < 0) x = 0; else if (x > 2) x = 2;
					int y = e.Y / 6;
					if (y < 0) x = 0; else if (y > 2) y = 2;
					m_PosSet = (PosSet)(x + y * 3);
					m_isMD = true;
					this.Invalidate();
				}
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if(m_isMD)
				{
					OnPosSeted(new PosSetEventArgs(m_PosSet));
					m_PosSet = PosSet.None;
					m_isMD = false;
					this.Invalidate();
				}
			}
			base.OnMouseUp(e);
		}
	}
}
