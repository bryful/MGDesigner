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
	public partial class MGProjectForm : MGToolForm
	{
		// *******************************************************************************
		public MGProjectForm()
		{
			InitializeComponent();
			ShowMGPropertyForm(false);
		}
		// *******************************************************************************
		public MGPropertyFormBase? MGPropertyForm = null;
		public void ShowMGPropertyForm(bool isV=true)
		{
			if (MGForm == null) return;
			if (MGPropertyForm == null)
			{
				MGPropertyForm = new MGPropertyFormBase();
				MGPropertyForm.MGForm = MGForm;

				if (isV)
				{
					MGPropertyForm.Show();
					MGPropertyForm.Visible = true;
				}
				else
				{
					MGPropertyForm.Visible = false;
				}

			}
				else
			{
				if (MGPropertyForm.Visible == false)
				{
					MGPropertyForm.Visible = true;
					MGPropertyForm.Activate();
					MGPropertyForm.Focus();
				}
				else
				{
					MGPropertyForm.Visible = false;
				}
			}
		}
		// *******************************************************************************
		public MGForm? MGForm = null;
		public void ShowMGForm()
		{
			if(MGForm==null)
			{
				MGFormSize dlg = new MGFormSize();
				dlg.StartPosition = FormStartPosition.Manual;
				dlg.Location = Cursor.Position;
				dlg.IsShowPosSet = false;
				if(dlg.ShowDialog() == DialogResult.OK)
				{
					MGForm = new MGForm();
					MGForm.Size = dlg.FormSize;
					MGForm.MGProjectForm = this;
					MGForm.Location = new Point(this.Left + this.Width + 5, this.Top);


					layerlListBox1.SetMGForm(MGForm);
					MGForm.Layers.LayerAdded += Layers_LayerAdded;
					MGForm.Layers.LayerRemoved += Layers_LayerAdded;
					MGForm.Layers.LayerOrderChanged += Layers_LayerAdded;
					MGForm.Layers.TargetLayerChanged += Layers_TargetLayerChanged;



					MGForm.Show();
				}

			}
			else
			{
				if(MGForm.Visible==false)
				{
					MGForm.Visible = true;
				}
				MGForm.Activate();
				MGForm.Focus();
			}
		}

		private void Layers_TargetLayerChanged(object sender, MGLayers.TargetLayerChangedEventArgs e)
		{
			if (e.Layer == null) return;
			int idx = e.Index;
			if ((idx >= 0) && (idx < layerlListBox1.Items.Count))
			{
				if (layerlListBox1.SelectedIndex != e.Index)
				{
					layerlListBox1.SelectedIndex = e.Index;
				}
			}
		}

		private void Layers_LayerAdded(object sender, EventArgs e)
		{
			layerlListBox1.ListUp();
		}



		private void btnNewMG_Click(object sender, EventArgs e)
		{
			ShowMGForm();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (MGForm != null)
			{
				MGForm.AddControl(mgStyleComb1.MGStyle);
			}
		}

		private void btnPropForm_Click(object sender, EventArgs e)
		{
			ShowMGPropertyForm();
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			MGFormSize dlg = new MGFormSize();

			if(dlg.ShowDialog()==DialogResult.OK)
			{

			}
			dlg.Dispose();
		}
	}
}
