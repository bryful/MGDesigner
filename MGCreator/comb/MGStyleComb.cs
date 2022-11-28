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
        private MGStyle[] m_MGStyleValues = new MGStyle[0];

        [Category("_MG")]
        public MGStyle MGStyle 
        {
            get 
            {
                if(SelectedIndex>=0)
                {
					return m_MGStyleValues[SelectedIndex];

				}else
                {
                    return MGStyle.None;
                }
			}
            set
            {
                if (this.Items.Count <= 0) return;
                int idx = 0;
                for(int i=0;i< m_MGStyleValues.Length;i++)
                {
                    if(m_MGStyleValues[i]==value)
                    {
                        idx = i;
                        break;
                    }
                }
                if(SelectedIndex != idx)
                {
					SelectedIndex = idx;
				}
			}
        }

        public MGStyleComb()
        {
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            DropDownStyle = ComboBoxStyle.DropDownList;
            Items.Clear();

            List<string> list = new List<string>();
			List<MGStyle> lista = new List<MGStyle>();
			string[] MGStyleStrings = Enum.GetNames(typeof(MGStyle));
			MGStyle[] k = (MGStyle[])Enum.GetValues(typeof(MGStyle));

            for(int i = 0; i < MGStyleStrings.Length; i++)
            {
                string s = MGStyleStrings[i];
				if (s != "None" && s != "ALL")
				{
					list.Add(s);
                    lista.Add(k[i]);
				}
			}
            Items.AddRange(list.ToArray());
            m_MGStyleValues = lista.ToArray();
            SelectedIndex = 0;
		}
        protected override void OnSelectedItemChanged(EventArgs e)
        {
            base.OnSelectedItemChanged(e);
        }

    }
}
