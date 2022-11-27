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
	public class PosChangedEventArgs : EventArgs
	{
		Point Pos = new Point(0, 0);
		public PosChangedEventArgs(int x, int y)
		{
			Pos = new Point(x, y);
		}
		public PosChangedEventArgs(Point p)
		{
			Pos = p;
		}
	}
	public partial class EditPosition : Edit
	{
		public new readonly MGStyle MGStyle = MGStyle.ALL;
		// ****************************************************************************
		public delegate void PosChangedHandler(object sender, PosChangedEventArgs e);
		public event PosChangedHandler? PosChanged;
		protected virtual void OnPosChanged(PosChangedEventArgs e)
		{
			if(_EventFLag==false) return;
			if (PosChanged != null)
			{
				PosChanged(this, e);
			}
		}
		// ****************************************************************************
		protected override void SetControl(MGControl? c)
		{
			m_control = c;
			if (m_control != null)
			{
				SetPoint(m_control.Location);
				m_control.LocationChanged += M_control_LocationChanged;
				this.Invalidate();
			}
		}
		// ****************************************************************************
		private void M_control_LocationChanged(object? sender, EventArgs e)
		{
			if (m_control != null)
			{
				SetPoint(m_control.Location);
			}
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
				return new Point((int)m_edit1.Value, (int)m_edit2.Value);
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
			_EventFLag = false;
			bool b = false;

			if (m_edit1.ValueInt != pnt.X)
			{
				m_edit1.Value = pnt.X;
				b = true;
			}
			if (m_edit2.ValueInt != pnt.Y)
			{
				m_edit2.Value = pnt.Y;
				b = true;
			}
			_EventFLag = true;
			if (b)
			{
				OnPosChanged(new PosChangedEventArgs(Point));
			}


		}
		// ****************************************************************************
		public void SetControlLocation(Point p)
		{
			if (m_control == null) return;
			if(_EventFLag == false) return;
			_EventFLag = false;
			if(m_control.Location !=p)
			{
				m_control.Location = p;
			}
			_EventFLag = true;
		}
		// ****************************************************************************
		protected PropEdit m_edit1 = new PropEdit();
		protected PropEdit m_edit2 = new PropEdit();
		protected PosSetGrid m_PosSetGrid = new PosSetGrid();
		// ****************************************************************************
		public EditPosition()
		{
			Caption = "Position";
			// ********************
			m_edit1.Name = "x";
			m_edit1.AutoSize = false;
			m_edit1.Location = new Point(60, 0);
			m_edit1.Size = new Size(80, 20);
			m_edit1.IsLeftRightMode = true;
			m_edit1.IsIntMode = true;
			m_edit1.ValueMin = -32000;
			m_edit1.ValueMax = 32000;
			m_edit1.PropChanged += M_edit_PropChanged; 
			// ********************
			m_edit2.Name = "y";
			m_edit2.AutoSize = false;
			m_edit2.Location = new Point(140, 0);
			m_edit2.Size = new Size(80, 20);
			m_edit2.IsLeftRightMode = false;
			m_edit2.IsIntMode = true;
			m_edit2.ValueMin = -32000;
			m_edit2.ValueMax = 32000;
			m_edit2.PropChanged += M_edit_PropChanged; ;
			// ********************
			m_PosSetGrid.Name = "g";
			m_PosSetGrid.AutoSize = false;
			m_PosSetGrid.Location = new Point(220, 0);
			m_PosSetGrid.Size = new Size(20, 20);
			m_PosSetGrid.Visible = true;
			m_PosSetGrid.PosSeted += M_PosSetGrid_PosSeted;
			this.Controls.Add(m_edit1);
			this.Controls.Add(m_edit2);
			this.Controls.Add(m_PosSetGrid);
			InitializeComponent();
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

		private void M_edit_PropChanged(object sender, PropChangedEventArgs e)
		{
			SetControlLocation(Point);
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public void ChkSize()
		{
			this.SuspendLayout();
			int w = (this.Width - m_CaptionWidth - m_PosSetGrid.Width) / 2;
			m_edit1.Width = w;
			m_edit2.Width = w;
			m_edit1.Location = new Point(m_CaptionWidth, 0);
			m_edit2.Location = new Point(m_CaptionWidth + w, 0);
			m_PosSetGrid.Location = new Point(m_CaptionWidth + w * 2, 0);
			this.ResumeLayout();
			this.Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
		/*
		public bool IsShowResizeType
		{
			get { return m_resizeGrid.Visible; }
			set { m_resizeGrid.Visible = value; this.Invalidate(); }
		}
		public ReSizeType ReSizeType
		{
			get { return m_resizeGrid.ReSizeType; }
			set { m_resizeGrid.ReSizeType = value; }
		}
		*/
	}
}
