﻿using System;
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
	public partial class EditNumber : Edit
	{
		protected override void GetValeuFromControl()
		{
			if (m_control != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					double? b = (double?)GetValueFromProp(m_PropName,typeof(double));
					if (b != null)
					{
						m_edit1.Value = (double)b;
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
			if (m_control != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					SetValueToProp(m_PropName, m_edit1.Value,typeof(double));
				}
				finally
				{
					_EventFLag = true;
				}
			}
		}
		public double ValueMax
		{
			get { return m_edit1.ValueMax; }
			set { m_edit1.ValueMax = value; }
		}
		public double ValueMin
		{
			get { return m_edit1.ValueMin; }
			set { m_edit1.ValueMin = value; }
		}
		public double Value
		{
			get { return m_edit1.Value; }
			set { m_edit1.Value = value; }
		}
		public bool IsINt
		{
			get { return m_edit1.IsIntMode; }
			set { m_edit1.IsIntMode = value; }
		}

		protected PropEdit m_edit1 = new PropEdit();
		public EditNumber()
		{
			Caption = "float";
			m_PropName = "LineWidth";
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(220, 20);
			this.MaximumSize = new Size(0, 20);
			m_edit1.Name = "float";
			m_edit1.AutoSize = false;
			m_edit1.Location = new Point(m_CaptionWidth, 0);
			m_edit1.Size = new Size(80, 20);
			m_edit1.IsLeftRightMode = true;
			m_edit1.IsIntMode = false;
			m_edit1.ValueMin = -32000;
			m_edit1.ValueMax = 32000;
			m_edit1.PropChanged += M_edit_PropChanged;
			this.Controls.Add(m_edit1);
			InitializeComponent();
			ChkSize();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		private void M_edit_PropChanged(object sender, PropChangedEventArgs e)
		{
			SetValeuToControl();
		}
		public void ChkSize()
		{
			this.SuspendLayout();
			int w = (this.Width - m_CaptionWidth);
			m_edit1.Width = w;
			m_edit1.Location = new Point(m_CaptionWidth, 0);
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
