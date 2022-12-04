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
	public enum CrossDir
	{
		None,
		Top,
		Right,
		Bottom,
		Left
	}
	public class CrossChangedEventArgs : EventArgs
	{
		public CrossDir Dir = CrossDir.None;
		public int Value = 0;
		public CrossChangedEventArgs(CrossDir d, int v)
		{
			Value = v;
			Dir = d;
		}
	}
	public partial class CrossKey : Control
	{
		
		private int m_BtnWidth = 20;
		private int m_BtnHeight = 20;
		private Color m_PushBackColor = Color.LightGray;
		private Color m_PushMojiColor = Color.White;
		private Color m_MojiColor = Color.Black;
		private Color m_ForcusedColor = Color.Black;
		private Color m_UnForcusedColor = Color.DarkGray;
		// *****************************************************************
		public delegate void CrossChangedHandler(object sender, CrossChangedEventArgs e);
		public event CrossChangedHandler? CrossChanged;
		protected virtual void OnCrossChanged(CrossChangedEventArgs e)
		{
			if (CrossChanged != null)
			{
				CrossChanged(this, e);
			}
		}
		// *****************************************************************

		public CrossKey()
		{
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			this.Size = new Size(m_BtnWidth*4,m_BtnHeight);
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
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
			return new Rectangle(x+1,y+1,m_BtnWidth-3,m_BtnHeight-3);
		}
		private Point[] DrawArrow(Rectangle r, CrossDir d)
		{
			Point[] p = new Point[3];
			switch(d)
			{
				case CrossDir.Top:
					p[0] = new Point(r.Left + r.Width / 3, r.Top + r.Height * 2 / 3);
					p[1] = new Point(r.Left + r.Width / 2, r.Top + r.Height / 3);
					p[2] = new Point(r.Left + r.Width * 2  / 3, r.Top + r.Height * 2 / 3);
					break;
				case CrossDir.Bottom:
					p[0] = new Point(r.Left + r.Width / 3, r.Top + r.Height  / 3);
					p[1] = new Point(r.Left + r.Width / 2, r.Top + r.Height *2/ 3);
					p[2] = new Point(r.Left + r.Width * 2 / 3, r.Top + r.Height  / 3);
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
			//base.OnPaint(pe);
			Graphics g = pe.Graphics;
			Pen p = new Pen(this.ForeColor);
			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{
				if(this.Focused)
				{
					p.Color = m_ForcusedColor;
				}
				else
				{
					p.Color = m_UnForcusedColor;
				}
				Rectangle r0 = BtnRegion(m_BtnWidth * 2, 0);
				Rectangle r1 = BtnRegion(m_BtnWidth * 1, 0);
				Rectangle r2 = BtnRegion(m_BtnWidth * 3, 0);
				Rectangle r3 = BtnRegion(0,0);
				switch (m_mdpos)
				{
					case CrossDir.Top:
						sb.Color = m_PushBackColor;
						g.FillRectangle(sb, r0);
						break;
					case CrossDir.Bottom:
						sb.Color = m_PushBackColor;
						g.FillRectangle(sb, r2);
						break;
					case CrossDir.Right:
						sb.Color = m_PushBackColor;
						g.FillRectangle(sb, r1);
						break;
					case CrossDir.Left:
						sb.Color = m_PushBackColor;
						g.FillRectangle(sb, r3);
						break;

				}
				Point[] ll = DrawArrow(r0, CrossDir.Top);
				g.DrawLines(p, ll);
				ll = DrawArrow(r1, CrossDir.Right);
				g.DrawLines(p, ll);
				ll = DrawArrow(r2, CrossDir.Bottom);
				g.DrawLines(p, ll);
				ll = DrawArrow(r3, CrossDir.Left);
				g.DrawLines(p, ll);

				g.DrawRectangle(p, r0);
				g.DrawRectangle(p, r1);
				g.DrawRectangle(p, r2);
				g.DrawRectangle(p, r3);
			}
			finally
			{
				p.Dispose();
			}
		}
		private CrossDir GetPos(int x,int y)
		{
			CrossDir ret = CrossDir.None;
			int p = x / m_BtnWidth;
			switch (p)
			{
				case 0:
					ret = CrossDir.Left;
					break;
				case 1:
					ret = CrossDir.Right;
					/*
					if(y < m_BtnHeight)
					{
						ret= CrossDir.Top;
					}
					else
					{
						ret = CrossDir.Bottom
							;
					}*/
					break;
				case 2:
					ret = CrossDir.Top;
					break;
				case 3:
					ret = CrossDir.Bottom;
					break;
				default:
					break;
			}
			return ret;
		}
		private CrossDir m_mdpos = CrossDir.None;
		private int m_mdvalue = 1;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			CrossDir pos = GetPos(e.X,e.Y);
			if(pos != CrossDir.None)
			{
				m_mdpos = pos;
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
				this.Invalidate();
			}
			else
			{
				base.OnMouseDown(e);
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if(m_mdpos != CrossDir.None)
			{
				OnCrossChanged(new CrossChangedEventArgs(m_mdpos, m_mdvalue));
				m_mdpos = CrossDir.None;
				m_mdvalue = 1;
				this.Invalidate();
			}
			else
			{
				base.OnMouseUp(e);
			}
		}
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.Invalidate();
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.Invalidate();
		}
	}
}
