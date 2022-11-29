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
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            ChkControlIndex();

		}
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
			ChkControlIndex();
		}
		// ************************************************************
		private int AddCount = 0;
        public bool AddControl(MGStyle mG)
        {
            bool ret = false;
			MGControl ctrl = new MGControl();
            ctrl.MGStyle = mG;

            string? n = Enum.GetName(typeof(MGStyle), mG);
            if (n == null) n = "MG";
			ctrl.Name = $"{n}{AddCount}";
			AddCount++;

			Random rnd = new Random();
            int w = 200;
            int h = 200;
			int l = 100;
			int t = 100;
			switch (mG)
            {
                case MGStyle.Frame:
					w = 400;
					h = 300;
                    l = 100;
					t = 100;
					ctrl.Fill = MG_COLORS.Red;
                    ctrl.FillOpacity = 0;
					ctrl.Line = MG_COLORS.White;
					ctrl.LineOpacity = 100;
					break;
                default:
					w = 200;
					h = 200;
					l = 200;
					t = 200;
					ctrl.Fill = MG_COLORS.White;
					ctrl.FillOpacity = 100;
					break;
			}
			ctrl.Size = new Size(w,h);
			ctrl.Location = new Point(l,t);
			ctrl.GotFocus += Ctrl_GotFocus;
			ctrl.LostFocus += Ctrl_LostFocus;

			this.Controls.Add(ctrl);
			ctrl.ChkOffScr();
			ChkControlIndex();
			ret = (ctrl != null);
			return ret;

        }

        private void Ctrl_LostFocus(object? sender, EventArgs e)
        {
			this.Invalidate();
		}

        private void Ctrl_GotFocus(object? sender, EventArgs e)
        {
            this.Invalidate();
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
					this.Invalidate();

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
                0
                );
			ChkControlIndex();
			OnControlOrderChanged(new ControlEventArgs(ctrl));
			this.Invalidate();
        }
        public void ControlToFront(Control ctrl)
        {
            this.Controls.SetChildIndex(
                ctrl,
                this.Controls.Count - 1
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
					this.Controls.Count - 1
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
            if (idx >= 0 && idx < this.Controls.Count-1)
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
				ChkControlIndex();
				this.Invalidate();
				OnControlOrderChanged(new ControlEventArgs(this.Controls[idx]));
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
            if (idx > 0 && idx < this.Controls.Count )
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
    }
}
