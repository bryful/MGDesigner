namespace MGDesigner
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mgGrid1 = new MGDesigner.MGGrid();
			this.mgScale1 = new MGDesigner.MGScale();
			this.mgScale2 = new MGDesigner.MGScale();
			this.mgCircleScale1 = new MGDesigner.MGCircleScale();
			this.mgCircle1 = new MGDesigner.MGCircle();
			this.mgCircleScale2 = new MGDesigner.MGCircleScale();
			this.SuspendLayout();
			// 
			// mgGrid1
			// 
			this.mgGrid1.BackColor = System.Drawing.Color.Transparent;
			this.mgGrid1.CenterX = 88.5F;
			this.mgGrid1.CenterY = 539F;
			this.mgGrid1.ControlPos = MGDesigner.ControlPos.None;
			this.mgGrid1.DrawIndex = 0;
			this.mgGrid1.DrawMargin = new System.Windows.Forms.Padding(0);
			this.mgGrid1.ForeColor = System.Drawing.Color.White;
			this.mgGrid1.Frame = MGDesigner.MG_COLORS.White;
			this.mgGrid1.FrameBack = MGDesigner.MG_COLORS.Transparent;
			this.mgGrid1.FrameBackOpacity = 100D;
			this.mgGrid1.FramedWeight = 2;
			this.mgGrid1.FrameOpacity = 100D;
			this.mgGrid1.Grid = MGDesigner.MG_COLORS.Gray;
			this.mgGrid1.GridCenterOffset = ((System.Drawing.PointF)(resources.GetObject("mgGrid1.GridCenterOffset")));
			this.mgGrid1.GridCenterOffsetX = 0F;
			this.mgGrid1.GridCenterOffsetY = 0F;
			this.mgGrid1.GridHeight = 50F;
			this.mgGrid1.GridOpacity = 100D;
			this.mgGrid1.GridWeight = 1F;
			this.mgGrid1.GridWidth = 50F;
			this.mgGrid1.Guide = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.mgGrid1.IsFull = true;
			this.mgGrid1.Location = new System.Drawing.Point(59, 510);
			this.mgGrid1.Name = "mgGrid1";
			this.mgGrid1.PosMargin = new System.Windows.Forms.Padding(0);
			this.mgGrid1.Size = new System.Drawing.Size(59, 58);
			this.mgGrid1.TabIndex = 0;
			this.mgGrid1.Text = "mgGrid1";
			// 
			// mgScale1
			// 
			this.mgScale1.BackColor = System.Drawing.Color.Transparent;
			this.mgScale1.CenterX = 38F;
			this.mgScale1.CenterY = 294F;
			this.mgScale1.ControlPos = MGDesigner.ControlPos.None;
			this.mgScale1.DrawIndex = 1;
			this.mgScale1.DrawMargin = new System.Windows.Forms.Padding(0);
			this.mgScale1.ForeColor = System.Drawing.Color.White;
			this.mgScale1.Guide = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.mgScale1.Inter = 40F;
			this.mgScale1.IsFull = false;
			this.mgScale1.Length = 20F;
			this.mgScale1.LengthHPer = 0.5F;
			this.mgScale1.Location = new System.Drawing.Point(12, 12);
			this.mgScale1.MGScale_ = null;
			this.mgScale1.Name = "mgScale1";
			this.mgScale1.Offset = 0F;
			this.mgScale1.PosMargin = new System.Windows.Forms.Padding(0);
			this.mgScale1.ScaleColor = MGDesigner.MG_COLORS.White;
			this.mgScale1.ScaleColorH = MGDesigner.MG_COLORS.GrayLight;
			this.mgScale1.ScaleType = MGDesigner.MGScaleType.Left;
			this.mgScale1.Size = new System.Drawing.Size(52, 564);
			this.mgScale1.TabIndex = 2;
			this.mgScale1.Text = "mgScale1";
			this.mgScale1.Weight = 4F;
			this.mgScale1.WeightH = 2F;
			// 
			// mgScale2
			// 
			this.mgScale2.BackColor = System.Drawing.Color.Transparent;
			this.mgScale2.CenterX = 762F;
			this.mgScale2.CenterY = 307F;
			this.mgScale2.ControlPos = MGDesigner.ControlPos.None;
			this.mgScale2.DrawIndex = 2;
			this.mgScale2.DrawMargin = new System.Windows.Forms.Padding(0);
			this.mgScale2.ForeColor = System.Drawing.Color.White;
			this.mgScale2.Guide = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.mgScale2.Inter = 40F;
			this.mgScale2.IsFull = false;
			this.mgScale2.Length = 20F;
			this.mgScale2.LengthHPer = 0.5F;
			this.mgScale2.Location = new System.Drawing.Point(736, 26);
			this.mgScale2.MGScale_ = null;
			this.mgScale2.Name = "mgScale2";
			this.mgScale2.Offset = 0F;
			this.mgScale2.PosMargin = new System.Windows.Forms.Padding(0);
			this.mgScale2.ScaleColor = MGDesigner.MG_COLORS.White;
			this.mgScale2.ScaleColorH = MGDesigner.MG_COLORS.GrayLight;
			this.mgScale2.ScaleType = MGDesigner.MGScaleType.Right;
			this.mgScale2.Size = new System.Drawing.Size(52, 562);
			this.mgScale2.TabIndex = 3;
			this.mgScale2.Text = "mgScale2";
			this.mgScale2.Weight = 4F;
			this.mgScale2.WeightH = 2F;
			// 
			// mgCircleScale1
			// 
			this.mgCircleScale1.BackColor = System.Drawing.Color.Transparent;
			this.mgCircleScale1.CenterX = 400F;
			this.mgCircleScale1.CenterY = 300.5F;
			this.mgCircleScale1.CircleScale = null;
			this.mgCircleScale1.ControlPos = MGDesigner.ControlPos.Center;
			this.mgCircleScale1.DrawIndex = 3;
			this.mgCircleScale1.DrawMargin = new System.Windows.Forms.Padding(0);
			this.mgCircleScale1.ForeColor = System.Drawing.Color.White;
			this.mgCircleScale1.Guide = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.mgCircleScale1.IsFull = false;
			this.mgCircleScale1.Length = 20F;
			this.mgCircleScale1.LineWeight = 2F;
			this.mgCircleScale1.Location = new System.Drawing.Point(81, 39);
			this.mgCircleScale1.Name = "mgCircleScale1";
			this.mgCircleScale1.PosMargin = new System.Windows.Forms.Padding(0);
			this.mgCircleScale1.RotValue = MGDesigner.RotValue.Rot10;
			this.mgCircleScale1.ScaleColor = MGDesigner.MG_COLORS.White;
			this.mgCircleScale1.ScaleOpacity = 100D;
			this.mgCircleScale1.Size = new System.Drawing.Size(638, 523);
			this.mgCircleScale1.TabIndex = 4;
			this.mgCircleScale1.Text = "mgCircleScale1";
			// 
			// mgCircle1
			// 
			this.mgCircle1.BackColor = System.Drawing.Color.Transparent;
			this.mgCircle1.CenterX = 400F;
			this.mgCircle1.CenterY = 300F;
			this.mgCircle1.Circle = MGDesigner.MG_COLORS.White;
			this.mgCircle1.CircleFill = MGDesigner.MG_COLORS.Gray;
			this.mgCircle1.CircleFillOpacity = 0D;
			this.mgCircle1.CircleOpacity = 100D;
			this.mgCircle1.ControlPos = MGDesigner.ControlPos.Center;
			this.mgCircle1.DrawIndex = 4;
			this.mgCircle1.DrawMargin = new System.Windows.Forms.Padding(0);
			this.mgCircle1.ForeColor = System.Drawing.Color.White;
			this.mgCircle1.Guide = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.mgCircle1.IsFull = false;
			this.mgCircle1.Location = new System.Drawing.Point(120, 27);
			this.mgCircle1.Name = "mgCircle1";
			this.mgCircle1.PosMargin = new System.Windows.Forms.Padding(0);
			this.mgCircle1.Size = new System.Drawing.Size(560, 546);
			this.mgCircle1.TabIndex = 5;
			this.mgCircle1.Text = "mgCircle1";
			this.mgCircle1.Weight = 4F;
			// 
			// mgCircleScale2
			// 
			this.mgCircleScale2.BackColor = System.Drawing.Color.Transparent;
			this.mgCircleScale2.CenterX = 400.5F;
			this.mgCircleScale2.CenterY = 300.5F;
			this.mgCircleScale2.CircleScale = null;
			this.mgCircleScale2.ControlPos = MGDesigner.ControlPos.Center;
			this.mgCircleScale2.DrawIndex = 5;
			this.mgCircleScale2.DrawMargin = new System.Windows.Forms.Padding(0);
			this.mgCircleScale2.ForeColor = System.Drawing.Color.White;
			this.mgCircleScale2.Guide = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.mgCircleScale2.IsFull = false;
			this.mgCircleScale2.Length = 20F;
			this.mgCircleScale2.LineWeight = 2F;
			this.mgCircleScale2.Location = new System.Drawing.Point(-8, 73);
			this.mgCircleScale2.Name = "mgCircleScale2";
			this.mgCircleScale2.PosMargin = new System.Windows.Forms.Padding(0);
			this.mgCircleScale2.RotValue = MGDesigner.RotValue.Rot90;
			this.mgCircleScale2.ScaleColor = MGDesigner.MG_COLORS.White;
			this.mgCircleScale2.ScaleOpacity = 100D;
			this.mgCircleScale2.Size = new System.Drawing.Size(817, 455);
			this.mgCircleScale2.TabIndex = 6;
			this.mgCircleScale2.Text = "mgCircleScale2";
			// 
			// MainForm
			// 
			this.Anti = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Back = MGDesigner.MG_COLORS.Black;
			this.BackColor = System.Drawing.Color.Turquoise;
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.mgCircleScale2);
			this.Controls.Add(this.mgCircleScale1);
			this.Controls.Add(this.mgScale2);
			this.Controls.Add(this.mgScale1);
			this.Controls.Add(this.mgGrid1);
			this.Controls.Add(this.mgCircle1);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MGControls = new string[] {
        "mgGrid1",
        "mgScale1",
        "mgScale2",
        "mgCircleScale1",
        "mgCircle1",
        "mgCircleScale2"};
			this.Name = "MainForm";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion
		private MGKagiEdge mgKagiEdge1;
		private MGDesigner.MGGrid mgGrid1;
		private MGScale mgScale1;
		private MGScale mgScale2;
		private MGCircleScale mgCircleScale1;
		private MGCircle mgCircle1;
		private MGCircleScale mgCircleScale2;
	}
}