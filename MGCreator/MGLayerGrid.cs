using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGCreator
{
	public class MGLayerGrid : MGLayer
	{
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
		protected MG_COLORS m_Grid = MG_COLORS.White;
		[Category("_MG")]
		public MG_COLORS Grid
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
		public float GridColorOpacity
		{
			get { return GridColorOpacity; }
			set
			{
				GridColorOpacity = value;
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
			Name = "Gtid";
			m_Size = new Size(200, 200);
			m_Fill = MG_COLORS.Black;
			m_FillOpacity = 0;
			m_Frame = MG_COLORS.White;
			m_FrameOpacity = 0;
			m_FrameWeight = new Padding(2,2,2,2);

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
				float cx = (float)rct2.Left + (float)rct2.Width / 2 + m_GridOffset.X;
				float cy = (float)rct2.Top + (float)rct2.Height / 2 + m_GridOffset.Y;
				if ((m_LineOpacity > 0) && (m_Line != MG_COLORS.Transparent))
				{
					p.Color = GetColors(m_Line, m_LineOpacity);
					p.Width = m_LineWeight;

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
			PList.AddRange(base.ParamsParam());

			EditSize m_gsize = new EditSize();
			m_gsize.SetCaptionPropName("GridSize", typeof(Size));
			PList.Add(m_gsize);


			EditPoint m_goffset = new EditPoint();
			m_goffset.SetCaptionPropName("GridOffset", typeof(Size));
			PList.Add(m_goffset);

			EditNumber m_lw = new EditNumber();
			m_lw.SetCaptionPropName("GridWeight", typeof(float));
			PList.Add(m_lw);

			EditPadding m_gfw = new EditPadding();
			m_gfw.SetCaptionPropName("FrameWeight", typeof(Padding));
			PList.Add(m_gfw);

			return PList;

		}
		public override List<Control> ParamsColors()
		{
			List<Control> PList = new List<Control>();

			EditMGColors m_gc = new EditMGColors();
			m_gc.SetCaptionPropName("Grid", typeof(MG_COLORS));
			PList.Add(m_gc);

			EditNumber m_gco = new EditNumber();
			m_gco.SetCaptionPropName("GridOpacity", typeof(float));
			m_gco.SetValueMinMax(0, 100);
			PList.Add(m_gco);

			EditMGColors m_gf = new EditMGColors();
			m_gc.SetCaptionPropName("Fill", typeof(MG_COLORS));
			PList.Add(m_gc);
			EditNumber m_gfo = new EditNumber();
			m_gfo.SetCaptionPropName("FillOpacity", typeof(float));
			m_gfo.SetValueMinMax(0, 100);
			PList.Add(m_gfo);

			EditMGColors m_fm = new EditMGColors();
			m_fm.SetCaptionPropName("Frame", typeof(MG_COLORS));
			PList.Add(m_fm);
			EditNumber m_fmo = new EditNumber();
			m_fmo.SetCaptionPropName("FrameOpacity", typeof(float));
			m_fmo.SetValueMinMax(0, 100);
			PList.Add(m_gco);

			PList.AddRange(base.ParamsColors());
			return PList;
		}
	}
}
