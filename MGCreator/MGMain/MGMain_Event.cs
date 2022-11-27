using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator

{
	/*
	public class ForcusChangedEventArgs : EventArgs
	{
		public int Index;
		public ForcusChangedEventArgs(int idx)
		{
			Index = idx;
		}
	}
	*/
	partial class MGMain
	{
		public delegate void ForcusChangedHandler(object sender, ForcusChangedEventArgs e);
		public event ForcusChangedHandler? ForcusChanged;
		protected virtual void OnForcusChanged(ForcusChangedEventArgs e)
		{
			if (ForcusChanged != null)
			{
				ForcusChanged(this, e);
			}
		}
		// ************************************************************
		public delegate void ControlChangedHandler(object sender, EventArgs e);
		public event ControlChangedHandler? ControlChanged;
		protected virtual void OnControlChanged(EventArgs e)
		{
			if (ControlChanged != null)
			{
				ControlChanged(this, e);
			}
		}
		// ************************************************************
		public delegate void ControlOrderChangedHandler(object sender, ControlEventArgs e);
		public event ControlOrderChangedHandler? ControlOrderChanged;
		protected virtual void OnControlOrderChanged(ControlEventArgs e)
		{
			if (ControlOrderChanged != null)
			{
				ControlOrderChanged(this, e);
			}
		}
		// ************************************************************
	}
}
