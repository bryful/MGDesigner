using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MGCreator
{
	public partial class FileBtn : Button
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
		private string m_FileName = "";
		public string FileName
		{
			get { return m_FileName; }
			set 
			{
				m_FileName = value;
				this.Text = Path.GetFileName(m_FileName);
			}
		}
		public FileBtn()
		{
			InitializeComponent();
		}
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "*.png|*.png|*.*|*.*";
			if(m_FileName != "")
			{
				ofd.InitialDirectory = Path.GetDirectoryName(m_FileName);
				ofd.FileName = Path.GetFileName(m_FileName);
			}
			if(ofd.ShowDialog() == DialogResult.OK)
			{
				m_FileName = ofd.FileName;
				this.Text = Path.GetFileName(m_FileName);
				OnValueChanged(new ValueChangedEventArgs(m_FileName));
			}
		}
	}
}
