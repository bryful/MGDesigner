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
			this.mgPropertyPanel1 = new MGCreator.MGPropertyPanel();
			this.SuspendLayout();
			// 
			// mgPropertyPanel1
			// 
			this.mgPropertyPanel1.BackColor = System.Drawing.Color.Transparent;
			this.mgPropertyPanel1.Caption = "PropertyPanel";
			this.mgPropertyPanel1.ForeColor = System.Drawing.Color.LightGray;
			this.mgPropertyPanel1.IsOpen = true;
			this.mgPropertyPanel1.Location = new System.Drawing.Point(181, 96);
			this.mgPropertyPanel1.MGForm = null;
			this.mgPropertyPanel1.Name = "mgPropertyPanel1";
			this.mgPropertyPanel1.Size = new System.Drawing.Size(345, 328);
			this.mgPropertyPanel1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(621, 524);
			this.Controls.Add(this.mgPropertyPanel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private MGPropertyPanel mgPropertyPanel1;
	}
}