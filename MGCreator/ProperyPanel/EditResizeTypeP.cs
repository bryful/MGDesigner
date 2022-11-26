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
	public partial class EditResizeTypeP : Control
	{
		private int m_CaptionWidth = 60;
		[Category("_MG")]
		public int CaptionWidth
		{
			get { return m_CaptionWidth; }
			set
			{
				m_CaptionWidth = value;
				ChkSize();
			}
		}
		protected Label m_label = new Label(); public EditResizeTypeP()
		{
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(0, 20);
			this.MaximumSize = new Size(0, 20);
			// ********************
			m_label.Name = "ResizeRoot";
			m_label.Text = "SizeRoot";
			m_label.AutoSize = false;
			m_label.TextAlign = ContentAlignment.MiddleLeft;
			m_label.Location = new Point(0, 0);
			m_label.Size = new Size(60, 20);
			// ********************
			this.Controls.Add(m_label);
			InitializeComponent();
			ChkSize();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);

		}
		private void DrawGrid(int x, int y,Graphics g ,SolidBrush sb)
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
					if(v==(int)m_ReSizeType)
					{
						sb.Color = Color.White;
					}
					else
					{
						sb.Color = Color.DarkGray;
					}
					Rectangle r = new Rectangle(xx, yy, 10, 4);
					g.FillRectangle(sb, r);
					xx += 12;
				}
				yy += 6;

			}


		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			Pen p = new Pen(this.ForeColor);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Graphics g = pe.Graphics;
			try
			{
				DrawGrid(m_CaptionWidth, 0, g, sb);
			}
			finally
			{
				p.Dispose();
				sb.Dispose();
			}

		}
		public void ChkSize()
		{
			this.SuspendLayout();
			m_label.Width = m_CaptionWidth;
			m_label.Location = new Point(0, 0);
			this.ResumeLayout();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
		private ReSizeType m_ReSizeType = ReSizeType.Center;
		[Category("_MG")]
		public ReSizeType SelectedReSizeType
		{
			get
			{
				return m_ReSizeType;
			}
			set
			{
				m_ReSizeType =value;
				this.Invalidate();
			}
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if((e.X>=m_CaptionWidth)&&(e.X< m_CaptionWidth+36))
			{
				int x = (e.X- m_CaptionWidth)/12;
				if (x < 0) x = 0; else if (x > 2) x = 2;
				int y = e.Y / 6;
				if (y < 0) x = 0; else if (y > 2) y = 2;
				m_ReSizeType = (ReSizeType)(x + y * 3);
				this.Invalidate();
			}
		}
	}
}

