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
	public partial class EditName : Control
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
		protected Label m_label = new Label();
		// *************************************************************
		private MGCcontrol? m_control = null;
		private void SetControl(MGCcontrol? c)
		{
			m_control = c;
			if (m_control != null)
			{
				this.Text = m_control.Name;
				this.Invalidate();
			}
		}
		private MGForm? m_MGForm = null;
		[Category("_MG")]
		public MGForm? MGForm
		{
			get { return m_MGForm; }
			set
			{
				m_MGForm = value;
				if (m_MGForm != null)
				{
					SetControl(m_MGForm.ForcusControl);
					m_MGForm.ForcusChanged += M_MGForm_ForcusChanged;
				}
			}
		}
		[Category("_MG")]
		public string Caption
		{
			get { return m_label.Text; }
			set { m_label.Text = value; }
		}
		private void M_MGForm_ForcusChanged(object sender, MGForm.ForcusChangedEventArgs e)
		{
			if (m_MGForm == null) return;
			if (e.Index >= 0)
			{
				SetControl((MGCcontrol)m_MGForm.Controls[e.Index]);
			}
		}
		// *************************************************************
		// *************************************************************

		public EditName()
		{
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(0, 20);
			this.MaximumSize = new Size(0, 20);
			// ********************
			m_label.Name = "EditName";
			m_label.Text = "Name";
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

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			Pen p = new Pen(this.ForeColor);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Graphics g = pe.Graphics;
			try
			{
				Rectangle r = new Rectangle(m_CaptionWidth, 0, this.Width - m_CaptionWidth, this.Height);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				sb.Color = this.ForeColor;
				g.DrawString(this.Text, this.Font, sb, r, sf);
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
			this.Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (m_isEdit)
			{
				if (ChkEdit())
				{
					EndEdit();
				}
			}
			if (e.X > m_CaptionWidth)
			{
				SetEdit();
			}
			else
			{
				base.OnMouseDown(e);
			}
		}
		private bool m_isEdit = false;
		private void SetEdit()
		{
			if (m_isEdit) return;
			m_isEdit = true;
			TextBox tb = new TextBox();
			tb.Text = this.Text;
			tb.BorderStyle = BorderStyle.FixedSingle;
			tb.Size = new Size(this.Width-m_CaptionWidth, this.Height - 2);
			tb.Location = new Point(m_CaptionWidth, 0);
			tb.KeyDown += Tb_KeyDown;
			tb.LostFocus += Tb_LostFocus;
			this.Controls.Add(tb);
			tb.Focus();
		}
		private void Tb_LostFocus(object? sender, EventArgs e)
		{
			ChkEdit();
			EndEdit();
		}
		private bool ChkEdit()
		{
			bool ret = false;
			TextBox tb = (TextBox)this.Controls[this.Controls.Count - 1];
			if(m_MGForm!=null)
			{
				string s = tb.Text.Trim();

				int idx = m_MGForm.FindControl(s);
				if(idx == -1)
				{
					this.Text = s;
					m_control.Name = s;
					ret = true;
				}
			}
			else
			{
				this.Text=tb.Text;
				ret = true;
			}
			return ret;

		}
		private void EndEdit()
		{
			TextBox tb = (TextBox)this.Controls[this.Controls.Count - 1];
			this.Controls.Remove(tb);
			tb.Dispose();
			m_isEdit = false;
			this.Invalidate();
		}
		private void Tb_KeyDown(object? sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				if (ChkEdit())
				{
					EndEdit();
				}
			}
			else if (e.KeyData == Keys.Escape)
			{
				EndEdit();
			}
		}
	}
}
