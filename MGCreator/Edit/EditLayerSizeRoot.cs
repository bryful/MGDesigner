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
	public partial class EditLayerSizeRoot : Edit
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
					m_edit.SizeRoot = m_Layer.SizeRoot;
					m_edit.CornerLock = m_Layer.CornerLock;
					PropError = false;
					this.Invalidate();
				}
			}
		}

		protected override void GetValeuFromControl()
		{
			if (m_Layer != null)
			{
				m_edit.SizeRoot = m_Layer.SizeRoot;
				m_edit.CornerLock = m_Layer.CornerLock;
				PropError = false;
				this.Invalidate();
			}
		}
		protected override void SetValeuToControl()
		{
			if (m_Layer != null)
			{
				m_edit.SizeRoot = m_Layer.SizeRoot;
				m_edit.CornerLock = m_Layer.CornerLock;
				PropError = false;
				this.Invalidate();
			}
		}
		private void Layers_TargetLayerChanged(object sender, MGLayers.TargetLayerChangedEventArgs e)
		{
			m_Layer = e.Layer;
			if (m_Layer != null)
			{
				m_edit.SizeRoot = m_Layer.SizeRoot;
				m_edit.CornerLock = m_Layer.CornerLock;
				PropError = false;
				this.Invalidate();
			}
		}

		protected SizeRootGrid m_edit = new SizeRootGrid();
		public EditLayerSizeRoot()
		{
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			Caption = "Position";
			SetCaptionPropName("SizeRoot", "SizeRoot");
			SetTargetType(typeof(SizeRootType));
			// ********************
			m_edit.Name = "ScaleGrid";
			m_edit.AutoSize = false;
			m_edit.Location = new Point(m_CaptionWidth, 0);
			m_edit.IsSmall = false;
			m_edit.SizeRootChanged += M_edit_SizeRootChanged;
			m_edit.CornerLockChanged += M_edit_CornerLockChanged;
			m_edit.ChkSize();
			this.MinimumSize = new Size(0, 0);
			this.MaximumSize = new Size(0, 0);
			this.Size = new Size(this.Width, 48);
			this.MinimumSize = new Size(0, this.Height);
			this.MaximumSize = new Size(0, this.Height);
			this.Controls.Add(m_edit);
			InitializeComponent();
		}

		private void M_edit_CornerLockChanged(object sender, CornerLockChangedEventArgs e)
		{
			if (m_Layer != null)
			{
				PropError = false;
				m_Layer.CornerLock = e.Value;
			}
		}

		private void M_edit_SizeRootChanged(object sender, SizeRootChangedEventArgs e)
		{
			if(m_Layer!=null)
			{
				PropError = false;
				m_Layer.SizeRoot = e.Value;
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
			if(this.Height!= m_edit.Height)
			{
				this.Size = new Size(this.Width, m_edit.Height);
			}
			this.Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
	}
}
