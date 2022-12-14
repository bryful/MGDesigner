using System;
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

		const int DrawWidth = 40;
		private MGColorComb m_cmb = new MGColorComb();

		public MG_COL Value
		{
			get { return m_cmb.MGColors; }
			set { m_cmb.MGColors = value;this.Invalidate(); }
		}
		public EditMGColors()
		{
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			SetTargetType(typeof(MG_COL));
			Caption = "MG_Colors";
			m_cmb.Name = "cmb";
			m_cmb.AutoSize = false;
			m_cmb.Location = new Point(m_CaptionWidth, 0);
			m_cmb.Size = new Size(100, 20);
			m_cmb.SelectedIndexChanged += M_cmb_SelectedIndexChanged;
			this.Controls.Add(m_cmb);
			InitializeComponent();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
//Control2Styles.UserMouse|
//Control2Styles.Selectable,
true);
		}

		private void M_cmb_SelectedIndexChanged(object? sender, EventArgs e)
		{
			SetValeuToControl();
			this.Invalidate();
		}

		// **********************************************************
	
		// **********************************************************
		protected override void GetValeuFromControl()
		{
			if (m_Layer != null)
			{

				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					MG_COL? v = (MG_COL?)GetValueFromProp(m_PropName,typeof(MG_COL));
					if (v != null) m_cmb.MGColors = (MG_COL)v;
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
			if (m_Layer != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				SetValueToProp(m_PropName, (object)m_cmb.MGColors,typeof(MG_COL));
				this.Invalidate();
				_EventFLag = true;
			}
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			SolidBrush sb = new SolidBrush(this.ForeColor);
			Graphics g = pe.Graphics;
			Pen p = new Pen(Color.DimGray);
			p.Width = 1;
			try
			{
				bool IsT = (m_cmb.MGColors == MG_COL.Transparent);
				Rectangle r = new Rectangle(m_CaptionWidth + 2, 2, DrawWidth - 4, this.Height - 4);
				if (IsT==false)
				{
					if (m_MGForm != null)
					{
						sb.Color = m_MGForm.GetMGColors(m_cmb.MGColors);
					}
					g.FillRectangle(sb, r);
				}
				else
				{
					sb.Color= Color.Black;
					g.FillRectangle(sb, r);
					g.DrawRectangle(p, r);
					g.DrawLine(p, r.Left, r.Top, r.Right, r.Bottom);
					g.DrawLine(p, r.Left, r.Bottom, r.Right, r.Top);

				}

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
		/*
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			if (m_MGForm != null)
			{
				if (m_cmb.MGColors != MG_COLORS.Transparent)
				{
					if (m_MGForm.MGColorPicker(m_cmb.MGColors) )
					{
						this.Invalidate();
						m_MGForm.DrawAll();
					}
				}
			}
		}
		*/
	}
}
