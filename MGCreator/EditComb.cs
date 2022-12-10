using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public partial class EditComb : Edit
	{
		private bool _EventFlag = false;
		public class ValueChangedEventArgs : EventArgs
		{
			public int Value = -1;
			public string TagName = "";
			public ValueChangedEventArgs(int v,object s)
			{
				Value = v;
				if ((s!=null)&&(s is string))
				{
					TagName = (string)s;
				}
			}
		}
		public delegate void ValueChangedHandler(object sender, ValueChangedEventArgs e);
		public event ValueChangedHandler? ValueChanged;
		protected virtual void OnValueChanged(ValueChangedEventArgs e)
		{
			if ((ValueChanged != null)&&(_EventFlag))
			{
				ValueChanged(this, e);
			}
		}
		// **********************************************************
		protected override void GetValeuFromControl()
		{
			object? o = (object?)GetValueFromProp(m_PropName, typeof(object));
			if ((o != null)&&( o is object))
			{
				Value = (object)o;

			}
		}       // **********************************************************
		protected override void SetValeuToControl()
		{
			SetValueToProp(m_PropName, (object)m_comb.SelectedIndex, typeof(int));
		}
		// **********************************************************
		public object? Value
		{
			get 
			{
				return (object?)m_comb.SelectedIndex;
			}
			set 
			{
				if((value!=null)&&(value is int))
				{

					if(((int)value>=0)&&((int)value <m_comb.Items.Count))
					{
						if(m_comb.SelectedIndex != (int)value)
						{
							m_comb.SelectedIndex = (int)value;
							OnValueChanged(new ValueChangedEventArgs(m_comb.SelectedIndex, m_comb.Items[m_comb.SelectedIndex]));
						}
					}
				}
			}
		}
		
		public void SetItems(string[] ss)
		{
			if (ss.Length>0)
			{
				m_comb.Items.Clear();
				m_comb.Items.AddRange(ss);
				if (m_comb.Items.Count > 0)
				{
					_EventFlag = false;
					m_comb.SelectedIndex = 0;
					_EventFlag = true;
				}
			}
		}
		protected ComboBox m_comb = new ComboBox();
		public EditComb()
		{
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			Caption = "Comb";
			m_PropName = "object";
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(180, 20);
			this.MaximumSize = new Size(0, 20);
			m_comb.DropDownStyle = ComboBoxStyle.DropDownList;
			m_comb.Name = "EditFont";
			m_comb.AutoSize = false;
			m_comb.Location = new Point(m_CaptionWidth, 0);
			m_comb.Size = new Size(80, 20);
			m_comb.SelectedIndexChanged += M_comb_SelectedIndexChanged;
			this.Controls.Add(m_comb);
			InitializeComponent();
			ChkSize();
		}

		private void M_comb_SelectedIndexChanged(object? sender, EventArgs e)
		{
			SetValeuToControl();
			if(m_comb.SelectedIndex >= 0)
			{
				OnValueChanged(new ValueChangedEventArgs(m_comb.SelectedIndex, m_comb.Items[m_comb.SelectedIndex]));
			}
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public void ChkSize()
		{
			this.SuspendLayout();
			int w = (this.Width - m_CaptionWidth);
			m_comb.Width = w;
			m_comb.Location = new Point(m_CaptionWidth, 0);
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
