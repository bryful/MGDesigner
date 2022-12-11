using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MGCreator
{
	public class MGLayerEdge : MGLayer
	{
		public new readonly MGStyle MGStyle = MGStyle.Edge;

		private Size m_EdgeSize = new Size(20, 20);
		public Size EdgeSize
		{
			get { return m_EdgeSize; }
			set { m_EdgeSize = value; ChkOffScr(); }
		}
		private bool m_IsKagi = true;
		public bool IsKagi
		{
			get { return m_IsKagi; }
			set { m_IsKagi = value; ChkOffScr(); }
		}
		private KagiParam m_kp = new KagiParam();

		public float TopHeight
		{
			get { return m_kp.TopHeight; }
			set
			{
				m_kp.TopHeight = value;
				ChkOffScr();
			}
		}
		public float BottomHeight
		{
			get { return m_kp.BottomHeight; }
			set
			{
				m_kp.BottomHeight = value;
				ChkOffScr();
			}
		}
		public float LeftWidth
		{
			get { return m_kp.LeftWidth; }
			set
			{
				m_kp.LeftWidth = value;
				ChkOffScr();
			}
		}
		public float RightWidth
		{
			get { return m_kp.RightWidth; }
			set
			{
				m_kp.RightWidth = value;
				ChkOffScr();
			}
		}
		private bool[] m_EdgeFlags = new bool[4] { true, true, true, true };
		public bool EdgeTopLeft
		{
			get { return m_EdgeFlags[0]; }
			set
			{
				m_EdgeFlags[0]=value;
				ChkOffScr();
			}
		}
		public bool EdgeTopRight
		{
			get { return m_EdgeFlags[1]; }
			set
			{
				m_EdgeFlags[1] = value;
				ChkOffScr();
			}
		}
		public bool EdgeBottomRight
		{
			get { return m_EdgeFlags[2]; }
			set
			{
				m_EdgeFlags[2] = value;
				ChkOffScr();
			}
		}
		public bool EdgeBottomLeft
		{
			get { return m_EdgeFlags[3]; }
			set
			{
				m_EdgeFlags[3] = value;
				ChkOffScr();
			}
		}
		public MGLayerEdge(MGForm m) : base(m)
		{
			Name = "Edge";
			m_Size = new Size(400, 400);
			m_Fill = MG_COL.White;
			m_FillOpacity = 100;
			m_EdgeSize = new Size(20, 20);
			m_IsKagi = true;

		}
		// ***************************************************************************
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			SolidBrush sb = new SolidBrush(m_ForeColor);
			try
			{
				if (IsClear) g.Clear(Color.Transparent);

				Rectangle r = MarginRect(rct);
				sb.Color = GetColors(m_Fill, m_FillOpacity);

				Rectangle r2;
				if (m_EdgeFlags[0])
				{
					r2 = new Rectangle(r.Left, r.Top, m_EdgeSize.Width, m_EdgeSize.Height);
					if (m_IsKagi)
					{
						m_kp.Rct = r2;
						m_kp.Styles = KagiStyles.TopLeft;
						MGLayerKagi.DrawKagi(g, sb, m_kp);
					}
					else
					{
						g.FillRectangle(sb, r2);
					}
				}
				if (m_EdgeFlags[1])
				{
					r2 = new Rectangle(r.Right - m_EdgeSize.Width, r.Top, m_EdgeSize.Width, m_EdgeSize.Height);
					if (m_IsKagi)
					{
						m_kp.Rct = r2;
						m_kp.Styles = KagiStyles.TopRight;
						MGLayerKagi.DrawKagi(g, sb, m_kp);
					}
					else
					{
						g.FillRectangle(sb, r2);
					}
				}
				if (m_EdgeFlags[2])
				{
					r2 = new Rectangle(r.Right - m_EdgeSize.Width, r.Bottom - m_EdgeSize.Height, m_EdgeSize.Width, m_EdgeSize.Height);
					if (m_IsKagi)
					{
						m_kp.Rct = r2;
						m_kp.Styles = KagiStyles.BottomRight;
						MGLayerKagi.DrawKagi(g, sb, m_kp);
					}
					else
					{
						g.FillRectangle(sb, r2);
					}
				}
				if (m_EdgeFlags[3])
				{
					r2 = new Rectangle(r.Left, r.Bottom - m_EdgeSize.Height, m_EdgeSize.Width, m_EdgeSize.Height);
					if (m_IsKagi)
					{
						m_kp.Rct = r2;
						m_kp.Styles = KagiStyles.BottomLeft;
						MGLayerKagi.DrawKagi(g, sb, m_kp);
					}
					else
					{
						g.FillRectangle(sb, r2);
					}
				}

			}
			finally
			{
				sb.Dispose();
			}
		}
		public override List<Control> ParamsParam()
		{
			List<Control> PList = new List<Control>();

			EditSize m_size = new EditSize();
			m_size.SetCaptionPropName("EdgeSize");
			PList.Add(m_size);

			EditBool m_ik = new EditBool();
			m_ik.SetCaptionPropName("IsKagi");
			PList.Add(m_ik);

			EditBool m_k0 = new EditBool();
			m_k0.SetCaptionPropName("EdgeTopLeft");
			PList.Add(m_k0);
			EditBool m_k1 = new EditBool();
			m_k1.SetCaptionPropName("EdgeTopRight");
			PList.Add(m_k1);
			EditBool m_k2 = new EditBool();
			m_k2.SetCaptionPropName("EdgeBottomRight");
			PList.Add(m_k2);
			EditBool m_k3 = new EditBool();
			m_k3.SetCaptionPropName("EdgeBottomLeft");
			PList.Add(m_k3);

			EditFloat m_th = new EditFloat();
			m_th.SetCaptionPropName("TopHeight");
			m_th.SetValueMinMax(0, 1000);
			PList.Add(m_th);

			EditFloat m_bh = new EditFloat();
			m_bh.SetCaptionPropName("BottomHeight");
			m_bh.SetValueMinMax(0, 1000);
			PList.Add(m_bh);

			EditFloat m_lw = new EditFloat();
			m_lw.SetCaptionPropName("LeftWidth");
			m_lw.SetValueMinMax(0, 1000);
			PList.Add(m_lw);

			EditFloat m_rw = new EditFloat();
			m_rw.SetCaptionPropName("RightWidth");
			m_rw.SetValueMinMax(0, 1000);
			PList.Add(m_rw);

			return PList;

		}
		public override List<Control> ParamsColors()
		{
			List<Control> PList = new List<Control>();

			EditMGColors m_B = new EditMGColors();
			m_B.SetCaptionPropName("Fill");
			PList.Add(m_B);

			EditFloat m_BOpacity = new EditFloat();
			m_BOpacity.SetCaptionPropName("FillOpacity");
			m_BOpacity.SetValueMinMax(0, 100);
			PList.Add(m_BOpacity);

			return PList;
		}
		// ***************************************************************************
		public override JsonObject ToJson()
		{
			MGj jn = new MGj(base.ToJson());
			jn.SetMGStyle(MGStyle);
			jn.SetValueSize("EdgeSize", m_EdgeSize);
			jn.SetValue("IsKagi", m_IsKagi);
			jn.SetValue("EdgeTopLeft", m_EdgeFlags[0]);
			jn.SetValue("EdgeTopRight", m_EdgeFlags[1]);
			jn.SetValue("EdgeBottomRight", m_EdgeFlags[2]);
			jn.SetValue("EdgeBottomLeft", m_EdgeFlags[3]);

			jn.SetValue("TopHeight", m_kp.TopHeight);
			jn.SetValue("BottomHeight", m_kp.BottomHeight);
			jn.SetValue("LeftWidth", m_kp.LeftWidth);
			jn.SetValue("RightWidth", m_kp.RightWidth);
			return jn.Obj;
		}
		// ***************************************************************************
		public override void FromJson(JsonObject jo)
		{
			bool ret = false;
			if (jo == null) return;
			base.FromJson(jo);
			MGj jn = new MGj(jo);
			if (jn.GetSize("EdgeSize", ref m_EdgeSize) == false) ret = false;
			if (jn.GetBool("IsKagi", ref m_IsKagi) == false) ret = false;

			if (jn.GetBool("EdgeTopLeft", ref m_EdgeFlags[0]) == false) ret = false;
			if (jn.GetBool("EdgeTopRight", ref m_EdgeFlags[1]) == false) ret = false;
			if (jn.GetBool("EdgeBottomRight", ref m_EdgeFlags[2]) == false) ret = false;
			if (jn.GetBool("EdgeBottomLeft", ref m_EdgeFlags[3]) == false) ret = false;

			if (jn.GetFloat("TopHeight", ref m_kp.TopHeight) == false) ret = false;
			if (jn.GetFloat("BottomHeight", ref m_kp.BottomHeight) == false) ret = false;
			if (jn.GetFloat("LeftWidth", ref m_kp.LeftWidth) == false) ret = false;
			if (jn.GetFloat("RightWidth", ref m_kp.RightWidth) == false) ret = false;

		}
	}
}
