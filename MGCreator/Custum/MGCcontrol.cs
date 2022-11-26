using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public enum MGStyle
	{
		None = 0b0000_0000_0000_0000,
		Frame = 0b0000_0000_0000_0001,
		Grid = 0b0000_0000_0000_0010,
		Circle = 0b0000_0000_0000_0100,
		CircleScale = 0b0000_0000_0000_1000,
		Triangle = 0b0000_0000_0001_0000,
		Polygon = 0b0000_0000_0010_0000,
		Cross = 0b0000_0000_0100_0000,
		Zebra = 0b0000_0000_1000_0000,
		Label = 0b0000_0001_0000_0000,
		Parallelogram = 0b0000_0010_0000_0000,
		Scale = 0b0000_0100_0000_0000,
		Sheet = 0b0000_1000_0000_0000,
		Kagi = 0b0001_0000_0000_0000,
		KagiEdge = 0b0010_0000_0000_0000,
	};
	public enum ControlPos
	{
		None = 0,
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
	public partial class MGCcontrol : Control
	{
		public readonly MGStyle Style = MGStyle.None;
		public int Index = -1;
		#region Global
		private Bitmap m_Offscr = new Bitmap(10, 10, PixelFormat.Format32bppArgb);
		[Category("_MG")]
		public Bitmap OffScr { get { return m_Offscr; } }

		private Color m_GuideColor = Color.FromArgb(64, 255, 0, 0);
		private Color m_GuideColorHi = Color.FromArgb(255, 255, 0, 0);
		private Color m_GuideColorMD = Color.FromArgb(255, 255, 255, 0);
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
				this.Visible = value;
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
			MGForm mf = (MGForm)this.Parent;
			if (mf == null) return;
			int x = 0;
			int y = 0;
			switch (v)
			{
				case ControlPos.Top:
					x = mf.Width / 2 - this.Width / 2;
					y = 0 + m_PosMargin.Top;
					break;
				case ControlPos.TopRight:
					x = mf.Width - this.Width - m_PosMargin.Right;
					y = 0 + m_PosMargin.Top;
					break;
				case ControlPos.Right:
					x = mf.Width - this.Width - m_PosMargin.Right;
					y = mf.Height / 2 - this.Height / 2;
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
					y = mf.Height / 2 - this.Height / 2 + m_PosMargin.Top - m_PosMargin.Bottom;
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
		private Padding m_PosMargin = new Padding(0, 0, 0, 0);
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
		private Padding m_DrawMargin = new Padding(0, 0, 0, 0);
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
		public int ControlIndex
		{
			get
			{
				int index = -1;
				if (this.Parent is MGForm)
				{
					MGForm m = (MGForm)this.Parent;
					index = m.FindControl(this.Name);
				}
				return index;
			}
			set
			{
				if (this.Parent is MGForm)
				{
					MGForm m = (MGForm)this.Parent;
					if ((value < m.Controls.Count) && (value >= 0))
					{
						int index = m.FindControl(this.Name);
						if (index != value)
						{
							m.Controls.SetChildIndex(
								m.Controls[index],
								value
								);
							ChkOffScr();
						}
					}
				}

			}
		}
		#endregion
		public Color GetColors(MG_COLORS c, double op)
		{
			if ((this.Parent == null) || (this.Parent is not MGForm)) return this.ForeColor;
			MGForm m = (MGForm)this.Parent;

			return m.GetColors(c, op);
		}
		// ************************************************************************
		private ContextMenuStrip m_Menu = new ContextMenuStrip();
		public virtual void InitMenu()
		{
			ToolStripMenuItem ToFrontMenu = new ToolStripMenuItem();
			ToFrontMenu.Name = "ToFront";
			ToFrontMenu.Text = "ToFront";
			ToFrontMenu.Click += FrontMenu_Click;
			ToolStripMenuItem ToBackMenu = new ToolStripMenuItem();
			ToBackMenu.Name = "ToBack";
			ToBackMenu.Text = "ToBack";
			ToBackMenu.Click += ToBackMenu_Click;
			ToolStripMenuItem ToUpMenu = new ToolStripMenuItem();
			ToUpMenu.Name = "Up";
			ToUpMenu.Text = "Up";
			ToUpMenu.Click += ToUpMenu_Click;
			ToolStripMenuItem ToDownMenu = new ToolStripMenuItem();
			ToDownMenu.Name = "Down";
			ToDownMenu.Text = "Down";
			ToDownMenu.Click += ToDownMenu_Click;

			ToolStripMenuItem DisposeMenu = new ToolStripMenuItem();
			DisposeMenu.Name = "Dispose";
			DisposeMenu.Text = "Dispose";
			DisposeMenu.Click += DisposeMenu_Click;

			m_Menu.Items.Add(ToFrontMenu);
			m_Menu.Items.Add(ToBackMenu);
			m_Menu.Items.Add(new ToolStripSeparator());
			m_Menu.Items.Add(ToUpMenu);
			m_Menu.Items.Add(ToDownMenu);
			m_Menu.Items.Add(new ToolStripSeparator());
			m_Menu.Items.Add(DisposeMenu);
			this.ContextMenuStrip = m_Menu;
		}

		private void ToDownMenu_Click(object? sender, EventArgs e)
		{
			ToDown();
		}

		private void ToUpMenu_Click(object? sender, EventArgs e)
		{
			ToUp();
		}

		private void ToBackMenu_Click(object? sender, EventArgs e)
		{
			ToBack();
		}

		private void FrontMenu_Click(object? sender, EventArgs e)
		{
			ToFront();
		}

		private void DisposeMenu_Click(object? sender, EventArgs e)
		{
			DeleteMe();
		}

		// ************************************************************************
		public MGCcontrol()
		{
			this.Size = new Size(100, 100);
			InitializeComponent();
			InitMenu();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor|
ControlStyles.UserMouse|
ControlStyles.Selectable,
true);
			this.BackColor = Color.Transparent;
			this.UpdateStyles();
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.White;
			this.UpdateStyles();
			InitOffScr();
			this.Invalidate();
		}
		// ************************************************************************
		public void DeleteMe()
		{
			int idx = ControlIndex;
			if(idx<0)
			{
				this.Dispose();
				return;
			}
			MGForm m = (MGForm)this.Parent;
			m.DeleteControl(idx);
		}
		public void ToFront()
		{
			MGForm m = (MGForm)this.Parent;
			m.ControlToFront(this);
		}
		public void ToBack()
		{
			MGForm m = (MGForm)this.Parent;
			m.ControlToBack(this);
		}
		public void ToUp()
		{
			MGForm m = (MGForm)this.Parent;
			m.ControlToUp(this);
		}
		public void ToDown()
		{
			MGForm m = (MGForm)this.Parent;
			m.ControlToDown(this);
		}
		// ************************************************************************
		public void ChkOffScr()
		{
			if ((this.Width != m_Offscr.Width) || (this.Height != m_Offscr.Height))
			{
				InitOffScr();
			}
			if ((this.Parent != null) && (this.Parent is MGForm))
			{
				MGForm m = (MGForm)this.Parent;
				if (m_IsFull == false)
				{
					Graphics g = Graphics.FromImage(m_Offscr);
					if (m.Anti) g.SmoothingMode = SmoothingMode.AntiAlias;
					Draw(g, new Rectangle(0, 0, m_Offscr.Width, m_Offscr.Height), true);
				}
				m.Invalidate();
			}
		}
		// ************************************************************
		private void InitOffScr()
		{
			try
			{
				m_Offscr = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
				Graphics g = Graphics.FromImage(m_Offscr);
				Draw(g, new Rectangle(0, 0, m_Offscr.Width, m_Offscr.Height), true);
			}
			catch
			{

			}
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
		// ************************************************************
		public Rectangle MarginRect(Rectangle rct)
		{
			return new Rectangle(
				rct.X + m_DrawMargin.Left,
				rct.Y + m_DrawMargin.Top,
				rct.Width - m_DrawMargin.Left - m_DrawMargin.Right,
				rct.Height - m_DrawMargin.Top - m_DrawMargin.Bottom
				); ;
		}

		// **************************************************************************************
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Pen p = new Pen(m_GuideColor, 1);
			SolidBrush sb = new SolidBrush(this.ForeColor);
			Graphics g = pe.Graphics;
			try
			{
				//g.Clear(Color.Transparent);
				if(m_MDCType != MGC_MDType.None)
				{
					sb.Color = Color.FromArgb(128, 255, 0, 0);
					g.FillRectangle(sb, this.ClientRectangle);
					p.Color = m_GuideColorMD;
					MGC.DrawFrame(g, p, 1, this.ClientRectangle);
				}
				else if (m_MDMouseIn)
				{
					sb.Color = Color.FromArgb(64, 255, 0, 0);
					g.FillRectangle(sb, this.ClientRectangle);
					p.Color = m_GuideColorHi;
					MGC.DrawFrame(g, p, 1, this.ClientRectangle);
				}else if (this.Focused)
				{
					p.Color = m_GuideColorMD;
					MGC.DrawFrame(g, p, 1, this.ClientRectangle);

				}
			}
			finally
			{
				p.Dispose();
				sb.Dispose();
			}

		}
		// ************************************************************
		public virtual void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			if (IsClear) g.Clear(Color.Transparent);
			Pen pen = new Pen(this.ForeColor, 3);
			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{
				Rectangle rct2 = MarginRect(rct);
				//g.Clear(this.BackColor);
				g.FillRectangle(sb, rct2);
				MGC.DrawFrame(g, pen, 2,rct2);
				g.DrawLine(pen,rct2.Left,rct2.Bottom,rct2.Right,rct2.Top);
				g.DrawLine(pen, rct2.Left, rct2.Top, rct2.Right, rct2.Bottom);
			}
			finally
			{
				sb.Dispose();
				pen.Dispose();
			}
		}
		// **************************************************************************************
		#region MouseEvent
		public enum MGC_MDType
		{
			None,
			TopLeft,
			Top,
			TopRight,
			Left,
			Center,
			Right,
			BottomLeft,
			Bottom,
			BottomRight
		}
		private MGC_MDType ChkMGC_MDType(int x, int y)
		{
			int a= 0;
			int inter = 25;
			if (x > this.Width - inter)
			{
				a = 2 + 1;
			}
			else if (x < inter)
			{
				a = 0 + 1;
			}
			else
			{
				a = 1 + 1;
			}
			if (y > this.Height - inter)
			{
				a += 6;
			}
			else if (y < 10)
			{
				//a += 3;
			}
			else
			{
				a += 3;
			}
			if (a < 0) a = 0;
			else if (a > 9) a = 9;
			return (MGC_MDType)a;
		}
		private MGC_MDType m_MDCType = MGC_MDType.None;
		private Size m_MDSize = new Size();
		private Point m_MDPoint = new Point();
		//private Point m_MDLoc = new Point();
		private bool m_MDMouseIn = false;

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Button == MouseButtons.Left)&&(m_MDCType == MGC_MDType.None))
			{
				m_MDCType = ChkMGC_MDType(e.X, e.Y);
				
				m_MDPoint = new Point(e.X, e.Y);
				m_MDSize = new Size(this.Width, this.Height);
			}
			else
			{
				base.OnMouseDown(e);
			}
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if ((e.Button == MouseButtons.Left) && (m_MDCType!= MGC_MDType.None))
			{
				int ax = e.X - m_MDPoint.X;
				int ay = e.Y - m_MDPoint.Y;
				if(m_MDCType == MGC_MDType.BottomRight)
				{
					this.Size = new Size(m_MDSize.Width + ax, m_MDSize.Height + ay);
				}else if (m_MDCType == MGC_MDType.Center)
				{
					this.Location = new Point(this.Left + ax, this.Top + ay);
				}
			}
			else
			{
				base.OnMouseMove(e);
			}

		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (m_MDCType != MGC_MDType.None)
			{
				m_MDCType = MGC_MDType.None;
				this.Text = "Mup";
				this.Invalidate();
			}
			base.OnMouseUp(e);
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			m_MDMouseIn = true;
			base.OnMouseEnter(e);
			this.Invalidate();
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			m_MDMouseIn = false;
			base.OnMouseLeave(e);
			this.Invalidate();
		}
		#endregion
	}
}
