using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public class NameChangedEventArgs : EventArgs
	{
		string Name = "";
		public NameChangedEventArgs(string s)
		{
			Name = s;
		}
	}
	public partial class EditName : Edit
	{
		//public new readonly MGStyle MGStyle = MGStyle.ALL;
		// ****************************************************************************
		/*
		protected override void SetControl(MGControl? c)
		{
			m_control = c;
			if (m_control != null)
			{
				this.Text = m_control.Name;
				m_control.TextChanged += M_control_TextChanged;
				this.Invalidate();
			}
		}

		private void M_control_TextChanged(object? sender, EventArgs e)
		{
			if (m_control != null)
			{
				this.Text = m_control.Name;
			}
		}
		*/
		// ****************************************************************************
		public delegate void NameChangedHandler(object sender, NameChangedEventArgs e);
		public event NameChangedHandler? NameChanged;
		protected virtual void OnNameChanged(NameChangedEventArgs e)
		{
			if (_EventFLag == false) return;
			_EventFLag = false;
			if (NameChanged != null)
			{
				NameChanged(this, e);
			}
			_EventFLag = true;
		}       
		// **********************************************************
		protected override void GetValeuFromControl()
		{
			if (m_control != null)
			{

				if (_EventFLag == false) return;
				_EventFLag = false;
				this.Text = m_control.Name;
				_EventFLag = true;
				this.Invalidate();
			}
		}
		protected override void SetValeuToControl()
		{
			if (m_control != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				m_control.Name = this.Text;
				_EventFLag = true;

			}
		}       
		// *************************************************************
		/*
		private void M_MGForm_ForcusChanged(object sender, ForcusChangedEventArgs e)
		{
			if (m_MGForm == null) return;
			if (e.Index >= 0)
			{
				SetControl((MGControl)m_MGForm.Controls[e.Index]);
			}
		}
		*/
		// *************************************************************
		// *************************************************************

		public EditName()
		{
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(220, 20);
			this.MaximumSize = new Size(0, 20);
			Caption = "Name";
			// ********************
			// ********************
			InitializeComponent();
			ChkSize();

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
			//this.SuspendLayout();
			//this.ResumeLayout();
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
			if((m_MGForm!=null)&&(m_control!=null))
			{
				string s = tb.Text.Trim();
				int idx = m_MGForm.FindControl(s);
				if(idx == -1)
				{
					this.Text = s;
					//OnNameChanged(new NameChangedEventArgs(this.Text));
					SetValeuToControl();
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
