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
    public partial class EditTriangleStyle : Edit
	{
		protected override void GetValeuFromControl()
		{
			if (m_Layer != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					TriangleStyle? b = (TriangleStyle?)GetValueFromProp(m_PropName, typeof(TriangleStyle));
					if (b != null)
					{
						m_edit.TrainglrStyle = (TriangleStyle)b;
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
				try
				{
					SetValueToProp(m_PropName, m_edit.TrainglrStyle, typeof(TriangleStyle));
				}
				finally
				{
					_EventFLag = true;
				}
			}
		}
		[Category("_MG")]
		public TriangleStyle TrainglrStyle
		{
			get
			{
				return m_edit.TrainglrStyle;
			}
			set
			{
				m_edit.TrainglrStyle = value;
				this.Invalidate();
			}
		}
		private TriangleStyleComb m_edit = new TriangleStyleComb();
		public EditTriangleStyle()
		{
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(220, 20);
			this.MaximumSize = new Size(0, 20);
			m_edit.Name = "TraiangleStyle";
			m_edit.Location = new Point(m_CaptionWidth, 0);
			m_edit.Size = new Size(this.Width - m_CaptionWidth, this.Height);
			m_edit.ValueChanged += M_edit_ValueChanged;
			SetCaptionPropName("TrainglrStyle");
			SetTargetType(typeof(TriangleStyle));
			this.Controls.Add(m_edit);
			InitializeComponent();
			ChkSize();

		}

		private void M_edit_ValueChanged(object sender, TriangleStyleComb.ValueChangedEventArgs e)
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
			m_edit.Width = this.Width - m_CaptionWidth;
			m_edit.Location = new Point(m_CaptionWidth, 0);
			this.Invalidate();
		}
	}
}
