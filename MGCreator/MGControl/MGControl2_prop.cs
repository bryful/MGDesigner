using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGCreator
{
	public partial class MGControl2
	{
		// ********************************************
		protected MGStyle m_MGStyle = MGStyle.Frame;
		[Category("_MG")]
		public MGStyle MGStyle
		{
			get { return m_MGStyle; }
			set
			{
				m_MGStyle = value;
				ChkOffScr();
			}
		}
		// ********************************************
		protected Color m_UnEnabledColor = Color.DarkGray;
		[Category("_MG")]
		public Color UnEnabledColor
		{
			get { return m_UnEnabledColor; }
			set
			{
				m_UnEnabledColor = value;
				ChkOffScr();
			}
		}
		protected bool m_IsShowGuide = true;
		[Category("_MG")]
		public bool IsShowGuide
		{
			get { return m_IsShowGuide; }
			set
			{
				m_IsShowGuide = value;
				ChkOffScr();
				this.Invalidate();
			}
		}
		// ********************************************
		/// <summary>
		/// コントロールの順番を入れる
		/// </summary>
		protected int m_Index = -1;
		/// <summary>
		/// コントロールの順番を入れる
		/// </summary>
		[Category("_MG")]
		public int Index
		{
			get { return m_Index; }
			set { m_Index = value; }
		}
		// ********************************************
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

		// ********************************************
		/// <summary>
		/// 全画面描画フラグ
		/// </summary>
		protected bool m_IsFull = false;
		/// <summary>
		/// 全画面描画フラグ
		/// </summary>
		[Category("_MG")]
		public bool IsFull
		{
			get
			{
				base.Visible = !m_IsFull;
				return m_IsFull;
			}
			set
			{
				m_IsFull = value;
				base.Visible = !m_IsFull;
				ChkOffScr();
				if (this.Parent != null)
				{
					if (this.Parent is MGForm)
					{
						MGForm mf = (MGForm)this.Parent;
						mf.Invalidate();
					}
				}
				this.Invalidate();
			}
		}
		// ********************************************
		protected Control2Pos m_Control2Pos = Control2Pos.None;
		/// <summary>
		/// コントロールの固定位置
		/// </summary>
		[Category("_MG")]
		public Control2Pos Control2Pos
		{
			get
			{
				return m_Control2Pos;
			}
			set
			{
				SetControl2Pos(value);
			}
		}
		protected Padding m_PosMargin = new Padding(0, 0, 0, 0);
		/// <summary>
		/// 
		/// </summary>
		[Category("_MG")]
		public Padding PosMargin
		{
			get { return m_PosMargin; }
			set
			{
				m_PosMargin = value;
				SetControl2Pos();
			}

		}
		protected Padding m_DrawMargin = new Padding(0, 0, 0, 0);
		/// <summary>
		/// 描画マージン
		/// </summary>
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
		protected Size m_GridSize = new Size(100,100);
		/// <summary>
		/// 描画マージン
		/// </summary>
		[Category("_MG")]
		public Size GridSize
		{
			get { return m_GridSize; }
			set
			{
				m_GridSize = value;
				ChkOffScr();
			}

		}
	}
}
