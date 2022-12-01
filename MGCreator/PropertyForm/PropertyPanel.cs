﻿using System;
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
	public partial class PropertyPanel : Panel
	{
		const int HeaderHeight = 20;
		const int FooterHeight = 5;
		const int LeftWidth = 20;
		const int RightWidth = 25;

		public new bool Visible
		{
			get { return base.Visible; }
			set
			{
				if ((ShowMGStyle & m_MGStyle) == 0)
				{
					base.Visible = false;
				}
				else
				{
					base.Visible = value;
				}
			}
		}

		// ******************************************
		protected MGStyle ShowMGStyle = MGStyle.ALL;

		protected MGStyle m_MGStyle = MGStyle.ALL;
		[Category("_MG")]
		public MGStyle MGStyle
		{
			get { return m_MGStyle; }
			set { SetMGStyle( value); }
		}
		public void SetMGStyle(MGStyle s)
		{
			m_MGStyle = s;

			bool _IsOpen = true;
			if(this.Parent is PropertyPanel)
			{
				_IsOpen = ((PropertyPanel)this.Parent).IsOpen;
			}
			if(_IsOpen==false)
			{
				Visible = false;
				return;
			}
			Visible = ((m_MGStyle & ShowMGStyle) != 0);
			if(this.Controls.Count>0)
			{
				foreach(Control c in this.Controls)
				{
					if(c is PropertyPanel)
					{
						((PropertyPanel)c).SetMGStyle(s);
					}else if (c is Edit)
					{
						((Edit)c).SetMGStyle(s);
					}
				}
			}
		}

		private int DispY = 0;
		private int DispYMax = 0;
		// ******************************************
		public delegate void IsShowChangedHandler(object sender, EventArgs e);
		public event IsShowChangedHandler? IsShowChanged;
		protected virtual void OnIsShowChanged(EventArgs e)
		{
			if (IsShowChanged != null)
			{
				IsShowChanged(this, e);
			}
		}
		// ******************************************
		private bool m_IsOpen = true;
		[Category("_MG")]
		public bool IsOpen
		{
			get { return m_IsOpen; }
			set
			{
				SetIsOpen(value);
			}
		}
		public void SetIsOpen(bool b)
		{
			bool e = (m_IsOpen != b);
			m_IsOpen = b;
			if (this.Controls.Count > 0)
			{
				foreach (Control c in this.Controls)
				{
					c.Visible =b;
				}
			}
			AutoLayout();
			if(this.Parent is PropertyPanel)
			{
				((PropertyPanel)this.Parent).AutoLayout();
			}
			this.Invalidate();
		}
		// ******************************************
		private string m_Caption = "PropertyPanel";
		[Category("_MG")]
		public  string Caption
		{
			get { return m_Caption; }
			set { m_Caption = value; this.Invalidate(); }
		}


		// ******************************************
		public void AddControl(Control c,bool IsLayout= true)
		{
			this.Controls.Add(c);
			this.Controls.SetChildIndex(c, 0);
			if(IsLayout)AutoLayout(this);
		}
		public void AddControls(List<Control> c, bool IsLayout = true)
		{
			foreach(Control c2 in c)
			{
				this.Controls.Add(c2);
				this.Controls.SetChildIndex(c2, 0);
				if (IsLayout) AutoLayout(this);
			}
			if (IsLayout) AutoLayout(this);
		}
		public void Clear()
		{
			this.Controls.Clear();
		}
		// ******************************************
		public PropertyPanel()
		{
			InitializeComponent();
			this.AutoSize = false;
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);
			this.BackColor = Color.Transparent;
			//this.AutoSize = false;
			this.AutoScroll = false;
			AutoLayout(this);
		}
		// ******************************************
		public void AutoLayout()
		{
			bool IsChild = (this.Parent is PropertyPanel);
			int t = HeaderHeight;
			if (IsChild == false)
			{
				t = 0;
				int he = 0;
				if (this.Controls.Count > 0)
				{
					for (int i = this.Controls.Count - 1; i >= 0; i--)
					{
						if (this.Controls[i].Visible == false) continue;
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
			}
			else
			{
				DispY = 0;
				DispYMax = 0;
			}
			if (this.Controls.Count > 0)
			{
				this.SuspendLayout();
				for (int i = this.Controls.Count - 1; i >= 0; i--)
				{
					if (this.Controls[i].Visible == false) continue;

					Point pp;
					Size sz;
					if(this.Controls[i] is PropertyPanel)
					{
						pp = new Point(0, t-DispY);
						sz = new Size(this.Width - RightWidth, this.Controls[i].Height);
					}
					else
					{
						pp = new Point(LeftWidth, t - DispY);
						sz = new Size(this.Width - RightWidth - LeftWidth, this.Controls[i].Height);
					}
					t += this.Controls[i].Height;
					if (this.Controls[i].Location != pp) this.Controls[i].Location = pp;
					if (this.Controls[i].Size != sz) this.Controls[i].Size = sz;
				}
				this.ResumeLayout(false);
			}
			if (IsChild)
			{
				this.Size = new Size(this.Width, t + FooterHeight);
			}

		}
		public void AutoLayout(PropertyPanel pp)
		{
			pp.AutoLayout();
			if(pp.Controls.Count>0)
			{
				foreach(Control c in pp.Controls)
				{
					if(c is PropertyPanel)
					{
						AutoLayout((PropertyPanel)c);
					}
				}
			}
		}
		public void ScrolExec()
		{
			if (this.Controls.Count > 0)
			{
				int t = 0;
				this.SuspendLayout();
				for (int i = this.Controls.Count - 1; i >= 0; i--)
				{
					if (this.Controls[i].Visible == false) continue;
					Point pp;
					if (this.Controls[i] is PropertyPanel)
					{
						pp = new Point(0, t - DispY);
					}
					else
					{
						pp = new Point(LeftWidth, t - DispY);
					}
					if (this.Controls[i].Location != pp) this.Controls[i].Location = pp;
					t += this.Controls[i].Height;
				}
				this.ResumeLayout(false);
				this.Invalidate();
			}
		}
		protected override void InitLayout()
		{
			base.InitLayout();
			AutoLayout();
		}
		protected override void OnResize(EventArgs eventargs)
		{
			base.OnResize(eventargs);
			AutoLayout();
			this.Invalidate();
		}
		protected override void OnControlAdded(ControlEventArgs e)
		{

			AutoLayout();
			base.OnControlAdded(e);
		}

		private void Topic_IsShowChanged(object sender, EventArgs e)
		{
			AutoLayout();
		}

		protected override void OnControlRemoved(ControlEventArgs e)
		{
			AutoLayout();
			base.OnControlRemoved(e);
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			bool IsChild = (this.Parent is PropertyPanel);
			Graphics g = pe.Graphics;
			//base.OnPaint(pe);
			SolidBrush sb = new SolidBrush(this.ForeColor);
			Pen p = new Pen(this.ForeColor, 1);
			try
			{
				g.Clear(this.BackColor);
				if (IsChild)
				{
					int box = 10;
					Rectangle r = new Rectangle(5, (HeaderHeight - box) / 2, box, box);
					g.DrawRectangle(p, r);
					g.DrawLine(p, r.Left + 3, r.Top + box / 2, r.Right - 3, r.Top + box / 2);
					if (m_IsOpen == false)
					{
						g.DrawLine(p, r.Left + box / 2, r.Top + 3, r.Left + box / 2, r.Bottom - 3);
					}

					StringFormat sf = new StringFormat();
					sf.Alignment = StringAlignment.Near;
					sf.LineAlignment = StringAlignment.Center;

					r = new Rectangle(LeftWidth, 0, this.Width - LeftWidth - RightWidth, HeaderHeight);
					g.DrawString(m_Caption, this.Font, sb, r, sf);
					g.DrawLine(p, 0, HeaderHeight - 2, this.Width, HeaderHeight - 2);

				}
				else
				{
					if (DispYMax > 0)
					{
						p.Color = this.ForeColor;
						int dx = this.Width - RightWidth / 2;
						int w = 10;
						g.DrawLine(p, dx, 5, dx, this.Height - 5);

						int y = (this.Height - 10) * DispY / DispYMax;
						sb.Color = this.ForeColor;
						g.FillEllipse(sb, new Rectangle(dx - 5, y, 10, 10));

					}
				}

			}
			finally
			{
				sb.Dispose();
			}
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			bool IsChild = (this.Parent is PropertyPanel);
			if((IsChild)&&(e.Y<HeaderHeight))
			{
				SetIsOpen(!m_IsOpen);
			}
			base.OnMouseClick(e);
		}
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
				if(md_p!=0)
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

	}
}
