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
	public partial class ColorEdit : Control
	{
		public class ValueChangedEventArgs : EventArgs
		{
			public Color Value;
			public ValueChangedEventArgs(Color v)
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
		protected Color m_Value = Color.Black;
		private int m_CaptionWidth = 40;
		[Category("_MG")]
		public Color Value
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
		public ColorEdit()
		{
			this.Size = new Size(80, 20);
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
				Rectangle f = new Rectangle(0, 0, this.Width, this.Height);
				g.FillRectangle(sb, f);

				f = new Rectangle(2, 2, m_CaptionWidth - 4, this.Height - 4);
				sb.Color = m_Value;
				g.FillRectangle(sb, f);


				f = new Rectangle(m_CaptionWidth, 0, this.Width-m_CaptionWidth, this.Height);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				sb.Color = this.ForeColor;
				g.DrawString(MGs.ValueToString(m_Value), this.Font, sb, f, sf);
				g.DrawRectangle(p, f);
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}
		}
		public void ShowColorPicker()
		{
			ColorDialog dlg = new ColorDialog();
			dlg.Color = m_Value;
			dlg.AnyColor = true;	
			dlg.FullOpen = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				m_Value = dlg.Color;
				this.Invalidate();
				OnValueChanged(new ValueChangedEventArgs(m_Value));
			}
		}
		private bool m_isEdit = false;

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if(e.X<m_CaptionWidth)
			{
				ShowColorPicker();
			}
			else
			{
				if (m_isEdit)
				{
					if (ChkEdit())
					{
						EndEdit();
					}
				}
				SetEdit();
			}
			base.OnMouseDown(e);
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
			tb.Size = new Size(this.Width-m_CaptionWidth,this.Height);
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
			Color c = Color.Black;
			if (MGs.StringToValue(tb.Text, ref c))
			{
				m_Value = c;
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
			if (m_isEdit)
			{
				ChkEdit();
				EndEdit();
			}

			base.OnResize(e);
			this.Invalidate();
		}

	}
}
