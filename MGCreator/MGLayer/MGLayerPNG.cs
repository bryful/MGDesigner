using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MGCreator
{
	public class MGLayerPNG :MGLayer
	{
		public new readonly MGStyle MGStyle = MGStyle.PNG;
		private string m_FileName = "";
		public string FileName
		{
			get { return m_FileName; }
			set
			{
				m_FileName = value;
				ChkOffScr();
			}

		}
		private bool LoadPNG(string s)
		{
			bool ret = false;
			if (File.Exists(s) == false) return ret;
			Bitmap bmp = new Bitmap(s);
			if(bmp == null) return ret;
			try
			{
				m_Offscr = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppArgb);
				m_Size = new Size(bmp.Width, bmp.Height);
				Graphics g = Graphics.FromImage(m_Offscr);
				g.Clear(Color.Transparent);
				g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
				bmp.Dispose();
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{

		}
		public new void ChkOffScr()
		{
			if(LoadPNG(m_FileName)==false)
			{
				m_Offscr = new Bitmap(100, 100, PixelFormat.Format32bppArgb);
				m_Size = new Size(100, 100);
			}
			if (m_MGForm != null)
			{
				m_MGForm.Invalidate();
			}
		}
		public MGLayerPNG(MGForm m) : base(m)
		{
			Name = "PNG";
			m_MGForm = m;

			ChkOffScr();
		}
		public override bool ChkMouseDown(MouseEventArgs e)
		{
			bool ret = false;
			if ((IsShow == false) || (m_IsFull)) return ret;
			int x = e.X - m_location.X;
			int y = e.Y - m_location.Y;
			SizeRootType m = GetMDPos(x, y);
			if (m != SizeRootType.None)
			{
				m_MouseDown = SizeRootType.Center;
				m_MDLocation = this.Location;
				m_MDPoint = new Point(x, y);
				m_MDSize = this.Size;
				//OnMouseDown(new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta));
				ret = true;
			}
			else
			{
				m_MouseDown = SizeRootType.None;
			}
			return ret;
		}
		// ***************************************************************************
		public override List<Control> ParamsMain()
		{
			List<Control> PList = new List<Control>();
			EditName m_name = new EditName();
			PList.Add(m_name);

			EditLayerLocation m_location = new EditLayerLocation();
			PList.Add(m_location);

			EditLayerSizeRoot m_SizeRoot = new EditLayerSizeRoot();
			PList.Add(m_SizeRoot);

			EditFileName m_fn = new EditFileName();
			PList.Add(m_fn);


			return PList;
		}
		public override List<Control> ParamsParam()
		{
			List<Control> PList = new List<Control>();

			return PList;

		}
		public override List<Control> ParamsColors()
		{
			List<Control> PList = new List<Control>();


			return PList;
		}
		// ***************************************************************************
		public virtual JsonObject ToJson()
		{
			MGj jn = new MGj(new JsonObject());
			jn.SetValue("MGStyle", (int)MGStyle);
			jn.SetValue("Name", m_Name);
			jn.SetValue("CornerLock", m_CornerLock);
			jn.SetValue("SizeRoot", (int)m_SizeRoot);
			jn.SetValue("FileName", m_FileName);
			return jn.Obj;
		}
		// ***************************************************************************
		public virtual void FromJson(JsonObject jo)
		{
			bool ret = false;
			if (jo == null) return;
			MGj jn = new MGj(jo);
			int v = 0;
			if (jn.GetStr("Name", ref m_Name) == false) { ret = false; m_Name = "Frame1"; }
			if (jn.GetBool("CornerLock", ref m_CornerLock) == false) { ret = false; m_CornerLock = false; }
			if (jn.GetInt("SizeRoot", ref v) == true)
			{
				m_SizeRoot = (SizeRootType)v;
			}
			else
			{
				m_SizeRoot = SizeRootType.TopLeft;
				ret = false;
			}
			v = 0;
			if (jn.GetStr("FileName", ref m_FileName) == false) { ret = false; }
			ChkOffScr();
		}
	}
}
