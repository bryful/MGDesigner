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
	public partial class EditPosition : EditBase
	{
		private MGCcontrol? m_control = null;
		private void SetControl(MGCcontrol? c)
		{
			m_control = c;
			if (m_control != null)
			{
				SetPoint(m_control.Location);
				m_control.LocationChanged += M_cntrol_LocationChanged;
			}
		}
		private MGForm? m_MGForm = null;
		[Category("_MG")]
		public MGForm? MGForm
		{
			get { return m_MGForm; }
			set
			{
				m_MGForm = value;
				if (m_MGForm != null)
				{
					SetControl( m_MGForm.ForcusControl);
					m_MGForm.ForcusChanged += M_MGForm_ForcusChanged;
				}
			}
		}
		private void M_MGForm_ForcusChanged(object sender, MGForm.ForcusChangedEventArgs e)
		{
			if (m_MGForm == null) return;
			if (e.Index >= 0)
			{
				SetControl((MGCcontrol)m_MGForm.Controls[e.Index]);
			}
		}
		// ****************************************************************************
		public void SetPoint(Point p)
		{
			SetValue(new double[] { (double)p.X, (double)p.Y });
		}
		// ****************************************************************************
		private void M_cntrol_LocationChanged(object? sender, EventArgs e)
		{
			if (m_control != null)
			{
				SetPoint(m_control.Location);
			}
		}
		// ****************************************************************************
		protected override void OnEditChanged(EditChangedEventArgs e)
		{
			if(m_control != null)
			{
				m_control.Location = new Point((int)e.X, (int)e.Y);
			}
			//base.OnEditChanged(e);
		}

		public EditPosition()
		{
			Caption = "Position";
			IntMode = true;
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
	}
}
