using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MGCreator
{
    public class MGLayerGrid : MGLayer
	{
		public new readonly MGStyle MGStyle = MGStyle.Grid;
		
        protected Size m_GridSize = new Size(100, 100);
        [Category("_MG")]
        public Size GridSize
        {
            get { return m_GridSize; }
            set
            {
                m_GridSize = value;
                ChkOffScr();
            }

        }
        protected MG_COL m_Grid = MG_COL.White;
        [Category("_MG")]
        public MG_COL Grid
        {
            get { return m_Grid; }
            set
            {
                m_Grid = value;
                ChkOffScr();
            }

        }
        protected float m_GridOpacity = 0;
        /// <summary>
        /// 線の透明度
        /// </summary>
        [Category("_MG")]
        public float GridOpacity
        {
            get { return m_GridOpacity; }
            set
            {
				m_GridOpacity = value;
                ChkOffScr();
            }
        }
        protected float m_GridWeight = 2;
        [Category("_MG")]
        public float GridWeight
        {
            get { return m_GridWeight; }
            set
            {
                m_GridWeight = value;
                ChkOffScr();
            }

        }
        protected Point m_GridOffset = new Point(0, 0);
        [Category("_MG")]
        public Point GridOffset
        {
            get { return m_GridOffset; }
            set
            {
                m_GridOffset = value;
                ChkOffScr();
            }

        }
        public MGLayerGrid(MGForm m) : base(m)
        {
            Name = "Grid";
            m_Size = new Size(200, 200);
            m_Grid = MG_COL.White;
            m_GridOpacity = 100;
            m_GridWeight = 1;
			m_Back = MG_COL.Black;
            m_BackOpacity = 0;
            m_Frame = MG_COL.White;
            m_FrameOpacity = 100;
            m_FrameWeight = new Padding(2, 2, 2, 2);
            m_GridOffset = new Point(0, 0);

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
                Rectangle rct2 = MarginRect(rct);

                if (m_Back != MG_COL.Transparent && m_Back > 0)
                {
                    sb.Color = GetColors(m_Back, m_BackOpacity);
                    g.FillRectangle(sb, rct2);
                }

                float cx = rct2.Left + (float)rct2.Width / 2 + m_GridOffset.X;
                float cy = rct2.Top + (float)rct2.Height / 2 + m_GridOffset.Y;
                if (m_GridOpacity > 0 && m_Grid != MG_COL.Transparent)
                {
                    p.Color = GetColors(m_Grid, m_GridOpacity);
                    p.Width = m_GridWeight;

                    // 水平線
                    float y = cy;
                    while (y >= rct2.Top)
                    {
                        g.DrawLine(p, rct2.Left, y, rct2.Right, y);
                        y -= m_GridSize.Height;
                    }
                    y = cy + m_GridSize.Height;
                    while (y < rct2.Bottom)
                    {
                        g.DrawLine(p, rct2.Left, y, rct2.Right, y);
                        y += m_GridSize.Height;
                    }
                    float x = cx;
                    while (x >= rct2.Left)
                    {
                        g.DrawLine(p, x, rct2.Top, x, rct2.Bottom);
                        x -= m_GridSize.Width;
                    }
                    x = cx + m_GridSize.Width;
                    while (x < rct2.Right)
                    {
                        g.DrawLine(p, x, rct2.Top, x, rct2.Bottom);
                        x += m_GridSize.Width;
                    }
                }
                if((m_Frame!=MG_COL.Transparent)||(m_FrameOpacity>0))
                {
					sb.Color = GetColors(m_Frame, m_FrameOpacity);
					MGc.DrawFrame(g, sb, rct2, m_FrameWeight);
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

            EditSize m_gsize = new EditSize();
            m_gsize.SetCaptionPropName("GridSize");
            PList.Add(m_gsize);


            EditPoint m_goffset = new EditPoint();
            m_goffset.SetCaptionPropName("GridOffset");
            PList.Add(m_goffset);

			EditFloat m_lw = new EditFloat();
            m_lw.SetCaptionPropName("GridWeight");
            PList.Add(m_lw);

            EditPadding m_gfw = new EditPadding();
            m_gfw.SetCaptionPropName("FrameWeight");
            PList.Add(m_gfw);

            return PList;

        }
        public override List<Control> ParamsColors()
        {
            List<Control> PList = new List<Control>();

            EditMGColors m_gc = new EditMGColors();
            m_gc.SetCaptionPropName("Grid");
            PList.Add(m_gc);

			EditFloat m_gco = new EditFloat();
            m_gco.SetCaptionPropName("GridOpacity");
            m_gco.SetValueMinMax(0, 100);
            PList.Add(m_gco);

            EditMGColors m_gf = new EditMGColors();
            m_gf.SetCaptionPropName("Back");
            PList.Add(m_gf);

			EditFloat m_gfo = new EditFloat();
            m_gfo.SetCaptionPropName("BackOpacity");
            m_gfo.SetValueMinMax(0, 100);
            PList.Add(m_gfo);

            EditMGColors m_fm = new EditMGColors();
            m_fm.SetCaptionPropName("Frame");
            PList.Add(m_fm);

			EditFloat m_fmo = new EditFloat();
            m_fmo.SetCaptionPropName("FrameOpacity");
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
			jn.SetValueSize("GridSize", m_GridSize);
			jn.SetValue("Grid", (int)m_Grid);
			jn.SetValue("GridOpacity", m_GridOpacity);
			jn.SetValue("GridWeight", m_GridWeight);
			jn.SetValuePoint("GridOffset", m_GridOffset);

			return jn.Obj;
		}
		public override void FromJson(JsonObject jo)
		{
			bool ret = false;
			if (jo == null) return;
			base.FromJson(jo);
			MGj jn = new MGj(jo);
            int v = 0;
			if (jn.GetSize("GridSize", ref m_GridSize) == false) ret = false;
            if (jn.GetInt("Grid", ref v) == false) ret = false; else m_Grid = (MG_COL)v;
			if (jn.GetFloat("GridOpacity", ref m_GridOpacity) == false) ret = false;
			if (jn.GetFloat("GridWeight", ref m_GridWeight) == false) ret = false;
			if (jn.GetPoint("GridOffset", ref m_GridOffset) == false) ret = false;

		}
	}
}
