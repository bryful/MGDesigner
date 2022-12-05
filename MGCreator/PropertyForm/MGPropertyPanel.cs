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
	public partial class MGPropertyPanel : PropertyPanelGroup
	{
		private MGLayer? m_Layer = null;
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
		private PropertyPanel m_Main = new PropertyPanel();
		private PropertyPanel m_Params = new PropertyPanel();
		private PropertyPanel m_Color = new PropertyPanel();
		// **********************************************************************

		public MGPropertyPanel()
		{
			m_Main.Caption = "Main";
			m_Params.Caption = "Params";
			m_Color.Caption = "Colors";
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;

			this.AddControl(m_Main);
			this.AddControl(m_Params);
			this.AddControl(m_Color);
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
			m_MGForm.Layers.TargetLayerChanged += Layers_TargetLayerChanged;

			SetControls();
			//SetFormSub(this, f);


		}

		private void Layers_TargetLayerChanged(object sender, MGLayers.TargetLayerChangedEventArgs e)
		{
			SetControls();
		}

		private void SetFormSub(Control pp, MGForm? f)
		{
			if (f == null) return;
			if (pp.Controls.Count > 0)
			{
				foreach (Control c in pp.Controls)
				{
					if (c is Edit)
					{
						((Edit)c).MGForm = f;
					}
					else if(c is PropertyPanel)
					{
						SetFormSub(c, f);
					}
				}
			}
		}

		private void SetControls()
		{
			if (m_MGForm != null)
			{
				m_Layer = m_MGForm.TargetLayer;
				this.SuspendLayout();
				if (m_Layer != null)
				{
					m_Main.Clear(false);
					m_Main.AddControls(m_Layer.ParamsMain(),false);
					m_Params.Clear(false);
					m_Params.AddControls(m_Layer.ParamsParam(), false);
					m_Color.Clear(false);
					m_Color.AddControls(m_Layer.ParamsColors(), false);
				}
				this.AutoLayout();
				this.ResumeLayout(true);
				SetFormSub(this, m_MGForm);
			}
		}
	}
}
