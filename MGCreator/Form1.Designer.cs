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
			this.mgIcon1 = new MGCreator.MGIcon();
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
			// mgIcon1
			// 
			this.mgIcon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.mgIcon1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.mgIcon1.Location = new System.Drawing.Point(288, 140);
			this.mgIcon1.Name = "mgIcon1";
			this.mgIcon1.Size = new System.Drawing.Size(20, 18);
			this.mgIcon1.Style = MGCreator.MGIcon.IconStyle.BottomArrow;
			this.mgIcon1.TabIndex = 1;
			this.mgIcon1.Text = "mgIcon1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(621, 524);
			this.Controls.Add(this.mgIcon1);
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
		private MGIcon mgIcon1;
	}
}