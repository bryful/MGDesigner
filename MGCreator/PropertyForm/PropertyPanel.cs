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
	public partial class PropertyPanel : Panel
	{
		const int HeaderHeight = 20;
		const int FooterHeight = 5;
		const int LeftWidth = 5;
		const int RightWidth = 25;

		
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
			AutoLayoutParent();
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
			c.Visible = m_IsOpen;
			this.Controls.Add(c);
			this.Controls.SetChildIndex(c, 0);
			if(IsLayout) AutoLayoutParent();
		}
		public void AddControls(List<Control>? c, bool IsLayout = true)
		{
			if ((c != null) && (c.Count > 0)){
				foreach (Control c2 in c)
				{
					c2.Visible = m_IsOpen;
					this.Controls.Add(c2);
					this.Controls.SetChildIndex(c2, 0);
				}

			}
			if (IsLayout) AutoLayoutParent();
		}
		public void Clear(bool isEvent=true)
		{
			this.Controls.Clear();
			if(isEvent)this.AutoLayoutParent();
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
			//this.AutoSize = false;
			this.AutoScroll = false;
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			AutoLayout();
		}
		// ******************************************
		public bool AutoLayoutParent()
		{
			bool ret = false;
			if(this.Parent is PropertyPanelGroup)
			{
				((PropertyPanelGroup)this.Parent).AutoLayout();
				ret = true;
			}
			return ret;
		}

		// ******************************************
		public void AutoLayout()
		{
			int t = HeaderHeight;
			this.SuspendLayout();
			if (this.Controls.Count > 0)
			{
				if (m_IsOpen)
				{
					for (int i = this.Controls.Count - 1; i >= 0; i--)
					{
						this.Controls[i].Visible = true;
						Point pp = new Point(LeftWidth, t);
						Size sz = new Size(this.Width - LeftWidth, this.Controls[i].Height);
						t += this.Controls[i].Height;
						if (this.Controls[i].Location != pp) this.Controls[i].Location = pp;
						if (this.Controls[i].Size != sz) this.Controls[i].Size = sz;
					}
				}
				else
				{
					foreach(Control c in this.Controls)
					{
						c.Visible = false;
					}
				}

			}
			Size ss = new Size(this.Width, t + FooterHeight);
			if (this.Size != ss) this.Size = ss;
			this.ResumeLayout();

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
		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			//base.OnPaint(pe);
			SolidBrush sb = new SolidBrush(this.ForeColor);
			Pen p = new Pen(this.ForeColor, 1);
			try
			{
				g.Clear(this.BackColor);
				
				//btn
				int box = 10;
				Rectangle r = new Rectangle(0, (HeaderHeight - box) / 2, box, box);
				g.DrawRectangle(p, r);

				//-
				g.DrawLine(p, r.Left + 3, r.Top + box / 2, r.Right - 3, r.Top + box / 2);
				if (m_IsOpen == false)
				{
					// +
					g.DrawLine(p, r.Left + box / 2, r.Top + 3, r.Left + box / 2, r.Bottom - 3);
				}

				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;

				r = new Rectangle(LeftWidth+10, 0, this.Width - LeftWidth - RightWidth-10, HeaderHeight);
				g.DrawString(m_Caption, this.Font, sb, r, sf);
				g.DrawLine(p, 0, HeaderHeight - 2, this.Width, HeaderHeight - 2);

			}
			finally
			{
				sb.Dispose();
			}
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if((e.Y<HeaderHeight))
			{
				SetIsOpen(!m_IsOpen);
			}
			base.OnMouseClick(e);
		}
	}
}
