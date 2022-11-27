using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public class PropChangedEventArgs : EventArgs
	{
		public double Value = 0;
		public PropChangedEventArgs(double v)
		{
			Value = v;
		}
	}
	public partial class PropEdit : Control
	{
		private int m_CellWidth = 80;
		private int m_CellHeight = 20;
		private int m_BtnWidth = 20;
		private int m_BtnHeight = 20;

		public delegate void PropChangedHandler(object sender, PropChangedEventArgs e);
		public event PropChangedHandler? PropChanged;
		protected virtual void OnPropChanged(PropChangedEventArgs e)
		{
			if (PropChanged != null)
			{
				PropChanged(this, e);
			}
		}
		private bool m_IsLeftRightMode = true;
		[Category("_MG")]
		public bool IsLeftRightMode
		{
			get { return m_IsLeftRightMode; }
			set { m_IsLeftRightMode = value; this.Invalidate(); }
		}
		private bool m_IsIntMode = false;
		[Category("_MG")]
		public bool IsIntMode
		{
			get { return m_IsIntMode; }
			set { m_IsIntMode = value; this.Invalidate(); }
		}
		private double m_Value = 0;
		[Category("_MG")]
		public double Value
		{
			get 
			{
				return m_Value;
			}
			set
			{
				SetValue(value);
			}
		}
		[Category("_MG")]
		public int ValueInt
		{
			get
			{

				return (int)(m_Value + 0);
			}
			set
			{
				SetValue((double)value);
			}
		}
		private double m_ValueMax = 32000;
		[Category("_MG")]
		public double ValueMax
		{
			get
			{
				return m_ValueMax;
			}
			set
			{
				m_ValueMax = value;
				if (m_Value > m_ValueMax) m_Value = m_ValueMax;
				this.Invalidate();
			}
		}
		private double m_ValueMin = 0;
		[Category("_MG")]
		public double ValueMin
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
		private bool _EventFlag = true;
		public bool EventFlag { get { return _EventFlag; } }
		public void SetEventFlag(bool b) { _EventFlag = b; }
		public void SetValue(double value)
		{
			if (_EventFlag == false) return;
			_EventFlag = false;
			bool flag = false;
			value = ChkValue(value);
			if (m_Value != value)
			{
				m_Value = value;
				flag = true;
			}
			if (flag)
			{
				OnPropChanged(new PropChangedEventArgs(m_Value));
			}
			_EventFlag = true;
			this.Invalidate();
		}
		private Color m_PushBackColor = Color.LightGray;
		private Color m_PushMojiColor = Color.White;
		private Color m_MojiColor = Color.Black;
		private Color m_ForcusedColor = Color.Black;
		private Color m_UnForcusedColor = Color.DarkGray;

		public PropEdit()
		{
			this.Size = new Size(m_CellWidth +m_BtnWidth*2, m_CellHeight);
			this.MinimumSize = new Size(0, this.Size.Height);
			this.MaximumSize = new Size(0, this.Size.Height);
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

		private Rectangle BtnRegion(int x, int y)
		{
			return new Rectangle(x + 1, y + 1, m_BtnWidth - 3, m_BtnHeight - 3);
		}
		private Point[] DrawArrow(Rectangle r, CrossDir d)
		{
			Point[] p = new Point[3];
			switch (d)
			{
				case CrossDir.Top:
					p[0] = new Point(r.Left + r.Width / 3, r.Top + r.Height * 2 / 3);
					p[1] = new Point(r.Left + r.Width / 2, r.Top + r.Height / 3);
					p[2] = new Point(r.Left + r.Width * 2 / 3, r.Top + r.Height * 2 / 3);
					break;
				case CrossDir.Bottom:
					p[0] = new Point(r.Left + r.Width / 3, r.Top + r.Height / 3);
					p[1] = new Point(r.Left + r.Width / 2, r.Top + r.Height * 2 / 3);
					p[2] = new Point(r.Left + r.Width * 2 / 3, r.Top + r.Height / 3);
					break;
				case CrossDir.Left:
					p[0] = new Point(r.Left + r.Width * 2 / 3, r.Top + r.Height / 3);
					p[1] = new Point(r.Left + r.Width / 3, r.Top + r.Height / 2);
					p[2] = new Point(r.Left + r.Width * 2 / 3, r.Top + r.Height * 2 / 3);
					break;
				case CrossDir.Right:
					p[0] = new Point(r.Left + r.Width / 3, r.Top + r.Height / 3);
					p[1] = new Point(r.Left + r.Width * 2 / 3, r.Top + r.Height / 2);
					p[2] = new Point(r.Left + r.Width / 3, r.Top + r.Height * 2 / 3);
					break;
				default:
					break;
			}
			return p;
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
				/*
				if (this.Focused)
				{
					p.Color = m_ForcusedColor;
				}
				else
				{
					p.Color = m_UnForcusedColor;
				}
				*/
				Rectangle r0 = BtnRegion(m_CellWidth , 0);
				Rectangle r1 = BtnRegion(m_CellWidth+m_BtnWidth, 0);
				switch (m_mdpos)
				{ 
					case CrossDir.Top:
						sb.Color = m_PushBackColor;
						g.FillRectangle(sb, r0);
						break;
					case CrossDir.Bottom:
						sb.Color = m_PushBackColor;
						g.FillRectangle(sb, r1);
						break;
					default:
						break;
				}

				Point[] l0;
				Point[] l1;
				if (m_IsLeftRightMode)
				{
					l0 = DrawArrow(r0, CrossDir.Left);
					l1 = DrawArrow(r1, CrossDir.Right);
				}
				else
				{
					l0 = DrawArrow(r0, CrossDir.Top);
					l1 = DrawArrow(r1, CrossDir.Bottom);
				}
				g.DrawLines(p, l0);
				g.DrawLines(p, l1);
				g.DrawRectangle(p, r0);
				g.DrawRectangle(p, r1);



				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				Rectangle r = new Rectangle(0, 0, m_CellWidth, m_CellHeight);
				sb.Color = this.ForeColor;

				double v = ChkValue( m_Value);
				g.DrawString($"{v}", this.Font, sb, r, sf);
				g.DrawRectangle(p, new Rectangle(0, 0, m_CellWidth - 1, m_CellHeight - 1));
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}



		}
		private CrossDir m_mdpos = CrossDir.None;
		private double m_mdvalue = 1;
		private bool m_isEdit = false;

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (m_isEdit)
			{
				ChkEdit();
				EndEdit();
			}
			if(e.X<m_CellWidth)
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
					m_mdvalue *= -1;
					m_mdpos = CrossDir.Top;
				}
				else
				{
					m_mdpos = CrossDir.Bottom;
					m_mdvalue *= 1;
				}
				this.Invalidate();
			}
			//base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (m_mdpos != CrossDir.None)
			{
				SetValue(m_Value + m_mdvalue); ;
				//OnCrossChanged(new CrossChangedEventArgs(m_mdpos, m_mdvalue));
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
			double v = ChkValue( m_Value);
			tb.Text = $"{v}";
			tb.BorderStyle = BorderStyle.FixedSingle;
			tb.Size = new Size(m_CellWidth, m_CellHeight-2);
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
		private double ChkValue(double v)
		{
			double ret = v;
			if(m_IsIntMode)
			{
				double f = 1;
				if (ret < 0) { f = -1; ret *= -1; }
				int ret2 = (int)(ret * 100 + 0.5);
				ret = (double)((double)ret2 / 100);
				if (m_IsIntMode)
				{
					ret = (double)((int)(ret + 0));
				}
				ret *= f;
			}
			if (ret > m_ValueMax) ret = m_ValueMax;
			else if (ret < m_ValueMin) ret = m_ValueMin;
			return ret;
		}
		private void ChkEdit()
		{
			TextBox tb = (TextBox)this.Controls[this.Controls.Count - 1];
			double v = 0;
			if (double.TryParse(tb.Text, out v) == true)
			{
				SetValue(v);
			}
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
				ChkEdit();
				EndEdit();
			}
			else if (e.KeyData == Keys.Escape)
			{
				EndEdit();
			}
		}
		protected override void OnResize(EventArgs e)
		{
			m_CellWidth = this.Width - (m_BtnWidth * 2);
			base.OnResize(e);
			this.Invalidate();
		}
	}
}
