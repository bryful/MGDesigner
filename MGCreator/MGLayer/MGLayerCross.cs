using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace MGCreator
{
    internal class MGLayerCross : MGLayer
    {
        private float m_CrossWeight = 20;
        public float CrossWeight
        {
            get { return m_CrossWeight; }
            set
            {
                m_CrossWeight = value;
                ChkOffScr();
            }
        }
        public MGLayerCross(MGForm m) : base(m)
        {
            Name = "Cross";
            m_Size = new Size(100,100);
            m_Fill = MG_COLORS.White;
            m_FillOpacity = 100;
            m_Line = MG_COLORS.White;
            m_LineOpacity = 0;
            m_LineWeight = 1;
        }
		// ***************************************************************************
        private PointF[] CrossRegion(RectangleF r, float wt)
        {
			PointF[] ps = new PointF[12];

			float cx = r.Left + (float)r.Width / 2;
			float cy = r.Top + (float)r.Height / 2;
			float w = wt / 2;
			ps[0] = new PointF(cx - w, r.Top);
			ps[1] = new PointF(cx + w, r.Top);
			ps[2] = new PointF(cx + w, cy - w);
			ps[3] = new PointF(r.Right, cy - w);
			ps[4] = new PointF(r.Right, cy + w);
			ps[5] = new PointF(cx + w, cy + w);
			ps[6] = new PointF(cx + w, r.Bottom);
			ps[7] = new PointF(cx - w, r.Bottom);
			ps[8] = new PointF(cx - w, cy + w);
			ps[9] = new PointF(r.Left, cy + w);
			ps[10] = new PointF(r.Left, cy - w);
			ps[11] = new PointF(cx - w, cy - w);
            return ps;
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
                if( (m_Fill!=MG_COLORS.Transparent)&&(m_FillOpacity>0))
                {
                    sb.Color = GetColors(m_Fill, m_FillOpacity);
					PointF[] ps = CrossRegion(r, m_CrossWeight);
                    g.FillPolygon(sb, ps);
				}

				if ((m_Line != MG_COLORS.Transparent) && (m_LineOpacity > 0)&&(m_CrossWeight>0))
				{
					p.Color = GetColors(m_Line, m_LineOpacity);
                    p.Width = m_LineWeight;
                    float ww = m_LineWeight / 2;
                    RectangleF rf = new RectangleF(r.Left + ww, r.Top + ww, r.Width - m_LineWeight, r.Height - m_LineWeight);
					PointF[] ps = CrossRegion(rf, m_CrossWeight-m_LineWeight);
					g.DrawPolygon(p, ps);
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
			PList.AddRange( base.ParamsParam());

			EditInt m_crossw = new EditInt();
			m_crossw.SetCaptionPropName("CrossWeight", typeof(float));
			PList.Add(m_crossw);

			EditInt m_LineWidth = new EditInt();
			m_LineWidth.SetCaptionPropName("LineWeight", typeof(float));
			PList.Add(m_LineWidth);

			return PList;

		}
		// ***************************************************************************
		public override JsonObject ToJson()
		{

			MGj jn = new MGj(base.ToJson());
			jn.SetValue("CrossWeight", m_CrossWeight);
			return jn.Obj;
		}
		public override void FromJson(JsonObject jo)
		{
			bool ret = false;
			if (jo == null) return;
			base.FromJson(jo);
			MGj jn = new MGj(jo);
			if (jn.GetFloat("CrossWeight", ref m_CrossWeight) == false) ret = false;


		}
	}
}
