


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
			this.mgStyleComb1 = new MGCreator.MGStyleComb();
			this.btnPropForm = new System.Windows.Forms.Button();
			this.pp = new MGCreator.MGProjectPanel();
			this.btnMG = new System.Windows.Forms.Button();
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
			// 
			// btnDel
			// 
			this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDel.ForeColor = System.Drawing.Color.LightGray;
			this.btnDel.Location = new System.Drawing.Point(12, 435);
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
			this.btnUp.Location = new System.Drawing.Point(12, 95);
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
			this.btnDown.Location = new System.Drawing.Point(54, 95);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(50, 23);
			this.btnDown.TabIndex = 5;
			this.btnDown.Text = "Down";
			this.btnDown.UseVisualStyleBackColor = true;
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
            "Side",
            "PNG",
            "JSON"});
			this.mgStyleComb1.Location = new System.Drawing.Point(11, 56);
			this.mgStyleComb1.MGStyle = MGCreator.MGStyle.Frame;
			this.mgStyleComb1.Name = "mgStyleComb1";
			this.mgStyleComb1.Size = new System.Drawing.Size(93, 23);
			this.mgStyleComb1.TabIndex = 7;
			// 
			// btnPropForm
			// 
			this.btnPropForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPropForm.ForeColor = System.Drawing.Color.LightGray;
			this.btnPropForm.Location = new System.Drawing.Point(86, 27);
			this.btnPropForm.Name = "btnPropForm";
			this.btnPropForm.Size = new System.Drawing.Size(72, 23);
			this.btnPropForm.TabIndex = 9;
			this.btnPropForm.Text = "Property";
			this.btnPropForm.UseVisualStyleBackColor = true;
			// 
			// pp
			// 
			this.pp.AddBtn = this.btnAdd;
			this.pp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pp.DelBtn = this.btnDel;
			this.pp.DownBtn = this.btnDown;
			this.pp.Location = new System.Drawing.Point(12, 124);
			this.pp.MGForm = null;
			this.pp.Name = "pp";
			this.pp.NewMGBtn = null;
			this.pp.PropBtn = this.btnPropForm;
			this.pp.Size = new System.Drawing.Size(146, 305);
			this.pp.StyleComb = this.mgStyleComb1;
			this.pp.TabIndex = 10;
			this.pp.Text = "mgProjectPanel1";
			this.pp.UpBtn = this.btnDel;
			// 
			// btnMG
			// 
			this.btnMG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMG.ForeColor = System.Drawing.Color.LightGray;
			this.btnMG.Location = new System.Drawing.Point(12, 27);
			this.btnMG.Name = "btnMG";
			this.btnMG.Size = new System.Drawing.Size(72, 23);
			this.btnMG.TabIndex = 11;
			this.btnMG.Text = "MG";
			this.btnMG.UseVisualStyleBackColor = true;
			this.btnMG.Click += new System.EventHandler(this.btnMG_Click);
			// 
			// MGProjectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(170, 471);
			this.Controls.Add(this.btnMG);
			this.Controls.Add(this.pp);
			this.Controls.Add(this.btnPropForm);
			this.Controls.Add(this.mgStyleComb1);
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
		private MGStyleComb mgStyleComb1;
		private Button btnPropForm;
		private MGProjectPanel pp;
		private Button btnMG;
	}
}