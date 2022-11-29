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
		public MGProjectForm? MGProjectForm = null;
		private ContextMenuStrip m_Menu = new ContextMenuStrip();
		private int m_TargetIndex = -1;
		private int TargetIndex
		{
			get { return m_TargetIndex; }
			set
			{
				SetTargetIndex(value);
			}
		}
		public void SetTargetIndex(int value,bool IsEvent=true)
		{
			if (value < -1) value = -1;
			if (m_TargetIndex != value)
			{
				m_TargetIndex = value;
				if (IsEvent)
				{
					TargetChangedEventArgs ret;
					if ((value >= 0) && (value < this.Controls.Count))
					{
						ret = new TargetChangedEventArgs(value, (MGControl)this.Controls[value]);
					}
					else
					{
						ret = new TargetChangedEventArgs(-1, null);
					}
					OnTargetChanged(ret);
				}
			}
		}


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
		private MG_COLORS m_Back = MG_COLORS.Black;
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

			ToolStripMenuItem MGPropMenu = new ToolStripMenuItem();
			MGPropMenu.Name = "MGPropMenu";
			MGPropMenu.Text = "Show MGProp";
			MGPropMenu.Click += MGPropMenu_Click;

			m_Menu.Items.Add(MGPropMenu);
			m_Menu.Items.Add(QuitMenu);
			this.ContextMenuStrip = m_Menu;
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
					if (c is MGControl)
					{
						((MGControl)c).ChkOffScr();
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
						if (c is MGControl)
						{
							DrawControl(g, (MGControl)c);
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
		private void DrawControl(Graphics g, MGControl mc)
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
