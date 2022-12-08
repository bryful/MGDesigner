using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MGCreator
{
	public partial class FontComb : ComboBox
	{
		public class ValueChangedEventArgs : EventArgs
		{
			public string Value;
			public ValueChangedEventArgs(string v)
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
		public string FontName
		{
			get
			{
				string ret = "";
				if (SelectedIndex >= 0)
				{
					ret = Items[SelectedIndex].ToString();
				}
				return ret;
			}
			set
			{
				if (this.Items.Count == 0) return;

				int idx = -1;
				string s = "";
				for (int i = 0; i < this.Items.Count; i++)
				{
					s = this.Items[i].ToString();
					if (s == value)
					{
						idx = i;
						break;
					}
				}
				if (idx < 0) idx = 0;
				if (SelectedIndex != idx)
				{
					SelectedIndex = idx;
					if (s != "")
					{
						this.Font = new Font(s, this.Font.Size, this.Font.Style);
						OnValueChanged(new ValueChangedEventArgs(s));
					}
				}
			}

		}
		public FontComb()
		{
			InitializeComponent();
		}

		protected override void InitLayout()
		{
			base.InitLayout();
			DropDownStyle = ComboBoxStyle.DropDownList;
			Items.Clear();
			InstalledFontCollection ifc =new InstalledFontCollection();
			FontFamily[] ffs = ifc.Families;
			List<string> list = new List<string>();
			foreach (FontFamily f in ffs)
			{
				list.Add(f.Name);
			}
			Items.AddRange(list.ToArray());
			FontName = this.Font.Name;
		}
	}
}
