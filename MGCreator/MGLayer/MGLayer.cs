using System;
using System.Collections.Generic;
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

	public enum SizeRootType
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
	
	public class NameChangedEventArgs : EventArgs
	{
		public string Name = "";
		public int Index = -1;
		public NameChangedEventArgs(string s, int idx)
		{
			Name = s;
			Index = idx;
		}
	}
	
	public partial class MGLayer
    {
		#region Event
		// ************************************************************************

		public delegate void NameChangedHandler(object sender, NameChangedEventArgs e);
		public event NameChangedHandler? NameChanged;
		protected virtual void OnNameChanged(NameChangedEventArgs e)
		{
			if (NameChanged != null)
			{
				NameChanged(this, e);
			}
		}       
		// ************************************************************************
		public delegate void SizeChangedHandler(object sender, EventArgs e);
		public event SizeChangedHandler? SizeChanged;
		protected virtual void OnSizeChanged(EventArgs e)
		{
			if (SizeChanged != null)
			{
				SizeChanged(this, e);
			}
		}
		// ************************************************************************
		public delegate void LocationChangedHandler(object sender, EventArgs e);
		public event LocationChangedHandler? LocationChanged;
		protected virtual void OnLocationChanged(EventArgs e)
		{
			if (LocationChanged != null)
			{
				LocationChanged(this, e);
			}
		}   
 
		#endregion
		// ************************************************************************
		#region Property
		protected int m_Index = -1;
		public int Index { get { return m_Index; } }
		public void SetIndex(int idx) { m_Index = idx; }
        protected MGForm? m_MGForm = null;
		[Category("_MGLayer")]
		public MGForm? MGForm
        {
            get { return m_MGForm; }
        }
        public MGStyle MGStyle = MGStyle.Frame;
		protected string m_Name = "Layer";
		[Category("_MGLayer")]
		public string Name
		{
			get { return m_Name; }
			set
			{
				if (m_Name != value)
				{
					m_Name = value;
					OnNameChanged(new NameChangedEventArgs(m_Name,m_Index));
				}
			}
		}

		protected Bitmap m_Offscr = new Bitmap(100, 100, PixelFormat.Format32bppArgb);
        public Bitmap OffScr() { return m_Offscr; }

		protected bool m_CornerLock = false;
		[Category("_MGLayer")]
		public bool CornerLock
		{
            get 
            {
				return m_CornerLock;
            }
            set
            {
				SetCornerLock(value);

			}

        }
		public void SetCorner(bool IsEvent = true)
		{
			SetCorner(m_SizeRoot,IsEvent);
		}
		public void SetCorner(SizeRootType sr,bool IsEvent = true)
		{
			if (m_MGForm == null) return;
			Point p;
			int x; int y;
			switch (sr)
			{
				case SizeRootType.TopLeft:
					p = new Point(0, 0);
					break;
				case SizeRootType.Top:
					x = (m_MGForm.Width / 2) - (m_Size.Width / 2);
					p = new Point(x, 0);
					break;
				case SizeRootType.TopRight:
					x = (m_MGForm.Width) - (m_Size.Width);
					p = new Point(x, 0);
					break;
				case SizeRootType.Right:
					x = (m_MGForm.Width) - (m_Size.Width);
					y = (m_MGForm.Height / 2) - (m_Size.Height / 2);
					p = new Point(x, y);
					break;
				case SizeRootType.BottomRight:
					x = (m_MGForm.Width) - (m_Size.Width);
					y = (m_MGForm.Height) - (m_Size.Height);
					p = new Point(x, y);
					break;
				case SizeRootType.Bottom:
					x = (m_MGForm.Width / 2) - (m_Size.Width / 2);
					y = (m_MGForm.Height) - (m_Size.Height);
					p = new Point(x, y);
					break;
				case SizeRootType.BottomLeft:
					x = 0;
					y = (m_MGForm.Height) - (m_Size.Height);
					p = new Point(x, y);
					break;
				case SizeRootType.Left:
					x = 0;
					y = (m_MGForm.Height / 2) - (m_Size.Height / 2);
					p = new Point(x, y);
					break;
				case SizeRootType.Center:
				default:
					x = (m_MGForm.Width / 2) - (m_Size.Width / 2);
					y = (m_MGForm.Height / 2) - (m_Size.Height / 2);
					p = new Point(x, y);
					break;
			}
			if (m_location != p)
			{
				m_location = p;
				if (IsEvent)
				{
					OnLocationChanged(EventArgs.Empty);
					if (m_MGForm != null) m_MGForm.Invalidate();
				}
			}
		}
		public void SetCornerLock(bool cl, bool IsEvent = true)
		{
			if (m_MGForm == null)
			{
				m_CornerLock = false;
				return;
			}
			m_CornerLock = cl;
			if (m_CornerLock == true)
			{
				SetCorner(true);
			}
		}
		protected Point m_location = new Point(0, 0);
        [Category("_MGLayer")]
		public Point Location
        {
            get { return m_location; }
            set
            {
				if(m_CornerLock==false)
				{
					if (m_location != value)
					{
						m_location = value;
						OnLocationChanged(EventArgs.Empty);
						if (m_MGForm != null) m_MGForm.Invalidate();
					}
				}
				else
				{
					SetCorner(true);
				}
			}
        }
        [Category("_MGLayer")]
        public int Left
        {
            get { return m_location.X; }
        }
        [Category("_MGLayer")]
        public int Top
        {
            get { return m_location.Y; }
        }


		protected SizeRootType m_SizeRoot = SizeRootType.TopLeft;
		[Category("_MGLayer")]
		public SizeRootType SizeRoot
		{
            get { return m_SizeRoot; }
            set 
			{ 
				m_SizeRoot = value;
				if(m_CornerLock)
				{
					SetCornerLock(true, true);
				}
			}
        }
		protected Size m_Size = new Size(100, 100);
        [Category("_MGLayer")]
        public Size Size
        {
            get { return m_Size; }
            set
            {
                if (m_Size != value)
                {
                    SetSize(value);
                    //if (m_MGForm != null) m_MGForm.DrawAll();
                }
            }
        }
        [Category("_MGLayer")]
        public int Width
        {
            get { return m_Size.Width; }
        }
        [Category("_MGLayer")]
        public int Height
        {
            get { return m_Size.Height; }
        }
		[Category("_MGLayer")]
        public Rectangle Bounds
        {
            get { return new Rectangle(m_location, m_Size); }
        }
		protected Padding m_DrawMargin = new Padding(0, 0, 0, 0);
		/// <summary>
		/// 描画マージン
		/// </summary>
		[Category("_MGLayer")]
		public Padding DrawMargin
		{
			get { return m_DrawMargin; }
			set
			{
				m_DrawMargin = value;
				ChkOffScr();
			}

		}
		protected Color m_ForeColor = Color.White;
		protected Color m_BackColor = Color.Black;
		#endregion
		// ************************************************************************
		#region Draw
		public Color GetColors(MG_COLORS c, double op)
		{
			if (m_MGForm!=null)
			{
				return m_MGForm.GetColors(c, op);
			}
			else
			{
				return Color.Red;
			}
		}
	
		// ***************************************************************************
		protected void SetSize(int x,int y)
        {
			SetSize(new Size(x,y));
		}
		protected void SetSize(Size sz)
        {
            if (m_Size == sz) return;
            if ((sz.Width < 10) || (sz.Height < 10)) return;
			if(m_CornerLock==true)
			{
				SetCorner(false);
			}
            int cx;
            int cy;
			switch (m_SizeRoot)
            { 
                case SizeRootType.TopLeft:
					m_Size = sz;
					break;
				case SizeRootType.Top:
                    cx = m_location.X + m_Size.Width / 2;
                    cy = m_location.Y;
                    m_Size = sz;
                    m_location.X = cx - sz.Width / 2;
					m_location.Y= cy;
					break;
				case SizeRootType.TopRight:
					cx = m_location.X + m_Size.Width;
					cy = m_location.Y;
					m_Size = sz;
					m_location.X = cx - sz.Width;
					m_location.Y = cy;
					break;
				case SizeRootType.Left:
					cx = m_location.X;
					cy = m_location.Y + m_Size.Height / 2;
					m_Size = sz;
					m_location.X = cx;
					m_location.Y = cy - m_Size.Height / 2;
					break;
				case SizeRootType.Center:
                    cx = m_location.X + m_Size.Width / 2;
                    cy = m_location.Y + m_Size.Height / 2;
					m_Size = sz;
					m_location.X = cx - m_Size.Width / 2;
					m_location.Y = cy - m_Size.Height / 2;
					break;
				case SizeRootType.Right:
					cx = m_location.X + m_Size.Width;
					cy = m_location.Y + m_Size.Height / 2;
					m_Size = sz;
					m_location.X = cx - m_Size.Width;
					m_location.Y = cy - m_Size.Height / 2;
					break;
				case SizeRootType.BottomLeft:
					cx = m_location.X;
					cy = m_location.Y + m_Size.Height;
					m_Size = sz;
					m_location.X = cx;
					m_location.Y = cy - m_Size.Height;
					break;
				case SizeRootType.Bottom:
					cx = m_location.X + m_Size.Width/2;
					cy = m_location.Y + m_Size.Height;
					m_Size = sz;
					m_location.X = cx - m_Size.Width / 2;
					m_location.Y = cy - m_Size.Height;
					break;
				case SizeRootType.BottomRight:
					cx = m_location.X + m_Size.Width;
					cy = m_location.Y + m_Size.Height;
					m_Size = sz;
					m_location.X = cx - m_Size.Width;
					m_location.Y = cy - m_Size.Height;
					break;
			}
            ChkOffScr();
            OnLocationChanged(new EventArgs());
            OnSizeChanged(new EventArgs());
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
		// ***************************************************************************
		public void DrawFrame(Graphics g, Pen p, int weight, Rectangle r)
		{
			float pw = p.Width;
			p.Width = 1;
			Rectangle r2 = new Rectangle(r.X, r.Y, r.Width - 1, r.Height - 1);
			for (int i = 0; i < weight; i++)
			{
				g.DrawRectangle(p, r2);
				r2 = new Rectangle(r2.X + 1, r2.Y + 1, r2.Width - 2, r2.Height - 2);
			}
		}       
		// ***************************************************************************
		public virtual void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
            SolidBrush sb = new SolidBrush(m_ForeColor);
            Pen p = new Pen(m_ForeColor);
            p.Width = 1;
            try
            {
                if (IsClear) g.Clear(Color.Transparent);
				Rectangle r2 = MarginRect(rct);
				DrawFrame(g, p, 2, r2);
            }
            finally
            {
                sb.Dispose();
                p.Dispose();
            }
		}
		private void InitOffScr()
		{
			try
			{
				int w = m_Size.Width;
				int h = m_Size.Height;
				if (w < 10) w = 10;
				if (h < 10) h = 10;
				m_Offscr = new Bitmap(w, h, PixelFormat.Format32bppArgb);
			}
			catch
			{
				m_Offscr = new Bitmap(10, 10, PixelFormat.Format32bppArgb);
			}
		}
        // ************************************************************************
        private bool isCheckingOffScr = false;
        public void ChkOffScr()
		{
            if (isCheckingOffScr == true) return;
			isCheckingOffScr = true;
			int w = m_Size.Width;
			int h = m_Size.Height;
			if (w < 10) w = 10;
			if (h < 10) h = 10;
			if ((w != m_Offscr.Width) || (h != m_Offscr.Height))
			{

				m_Offscr = new Bitmap(w, h, PixelFormat.Format32bppArgb);
			}
			if (m_MGForm != null)
			{
				if (m_IsFull == false)
				{
					Graphics g = Graphics.FromImage(m_Offscr);
					if (m_MGForm.Anti) g.SmoothingMode = SmoothingMode.AntiAlias;
					Draw(g, new Rectangle(0, 0, m_Offscr.Width, m_Offscr.Height), true);
				}
				m_MGForm.Invalidate();
			}
            isCheckingOffScr = false; ;
		}
		#endregion
		// ************************************************************************
		public MGLayer(MGForm m)
        {

			m_MGForm = m;
			InitOffScr();
			ChkOffScr();

		}
		// ************************************************************************
		~MGLayer()
		{

		}
		public void Dispose()
		{
			m_Offscr.Dispose();
		}
		// ************************************************************************
		protected Size m_MDSize = new Size();
        protected Point m_MDPoint = new Point();
		protected Point m_MDLocation = new Point();
		protected SizeRootType m_MouseDown = SizeRootType.None;
        protected bool m_IsMouseEnter = false;
        public bool IsMouseEnter { get { return m_IsMouseEnter; } }
        // ************************************************************************
        private SizeRootType GetMDPos(int x, int y)
        {
            int w = 10;
            SizeRootType ret = SizeRootType.None;
            if (x >= 0 && y >= 0 && x < m_Size.Width && y < m_Size.Height)
            {
                if (y < w)
                {
                    if (x < w) ret = SizeRootType.TopLeft;
                    else if (x > this.Width - w) ret = SizeRootType.TopRight;
                    else ret = SizeRootType.Top;

                }
                else if (y > this.Height - w)
                {
                    if (x < w) ret = SizeRootType.BottomLeft;
                    else if (x > this.Width - w) ret = SizeRootType.BottomRight;
                    else ret = SizeRootType.Bottom;

                }
                else
                {
                    if (x < w) ret = SizeRootType.Left;
                    else if (x > this.Width - w) ret = SizeRootType.Right;
                    else ret = SizeRootType.Center;
                }
            }
            else
            {
                ret = SizeRootType.None;
            }

            return ret;
        }
        // ************************************************************************
 
		public bool ChkMouseDown(MouseEventArgs e)
        {
            bool ret = false;
            int x = e.X - m_location.X;
            int y = e.Y - m_location.Y;
            SizeRootType m = GetMDPos(x, y);

            if (m != SizeRootType.None)
            {
				if((m_SizeRoot !=m)|| (m_SizeRoot == SizeRootType.Center))
				{
					m_MouseDown = m;
					m_MDLocation = this.Location;
					m_MDPoint = new Point(x, y);
					m_MDSize = this.Size;

				}
				//OnMouseDown(new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta));
				ret = true;
            }
            else
            {
                m_MouseDown = SizeRootType.None;
            }
            return ret;
        }
		public bool ChkMouseMove(MouseEventArgs e)
        {
			bool ret = false;
			int x = e.X - m_location.X;
            int y = e.Y - m_location.Y;
            bool isIn = x >= 0 && y >= 0 && x < m_Size.Width && y < m_Size.Height;

            if (m_MouseDown != SizeRootType.None)
            {
                int ax = x - m_MDPoint.X;
				int ay = y - m_MDPoint.Y;
                switch(m_MouseDown)
                {
                    case SizeRootType.Center:
						Location = new Point(m_MDLocation.X + ax, m_MDLocation.Y + ay);
                        m_MDLocation = Location;
						if (m_MGForm != null)
						{
							OnLocationChanged(EventArgs.Empty);
							m_MGForm.Invalidate();
						}
						break;
					case SizeRootType.None:
                        break;
					case SizeRootType.BottomRight:
						if ((m_SizeRoot != SizeRootType.Right) &&
							(m_SizeRoot != SizeRootType.BottomRight) &&
							(m_SizeRoot != SizeRootType.Bottom)
							)
						{
							int bx = m_MDSize.Width + ax;
							int by = m_MDSize.Height + ay;
							SetSize(bx, by);
						}
						break;
					case SizeRootType.Bottom:
						if ((m_SizeRoot != SizeRootType.Bottom) &&
							(m_SizeRoot != SizeRootType.BottomLeft) &&
							(m_SizeRoot != SizeRootType.BottomRight)
							)
						{
							int bx = m_MDSize.Width;
							int by = m_MDSize.Height + ay;
							SetSize(bx, by);
						}
						break;
					case SizeRootType.BottomLeft:
						if ((m_SizeRoot != SizeRootType.BottomLeft) &&
							(m_SizeRoot != SizeRootType.Left) &&
							(m_SizeRoot != SizeRootType.Bottom)
							)
						{
							int bx = m_MDSize.Width - ax;
							int by = m_MDSize.Height + ay;
							SetSize(bx, by);
						}
						break;
					case SizeRootType.TopLeft:
						if ((m_SizeRoot != SizeRootType.TopLeft) &&
							(m_SizeRoot != SizeRootType.Top) &&
							(m_SizeRoot != SizeRootType.Left)
							)
						{
							int bx = m_MDSize.Width - ax;
							int by = m_MDSize.Height - ay;
							SetSize(bx, by);
						}
						break;
					case SizeRootType.Left:
						if ((m_SizeRoot != SizeRootType.Left) &&
							(m_SizeRoot != SizeRootType.TopLeft) &&
							(m_SizeRoot != SizeRootType.TopRight)
							)
						{
							int bx = m_MDSize.Width - ax;
							int by = m_MDSize.Height;
							SetSize(bx, by);
						}
						break;
					case SizeRootType.Right:
						if ((m_SizeRoot != SizeRootType.Right) &&
							(m_SizeRoot != SizeRootType.TopRight) &&
							(m_SizeRoot != SizeRootType.BottomLeft)
							)
						{
							int bx = m_MDSize.Width + ax;
							int by = m_MDSize.Height;
							SetSize(bx, by);
						}
						break;
					case SizeRootType.Top:
						if ((m_SizeRoot != SizeRootType.Top) &&
							(m_SizeRoot != SizeRootType.TopLeft) &&
							(m_SizeRoot != SizeRootType.TopRight)
							)
						{
							int bx = m_MDSize.Width;
							int by = m_MDSize.Height - ay;
							SetSize(bx, by);
						}
						break;
					case SizeRootType.TopRight:
						if ((m_SizeRoot != SizeRootType.Top) &&
							(m_SizeRoot != SizeRootType.TopLeft) &&
							(m_SizeRoot != SizeRootType.BottomLeft)
							)
						{
							int bx = m_MDSize.Width+ax;
							int by = m_MDSize.Height - ay;
							SetSize(bx, by);
						}
						break;
					default:
						break;
				}
				//OnMouseMove(new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta));
                ret = true;
            }
			else if (isIn == true && m_IsMouseEnter == false)
			{
				//OnMouseEnter(EventArgs.Empty);
                m_IsMouseEnter = true;
				ret = true;
			}
            else if ((m_IsMouseEnter) && (isIn == false))
			{
                
				m_IsMouseEnter = false;
                ret = true;
			}
			return ret;
        }
		public bool ChkMouseUp(MouseEventArgs e)
        {
			bool ret = false;
            if (m_MouseDown != SizeRootType.None)
            {
				int x = e.X - m_location.X;
				int y = e.Y - m_location.Y;
				m_MouseDown = SizeRootType.None;
                m_MDPoint = new Point(0, 0);
                m_MDSize = new Size(0, 0);
                ret = true;
            }
			return ret;
		}

		// ***************************************************************************
		public virtual List<Control> ParamsMain()
		{
			List<Control> PList = new List<Control>();
			EditName m_name = new EditName();
			PList.Add(m_name);
			
			EditBool m_IsFull = new EditBool();
			m_IsFull.SetCaptionPropName("IsFull", typeof(bool));
			PList.Add(m_IsFull);
				;
			EditLayerLocation m_location = new EditLayerLocation();
			PList.Add(m_location);

			EditLayerSizeRoot m_SizeRoot = new EditLayerSizeRoot();
			PList.Add(m_SizeRoot);
			
			EditLayerSize m_Size = new EditLayerSize();
			PList.Add(m_Size);

			EditPadding m_DrawMargin = new EditPadding();
			m_DrawMargin.SetCaptionPropName("DrawMargin", typeof(Padding));

			PList.Add(m_DrawMargin);

			return PList;
		}
		public virtual List<Control> ParamsParam()
		{
			List<Control> PList = new List<Control>();
			return PList;

		}
		public virtual List<Control> ParamsColors()
		{
			List<Control> PList = new List<Control>();

			EditMGColors m_cFill = new EditMGColors();
			m_cFill.SetCaptionPropName("Fill", typeof(MG_COLORS));
			PList.Add(m_cFill);

			EditNumber m_cFillOpacity = new EditNumber();
			m_cFillOpacity.SetCaptionPropName("FillOpacity", typeof(float));
			m_cFillOpacity.SetValueMinMax(0, 100);
			PList.Add(m_cFillOpacity);

			EditMGColors m_cLine = new EditMGColors();
			m_cLine.SetCaptionPropName("Line", typeof(MG_COLORS));
			PList.Add(m_cLine);

			EditNumber m_cLineOpacity = new EditNumber();
			m_cLineOpacity.SetCaptionPropName("LineOpacity", typeof(float));
			m_cLineOpacity.SetValueMinMax(0, 100);
			PList.Add(m_cLineOpacity);

			return PList;
		}
		// ***************************************************************************
	}
}
