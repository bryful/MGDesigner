using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MGCreator.ProperyPanel;

namespace MGCreator
{
	public partial class EditResizeType : Control
	{

		private int m_CaptionWidth = 60;
		[Category("_MG")]
		public int CaptionWidth
		{
			get { return m_CaptionWidth; }
			set
			{
				m_CaptionWidth = value;
				ChkSize();
			}
		}
		protected Label m_label = new Label();
		protected ResizeTypeComb m_cmb = new ResizeTypeComb();

		public EditResizeType()
		{
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(0, 20);
			this.MaximumSize = new Size(0, 20);
			// ********************
			m_label.Name = "ResizeRoot";
			m_label.Text = "SizeRoot";
			m_label.AutoSize = false;
			m_label.TextAlign = ContentAlignment.MiddleLeft;
			m_label.Location = new Point(0, 0);
			m_label.Size = new Size(60, 20);
			// ********************
			m_cmb.Name = "cmb";
			m_cmb.AutoSize = false;
			m_cmb.Location = new Point(60, 0);
			m_cmb.Size = new Size(80, 20);
			this.Controls.Add(m_label);
			this.Controls.Add(m_cmb);
			InitializeComponent();
			ChkSize();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);
		
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public void ChkSize()
		{
			this.SuspendLayout();
			m_label.Width = m_CaptionWidth;
			m_label.Location = new Point(0, 0);
			int w = (this.Width - m_CaptionWidth);
			m_cmb.Width = w;
			m_cmb.Location = new Point(m_CaptionWidth, 0);
			this.ResumeLayout();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
		public ReSizeType SelectedReSizeType
		{
			get
			{
				return m_cmb.SelectedReSizeType;
			}
			set
			{
				m_cmb.SelectedReSizeType = value;
			}
		}
	}
}
