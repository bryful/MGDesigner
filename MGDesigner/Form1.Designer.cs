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
			this.mgColorComb1 = new MGCreator.MGColorComb();
			this.SuspendLayout();
			// 
			// mgColorComb1
			// 
			this.mgColorComb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.mgColorComb1.FormattingEnabled = true;
			this.mgColorComb1.Items.AddRange(new object[] {
            "White",
            "WhiteTrue",
            "Black",
            "BLackTrue",
            "Gray",
            "GrayLight",
            "GrayDrak",
            "GrayDrakDark",
            "Red",
            "RedLight",
            "RedDark",
            "Blood",
            "Pink",
            "Green",
            "GreenTrue",
            "GreenLight",
            "GreenDark",
            "Emerald",
            "Blue",
            "BlueTrue",
            "BlueLight",
            "BlueDark",
            "SkayBlue",
            "Cyan",
            "CyanLight",
            "CyanDark",
            "Yellow",
            "YellowLight",
            "YellowDark",
            "YellowGreen",
            "Cream",
            "Magenta",
            "MagentaLight",
            "MagentaDark",
            "Orange",
            "OrangeLight",
            "OrangeDark",
            "RedTrue",
            "ForeColor",
            "BackColor",
            "Transparent"});
			this.mgColorComb1.Location = new System.Drawing.Point(298, 283);
			this.mgColorComb1.Name = "mgColorComb1";
			this.mgColorComb1.Size = new System.Drawing.Size(128, 23);
			this.mgColorComb1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(621, 524);
			this.Controls.Add(this.mgColorComb1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private MGColorComb mgColorComb1;
	}
}