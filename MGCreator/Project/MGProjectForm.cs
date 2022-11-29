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
		public MGPropertyForm? MGPropertyForm = null;
		public void ShowMGPropertyForm(bool isV=true)
		{
			if (MGForm == null) return;
			if (MGPropertyForm == null)
			{
				MGPropertyForm = new MGPropertyForm();
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
				dlg.IsShowPosSet = false;
				if(dlg.ShowDialog() == DialogResult.OK)
				{
					MGForm = new MGForm();
					MGForm.Size = dlg.FormSize;
					MGForm.MGProjectForm = this;
					controlListBox1.SetMGForm(MGForm);
					MGForm.ControlAdded += M_MGForm_ControlCHanged;
					MGForm.ControlRemoved += M_MGForm_ControlCHanged;
					MGForm.ControlOrderChanged += M_MGForm_ControlCHanged;
					MGForm.ForcusChanged += M_MGForm_ForcusChanged;
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
		private void M_MGForm_ForcusChanged(object sender, ForcusChangedEventArgs e)
		{
			int idx = e.Index;
			if ((idx>=0)&&(idx<controlListBox1.Items.Count))
			{
				if(controlListBox1.SelectedIndex!=e.Index)
				{
					controlListBox1.SelectedIndex = e.Index;
				}
			}
		}

		private void M_MGForm_ControlCHanged(object? sender, ControlEventArgs e)
		{
			controlListBox1.ListUp();
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
