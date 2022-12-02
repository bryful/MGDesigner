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
	public partial class EditPoint : Edit
	{
		protected override void GetValeuFromControl()
		{
			if (m_Layer != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					Point? b = (Point?)GetValueFromProp(m_PropName, typeof(Point));
					if (b != null)
					{
						m_edit.Value = (Point)b;
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
					SetValueToProp(m_PropName, m_edit.Value, typeof(Point));
				}
				finally
				{
					_EventFLag = true;
				}
			}
		}
		[Category("_MG")]
		public Point Point
		{
			get
			{
				return m_edit.Value;
			}
			set
			{
				m_edit.Value = value;
				this.Invalidate();
			}
		}
		private PosEdit m_edit = new PosEdit();
		public EditPoint()
		{
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(220, 20);
			this.MaximumSize = new Size(0, 20);
			m_edit.Name = "pointEdit";
			m_edit.Location = new Point(m_CaptionWidth, 0);
			m_edit.Size = new Size(this.Width - m_CaptionWidth, this.Height);
			Caption = "Point";
			this.Controls.Add(m_edit);
			InitializeComponent();
			ChkSize();
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
