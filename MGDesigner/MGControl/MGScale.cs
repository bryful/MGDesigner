using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGDesigner
{
	public partial class MGScale : Z_MG
	{
		private ScaleStlye m_ScaleStlye = ScaleStlye.Vur;
		[Category("_MG")]
		public ScaleStlye ScaleStlye
		{
			get { return m_ScaleStlye; }
			set
			{
				m_ScaleStlye = value;
				this.Invalidate();
			}
		}
		private float m_Offset = 0;
		[Category("_MG")]
		public float Offset
		{
			get { return m_Offset; }
			set
			{
				m_Offset = value;
				this.Invalidate();
			}
		}
		private float m_Inter = 6;
		[Category("_MG")]
		public float Inter
		{
			get { return m_Inter; }
			set
			{
				m_Inter = value;
				this.Invalidate();
			}
		}
		private float m_Weight = 2;
		[Category("_MG")]
		public float Weight
		{
			get { return m_Weight; }
			set
			{
				m_Weight = value;
				this.Invalidate();
			}
		}

		private Color[] m_ScaleColor = new Color[]
		{
			Color.White,
			Color.Gray,
			Color.Gray,
			Color.LightGray,
			Color.Gray,
			Color.Gray
		};
		[Category("_MG")]
		public Color [] ScaleColor
		{
			get { return m_ScaleColor; }
			set
			{
				m_ScaleColor = value;
				this.Invalidate();
			}
		}
		private float[] m_WeightPers = new float[]
		{
			100,
			50,
			50,
			75,
			50,
			50
		};
		[Category("_MG")]
		public float[] WeightPers
		{
			get { return m_WeightPers; }
			set
			{
				m_WeightPers = value;
				this.Invalidate();
			}
		}
		public float[] m_LengthPers = new float[] { 100, 50, 50, 75, 50, 50 };
		[Category("_MG")]
		public float[] LengthPers
		{
			get { return m_LengthPers; }
			set
			{
				m_LengthPers = value;
				this.Invalidate();
			}
		}
		public MGScale()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Draw(pe.Graphics);
		}
		protected override void Draw(Graphics g)
		{
			base.Draw(g);

			Pen p = new Pen(this.ForeColor);
			try
			{

				MGDrawScale sc = new MGDrawScale();
				switch(m_ScaleStlye)
				{
					case ScaleStlye.Vur:
					case ScaleStlye.Left:
					case ScaleStlye.Right:
						sc.length = this.Width;
						break;
					case ScaleStlye.Hor:
					case ScaleStlye.Top:
					case ScaleStlye.Bottom:
						sc.length = this.Height;
						break;
				}
				sc.BaseInter = m_Inter;
				sc.Weight = m_Weight;
				sc.WeightPers = m_WeightPers;
				sc.LengthPers = m_LengthPers;
				sc.Colors = m_ScaleColor;
				sc.Offset = m_Offset;
				sc.Draw(g, p, this.ClientRectangle, m_ScaleStlye);

			}
			catch
			{
				MessageBox.Show("a");
			}
			finally
			{
				p.Dispose();
			}
		}
	}
}
