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
	public partial class MGColorsSetting : MGToolForm
	{
		public MGForm m_MGForm;
		public MGForm MGForm
		{
			get { return m_MGForm; }
			set 
			{
				if (value == null) return;
				m_MGForm = value; 
				CreateUI();
			}
		}
		public MGColorsSetting(MGForm m)
		{
			m_MGForm = m;
			InitializeComponent();
			CreateUI();
			//panel1.SizeChanged += Panel1_SizeChanged;
		}

		private void Panel1_SizeChanged(object? sender, EventArgs e)
		{
			if(panel1.Controls.Count>0)
			{
				foreach(Control c in panel1.Controls)
				{
					c.Width = panel1.ClientSize.Width-40;
					c.Invalidate();
				}
			}
			this.Invalidate();
		}

		protected override void OnClosed(EventArgs e)
		{
			if (this.DialogResult == DialogResult.Cancel)
			{
				m_MGForm.PopColors();
			}
			base.OnClosed(e);
		}
		private void CreateUI()
		{
			if(m_MGForm == null)return;
			panel1.Controls.Clear();
			string[] caps = m_MGForm.MGColorsName();
			//Color[] cols = m_MGForm.Colors();
			int idx = 0;
			foreach (string cap in caps)
			{
				EditColor ec = new EditColor();
				ec.Name = $"ec{idx}";
				ec.MGForm = this.m_MGForm;
				ec.Name = cap;
				//ec.Color = cols[idx];
				ec.ValueChanged += Ec_ValueChanged;
				ec.SetCaptionPropName(cap, typeof(Color));
				ec.ReGet();
				ec.Location = new Point(0, ec.Height * idx);
				ec.Size = new Size(panel1.ClientSize.Width-40, ec.Height);
				//ec.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				idx++;
				this.panel1.Controls.Add(ec);
			}
			panel1.Controls[0].Focus();
		}
		private void Ec_ValueChanged(object sender, EventArgs e)
		{
			if (m_MGForm != null) m_MGForm.DrawAll();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}

}
