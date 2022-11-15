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
			this.mgTetragon1 = new MGDesigner.MGTetragon();
			this.mgTetragon2 = new MGDesigner.MGTetragon();
			this.SuspendLayout();
			// 
			// mgTetragon1
			// 
			this.mgTetragon1.Back = MGDesigner.MG_COLOR.Gray;
			this.mgTetragon1.BackColor = System.Drawing.Color.Transparent;
			this.mgTetragon1.BackOpacity = 50D;
			this.mgTetragon1.BottomLeft = 0F;
			this.mgTetragon1.BottomRight = 100F;
			this.mgTetragon1.ForeColor = System.Drawing.Color.White;
			this.mgTetragon1.Location = new System.Drawing.Point(128, 83);
			this.mgTetragon1.MGForm = this;
			this.mgTetragon1.Name = "mgTetragon1";
			this.mgTetragon1.Size = new System.Drawing.Size(303, 188);
			this.mgTetragon1.TabIndex = 0;
			this.mgTetragon1.Text = "mgTetragon1";
			this.mgTetragon1.TopLeft = 0F;
			this.mgTetragon1.TopRight = 100F;
			// 
			// mgTetragon2
			// 
			this.mgTetragon2.Back = MGDesigner.MG_COLOR.Gray;
			this.mgTetragon2.BackColor = System.Drawing.Color.Transparent;
			this.mgTetragon2.BackOpacity = 100D;
			this.mgTetragon2.BottomLeft = 25F;
			this.mgTetragon2.BottomRight = 100F;
			this.mgTetragon2.ForeColor = System.Drawing.Color.White;
			this.mgTetragon2.Location = new System.Drawing.Point(67, 62);
			this.mgTetragon2.MGForm = this;
			this.mgTetragon2.Name = "mgTetragon2";
			this.mgTetragon2.Size = new System.Drawing.Size(218, 93);
			this.mgTetragon2.TabIndex = 1;
			this.mgTetragon2.Text = "mgTetragon2";
			this.mgTetragon2.TopLeft = 0F;
			this.mgTetragon2.TopRight = 75F;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Back = MGDesigner.MG_COLOR.Black;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(484, 374);
			this.Controls.Add(this.mgTetragon2);
			this.Controls.Add(this.mgTetragon1);
			this.Edge = MGDesigner.MG_COLOR.BlueLight;
			this.EdgeHeight = 5F;
			this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Frame = MGDesigner.MG_COLOR.Gray;
			this.Grid = MGDesigner.MG_COLOR.Gray;
			this.GridHeight = 50F;
			this.GridOpacity = 25D;
			this.GridWeight = 2F;
			this.GridWidth = 50F;
			this.Kagi = MGDesigner.MG_COLOR.WhiteTrue;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private MGTetragon mgTetragon1;
		private MGTetragon mgTetragon2;
	}
}