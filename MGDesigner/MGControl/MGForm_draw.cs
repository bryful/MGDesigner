using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDesigner
{


	partial class MGForm
	{
		private FormDrawStyle[] m_FormDrawStyle = new FormDrawStyle[] {FormDrawStyle.Grid,FormDrawStyle.Frame};
		public FormDrawStyle[] DrawStyle
		{
			get { return m_FormDrawStyle; }
			set { m_FormDrawStyle = value; this.Invalidate(); }
		}



		#region Frame
		private MG_COLOR m_Frame = MG_COLOR.White;
		[Category("_MG")]
		public MG_COLOR Frame
		{
			get { return m_Frame; }
			set
			{
				m_Frame = value;
				this.Invalidate();
			}
		}
		private int m_FrameWeight = 0;
		[Category("_MG")]
		public int FrameWeight
		{
			get { return m_FrameWeight; }
			set
			{
				m_FrameWeight = value;
				this.Invalidate();
			}
		}
		private double m_FrameOpacity = 100;
		[Category("_MG")]
		public double FrameOpacity
		{
			get { return m_FrameOpacity; }
			set
			{
				m_FrameOpacity = value;
				this.Invalidate();
			}
		}
		#endregion
		// *******************************************
		#region Grid
		private MG_COLOR m_Grid = MG_COLOR.White;
		[Category("_MG_Grid")]
		public MG_COLOR Grid
		{
			get { return m_Grid; }
			set
			{
				m_Grid = value;
				this.Invalidate();
			}
		}
		private float m_GridWeight = 0;
		[Category("_MG_Grid")]
		public float GridWeight
		{
			get { return m_GridWeight; }
			set
			{
				m_GridWeight = value;
				if (m_GridWeight < 0) m_GridWeight = 0;
				this.Invalidate();
			}
		}
		private double m_GridOpacity = 100;
		[Category("_MG_Grid")]
		public double GridOpacity
		{
			get { return m_GridOpacity; }
			set
			{
				m_GridOpacity = value;
				this.Invalidate();
			}
		}
		private float m_GridWidth = 100;
		[Category("_MG_Grid")]
		public float GridWidth
		{
			get { return m_GridWidth; }
			set
			{
				m_GridWidth = value;
				this.Invalidate();
			}
		}
		private float m_GridHeight = 100;
		[Category("_MG_Grid")]
		public float GridHeight
		{
			get { return m_GridHeight; }
			set
			{
				m_GridHeight = value;
				this.Invalidate();
			}
		}
		#endregion
		// ******************************************
		#region Edge
		private MG_COLOR m_Edge = MG_COLOR.White;
		[Category("_MG_Edge")]
		public MG_COLOR Edge
		{
			get { return m_Edge; }
			set
			{
				m_Edge = value;
				this.Invalidate();
			}
		}
		private float m_EdgeHorMargin = 10;
		[Category("_MG_Edge")]
		public float EdgeHorMargin
		{
			get { return m_EdgeHorMargin; }
			set
			{
				m_EdgeHorMargin = value;
				this.Invalidate();
			}
		}
		private float m_EdgeVurMargin = 10;
		[Category("_MG_Edge")]
		public float EdgeVurMargin
		{
			get { return m_EdgeVurMargin; }
			set
			{
				m_EdgeVurMargin = value;
				this.Invalidate();
			}
		}
		private float m_EdgeWidth = 15;
		[Category("_MG_Edge")]
		public float EdgeWidth
		{
			get { return m_EdgeWidth; }
			set
			{
				m_EdgeWidth = value;
				if (m_EdgeWidth < 2) m_EdgeWidth = 2;
				this.Invalidate();
			}
		}
		private float m_EdgeHeight = 10;
		[Category("_MG_Edge")]
		public float EdgeHeight
		{
			get { return m_EdgeHeight; }
			set
			{
				m_EdgeHeight = value;
				if (m_EdgeHeight < 2) m_EdgeHeight = 2;
				this.Invalidate();
			}
		}
		private double m_EdgeOpacity = 0;
		[Category("_MG_Edge")]
		public double EdgeOpacity
		{
			get { return m_EdgeOpacity; }
			set
			{
				m_EdgeOpacity = value;
				this.Invalidate();
			}
		}
		#endregion

		#region Kagi
		private MG_COLOR m_Kagi = MG_COLOR.Blue;
		[Category("_MG_Kagi")]
		public MG_COLOR Kagi
		{
			get { return m_Kagi; }
			set
			{
				m_Kagi = value;
				this.Invalidate();
			}
		}
		private bool[] m_KagiEnabled = new bool[] { true, true, true, true };
		[Category("_MG_Kagi")]
		public bool[] KagiEnabled
		{
			get { return m_KagiEnabled; }
			set
			{
				if (value.Length > 0) m_KagiEnabled[0] = value[0];
				if (value.Length > 1) m_KagiEnabled[1] = value[1];
				if (value.Length > 2) m_KagiEnabled[2] = value[2];
				if (value.Length > 3) m_KagiEnabled[3] = value[3];
				this.Invalidate();
			}
		}
		private double m_KagiOpacity = 0;
		[Category("_MG_Kagi")]
		public double KagiOpacity
		{
			get { return m_KagiOpacity; }
			set
			{
				m_KagiOpacity = value;
				this.Invalidate();
			}
		}
		private int m_kagiWidth = 30;
		[Category("_MG_Kagi")]
		public int kagiWidth
		{
			get { return m_kagiWidth; }
			set
			{
				m_kagiWidth = value;
				this.Invalidate();
			}
		}
		private int m_kagiHeight = 30;
		[Category("_MG_Kagi")]
		public int kagiHeight
		{
			get { return m_kagiHeight; }
			set
			{
				m_kagiHeight = value;
				this.Invalidate();
			}
		}
		private int m_kagiWeightH = 5;
		[Category("_MG_Kagi")]
		public int kagiWeightH
		{
			get { return m_kagiWeightH; }
			set
			{
				m_kagiWeightH = value;
				this.Invalidate();
			}
		}
		private int m_kagiWeightV = 5;
		[Category("_MG_Kagi")]
		public int kagiWeightV
		{
			get { return m_kagiWeightV; }
			set
			{
				m_kagiWeightV = value;
				this.Invalidate();
			}
		}
		private int m_kagiMarginH = 30;
		[Category("_MG_Kagi")]
		public int kagiMarginH
		{
			get { return m_kagiMarginH; }
			set
			{
				m_kagiMarginH = value;
				this.Invalidate();
			}
		}
		private int m_kagiMarginV = 30;
		[Category("_MG_Kagi")]
		public int kagiMarginV
		{
			get { return m_kagiMarginV; }
			set
			{
				m_kagiMarginV = value;
				this.Invalidate();
			}
		}
		#endregion
	}
}
