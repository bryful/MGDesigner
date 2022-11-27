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
		public readonly int HeaderCloseBoxSize = 12;

		private bool m_IsColseBtn = false;
		public bool IsColseBtn
		{
			get { return m_IsColseBtn; }
			set
			{
				m_IsColseBtn = value;
				this.Invalidate();
			}
		}

		// ***************************************************************************
		/*
		public MGForm? MGForm = null;
		public void ShowMGForm()
		{
			if(MGForm==null)
			{
				MGForm = new MGForm();
				MGForm.Show();
			}
			else
			{
				MGForm.Activate();
				MGForm.Focus();
			}
		}
		*/
		// ***************************************************************************
		public MGToolForm()
		{
			this.BackColor = Color.Black;
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
		/*
		protected MGForm? m_MGForm = null;
		[Category("_MG")]
		public virtual MGForm? MGForm
		{
			get { return m_MGForm; }
			set { SetMGForm(value); }
		}
		protected virtual void SetMGForm(MGForm? m)
		{
			m_MGForm = m;
		}
		*/
		// ***************************************************************************
		private Point m_MDPos = new Point(0, 0);
		private Size m_MDSize = new Size(0, 0);
		private int m_MD_Mode = 0;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((m_IsColseBtn==true)&&(e.Y < HeaderHeight) && (e.X > this.Width - HeaderCloseBoxSize - 5))
			{
				Application.Exit();
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

						m_MDSize.Width,
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
				
				Rectangle r = new Rectangle(0,0,this.Width,HeaderHeight-3);
				sb.Color = this.ForeColor;
				g.FillRectangle(sb, r);

				if (m_IsColseBtn)
				{

					r = new Rectangle(this.Width - HeaderCloseBoxSize - 5, (HeaderHeight - HeaderCloseBoxSize) / 2, HeaderCloseBoxSize, HeaderCloseBoxSize);
					sb.Color = this.BackColor;
					g.FillRectangle(sb, r);
				}

				r = new Rectangle(0, this.Height-10, this.Width - 1, 10);
				g.FillRectangle(sb, r);
				r = new Rectangle(0,0,this.Width-1,this.Height-1);
				p.Color = this.ForeColor;
				g.DrawRectangle(p, r);

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
	}
}
