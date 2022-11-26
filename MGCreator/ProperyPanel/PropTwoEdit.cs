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
	public class P2ValeeChangedEventArgs : EventArgs
	{
		public int[] Value = new int[2] { 0, 0 };
		public P2ValeeChangedEventArgs(int[] v)
		{
			if (v.Length > 0) Value[0] = v[0];
			if (v.Length > 1) Value[1] = v[1];
		}
	}
	public partial class PropTwoEdit : Control
	{
		private int m_Width = 120;
		private int m_CellHeight = 20;
		public delegate void ValueChangedHandler(object sender, P2ValeeChangedEventArgs e);
		public event ValueChangedHandler? ValueChanged;
		protected virtual void OnValueChanged(P2ValeeChangedEventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		private int[] m_Value = new int[2] { 0, 0 };
		public int[] Value
		{
			get { return m_Value; }
			set
			{
				SetValue(Value);
			}
		}
		private bool _EventFlag = true;
		public bool EventFlag { get { return _EventFlag; } }
		public void SetEventFlag(bool b) { _EventFlag = b; }
		public void SetValue(int[] value)
		{
			bool flag = false;
			if (value.Length > 0)
			{
				if (m_Value[0] != value[0])
				{
					m_Value[0] = value[0];
					flag = true;
				}
			}
			if (value.Length > 1)
			{
				if (m_Value[1] != value[1])
				{
					m_Value[1] = value[1];
					flag = true;
				}
			}
			if ((flag)&&(_EventFlag))
			{
				OnValueChanged(new P2ValeeChangedEventArgs(m_Value));
			}
			this.Invalidate();
		}
		public int ValueFirst
		{
			get { return m_Value[0]; }
			set 
			{
				if(m_Value[0] != value)
				{
					m_Value[0] = value;
					if(_EventFlag)
						OnValueChanged(new P2ValeeChangedEventArgs(m_Value));
				}
			}
		}
		public int ValueSecond
		{
			get { return m_Value[1]; }
			set
			{
				if (m_Value[1] != value)
				{
					m_Value[1] = value;
					if (_EventFlag)
						OnValueChanged(new P2ValeeChangedEventArgs(m_Value));
				}
			}
		}
		public PropTwoEdit()
		{
			this.Size = new Size(m_Width*2, m_CellHeight);
			this.MinimumSize= new Size(0,this.Size.Height);
			this.MaximumSize = new Size(0, this.Size.Height);
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			Graphics g = pe.Graphics;
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor);
			try
			{
				g.FillRectangle(sb,new Rectangle(0,0,this.Width*2,m_CellHeight));

				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				Rectangle r = new Rectangle(0, 0, this.Width/2, m_CellHeight);
				sb.Color = this.ForeColor;
				g.DrawString($"{m_Value[0]}", this.Font, sb, r, sf);
				r = new Rectangle(this.Width / 2, 0, this.Width/2, m_CellHeight);
				g.DrawString($"{m_Value[1]}", this.Font, sb, r, sf);

				g.DrawLine(p, this.Width / 2,0, this.Width/2, m_CellHeight);
				g.DrawRectangle(p, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}



		}
		private bool m_isEdit = false;
		private void SetEdit(int v)
		{
			if (m_isEdit) return;
			m_isEdit = true;
			TextBox tb = new TextBox();
			if (v==0)
			{
				tb.Text = $"{m_Value[0]}";
			}
			else
			{
				tb.Text = $"{m_Value[1]}";
				v = 1;
			}
			tb.Tag = (Object)v;
			tb.BorderStyle = BorderStyle.FixedSingle;
			tb.Size = new Size(this.Width/2, m_CellHeight);
			tb.Location = new Point(v* this.Width / 2, 0);
			tb.KeyDown += Tb_KeyDown;
			tb.LostFocus += Tb_LostFocus;
			this.Controls.Add(tb);
			tb.Focus();
		}

		private void Tb_LostFocus(object? sender, EventArgs e)
		{
			if (sender == null) return;
			TextBox tb = (TextBox)sender;
			ChkEdit(tb);
			EndEdit(tb);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if(m_isEdit)
			{
				TextBox tb = (TextBox)this.Controls[this.Controls.Count - 1];
				ChkEdit(tb);
				EndEdit(tb);
			}
			int v = 0;
			if(e.X<this.Width/2)
			{
				v = 0;
			}
			else
			{
				v = 1;
			}
			SetEdit(v);
			base.OnMouseClick(e);

		}
		private void ChkEdit(TextBox tb)
		{
			int idx = (int)tb.Tag;
			int v = 0;
			if (int.TryParse(tb.Text, out v) == true)
			{
				if (idx == 0)
				{
					ValueFirst = v;
				}
				else
				{
					ValueSecond = v;
				}
			}
		}
		private void EndEdit(TextBox tb)
		{
			if(tb==null) return;
			this.Controls.Remove(tb);
			tb.Dispose();
			m_isEdit = false;
			this.Invalidate();
		}

		private void Tb_KeyDown(object? sender, KeyEventArgs e)
		{
			if (sender == null) return;
			TextBox tb = (TextBox)sender;
			if (e.KeyData == Keys.Enter)
			{
				ChkEdit(tb);
				EndEdit(tb);
			}
			else if(e.KeyData == Keys.Escape)
			{
				EndEdit(tb);
			}
		}

	}
}
