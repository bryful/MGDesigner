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
	public partial class MGItemListForm : MGBaseForm
	{
		private MGForm? m_MGForm = null;
		public MGForm? MGForm
		{
			get { return m_MGForm; }
			set 
			{
				m_MGForm = value;
				if(m_MGForm != null)
				{
					controlListBox1.SetControls(m_MGForm.Controls);
					m_MGForm.ControlAdded += M_MGForm_ControlCHanged;
					m_MGForm.ControlRemoved += M_MGForm_ControlCHanged;
					m_MGForm.ControlOrderChanged += M_MGForm_ControlCHanged;
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
		}
	}
}
