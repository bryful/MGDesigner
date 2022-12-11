using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public partial class PropertyPanelGroup : Panel
	{
		const int LeftWidth = 20;
		const int RightWidth = 25;
		private int DispY = 0;
		private int DispYMax = 0;
		// ******************************************
		public void AddControl(Control c, bool IsLayout = true)
		{
			this.Controls.Add(c);
			this.Controls.SetChildIndex(c, 0);
			if (IsLayout) AutoLayout();
		}
		// ******************************************
		public void AddControls(List<Control>? c, bool IsLayout = true)
		{
			if ((c != null) && (c.Count > 0))
			{
				foreach (Control c2 in c)
				{
					this.Controls.Add(c2);
					this.Controls.SetChildIndex(c2, 0);
				}

			}
			if (IsLayout) AutoLayout();
		}
		// ******************************************
		public void Clear()
		{
			this.Controls.Clear();
			this.AutoLayout();
		}
		// ******************************************
		public PropertyPanelGroup()
		{
			InitializeComponent();
			this.AutoSize = false;
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			//this.AutoSize = false;
			this.AutoScroll = false;
			AutoLayout();
		}
		// ******************************************
		public void AutoLayout()
		{
			int t = 0;
			int he = 0;
			this.SuspendLayout();
			if (this.Controls.Count > 0)
			{
				for (int i = this.Controls.Count - 1; i >= 0; i--)
				{
					if(this.Controls[i] is PropertyPanel)
					{
						((PropertyPanel)this.Controls[i]).AutoLayout();
					}
					he += this.Controls[i].Height;
				}
				DispYMax = he - this.Height;
				if (DispYMax < 0) DispYMax = 0;
				if (DispY > DispYMax) DispY = DispYMax;
			}
			else
			{
				DispY = 0;
				DispYMax = 0;
			}
			if (this.Controls.Count > 0)
			{
				for (int i = this.Controls.Count - 1; i >= 0; i--)
				{
					Point pp = new Point(0, t - DispY);
					Size sz = new Size(this.Width - RightWidth, this.Controls[i].Height);
					t += this.Controls[i].Height;
					if (this.Controls[i].Location != pp) this.Controls[i].Location = pp;
					if (this.Controls[i].Size != sz) this.Controls[i].Size = sz;
				}
			}
			this.ResumeLayout();
		}
		// ******************************************
		public void ScrolExec()
		{
			if (this.Controls.Count > 0)
			{
				int t = 0;
				this.SuspendLayout();
				for (int i = this.Controls.Count - 1; i >= 0; i--)
				{
					Point pp = new Point(0, t - DispY);
					if (this.Controls[i].Location != pp) this.Controls[i].Location = pp;
					t += this.Controls[i].Height;
				}
				this.ResumeLayout(false);
				this.Invalidate();
			}
		}
		// ******************************************
		protected override void InitLayout()
		{
			base.InitLayout();
			AutoLayout();
		}
		protected override void OnResize(EventArgs eventargs)
		{
			base.OnResize(eventargs);
			AutoLayout();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			bool IsChild = (this.Parent is PropertyPanel);
			Graphics g = pe.Graphics;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			//base.OnPaint(pe);
			SolidBrush sb = new SolidBrush(this.ForeColor);
			Pen p = new Pen(this.ForeColor, 1);
			try
			{
				g.Clear(this.BackColor);

				if (DispYMax > 0)
				{
					p.Color = this.ForeColor;
					int dx = this.Width - RightWidth / 2;
					g.DrawLine(p, dx, 5, dx, this.Height - 5);

					int y = (this.Height - 10) * DispY / DispYMax;
					sb.Color = this.ForeColor;
					g.FillEllipse(sb, new Rectangle(dx - 5, y, 10, 10));

				}

			}
			finally
			{
				sb.Dispose();
			}
		}
		// ***************************************************************************
		private int md_p = 0;
		private int md_y = 0;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (DispYMax > 0)
				{
					if (e.X > this.Width - RightWidth)
					{
						int y = (this.Height - 10) * DispY / DispYMax;
						if ((e.Y >= y - 10) && (e.Y <= y + 10))
						{
							md_p = e.Y;
							md_y = DispY;
						}
					}
				}
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (md_p != 0)
				{
					int dy = md_y + ((e.Y - md_p) * DispYMax / (this.Height - 10));
					if (dy < 0) dy = 0; else if (dy > DispYMax) dy = DispYMax;
					if (DispY != dy)
					{
						DispY = dy;
						ScrolExec();
					}
				}
			}
			base.OnMouseMove(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			md_p = 0;
			md_y = 0;
			base.OnMouseUp(e);
		}
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			int y = DispY - e.Delta * SystemInformation.MouseWheelScrollLines *3 / 120;
			if (y < 0) y = 0;
			else if (y > DispYMax) y = DispYMax;
			if(DispY != y)
			{
				DispY = y;
				ScrolExec();
				this.Invalidate();
			}
		}
	}
}
