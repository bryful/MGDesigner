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
		private MG_COLORS[] m_ColorsTable = new MG_COLORS[(int)(MG_COLORS.Transparent) + 1];
		[Category("_MG")]
		public MG_COLORS MGColors
		{
			get 
			{
				MG_COLORS ret = MG_COLORS.White;
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
			m_ColorsTable = (MG_COLORS[])Enum.GetValues(typeof(MG_COLORS));
			Items.AddRange(Enum.GetNames(typeof(MG_COLORS)));
			SelectedIndex = 0;
		}

	}
}
