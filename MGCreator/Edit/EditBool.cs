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
	public partial class EditBool : Edit
	{

		// ****************************************************************************
		protected bool m_BoolValue = false;
		protected override void GetValeuFromControl()
		{
			if (m_Layer != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					bool? b = (bool?)GetValueFromProp(m_PropName,typeof(bool));
					if (b != null)
					{
						m_BoolValue = (bool)b;
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
					SetValueToProp(m_PropName, m_BoolValue,typeof(bool));
				}
				finally
				{
					_EventFLag = true;
				}
			}
		}
		public EditBool()
		{
			SetTargetType(typeof(bool));
			Caption = "bool";
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(220, 20);
			this.MaximumSize = new Size(0, 20);
			InitializeComponent();
			ChkSize();
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			Pen p = new Pen(this.ForeColor);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Graphics g = pe.Graphics;
			try
			{
				Rectangle r = new Rectangle(m_CaptionWidth, 0, this.Width - m_CaptionWidth, this.Height);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				sb.Color = this.ForeColor;

				g.DrawString($"{m_BoolValue.ToString()}", this.Font, sb, r, sf);
			}
			finally
			{
				p.Dispose();
				sb.Dispose();
			}


		}
		public void ChkSize()
		{
			//this.SuspendLayout();
			//this.ResumeLayout();
			this.Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{ 
			if (e.X > m_CaptionWidth)
			{
				m_BoolValue = !m_BoolValue;
				this.Invalidate();
				SetValeuToControl();
			}
			base.OnMouseDown(e);
		}

	}
}
