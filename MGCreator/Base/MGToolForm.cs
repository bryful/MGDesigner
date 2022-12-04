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
	public partial class MGToolForm : Form
	{
		public readonly int HeaderHeight = 25;
		public readonly int FooterHeight = 10;
		public readonly int HeaderCloseBoxSize = 12;

		private Color m_ActiveForeColor = Color.LightGray;
		private Color m_NoActiveForeColor = Color.Gray;

		// ***************************************************************************
		public MGToolForm()
		{
			this.BackColor = Color.FromArgb(40,40,40);
			this.ForeColor = Color.LightGray;
			this.FormBorderStyle = FormBorderStyle.None;
			this.TopMost = true;
			InitializeComponent();
			this.SetStyle(
				ControlStyles.DoubleBuffer |
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.SupportsTransparentBackColor,
				true);
		}
		// ***************************************************************************
		// ***************************************************************************
		private Point m_MDPos = new Point(0, 0);
		private Size m_MDSize = new Size(0, 0);
		private int m_MD_Mode = 0;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Y < HeaderHeight) && (e.X > this.Width - HeaderCloseBoxSize - 5))
			{
				if(e.Button == MouseButtons.Left)
				{
					if(this is MGProjectForm)
					{
						Application.Exit();
					}
					else if (this is MGColorsSetting)
					{
						this.DialogResult = DialogResult.Cancel;
						this.Close();
					}
					else
					{
						this.Hide();
					}

				}
				return;
			}
			if (e.Button == MouseButtons.Left)
			{
				if(e.Y>=this.Height-30)
				{
					m_MD_Mode = 2;
				}
				else
				{
					m_MD_Mode = 1;
				}
				m_MDPos = e.Location;
				m_MDSize = this.Size;
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int ax = e.X - m_MDPos.X;
				int ay = e.Y - m_MDPos.Y;
				if (m_MD_Mode == 1)
				{
					this.Location = new Point(ax + this.Left, ay + this.Top);
				}else if(m_MD_Mode == 2)
				{
					this.Size = new Size(

						m_MDSize.Width+ax,
						m_MDSize.Height + ay
						);
				}
			}
			base.OnMouseMove(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (m_MD_Mode != 0)
			{
				m_MD_Mode = 0;
				this.Invalidate();
			}
			base.OnMouseUp(e);
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Invalidate();
		}
		// ***************************************************************************
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p= new Pen(this.ForeColor, 1);
			Graphics g = e.Graphics;
			try
			{
				g.Clear(this.BackColor);
				Color c = m_NoActiveForeColor;
				if(Form.ActiveForm == this)
				{
					c = m_ActiveForeColor;
				}
				
				Rectangle r = new Rectangle(0,0,this.Width,HeaderHeight-3);
				//header
				sb.Color = c;
				g.FillRectangle(sb, r);

				//closebtn
				r = new Rectangle(this.Width - HeaderCloseBoxSize - 5, (HeaderHeight - HeaderCloseBoxSize) / 2, HeaderCloseBoxSize, HeaderCloseBoxSize);
				sb.Color = this.BackColor;
				g.FillRectangle(sb, r);

				//footer
				r = new Rectangle(0, this.Height- FooterHeight, this.Width - 1, FooterHeight);
				sb.Color = c;
				g.FillRectangle(sb, r);
				//Outline
				r = new Rectangle(0,0,this.Width-1,this.Height-1);
				p.Color = c;
				g.DrawRectangle(p, r);

				//caption
				sb.Color = this.BackColor;
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				r = new Rectangle(10, 0, this.Width-10, HeaderHeight - 3);
				g.DrawString(this.Text, this.Font, sb, r, sf);
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}
		}
		// ***************************************************************************
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			this.Invalidate();
		}
		protected override void OnDeactivate(EventArgs e)
		{
			base.OnDeactivate(e);
			this.Invalidate();
		}
	}
}
