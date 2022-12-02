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
		protected Padding m_FrameWeight = new Padding(2,2,2,2);
		/// <summary>
		/// 線の太さ
		/// </summary>
		[Category("_MG")]
		public Padding FrameWeight
		{
			get { return FrameWeight; }
			set
			{
				FrameWeight = value;
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
