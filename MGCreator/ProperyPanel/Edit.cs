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
	public partial class Edit : Control
	{
		// **********************************************************
		public readonly MGStyle MGStyle = MGStyle.ALL;
		public void SetIsShow(MGStyle style, bool isSHow)
		{
			if ((MGStyle & style) !=0 )
			{
				this.Visible = isSHow;
			}
			else
			{
				this.Visible = false;
			}
		}
		// **********************************************************
		protected bool _EventFLag = true;
		public void StopEvent()
		{
			_EventFLag = false;
		}
		public void StartEvent()
		{
			_EventFLag = true;
		}       
		// **********************************************************
		protected MGControl? m_control = null;
		protected virtual void SetControl(MGControl? c)
		{
			m_control = c;
			if (m_control != null)
			{
				this.Text = m_control.Name;
				this.Invalidate();
			}
		}
		protected MGForm? m_MGForm = null;
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
					m_MGForm.ForcusChanged += Control_ForcusChanged;
				}
			}
		}
		protected void Control_ForcusChanged(object sender, ForcusChangedEventArgs e)
		{
			if (m_MGForm == null) return;
			if (e.Index >= 0)
			{
				SetControl((MGControl)m_MGForm.Controls[e.Index]);
			}
		}
		// **********************************************************
		protected int m_CaptionWidth = 60;
		[Category("_MG")]
		public int CaptionWidth
		{
			get { return m_CaptionWidth; }
			set
			{
				m_CaptionWidth = value;
				this.Invalidate();
			}
		}
		// **********************************************************
		protected string m_Caption = "Caption";
		[Category("_MG")]
		public string Caption
		{
			get { return m_Caption; }
			set { m_Caption = value;this.Invalidate(); }
		}
		// **********************************************************
		public Edit()
		{
			this.Size = new Size(240, 20);
			this.MinimumSize = new Size(220, 20);
			this.MaximumSize = new Size(0, 20);
			InitializeComponent();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor |
ControlStyles.UserMouse |
ControlStyles.Selectable,
true);
		}
		protected Color m_ForcusColor = Color.DarkGray;

		// **********************************************************
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			SolidBrush sb = new SolidBrush(this.ForeColor);
			Graphics g = pe.Graphics;
			try
			{
				Rectangle r = new Rectangle(5, 2, m_CaptionWidth - 10, this.Height - 4);
				if (this.Focused)
				{
					sb.Color = m_ForcusColor;
					g.FillRectangle(sb, r);
				}
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				sb.Color= this.ForeColor;
				g.DrawString(m_Caption, this.Font, sb, r, sf);
			}
			finally
			{
				sb.Dispose();
			}
		}
		// **********************************************************
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.Invalidate();
		}

		// **********************************************************
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.Invalidate();
		}
	}
}
