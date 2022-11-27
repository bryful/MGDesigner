

namespace MGCreator
{
    partial class MGItemListForm
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
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.ForeColor = System.Drawing.Color.LightGray;
			this.btnAdd.Location = new System.Drawing.Point(109, 28);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(42, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "add";
			this.btnAdd.UseVisualStyleBackColor = true;
			// 
			// btnDel
			// 
			this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDel.ForeColor = System.Drawing.Color.LightGray;
			this.btnDel.Location = new System.Drawing.Point(11, 82);
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
			this.btnUp.Location = new System.Drawing.Point(56, 82);
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
			this.btnDown.Location = new System.Drawing.Point(101, 82);
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
			this.controlListBox1.Items.AddRange(new object[] {
            "controlListBox1",
            "button4",
            "button3",
            "button2",
            "comboBox1",
            "button1"});
			this.controlListBox1.Location = new System.Drawing.Point(11, 111);
			this.controlListBox1.Name = "controlListBox1";
			this.controlListBox1.Size = new System.Drawing.Size(141, 319);
			this.controlListBox1.TabIndex = 6;
			// 
			// mgStyleComb1
			// 
			this.mgStyleComb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.mgStyleComb1.FormattingEnabled = true;
			this.mgStyleComb1.Items.AddRange(new object[] {
            "None",
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
            "ALL"});
			this.mgStyleComb1.Location = new System.Drawing.Point(11, 29);
			this.mgStyleComb1.Name = "mgStyleComb1";
			this.mgStyleComb1.Size = new System.Drawing.Size(93, 23);
			this.mgStyleComb1.TabIndex = 7;
			// 
			// MGItemListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(160, 444);
			this.Controls.Add(this.mgStyleComb1);
			this.Controls.Add(this.controlListBox1);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnAdd);
			this.DoubleBuffered = true;
			this.Name = "MGItemListForm";
			this.Text = "MGItems";
			this.ResumeLayout(false);

		}

		#endregion
		private Button btnAdd;
		private Button btnDel;
		private Button btnUp;
		private Button btnDown;
		private ControlListBox controlListBox1;
		private MGStyleComb mgStyleComb1;
	}
}