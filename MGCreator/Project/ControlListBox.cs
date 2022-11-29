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
		private MGForm? m_MGForm = null;
		private ControlCollection? m_controls = null;

        public void SetMGForm(MGForm m)
        {
			m_MGForm=m;
            if(m_MGForm!=null)
            {
                m_controls = m_MGForm.Controls;
                m_MGForm.TargetChanged += M_MGForm_TargetChanged;
				ListUp(m_MGForm.TargetControl);
            }

		}

        private void M_MGForm_TargetChanged(object sender, TargetChangedEventArgs e)
        {
			ListUp(e.Control);
		}

        // ****************************************************************
        public ControlListBox()
        {
			this.SetStyle(
					ControlStyles.DoubleBuffer |
					ControlStyles.SupportsTransparentBackColor,
					true);
		}
        // ****************************************************************
        public void ListUp(MGControl? ctrl)
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
                        if ((c is MGControl) && (ctrl != null));
                        {
                            MGControl cc = (MGControl)c;
                            if (cc == ctrl)
                            {
                                si = idx;
                            }
                        }
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
			this.Invalidate();

		}
		// ****************************************************************
		protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (m_controls != null)
            {
                if (SelectedIndex >= 0)
                {
                    if(m_MGForm!=null)
                    {
                        m_MGForm.TargetIndex = SelectedIndex;
					}
                    
                }
            }
        }
  
        // ****************************************************************
    }
}
