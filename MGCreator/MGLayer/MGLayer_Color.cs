using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGCreator
{
	public partial class MGLayer
	{
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
		protected Size m_GridSize = new Size(100, 100);
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
