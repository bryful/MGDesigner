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

	public class CornerLockChangedEventArgs : EventArgs
	{
		public bool Value = false;
		public CornerLockChangedEventArgs(bool ps)
		{
			Value = ps;
		}
	}
	public class SizeRootChangedEventArgs : EventArgs
	{
		public SizeRootType Value = SizeRootType.Center;
		public SizeRootChangedEventArgs(SizeRootType ps)
		{
			Value = ps;
		}
	}
	/*
	public enum SizeRootGridMode
	{
		CornerLock,
		SizeRoot
	}
	*/
	public partial class SizeRootGrid : Control
	{
		public delegate void CornerLockChangedHandler(object sender, CornerLockChangedEventArgs e);
		public event CornerLockChangedHandler? CornerLockChanged;
		protected virtual void OnCornerLockChanged(CornerLockChangedEventArgs e)
		{
			if (CornerLockChanged != null)
			{
				CornerLockChanged(this, e);
			}
		}
		public delegate void SizeRootChangedHandler(object sender, SizeRootChangedEventArgs e);
		public event SizeRootChangedHandler? SizeRootChanged;
		protected virtual void OnSizeRootChanged(SizeRootChangedEventArgs e)
		{
			if (SizeRootChanged != null)
			{
				SizeRootChanged(this, e);
			}
		}
		private int DotSz = 8;
		private int DotIt = 2;
		private int DotL = 2;
		private int DotT = 2;
		private int SwitchW = 70;
		private int SwitchL = 7;
		private int SwitchH = 7;
		private int SwitchT = 2;


		[Category("_MG")]
		public bool IsSmall
		{
			get { return DotSz==5; }
			set
			{
				if (value==false)
				{
					DotSz = 8;
					DotIt = 2;
					SwitchW = 70;
				}
				else
				{
					DotSz = 5;
					DotIt = 1;
					SwitchW = 70;
				}
				DotL = 2;
				DotT = 2;
				ChkSize();
			}
		}
		public void ChkSize()
		{
			int w = 0;
			int h = 0;
			SwitchH = DotSz * 3 + DotIt * 2;
			SwitchT = DotT;
			if (m_IsShowSwitch)
			{
				SwitchL = DotL + DotSz * 3 + DotIt * 2 + 2;
				w = SwitchL + SwitchW + DotL;
				h = SwitchH + DotT * 2;
			}
			else
			{
				SwitchL = DotL + DotSz * 3 + DotIt * 2;
				w = SwitchL;
				h = SwitchH + DotT * 2;
			}

			this.MinimumSize = new Size(0, 0);
			this.MaximumSize = new Size(0, 0);
			this.Size = new Size(w, h);
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
		}
		private bool m_CornerLock=false;
		[Category("_MG")]
		public bool CornerLock
		{
			get { return m_CornerLock; }
			set
			{
				m_CornerLock = value;
				this.Invalidate();
			}
		}

		private bool m_MousePush = false;

		private bool m_IsShowSwitch = true;
		[Category("_MG")]
		public bool IsShowSwitch
		{
			get { return m_IsShowSwitch; }
			set
			{
				m_IsShowSwitch=value;
				ChkSize();
			}
		}

		private SizeRootType m_SizeRoot = SizeRootType.TopLeft;
		[Category("_MG")]
		public SizeRootType SizeRoot
		{
			get { return m_SizeRoot; }
			set { 
				m_SizeRoot = value; 
				this.Invalidate();
			}
		}
		private Color m_BaseColor = Color.DimGray;
		[Category("_MG")]
		public Color BaseColor
		{
			get { return m_BaseColor; }
			set { m_BaseColor = value;this.Invalidate(); }
		}
		private Color m_PushColor = Color.LightGray;
		[Category("_MG")]
		public Color PushColor
		{
			get { return m_PushColor; }
			set { m_PushColor = value; this.Invalidate(); }
		}
		private Color m_PushColor2 = Color.White;
		[Category("_MG")]
		public Color PushColor2
		{
			get { return m_PushColor2; }
			set { m_PushColor2 = value; this.Invalidate(); }
		}
		public SizeRootGrid()
		{
			
			InitializeComponent();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor |
ControlStyles.UserMouse |
ControlStyles.Selectable,
true);
			this.BackColor = Color.Black;
			this.ForeColor = Color.LightGray;
			IsSmall = false;
			ChkSize();
		}
		protected override void InitLayout()
		{
			base.InitLayout();
			IsSmall = false;
			ChkSize();

		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor);
			Graphics g = pe.Graphics;
			try
			{
				for (int y=0; y<3;y++)
				{
					int yy = y * (DotSz + DotIt) + DotT;
					for (int x = 0; x < 3; x++)
					{
						int xx = x * (DotSz + DotIt) + DotL;
						Rectangle r = new Rectangle(xx, yy, DotSz, DotSz);
						if (( (SizeRootType)(y*3+x+1) == m_SizeRoot ))
						{
							if(m_MousePush == true)
							{
								sb.Color = m_PushColor2;
							}
							else
							{
								sb.Color = m_PushColor;
							}
						}
						else
						{
							sb.Color = m_BaseColor;
						}
						g.FillRectangle(sb, r);
					}
				}
				Rectangle r2 = new Rectangle(SwitchL, SwitchT, SwitchW, SwitchH);
				p.Color = this.ForeColor;
				p.Width = 1;
				sb.Color = this.ForeColor;
				g.DrawRectangle(p, r2);
				r2 = new Rectangle(r2.Left + 4, r2.Top + 4, r2.Width - 8, r2.Height - 8);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				if (m_CornerLock)
				{
					g.FillRectangle(sb, r2);
					sb.Color = this.BackColor;
					g.DrawString("Locked", this.Font, sb, r2, sf);
				}
				else
				{
					g.DrawRectangle(p, r2);
					sb.Color = this.ForeColor;
					g.DrawString("UnLocked", this.Font, sb, r2, sf);
				}
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}

		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if(e.Button== MouseButtons.Left)
			{
				if(e.X>=SwitchL)
				{
					m_CornerLock = !m_CornerLock;
					m_MousePush = m_CornerLock;
					OnCornerLockChanged(new CornerLockChangedEventArgs(m_CornerLock));
				}
				else
				{
					int p = ((e.X - DotL) / (DotSz + DotIt)) + 3 * ((e.Y - DotT) / (DotSz + DotIt)) + 1;
					if (p < 1) p = 1; else if (p > (int)SizeRootType.BottomRight) p = (int)SizeRootType.BottomRight;
					m_SizeRoot = (SizeRootType)p;
					OnSizeRootChanged(new SizeRootChangedEventArgs(m_SizeRoot));

					m_MousePush = true;
				}

				this.Invalidate();
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if(m_MousePush==true)
			{
				m_MousePush=false;
				this.Invalidate();
			}
			base.OnMouseUp(e);
		}
	}
}
