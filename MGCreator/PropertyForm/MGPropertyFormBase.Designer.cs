namespace MGCreator
{
	partial class MGPropertyFormBase
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
			this.mgPropertyPanelBase1 = new MGCreator.MGPropertyPanelBase();
			this.SuspendLayout();
			// 
			// mgPropertyPanelBase1
			// 
			this.mgPropertyPanelBase1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mgPropertyPanelBase1.BackColor = System.Drawing.Color.Transparent;
			this.mgPropertyPanelBase1.Caption = "PropertyPanel";
			this.mgPropertyPanelBase1.IsOpen = true;
			this.mgPropertyPanelBase1.Location = new System.Drawing.Point(12, 28);
			this.mgPropertyPanelBase1.MGForm = null;
			this.mgPropertyPanelBase1.MGStyle = MGCreator.MGStyle.ALL;
			this.mgPropertyPanelBase1.Name = "mgPropertyPanelBase1";
			this.mgPropertyPanelBase1.Size = new System.Drawing.Size(335, 410);
			this.mgPropertyPanelBase1.TabIndex = 0;
			// 
			// MGPropertyFormBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 450);
			this.Controls.Add(this.mgPropertyPanelBase1);
			this.Name = "MGPropertyFormBase";
			this.Text = "Property";
			this.ResumeLayout(false);

		}

		#endregion

		private MGPropertyPanelBase mgPropertyPanelBase1;
	}
}