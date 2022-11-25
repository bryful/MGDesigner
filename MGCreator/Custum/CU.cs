using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGCreator.Custum
{
    public class CU
    {
        private Form? m_Form = null;
        [Category("_Controls")]
        public Form? Form
        {
            get { return m_Form; }
            set
            {
                m_Form = value;
            }
        }
        public CU(Form? form = null)
        {
            Form = form;
        }
        // *******************************************************************
        public string[] ListUp()
        {
            string[] ret = new string[0];
            if (m_Form == null) return ret;

            if (m_Form.Controls.Count > 0)
            {
                List<string> lst = new List<string>();
                foreach (Control c in m_Form.Controls)
                {
                    lst.Add(c.Name);
                }
            }
            return ret;

        }
        // *******************************************************************
        public void DeleteControl(int idx)
        {
            if (m_Form == null) return;
            if (idx >= 0 && idx < m_Form.Controls.Count)
            {
                m_Form.Controls[idx].Dispose();
                m_Form.Controls.RemoveAt(idx);
            }

        }
        // *******************************************************************
        public void ControlToDown(int idx)
        {
            if (m_Form == null) return;
            if (idx >= 1 && idx < m_Form.Controls.Count)
            {
                m_Form.Controls.SetChildIndex(
                    m_Form.Controls[idx],
                    idx - 1);
            }

        }
        public void ControlToUp(int idx)
        {
            if (m_Form == null) return;
            if (idx >= 0 && idx < m_Form.Controls.Count - 1)
            {
                m_Form.Controls.SetChildIndex(
                    m_Form.Controls[idx],
                    idx + 1);
            }

        }
    }
}
