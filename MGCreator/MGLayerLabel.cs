using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MGCreator
{
	public class MGLayerLabel : MGLayer
	{
		public new readonly MGStyle MGStyle = MGStyle.Label;
		private Font m_Font = new Font("System",8);
		public Font Font
		{
			get { return m_Font; }
			set
			{
				m_Font = value;
				ChkOffScr();
			}
		}
		private string m_Text = "Label";
		public string Text
		{
			get { return m_Text; }
			set
			{
				m_Text = value;
				ChkOffScr();
			}
		}
		private StringFormat m_sf = new StringFormat();
		public SizeRootType Alignment
		{
			get {
				SizeRootType ret = SizeRootType.Left;
				if(m_sf.Alignment == StringAlignment.Near)
				{
					switch(m_sf.LineAlignment)
					{
						case StringAlignment.Near:
							ret = SizeRootType.TopLeft;
							break;
						case StringAlignment.Center:
							ret = SizeRootType.Left;
							break;
						case StringAlignment.Far:
							ret = SizeRootType.BottomLeft;
							break;

					}
				}else if (m_sf.Alignment == StringAlignment.Center)
				{
					switch (m_sf.LineAlignment)
					{
						case StringAlignment.Near:
							ret = SizeRootType.Top;
							break;
						case StringAlignment.Center:
							ret = SizeRootType.Center;
							break;
						case StringAlignment.Far:
							ret = SizeRootType.Bottom;
							break;

					}
				}
				else if (m_sf.Alignment == StringAlignment.Far)
				{
					switch (m_sf.LineAlignment)
					{
						case StringAlignment.Near:
							ret = SizeRootType.TopRight;
							break;
						case StringAlignment.Center:
							ret = SizeRootType.Right;
							break;
						case StringAlignment.Far:
							ret = SizeRootType.BottomRight;
							break;

					}
				}
				return ret;
			}
			set
			{
				switch(value)
				{
					case SizeRootType.TopLeft:
						m_sf.Alignment = StringAlignment.Near;
						m_sf.LineAlignment = StringAlignment.Near;
						break;
					case SizeRootType.Top:
						m_sf.Alignment = StringAlignment.Center;
						m_sf.LineAlignment = StringAlignment.Near;
						break;
					case SizeRootType.TopRight:
						m_sf.Alignment = StringAlignment.Far;
						m_sf.LineAlignment = StringAlignment.Near;
						break;
					case SizeRootType.Right:
						m_sf.Alignment = StringAlignment.Far;
						m_sf.LineAlignment = StringAlignment.Center;
						break;
					case SizeRootType.BottomRight:
						m_sf.Alignment = StringAlignment.Far;
						m_sf.LineAlignment = StringAlignment.Far;
						break;
					case SizeRootType.Bottom:
						m_sf.Alignment = StringAlignment.Center;
						m_sf.LineAlignment = StringAlignment.Far;
						break;
					case SizeRootType.BottomLeft:
						m_sf.Alignment = StringAlignment.Near;
						m_sf.LineAlignment = StringAlignment.Far;
						break;
					case SizeRootType.Left:
						m_sf.Alignment = StringAlignment.Near;
						m_sf.LineAlignment = StringAlignment.Center;
						break;
					case SizeRootType.Center:
						m_sf.Alignment = StringAlignment.Center;
						m_sf.LineAlignment = StringAlignment.Center;
						break;
				}

				ChkOffScr();
			}
		}
		public MGLayerLabel(MGForm m) : base(m)
		{
			Name = "Label";
			m_Size = new Size(120, 25);
			m_Fill = MG_COL.White;
			m_FillOpacity = 100;

		}       
		// ***************************************************************************
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			SolidBrush sb = new SolidBrush(m_ForeColor);
			Pen p = new Pen(m_ForeColor);
			p.Width = 1;
			try
			{
				if (IsClear) g.Clear(Color.Transparent);

				Rectangle r = MarginRect(rct);
				if ((m_Fill != MG_COL.Transparent) && (m_FillOpacity > 0))
				{
					sb.Color = GetColors(m_Fill, m_FillOpacity);
					g.DrawString(m_Text, m_Font, sb, r, m_sf);
				}

			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}
		}
		public override List<Control> ParamsParam()
		{
			List<Control> PList = new List<Control>();
			//PList.AddRange(base.ParamsParam());

			EditFont m_f = new EditFont();
			m_f.SetCaptionPropName("Font");
			PList.Add(m_f);

			EditAlignment m_a = new EditAlignment();
			m_a.SetCaptionPropName("Alignment");
			PList.Add(m_a);


			EditString m_s = new EditString();
			m_s.SetCaptionPropName("Text");
			PList.Add(m_s);

			return PList;
		}

		public override List<Control> ParamsColors()
		{
			List<Control> PList = new List<Control>();


			EditMGColors m_fm = new EditMGColors();
			m_fm.SetCaptionPropName("Fill");
			PList.Add(m_fm);

			EditFloat m_fmo = new EditFloat();
			m_fmo.SetCaptionPropName("FillOpacity");
			m_fmo.SetValueMinMax(0, 100);
			PList.Add(m_fmo);

			//PList.AddRange(base.ParamsColors());
			return PList;
		}
		// ***************************************************************************
		public override JsonObject ToJson()
		{

			MGj jn = new MGj(base.ToJson());
			jn.SetMGStyle(MGStyle);
			jn.SetValue("FontName", m_Font.Name);
			jn.SetValue("FontSize", (float)m_Font.Size);
			jn.SetValue("FontStyle", (int)m_Font.Style);
			jn.SetValue("Text", (string)m_Text);
			jn.SetValue("Alignment", (int)Alignment);

			return jn.Obj;
		}
		public override void FromJson(JsonObject jo)
		{
			bool ret = false;
			if (jo == null) return;
			base.FromJson(jo);
			MGj jn = new MGj(jo);
			string n = "System";
			if (jn.GetStr("FontName", ref n) == false) ret = false;
			float sz = 12;
			if (jn.GetFloat("FontName", ref sz) == false) ret = false;
			int  st = 12;
			if (jn.GetInt("FontName", ref st) == false) ret = false;
			m_Font = new Font(n, sz, (FontStyle)st);

			if (jn.GetInt("Alignment", ref st) == false) ret = false;
			Alignment = (SizeRootType)st;


		}
	}
}
