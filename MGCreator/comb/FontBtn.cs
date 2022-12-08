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
	public partial class FontBtn : Button
	{
		public class ValueChangedEventArgs : EventArgs
		{
			public Font Value;
			public ValueChangedEventArgs(Font v)
			{
				Value = v;
			}
		}
		public delegate void ValueChangedHandler(object sender, ValueChangedEventArgs e);
		public event ValueChangedHandler? ValueChanged;
		protected virtual void OnValueChanged(ValueChangedEventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		protected Font m_Value = new Font("System",12);
		[Category("_MG")]
		public Font Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value = value;
				this.Text = m_Value.Name;
				OnValueChanged(new ValueChangedEventArgs(m_Value));

				this.Invalidate();
			}
		}
		public FontBtn()
		{
			m_Value = new Font(this.Font.Name, this.Font.Size, this.Font.Style);
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			this.Text = m_Value.Name;
			InitializeComponent();
			this.SetStyle(
ControlStyles.DoubleBuffer |
//ControlStyles.UserPaint |
//ControlStyles.AllPaintingInWmPaint |
//ControlStyles.SupportsTransparentBackColor |
ControlStyles.UserMouse |
ControlStyles.Selectable,
true);
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			FontDialog dlg = new FontDialog();
			dlg.Font = m_Value;
			if(dlg.ShowDialog()== DialogResult.OK)
			{
				m_Value = dlg.Font;
				this.Text = m_Value.Name;
				OnValueChanged(new ValueChangedEventArgs(m_Value));
			}
		}
	}
}
