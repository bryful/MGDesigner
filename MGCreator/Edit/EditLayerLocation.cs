using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{

	public partial class EditLayerLocation : Edit
	{
		protected override void SetMGForm(MGForm? m)
		{
			m_MGForm = m;
			if (m_MGForm != null)
			{
				m_MGForm.Layers.TargetLayerChanged += Layers_TargetLayerChanged;
				m_Layer = m_MGForm.Layers.TargetLayer;
				if (m_Layer != null)
				{
					m_edit.Value = m_Layer.Location;
					m_Layer.LocationChanged += M_Layer_LocationChanged; ;
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
					m_edit.Value = m_Layer.Location;
					m_Layer.LocationChanged += M_Layer_LocationChanged;
				}
			}
		}

		private void M_Layer_LocationChanged(object sender, EventArgs e)
		{
			if (m_Layer != null)
			{
				m_edit.Value = m_Layer.Location;
			}
		}
		// ****************************************************************************
		
		// ****************************************************************************
		
		// ****************************************************************************
		protected PointEdit m_edit = new PointEdit();
		// ****************************************************************************
		public EditLayerLocation()
		{
			this.ForeColor = Color.LightGray;
			this.BackColor = Color.Black;
			Caption = "Position";
			// ********************
			m_edit.Name = "Pos";
			m_edit.AutoSize = false;
			m_edit.Location = new Point(m_CaptionWidth, 0);
			m_edit.Size = new Size(160, 20);
			m_edit.ValueChanged += M_posEdit_ValueChanged2;

			// ********************
			this.Controls.Add(m_edit);
			InitializeComponent();
		}

		private void M_posEdit_ValueChanged2(object sender, PointEdit.ValueChangedEventArgs e)
		{

			if(m_Layer!=null)
			{
				if (m_Layer.CornerLock == false)
				{
					m_Layer.Location = e.Value;
				}
			}
		}


		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public void ChkSize()
		{
			int w = (this.Width - m_CaptionWidth);
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
