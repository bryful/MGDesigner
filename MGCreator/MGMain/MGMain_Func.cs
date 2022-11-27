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
	partial class MGMain
	{

		// ************************************************************
        private void ChkControlIndex()
        {
            if(this.Controls.Count > 0)
            {
                for(int i=0; i< this.Controls.Count; i++)
                {
                    if (this.Controls[i] is MGControl)
                    {
                        ((MGControl)this.Controls[i]).Index = i;
					}
                }
            }
        }
		// ************************************************************
		private int AddCount = 0;
        public bool AddControl()
        {
            MGControl ctrl = new MGControl();
            ctrl.Name = $"control{AddCount}";
            AddCount++;
            ctrl.Size = new Size(100, 100);
            ctrl.Location = new Point(80, 80);

            ctrl.GotFocus += Ctrl_GotFocus;



			this.Controls.Add(ctrl);
            ChkControlIndex();
			return ctrl != null;
        }

        private void Ctrl_LostFocus(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Ctrl_GotFocus(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (sender is MGControl)
            {
                MGControl m = (MGControl)sender;
                OnForcusChanged(new ForcusChangedEventArgs(m.Index));
            }
        }
        public int ForcusControlIndex
        {
            get
            {
                int ret = -1;
                for(int i=0;i<this.Controls.Count;i++)
                {
                    if (this.Controls[i].Focused)
                    {
                        ret = i;
                        break;
                    }
                }
                return ret;
            }
            set
            {
                if((value>=0)&&(value<this.Controls.Count))
                {
                    this.Controls[value].Focus();

				}
            }
        }
        public MGControl? ForcusControl
        {
            get
            {
                MGControl? ret = null;
                int idx = ForcusControlIndex;
                if (idx >= 0) ret = (MGControl)this.Controls[idx];
                return ret;

			}
        }

		public bool DeleteControl(int idx)
        {
            bool ret = false;
            if (idx >= 0 && idx < this.Controls.Count)
            {
                this.Controls[idx].Dispose();
                this.Controls.RemoveAt(idx);
				ChkControlIndex();
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
				ChkControlIndex();
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
			ChkControlIndex();
			OnControlOrderChanged(new ControlEventArgs(ctrl));
			this.Invalidate();
        }
        public void ControlToFront(Control ctrl)
        {
            this.Controls.SetChildIndex(
                ctrl,
                0
                );
			ChkControlIndex();
			this.Invalidate();
			OnControlOrderChanged(new ControlEventArgs(ctrl));
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
				ChkControlIndex();
				this.Invalidate();
				OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			}
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
				ChkControlIndex();
				this.Invalidate();
				OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			}
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
				ChkControlIndex();
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
				ChkControlIndex();
				this.Invalidate();
				OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
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
				ChkControlIndex();
				this.Invalidate();
				OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
			}
			return ret;
        }
    }
}
