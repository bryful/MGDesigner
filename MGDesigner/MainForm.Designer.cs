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
			this.mgScale1 = new MGDesigner.MGScale();
			this.SuspendLayout();
			// 
			// mgScale1
			// 
			this.mgScale1.BackColor = System.Drawing.Color.Transparent;
			this.mgScale1.CenterX = 96.5F;
			this.mgScale1.CenterY = 267F;
			this.mgScale1.ControlPos = MGDesigner.ControlPos.None;
			this.mgScale1.DrawIndex = 0;
			this.mgScale1.DrawMargin = new System.Windows.Forms.Padding(30);
			this.mgScale1.ForeColor = System.Drawing.Color.White;
			this.mgScale1.Inter = 40F;
			this.mgScale1.IsFull = false;
			this.mgScale1.Length = 20F;
			this.mgScale1.LengthHPer = 0.5F;
			this.mgScale1.Location = new System.Drawing.Point(12, 66);
			this.mgScale1.MGScale_ = null;
			this.mgScale1.Name = "mgScale1";
			this.mgScale1.Offset = 0F;
			this.mgScale1.PosMargin = new System.Windows.Forms.Padding(0);
			this.mgScale1.ScaleColor = MGDesigner.MG_COLORS.White;
			this.mgScale1.ScaleColorH = MGDesigner.MG_COLORS.GrayLight;
			this.mgScale1.ScaleType = MGDesigner.MGScaleType.Left;
			this.mgScale1.Size = new System.Drawing.Size(169, 402);
			this.mgScale1.TabIndex = 0;
			this.mgScale1.Text = "mgScale1";
			this.mgScale1.Weight = 4F;
			this.mgScale1.WeightH = 2F;
			// 
			// MainForm
			// 
			this.Anti = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Back = MGDesigner.MG_COLORS.Black;
			this.BackColor = System.Drawing.Color.Turquoise;
			this.ClientSize = new System.Drawing.Size(1103, 656);
			this.Controls.Add(this.mgScale1);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MGControls = new string[] {
        "mgScale1"};
			this.Name = "MainForm";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private MGScale mgScale1;
	}
}