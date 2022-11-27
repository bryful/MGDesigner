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
    public class MGStyleComb : ComboBox
    {
        private MGStyle m_MGStyle = MGStyle.None;
        public MGStyle MGStyle { get {return m_MGStyle;} }

		public MGStyleComb()
        {
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            DropDownStyle = ComboBoxStyle.DropDownList;
            Items.Clear();

            List<string> list = new List<string>();
            foreach(string s in Enum.GetNames(typeof(MGStyle)))
            {
                if ((s != "None") && (s != "ALL"))
                {
                    list.Add(s);
                }
			}
			Items.AddRange(list.ToArray());
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (SelectedIndex >= 0)
            {
				m_MGStyle =  (MGStyle)Enum.Parse(typeof(MGStyle), (string)this.Items[SelectedIndex]);
            }
            else
            {
                m_MGStyle = MGStyle.None;
            }
        }

    }
}
