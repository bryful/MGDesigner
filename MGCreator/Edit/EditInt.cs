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
	public partial class EditInt : Edit
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
						int? b = (int?)GetValueFromProp(m_PropName, typeof(int));
						if (b != null)
						{
							m_edit1.Value = (int)b;
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
						SetValueToProp(m_PropName, m_edit1.Value, p);
					}
				}
				finally
				{
					_EventFLag = true;
				}
			}
		}
		public int ValueMax
		{
			get { return m_edit1.ValueMax; }
			set { m_edit1.ValueMax = value; }
		}
		public int ValueMin
		{
			get { return m_edit1.ValueMin; }
			set { m_edit1.ValueMin = value; }
		}
		public int Value
		{
			get { return m_edit1.Value; }
			set { m_edit1.Value = value; }
		}
		public void SetValueMinMax(int n, int m)
		{
			m_edit1.ValueMax = m;
			m_edit1.ValueMin = n;
		}
		protected IntEdit m_edit1 = new IntEdit();
		public EditInt()
		{
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			SetTargetType(typeof(int));
			Caption = "int";
			m_PropName = "LineWidth";
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(180, 20);
			this.MaximumSize = new Size(0, 20);
			m_edit1.Name = "int";
			m_edit1.AutoSize = false;
			m_edit1.Location = new Point(m_CaptionWidth, 0);
			m_edit1.Size = new Size(80, 20);
			m_edit1.ValueMin = -32000;
			m_edit1.ValueMax = 32000;
			m_edit1.ValueChanged += M_edit1_ValueChanged;
			this.Controls.Add(m_edit1);
			InitializeComponent();
			ChkSize();
		}

		private void M_edit1_ValueChanged(object sender, IntEdit.ValueChangedEventArgs e)
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
