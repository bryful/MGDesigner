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
		None= 
			0b0000_0000_0000_0000_0000,
		Frame =
			0b0000_0000_0000_0000_0001,
		Grid =
			0b0000_0000_0000_0000_0010,
		Circle =
			0b0000_0000_0000_0000_0100,
		CircleScale =
			0b0000_0000_0000_0000_1000,
		Triangle =
			0b0000_0000_0000_0001_0000,
		Polygon =
			0b0000_0000_0000_0010_0000,
		Cross =
			0b0000_0000_0000_0100_0000,
		Zebra =
			0b0000_0000_0000_1000_0000,
		Label =
			0b0000_0000_0001_0000_0000,
		Parallelogram =
			0b0000_0000_0010_0000_0000,
		Scale =
			0b0000_0000_0100_0000_0000,
		Sheet =
			0b0000_0000_1000_0000_0000,
		Kagi =
			0b0000_0001_0000_0000_0000,
		Edge =
			0b0000_0010_0000_0000_0000,
		Side =
			0b0000_0100_0000_0000_0000,
		ALL =
			0b1111_1111_1111_1111_1111,

	};
	public enum Control2Pos
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

	public partial class MGControl2 : Control
	{
		public class NameChangedEventArgs : EventArgs
		{
			string Name = "";
			public NameChangedEventArgs(string s)
			{
				Name = s;
			}
		}
		public delegate void NameChangedHandler(object sender, NameChangedEventArgs e);
		public event NameChangedHandler? NameChanged;
		protected virtual void OnNameChanged(NameChangedEventArgs e)
		{
			if (NameChanged != null)
			{
				NameChanged(this, e);
			}
		}
		#region Global
		private Bitmap m_Offscr = new Bitmap(5, 5, PixelFormat.Format32bppArgb);
		public Bitmap OffScr { get { return m_Offscr; } }
		private Color m_GuideColor = Color.FromArgb(64, 255, 0, 0);
		private Color m_GuideColorHi = Color.FromArgb(255, 255, 0, 0);
		private Color m_GuideColorMD = Color.FromArgb(255, 255, 255, 0);

		public new string  Name
		{ 
			get{ return base.Name; }
			set
			{
				if(base.Name != value)
				{
					base.Name = value;
					OnNameChanged(new NameChangedEventArgs(value));
				}
			}
		}

		private void SetControl2Pos(Control2Pos v)
		{
			m_Control2Pos = v;
			if (v == Control2Pos.None) return;
			MGForm mf = (MGForm)this.Parent;
			if (mf == null) return;
			int x = 0;
			int y = 0;
			switch (v)
			{
				case Control2Pos.Top:
					x = mf.Width / 2 - this.Width / 2;
					y = 0 + m_PosMargin.Top;
					break;
				case Control2Pos.TopRight:
					x = mf.Width - this.Width - m_PosMargin.Right;
					y = 0 + m_PosMargin.Top;
					break;
				case Control2Pos.Right:
					x = mf.Width - this.Width - m_PosMargin.Right;
					y = mf.Height / 2 - this.Height / 2;
					break;
				case Control2Pos.BottomRight:
					x = mf.Width - this.Width - m_PosMargin.Right;
					y = mf.Height - this.Height - m_PosMargin.Bottom;
					break;
				case Control2Pos.Bottom:
					x = mf.Width / 2 - this.Width / 2;
					y = mf.Height - this.Height - m_PosMargin.Bottom;
					break;
				case Control2Pos.BottomLeft:
					x = 0 + m_PosMargin.Left;
					y = mf.Height - this.Height - m_PosMargin.Bottom;
					break;
				case Control2Pos.Left:
					x = +m_PosMargin.Left;
					y = mf.Height / 2 - this.Height / 2;
					break;
				case Control2Pos.LeftTop:
					x = m_PosMargin.Left;
					y = m_PosMargin.Top;
					break;
				case Control2Pos.Center:
					x = mf.Width / 2 - this.Width / 2 + m_PosMargin.Left - m_PosMargin.Right;
					y = mf.Height / 2 - this.Height / 2 + m_PosMargin.Top - m_PosMargin.Bottom;
					break;
				default:
					return;

			}
			this.Location = new Point(x, y);
		}
		public void SetControl2Pos()
		{
			SetControl2Pos(m_Control2Pos);
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
					index = m.FindLayer(this.Name);
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
						int index = m.FindLayer(this.Name);
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
			if ((this.Parent != null) && (this.Parent is  MGForm))
			{
				MGForm m = (MGForm)this.Parent;
				return m.GetMGColors(c, op);
			}
			else
			{
				return this.ForeColor;
			}
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

		// ************************************************************************
		public MGControl2()
		{
			this.Size = new Size(100, 100);
			InitializeComponent();
			InitMenu();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
//Control2Styles.UserMouse|
//Control2Styles.Selectable,
true);


			this.BackColor = Color.Transparent;
			this.UpdateStyles();
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.White;
			this.UpdateStyles();
			InitOffScr();
			this.Invalidate();
			base.Visible = true;
		}
		// ************************************************************************
		public new bool Visible
		{
			get { return base.Visible; }
			set { base.Visible = true; }
		}


		// ************************************************************************
		public void ChkOffScr()
		{
			if(base.Visible==false) return;
			int w = this.Width;
			int h = this.Height;
			if (w < 10) w = 10;
			if (h < 10) h = 10;
			if ((w != m_Offscr.Width) || (h != m_Offscr.Height))
			{
				
				m_Offscr = new Bitmap(w, h, PixelFormat.Format32bppArgb);
			}
			if (this.Parent != null)
			{
				if(this.Parent is MGForm)
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
			this.Invalidate();
		}
		// ************************************************************
		private void InitOffScr()
		{
			try
			{
				int w = this.Width;
				int h = this.Height;
				if (w < 10) w = 10;
				if (h < 10) h = 10;
				m_Offscr = new Bitmap(w, h, PixelFormat.Format32bppArgb);
				Graphics g = Graphics.FromImage(m_Offscr);
				if (this.Parent != null)
				{
					MGForm m = (MGForm)this.Parent;
					if (m.Anti) g.SmoothingMode = SmoothingMode.AntiAlias;
				}
				Draw(g, new Rectangle(0, 0, m_Offscr.Width, m_Offscr.Height), true);
			}
			catch
			{
				m_Offscr = new Bitmap(10, 10, PixelFormat.Format32bppArgb);
			}
		}
		// ************************************************************
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			SetControl2Pos();
			ChkOffScr();
			this.Invalidate();
		}
		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
			SetControl2Pos();

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
			return;
			if (base.Visible == false) return;
			//Pen p = new Pen(m_GuideColor, 1);
			SolidBrush sb = new SolidBrush(this.ForeColor);
			Graphics g = pe.Graphics;
			/*
			if (m_MGStyle == MGStyle.Zebra)
			{
				GraphicsPath path = new GraphicsPath();
				path.AddRectangle(this.ClientRectangle);
				Region region = new Region(path);
				g.SetClip(region, CombineMode.Replace);
			}
			*/
			try
			{
				bool isTarget = false;
				if (this.Parent is MGForm)
				{
					isTarget = ((this.Index == ((MGForm)this.Parent).TargetIndex)&&(m_IsShowGuide));
				}
				/*
				if(m_MDCType != MGC_MDType.None)
				{
					p.Color = m_GuideColorMD;
					MGC.DrawFrame(g, p, 1, this.ClientRectangle);
				}
				else*/ if (m_MDMouseIn)
				{
					sb.Color = Color.FromArgb(64, 255, 0, 0);
					g.FillRectangle(sb, this.ClientRectangle);
				
				}else if (isTarget)
				{
					sb.Color = Color.FromArgb(64, 0, 0, 255);
					g.FillRectangle(sb, this.ClientRectangle);
					/*
					p.Color = Color.FromArgb(128,255,0,255);
					p.DashStyle = DashStyle.Dash;
					p.Width = 2;
					g.DrawRectangle(p,new Rectangle(3,3,this.Width-7,this.Height-7));
					p.DashStyle = DashStyle.Solid;
					*/

				}
			}
			finally
			{
				//p.Dispose();
				sb.Dispose();
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
			if(this.Parent is MGForm)
			{
				MGForm form = (MGForm)this.Parent;
				form.TargetIndex = this.Index;
			}
			base.OnMouseDown(e);
			if ((e.Button == MouseButtons.Left)&&(m_MDCType == MGC_MDType.None))
			{
				m_MDCType = ChkMGC_MDType(e.X, e.Y);
				
				m_MDPoint = new Point(e.X, e.Y);
				m_MDSize = new Size(this.Width, this.Height);
			}
			//MessageBox.Show("MGC");
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
					this.Parent.Refresh();
				}
			}
			else
			{
			}
			base.OnMouseMove(e);

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
			this.Invalidate();
			base.OnMouseEnter(e);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			m_MDMouseIn = false;
			this.Invalidate();
			base.OnMouseLeave(e);
		}

		#endregion
	}
}
