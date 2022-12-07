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
	public partial class RectangleEdit : Control
	{
		public class ValueChangedEventArgs : EventArgs
		{
			public Rectangle Value;
			public ValueChangedEventArgs(Rectangle v)
			{
				Value = v;
			}
		}
		public delegate void ValueChangedHandler(object sender, ValueChangedEventArgs e);
		public event ValueChangedHandler? ValueChanged;
		protected virtual void OnValueChanged(ValueChangedEventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		private int m_CellWidth = 80;
		private int m_CellHeight = 20;
		protected Rectangle m_Value = new Rectangle(0, 0, 0, 0);
		[Category("_MG")]
		public Rectangle Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value = value;
				this.Invalidate();
			}
		}
		public RectangleEdit()
		{
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			InitializeComponent();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor |
ControlStyles.UserMouse |
ControlStyles.Selectable, true);
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor);
			try
			{
				g.FillRectangle(sb, this.ClientRectangle);

				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				sb.Color = this.ForeColor;
				g.DrawString(MGs.ValueToString(m_Value), this.Font, sb, this.ClientRectangle, sf);
				g.DrawRectangle(p, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}

		}
		private bool m_isEdit = false;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (m_isEdit)
			{
				if (ChkEdit())
				{
					EndEdit();
				}
			}
			SetEdit();
			this.Invalidate();
			
			//base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
		}
		private void SetEdit()
		{
			if (m_isEdit) return;
			m_isEdit = true;
			TextBox tb = new TextBox();
			tb.Text = MGs.ValueToString(m_Value);
			tb.BorderStyle = BorderStyle.FixedSingle;
			tb.Size = new Size(m_CellWidth, m_CellHeight - 2);
			tb.Location = new Point(0, 0);
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
			Rectangle pt = new Rectangle(0, 0,0,0);
			if (MGs.StringToValue(tb.Text, ref pt))
			{
				m_Value = pt;
				ret = true;
				this.Invalidate();
				OnValueChanged(new ValueChangedEventArgs(m_Value));
			}
			return ret;

		}
		private void EndEdit()
		{
			TextBox tb = (TextBox)this.Controls[this.Controls.Count - 1];
			this.Controls.Remove(tb);
			tb.Dispose();
			m_isEdit = false;
			this.Focus();
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
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Invalidate();
		}
	}
}
