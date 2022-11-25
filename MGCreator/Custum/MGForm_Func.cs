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
	partial class MGForm
	{
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
		private int AddCount = 0;
        public bool AddControl()
        {
            MGCcontrol ctrl = new MGCcontrol();
            ctrl.Name = $"control{AddCount}";
            AddCount++;
            ctrl.Size = new Size(100, 100);
            ctrl.Location = new Point(80, 80);

            this.Controls.Add(ctrl);

			return ctrl != null;
        }
        public bool DeleteControl(int idx)
        {
            bool ret = false;
            if (idx >= 0 && idx < this.Controls.Count)
            {
                this.Controls[idx].Dispose();
                this.Controls.RemoveAt(idx);
                ret = true;
			}
			return ret;
        }
        public bool ControlBackTo(int idx)
        {
            bool ret = false;
            if (idx >= 0 && idx < this.Controls.Count)
            {

                this.Controls.SetChildIndex(
                    this.Controls[idx],
                this.Controls.Count - 1
                    );
                ret = true;
                this.Invalidate();
				OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			}
			return ret;
        }
        public void ControlToBack(Control ctrl)
        {
            this.Controls.SetChildIndex(
                ctrl,
                this.Controls.Count - 1
                );
			OnControlOrderChanged(new ControlEventArgs(ctrl));
			this.Invalidate();
        }
        public void ControlToFront(Control ctrl)
        {
            this.Controls.SetChildIndex(
                ctrl,
                0
                );
			OnControlOrderChanged(new ControlEventArgs(ctrl));
			this.Invalidate();
        }
        public bool ControlToFront(int idx)
        {
            bool ret = false;
            if (idx >= 0 && idx < this.Controls.Count)
            {

                this.Controls.SetChildIndex(
                    this.Controls[idx],
                    0
                    );
                ret = true;
                this.Invalidate();
            }
			OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			return ret;
        }
        public bool ControlToUp(int idx)
        {
            bool ret = false;
            if (idx > 0 && idx < this.Controls.Count)
            {
                this.Controls.SetChildIndex(
                    this.Controls[idx],
                    idx - 1
                    );
                ret = true;
                this.Invalidate();
            }
			OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			return ret;
        }
        public bool ControlToUp(Control ctrl)
        {
            bool ret = false;
            int idx = this.Controls.GetChildIndex(ctrl);
            if (idx > 0 && idx < this.Controls.Count)
            {
                this.Controls.SetChildIndex(
                    this.Controls[idx],
                    idx - 1
                    );
                ret = true;
                this.Invalidate();
				OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			}
			return ret;
        }
        public bool ControlToDown(int idx)
        {
            bool ret = false;
            if (idx >= 0 && idx < this.Controls.Count - 1)
            {
                this.Controls.SetChildIndex(
                    this.Controls[idx],
                    idx + 1
                    );
                ret = true;
				OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
				this.Invalidate();
            }
            return ret;
        }
        public bool ControlToDown(Control ctrl)
        {
            bool ret = false;
            int idx = this.Controls.GetChildIndex(ctrl);
            if (idx >= 0 && idx < this.Controls.Count - 1)
            {
                this.Controls.SetChildIndex(
                    this.Controls[idx],
                    idx + 1
                    );
                ret = true;
				OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
				this.Invalidate();
            }
            return ret;
        }
    }
}
