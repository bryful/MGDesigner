using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public partial class MGPropertyPanel : PropertyPanel
	{
		private MGForm? m_MGForm = null;
		[Category("_MG")]
		public MGForm? MGForm
		{
			get { return m_MGForm; }
			set
			{
				m_MGForm = value;
				SetForm(m_MGForm);
			}
		}

		// **********************************************************************
		private PropertyPanel m_PPForm = new PropertyPanel();
		private PropertyPanel m_PPParts = new PropertyPanel();
		private PropertyPanel m_PPLayout = new PropertyPanel();
		private PropertyPanel m_PPDisp = new PropertyPanel();

		private EditBase m_FormSize = new EditBase();

		private EditPosition m_Position = new EditPosition();
		private EditSize m_Size = new EditSize();
		private EditName m_Name = new EditName();
		private EditBase m_Dummy1 = new EditBase();
		private EditBase m_Dummy2 = new EditBase();
		public MGPropertyPanel()
		{
			m_PPForm.Name = "PPForm";
			m_PPForm.Text = "Monitor";
			m_PPForm.Caption = "Monitor";

			m_PPParts.Name = "Parts";
			m_PPParts.Text = "Parts";
			m_PPParts.Caption = "Parts";

			m_PPLayout.Name = "PPLocation";
			m_PPLayout.Text = "Layout";
			m_PPLayout.Caption = "Layout";
			
			m_PPDisp.Name = "PPDraw";
			m_PPDisp.Text = "Draw";
			m_PPDisp.Caption = "Draw";

			m_Size.IsShowResizeType = true;

			m_PPParts.AddControl(m_Name);

			m_PPForm.AddControl(m_FormSize);
			m_PPLayout.AddControl(m_Position);
			m_PPLayout.AddControl(m_Size);


			m_PPDisp.AddControl(m_Dummy1);
			m_PPDisp.AddControl(m_Dummy2);

			AddControl(m_PPForm);
			AddControl(m_PPParts);
			AddControl(m_PPLayout);
			AddControl(m_PPDisp);



			InitializeComponent();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);
			this.AutoLayout();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public void SetForm(MGForm? f)
		{
			m_Position.MGForm = f;
			m_Size.MGForm = f;
			m_Name.MGForm = f;
		}
	}
}
