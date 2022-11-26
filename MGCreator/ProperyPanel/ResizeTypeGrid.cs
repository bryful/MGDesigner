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
	public partial class ResizeTypeGrid : Control
	{
		private ReSizeType m_ReSizeType = ReSizeType.Center;
		[Category("_MG")]
		public ReSizeType ReSizeType
		{
			get
			{
				return m_ReSizeType;
			}
			set
			{
				m_ReSizeType = value;
				this.Invalidate();
			}
		}
		public ResizeTypeGrid()
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
					if (v == (int)m_ReSizeType)
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
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if ((e.X >= 0) && (e.X < 18))
			{
				int x = e.X / 6;
				if (x < 0) x = 0; else if (x > 2) x = 2;
				int y = e.Y / 6;
				if (y < 0) x = 0; else if (y > 2) y = 2;
				m_ReSizeType = (ReSizeType)(x + y * 3);
				this.Invalidate();
			}
		}
	}
}
