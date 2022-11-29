﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public partial class EditMGColors : Edit
	{
		public new MGStyle ShowMGStyle = MGStyle.ALL;

		const int DrawWidth = 40;
		private MGColorComb m_cmb = new MGColorComb();

		public EditMGColors()
		{
			Caption = "MG_Colors";
			m_cmb.Name = "cmb";
			m_cmb.AutoSize = false;
			m_cmb.Location = new Point(m_CaptionWidth, 0);
			m_cmb.Size = new Size(100, 20);
			m_cmb.SelectedIndexChanged += M_cmb_SelectedIndexChanged;
			this.Controls.Add(m_cmb);
			InitializeComponent();
		}

		private void M_cmb_SelectedIndexChanged(object? sender, EventArgs e)
		{
			SetValeuToControl();
		}

		// **********************************************************
	
		// **********************************************************
		protected override void GetValeuFromControl()
		{
			if (m_control != null)
			{

				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					MG_COLORS? v = (MG_COLORS?)GetValueFromProp(m_PropName,typeof(MG_COLORS));
					if (v != null) m_cmb.MGColors = (MG_COLORS)v;
				}
				finally
				{
					_EventFLag = true;
					this.Invalidate();
				}
			}
		}
		protected override void SetValeuToControl()
		{
			if (m_control != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				SetValueToProp(m_PropName, (object)m_cmb.MGColors,typeof(MG_COLORS));
				_EventFLag = true;
			}
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			SolidBrush sb = new SolidBrush(this.ForeColor);
			Graphics g = pe.Graphics;
			try
			{
				if(m_MGForm!=null)
				{
					sb.Color = m_MGForm.GetColors(m_cmb.MGColors);
				}
				Rectangle r = new Rectangle(m_CaptionWidth + 2, 2, DrawWidth - 4, this.Height - 4);
				g.FillRectangle(sb, r);

			}
			finally
			{
				sb.Dispose();
			}

		}
		public void ChkSize()
		{
			int w = (this.Width - DrawWidth - m_CaptionWidth);
			m_cmb.Width = w;
			m_cmb.Location = new Point(m_CaptionWidth+DrawWidth, 0);
			this.Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}

	}
}