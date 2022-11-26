

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
			this.btnAdd.ForeColor = System.Drawing.Color.Black;
			this.btnAdd.Location = new System.Drawing.Point(139, 13);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(52, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "add";
			this.btnAdd.UseVisualStyleBackColor = true;
			// 
			// btnDel
			// 
			this.btnDel.ForeColor = System.Drawing.Color.Black;
			this.btnDel.Location = new System.Drawing.Point(12, 42);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(58, 23);
			this.btnDel.TabIndex = 3;
			this.btnDel.Text = "Del";
			this.btnDel.UseVisualStyleBackColor = true;
			// 
			// btnUp
			// 
			this.btnUp.ForeColor = System.Drawing.Color.Black;
			this.btnUp.Location = new System.Drawing.Point(76, 42);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(57, 23);
			this.btnUp.TabIndex = 4;
			this.btnUp.Text = "Up";
			this.btnUp.UseVisualStyleBackColor = true;
			// 
			// btnDown
			// 
			this.btnDown.ForeColor = System.Drawing.Color.Black;
			this.btnDown.Location = new System.Drawing.Point(139, 42);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(52, 23);
			this.btnDown.TabIndex = 5;
			this.btnDown.Text = "Down";
			this.btnDown.UseVisualStyleBackColor = true;
			// 
			// controlListBox1
			// 
			this.controlListBox1.AddBtn = null;
			this.controlListBox1.FormattingEnabled = true;
			this.controlListBox1.ItemHeight = 15;
			this.controlListBox1.Items.AddRange(new object[] {
            "controlListBox1",
            "button4",
            "button3",
            "button2",
            "comboBox1",
            "button1"});
			this.controlListBox1.Location = new System.Drawing.Point(12, 80);
			this.controlListBox1.Name = "controlListBox1";
			this.controlListBox1.Size = new System.Drawing.Size(179, 319);
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
            "KagiEdge"});
			this.mgStyleComb1.Location = new System.Drawing.Point(11, 13);
			this.mgStyleComb1.Name = "mgStyleComb1";
			this.mgStyleComb1.Size = new System.Drawing.Size(121, 23);
			this.mgStyleComb1.TabIndex = 7;
			// 
			// MGItemListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(200, 406);
			this.Controls.Add(this.mgStyleComb1);
			this.Controls.Add(this.controlListBox1);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnAdd);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "MGItemListForm";
			this.Text = "MGItems";
			this.TopMost = true;
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