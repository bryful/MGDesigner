namespace MGCreator
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sizeRootGrid1 = new MGCreator.SizeRootGrid();
			this.SuspendLayout();
			// 
			// sizeRootGrid1
			// 
			this.sizeRootGrid1.BackColor = System.Drawing.Color.Black;
			this.sizeRootGrid1.BaseColor = System.Drawing.Color.DimGray;
			this.sizeRootGrid1.CornerLock = true;
			this.sizeRootGrid1.ForeColor = System.Drawing.Color.LightGray;
			this.sizeRootGrid1.IsSmall = false;
			this.sizeRootGrid1.Location = new System.Drawing.Point(299, 321);
			this.sizeRootGrid1.MaximumSize = new System.Drawing.Size(104, 32);
			this.sizeRootGrid1.MinimumSize = new System.Drawing.Size(104, 32);
			this.sizeRootGrid1.Name = "sizeRootGrid1";
			this.sizeRootGrid1.PushColor = System.Drawing.Color.LightGray;
			this.sizeRootGrid1.PushColor2 = System.Drawing.Color.White;
			this.sizeRootGrid1.Size = new System.Drawing.Size(104, 32);
			this.sizeRootGrid1.SizeRoot = MGCreator.SizeRootType.BottomRight;
			this.sizeRootGrid1.TabIndex = 0;
			this.sizeRootGrid1.Text = "sizeRootGrid1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(621, 524);
			this.Controls.Add(this.sizeRootGrid1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private EditLayerLocation editControlPoint1;
		private EditLayerSize editControlSize1;
		private SizeRootGrid sizeRootGrid1;
	}
}