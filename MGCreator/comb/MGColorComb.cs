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
	public partial class MGColorComb : ComboBox
	{
		private MG_COL[] m_ColorsTable = new MG_COL[(int)(MG_COL.Transparent) + 1];
		[Category("_MG")]
		public MG_COL MGColors
		{
			get 
			{
				MG_COL ret = MG_COL.White;
				if(SelectedIndex>=0)
				{
					ret = m_ColorsTable[SelectedIndex];
				}
				return ret; 
			}
			set
			{
				if (this.Items.Count ==0) return;

				int idx = -1;
				for(int i=0; i< m_ColorsTable.Length; i++)
				{
					if (m_ColorsTable[i] == value)
					{
						idx= i;
						break;
					}
				}
				if (idx < 0) idx = 0;
				if(SelectedIndex != idx)
				{
					SelectedIndex = idx;
				}

			}

		}
		public MGColorComb()
		{
			InitializeComponent();
		}
		protected override void InitLayout()
		{
			base.InitLayout();
			DropDownStyle = ComboBoxStyle.DropDownList;
			Items.Clear();
			m_ColorsTable = (MG_COL[])Enum.GetValues(typeof(MG_COL));
			Items.AddRange(Enum.GetNames(typeof(MG_COL)));
			SelectedIndex = 0;
		}

	}
}
