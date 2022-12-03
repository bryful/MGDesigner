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
		protected bool PropError = false;
		// **********************************************************
		
		protected virtual Type? GetTypeFromProp(string n)
		{
			Type? ret = null;
			if (m_Layer == null) return null;
			var prop = m_Layer.GetType().GetProperty(n);
			if(prop != null)
			{
				ret = prop.PropertyType;
				//MessageBox.Show(ret.ToString());
			}
			return ret;
		}
		
		protected virtual object? GetValueFromProp(string n,Type T)
		{
			PropError = true;
			object? result = null;
			if (m_Layer == null) return null;
			var prop = m_Layer.GetType().GetProperty(n);
			if (prop != null)
			{
				try
				{
					if (prop.PropertyType == T)
					{
						result = prop.GetValue(m_Layer);
						PropError = false;
					}
				}
				catch
				{
					result=null;
				}

			}
			return result;
		}
		protected virtual bool SetValueToProp(string n, object v,Type T)
		{
			PropError = true;
			bool result = false;
			if (m_Layer == null) return result;
			var prop = m_Layer.GetType().GetProperty(n);
			if (prop != null)
			{
				try
				{
					if (prop.PropertyType == T)
					{
						prop.SetValue(m_Layer, v);
						result = true;
						PropError = false;
					}

				}
				catch
				{
					result = false;
				}
			}
			return result;
		}
		// **********************************************************
		protected virtual void GetValeuFromControl()
		{
			Object? o = GetValueFromProp(m_PropName, m_TargetType);
			if(o!=null)
			{
				if(o is string)
				{
					this.Text = (string)o;
				}

			}
		}
		// **********************************************************
		protected virtual void SetValeuToControl()
		{
			SetValueToProp(m_PropName, (object)this.Text,m_TargetType);
		}
		// **********************************************************
		protected virtual void SetMGForm(MGForm? m)
		{
			m_MGForm = m;
			if (m_MGForm != null)
			{
				m_Layer = m_MGForm.TargetLayer;
				m_MGForm.Layers.TargetLayerChanged += MGLayes_TargetLayerChanged;
				GetValeuFromControl();
			}

		}       
		// **********************************************************
		protected string m_PropName = "Text";
		[Category("_MG")]
		public string PropName
		{
			get { return m_PropName; }
		}
		protected Type m_TargetType = typeof(string);
		public Type TargetType
		{
			get { return m_TargetType; }
		}
		// **********************************************************
		public void SetCaptionPropName(string c, string p,Type t)
		{
			m_Caption = c;
			m_PropName = p;
			m_TargetType = t;
			//GetValeuFromControl();
		}
		// **********************************************************
		public void SetCaptionPropName(string c, Type t)
		{
			SetCaptionPropName(c, c,t);
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
		protected MGLayer? m_Layer = null;
		protected MGForm? m_MGForm = null;
		[Category("_MG")]
		public MGForm? MGForm
		{
			get { return m_MGForm; }
			set
			{
				SetMGForm(value);
			}
		}

		private void MGLayes_TargetLayerChanged(object sender, MGLayers.TargetLayerChangedEventArgs e)
		{
			if (m_MGForm == null) return;
			m_Layer = e.Layer;
			if (m_Layer != null)
			{
				GetValueFromProp(m_PropName, m_TargetType);
			}
		}


		

		// **********************************************************
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
			this.ForeColor = Color.LightGray;
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
