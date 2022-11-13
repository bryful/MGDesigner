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
		// *******************************************
		private MG_COLOR m_Grid = MG_COLOR.White;
		[Category("_MG")]
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
		[Category("_MG")]
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
		[Category("_MG")]
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
		[Category("_MG")]
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
		[Category("_MG")]
		public float GridHeight
		{
			get { return m_GridHeight; }
			set
			{
				m_GridHeight = value;
				this.Invalidate();
			}
		}
	}
}
