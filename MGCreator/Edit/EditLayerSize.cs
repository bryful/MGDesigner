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

	public partial class EditLayerSize : Edit
	{
		
		public new readonly MGStyle ShowMGStyle = MGStyle.ALL;
		// ****************************************************************************
		protected override void SetMGForm(MGForm? m)
		{
			m_MGForm = m;
			if (m_MGForm != null)
			{
				m_MGForm.Layers.TargetLayerChanged += Layers_TargetLayerChanged;
				m_Layer = m_MGForm.Layers.TargetLayer;
				if (m_Layer != null)
				{
					m_edit.Value = m_Layer.Size;
					m_Layer.SizeChanged += M_Layer_Resize;
				}
			}
		}
		private void Layers_TargetLayerChanged(object sender, MGLayers.TargetLayerChangedEventArgs e)
		{
			if (m_MGForm != null)
			{
				m_Layer = e.Layer;
				if (m_Layer != null)
				{
					m_edit.Value = m_Layer.Size;
					m_Layer.SizeChanged += M_Layer_Resize;
					m_edit.Value = m_Layer.Size;
					//GetValeuFromControl();
				}
			}
		}


		private void M_Layer_Resize(object sender, EventArgs e)
		{
			if (m_Layer != null)
			{
				m_edit.Value = m_Layer.Size;
			}
		}



		// ****************************************************************************
		protected SizeEdit m_edit = new SizeEdit();


		// ****************************************************************************
		public EditLayerSize()
		{
			this.ForeColor = Color.LightGray;
			this.BackColor = Color.Black;
			Caption = "Size";
			// ********************
			m_edit.Name = "x";
			m_edit.AutoSize = false;
			m_edit.Location = new Point(60, 0);
			m_edit.Size = new Size(80, 20);
			m_edit.ValueChanged += M_edit_ValueChanged;
			// ********************
	
			this.Controls.Add(m_edit);
			InitializeComponent();
		}

		private void M_edit_ValueChanged(object sender, SizeEdit.ValueChangedEventArgs e)
		{
			if (m_Layer != null)
			{
				m_Layer.Size = m_edit.Value;
			}
		}



		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public void ChkSize()
		{
			int w = (this.Width - m_CaptionWidth );
			m_edit.Width = w;
			m_edit.Location = new Point(m_CaptionWidth, 0);
			this.Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}

	
	}
}
