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
	public partial class FloatEdit : Control
	{
		public class ValueChangedEventArgs : EventArgs
		{
			public float Value;
			public ValueChangedEventArgs(float v)
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
		private int m_BtnWidth = 20;
		private int m_BtnHeight = 20;
		private Color m_PushBackColor = Color.LightGray;

		protected float m_Value = 0;
		[Category("_MG")]
		public float Value
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
		protected float m_ValueMax = 30000;
		[Category("_MG")]
		public float ValueMax
		{
			get
			{
				if (m_ValueMax < 10)
				{
					//MessageBox.Show("A");
				}

				return m_ValueMax;
			}
			set
			{
				m_ValueMax = value;
				if(m_ValueMax < 10)
				{
					//MessageBox.Show("A");
				}
				if (m_Value > m_ValueMax) m_Value = m_ValueMax;
				this.Invalidate();
			}
		}
		protected float m_ValueMin = 0;
		[Category("_MG")]
		public float ValueMin
		{
			get
			{
				return m_ValueMin;
			}
			set
			{
				m_ValueMin = value;
				if (m_Value < m_ValueMin) m_Value = m_ValueMin;
				this.Invalidate();
			}
		}
		public FloatEdit()
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
ControlStyles.Selectable,
true);
		}
		public void SetMinMax(float n , float m)
		{
			ValueMin = n;
			ValueMax = m;
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			Graphics g = pe.Graphics;
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor);
			try
			{
				g.FillRectangle(sb, new Rectangle(0, 0, m_CellWidth, m_CellHeight));

				Rectangle r0 = SizeEdit.BtnRegion(m_CellWidth, 0, m_BtnWidth, m_BtnHeight);
				Rectangle r1 = SizeEdit.BtnRegion(m_CellWidth + m_BtnWidth, 0, m_BtnWidth, m_BtnHeight);
				switch (m_mdpos)
				{
					case CrossDir.Left:
						sb.Color = m_PushBackColor;
						g.FillRectangle(sb, r0);
						break;
					case CrossDir.Right:
						sb.Color = m_PushBackColor;
						g.FillRectangle(sb, r1);
						break;

					default:
						break;
				}

				Point[] l0 = SizeEdit.DrawArrow(r0, CrossDir.Left);
				Point[] l1 = SizeEdit.DrawArrow(r1, CrossDir.Right);
				g.DrawLines(p, l0);
				g.DrawLines(p, l1);
				g.DrawRectangle(p, r0);
				g.DrawRectangle(p, r1);



				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				Rectangle r = new Rectangle(0, 0, m_CellWidth, m_CellHeight);
				sb.Color = this.ForeColor;

				g.DrawString(MGs.ValueToString(m_Value), this.Font, sb, r, sf);
				g.DrawRectangle(p, new Rectangle(0, 0, m_CellWidth - 1, m_CellHeight - 1));
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}

		}
		private CrossDir m_mdpos = CrossDir.None;
		private float m_mdvalue = 1;
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
			if (e.X < m_CellWidth)
			{
				SetEdit();
			}
			else
			{
				if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					m_mdvalue *= 10;
				}
				if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
				{
					m_mdvalue *= 5;
				}
				if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
				{
					m_mdvalue *= 2;
				}

				if (e.X < m_CellWidth + m_BtnWidth)
				{
					m_mdpos = CrossDir.Left;
				}
				else if (e.X < m_CellWidth + m_BtnWidth * 2)
				{
					m_mdpos = CrossDir.Right;
				}
				this.Invalidate();
			}
			//base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (m_mdpos != CrossDir.None)
			{
				float v = 0;
				bool b = false;
				switch (m_mdpos)
				{
					case CrossDir.Left:
						v = m_Value - m_mdvalue;
						if (v < m_ValueMin) v = m_ValueMin;

						if (m_Value != v) { Value = v; b = true; }
						break;
					case CrossDir.Right:
						v = m_Value + m_mdvalue;
						if (v > m_ValueMax) v = m_ValueMax;

						if (m_Value != v) { Value = v; b = true; }
						break;

				}
				if (b) OnValueChanged(new ValueChangedEventArgs(m_Value));
				m_mdpos = CrossDir.None;
				m_mdvalue = 1;
			}
			else
			{
				base.OnMouseUp(e);
			}
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
			float v = 0;
			if (MGs.StringToValue(tb.Text, ref v))
			{
				if (v < m_ValueMin) v = m_ValueMin;
				else if (v > m_ValueMax) v = m_ValueMax;
				if (v != m_Value)
				{
					m_Value = v;
					ret = true;
					this.Invalidate();
					OnValueChanged(new ValueChangedEventArgs(m_Value));
				}
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
			m_CellWidth = this.Width - (m_BtnWidth * 2);
			this.Invalidate();
		}
	}
}
