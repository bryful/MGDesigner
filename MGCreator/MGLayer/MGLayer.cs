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
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public enum MGStyle
	{
		None = -1,
		Frame,
		Grid,
		Circle,
		CircleScale,
		Triangle,
		Polygon,
		Cross,
		Zebra,
		Label,
		Parallelogram,
		Scale,
		Sheet,
		Kagi,
		Edge,
		Side,
		PNG,
		JSON,
	};
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
		public readonly MGStyle MGStyle = MGStyle.Frame;
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
		// **************************************************
		public void SetCorner(bool IsEvent = true)
		{
			SetCorner(m_SizeRoot, IsEvent);
		}
		// **************************************************
		public void SetCorner(SizeRootType sr, bool IsEvent = true)
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
		// ************************************************************************
		#region Draw
		public Color GetColors(MG_COLORS c, double op)
		{
			if (m_MGForm!=null)
			{
				return m_MGForm.GetMGColors(c, op);
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

				if((m_Back!=MG_COLORS.Transparent)&&(m_BackOpacity > 0))
				{
					sb.Color = GetColors(m_Back, m_BackOpacity);
					g.FillRectangle(sb, r2);
				}
				if ((m_Frame != MG_COLORS.Transparent) && (m_FrameOpacity > 0))
				{
					sb.Color = GetColors(m_Frame, m_FrameOpacity);
					MGc.DrawFrame(g, sb, r2, m_FrameWeight);
				}

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
			m_Back = MG_COLORS.Black;
			m_FrameOpacity = 100;
			m_Frame = MG_COLORS.White;
			m_FrameOpacity = 100;

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
			EditPadding m_F = new EditPadding();
			m_F.SetCaptionPropName("FrameWeight", typeof(Padding));
			PList.Add(m_F);

			return PList;

		}
		public virtual List<Control> ParamsColors()
		{
			List<Control> PList = new List<Control>();

			EditMGColors m_B = new EditMGColors();
			m_B.SetCaptionPropName("Back", typeof(MG_COLORS));
			PList.Add(m_B);

			EditNumber m_BOpacity = new EditNumber();
			m_BOpacity.SetCaptionPropName("BackOpacity", typeof(float));
			m_BOpacity.SetValueMinMax(0, 100);
			PList.Add(m_BOpacity);

			EditMGColors m_F = new EditMGColors();
			m_F.SetCaptionPropName("Frame", typeof(MG_COLORS));
			PList.Add(m_F);

			EditNumber m_FOpacity = new EditNumber();
			m_FOpacity.SetCaptionPropName("FrameOpacity", typeof(float));
			m_FOpacity.SetValueMinMax(0, 100);
			PList.Add(m_FOpacity);

			return PList;
		}
		// ***************************************************************************
		public virtual Bitmap? ToBitmap()
		{
			Bitmap? bmp = null;
			if (m_MGForm == null) return null;
			bmp= new Bitmap(m_MGForm.Width, m_MGForm.Height,PixelFormat.Format32bppArgb);
			Graphics g = Graphics.FromImage(bmp);
			Draw(g, new Rectangle(m_location, m_Size), true);
			return bmp;
		}
		// ***************************************************************************
		public virtual Bitmap? ToBitmapLayer()
		{
			Bitmap? bmp = null;
			bmp = new Bitmap(m_Size.Width, m_Size.Height, PixelFormat.Format32bppArgb);
			Graphics g = Graphics.FromImage(bmp);
			Draw(g, new Rectangle(new Point(0,0), m_Size), true);
			return bmp;
		}
		// ***************************************************************************
		public virtual JsonObject ToJson()
		{
			MGj jn = new MGj(new JsonObject());
			jn.SetValue("MGStyle", (int)MGStyle);
			jn.SetValue("Name", m_Name);
			jn.SetValue("IsFull", m_IsFull);
			jn.SetValue("CornerLock", m_CornerLock);
			jn.SetValue("SizeRoot", (int)m_SizeRoot);
			jn.SetValueRectangle("Bounds", this.Bounds);
			jn.SetValuePadding("DrawMargin", m_DrawMargin);
			jn.SetValue("Back", (int)m_Back);
			jn.SetValue("BackOpacity", m_BackOpacity);
			jn.SetValue("Fill", (int)m_Fill);
			jn.SetValue("FillOpacity", m_FillOpacity);
			jn.SetValue("Line", (int)m_Line);
			jn.SetValue("LineOpacity", m_LineOpacity);
			jn.SetValue("LineWeight", m_LineWeight);
			jn.SetValue("Frame", (int)m_Frame);
			jn.SetValue("FrameOpacity", m_FrameOpacity);
			jn.SetValuePadding("FrameWeight", m_FrameWeight);
			return jn.Obj;
		}
		// ***************************************************************************
		public virtual void FromJson(JsonObject jo)
		{
			bool ret = false;
			if (jo == null) return;
			MGj jn = new MGj(jo);
			int v = 0;

			if (jn.GetStr("Name", ref m_Name) == false) ret = false;
			if (jn.GetBool("IsFull", ref m_IsFull) == false) ret = false;
			if (jn.GetBool("CornerLock", ref m_CornerLock) == false) ret = false;
			if (jn.GetInt("SizeRoot", ref v) == true) m_SizeRoot = (SizeRootType)v; else ret = false;
			Rectangle r = new Rectangle(0, 0, 0, 0);
			if (jn.GetRectangle("Bounds", ref r) == true)
			{
				m_location = r.Location;
				m_Size = r.Size;
			}
			else {
				ret = false;
			}
			if (jn.GetPadding("DrawMargin", ref m_DrawMargin) == false) ret = false;
			v = 0;
			if (jn.GetInt("Back", ref v) == true) m_Back = (MG_COLORS)v; else ret = false;
			if (jn.GetFloat("BackOpacity", ref m_BackOpacity) == false)  ret = false;
			if (jn.GetInt("Fill", ref v) == true) m_Fill = (MG_COLORS)v; else ret = false;
			if (jn.GetFloat("FillOpacity", ref m_FillOpacity) == false) ret = false;
			if (jn.GetInt("Line", ref v) == true) m_Line = (MG_COLORS)v; else ret = false;
			if (jn.GetFloat("LineOpacity", ref m_LineOpacity) == false) ret = false;
			if (jn.GetInt("Frame", ref v) == true) m_Frame = (MG_COLORS)v; else ret = false;
			if (jn.GetFloat("FrameOpacity", ref m_LineOpacity) == false) ret = false;
			if (jn.GetPadding("FrameWeight", ref m_FrameWeight) == false) ret = false;

		}
	}
}
