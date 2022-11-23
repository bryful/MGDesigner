using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGDesigner
{
	public partial class MGLabel : MGControl
	{
		#region Label
		private StringFormat m_sf = new StringFormat();
		[Category("_MG_Label")]
		public StringAlignment StringAlignment
		{
			get { return m_sf.Alignment; }
			set
			{
				m_sf.Alignment = value;
				ChkOffScr();
			}
		}
		[Category("_MG_Label")]
		public StringAlignment StringLineAlignment
		{
			get { return m_sf.LineAlignment; }
			set
			{
				m_sf.LineAlignment = value;
				ChkOffScr();
			}
		}
		[Category("_MG_Label")]
		public string MGText
		{
			get { return this.Text; }
			set
			{
				this.Text = value;
				ChkOffScr();
			}
		}
		private Padding m_MGTextMargion = new Padding(0,0,0,0);
		[Category("_MG_Label")]
		public Padding MGTextMargion
		{
			get { return m_MGTextMargion; }
			set
			{
				m_MGTextMargion = value;
				ChkOffScr();
			}
		}
		private Size m_LeftBox = new Size(12, 12);
		[Category("_MG_Label")]
		public Size LeftBox
		{
			get { return m_LeftBox; }
			set
			{
				m_LeftBox = value;
				ChkOffScr();
			}
		}
		private Size m_RightBox = new Size(0, 0);
		[Category("_MG_Label")]
		public Size RightBox
		{
			get { return m_RightBox; }
			set
			{
				m_RightBox = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_Label = MG_COLORS.White;
		[Category("_MG_Label")]
		public MG_COLORS Label
		{
			get { return m_Label; }
			set
			{
				m_Label = value;
				ChkOffScr();
			}
		}
		[Category("_MG_Label")]
		public Font MGFont
		{
			get { return this.Font; }
			set
			{
				this.Font = value;
				ChkOffScr();
			}
		}
		private double m_LabelOpacity = 100;
		[Category("_MG_Label")]
		public double LabelOpacity
		{
			get { return m_LabelOpacity; }
			set
			{
				m_LabelOpacity = value;
				this.Invalidate();
			}
		}
		#endregion
		#region Back
		private MG_COLOR m_Back = MG_COLOR.Transparent;
		[Category("_MG")]
		public MG_COLOR Back
		{
			get { return m_Back; }
			set
			{
				m_Back = value;
				this.Invalidate();
			}
		}
		private double m_BackOpacity = 0;
		[Category("_MG")]
		public double BackOpacity
		{
			get { return m_BackOpacity; }
			set
			{
				m_BackOpacity = value;
				this.Invalidate();
			}
		}
		#endregion
		#region Frame
		private int m_FrameWeight = 0;
		[Category("_MG_Frame")]
		public int FrameWeight
		{
			get { return m_FrameWeight; }
			set
			{
				m_FrameWeight = value;
				this.Invalidate();
			}
		}
		private MG_COLOR m_Frame = MG_COLOR.Gray;
		[Category("_MG_Frame")]
		public MG_COLOR Frame
		{
			get { return m_Frame; }
			set
			{
				m_Frame = value;
				this.Invalidate();
			}
		}
		private double m_FramelOpacity = 100;
		[Category("_MG_Frame")]
		public double FramelOpacity
		{
			get { return m_FramelOpacity; }
			set
			{
				m_FramelOpacity = value;
				this.Invalidate();
			}
		}
		#endregion
		public MGLabel()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
	}
}
