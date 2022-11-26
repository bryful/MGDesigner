using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator.ProperyPanel
{
    public class ResizeTypeComb : ComboBox
    {
        public ResizeTypeComb()
        {
            BackColor = Color.Black;
            ForeColor = Color.LightGray;
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            DropDownStyle = ComboBoxStyle.DropDownList;
            Items.Clear();
            Items.AddRange(Enum.GetNames(typeof(ReSizeType)));
            SelectedIndex = (int)ReSizeType.Center;
            BackColor = Color.Black;
            ForeColor = Color.LightGray;
        }
        public ReSizeType SelectedReSizeType
        {
            get
            {
                ReSizeType ret = ReSizeType.Center;
                if (SelectedIndex >= 0)
                {
                    ret = (ReSizeType)SelectedIndex;
                }
                return ret;
            }
            set
            {
                SelectedIndex = (int)value;
            }
        }
    }
}
