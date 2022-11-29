using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public class NumberChangedEventArgs : EventArgs
	{
		public object Value;
		public NumberChangedEventArgs(object v)
		{
			Value = v;
		}
	}
	public enum TargetType
	{
		INT = 0,
		FLOAT,
		DOUBLE
	}; 
	public partial class DoubleEdit : Control
	{
		private TargetType m_TargetType = TargetType.DOUBLE;

		public TargetType TargetType
		{
			get { return m_TargetType; }
			set { m_TargetType = value; this.Invalidate(); }
		}
		private bool IsTarget(object v)
		{
			return ((v.GetType() == typeof(int)) || (v.GetType() == typeof(float)) || (v.GetType() == typeof(float)));
		}

		private Type[] m_TargetTypeValue = new Type[] {typeof(int),typeof(float),typeof(double)};
		private int m_CellWidth = 80;
		private int m_CellHeight = 20;
		private int m_BtnWidth = 20;
		private int m_BtnHeight = 20;

		public delegate void NumberChangedHandler(object sender, NumberChangedEventArgs e);
		public event NumberChangedHandler? NumberChanged;
		protected virtual void OnNumberChanged(NumberChangedEventArgs e)
		{
			if (NumberChanged != null)
			{
				NumberChanged(this, e);
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
		
		/*
		[Category("_MG")]
		public bool IsIntMode
		{
			get { return (m_TargetType == TargetType.INT); }
			set {m_TargetType = value; this.Invalidate(); }
		}
		*/
		
		protected object m_Value = 0;
		[Category("_MG")]
		public object Value
		{
			get 
			{
				return Convert.ChangeType(m_Value, m_TargetTypeValue[(int)m_TargetType]);
			}
			set
			{
				if (IsTarget(value) == false) return; 
				SetValue(value);
			}
		}
		private string m_ValueToStr()
		{
			switch (m_TargetType)
			{
				case TargetType.INT:
					int iv = (int)Convert.ChangeType(m_Value,typeof(int));
					return $"{iv}";
				case TargetType.FLOAT:
					float fv = (float)Convert.ChangeType(m_Value, typeof(float));
					return $"{fv}";
				case TargetType.DOUBLE:
					double dv = (double)Convert.ChangeType(m_Value, typeof(double));
					return $"{dv}";
				default:
					return "";
			}

		}
		[Category("_MG")]
		public int ValueInt
		{
			get
			{
				return (int)Convert.ChangeType(m_Value, typeof(int));
			}
			set
			{
				SetValue((object)value);
			}
		}

		protected double m_ValueMax = 32000;
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
				double dv = (double)Convert.ChangeType(m_Value, typeof(double));
				if (dv > m_ValueMax) 
					m_Value = Convert.ChangeType(m_ValueMax, m_TargetTypeValue[(int)m_TargetType]);
				this.Invalidate();
			}
		}
		protected double m_ValueMin = 0;
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
				double dv = (double)Convert.ChangeType(m_Value, typeof(double));
				if (dv < m_ValueMin)
					m_Value = Convert.ChangeType(m_ValueMin, m_TargetTypeValue[(int)m_TargetType]);
				this.Invalidate();
			}
		}
		private bool _EventFlag = true;
		public bool EventFlag { get { return _EventFlag; } }
		public void SetEventFlag(bool b) { _EventFlag = b; }
		public void SetValue(object value)
		{
			if (_EventFlag == false) return;
			if(IsTarget(value)==false) return;
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
				OnNumberChanged(new NumberChangedEventArgs(m_Value));
			}
			_EventFlag = true;
			this.Invalidate();
		}
		private Color m_PushBackColor = Color.LightGray;
		private Color m_PushMojiColor = Color.White;
		private Color m_MojiColor = Color.Black;
		private Color m_ForcusedColor = Color.Black;
		private Color m_UnForcusedColor = Color.DarkGray;

		public DoubleEdit()
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

				g.DrawString(m_ValueToStr(), this.Font, sb, r, sf);
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
				Value = (double)m_Value + (double)m_mdvalue;
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
			tb.Text = $"{m_ValueToStr()}";
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
		private object ChkValue(object v)
		{
			object v2 = Convert.ChangeType(v, m_TargetTypeValue[(int)m_TargetType]);
			
			object vmax = Convert.ChangeType(m_ValueMax, m_TargetTypeValue[(int)m_TargetType]);
			object vmin = Convert.ChangeType(m_ValueMin, m_TargetTypeValue[(int)m_TargetType]);
			switch (m_TargetType)
			{
				case TargetType.INT:
					
					if ((int)v2 > (int)vmax) v2 = vmax;
					else if ((int)v2 < (int)vmin) v2 = vmin;
					break;
				case TargetType.FLOAT:
					v2 = (float)((int)((float)v2 * 100 + 0.5)) / 100;
					if ((float)v2 > (float)vmax) v2 = vmax;
					else if ((float)v2 < (float)vmin) v2 = vmin;
					break;
				case TargetType.DOUBLE:
					v2 = (double)((int)((double)v2 * 100 + 0.5)) / 100;
					if ((double)v2 > (double)vmax) v2 = vmax;
					else if ((double)v2 < (double)vmin) v2 = vmin;
					break;
			}
			return v2;
		}
		private bool ChkEdit()
		{
			bool ret = false;
			TextBox tb = (TextBox)this.Controls[this.Controls.Count - 1];
			switch (m_TargetType)
			{
				case TargetType.INT:
					int iv = 0;
					if (int.TryParse(tb.Text, out iv) == true)
					{
						SetValue((object)iv);
						ret = true;
					}
					break;
				case TargetType.FLOAT:
					float fv = 0;
					if (float.TryParse(tb.Text, out fv) == true)
					{
						SetValue((object)fv);
						ret = true;
					}
					break;
				case TargetType.DOUBLE:
					double dv = 0;
					if (double.TryParse(tb.Text, out dv) == true)
					{
						SetValue((object)dv);
						ret = true;
					}
					break;
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
				if(ChkEdit())
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
