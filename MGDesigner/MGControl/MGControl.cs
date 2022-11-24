using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using BRY;

namespace MGDesigner
{
	public enum ControlPos
	{
		None=0,
		Top,
		TopRight,
		Right,
		BottomRight,
		Bottom,
		BottomLeft,
		Left,
		LeftTop,
		Center
	}

	public partial class MGControl : Control
	{
		private bool GetDesignMode(Control control)
		{
			if (control == null) return false;

			bool mode = control.Site == null ? false : control.Site.DesignMode;

			return mode | GetDesignMode(control.Parent);
		}

		// 本来のDesignModeを上書き
		public new bool DesignMode
		{
			get
			{
				return GetDesignMode(this);
			}
		}
		private Color m_Guide = Color.FromArgb(65, 255, 0, 0);
		[Category("_MG")]
		public Color Guide
		{
			get { return m_Guide; }
			set { m_Guide = value; this.Invalidate(); }	
		}
		public bool ClearFlag = true;
		private Bitmap m_Offscr=new Bitmap(10,10,PixelFormat.Format32bppArgb);
		public Bitmap OffScr { get { return m_Offscr; } }

		#region Global
		private bool m_IsFull = false;
		[Category("_MG")]
		public bool IsFull
		{
			get
			{
				return m_IsFull;
			}
			set
			{
				m_IsFull = value;
				ChkOffScr();
			}
		}
		private ControlPos m_ControlPos = ControlPos.None;
		[Category("_MG")]
		public ControlPos ControlPos
		{
			get
			{
				return m_ControlPos;
			}
			set
			{
				SetControlPos(value);
			}
		}

		private void SetControlPos(ControlPos v)
		{
			m_ControlPos = v;
			if (v == ControlPos.None) return;
			MGMainForm mf = (MGMainForm)this.Parent;
			if(mf==null) return;
			int x=0;
			int y=0;
			switch (v)
			{
				case ControlPos.Top:
					x = mf.Width / 2 - this.Width / 2 ;
					y = 0 + m_PosMargin.Top;
					break;
				case ControlPos.TopRight:
					x = mf.Width  - this.Width - m_PosMargin.Right;
					y = 0 + m_PosMargin.Top;
					break;
				case ControlPos.Right:
					x = mf.Width - this.Width - m_PosMargin.Right;
					y = mf.Height/2 - this.Height/2;
					break;
				case ControlPos.BottomRight:
					x = mf.Width - this.Width - m_PosMargin.Right;
					y = mf.Height - this.Height - m_PosMargin.Bottom;
					break;
				case ControlPos.Bottom:
					x = mf.Width / 2 - this.Width / 2;
					y = mf.Height - this.Height - m_PosMargin.Bottom;
					break;
				case ControlPos.BottomLeft:
					x = 0 + m_PosMargin.Left;
					y = mf.Height - this.Height - m_PosMargin.Bottom;
					break;
				case ControlPos.Left:
					x = +m_PosMargin.Left;
					y = mf.Height / 2 - this.Height / 2;
					break;
				case ControlPos.LeftTop:
					x = m_PosMargin.Left;
					y = m_PosMargin.Top;
					break;
				case ControlPos.Center:
					x = mf.Width / 2 - this.Width / 2 + m_PosMargin.Left - m_PosMargin.Right;
					y = mf.Height / 2 - this.Height / 2 + m_PosMargin.Top - m_PosMargin.Bottom ;
					break;
				default:
					return;

			}
			this.Location = new Point(x, y);
		}
		public void SetControlPos()
		{
			SetControlPos(m_ControlPos);
		}
		private Padding m_PosMargin = new Padding(0,0,0,0);
		[Category("_MG")]
		public Padding PosMargin
		{
			get { return m_PosMargin; }
			set
			{
				m_PosMargin = value;
				SetControlPos();
			}

		}
		private Padding m_DrawMargin = new Padding(0,0,0,0);
		[Category("_MG")]
		public Padding DrawMargin
		{
			get { return m_DrawMargin; }
			set
			{
				m_DrawMargin = value;
				ChkOffScr();
			}

		}
		[Category("_MG")]
		public float CenterX
		{
			get
			{
				return (float)this.Left + (float)this.Width / 2;
			}
			set
			{
				float x = value - (float)this.Width / 2;
				this.Location = new Point((int)x, this.Top);
			}
		}
		[Category("_MG")]
		public float CenterY
		{
			get
			{
				return (float)this.Top + (float)this.Height / 2;
			}
			set
			{
				float y = value - (float)this.Height / 2;
				this.Location = new Point(this.Left, (int)y);
			}
		}
		[Category("_MG")]
		public int DrawIndex
		{
			get
			{
				int index = -1;
				if (this.Parent is MGMainForm)
				{
					MGMainForm m = (MGMainForm)this.Parent;
					index = m.FindMGControls(this.Name);
				}
				return index;
			}
			set
			{
				if(this.Parent is MGMainForm)
				{
					MGMainForm m = (MGMainForm)this.Parent;
					if((value<m.MGControlsCount())&&(value>=0))
					{
						int index = m.FindMGControls(this.Name);
						if(index!=value)
						{
							m.SetIndex(index, value);
							ChkOffScr();
							//m.setm_DrawIndex = value;
						}
					}
				}

			}
		}
		#endregion
		public Color GetMG_Colors(MG_COLORS c,double op)
		{
			if((this.Parent==null)||(this.Parent is not MGMainForm)) return this.ForeColor;
			MGMainForm m = (MGMainForm)this.Parent;

			return m.GetMG_Colors(c, op);
		}
		// ************************************************************
		public MGControl()
		{
			this.Size = new Size(100, 100);
			InitializeComponent();
			this.SetStyle(
	ControlStyles.DoubleBuffer |
	ControlStyles.UserPaint |
	ControlStyles.AllPaintingInWmPaint |
	ControlStyles.SupportsTransparentBackColor,
	true);
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.White;
			this.UpdateStyles();
			InitOffScr();
			this.Invalidate();
		}
		// ************************************************************
		public void ChkOffScr()
		{
			if((this.Width!=m_Offscr.Width)|| (this.Height != m_Offscr.Height))
			{
				InitOffScr();
			}
			if ((this.Parent != null) && (this.Parent is MGMainForm))
			{
				MGMainForm m = (MGMainForm)this.Parent;
				if (m_IsFull == false)
				{
					Graphics g = Graphics.FromImage(m_Offscr);
					if(m.Anti) g.SmoothingMode = SmoothingMode.AntiAlias;
					Draw(g, new Rectangle(0, 0, m_Offscr.Width, m_Offscr.Height),true);
				}
				m.Invalidate();
			}
		}
		// ************************************************************
		private void InitOffScr()
		{
			m_Offscr = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
			Graphics g = Graphics.FromImage(m_Offscr);
			Draw(g, new Rectangle(0, 0, m_Offscr.Width, m_Offscr.Height),true);
			
		}
		// ************************************************************
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			SetControlPos();
			ChkOffScr();
		}
		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
			SetControlPos();

		}
		// ************************************************************
		protected override void OnPaint(PaintEventArgs pe)
		{
			//pe.Graphics.Clear(Color.Transparent);
			if(DesignMode)
			{
				Pen pen = new Pen(m_Guide);
				MG.Frame(pe.Graphics, pen, this.ClientRectangle);
				pen.Dispose();
			}
		}
		// ************************************************************
		public Rectangle MarginRect(Rectangle rct)
		{
			return new Rectangle(
				rct.X + m_DrawMargin.Left,
				rct.Y + m_DrawMargin.Top,
				rct.Width - m_DrawMargin.Left -m_DrawMargin.Right,
				rct.Height - m_DrawMargin.Top - m_DrawMargin.Bottom
				); ;
		}
		// ************************************************************
		public virtual void Draw(Graphics g, Rectangle rct,bool IsClear= true)
		{
			if (IsClear) g.Clear(Color.Transparent);
			Pen pen = new Pen(this.ForeColor, 3);
			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{
				Rectangle rct2 = MarginRect(rct);
				//g.Clear(this.BackColor);
				g.FillRectangle(sb, rct2);
				MG.Frame(g, pen, rct2);

			}
			finally
			{
				sb.Dispose();
				pen.Dispose();
			}
		}

	}
}
