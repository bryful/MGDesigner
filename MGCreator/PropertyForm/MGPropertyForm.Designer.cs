namespace MGCreator
{
	partial class MGPropertyForm
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
			this.mgPropertyPanel1 = new MGCreator.MGPropertyPanel();
			this.SuspendLayout();
			// 
			// mgPropertyPanel1
			// 
			this.mgPropertyPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mgPropertyPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.mgPropertyPanel1.Location = new System.Drawing.Point(9, 23);
			this.mgPropertyPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.mgPropertyPanel1.MGForm = null;
			this.mgPropertyPanel1.Name = "mgPropertyPanel1";
			this.mgPropertyPanel1.Size = new System.Drawing.Size(266, 409);
			this.mgPropertyPanel1.TabIndex = 0;
			// 
			// MGPropertyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 441);
			this.Controls.Add(this.mgPropertyPanel1);
			this.Name = "MGPropertyForm";
			this.Text = "Property";
			this.ResumeLayout(false);

		}

		#endregion

		private MGPropertyPanel mgPropertyPanel1;
	}
}