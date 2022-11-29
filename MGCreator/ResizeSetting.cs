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
	public partial class ResizeSetting : Control
	{
		private int DotSz = 10;
		private int DotIt = 3;
		private int DotL = 3;
		private int DotT = 3;

		private PosSet m_PosSet = PosSet.Center;
		[Category("_MG")]
		public PosSet PosSet
		{
			get { return m_PosSet; }
			set { m_PosSet = value; this.Invalidate(); }
		}
		private Color m_BaseColor = Color.DimGray;
		[Category("_MG")]
		public Color BaseColor
		{
			get { return m_BaseColor; }
			set { m_BaseColor = value;this.Invalidate(); }
		}
		public ResizeSetting()
		{
			int w = DotL*2 + DotSz*3 + DotIt*2;
			int h = DotT * 2 + DotSz * 3 + DotIt * 2;
			this.Size = new Size(w,h);
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			InitializeComponent();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor |
ControlStyles.UserMouse |
ControlStyles.Selectable,
true);
			this.BackColor = Color.Black;
			this.ForeColor = Color.LightGray;
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor);
			Graphics g = pe.Graphics;
			try
			{
				for (int y=0; y<3;y++)
				{
					int yy = y * (DotSz + DotIt) + DotT;
					for (int x = 0; x < 3; x++)
					{
						int xx = x * (DotSz + DotIt) + DotL;
						Rectangle r = new Rectangle(xx, yy, DotSz, DotSz);
						if ( (PosSet)(y*3+x) == m_PosSet )
						{
							sb.Color = this.ForeColor;
						}
						else
						{
							sb.Color = m_BaseColor;
						}
						g.FillRectangle(sb, r);
					}

				}
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}

		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if(e.Button== MouseButtons.Left)
			{
				int p = ((e.X - DotL) / (DotSz + DotIt)) + 3 * ((e.Y - DotT) / (DotSz + DotIt));
				if (p < 0) p = 0; else if (p >= (int)PosSet.None) p = (int)PosSet.None - 1;
				m_PosSet = (PosSet)p;
				this.Invalidate();
			}
			base.OnMouseDown(e);
		}
	}
}
