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
    public class ControlListBox : ListBox
    {
        private ControlCollection? m_controls = null;

        public void SetControls(ControlCollection cc)
        {
            m_controls = cc;
            ListUp();
        }


        private Button? m_AddBtn = null;
        [Category("_MG")]
        public Button? AddBtn
        {
            get { return m_AddBtn; }
            set
            {
                m_AddBtn = value;
                if (m_AddBtn != null)
                {
                    m_AddBtn.Click += M_AddBtn_Click;
                }
            }
        }

        private void M_AddBtn_Click(object? sender, EventArgs e)
        {
            ListUp();
        }

        // ****************************************************************
        public ControlListBox()
        {
        }
        // ****************************************************************
        public void ListUp()
        {
            //MessageBox.Show(m_cu.ListUp().ToString());
            Items.Clear();
            if (m_controls != null)
            {
                if (m_controls.Count > 0)
                {
                    int si = -1;
                    List<string> lst = new List<string>();
                    int idx = 0;
                    foreach (Control c in m_controls)
                    {
                        if (c.Focused) si = idx;
                        lst.Add(c.Name);
                        idx++;
                    }
                    Items.AddRange(lst.ToArray());
                    if (si >= 0)
                    {
                        SelectedIndex = si;
                    }
                }
            }
        }
        // ****************************************************************
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (m_controls != null)
            {
                if (SelectedIndex >= 0)
                {
                    m_controls[SelectedIndex].Focus();
                }
            }
        }
        // ****************************************************************
        public void DeleteControl()
        {
            //m_cu.DeleteControl(this.SelectedIndex);
        }
        // ****************************************************************
        public void ControlToUp()
        {
            //m_cu.ControlToUp(this.SelectedIndex);
        }
        // ****************************************************************
        public void ControlToDown()
        {
            //m_cu.ControlToDown(this.SelectedIndex);
        }
        // ****************************************************************
    }
}
