using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGCreator
{
	partial class MGLayer
	{
		public bool IsShow = true;
		// **************************************************
		protected int m_Index = -1;
		public int Index { get { return m_Index; } }
		public void SetIndex(int idx) { m_Index = idx; }

		// **************************************************
		protected MGForm? m_MGForm = null;
		[Category("_MGLayer")]
		public MGForm? MGForm
		{
			get { return m_MGForm; }
		}

		// **************************************************
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
					OnNameChanged(new NameChangedEventArgs(m_Name, m_Index));
				}
			}
		}
		// **************************************************

		protected Bitmap m_Offscr = new Bitmap(100, 100, PixelFormat.Format32bppArgb);
		public Bitmap OffScr() { return m_Offscr; }
		// **************************************************

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

		protected Point m_location = new Point(0, 0);
		[Category("_MGLayer")]
		public Point Location
		{
			get { return m_location; }
			set
			{
				if (m_CornerLock == false)
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
				if (m_CornerLock)
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
		// ********************************************
		protected MG_COLORS m_Back = MG_COLORS.Black;
		/// <summary>
		/// 基本となる塗りつぶし入り
		/// </summary>
		[Category("_MG")]
		public MG_COLORS Back
		{
			get { return m_Back; }
			set
			{
				m_Back = value;
				ChkOffScr();
			}
		}
		protected float m_BackOpacity = 0;
		/// <summary>
		/// 線の透明度
		/// </summary>
		[Category("_MG")]
		public float BackOpacity
		{
			get { return m_BackOpacity; }
			set
			{
				m_BackOpacity = value;
				ChkOffScr();
			}
		}       // ********************************************
		protected MG_COLORS m_Fill = MG_COLORS.White;
		/// <summary>
		/// 基本となる塗りつぶし入り
		/// </summary>
		[Category("_MG")]
		public MG_COLORS Fill
		{
			get { return m_Fill; }
			set
			{
				m_Fill = value;
				ChkOffScr();
			}
		}
		protected float m_FillOpacity = 0;
		/// <summary>
		/// 線の透明度
		/// </summary>
		[Category("_MG")]
		public float FillOpacity
		{
			get { return m_FillOpacity; }
			set
			{
				m_FillOpacity = value;
				ChkOffScr();
			}
		}
		protected MG_COLORS m_Line = MG_COLORS.Red;
		/// <summary>
		/// 線の色
		/// </summary>
		[Category("_MG")]
		public MG_COLORS Line
		{
			get { return m_Line; }
			set
			{
				m_Line = value;
				ChkOffScr();
			}
		}
		protected float m_LineWeight = 2;

		// **************************************************************
		protected float m_LineOpacity = 100;
		/// <summary>
		/// 線の透明度
		/// </summary>
		[Category("_MG")]
		public float LineOpacity
		{
			get { return m_LineOpacity; }
			set
			{
				m_LineOpacity = value;
				ChkOffScr();
			}
		}
		/// <summary>
		/// 線の太さ
		/// </summary>
		[Category("_MG")]
		public float LineWeight
		{
			get { return m_LineWeight; }
			set
			{
				m_LineWeight = value;
				ChkOffScr();
			}
		}
		protected MG_COLORS m_Frame = MG_COLORS.White;
		/// <summary>
		/// 線の色
		/// </summary>
		[Category("_MG")]
		public MG_COLORS Frame
		{
			get { return m_Frame; }
			set
			{
				m_Frame = value;
				ChkOffScr();
			}
		}
		protected float m_FrameOpacity = 100;
		/// <summary>
		/// 線の透明度
		/// </summary>
		[Category("_MG")]
		public float FrameOpacity
		{
			get { return m_FrameOpacity; }
			set
			{
				m_FrameOpacity = value;
				ChkOffScr();
			}
		}
		protected Padding m_FrameWeight = new Padding(2,2,2,2);
		/// <summary>
		/// 線の太さ
		/// </summary>
		[Category("_MG")]
		public Padding FrameWeight
		{
			get { return m_FrameWeight; }
			set
			{
				m_FrameWeight = value;
				ChkOffScr();
			}
		}

		// ********************************************
		protected bool m_IsFull = false;
		[Category("_MGLayer")]
		public bool IsFull
		{
			get { return m_IsFull; }
			set
			{
				m_IsFull = value;
				if (m_MGForm != null) m_MGForm.Invalidate();
			}
		}
		// ********************************************
	
	}
}
