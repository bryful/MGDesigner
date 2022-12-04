using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public partial class MGProjectPanel : Control
	{
		public Point MGFormPoint = new Point(-1, -1);
		public Point MGPropPoint = new Point(-1, -1);
		public Color[] MGColors = new Color[(int)MG_COLORS.Transparent];
		public MG_COLORS Back = MG_COLORS.Black;
		public MGPropertyForm? MGPropertyForm = null;

		private MGForm? m_MGForm = null;
		private int m_DispY = 0;
		private int m_DispYMax = 0;
		private int m_RowHeight = 14;
		private StringFormat m_sf = new StringFormat();
		private Color m_SelectedColor = Color.Gray;
		private int m_HideWidth = 14;
		private int m_ScrolWidth = 14;
		public MGForm? MGForm
		{
			get { return m_MGForm; }
			set
			{
				m_MGForm = value;
				if (m_MGForm != null)
				{
					m_MGForm.Layers.LayerAdded += Layers_LayerAdded;
					m_MGForm.Layers.LayerRemoved += Layers_LayerAdded;
					m_MGForm.Layers.LayerOrderChanged += Layers_LayerAdded;
					m_MGForm.Layers.TargetLayerChanged += Layers_TargetLayerChanged;
				}
				this.Invalidate();
			}
		}

		private void Layers_TargetLayerChanged(object sender, MGLayers.TargetLayerChangedEventArgs e)
		{
			this.Invalidate();
		}

		private void Layers_LayerAdded(object sender, EventArgs e)
		{
			ChkSize();
			this.Invalidate();
		}
		// ************************************************************************************************
		private Button? m_AddBtn = null;
		public Button? AddBtn
		{
			get { return m_AddBtn; }
			set
			{
				m_AddBtn = value;
				if(m_AddBtn != null)
				{
					m_AddBtn.Click += M_AddBtn_Click;
				}
			}
		}
		private void M_AddBtn_Click(object? sender, EventArgs e)
		{
			if ((MGForm != null) && (m_StyleComb != null))
			{
				MGForm.AddLayer(m_StyleComb.MGStyle);
			}
		}
		// ************************************************************************************************
		private MGStyleComb? m_StyleComb = null;
		public MGStyleComb? StyleComb
		{
			get { return m_StyleComb; }
			set
			{
				m_StyleComb = value;
			}
		}

		// ************************************************************************************************
		private Button? m_DelBtn = null;
		public Button? DelBtn
		{
			get { return m_DelBtn; }
			set
			{
				m_DelBtn = value;
				if (m_DelBtn != null)
				{
					m_DelBtn.Click += M_DelBtn_Click;
				}
			}
		}
		private void M_DelBtn_Click(object? sender, EventArgs e)
		{
			if (MGForm != null)
			{
				MGForm.Layers.TargetRemove();
			}
		}
		// ************************************************************************************************
		private Button? m_UpBtn = null;
		public Button? UpBtn
		{
			get { return m_DelBtn; }
			set
			{
				m_UpBtn = value;
				if (m_UpBtn != null)
				{
					m_UpBtn.Click += M_UpBtn_Click;
				}
			}
		}
		private void M_UpBtn_Click(object? sender, EventArgs e)
		{
			if (MGForm != null)
			{
				MGForm.Layers.TargetUp();
			}
		}
		// ************************************************************************************************
		private Button? m_DownBtn = null;
		public Button? DownBtn
		{
			get { return m_DownBtn; }
			set
			{
				m_DownBtn = value;
				if (m_DownBtn != null)
				{
					m_DownBtn.Click += M_DownBtn_Click;
				}
			}
		}
		private void M_DownBtn_Click(object? sender, EventArgs e)
		{
			if (MGForm != null)
			{
				MGForm.Layers.TargetDown();
			}
		}
		// ************************************************************************************************
		private Button? m_NewMGBtn = null;
		public Button? NewMGBtn
		{
			get { return m_NewMGBtn; }
			set
			{
				m_NewMGBtn = value;
				if (m_NewMGBtn != null)
				{
					m_NewMGBtn.Click += M_NewMGBtn_Click;
				}
			}
		}

		private void M_NewMGBtn_Click(object? sender, EventArgs e)
		{
			ShowMGForm();
		}
		// ************************************************************************************************
		private Button? m_PropBtn = null;
		public Button? PropBtn
		{
			get { return m_PropBtn; }
			set
			{
				m_PropBtn = value;
				if (m_PropBtn != null)
				{
					m_PropBtn.Click += M_PropBtn_Click;
				}
			}
		}

		private void M_PropBtn_Click(object? sender, EventArgs e)
		{
			ShowMGPropertyForm();
		}
		// ************************************************************************************************

		public MGProjectPanel()
		{
			m_sf.Alignment = StringAlignment.Near;
			m_sf.LineAlignment = StringAlignment.Center;
			InitializeComponent();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor |
ControlStyles.UserMouse |
ControlStyles.Selectable,
true);
			ChkSize();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Graphics g = pe.Graphics;
			g.Clear(this.BackColor);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(this.ForeColor);
			try
			{
				if(this.m_MGForm != null)
				{
					sb.Color = this.ForeColor;
					if(this.m_MGForm.Layers.Count>0)
					{
						for(int idx=0; idx< this.m_MGForm.Layers.Count;idx++)
						{
							int y = idx * m_RowHeight - m_DispY;
							if ((y < -m_RowHeight)||(y>=this.Height)) continue;
							MGLayer layer = m_MGForm.Layers[idx];
							Rectangle rct = new Rectangle(0, y, this.Width - m_ScrolWidth, m_RowHeight);
							if(idx== m_MGForm.Layers.TargetIndex)
							{
								sb.Color = m_SelectedColor;
								g.FillRectangle(sb, rct);
							}
							sb.Color = this.ForeColor;
							if (layer.IsShow)
							{
								rct = new Rectangle(5, y + 3, 8, 8);
								g.FillEllipse(sb, rct);
							}
							else
							{
								int y2 = y + m_RowHeight / 2;
								p.Width = 1;
								g.DrawLine(p, 6, y2, 11, y2);
							}
							rct = new Rectangle(m_HideWidth,
								y,
								this.Width - m_HideWidth-m_ScrolWidth,
								m_RowHeight);
							g.DrawString(layer.Name, this.Font, sb, rct, m_sf);


						}
					}
					int x = this.Width - m_ScrolWidth / 2;
					int ms = m_ScrolWidth / 2;
					g.DrawLine(p, x, ms, x, this.Height - ms);
					if(m_DispYMax>0)
					{
						int y = m_DispY * (this.Height - m_ScrolWidth) / (m_DispYMax);
						Rectangle rr = new Rectangle(this.Width-m_ScrolWidth, y, m_ScrolWidth, m_ScrolWidth);
						if (m_ismd)
						{
							sb.Color = Color.Gray;
						}
						else
						{
							sb.Color = this.ForeColor;
						}
						g.FillEllipse(sb, rr);
					}


				}
				p.Color = this.ForeColor;
				MGc.DrawFrame(g, p,1, this.ClientRectangle);
			}
			catch
			{
				sb.Dispose();
				p.Dispose();
			}

		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
			this.Invalidate();
		}
		public void ChkSize()
		{
			if ((m_MGForm != null)&&(m_MGForm.Layers.Count>0))
			{
				int h = m_MGForm.Layers.Count * m_RowHeight;
				m_DispYMax = h - this.Height;
				if (m_DispYMax < 0) m_DispYMax = 0;
				if (m_DispY > m_DispYMax) m_DispY = m_DispYMax;
			}
			else
			{
				m_DispY = 0;
				m_DispYMax = 0;
			}
		}
		private int m_mdpos = 0;
		private bool m_ismd = false;
		private int m_dispYBak = 0;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (m_MGForm != null)
			{
				bool b = false;
				int idx = (m_DispY + e.Y) / m_RowHeight;
				if (idx < 0) idx = 0;
				else if (idx >= m_MGForm.Layers.Count) idx = m_MGForm.Layers.Count;
				if (e.X> this.Width - m_ScrolWidth)
				{
					if (m_DispYMax > 0) {
						int dc = e.Y - m_ScrolWidth / 2;
						int dy = m_DispY * (this.Height - m_ScrolWidth) / m_DispYMax;

						if ( (dy-5<dc) && (dy+5 > dc) )
						{
							m_mdpos = e.Y;
							m_ismd = true;
							m_dispYBak = m_DispY;
							b = true;
						}
						else
						{
							m_DispY = m_DispYMax * dc / (this.Height - m_ScrolWidth);
							if (m_DispY < 0) m_DispY = 0; else if (m_DispY > m_DispYMax) m_DispY = m_DispYMax;
							b = true;
						}
					}
				}
				else
				{
					if (m_MGForm.Layers.TargetIndex != idx)
					{
						m_MGForm.Layers.TargetIndex = idx;
						b = true;
					}
					if (e.X < m_HideWidth)
					{
						m_MGForm.Layers[idx].IsShow = !m_MGForm.Layers[idx].IsShow;
						b = true;
						MGForm.Invalidate();
					}
				}
				if (b) this.Invalidate();
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if(m_ismd)
			{
				int dd = (this.Height - m_ScrolWidth);
				int dy = (e.Y - m_mdpos);
				m_DispY = m_dispYBak + dy*m_DispYMax/dd;
				if (m_DispY < 0) m_DispY = 0; else if (m_DispY > m_DispYMax) m_DispY = m_DispYMax;
				this.Invalidate();
			}
			base.OnMouseMove(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (m_ismd)
			{
				m_ismd = false;
				m_mdpos = 0;
				m_dispYBak = 0;
				this.Invalidate();
			}
			base.OnMouseUp(e);
		}

		// *********************************************************************************
		// *******************************************************************************
		public void ShowMGPropertyForm(bool isV = true)
		{
			if (MGForm == null) return;
			if (MGPropertyForm == null)
			{
				MGPropertyForm = new MGPropertyForm();
				MGPropertyForm.MGForm = MGForm;
				MGPropertyForm.StartPosition = FormStartPosition.Manual;
				if (MGPropPoint.X != -1)
				{

					MGPropertyForm.Location = MGPropPoint;
				}
				else
				{
					MGPropertyForm.Location = new Point(
						this.Left,
						this.Bottom + 5);
				}

				if (isV)
				{
					MGPropertyForm.Show();
					MGPropertyForm.Visible = true;
				}
				else
				{
					MGPropertyForm.Visible = false;
				}

			}
			else
			{
				if (MGPropertyForm.Visible == false)
				{
					MGPropertyForm.Visible = true;
					MGPropertyForm.Activate();
					MGPropertyForm.Focus();
				}
				else
				{
					MGPropertyForm.Visible = false;
				}
			}
		}
		// *******************************************************************************
		public void ShowMGForm()
		{
			if (MGForm == null)
			{
				MGFormSize dlg = new MGFormSize();
				dlg.StartPosition = FormStartPosition.Manual;
				dlg.Location = Cursor.Position;
				dlg.IsShowPosSet = false;
				MGForm = new MGForm();
				dlg.MGFrom = MGForm;
				dlg.Back = Back;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					MGForm.Size = dlg.FormSize;
					MGForm.MGProjectPanel = this;

					MGForm.Back = dlg.Back;
					if (MGFormPoint.X != -1)
					{
						MGForm.Location = MGFormPoint;
					}
					else
					{
						MGForm.Location = new Point(this.Left + this.Width + 5, this.Top);
					}
					MGForm.SetColors(MGColors);
					if(MGForm.ChkColors()==false)
					{
						MGForm.InitColor();
						MessageBox.Show("Bug! Color Reset");
					}
					MGForm.Show();
					ShowMGPropertyForm(false);
				}
				else
				{
					MGForm = null;
				}

			}
			else
			{
				if (MGForm.Visible == false)
				{
					MGForm.Visible = true;
				}
				MGForm.Activate();
				MGForm.Focus();
			}
		}
	}
}
