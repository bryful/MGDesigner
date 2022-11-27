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
			this.IsColseBtn = true;
			InitializeComponent();
		}
		// *******************************************************************************
		public MGPropertyForm? MGPropertyForm = null;
		public void ShowMGPropertyForm()
		{
			if (MGForm == null) return;
			if (MGPropertyForm == null)
			{
				MGPropertyForm = new MGPropertyForm();
				MGPropertyForm.IsColseBtn = false;
				MGPropertyForm.MGForm = MGForm;
				MGPropertyForm.Show();
			}
			else
			{
				MGPropertyForm.Activate();
				MGPropertyForm.Focus();
			}
		}
		// *******************************************************************************
		public MGForm? MGForm = null;
		public void ShowMGForm()
		{
			if(MGForm==null)
			{
				MGForm = new MGForm();
				MGForm.MGProjectForm = this;
				controlListBox1.SetMGForm(MGForm);
				MGForm.ControlAdded += M_MGForm_ControlCHanged;
				MGForm.ControlRemoved += M_MGForm_ControlCHanged;
				MGForm.ControlOrderChanged += M_MGForm_ControlCHanged;
				MGForm.ForcusChanged += M_MGForm_ForcusChanged;
				MGForm.Show();
			}
			else
			{
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
	}
}
