using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MGCreator
{
    public class MGLayers
    {
		// ************************************************************

		public delegate void NameChangedHandler(object sender, NameChangedEventArgs e);
		public event NameChangedHandler? LayerNameChanged;
		protected virtual void OnLayerNameChanged(NameChangedEventArgs e)
		{
			if (LayerNameChanged != null)
			{
				LayerNameChanged(this, e);
			}
		}               
		// ************************************************************
		public class TargetLayerChangedEventArgs : EventArgs
		{
			public int Index;
			public MGLayer? Layer;
			public TargetLayerChangedEventArgs(int idx, MGLayer? l)
			{
				this.Index = idx;
				this.Layer = l;
			}
		}
		// ************************************************************
		public delegate void TargetLayerChangedHandler(object sender, TargetLayerChangedEventArgs e);
		public event TargetLayerChangedHandler? TargetLayerChanged;
		protected virtual void OnTargetLayerChanged(TargetLayerChangedEventArgs e)
		{
			if (TargetLayerChanged != null)
			{
				TargetLayerChanged(this, e);
			}
		}
		// **********************************************************************************
		public delegate void LayerAddedHandler(object sender, EventArgs e);
		public event LayerAddedHandler? LayerAdded;
		protected virtual void OnLayerAdded(EventArgs e)
		{
			if (LayerAdded != null)
			{
				LayerAdded(this, e);
			}
		}
		public delegate void LayerRemovedHandler(object sender, EventArgs e);
		public event LayerRemovedHandler? LayerRemoved;
		protected virtual void OnLayerRemoved(EventArgs e)
		{
			if (LayerRemoved != null)
			{
				LayerRemoved(this, e);
			}
		}
		public delegate void LayerOrderChangedHandler(object sender, EventArgs e);
		public event LayerOrderChangedHandler? LayerOrderChanged;
		protected virtual void OnLayerOrderChanged(EventArgs e)
		{
			if (LayerOrderChanged != null)
			{
				LayerOrderChanged(this, e);
			}
		}
		// **********************************************************************************
		private MGForm? m_MGForm=null;
        public void SetMGForm(MGForm m) { m_MGForm = m; }
		
		private int m_TargetIndex =-1;
        public int TargetIndex
        {
            get { return m_TargetIndex; }
            set
            {
                if ((value >= 0) && (value < Count))
                {
                    if (m_TargetIndex != value)
                    {
                        m_TargetIndex = value;
                        OnTargetLayerChanged(new TargetLayerChangedEventArgs(m_TargetIndex, m_Items[m_TargetIndex]));
					}
                }
			}
        }
        private List<MGLayer> m_Items = new List<MGLayer>();
        public int Count { get { return m_Items.Count; } }
        public MGLayer? this[int idx]
        {
            get
            {
                if((idx >= 0) && (idx < m_Items.Count))
                {
                    return m_Items[idx];
                }
                else
                {
                    return null;
                }
            }
        }
        public MGLayer? TargetLayer
        {
			get
			{
				if ((m_TargetIndex >= 0) && (m_TargetIndex < m_Items.Count))
				{
					return m_Items[m_TargetIndex];
				}
				else
				{
					return null;
				}
			}
		}
		public string[] LayerNames
		{
			get
			{
				string[] names = new string[Count];
				if(Count>0)
				{
					for(int i=0;i<Count; i++)
					{
						names[i] = m_Items[i].Name;
					}
				}
				return names;
			}
		}
		// **********************************************************************************
		public MGLayers(MGForm m)
        {
            m_MGForm = m;
        }
		// **********************************************************************************
		public MGLayers()
		{
		}
		// **********************************************************************************
		public int IndexOf(string name)
		{
			int ret = -1;
			if (Count > 0)
			{
				for (int i = 0; i < Count; i++)
				{
					if (m_Items[i].Name== name)
					{
						ret = i;
						break;
					}
				}
			}
			return ret;
		}
		
		// **********************************************************************************
		public void ChkLayers()
		{
			if (Count > 0)
			{
				for (int i = 0; i < Count; i++)
				{
					m_Items[i].SetIndex(i);
				}
			}
		}
		// **********************************************************************************
		public MGLayer? CreateLayer(MGStyle ms)
		{
			MGLayer? ret = null;
			if (m_MGForm == null) return ret;
			switch (ms)
			{
				case MGStyle.Cross:
					ret = (MGLayer)(new MGLayerCross(m_MGForm));
					break;
				case MGStyle.Grid:
					ret = (MGLayer)(new MGLayerGrid(m_MGForm));
					break;
				default:
					ret = (MGLayer)(new MGLayer(m_MGForm));
					break;
			}
			return ret;
		}
		// **********************************************************************************
		private int m_Def_PosX = 0;
		private int m_Def_PosY = 0;
		public void AddLayer(MGStyle ms)
        {
			if (m_MGForm == null) return;
			MGLayer? layer = CreateLayer(ms);
			if (layer == null) return;

			string n = layer.Name;
			layer.Name += "1";
			int cnt = 1;
			while(IndexOf(layer.Name)>=0)
			{
				layer.Name = n+ $"{cnt}";
				cnt++;
			}
			layer.Location = new Point(layer.Left + m_Def_PosX, layer.Top + m_Def_PosY);
			m_Def_PosX += 30; if (m_Def_PosX > m_MGForm.Width *3/ 4) m_Def_PosX = 0;
			m_Def_PosY += 30; if (m_Def_PosY > m_MGForm.Height *3/ 4) m_Def_PosY = 0;
			layer.NameChanged += Layer_NameChanged1;
			if(Count>0)
			{
				m_Items.Insert(0,layer);
			}
			else
			{
				m_Items.Add(layer);

			}
			ChkLayers();
			layer.ChkOffScr();
			OnLayerAdded(EventArgs.Empty);
			TargetIndex = 0;
		}

		private void Layer_NameChanged1(object sender, NameChangedEventArgs e)
		{
			OnLayerNameChanged(e);
		}
		// **********************************************************************************
		public void Remove(MGLayer layer)
		{
			int idx=IndexOf(layer.Name);
			RemoveAt(idx);
		}
		// **********************************************************************************
		public void RemoveAt(int idx)
		{
			if ((idx >= 0)&&(idx<Count))
			{
				m_Items[idx].Dispose();
				m_Items.RemoveAt(idx);
				ChkLayers();
				if (m_TargetIndex >= Count) m_TargetIndex = Count - 1;
				OnLayerRemoved(EventArgs.Empty);
				if (m_TargetIndex >= 0)
				{
					OnTargetLayerChanged(new TargetLayerChangedEventArgs(m_TargetIndex, m_Items[m_TargetIndex]));
				}
				if (m_MGForm != null) m_MGForm.Invalidate();

			}
		}
		// **********************************************************************************
		public void TargetRemove()
		{
			if((m_TargetIndex>=0)&&(m_TargetIndex<Count))
			{
				RemoveAt(m_TargetIndex);
			}
		}
		// **********************************************************************************
		public  void OederChange(int srcIdx, int newIdx)
		{
			if (srcIdx == newIdx) return;
			if ((srcIdx < 0) || (srcIdx >= Count) || (newIdx < 0) || (newIdx >= Count)) return;

			MGLayer item = m_Items[srcIdx];
			m_Items.RemoveAt(srcIdx);

			if (newIdx > m_Items.Count)
			{
				m_Items.Add(item);
			}
			else
			{
				m_Items.Insert(newIdx, item);
			}
			ChkLayers();
			if (m_MGForm != null) m_MGForm.Invalidate();
		}
		public void TargetUp()
		{
			if((m_TargetIndex>0)&&(m_TargetIndex < Count))
			{
				OederChange(m_TargetIndex, m_TargetIndex - 1);
				m_TargetIndex = m_TargetIndex - 1;
				OnLayerOrderChanged(new EventArgs());
			}
		}
		public void TargetDown()
		{
			if ((m_TargetIndex >= 0) && (m_TargetIndex < Count-1))
			{
				OederChange(m_TargetIndex, m_TargetIndex + 1);
				m_TargetIndex = m_TargetIndex + 1;
				OnLayerOrderChanged(new EventArgs());
			}
		}
		public void TargetToBottom()
		{
			if ((m_TargetIndex >= 0) && (m_TargetIndex < Count-1))
			{
				OederChange(m_TargetIndex, Count-1);
				m_TargetIndex = Count - 1;
				OnLayerOrderChanged(new EventArgs());
			}
		}
		public void TargetToTop()
		{
			if ((m_TargetIndex > 0) && (m_TargetIndex < Count))
			{
				OederChange(m_TargetIndex, 0);
				m_TargetIndex = 0;
				OnLayerOrderChanged(new EventArgs());
			}
		}
		// **********************************************************************************
		public void ShowMenu(int x, int y)
		{
			ContextMenuStrip menu = new ContextMenuStrip();
			ToolStripMenuItem ToTopMenu = new ToolStripMenuItem();
			ToTopMenu.Name = "ToTop";
			ToTopMenu.Text = "To Top";
			ToTopMenu.Click += ToTopMenu_Click;
			ToolStripMenuItem ToBottomMenu = new ToolStripMenuItem();
			ToBottomMenu.Name = "ToBottom";
			ToBottomMenu.Text = "To Bottom";
			ToBottomMenu.Click += ToBottomMenu_Click;

			ToolStripMenuItem UpMenu = new ToolStripMenuItem();
			UpMenu.Name = "Up";
			UpMenu.Text = "Up";
			UpMenu.Click += UpMenu_Click;
			ToolStripMenuItem DownMenu = new ToolStripMenuItem();
			DownMenu.Name = "Down";
			DownMenu.Text = "Down";
			DownMenu.Click += DownMenu_Click;

			ToolStripMenuItem DelMenu = new ToolStripMenuItem();
			DelMenu.Name = "Delete";
			DelMenu.Text = "Delete";
			DelMenu.Click += DelMenu_Click;


			menu.Items.Add(ToTopMenu);
			menu.Items.Add(ToBottomMenu);
			menu.Items.Add(new ToolStripSeparator());
			menu.Items.Add(UpMenu);
			menu.Items.Add(DownMenu);
			menu.Items.Add(new ToolStripSeparator());
			menu.Items.Add(DelMenu);
			menu.Show(m_MGForm, x, y);
		}

		private void DelMenu_Click(object? sender, EventArgs e)
		{
			TargetRemove();
		}

		private void DownMenu_Click(object? sender, EventArgs e)
		{
			TargetDown();
		}

		private void UpMenu_Click(object? sender, EventArgs e)
		{
			TargetUp();
		}

		private void ToBottomMenu_Click(object? sender, EventArgs e)
		{
			TargetToBottom();
		}

		private void ToTopMenu_Click(object? sender, EventArgs e)
		{
			TargetToTop();
		}
		public void SetFormSize(Size sz, SizeRootType sr)
		{
			if (m_MGForm == null) return;
			if (m_MGForm.Size == sz) return;
			if (Count <= 0)
			{
				m_MGForm.Size = sz;
				return;
			}
			//まず基点を求める

			List<Point> baseP = new List<Point>();
			int cx;
			int cy;
			Size m = m_MGForm.Size;
			for(int i = 0; i < Count; i++)
			{
				MGLayer L = m_Items[i];
				cx = L.Left;
				cy = L.Top;
				switch (sr)
				{
					case SizeRootType.Center:
						cx = cx - (m.Width / 2);
						cy = cy - (m.Height / 2);
						break;
					case SizeRootType.TopLeft:
						break;
					case SizeRootType.Top:
						cx =  cx -  (m.Width / 2);
						cy =  cy -  0;
						break;
					case SizeRootType.TopRight:
						cx = cx - (m.Width);
						cy = cy - 0;
						break;
					case SizeRootType.Right:
						cx = cx - (m.Width);
						cy = cy - (m.Height/2);
						break;
					case SizeRootType.BottomRight:
						cx = cx - (m.Width);
						cy = cy - (m.Height);
						break;
					case SizeRootType.Bottom:
						cx = cx - (m.Width/2);
						cy = cy - (m.Height);
						break;
					case SizeRootType.BottomLeft:
						cx = cx - 0;
						cy = cy - (m.Height);
						break;
					case SizeRootType.Left:
						cx = cx - 0;
						cy = cy - (m.Height/2);
						break;
				}
				baseP.Add(new Point(cx, cy));
			}
			Point p = m_MGForm.Location;
			cx = p.X + m.Width / 2;
			cy = p.Y + m.Height / 2;
			m_MGForm.Size = sz;
			m = m_MGForm.Size;
			m_MGForm.Location = new Point(cx-m.Width/2, cy-m.Height/2);
			for (int i = 0; i < Count; i++)
			{
				cx = 0;
				cy = 0;
				switch (sr)
				{
					case SizeRootType.Center:
						cx = baseP[i].X + (m.Width / 2);
						cy = baseP[i].Y + (m.Height / 2);
						break;
					case SizeRootType.TopLeft:
						cx  = baseP[i].X;
						cy = baseP[i].Y;
						break;
					case SizeRootType.Top:
						cx = baseP[i].X + (m.Width / 2);
						cy = baseP[i].Y;
						break;
					case SizeRootType.TopRight:
						cx = baseP[i].X + (m.Width);
						cy = baseP[i].Y;
						break;
					case SizeRootType.Right:
						cx = baseP[i].X + (m.Width);
						cy = baseP[i].Y + (m.Height / 2);

						break;
					case SizeRootType.BottomRight:
						cx = baseP[i].X + (m.Width);
						cy = baseP[i].Y + (m.Height);
						break;
					case SizeRootType.Bottom:
						cx = baseP[i].X + (m.Width/2);
						cy = baseP[i].Y + (m.Height);
						break;
					case SizeRootType.BottomLeft:
						cx = baseP[i].X ;
						cy = baseP[i].Y + (m.Height);
						break;
					case SizeRootType.Left:
						cx = baseP[i].X;
						cy = baseP[i].Y + (m.Height/2);
						break;
					default:
						break;
				}
				m_Items[i].Location = new Point(cx, cy);
			}
		}
		private SizeRootType m_Def_SR= SizeRootType.Center;
		public void SetFormSize()
		{
			if (m_MGForm == null) return;
			MGFormSize dlg = new MGFormSize();
			dlg.SizeRoot = m_Def_SR;
			dlg.FormSize = m_MGForm.Size;
			dlg.MGFrom = m_MGForm;
			dlg.Back = m_MGForm.Back;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SetFormSize(dlg.FormSize, dlg.SizeRoot);
				m_Def_SR = dlg.SizeRoot;
				m_MGForm.Back = dlg.Back;
			}
			dlg.Dispose();
		}
		public JsonArray ToJson()
		{
			JsonArray result = new JsonArray();
			foreach(MGLayer l in m_Items)
			{
				JsonObject ja = l.ToJson();
				result.Add(ja);
			}
			return result;
		}
	}
}
