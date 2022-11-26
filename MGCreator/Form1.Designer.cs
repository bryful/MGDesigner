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
			this.editResizeTypep1 = new MGCreator.EditResizeTypeP();
			this.resizeTypeGrid1 = new MGCreator.ResizeTypeGrid();
			this.editName1 = new MGCreator.EditName();
			this.mgPropertyPanel1 = new MGCreator.MGPropertyPanel();
			this.SuspendLayout();
			// 
			// editResizeTypep1
			// 
			this.editResizeTypep1.BackColor = System.Drawing.Color.Black;
			this.editResizeTypep1.CaptionWidth = 60;
			this.editResizeTypep1.ForeColor = System.Drawing.Color.LightGray;
			this.editResizeTypep1.Location = new System.Drawing.Point(212, 243);
			this.editResizeTypep1.MaximumSize = new System.Drawing.Size(0, 20);
			this.editResizeTypep1.MinimumSize = new System.Drawing.Size(0, 20);
			this.editResizeTypep1.Name = "editResizeTypep1";
			this.editResizeTypep1.SelectedReSizeType = MGCreator.ReSizeType.Center;
			this.editResizeTypep1.Size = new System.Drawing.Size(125, 20);
			this.editResizeTypep1.TabIndex = 0;
			this.editResizeTypep1.Text = "editResizeTypep1";
			// 
			// resizeTypeGrid1
			// 
			this.resizeTypeGrid1.Location = new System.Drawing.Point(274, 342);
			this.resizeTypeGrid1.MaximumSize = new System.Drawing.Size(20, 20);
			this.resizeTypeGrid1.MinimumSize = new System.Drawing.Size(20, 20);
			this.resizeTypeGrid1.Name = "resizeTypeGrid1";
			this.resizeTypeGrid1.ReSizeType = MGCreator.ReSizeType.Center;
			this.resizeTypeGrid1.Size = new System.Drawing.Size(20, 20);
			this.resizeTypeGrid1.TabIndex = 1;
			this.resizeTypeGrid1.Text = "resizeTypeGrid1";
			// 
			// editName1
			// 
			this.editName1.CaptionWidth = 60;
			this.editName1.ForeColor = System.Drawing.Color.LightGray;
			this.editName1.Location = new System.Drawing.Point(291, 289);
			this.editName1.MaximumSize = new System.Drawing.Size(0, 20);
			this.editName1.MGForm = null;
			this.editName1.MinimumSize = new System.Drawing.Size(0, 20);
			this.editName1.Name = "editName1";
			this.editName1.Size = new System.Drawing.Size(239, 20);
			this.editName1.TabIndex = 2;
			this.editName1.Text = "editName1";
			this.editName1.Click += new System.EventHandler(this.editName1_Click);
			// 
			// mgPropertyPanel1
			// 
			this.mgPropertyPanel1.BackColor = System.Drawing.Color.Transparent;
			this.mgPropertyPanel1.Caption = "PropertyPanel";
			this.mgPropertyPanel1.ForeColor = System.Drawing.Color.LightGray;
			this.mgPropertyPanel1.IsShow = true;
			this.mgPropertyPanel1.Location = new System.Drawing.Point(475, 55);
			this.mgPropertyPanel1.MGForm = null;
			this.mgPropertyPanel1.Name = "mgPropertyPanel1";
			this.mgPropertyPanel1.Size = new System.Drawing.Size(247, 295);
			this.mgPropertyPanel1.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.mgPropertyPanel1);
			this.Controls.Add(this.editName1);
			this.Controls.Add(this.resizeTypeGrid1);
			this.Controls.Add(this.editResizeTypep1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private EditResizeTypeP editResizeTypep1;
		private ResizeTypeGrid resizeTypeGrid1;
		private EditName editName1;
		private MGPropertyPanel mgPropertyPanel1;
	}
}