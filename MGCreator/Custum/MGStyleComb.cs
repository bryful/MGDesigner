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
        public MGStyleComb()
        {
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            DropDownStyle = ComboBoxStyle.DropDownList;
            Items.Clear();
            Items.AddRange(Enum.GetNames(typeof(MGStyle)));

        }

    }
}
