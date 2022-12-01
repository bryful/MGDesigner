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
        private void ChkMGLyers()
        {
            Layers.ChkLayers();
        }

		// ************************************************************
        public void AddControl(MGStyle mG)
        {
            Layers.AddLayer(mG);
        }

		public bool DeleteControl(int idx)
        {
            bool ret = false;
            try
            {
                if (idx >= 0 && idx < this.Controls.Count)
                {
                    Control c = Controls[idx];
                    this.Controls.RemoveAt(idx);
                    if (c != null)
                    {
                        c.Dispose();
                    }
                    this.Invalidate();
                    ret = true;
                }
            }
            catch
            {
                ret = false;
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
                0
                    );
                ret = true;
				ChkMGLyers();
				this.Invalidate();
				//OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			}
			return ret;
        }
        public void ControlToBack(Control ctrl)
        {
            this.Controls.SetChildIndex(
                ctrl,
                0
                );
			ChkMGLyers();
			//OnControlOrderChanged(new ControlEventArgs(ctrl));
			this.Invalidate();
        }
        public void ControlToFront(Control ctrl)
        {
            this.Controls.SetChildIndex(
                ctrl,
                this.Controls.Count - 1
                );
			ChkMGLyers();
			this.Invalidate();
			//OnControlOrderChanged(new ControlEventArgs(ctrl));
        }
        public bool ControlToFront(int idx)
        {
            bool ret = false;
            if (idx >= 0 && idx < this.Controls.Count)
            {

                this.Controls.SetChildIndex(
                    this.Controls[idx],
					this.Controls.Count - 1
					);
                ret = true;
				ChkMGLyers();
				this.Invalidate();
				//OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			}
			return ret;
        }
        public bool ControlToUp(int idx)
        {
            bool ret = false;
            if (idx >= 0 && idx < this.Controls.Count-1)
            {
                this.Controls.SetChildIndex(
                    this.Controls[idx],
                    idx + 1
                    );
                ret = true;
				ChkMGLyers();
				this.Invalidate();
				//OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			}
			return ret;
        }
        public bool ControlToUp(Control ctrl)
        {
            bool ret = false;
            int idx = this.Controls.GetChildIndex(ctrl);
            if (idx >= 0 && idx < this.Controls.Count-1)
            {
                this.Controls.SetChildIndex(
                    this.Controls[idx],
                    idx + 1
                    );
                ret = true;
				ChkMGLyers();
				this.Invalidate();
				//OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			}
			return ret;
        }
        public bool ControlToDown(int idx)
        {
            bool ret = false;
            if (idx > 0 && idx < this.Controls.Count )
            {
                this.Controls.SetChildIndex(
                    this.Controls[idx],
                    idx - 1
                    );
                ret = true;
				ChkMGLyers();
				this.Invalidate();
				//OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			}
			return ret;
        }
        public bool ControlToDown(Control ctrl)
        {
            bool ret = false;
            int idx = this.Controls.GetChildIndex(ctrl);
            if (idx > 0 && idx < this.Controls.Count )
            {
                this.Controls.SetChildIndex(
                    this.Controls[idx],
                    idx - 1
                    );
                ret = true;
				ChkMGLyers();
				this.Invalidate();
				//OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			}
			return ret;
        }
    }
}
