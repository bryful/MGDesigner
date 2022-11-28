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
				SetMGForm(value);
			}
		}

		// **********************************************************************
		private PropertyPanel m_PPForm = new PropertyPanel();
		private PropertyPanel m_PPParts = new PropertyPanel();
		private PropertyPanel m_PPLayout = new PropertyPanel();
		private PropertyPanel m_PPDisp = new PropertyPanel();


		private EditName m_Name = new EditName();
		private EditBool m_IsFull = new EditBool();
		private EditBool m_IsShowGuide = new EditBool();
		private EditPadding m_DrawMargin = new EditPadding();

		private EditPosition m_Position = new EditPosition();
		private EditSize m_Size = new EditSize();

		private EditMGColors m_Fill = new EditMGColors();
		private EditNumber m_FillOpacity = new EditNumber();
		private EditMGColors m_Line = new EditMGColors();
		private EditNumber m_LineOpacity = new EditNumber();


		public MGPropertyPanel()
		{
			m_PPForm.Name = "PPForm";
			m_PPForm.Text = "Monitor";
			m_PPForm.Caption = "Monitor";

			m_PPParts.Name = "PPParts";
			m_PPParts.Text = "Parts";
			m_PPParts.Caption = "Parts";

			m_PPLayout.Name = "PPLayoutn";
			m_PPLayout.Text = "Layout";
			m_PPLayout.Caption = "Layout";
			
			m_PPDisp.Name = "PPDraw";
			m_PPDisp.Text = "Draw";
			m_PPDisp.Caption = "Draw";

			m_Size.IsShowResizeType = true;

			m_Fill.SetCaptionPropName("Fill");
			m_FillOpacity.SetCaptionPropName("FillOpacity");
			m_Line.SetCaptionPropName("Line");
			m_LineOpacity.SetCaptionPropName("LineOpacity");
			m_IsFull.SetCaptionPropName("IsFull");
			m_IsShowGuide.SetCaptionPropName("Guide", "IsShowGuide");
			m_DrawMargin.SetCaptionPropName("DrawMargin");

			m_PPForm.AddControl(m_Name);
			m_PPForm.AddControl(m_IsShowGuide);

			m_PPParts.AddControl(m_IsFull);
			m_PPParts.AddControl(m_DrawMargin);

			m_PPLayout.AddControl(m_Position);
			m_PPLayout.AddControl(m_Size);

			m_PPDisp.AddControl(m_Fill);
			m_PPDisp.AddControl(m_FillOpacity);
			m_PPDisp.AddControl(m_Line);
			m_PPDisp.AddControl(m_LineOpacity);

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
		public void SetMGForm(MGForm? f)
		{
			if(f == null) return;
			m_MGForm = f;
			m_MGForm.ForcusChanged += M_MGForm_ForcusChanged;
			SetControls();
			SetFormSub(this,f);

		}
		private void SetFormSub(PropertyPanel pp, MGForm? f)
		{
			if (f == null) return;
			if (pp.Controls.Count > 0)
			{
				foreach (Control c in pp.Controls)
				{
					if(c is EditPosition)
					{
						((EditPosition)c).MGForm = f;
					}
					else if (c is EditSize)
					{
						((EditSize)c).MGForm = f;
					}
					else if (c is Edit)
					{
						((Edit)c).MGForm = f;
					}
					else if(c is PropertyPanel)
					{
						SetFormSub((PropertyPanel)c, f);
					}
				}
			}
		}

		private void M_MGForm_ForcusChanged(object sender, ForcusChangedEventArgs e)
		{
			SetControls();
		}
		private void SetControls()
		{
			if (m_MGForm != null)
			{
				m_control = m_MGForm.ForcusControl;
				if (m_control != null)
				{
					this.SetMGStyle(m_control.MGStyle);
					this.AutoLayout();
				}
			}
		}
	}
}
