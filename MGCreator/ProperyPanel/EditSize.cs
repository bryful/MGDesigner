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
	public enum ReSizeType
	{
		TopLeft,
		Top,
		TopRight,
		Left,
		Center,
		Bottom,
		BottomLeft,
		Right,
		BottomRight
	}
	public partial class EditSize : EditBase
	{
		private MGCcontrol? m_control = null;

		private void SetControl(MGCcontrol? c)
		{
			m_control = c;
			if (m_control != null)
			{
				SetSzie(m_control.Size);
				m_control.SizeChanged += M_control_SizeChanged;
			}
		}

		private void M_control_SizeChanged(object? sender, EventArgs e)
		{
			if (m_control != null)
			{
				SetSzie(m_control.Size);
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
					SetControl(m_MGForm.ForcusControl);
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
		public void SetSzie(Size sz)
		{

			SetValue(new double[] { (double)sz.Width, (double)sz.Height });
		}
		// ****************************************************************************
		public void SetControlSize(Size sz)
		{
			if (m_control == null) return;
			Rectangle orct = m_control.Bounds;
			Size osz = m_control.Size;

			Rectangle rct = new Rectangle(orct.Left, orct.Top, osz.Width, osz.Height);
			int cx = 0;
			int cy = 0;
			switch (this.ReSizeType)
			{
				case ReSizeType.Center:
					cx = orct.Left + orct.Width / 2;
					cy = orct.Top + orct.Height / 2;
					rct = new Rectangle(cx - sz.Width / 2, cy - sz.Height / 2, sz.Width, sz.Height);
					break;
				case ReSizeType.Top:
					cx = orct.Left + orct.Width / 2;
					cy = orct.Top;
					rct = new Rectangle(cx - sz.Width / 2, cy, sz.Width, sz.Height);
					break;
				case ReSizeType.TopRight:
					cx = orct.Left + orct.Width;
					cy = orct.Top;
					rct = new Rectangle(cx - sz.Width, cy, sz.Width, sz.Height);
					break;
				case ReSizeType.BottomRight:
					cx = orct.Left + orct.Width;
					cy = orct.Top + orct.Height;
					rct = new Rectangle(cx - sz.Width, cy - sz.Height, sz.Width, sz.Height);
					break;
				case ReSizeType.Bottom:
					cx = orct.Left + orct.Width / 2;
					cy = orct.Top + orct.Height;
					rct = new Rectangle(cx - sz.Width / 2, cy - sz.Height, sz.Width, sz.Height);
					break;
				case ReSizeType.BottomLeft:
					cx = orct.Left;
					cy = orct.Top + orct.Height;
					rct = new Rectangle(cx, cy - sz.Height, sz.Width, sz.Height);
					break;
				case ReSizeType.TopLeft:
				default:
					rct = new Rectangle(orct.Left, orct.Top, sz.Width, sz.Height);
					break;
			}
			try
			{
				m_control.Bounds = rct;
			}
			catch
			{
				MessageBox.Show("er");
			}

		}
		protected override void OnEditChanged(EditChangedEventArgs e)
		{
			SetControlSize(new Size((int)e.X, (int)e.Y));
			//base.OnEditChanged(e);
		}
		public EditSize()
		{
			Caption = "Size";
			IntMode = true;
			this.IsShowResizeType = true;
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
	}
}
