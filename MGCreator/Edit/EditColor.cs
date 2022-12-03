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

	public partial class EditColor : Edit
	{
		public delegate void ValueChangedHandler(object sender, EventArgs e);
		public event ValueChangedHandler? ValueChanged;
		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		protected override object? GetValueFromProp(string n, Type T)
		{
			PropError = true;
			object? result = null;
			if (m_MGForm == null) return null;
			var prop = m_MGForm.GetType().GetProperty(n);
			if (prop != null)
			{
				try
				{
					if (prop.PropertyType == T)
					{
						result = prop.GetValue(m_MGForm);
						PropError = false;
					}
				}
				catch
				{
					result = null;
				}

			}
			return result;
		}
		protected override bool SetValueToProp(string n, object v, Type T)
		{
			PropError = true;
			bool result = false;
			if (m_MGForm == null) return result;
			var prop = m_MGForm.GetType().GetProperty(n);
			if (prop != null)
			{
				try
				{
					if (prop.PropertyType == T)
					{
						prop.SetValue(m_MGForm, v);
						result = true;
						PropError = false;
					}

				}
				catch
				{
					result = false;
					MessageBox.Show("er");
				}
			}
			return result;
		}
		protected override void GetValeuFromControl()
		{
			if (m_MGForm != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					Color? b = (Color?)GetValueFromProp(m_PropName, typeof(Color));
					if (b != null)
					{
						m_edit.Value = (Color)b;
						PropError = false;
					}

				}
				finally
				{
					this.Invalidate();
					_EventFLag = true;
				}
			}
		}
		public void ReGet()
		{
			GetValeuFromControl();
		}
		protected override void SetValeuToControl()
		{
			if (m_MGForm != null)
			{
				if (_EventFLag == false) return;
				_EventFLag = false;
				try
				{
					SetValueToProp(m_PropName, m_edit.Value, typeof(Color));
					PropError = false;
				}
				finally
				{
					_EventFLag = true;
				}
			}
		}
		[Category("_MG")]
		public Color Color
		{
			get
			{
				return m_edit.Value;
			}
			set
			{
				m_edit.Value = value;
				this.Invalidate();
			}
		}
		private ColorEdit m_edit = new ColorEdit(); 
		public EditColor()
		{
			m_TargetType = typeof(Color);
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(220, 20);
			this.MaximumSize = new Size(0, 20);
			m_edit.Name = "colorEdit";
			m_edit.Location = new Point(m_CaptionWidth, 0);
			m_edit.Size = new Size(this.Width - m_CaptionWidth, this.Height);
			m_edit.ValueChanged += M_edit_ValueChanged;
			Caption = "Color";
			this.Controls.Add(m_edit);
			InitializeComponent();
			ChkSize();
		}

		private void M_edit_ValueChanged(object sender, ColorEdit.ValueChangedEventArgs e)
		{
			SetValeuToControl();
			OnValueChanged(EventArgs.Empty);
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
		public void ChkSize()
		{
			m_edit.Width = this.Width - m_CaptionWidth;
			m_edit.Location = new Point(m_CaptionWidth, 0);
			this.Invalidate();
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			GetValeuFromControl();
		}
	}
}
