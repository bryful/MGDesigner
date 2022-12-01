namespace MGCreator
{
	partial class MGFormSize
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbSizePos = new System.Windows.Forms.Label();
			this.resizeSetting1 = new MGCreator.SizeRootGrid();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(156, 89);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(60, 23);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOK.Location = new System.Drawing.Point(222, 89);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(63, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(66, 45);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(74, 23);
			this.numericUpDown1.TabIndex = 2;
			this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(211, 45);
			this.numericUpDown2.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
			this.numericUpDown2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(74, 23);
			this.numericUpDown2.TabIndex = 3;
			this.numericUpDown2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Width";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(159, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 15);
			this.label2.TabIndex = 5;
			this.label2.Text = "Heigjht";
			// 
			// lbSizePos
			// 
			this.lbSizePos.AutoSize = true;
			this.lbSizePos.Location = new System.Drawing.Point(21, 80);
			this.lbSizePos.Name = "lbSizePos";
			this.lbSizePos.Size = new System.Drawing.Size(50, 15);
			this.lbSizePos.TabIndex = 7;
			this.lbSizePos.Text = "Position";
			// 
			// resizeSetting1
			// 
			this.resizeSetting1.BackColor = System.Drawing.Color.Black;
			this.resizeSetting1.BaseColor = System.Drawing.Color.DimGray;
			this.resizeSetting1.CornerLock = false;
			this.resizeSetting1.ForeColor = System.Drawing.Color.LightGray;
			this.resizeSetting1.IsShowSwitch = false;
			this.resizeSetting1.IsSmall = false;
			this.resizeSetting1.Location = new System.Drawing.Point(77, 80);
			this.resizeSetting1.MaximumSize = new System.Drawing.Size(30, 32);
			this.resizeSetting1.MinimumSize = new System.Drawing.Size(30, 32);
			this.resizeSetting1.Name = "resizeSetting1";
			this.resizeSetting1.PushColor = System.Drawing.Color.LightGray;
			this.resizeSetting1.PushColor2 = System.Drawing.Color.White;
			this.resizeSetting1.Size = new System.Drawing.Size(30, 32);
			this.resizeSetting1.SizeRoot = MGCreator.SizeRootType.Center;
			this.resizeSetting1.TabIndex = 8;
			this.resizeSetting1.Text = "resizeSetting1";
			// 
			// MGFormSize
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(310, 138);
			this.Controls.Add(this.resizeSetting1);
			this.Controls.Add(this.lbSizePos);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDown2);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Name = "MGFormSize";
			this.Text = "Size Setting";
			this.Load += new System.EventHandler(this.MGFormSize_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button btnCancel;
		private Button btnOK;
		private NumericUpDown numericUpDown1;
		private NumericUpDown numericUpDown2;
		private Label label1;
		private Label label2;
		private Label lbSizePos;
		private SizeRootGrid resizeSetting1;
	}
}