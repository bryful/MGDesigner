using BRY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MGCreator
{
	public partial class MGForm : Form
	{
		public MGLayers Layers= new MGLayers();
		public MGProjectPanel? MGProjectPanel = null;
	

		public void ShowMGFromMenu(int x,int y)
		{
			ContextMenuStrip menu = new ContextMenuStrip();
			ToolStripMenuItem QuitMenu = new ToolStripMenuItem();
			QuitMenu.Name = "QuitMenu";
			QuitMenu.Text = "Quit";
			QuitMenu.Click += QuitMenu_Click;

			ToolStripMenuItem MGPropMenu = new ToolStripMenuItem();
			MGPropMenu.Name = "PropertyPanel";
			MGPropMenu.Text = "Property Panel";
			MGPropMenu.Click += MGPropMenu_Click;

			ToolStripMenuItem MGFormSizeMenu = new ToolStripMenuItem();
			MGFormSizeMenu.Name = "MGSize";
			MGFormSizeMenu.Text = "MGSize";
			MGFormSizeMenu.Click += MGFormSizeMenu_Click;

			ToolStripMenuItem MGColorsSettingMenu = new ToolStripMenuItem();
			MGColorsSettingMenu.Name = "MGColors";
			MGColorsSettingMenu.Text = "MGColors";
			MGColorsSettingMenu.Click += MGColorsSettingMenu_Click;

			ToolStripMenuItem ExportMenu = new ToolStripMenuItem();
			ExportMenu.Name = "Export";
			ExportMenu.Text = "Export Layers(png)";
			ExportMenu.Click += ExportMenu_Click;

			ToolStripMenuItem ExportMixMenu = new ToolStripMenuItem();
			ExportMixMenu.Name = "ExportMixed";
			ExportMixMenu.Text = "Export Mixed Layers(png)";
			ExportMixMenu.Click += ExportMixMenu_Click;

			ToolStripMenuItem OpenMenu = new ToolStripMenuItem();
			OpenMenu.Name = "Openjson";
			OpenMenu.Text = "Open jsonFile";
			OpenMenu.Click += OpenMenu_Click;	

			ToolStripMenuItem SaveMenu = new ToolStripMenuItem();
			SaveMenu.Name = "Savejson";
			SaveMenu.Text = "Save jsonFile";
			SaveMenu.Click += SaveMenu_Click;

			ToolStripMenuItem AntiMenu = new ToolStripMenuItem();
			AntiMenu.Name = "Anti-Aliasing";
			AntiMenu.Text = "Anti-Aliasing";
			AntiMenu.Checked = this.m_Anti;
			AntiMenu.Click += AntiMenu_Click;

			menu.Items.Add(AntiMenu);
			menu.Items.Add(new ToolStripSeparator());
			menu.Items.Add(OpenMenu);
			menu.Items.Add(SaveMenu);
			menu.Items.Add(new ToolStripSeparator());
			menu.Items.Add(MGPropMenu);
			menu.Items.Add(MGFormSizeMenu);
			menu.Items.Add(new ToolStripSeparator());
			menu.Items.Add(MGColorsSettingMenu);
			menu.Items.Add(new ToolStripSeparator());
			menu.Items.Add(ExportMenu);
			menu.Items.Add(ExportMixMenu);
			menu.Items.Add(new ToolStripSeparator());
			menu.Items.Add(QuitMenu);
			menu.Show(this,x,y);
		}

		private void OpenMenu_Click(object? sender, EventArgs e)
		{
			Load(Layers.LoadJsonFileDialog());
		}

		private void SaveMenu_Click(object? sender, EventArgs e)
		{
			Save(Layers.SaveJsonFileDialog());
		}

		private void AntiMenu_Click(object? sender, EventArgs e)
		{
			m_Anti = !m_Anti;
			DrawAll();
			this.Invalidate();
		}

		private void ExportMixMenu_Click(object? sender, EventArgs e)
		{
			Layers.ExportMix(Layers.SavePNGFileDialog());
		}

		private void ExportMenu_Click(object? sender, EventArgs e)
		{
			Layers.Export(Layers.SavePNGFileDialog());
		}

		private void MGColorsSettingMenu_Click(object? sender, EventArgs e)
		{
			ShowMGColorsSettings();
		}

		private void MGFormSizeMenu_Click(object? sender, EventArgs e)
		{
			Layers.SetFormSize();
		}

		private void MGPropMenu_Click(object? sender, EventArgs e)
		{
			if (MGProjectPanel != null)
			{
				MGProjectPanel.ShowMGPropertyForm();
			}
		}

		private void MGListMenu_Click(object? sender, EventArgs e)
		{
			if(MGProjectPanel != null)
			{
				if (MGProjectPanel is Form)
				{
					Form m = (Form)MGProjectPanel.Parent;

					m.Activate();
					MGProjectPanel.Focus();
				}
			}
		}


		private void QuitMenu_Click(object? sender, EventArgs e)
		{
			Application.Exit();
		}
		// ********************************************************************************
		public MGForm()
		{
			Layers.SetMGForm(this);
			SetMGForm();
			this.FormBorderStyle = FormBorderStyle.None;
			InitializeComponent();
			InitColor();
			//InitMenu();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
//ControlStyles.UserMouse |
//ControlStyles.Selectable
true);
			

		}
		// ********************************************************************************
		public void SetMGForm()
		{
			Layers.TargetLayerChanged += Layers_Changed;
			Layers.LayerAdded += Layers_LayerAdded;
			Layers.LayerRemoved += Layers_LayerAdded;
			Layers.LayerOrderChanged += Layers_LayerAdded;
		}

		private void Layers_LayerAdded(object sender, EventArgs e)
		{
			this.Invalidate();
		}

		private void Layers_Changed(object sender, MGLayers.TargetLayerChangedEventArgs e)
		{
			this.Invalidate();
		}

		// ********************************************************************************
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

		}
		//*******************************************************************************
		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);

		}
		//*******************************************************************************
		public MGLayer? TargetLayer { get { return Layers.TargetLayer; } }
		public int FindLayer(string n)
		{
			return Layers.IndexOf(n);
		}
		public void DrawAll()
		{
			if ((Layers != null) && (Layers.Count > 0))
			{
				for (int i = Layers.Count - 1; i >= 0; i--)
				{
					if (Layers[i] != null)
					{
						Layers[i].ChkOffScr();
					}
				}

			}
		}
		//*******************************************************************************
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Graphics g = pe.Graphics;
			if (m_Anti == false)
			{
				g.SmoothingMode = SmoothingMode.AntiAlias;
			}
			SolidBrush sb = new SolidBrush(Color.Transparent);
			Pen p = new Pen(this.ForeColor, 2);
			try
			{

				sb.Color = GetMGColors(m_Back);
				g.FillRectangle(sb, this.ClientRectangle);
				if((Layers!=null)&&(Layers.Count>0))
				{
					for (int i = Layers.Count - 1; i >= 0; i--)
					{
						if (Layers[i] == null) continue;
						MGLayer lyr = Layers[i];
						if(lyr.IsShow)DrawMGLayer(g, lyr,sb,p);
					}
					if(Layers.TargetIndex >=0)
					{
						MGLayer lyr = Layers[TargetIndex];
						if ((lyr != null)&&(lyr.IsFull==false))
						{
							Rectangle rr = new Rectangle(lyr.Left - 2, lyr.Top - 2, lyr.Width + 4, lyr.Height + 3);
							p.Color = Color.Yellow;
							p.DashStyle = DashStyle.Dash;
							p.Width = 2;
							g.DrawRectangle(p, rr);
							p.DashStyle = DashStyle.Solid;
						}
					}

				}
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}

		}

		// *********************************************************************************
		private void DrawMGLayer(Graphics g, MGLayer layer,SolidBrush sb , Pen p)
		{
			if (layer.IsFull)
			{
				layer.Draw(g, this.ClientRectangle, false);
			}
			else
			{
				g.DrawImage(layer.OffScr(), layer.Location);
				if (layer.IsMouseEnter)
				{
					sb.Color = Color.FromArgb(64,255, 0, 0);
					g.FillRectangle(sb, layer.Bounds);
				}
			}
		}
		// *********************************************************************************
		private bool ChkMouseDown(MouseEventArgs e)
		{
			bool ret = false;
			if(Layers.Count>0)
			{
				for(int i=0; i< Layers.Count;i++)
				{
					if (Layers[i] == null) continue;
					if (Layers[i].ChkMouseDown(e))
					{
						Layers.TargetIndex = i;
						ret = true;
						break;
					}
				}
			}
			return ret;
		}
		private bool ChkMouseMove(MouseEventArgs e)
		{
			bool ret = false;
			if (Layers.Count > 0)
			{
				for (int i = 0; i < Layers.Count; i++)
				{
					if (Layers[i] == null) continue;


					if (Layers[i].ChkMouseMove(e))
					{
						ret = true;
						break;
					}
				}
			}
			return ret;
		}
		private bool ChkMouseUp(MouseEventArgs e)
		{
			bool ret = false;
			if (Layers.Count > 0)
			{
				for (int i = 0; i < Layers.Count; i++)
				{
					if (Layers[i] == null) continue;
					if (Layers[i].ChkMouseUp(e))
					{
						ret = true;
						break;
					}
				}
			}
			return ret;
		}
		// *********************************************************************************
		private Point m_MD = new Point(0, 0);
		private int m_MD_Mode = 0;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if(ChkMouseDown(e))
			{
				this.Invalidate();
				if (e.Button== MouseButtons.Right)
				{
					Layers.ShowMenu(e.X, e.Y);
				}
			}
			else if (e.Button == MouseButtons.Left)
			{
				m_MD_Mode = 1;
				m_MD = e.Location;
			}
			else if (e.Button == MouseButtons.Right)
			{
				ShowMGFromMenu(e.X, e.Y);
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (ChkMouseMove(e))
			{
				this.Invalidate();
			}
			else if(e.Button == MouseButtons.Left)
			{
				int ax = e.X - m_MD.X;
				int ay = e.Y - m_MD.Y;
				if (m_MD_Mode == 1)
				{
					this.Location = new Point(ax + this.Left, ay + this.Top);
				}
			}
			base.OnMouseMove(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{

			if (ChkMouseUp(e))
			{
				this.Invalidate();
			}
			else if (m_MD_Mode != 0)
			{
				m_MD_Mode = 0;
				this.Invalidate();
			}
			base.OnMouseUp(e);
		}

		public bool MGColorPicker(MG_COLORS mg)
		{
			bool ret = false;
			if (mg == MG_COLORS.Transparent) return ret;
			Color? c = GetMGColors(mg, 100);
			if (c==null) return ret;

			ColorDialog dlg = new ColorDialog();
			dlg.Color = (Color)c;
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				SetMG_Colors(mg, dlg.Color);
				this.DrawAll();
				ret = true;
			}
			return ret;
		}
		// ************************************************************
		private void ChkMGLyers()
		{
			Layers.ChkLayers();
		}

		// ************************************************************
		public void AddLayer(MGStyle mG)
		{
			Layers.AddLayer(mG);
		}

		// ************************************************************
		public void ShowMGColorsSettings()
		{
			MGColorsSetting dlg = new MGColorsSetting(this);
			PushColors();
			dlg.Location = new Point(this.Left+100,this.Top+100);
			if(dlg.ShowDialog() == DialogResult.OK)
			{

			}
			else
			{
				PopColors();
			}
		}
		public JsonObject ToJson()
		{
			MGj jn = new MGj(new JsonObject());
			jn.SetValue("Header", "MG");
			jn.SetValueSize("Size", this.Size);
			jn.SetValue("Back", (int)m_Back);
			jn.SetValue("Layers", Layers.ToJson());
			return jn.Obj;
		}
		public bool Save(string? p)
		{
			MGj mj = new MGj(ToJson());
			return mj.Save(p);
		}
		public bool Load(string? p)
		{
			bool ret = false;
			if(File.Exists(p)==false) return ret;
			MGj mj = new MGj();
			JsonObject? obj = mj.Load(p); 
			if(obj == null) return ret;
			return FromJson(obj);
		}
		public bool FromJson(JsonObject? jo)
		{
			bool ret = false;
			if(jo==null) return ret;	
			MGj jn = new MGj(jo);

			string n = "";
			if (jn.GetStr("Header", ref n) == false)
			{
				return ret;
			}
			else
			{
				if (n != "MG") return ret;
			}
			Size sz = new Size(0, 0);
			if (jn.GetSize("Size", ref sz) == false) return ret;
			MG_COLORS c = MG_COLORS.Black;
			if (jn.GetMGColor("Back", ref c) == false) return ret;
			JsonArray? ja = jn.GetArray("Layers");
			if (ja == null) return ret;
			Layers.Clear();
			this.Size = sz;
			this.m_Back = c;
			ret = Layers.FromJson(ja);
			return ret;
		}
	}
}
