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
		private Point MGFormPoint = new Point(-1, -1);
		private Point MGPropPoint = new Point(-1, -1);
		private Color[] m_MGColors = new Color[(int)MG_COLORS.Transparent];
		private MG_COLORS m_Back = MG_COLORS.Black;
		public MGForm? MGForm = null;
		public MGPropertyForm? MGPropertyForm = null;

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
				if (ok) MGFormPoint = p;
				p = pf.GetPoint("MGPropPoint", out ok);
				if (ok) MGPropPoint = p;
				ShowMGPropertyForm(false);
				JsonArray? mc = pf.Array("MGColors");
				if(mc!=null)
				{
					Color[]? a = MGForm.FormJsonToColors(mc);
					MessageBox.Show($"{a.ToString()}");
					if (a!=null)
					{
						m_MGColors = a;
					}
				}
				int v = pf.GetValueInt("Back", out ok);
				if(ok)
				{
					m_Back = (MG_COLORS)v;
				}

			}

		}
		// *******************************************************************************
		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);
			PrefFile pf = new PrefFile(this);
			pf.SetRect("ProjectBounds", this.Bounds);
			if (MGForm != null)
			{
				pf.SetPoint("MGFormPoint", MGForm.Location);
				pf.AddArray("MGColors", MGForm.MGColorsToJson());
				pf.SetValue("Back", (int)MGForm.Back);
			}
			if (MGPropertyForm != null)
			{
				pf.SetPoint("MGPropPoint", MGPropertyForm.Location);
			}
			pf.Save();
		}
		// *******************************************************************************
		public void ShowMGPropertyForm(bool isV=true)
		{
			if (MGForm == null) return;
			if (MGPropertyForm == null)
			{
				MGPropertyForm = new MGPropertyForm();
				MGPropertyForm.MGForm = MGForm;
				MGPropertyForm.StartPosition = FormStartPosition.Manual;
				if (MGPropPoint.X != -1)
				{

					MGPropertyForm.Location = MGPropPoint;
				}
				else
				{
					MGPropertyForm.Location = new Point(
						this.Left, 
						this.Bottom+5);
				}

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
		public void ShowMGForm()
		{
			if(MGForm==null)
			{
				MGFormSize dlg = new MGFormSize();
				dlg.StartPosition = FormStartPosition.Manual;
				dlg.Location = Cursor.Position;
				dlg.IsShowPosSet = false;
				MGForm = new MGForm();
				dlg.MGFrom = MGForm;
				dlg.Back = m_Back;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					MGForm.Size = dlg.FormSize;
					MGForm.MGProjectForm = this;
					
					MGForm.Back = dlg.Back;
					if (MGFormPoint.X != -1)
					{
						MGForm.Location = MGFormPoint;
					}
					else
					{
						MGForm.Location = new Point(this.Left + this.Width + 5, this.Top);
					}
					MGForm.SetColors(m_MGColors);
					layerlListBox1.SetMGForm(MGForm);
					MGForm.Layers.LayerAdded += Layers_LayerAdded;
					MGForm.Layers.LayerRemoved += Layers_LayerAdded;
					MGForm.Layers.LayerOrderChanged += Layers_LayerAdded;
					MGForm.Layers.TargetLayerChanged += Layers_TargetLayerChanged;



					MGForm.Show();
				}
				else
				{
					MGForm = null;
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
				MGForm.AddLayer(mgStyleComb1.MGStyle);
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
