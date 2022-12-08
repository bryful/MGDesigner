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
			this.components = new System.ComponentModel.Container();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editString1 = new MGCreator.EditString();
			this.sizeRootGrid1 = new MGCreator.SizeRootGrid();
			this.editAlignment1 = new MGCreator.EditAlignment();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.BackColor = System.Drawing.Color.Black;
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
			// 
			// fIleToolStripMenuItem
			// 
			this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
			this.fIleToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.fIleToolStripMenuItem.Text = "FIle";
			// 
			// editString1
			// 
			this.editString1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.editString1.Caption = "string";
			this.editString1.CaptionWidth = 90;
			this.editString1.ForeColor = System.Drawing.Color.LightGray;
			this.editString1.Location = new System.Drawing.Point(195, 243);
			this.editString1.MaximumSize = new System.Drawing.Size(0, 20);
			this.editString1.MGForm = null;
			this.editString1.MinimumSize = new System.Drawing.Size(180, 20);
			this.editString1.Name = "editString1";
			this.editString1.Size = new System.Drawing.Size(220, 20);
			this.editString1.TabIndex = 1;
			this.editString1.Text = "editString1";
			this.editString1.Value = "";
			// 
			// sizeRootGrid1
			// 
			this.sizeRootGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.sizeRootGrid1.BaseColor = System.Drawing.Color.DimGray;
			this.sizeRootGrid1.CornerLock = false;
			this.sizeRootGrid1.ForeColor = System.Drawing.Color.LightGray;
			this.sizeRootGrid1.IsShowSwitch = false;
			this.sizeRootGrid1.IsSmall = false;
			this.sizeRootGrid1.Location = new System.Drawing.Point(238, 321);
			this.sizeRootGrid1.MaximumSize = new System.Drawing.Size(30, 32);
			this.sizeRootGrid1.MinimumSize = new System.Drawing.Size(30, 32);
			this.sizeRootGrid1.Name = "sizeRootGrid1";
			this.sizeRootGrid1.PushColor = System.Drawing.Color.LightGray;
			this.sizeRootGrid1.PushColor2 = System.Drawing.Color.White;
			this.sizeRootGrid1.Size = new System.Drawing.Size(30, 32);
			this.sizeRootGrid1.SizeRoot = MGCreator.SizeRootType.TopLeft;
			this.sizeRootGrid1.TabIndex = 2;
			this.sizeRootGrid1.Text = "sizeRootGrid1";
			// 
			// editAlignment1
			// 
			this.editAlignment1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.editAlignment1.Caption = "Aligment";
			this.editAlignment1.CaptionWidth = 90;
			this.editAlignment1.ForeColor = System.Drawing.Color.LightGray;
			this.editAlignment1.Location = new System.Drawing.Point(170, 410);
			this.editAlignment1.MaximumSize = new System.Drawing.Size(0, 32);
			this.editAlignment1.MGForm = null;
			this.editAlignment1.MinimumSize = new System.Drawing.Size(180, 32);
			this.editAlignment1.Name = "editAlignment1";
			this.editAlignment1.Size = new System.Drawing.Size(180, 32);
			this.editAlignment1.TabIndex = 3;
			this.editAlignment1.Text = "editAlignment1";
			this.editAlignment1.Value = MGCreator.SizeRootType.TopLeft;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(621, 524);
			this.Controls.Add(this.editAlignment1);
			this.Controls.Add(this.sizeRootGrid1);
			this.Controls.Add(this.editString1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private EditLayerLocation editControlPoint1;
		private EditLayerSize editControlSize1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem fIleToolStripMenuItem;
		private EditString editString1;
		private SizeRootGrid sizeRootGrid1;
		private EditAlignment editAlignment1;
	}
}