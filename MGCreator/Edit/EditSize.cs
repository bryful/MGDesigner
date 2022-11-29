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
	public partial class EditSize : Edit
	{
		public new MGStyle ShowMGStyle = MGStyle.ALL;


		protected override void GetValeuFromControl()
		{
			if (m_control != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					Size? p = (Size?)GetValueFromProp(m_PropName, typeof(Size));
					if (p != null) m_sizeEdit.Value = (Size)p;
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
			if (m_control != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					SetValueToProp(m_PropName, m_sizeEdit.Value, typeof(Size));
				}
				finally
				{
					_EventFLag = true;
				}
			}
		}
		// ****************************************************************************
		[Category("_MG")]
		public Size Sizes
		{
			get
			{
				return m_sizeEdit.Value;
			}
			set
			{
				m_sizeEdit.Value = value;
				this.Invalidate();
			}
		}
		protected SizeEdit m_sizeEdit = new SizeEdit();
		public EditSize()
		{
			this.BackColor = Color.Black;
			this.ForeColor = Color.LightGray;

			Caption = "Size";
			PropName = "Size";
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(220, 20);
			this.MaximumSize = new Size(0, 20);
			m_sizeEdit.Name = "float";
			m_sizeEdit.AutoSize = false;
			m_sizeEdit.Location = new Point(m_CaptionWidth, 0);
			m_sizeEdit.Size = new Size(120, 20);
			m_sizeEdit.ValueChanged += M_sizeEdit_ValueChanged;
			this.Controls.Add(m_sizeEdit);
			InitializeComponent();
			ChkSize();
		}

		private void M_sizeEdit_ValueChanged(object sender, SizeEdit.ValueChangedEventArgs e)
		{
			SetValeuToControl();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
		public void ChkSize()
		{
			m_sizeEdit.Width = this.Width - m_CaptionWidth;
			m_sizeEdit.Location = new Point(m_CaptionWidth, 0);
			this.Invalidate();
		}
	}
}
