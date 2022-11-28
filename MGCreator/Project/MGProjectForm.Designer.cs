


namespace MGCreator
{
    partial class MGProjectForm
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
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.controlListBox1 = new MGCreator.ControlListBox();
			this.mgStyleComb1 = new MGCreator.MGStyleComb();
			this.btnNewMG = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.ForeColor = System.Drawing.Color.LightGray;
			this.btnAdd.Location = new System.Drawing.Point(110, 55);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(42, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDel
			// 
			this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDel.ForeColor = System.Drawing.Color.LightGray;
			this.btnDel.Location = new System.Drawing.Point(12, 436);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(39, 23);
			this.btnDel.TabIndex = 3;
			this.btnDel.Text = "Del";
			this.btnDel.UseVisualStyleBackColor = true;
			// 
			// btnUp
			// 
			this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUp.ForeColor = System.Drawing.Color.LightGray;
			this.btnUp.Location = new System.Drawing.Point(12, 97);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(39, 23);
			this.btnUp.TabIndex = 4;
			this.btnUp.Text = "Up";
			this.btnUp.UseVisualStyleBackColor = true;
			// 
			// btnDown
			// 
			this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDown.ForeColor = System.Drawing.Color.LightGray;
			this.btnDown.Location = new System.Drawing.Point(57, 97);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(50, 23);
			this.btnDown.TabIndex = 5;
			this.btnDown.Text = "Down";
			this.btnDown.UseVisualStyleBackColor = true;
			// 
			// controlListBox1
			// 
			this.controlListBox1.AddBtn = this.btnAdd;
			this.controlListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.controlListBox1.BackColor = System.Drawing.Color.Black;
			this.controlListBox1.DelBtn = this.btnDel;
			this.controlListBox1.ForeColor = System.Drawing.Color.LightGray;
			this.controlListBox1.FormattingEnabled = true;
			this.controlListBox1.ItemHeight = 15;
			this.controlListBox1.Location = new System.Drawing.Point(11, 126);
			this.controlListBox1.Name = "controlListBox1";
			this.controlListBox1.Size = new System.Drawing.Size(141, 304);
			this.controlListBox1.TabIndex = 6;
			// 
			// mgStyleComb1
			// 
			this.mgStyleComb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.mgStyleComb1.FormattingEnabled = true;
			this.mgStyleComb1.Items.AddRange(new object[] {
            "Frame",
            "Grid",
            "Circle",
            "CircleScale",
            "Triangle",
            "Polygon",
            "Cross",
            "Zebra",
            "Label",
            "Parallelogram",
            "Scale",
            "Sheet",
            "Kagi",
            "Edge",
            "Side"});
			this.mgStyleComb1.Location = new System.Drawing.Point(11, 56);
			this.mgStyleComb1.MGStyle = MGCreator.MGStyle.Frame;
			this.mgStyleComb1.Name = "mgStyleComb1";
			this.mgStyleComb1.Size = new System.Drawing.Size(93, 23);
			this.mgStyleComb1.TabIndex = 7;
			// 
			// btnNewMG
			// 
			this.btnNewMG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNewMG.ForeColor = System.Drawing.Color.LightGray;
			this.btnNewMG.Location = new System.Drawing.Point(12, 27);
			this.btnNewMG.Name = "btnNewMG";
			this.btnNewMG.Size = new System.Drawing.Size(92, 23);
			this.btnNewMG.TabIndex = 8;
			this.btnNewMG.Text = "New Moniter";
			this.btnNewMG.UseVisualStyleBackColor = true;
			this.btnNewMG.Click += new System.EventHandler(this.btnNewMG_Click);
			// 
			// MGProjectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(160, 472);
			this.Controls.Add(this.btnNewMG);
			this.Controls.Add(this.mgStyleComb1);
			this.Controls.Add(this.controlListBox1);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnAdd);
			this.DoubleBuffered = true;
			this.Name = "MGProjectForm";
			this.Text = "MGCreater";
			this.ResumeLayout(false);

		}

		#endregion
		private Button btnAdd;
		private Button btnDel;
		private Button btnUp;
		private Button btnDown;
		private ControlListBox controlListBox1;
		private MGStyleComb mgStyleComb1;
		private Button btnNewMG;
	}
}