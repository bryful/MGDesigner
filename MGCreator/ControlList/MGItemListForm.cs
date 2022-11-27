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
	public partial class MGItemListForm : MGToolForm
	{

		protected override void SetMGForm(MGForm? m)
		{
			m_MGForm = m;
			if (m_MGForm != null)
			{
				controlListBox1.SetMGForm(m_MGForm);
				m_MGForm.ControlAdded += M_MGForm_ControlCHanged;
				m_MGForm.ControlRemoved += M_MGForm_ControlCHanged;
				m_MGForm.ControlOrderChanged += M_MGForm_ControlCHanged;
				m_MGForm.ForcusChanged += M_MGForm_ForcusChanged;
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

		public MGItemListForm()
		{
			InitializeComponent();
			this.TopMost = true;
		}
	}
}
