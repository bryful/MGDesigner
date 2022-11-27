﻿using System;
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
	public partial class MGPropertyForm : MGToolForm
	{
		public MGPropertyForm()
		{
			InitializeComponent();
			mgPropertyPanel1.ForeColor = Color.LightGray;
		}
		protected override void SetMGForm(MGForm? m)
		{
			m_MGForm = m;
			mgPropertyPanel1.MGForm = m;
		}
	}
}
