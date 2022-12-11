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
	public partial class EditAlignment : Edit
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
						SizeRootType? b = (SizeRootType?)GetValueFromProp(m_PropName, typeof(SizeRootType));
						if (b != null)
						{
							m_edit1.SizeRoot = (SizeRootType)b;
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
						SetValueToProp(m_PropName, m_edit1.SizeRoot, typeof(SizeRootType));
					}
				}
				finally
				{
					_EventFLag = true;
				}
			}
		}
		public SizeRootType Value
		{
			get { return m_edit1.SizeRoot; }
			set { m_edit1.SizeRoot = value; }
		}
		protected SizeRootGrid m_edit1 = new SizeRootGrid();
		public EditAlignment()
		{
			m_edit1.IsShowSwitch = false;
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			SetTargetType(typeof(float));
			Caption = "Aligment";
			m_PropName = "Aligment";
			this.Size = new Size(180, 32);
			this.MinimumSize = new Size(180, 32);
			this.MaximumSize = new Size(0, 32);
			m_edit1.Name = "Aligment";
			m_edit1.AutoSize = false;
			m_edit1.Location = new Point(m_CaptionWidth, 0);
			m_edit1.Size = new Size(30, 32);
			m_edit1.SizeRootChanged += M_edit1_SizeRootChanged;
			this.Controls.Add(m_edit1);
			InitializeComponent();
			ChkSize();
		}

		private void M_edit1_SizeRootChanged(object sender, SizeRootChangedEventArgs e)
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
