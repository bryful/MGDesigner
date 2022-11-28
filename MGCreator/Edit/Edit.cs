using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public partial class Edit : Control
	{
		private bool PropError = false;
		public new bool Visible
		{
			get { return base.Visible; }
			set
			{
				if ((ShowMGStyle & m_MGStyle) == 0)
				{
					base.Visible = false;
				}
				else
				{
					base.Visible = value;
				}
			}
		}
		public readonly MGStyle ShowMGStyle = MGStyle.ALL;

		private MGStyle m_MGStyle = MGStyle.ALL;
		public void SetMGStyle(MGStyle style)
		{
			m_MGStyle = style;
			bool _IsShow = true;
			if(this.Parent != null)
			{
				_IsShow = ((PropertyPanel)this.Parent).IsOpen;
			}
			this.Visible = _IsShow;
		}
		// **********************************************************
		/*
		protected virtual Type? GetTypeFromProp(string n)
		{
			Type? ret = null;
			if (m_control == null) return null;
			var prop = typeof(MGControl).GetProperty(n);
			if(prop != null)
			{
				ret = prop.PropertyType;
			}
			return ret;
		}
		*/
		protected virtual object? GetValueFromProp(string n,Type T)
		{
			PropError = true;
			object? result = null;
			if (m_control == null) return null;
			var prop = typeof(MGControl).GetProperty(n);
			if (prop != null)
			{
				if (prop.PropertyType == T)
				{
					result = prop.GetValue(m_control);
					PropError = false;
				}

			}
			return result;
		}
		protected bool SetValueToProp(string n, object v,Type T)
		{
			PropError = true;
			bool result = false;
			if (m_control == null) return result;
			var prop = typeof(MGControl).GetProperty(n);
			if (prop != null)
			{
				if (prop.PropertyType == T)
				{
					prop.SetValue(m_control, v);
					result = true;
					PropError = false;
				}
			}
			return result;
		}       
		// **********************************************************
		protected string m_PropName = "Fill";
		[Category("_MG")]
		public string PropName
		{
			get { return m_PropName; }
			set
			{
				m_PropName = value;
				GetValeuFromControl();
			}
		}       
		public void SetCaptionPropName(string c, string p)
		{
			m_Caption = c;
			m_PropName = p;
			GetValeuFromControl();
		}
		public void SetCaptionPropName(string c)
		{
			SetCaptionPropName(c, c);
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
					m_control = m_MGForm.ForcusControl;
					GetValeuFromControl();
					m_MGForm.ForcusChanged += Control_ForcusChanged;
				}
			}
		}
		protected void Control_ForcusChanged(object sender, ForcusChangedEventArgs e)
		{
			if (m_MGForm == null) return;
			m_MGForm.ForcusChanged -= Control_ForcusChanged;
			m_MGForm.ForcusChanged += Control_ForcusChanged;
			if (e.Index >= 0)
			{
				m_control = (MGControl)m_MGForm.Controls[e.Index];
				GetValeuFromControl();
			}
		}

		

		// **********************************************************
		protected virtual void GetValeuFromControl()
		{
			if(m_control != null)
			{
				this.Text = m_control.Name;
			}
		}
		protected virtual void SetValeuToControl()
		{
			if (m_control != null)
			{
				m_control.Name = this.Text;
			}
		}
		// **********************************************************
		protected int m_CaptionWidth = 90;
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
				if (PropError)
				{
					sb.Color = Color.Gray;
				}
				else
				{
					sb.Color = this.ForeColor;
				}
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
