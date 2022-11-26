using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public partial class MGForm : MGBaseForm
	{

		private ContextMenuStrip m_Menu = new ContextMenuStrip();

		private string[] ControlsName()
		{
			string[] ret = new string[this.Controls.Count];
			if (this.Controls.Count > 0)
			{
				int idx = 0;
				foreach (Control c in this.Controls)
				{
					ret[idx] = c.Name;
					idx++;
				}
			}
			return ret;

		}
		private bool m_Anti = false;
		[Category("_MG")]
		public bool Anti
		{
			get { return m_Anti; }
			set
			{
				m_Anti = value;
				//DrawAll();
			}
		}
		private MG_COLORS m_Back = MG_COLORS.BackColor;
		[Category("_MG")]
		public MG_COLORS Back
		{
			get { return m_Back; }
			set
			{
				m_Back = value;
				this.Invalidate();
			}
		}
		private void InitMenu()
		{
			ToolStripMenuItem QuitMenu = new ToolStripMenuItem();
			QuitMenu.Name = "QuitMenu";
			QuitMenu.Text = "Quit";
			QuitMenu.Click += QuitMenu_Click;

			ToolStripMenuItem AddMenu = new ToolStripMenuItem();
			AddMenu.Name = "AddMenu";
			AddMenu.Text = "Add";
			AddMenu.Click += AddMenu_Click;

			ToolStripMenuItem MGListMenu = new ToolStripMenuItem();
			MGListMenu.Name = "MGListMenu";
			MGListMenu.Text = "Show MGList";
			MGListMenu.Click += MGListMenu_Click;

			ToolStripMenuItem MGPropMenu = new ToolStripMenuItem();
			MGPropMenu.Name = "MGPropMenu";
			MGPropMenu.Text = "Show MGProp";
			MGPropMenu.Click += MGPropMenu_Click;

			m_Menu.Items.Add(AddMenu);
			m_Menu.Items.Add(MGListMenu);
			m_Menu.Items.Add(MGPropMenu);
			m_Menu.Items.Add(QuitMenu);
			this.ContextMenuStrip = m_Menu;
		}

		private void MGPropMenu_Click(object? sender, EventArgs e)
		{
			MGPropertyForm fm = new MGPropertyForm();
			fm.MGForm = this;
			fm.Show();
		}

		private void MGListMenu_Click(object? sender, EventArgs e)
		{
			MGItemListForm fm = new MGItemListForm();
			fm.MGForm = this;
			fm.Show();
		}

		private void AddMenu_Click(object? sender, EventArgs e)
		{
			AddControl();
		}

		private void QuitMenu_Click(object? sender, EventArgs e)
		{
			Application.Exit();
		}

		public MGForm()
		{
			InitializeComponent();
			InitColor();
			InitMenu();
			
		}
		public int FindControl(string n)
		{
			return Controls.IndexOfKey(n);
		}
		public void DrawAll()
		{
			if (this.Controls.Count > 0)
			{
				foreach (var c in this.Controls)
				{
					if(c is MGCcontrol)
					{
						((MGCcontrol)c).ChkOffScr();
					}
				}
				this.Invalidate();
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

				sb.Color = GetColors(m_Back);
				g.FillRectangle(sb, this.ClientRectangle);
				if (this.Controls.Count > 0)
				{
					foreach (var c in this.Controls)
					{
						if (c is MGCcontrol)
						{
							DrawControl(g, (MGCcontrol)c);
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
		private void DrawControl(Graphics g, MGCcontrol mc)
		{
			GraphicsPath path = new GraphicsPath();
			path.AddRectangle(this.ClientRectangle);
			Region region = new Region(path);
			g.SetClip(region, CombineMode.Replace);
			if (mc.IsFull)
			{
				mc.Draw(g, this.ClientRectangle, false);
			}
			else
			{
				g.DrawImage(mc.OffScr, mc.Location);
			}
		}
		// *********************************************************************************
	}
}
