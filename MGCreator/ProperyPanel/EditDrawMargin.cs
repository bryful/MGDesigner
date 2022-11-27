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
	public partial class EditDrawMargin : Edit
	{
		public new readonly MGStyle MGStyle = MGStyle.ALL;
		protected Padding m_DrawMargin = new Padding(0,0,0,0);

		protected override void GetValeuFromControl()
		{
			if (m_control != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				m_DrawMargin = m_control.DrawMargin;
				this.Invalidate();
				_EventFLag = true;
			}
		}
		protected override void SetValeuToControl()
		{
			if (m_control != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;	 
				m_control.DrawMargin = m_DrawMargin;
				_EventFLag = true;
			}
		}       
		// ****************************************************************************
		[Category("_MG")]
		public Padding DrawMargin
		{
			get
			{
				return m_DrawMargin;
			}
			set
			{
				m_DrawMargin=value;
				this.Invalidate();
			}
		}
		public EditDrawMargin()
		{
			Caption = "DrawMargin";
			InitializeComponent();
		}
		private string ValueToString()
		{
			return $"{m_DrawMargin.Left},{m_DrawMargin.Right},{m_DrawMargin.Top},{m_DrawMargin.Bottom}";
		}
		private bool StringToValue(string s)
		{
			bool ret = false;
			string[] sa  = s.Split(',');
			if (sa.Length < 4) return ret;
			int[] ia = new int[4];
			for(int i = 0; i < sa.Length; i++)
			{
				if (sa[i].Trim()=="")
				{
					ia[i] = 0;
				}
				else
				{
					int v = 0;
					if (int.TryParse(sa[i], out v))
					{
						ia[i] = v;
					}
					else
					{
						return ret;
					}

				}
			}
			m_DrawMargin = new Padding(ia[0], ia[1], ia[2], ia[3]);
			return true;
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor, 1);
			Graphics g = pe.Graphics;
			try
			{
				Rectangle r = new Rectangle(m_CaptionWidth, 0, this.Width - m_CaptionWidth, this.Height);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				sb.Color = this.ForeColor;
				g.DrawString(ValueToString(), this.Font, sb, r, sf);

			}
			finally
			{
				sb.Dispose();
				p.Dispose();

			}
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (m_isEdit)
			{
				ChkEdit();
				EndEdit();
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
			tb.Text = ValueToString();
			tb.BorderStyle = BorderStyle.FixedSingle;
			tb.Size = new Size(this.Width - m_CaptionWidth, this.Height - 2);
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
			if ((m_MGForm != null) && (m_control != null))
			{
				if(StringToValue(tb.Text))
				{
					SetValeuToControl();
					ret = true;
				}
			}
			else
			{
				this.Text = tb.Text;
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
