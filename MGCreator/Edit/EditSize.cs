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
		Right,
		BottomLeft,
		Bottom,
		BottomRight
	}
	public partial class EditSize : Edit
	{
		public class CSizeChangedEventArgs : EventArgs
		{
			Size Size = new Size(0, 0);
			public CSizeChangedEventArgs(int x, int y)
			{
				Size = new Size(x, y);
			}
			public CSizeChangedEventArgs(Size sz)
			{
				Size = sz;
			}
		}
		public new readonly MGStyle ShowMGStyle = MGStyle.ALL;
		// ****************************************************************************
		public delegate void CSizeChangedHandler(object sender, CSizeChangedEventArgs e);
		public event CSizeChangedHandler? CSizaChanged;
		protected virtual void OnCSizeChanged(CSizeChangedEventArgs e)
		{
			if (_EventFLag == false) return;
			if (CSizaChanged != null)
			{
				CSizaChanged(this, e);
			}
		}
		// ****************************************************************************
		[Category("_MG")]
		public new MGForm? MGForm
		{
			get { return m_MGForm; }
			set
			{
				m_MGForm = value;
				if (m_MGForm != null)
				{
					m_control = m_MGForm.ForcusControl;
					GetValeuFromControl();
					m_MGForm.ForcusChanged += M_MGForm_ForcusChanged;
					if (m_control != null)
					{
						m_control.SizeChanged += M_control_SizeChanged;
					}
				}
			}
		}

		private void M_MGForm_ForcusChanged(object sender, ForcusChangedEventArgs e)
		{
			if (m_MGForm != null)
			{
				m_control = m_MGForm.ForcusControl;
				if (m_control != null)
				{
					m_control.SizeChanged += M_control_SizeChanged;
					GetValeuFromControl();
				}
			}
		}

		private void M_control_SizeChanged(object? sender, EventArgs e)
		{
			GetValeuFromControl();
		}

		// ****************************************************************************

		protected override void GetValeuFromControl()
		{
			if (m_control != null)
			{
				SetSzie(m_control.Size);
			}
		}
		protected override void SetValeuToControl()
		{
			if (m_control != null)
			{
				
			}
		}       
		// ****************************************************************************
		/*
		private void M_control_SizeChanged(object? sender, EventArgs e)
		{
			if (m_control != null)
			{
				SetSzie(m_control.Size);
			}
		}
		*/
		// ****************************************************************************
		protected DoubleEdit m_edit1 = new DoubleEdit();
		protected DoubleEdit m_edit2 = new DoubleEdit();
		protected ResizeTypeGrid m_resizeGrid = new ResizeTypeGrid();

		// ****************************************************************************
		public void SetSzie(Size sz)
		{
			SetValue(sz);
		}
		// ****************************************************************************
		[Category("_MG")]
		public Size CSize
		{
			get
			{
				return new Size((int)m_edit1.Value, (int)m_edit2.Value);
			}
			set
			{
				SetValue(value);
			}
		}       
		// ****************************************************************************
		public void SetValue(Size p)
		{
			if (_EventFLag == false) return;
			_EventFLag = false;
			bool b = false;

			if (m_edit1.ValueInt != p.Width)
			{
				m_edit1.Value = p.Width;
				b = true;
			}
			if (m_edit2.ValueInt != p.Height)
			{
				m_edit2.Value = p.Height;
				b = true;
			}
			_EventFLag = true;


		}      
		// ****************************************************************************
		public void SetControlSize(Size sz)
		{
			if (m_control == null) return;
			if (_EventFLag == false) return;
			_EventFLag = false;
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
			_EventFLag = true;


		}
		// ****************************************************************************
		public EditSize()
		{
			Caption = "Size";
			// ********************
			m_edit1.Name = "x";
			m_edit1.AutoSize = false;
			m_edit1.Location = new Point(60, 0);
			m_edit1.Size = new Size(80, 20);
			m_edit1.IsLeftRightMode = true;
			m_edit1.TargetType = TargetType.INT;
			m_edit1.ValueMin = 32;
			m_edit1.ValueMax = 32000;
			m_edit1.NumberChanged += M_edit_PropChanged;
			// ********************
			m_edit2.Name = "y";
			m_edit2.AutoSize = false;
			m_edit2.Location = new Point(140, 0);
			m_edit2.Size = new Size(80, 20);
			m_edit2.IsLeftRightMode = false;
			m_edit2.TargetType = TargetType.INT;
			m_edit2.ValueMin = 32;
			m_edit2.ValueMax = 32000;
			m_edit2.NumberChanged += M_edit_PropChanged; ;
			// ********************
			m_resizeGrid.Name = "g";
			m_resizeGrid.AutoSize = false;
			m_resizeGrid.Location = new Point(220, 0);
			m_resizeGrid.Size = new Size(20, 20);
			m_resizeGrid.Visible = true;
			this.Controls.Add(m_edit1);
			this.Controls.Add(m_edit2);
			this.Controls.Add(m_resizeGrid);
			InitializeComponent();
		}
		private void M_edit_PropChanged(object sender, NumberChangedEventArgs e)
		{
			OnCSizeChanged(new CSizeChangedEventArgs(CSize));
			SetControlSize(CSize);
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public void ChkSize()
		{
			this.SuspendLayout();
			int w = (this.Width - m_CaptionWidth - m_resizeGrid.Width) / 2;
			m_edit1.Width = w;
			m_edit2.Width = w;
			m_edit1.Location = new Point(m_CaptionWidth, 0);
			m_edit2.Location = new Point(m_CaptionWidth + w, 0);
			m_resizeGrid.Location = new Point(m_CaptionWidth + w * 2, 0);
			this.ResumeLayout();
			this.Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
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
	}
}
