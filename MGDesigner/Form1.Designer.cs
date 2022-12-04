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
			this.editTriangleStyle1 = new MGCreator.EditTriangleStyle();
			this.SuspendLayout();
			// 
			// editTriangleStyle1
			// 
			this.editTriangleStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.editTriangleStyle1.Caption = "TrainglrStyle";
			this.editTriangleStyle1.CaptionWidth = 90;
			this.editTriangleStyle1.ForeColor = System.Drawing.Color.LightGray;
			this.editTriangleStyle1.Location = new System.Drawing.Point(231, 273);
			this.editTriangleStyle1.MaximumSize = new System.Drawing.Size(0, 20);
			this.editTriangleStyle1.MGForm = null;
			this.editTriangleStyle1.MinimumSize = new System.Drawing.Size(220, 20);
			this.editTriangleStyle1.Name = "editTriangleStyle1";
			this.editTriangleStyle1.Size = new System.Drawing.Size(220, 20);
			this.editTriangleStyle1.TabIndex = 0;
			this.editTriangleStyle1.Text = "editTriangleStyle1";
			this.editTriangleStyle1.TrainglrStyle = MGCreator.MGLayer.TriangleStyle.Center;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(621, 524);
			this.Controls.Add(this.editTriangleStyle1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private EditTriangleStyle editTriangleStyle1;
	}
}