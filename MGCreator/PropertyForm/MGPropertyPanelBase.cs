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
	public partial class MGPropertyPanelBase : PropertyPanel
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

		// **********************************************************************
		
		public MGPropertyPanelBase()
		{

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
			SetFormSub(this,f);

		}

		private void Layers_TargetLayerChanged(object sender, MGLayers.TargetLayerChangedEventArgs e)
		{
			SetControls();
		}

		private void SetFormSub(PropertyPanel pp, MGForm? f)
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
						SetFormSub((PropertyPanel)c, f);
					}
				}
			}
		}

		private void SetControls()
		{
			if (m_MGForm != null)
			{
				m_Layer = m_MGForm.TargetLayer;
				if (m_Layer != null)
				{
					this.Clear();
					AddControls(m_Layer.Param());

					this.SetMGStyle(m_Layer.MGStyle);
					this.AutoLayout();
				}
			}
			SetFormSub(this, m_MGForm);
		}
	}
}
