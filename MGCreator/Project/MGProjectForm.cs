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
				JsonArray? mc = pf.Array("MGColors");
				if(mc!=null)
				{
					Color[]? a = MGForm.FormJsonToColors(mc);
					//MessageBox.Show($"{a.ToString()}");
					if (a!=null)
					{
						pp.MGColors = a;
					}
				}
				int v = pf.GetValueInt("Back", out ok);
				if(ok)
				{
					pp.Back = (MG_COLORS)v;
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
				pf.AddArray("MGColors", pp.MGForm.MGColorsToJson());
				pf.SetValue("Back", (int)pp.MGForm.Back);
			}
			if (pp.MGPropertyForm != null)
			{
				pf.SetPoint("MGPropPoint", pp.MGPropertyForm.Location);
			}
			pf.Save();
		}


	}
}
