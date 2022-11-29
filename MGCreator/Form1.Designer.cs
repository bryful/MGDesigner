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
			this.editControlPoint1 = new MGCreator.EditControlPoint();
			this.SuspendLayout();
			// 
			// editControlPoint1
			// 
			this.editControlPoint1.BackColor = System.Drawing.Color.Black;
			this.editControlPoint1.Caption = "Position";
			this.editControlPoint1.CaptionWidth = 90;
			this.editControlPoint1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
			this.editControlPoint1.Location = new System.Drawing.Point(167, 207);
			this.editControlPoint1.MaximumSize = new System.Drawing.Size(0, 20);
			this.editControlPoint1.MGForm = null;
			this.editControlPoint1.MinimumSize = new System.Drawing.Size(220, 20);
			this.editControlPoint1.Name = "editControlPoint1";
			this.editControlPoint1.Point = new System.Drawing.Point(0, 0);
			this.editControlPoint1.PropName = "Fill";
			this.editControlPoint1.Size = new System.Drawing.Size(271, 20);
			this.editControlPoint1.TabIndex = 0;
			this.editControlPoint1.Text = "editControlPoint1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(621, 524);
			this.Controls.Add(this.editControlPoint1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private EditControlPoint editControlPoint1;
	}
}