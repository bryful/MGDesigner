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
			this.editFloat1 = new MGCreator.EditFloat();
			this.SuspendLayout();
			// 
			// editFloat1
			// 
			this.editFloat1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.editFloat1.Caption = "float";
			this.editFloat1.CaptionWidth = 90;
			this.editFloat1.ForeColor = System.Drawing.Color.LightGray;
			this.editFloat1.Location = new System.Drawing.Point(295, 257);
			this.editFloat1.MaximumSize = new System.Drawing.Size(0, 20);
			this.editFloat1.MGForm = null;
			this.editFloat1.MinimumSize = new System.Drawing.Size(220, 20);
			this.editFloat1.Name = "editFloat1";
			this.editFloat1.Size = new System.Drawing.Size(220, 20);
			this.editFloat1.TabIndex = 0;
			this.editFloat1.Text = "editFloat1";
			this.editFloat1.Value = 0F;
			this.editFloat1.ValueMax = 32000F;
			this.editFloat1.ValueMin = -32000F;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(621, 524);
			this.Controls.Add(this.editFloat1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private EditLayerLocation editControlPoint1;
		private EditLayerSize editControlSize1;
		private EditFloat editFloat1;
	}
}