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
    public partial class EditPadding : Edit
	{
		protected Padding m_Padding = new Padding(0,0,0,0);

		protected override void GetValeuFromControl()
		{
			if (m_Layer != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					Padding? p = (Padding?)GetValueFromProp(m_PropName,typeof(Padding));
					if (p != null) m_Padding = (Padding)p;
				}
				finally
				{
					this.Invalidate();
					_EventFLag = true;
				}
			}
		}
		
		protected override void SetValeuToControl()
		{
			if (m_Layer != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					SetValueToProp(m_PropName, m_Padding,typeof(Padding));
				}
				finally
				{
					_EventFLag = true;
				}
			}
		}       
		// ****************************************************************************
		[Category("_MG")]
		public Padding Paddings
		{
			get
			{
				return m_Padding;
			}
			set
			{
				m_Padding = value;
				this.Invalidate();
			}
		}
		public EditPadding()
		{
			SetCaptionPropName("Padding");
			SetTargetType(typeof(Padding));
			//this.Controls.Add(m_Padding);
			InitializeComponent();
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
				g.DrawString(MGs.ValueToString(m_Padding), this.Font, sb, r, sf);

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
			tb.Text = MGs.ValueToString(m_Padding);
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
			if ((m_MGForm != null) && (m_Layer != null))
			{
				Padding p = new Padding( m_Padding.Left, m_Padding.Top, m_Padding.Right, m_Padding.Bottom);
				if(MGs.StringToValue(tb.Text,ref p))
				{
					m_Padding = p;
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
