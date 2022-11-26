using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
		const int RightWidth = 20;
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
		private bool m_IsShow = true;
		[Category("_MG")]
		public bool IsShow
		{
			get { return m_IsShow; }
			set
			{
				SetIsHow(value);
			}
		}
		public void SetIsHow(bool b)
		{
			bool e = (m_IsShow != b);
			m_IsShow = b;
			if (this.Controls.Count > 0)
			{
				foreach (Control c in this.Controls)
				{
					c.Visible = b;
				}
			}
			AutoLayout();
			if (e)
			{
				if(this.Parent is PropertyPanel)
				{
					PropertyPanel m = (PropertyPanel)this.Parent;
					m.AutoLayout();
				}
				OnIsShowChanged(EventArgs.Empty);
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
		public void AddControl(Control c)
		{
			this.Controls.Add(c);
			this.Controls.SetChildIndex(c, 0);
			AutoLayout();
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
			AutoLayout();
		}
		public void AutoLayout()
		{
			this.AutoSize = false;
			bool IsChild = (this.Parent is PropertyPanel);
			int t = HeaderHeight;
			if (IsChild == false) t = 0;
			if (this.Controls.Count > 0)
			{
				this.SuspendLayout();
				for (int i = this.Controls.Count - 1; i >= 0; i--)
				{
					if (this.Controls[i].Visible == false) continue;
					Point pp;
					Size sz;
					if (this.Controls[i] is PropertyPanel)
					{
						pp = new Point(0, t);
						
						PropertyPanel m = (PropertyPanel)this.Controls[i];
						if (m.IsShow==false)
						{
							sz = new Size(this.Width-RightWidth, HeaderHeight);
						}
						else
						{
							sz = new Size(this.Width - RightWidth, m.Height);
						}
						
					}
					else
					{
						pp = new Point(LeftWidth, t);
						sz = new Size(this.Width - RightWidth - LeftWidth, this.Controls[i].Height);

					}
					if (this.Controls[i].Location != pp) this.Controls[i].Location = pp;
					if (this.Controls[i].Size != sz) this.Controls[i].Size = sz;

					t += this.Controls[i].Height;
				}
				if(IsChild)
				{
					PropertyPanel p = (PropertyPanel)this.Parent;
					Size sz = new Size(p.Width, t+ FooterHeight);
					if(this.Size != sz) this.Size = sz;
				}
				this.ResumeLayout(false);
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
			if (IsChild)
			{
				Graphics g = pe.Graphics;
				//base.OnPaint(pe);
				SolidBrush sb = new SolidBrush(this.ForeColor);
				Pen p = new Pen(this.ForeColor, 1);
				try
				{
					int box = 10;
					Rectangle r = new Rectangle(5,(HeaderHeight-box)/2,box,box);
					g.DrawRectangle(p,r);
					g.DrawLine(p,r.Left+3,r.Top + box/2,r.Right-3, r.Top + box / 2);
					if (m_IsShow==false)
					{
						g.DrawLine(p, r.Left + box/2 ,r.Top + 3, r.Left + box/2, r.Bottom -3);
					}

					StringFormat sf = new StringFormat();
					sf.Alignment = StringAlignment.Near;
					sf.LineAlignment = StringAlignment.Center;

					r = new Rectangle(LeftWidth, 0, this.Width - LeftWidth - RightWidth, HeaderHeight);
					g.DrawString(m_Caption, this.Font, sb, r, sf);
					g.DrawLine(p, 0, HeaderHeight-2, this.Width, HeaderHeight-2);
				}
				finally
				{
					sb.Dispose();
				}
			}
		}
		protected override void OnMouseClick(MouseEventArgs e)
		{
			bool IsChild = (this.Parent is PropertyPanel);
			if((IsChild)&&(e.Y<HeaderHeight))
			{
				SetIsHow(!m_IsShow);
			}
			base.OnMouseClick(e);
		}

	}
}
