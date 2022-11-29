namespace MGCreator
{
	public class ForcusChangedEventArgs : EventArgs
	{
		public int Index;
		public ForcusChangedEventArgs(int idx)
		{
			Index = idx;
		}
	}
	public class TargetChangedEventArgs : EventArgs
	{
		public int Index;
		MGControl? Control;
		public TargetChangedEventArgs(int idx, MGControl? ctrl)
		{
			this.Index = idx;
			this.Control = ctrl;
		}
	}
	partial class MGForm
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
		public delegate void TargetChangedHandler(object sender, TargetChangedEventArgs e);
		public event TargetChangedHandler? TargetChanged;
		protected virtual void OnTargetChanged(TargetChangedEventArgs e)
		{
			if (TargetChanged != null)
			{
				TargetChanged(this, e);
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
