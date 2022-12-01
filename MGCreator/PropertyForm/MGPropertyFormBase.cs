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
	public partial class MGPropertyFormBase : MGToolForm
	{
		public MGPropertyFormBase()
		{
			InitializeComponent();
			mgPropertyPanelBase1.ForeColor = Color.LightGray;
		}
		public MGForm? MGForm
		{
			get { return mgPropertyPanelBase1.MGForm; }
			set { mgPropertyPanelBase1.MGForm = value; }
		}
		public void AddControls(List<Control> c, bool IsLayout = true)
		{
			mgPropertyPanelBase1.AddControls(c, IsLayout);
		}
	}
}
