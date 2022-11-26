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
	public class EditChangedEventArgs : EventArgs
	{
		public double X = 0;
		public double Y = 0;
		public EditChangedEventArgs(double x0,double y0)
		{
			X = x0;
			Y = y0;
		}
	}
	public partial class EditBase : Control
	{
		private bool _EventFLag = true;
		public void StopEvent()
		{
			_EventFLag = false;
		}
		public void StartEvent()
		{
			_EventFLag = true;
		}
		public delegate void EditChangedHandler(object sender, EditChangedEventArgs e);
		public event EditChangedHandler? EditChanged;
		protected virtual void OnEditChanged(EditChangedEventArgs e)
		{
			if (EditChanged != null)
			{
				EditChanged(this, e);
			}
		}
		private int m_CaptionWidth = 60;
		[Category("_MG")]
		public int CaptionWidth
		{
			get { return m_CaptionWidth; }
			set
			{
				m_CaptionWidth = value;
				ChkSize();
			}
		}
		[Category("_MG")]
		public string Caption
		{
			get { return m_label.Text; }
			set { m_label.Text = value; }
		}
		[Category("_MG")]
		public bool IntMode
		{
			get { return m_edit1.IsIntMode; }
			set
			{
				m_edit1.IsIntMode = value;
				m_edit2.IsIntMode = value;
			}
		}
		[Category("_MG")]
		public double[] Values
		{
			get
			{
				double[] ret = new double[2];
				ret[0] = m_edit1.Value;
				ret[1] = m_edit2.Value;
				return ret;
			}
			set
			{
				SetValue(value);
			}
		}
		[Category("_MG")]
		public double ValueMax
		{
			get
			{
				return m_edit1.ValueMax;
			}
			set
			{
				m_edit1.ValueMax = value;
				m_edit2.ValueMax = value;
			}
		}
		[Category("_MG")]
		public double ValueMin
		{
			get
			{
				return m_edit1.ValueMin;
			}
			set
			{
				m_edit1.ValueMin = value;
				m_edit2.ValueMin = value;
			}
		}
		public void SetValue(double[] value)
		{
			if (_EventFLag == false) return;
			_EventFLag = false;
			bool b = false;
			if (value.Length > 0)
			{
				if(m_edit1.Value != value[0])
				{
					m_edit1.Value = value[0];
					b = true;
				}
			}
			if (value.Length > 1)
			{
				if (m_edit2.Value != value[1])
				{
					m_edit2.Value = value[1];
					b = true;
				}
			}
			if(b)
			{
				OnEditChanged(new EditChangedEventArgs(m_edit1.Value, m_edit2.Value));
			}
			_EventFLag=true;


		}
		protected Label m_label = new Label();
		protected PropEdit m_edit1 = new PropEdit();
		protected PropEdit m_edit2 = new PropEdit();
		protected ResizeTypeGrid m_resizeGrid = new ResizeTypeGrid();
		public EditBase()
		{
			this.Size = new Size(240, 20);
			this.MinimumSize = new Size(0, 20);
			this.MaximumSize = new Size(0, 20);
			// ********************
			m_label.Name = "Caption";
			m_label.Text = "ProcEdit";
			m_label.AutoSize = false;
			m_label.TextAlign = ContentAlignment.MiddleLeft;
			m_label.Location = new Point(0, 0);
			m_label.Size = new Size(60, 20);
			// ********************
			m_edit1.Name = "x";
			m_edit1.AutoSize = false;
			m_edit1.Location = new Point(60, 0);
			m_edit1.Size = new Size(80, 20);
			m_edit1.IsLeftRightMode = true;
			m_edit1.ProcChanged += M_edit1_ProcChanged;
			// ********************
			m_edit2.Name = "y";
			m_edit2.AutoSize = false;
			m_edit2.Location = new Point(140, 0);
			m_edit2.Size = new Size(80, 20);
			m_edit2.IsLeftRightMode = false;
			m_edit2.ProcChanged += M_edit1_ProcChanged;
			// ********************
			m_resizeGrid.Name = "y";
			m_resizeGrid.AutoSize = false;
			m_resizeGrid.Location = new Point(220, 0);
			m_resizeGrid.Size = new Size(20, 20);
			m_resizeGrid.Visible = false;
			this.Controls.Add(m_label);
			this.Controls.Add(m_edit1);
			this.Controls.Add(m_edit2);
			this.Controls.Add(m_resizeGrid);
			InitializeComponent();
			ChkSize();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);
		}

		private void M_edit1_ProcChanged(object sender, PropChangedEventArgs e)
		{
			OnEditChanged(new EditChangedEventArgs(m_edit1.Value, m_edit2.Value));
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public void ChkSize()
		{
			this.SuspendLayout();
			m_label.Width = m_CaptionWidth;
			m_label.Location = new Point(0, 0);
			int w = (this.Width - m_CaptionWidth-m_resizeGrid.Width) / 2;
			m_edit1.Width = w;
			m_edit2.Width = w;
			m_edit1.Location = new Point(m_CaptionWidth, 0);
			m_edit2.Location = new Point(m_CaptionWidth+w, 0);
			m_resizeGrid.Location = new Point(m_CaptionWidth + w*2, 0);
			this.ResumeLayout();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
		public bool IsShowResizeType
		{
			get { return m_resizeGrid.Visible; }
			set { m_resizeGrid.Visible = value;this.Invalidate(); }
		}
		public ReSizeType ReSizeType
		{
			get { return m_resizeGrid.ReSizeType; }
			set { m_resizeGrid.ReSizeType = value; }
		}
	}
}
