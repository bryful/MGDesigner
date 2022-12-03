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
		public MGProjectForm? MGProjectForm = null;
	

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


			menu.Items.Add(MGColorsSettingMenu);
			menu.Items.Add(new ToolStripSeparator());
			menu.Items.Add(MGPropMenu);
			menu.Items.Add(MGFormSizeMenu);
			menu.Items.Add(new ToolStripSeparator());
			menu.Items.Add(QuitMenu);
			menu.Show(this,x,y);
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
			if (MGProjectForm != null)
			{
				MGProjectForm.ShowMGPropertyForm();
			}
		}

		private void MGListMenu_Click(object? sender, EventArgs e)
		{
			if(MGProjectForm != null)
			{
				MGProjectForm.Activate();
				MGProjectForm.Focus();
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
						DrawMGLayer(g, lyr,sb,p);
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
			jn.SetValueSize("Size", this.Size);
			jn.SetValue("Back", (int)m_Back);
			jn.SetValue("Layers", Layers.ToJson());

			return jn.Obj;
		}
	}
}
