using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public class BoundsChangedEventArgs : EventArgs
	{
		Rectangle Bounds = new Rectangle(0, 0, 0, 0);
		public BoundsChangedEventArgs(Rectangle r)
		{
			Bounds = r;
		}
	}
	public partial class EditControlPoint : Edit
	{
		public new readonly MGStyle ShowMGStyle = MGStyle.ALL;
		protected Rectangle m_Bounds = new Rectangle(0, 0, 0, 0);
		// ****************************************************************************
		public delegate void BoundsChangedHandler(object sender, BoundsChangedEventArgs e);
		public event BoundsChangedHandler? BoundsChanged;
		protected virtual void OnBoundsChanged(BoundsChangedEventArgs e)
		{
			if(_EventFLag==false) return;
			if (BoundsChanged != null)
			{
				BoundsChanged(this, e);
			}
		}

		[Category("_MG")]
		public new MGForm? MGForm
		{
			get { return m_MGForm; }
			set
			{
				m_MGForm = value;
				if (m_MGForm != null)
				{
					m_control = m_MGForm.TargetControl;
					GetValeuFromControl();
					m_MGForm.TargetChanged += M_MGForm_TargetChanged;
					if(m_control != null)
					{
						m_control.LocationChanged += M_control_LocationChanged;
					}
				}
			}
		}

		private void M_MGForm_TargetChanged(object sender, TargetChangedEventArgs e)
		{
			if (m_MGForm != null)
			{
				m_control = e.Control;
				if (m_control != null)
				{
					m_control.LocationChanged += M_control_LocationChanged;
					GetValeuFromControl();
				}
			}
		}


		private void M_control_LocationChanged(object? sender, EventArgs e)
		{
			GetValeuFromControl();
		}
		protected override void GetValeuFromControl()
		{
			if (m_control != null)
			{
				m_Bounds = m_control.Bounds;
				SetValue(m_control.Location);
			}
		}
		protected override void SetValeuToControl()
		{
			if (m_control == null) return;
			_EventFLag = false;
			m_control.Bounds = m_Bounds;
			_EventFLag = true;

		}
		public void SetControlLocation(Point p)
		{
			if (m_control == null) return;
			if (_EventFLag == false) return;
			_EventFLag = false;

			if (m_control.ControlPos != ControlPos.None) return;

			if (m_control.Location != p)
			{
				m_control.Location = p;
			}
			_EventFLag = true;
		}       
		// ****************************************************************************
		public void SetPoint(Point p)
		{
			SetValue(p);
		}
		[Category("_MG")]
		public Point Point
		{
			get
			{
				return m_posEdit.Value;
			}
			set
			{
				SetValue(value);
			}
		}
		// ****************************************************************************
		public void SetValue(Point pnt)
		{
			if (_EventFLag == false) return;
			if(m_posEdit.Value != pnt)
			{
				_EventFLag = false;
				m_posEdit.Value = pnt;
				_EventFLag = true;
				this.Invalidate();
			}


		}
		// ****************************************************************************
		
		// ****************************************************************************
		protected PosEdit m_posEdit = new PosEdit();
		protected PosSetGrid m_PosSetGrid = new PosSetGrid();
		// ****************************************************************************
		public EditControlPoint()
		{
			this.ForeColor = Color.LightGray;
			this.BackColor = Color.Black;
			Caption = "Position";
			// ********************
			m_posEdit.Name = "x";
			m_posEdit.AutoSize = false;
			m_posEdit.Location = new Point(60, 0);
			m_posEdit.Size = new Size(160, 20);
			m_posEdit.ValueChanged += M_posEdit_ValueChanged; 

			// ********************
			m_PosSetGrid.Name = "g";
			m_PosSetGrid.AutoSize = false;
			m_PosSetGrid.Location = new Point(220, 0);
			m_PosSetGrid.Size = new Size(20, 20);
			m_PosSetGrid.Visible = true;
			m_PosSetGrid.PosSeted += M_PosSetGrid_PosSeted;
			this.Controls.Add(m_posEdit);
			this.Controls.Add(m_PosSetGrid);
			InitializeComponent();
		}

		private void M_posEdit_ValueChanged(object sender, PosEdit.ValueChangedEventArgs e)
		{
			SetControlLocation(Point);
		}

		private void M_PosSetGrid_PosSeted(object sender, PosSetEventArgs e)
		{

			if ((m_MGForm==null)||(m_control == null)) return;
			Point p;
			int x; int y;
			switch(e.PosSet)
			{
				case PosSet.TopLeft:
					p = new Point(0, 0);
					break;
				case PosSet.Top:
					x = (m_MGForm.Width / 2)-(m_control.Width/2);
					p = new Point(x, 0);
					break;
				case PosSet.TopRight:
					x = (m_MGForm.Width) - (m_control.Width);
					p = new Point(x, 0);
					break;
				case PosSet.Right:
					x = (m_MGForm.Width) - (m_control.Width);
					y = (m_MGForm.Height / 2) - (m_control.Height / 2);
					p = new Point(x, y);
					break;
				case PosSet.BottomRight:
					x = (m_MGForm.Width) - (m_control.Width);
					y = (m_MGForm.Height) - (m_control.Height);
					p = new Point(x, y);
					break;
				case PosSet.Bottom:
					x = (m_MGForm.Width/2) - (m_control.Width / 2);
					y = (m_MGForm.Height) - (m_control.Height);
					p = new Point(x, y);
					break;
				case PosSet.BottomLeft:
					x = 0;
					y = (m_MGForm.Height) - (m_control.Height );
					p = new Point(x, y);
					break;
				case PosSet.Left:
					x = 0;
					y = (m_MGForm.Height/2) - (m_control.Height/2);
					p = new Point(x, y);
					break;
				case PosSet.Center:
				default:
					x = (m_MGForm.Width / 2) - (m_control.Width / 2);
					y = (m_MGForm.Height / 2) - (m_control.Height / 2);
					p = new Point(x, y);
					break;
			}
			m_control.Location = p;
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public void ChkSize()
		{
			this.SuspendLayout();
			int w = (this.Width - m_CaptionWidth - m_PosSetGrid.Width);
			m_posEdit.Width = w;
			m_posEdit.Location = new Point(m_CaptionWidth, 0);
			m_PosSetGrid.Location = new Point(m_CaptionWidth + w, 0);
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
