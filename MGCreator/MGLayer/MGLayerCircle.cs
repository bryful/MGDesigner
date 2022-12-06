using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MGCreator
{
    public class MGLayerCircle : MGLayer
    {
		public new readonly MGStyle MGStyle = MGStyle.Circle;
		public MGLayerCircle(MGForm m) : base(m)
        {
            Name = "Circle";
            m_Size = new Size(70, 70);
            m_Fill = MG_COL.Black;
            m_FillOpacity = 0;
            m_Line = MG_COL.White;
            m_LineOpacity = 100;
            m_LineWeight = 2;
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
                float cx = r.Left + (float)r.Width / 2;
                float cy = r.Top + (float)r.Height / 2;
                float radius = r.Width;
                if (radius > r.Height) radius = r.Height;
                radius /= 2;
                Rectangle r2 = new Rectangle((int)(cx - radius), (int)(cy - radius), (int)(radius * 2), (int)(radius * 2));
                if (m_Fill != MG_COL.Transparent && m_FillOpacity > 0)
                {
                    sb.Color = GetColors(m_Fill, m_FillOpacity);
                    g.FillEllipse(sb, r2);
                }

                if (m_Line != MG_COL.Transparent && m_LineOpacity > 0 && m_LineWeight > 0)
                {
                    radius -= m_LineWeight / 2;
                    r2 = new Rectangle((int)(cx - radius), (int)(cy - radius), (int)(radius * 2), (int)(radius * 2));
                    p.Color = GetColors(m_Line, m_LineOpacity);
                    p.Width = m_LineWeight;
                    g.DrawEllipse(p, r2);
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

            EditFloat m_LineWidth = new EditFloat();
            m_LineWidth.SetCaptionPropName("LineWeight");
            PList.Add(m_LineWidth);

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

            EditMGColors m_C = new EditMGColors();
            m_C.SetCaptionPropName("Line");
            PList.Add(m_C);

            EditFloat m_CO = new EditFloat();
            m_CO.SetCaptionPropName("LineOpacity");
            m_CO.SetValueMinMax(0, 100);
            PList.Add(m_CO);


            return PList;
        }
		// ***************************************************************************
		public override JsonObject ToJson()
		{
			MGj jn = new MGj(base.ToJson());
			jn.SetMGStyle(MGStyle);
			return jn.Obj;
		}
		// ***************************************************************************
		public override void FromJson(JsonObject jo)
		{
			bool ret = false;
			if (jo == null) return;
			base.FromJson(jo);
			MGj jn = new MGj(jo);
			int v = 0;

		}
	}
}
