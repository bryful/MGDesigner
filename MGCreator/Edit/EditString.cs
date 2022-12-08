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
	public partial class EditString : Edit
	{
		protected override void GetValeuFromControl()
		{
			if (m_Layer != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					Type? p = GetTypeFromProp(m_PropName);
					if (p != null)
					{
						string? b = (string?)GetValueFromProp(m_PropName, typeof(string));
						if (b != null)
						{
							m_edit1.Value = (string)b;
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
						SetValueToProp(m_PropName, m_edit1.Value, typeof(string));
					}
				}
				finally
				{
					_EventFLag = true;
				}
			}
		}
		public string Value
		{
			get { return m_edit1.Value; }
			set { m_edit1.Value = value; }
		}
		protected StringEdit m_edit1 = new StringEdit();
		public EditString()
		{
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			SetTargetType(typeof(string));
			Caption = "string";
			m_PropName = "Text";
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(180, 20);
			this.MaximumSize = new Size(0, 20);
			m_edit1.Name = "Text";
			m_edit1.AutoSize = false;
			m_edit1.Location = new Point(m_CaptionWidth, 0);
			m_edit1.Size = new Size(80, 20);
			m_edit1.ValueChanged += M_edit1_ValueChanged;
			this.Controls.Add(m_edit1);
			InitializeComponent();
			ChkSize();
		}

		private void M_edit1_ValueChanged(object sender, StringEdit.ValueChangedEventArgs e)
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
