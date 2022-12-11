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
	public partial class EditFileName : Edit
	{
		protected override void GetValeuFromControl()
		{
			if (m_Layer != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					//Type? p = GetTypeFromProp(m_PropName);
					//if (p != null)
					{
						string? b = (string?)GetValueFromProp(m_PropName, typeof(string));
						if (b != null)
						{
							m_edit1.FileName = (string)b;
						}
					}
				}
				finally
				{
					this.Invalidate();
					_EventFLag = true;
				}
			}
		}
		protected override void SetValeuToControl()
		{
			if (m_Layer != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				Type? p = GetTypeFromProp(m_PropName);
				try
				{
					if (p != null)
					{
						SetValueToProp(m_PropName, m_edit1.FileName, p);
					}
				}
				finally
				{
					_EventFLag = true;
				}
			}
		}
		public string FileName
		{
			get { return m_edit1.FileName; }
			set { m_edit1.FileName = value; }
		}
		protected FileBtn m_edit1 = new FileBtn();
		public EditFileName()
		{
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			SetTargetType(typeof(string));
			Caption = "FileName";
			m_PropName = "FileName";
			this.Size = new Size(180, 30);
			this.MinimumSize = new Size(180, 30);
			this.MaximumSize = new Size(0, 30);
			m_edit1.Name = "EditFileName";
			m_edit1.AutoSize = false;
			m_edit1.Location = new Point(m_CaptionWidth, 0);
			m_edit1.Size = new Size(80, 30);
			m_edit1.ValueChanged += M_edit1_ValueChanged;
			this.Controls.Add(m_edit1);
			InitializeComponent();
			ChkSize();
		}

		private void M_edit1_ValueChanged(object sender, FileBtn.ValueChangedEventArgs e)
		{
			SetValeuToControl();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public void ChkSize()
		{
			this.SuspendLayout();
			int w = (this.Width - m_CaptionWidth);
			m_edit1.Width = w;
			m_edit1.Location = new Point(m_CaptionWidth, 0);
			this.ResumeLayout();
			this.Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
	}
}
