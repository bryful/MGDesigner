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
    public class MGLayerListBox : ListBox
    {
		private MGForm? m_MGForm = null;
		private MGLayers? m_Layers = null;

        public void SetMGForm(MGForm m)
        {
			m_MGForm=m;
            if(m_MGForm!=null)
            {
                m_Layers = m_MGForm.Layers;
                if (m_Layers!=null)
                {
                    m_Layers.TargetLayerChanged += M_Layers_TargetLayerChanged;
                    m_Layers.LayerNameChanged += M_Layers_LayerNameChanged;
                    m_Layers.LayerOrderChanged += M_Layers_LayerOrderChanged;
                }
				ListUp();
            }

		}

        private void M_Layers_LayerOrderChanged(object sender, EventArgs e)
        {
			ListUp();
		}

		private void M_Layers_LayerNameChanged(object sender, NameChangedEventArgs e)
        {
            if((e.Index>=0)&&(e.Index<this.Items.Count))
            {
                this.Items[e.Index] = e.Name;
            }
        }

        private void M_Layers_TargetLayerChanged(object sender, MGLayers.TargetLayerChangedEventArgs e)
        {
            if(SelectedIndex != e.Index)
            {
				SelectedIndex = e.Index;
			}
		}

        // ****************************************************************
        public MGLayerListBox()
        {
			this.SetStyle(
					ControlStyles.DoubleBuffer |
					ControlStyles.SupportsTransparentBackColor,
					true);
		}
        // ****************************************************************
        public void ListUp()
        {
            Items.Clear();
            if (m_Layers != null)
            {
				Items.AddRange(m_Layers.LayerNames);
                if(m_Layers.TargetIndex>=0)
                {
					SelectedIndex = m_Layers.TargetIndex;
				}
            }
			this.Invalidate();

		}
		// ****************************************************************
		protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (m_Layers != null)
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
