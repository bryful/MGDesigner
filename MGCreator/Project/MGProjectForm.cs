using BRY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public partial class MGProjectForm : MGToolForm
	{
		public void ShowMGPropertyForm(bool isV = true)
		{
			pp.ShowMGPropertyForm(isV);
		}
		public void ShowMGForm()
		{
			pp.ShowMGForm();
		}
		// *******************************************************************************
		public MGProjectForm()
		{
			InitializeComponent();
		}
		// *******************************************************************************
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			PrefFile pf = new PrefFile(this);
			if(pf.Load())
			{
				bool ok = false;
				Rectangle r = pf.GetRect("ProjectBounds", out ok);
				if (ok)
				{
					if (PrefFile.ScreenIn(r))
					{
						this.Bounds = r;
					}
				}
				Point p = pf.GetPoint("MGFormPoint", out ok);
				if (ok) pp.MGFormPoint = p;
				p = pf.GetPoint("MGPropPoint", out ok);
				if (ok) pp.MGPropPoint = p;
				string cp = Path.Combine(pf.FileDirectory, "MGColors.json");
				Color[]? cols = MGColor.OpenMGColors(cp);
				if(cols != null)
				{
					pp.MGColors = cols;
				}

				int v = pf.GetValueInt("Back", out ok);
				if(ok)
				{
					pp.Back = (MG_COL)v;
				}
				Size szz = pf.GetSize("MGSize", out ok);
				if(ok)
				{
					pp.MGSize = szz;
				}
				ShowMGForm();
				ShowMGPropertyForm(false);

			}

		}
		// *******************************************************************************
		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);
			PrefFile pf = new PrefFile(this);
			pf.SetRect("ProjectBounds", this.Bounds);
			if (pp.MGForm != null)
			{
				pf.SetPoint("MGFormPoint", pp.MGForm.Location);
				pf.SetValue("Back", (int)pp.MGForm.Back);
				pf.SetSize("MGSize", pp.MGForm.Size);

				string p = Path.Combine(pf.FileDirectory, "MGColors.json");
				if (MGColor.SaveMGColors(p, pp.MGForm.Colors())) { }
			}
			if (pp.MGPropertyForm != null)
			{
				pf.SetPoint("MGPropPoint", pp.MGPropertyForm.Location);
			}
			pf.Save();
		}


	}
}
