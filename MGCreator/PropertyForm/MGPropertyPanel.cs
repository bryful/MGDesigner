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
		private MGControl? m_control = null;
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

		private Edit m_FormSize = new Edit();

		private EditPosition m_Position = new EditPosition();
		private EditSize m_Size = new EditSize();
		private EditName m_Name = new EditName();
		private EditIsFull m_IsFull = new EditIsFull();
		private EditDrawMargin m_DrawMargin = new EditDrawMargin();
		private EditBool m_Dummy1 = new EditBool();
		private Edit m_Dummy2 = new Edit();
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
			m_PPParts.AddControl(m_IsFull);
			m_PPParts.AddControl(m_DrawMargin);

			m_PPForm.AddControl(m_FormSize);
			m_PPLayout.AddControl(m_Position);
			m_PPLayout.AddControl(m_Size);


			m_Dummy1.BoolValueChanged += M_Dummy1_BoolValueChanged;

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

		private void M_Dummy1_BoolValueChanged(object sender, BoolValueChangedEventArgs e)
		{
			if(m_control != null)
			{
				m_control.IsFull = e.BoolValue;
			}
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
			m_IsFull.MGForm = f;
			m_DrawMargin.MGForm = f;
			m_MGForm = f;
			if (m_MGForm != null)
			{
				m_control = m_MGForm.ForcusControl;
				m_MGForm.ForcusChanged += F_ForcusChanged;
			}
		}

		private void F_ForcusChanged(object sender, ForcusChangedEventArgs e)
		{
			if (m_MGForm != null)
			{
				m_control = m_MGForm.ForcusControl;
				if (m_control != null)
				{
					m_Dummy1.BoolValue = m_control.IsFull;
				}
			}
		}
	}
}
