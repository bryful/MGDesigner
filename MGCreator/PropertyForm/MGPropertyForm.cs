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
	public partial class MGPropertyForm : MGToolForm
	{
		public MGPropertyForm()
		{
			InitializeComponent();
			mgPropertyPanel1.ForeColor = Color.LightGray;
			try
			{
				mgPropertyPanel1.Bounds = new Rectangle(3, this.HeaderHeight, this.Width - 6, this.Height - HeaderHeight - this.FooterHeight);
			}
			catch
			{

			}
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			try
			{
				if (mgPropertyPanel1 != null)
				{
					mgPropertyPanel1.Bounds = new Rectangle(3, this.HeaderHeight, this.Width - 6, this.Height - HeaderHeight - 10);
				}
			}
			catch { }
		}
		public MGForm? MGForm
		{
			get { return mgPropertyPanel1.MGForm; }
			set { mgPropertyPanel1.MGForm = value; }
		}
		
		public void AddControls(List<Control> c, bool IsLayout = true)
		{
			mgPropertyPanel1.AddControls(c, IsLayout);
		}
	}
}
