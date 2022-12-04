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
			this.doubleEdit1 = new MGCreator.DoubleEdit();
			this.editInt1 = new MGCreator.EditInt();
			this.editPoint1 = new MGCreator.EditPoint();
			this.floatEdit1 = new MGCreator.FloatEdit();
			this.intEdit1 = new MGCreator.IntEdit();
			this.doubleEdit2 = new MGCreator.DoubleEdit();
			this.floatEdit2 = new MGCreator.FloatEdit();
			this.SuspendLayout();
			// 
			// doubleEdit1
			// 
			this.doubleEdit1.BackColor = System.Drawing.Color.Black;
			this.doubleEdit1.ForeColor = System.Drawing.Color.LightGray;
			this.doubleEdit1.Location = new System.Drawing.Point(188, 229);
			this.doubleEdit1.Name = "doubleEdit1";
			this.doubleEdit1.Size = new System.Drawing.Size(75, 23);
			this.doubleEdit1.TabIndex = 0;
			this.doubleEdit1.Text = "doubleEdit1";
			this.doubleEdit1.Value = 0D;
			this.doubleEdit1.ValueMax = 30000D;
			this.doubleEdit1.ValueMin = 0D;
			// 
			// editInt1
			// 
			this.editInt1.Caption = "int";
			this.editInt1.CaptionWidth = 90;
			this.editInt1.ForeColor = System.Drawing.Color.LightGray;
			this.editInt1.Location = new System.Drawing.Point(245, 258);
			this.editInt1.MaximumSize = new System.Drawing.Size(0, 20);
			this.editInt1.MGForm = null;
			this.editInt1.MinimumSize = new System.Drawing.Size(220, 20);
			this.editInt1.Name = "editInt1";
			this.editInt1.Size = new System.Drawing.Size(220, 20);
			this.editInt1.TabIndex = 1;
			this.editInt1.Text = "editInt1";
			this.editInt1.Value = 0;
			this.editInt1.ValueMax = 32000;
			this.editInt1.ValueMin = -32000;
			// 
			// editPoint1
			// 
			this.editPoint1.Caption = "Point";
			this.editPoint1.CaptionWidth = 90;
			this.editPoint1.ForeColor = System.Drawing.Color.LightGray;
			this.editPoint1.Location = new System.Drawing.Point(245, 319);
			this.editPoint1.MaximumSize = new System.Drawing.Size(0, 20);
			this.editPoint1.MGForm = null;
			this.editPoint1.MinimumSize = new System.Drawing.Size(220, 20);
			this.editPoint1.Name = "editPoint1";
			this.editPoint1.Point = new System.Drawing.Point(0, 0);
			this.editPoint1.Size = new System.Drawing.Size(220, 20);
			this.editPoint1.TabIndex = 2;
			this.editPoint1.Text = "editPoint1";
			// 
			// floatEdit1
			// 
			this.floatEdit1.BackColor = System.Drawing.Color.Black;
			this.floatEdit1.ForeColor = System.Drawing.Color.LightGray;
			this.floatEdit1.Location = new System.Drawing.Point(101, 367);
			this.floatEdit1.Name = "floatEdit1";
			this.floatEdit1.Size = new System.Drawing.Size(108, 23);
			this.floatEdit1.TabIndex = 3;
			this.floatEdit1.Text = "floatEdit1";
			this.floatEdit1.Value = 0F;
			this.floatEdit1.ValueMax = 30000F;
			this.floatEdit1.ValueMin = 0F;
			// 
			// intEdit1
			// 
			this.intEdit1.BackColor = System.Drawing.Color.Black;
			this.intEdit1.ForeColor = System.Drawing.Color.LightGray;
			this.intEdit1.Location = new System.Drawing.Point(70, 319);
			this.intEdit1.Name = "intEdit1";
			this.intEdit1.Size = new System.Drawing.Size(75, 23);
			this.intEdit1.TabIndex = 4;
			this.intEdit1.Text = "intEdit1";
			this.intEdit1.Value = 0;
			this.intEdit1.ValueMax = 30000;
			this.intEdit1.ValueMin = 0;
			// 
			// doubleEdit2
			// 
			this.doubleEdit2.BackColor = System.Drawing.Color.Black;
			this.doubleEdit2.ForeColor = System.Drawing.Color.LightGray;
			this.doubleEdit2.Location = new System.Drawing.Point(70, 266);
			this.doubleEdit2.Name = "doubleEdit2";
			this.doubleEdit2.Size = new System.Drawing.Size(75, 23);
			this.doubleEdit2.TabIndex = 5;
			this.doubleEdit2.Text = "doubleEdit2";
			this.doubleEdit2.Value = 0D;
			this.doubleEdit2.ValueMax = 30000D;
			this.doubleEdit2.ValueMin = 0D;
			// 
			// floatEdit2
			// 
			this.floatEdit2.BackColor = System.Drawing.Color.Black;
			this.floatEdit2.ForeColor = System.Drawing.Color.LightGray;
			this.floatEdit2.Location = new System.Drawing.Point(79, 219);
			this.floatEdit2.Name = "floatEdit2";
			this.floatEdit2.Size = new System.Drawing.Size(75, 23);
			this.floatEdit2.TabIndex = 6;
			this.floatEdit2.Text = "floatEdit2";
			this.floatEdit2.Value = 0F;
			this.floatEdit2.ValueMax = 30000F;
			this.floatEdit2.ValueMin = 0F;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(621, 524);
			this.Controls.Add(this.floatEdit2);
			this.Controls.Add(this.doubleEdit2);
			this.Controls.Add(this.intEdit1);
			this.Controls.Add(this.floatEdit1);
			this.Controls.Add(this.editPoint1);
			this.Controls.Add(this.editInt1);
			this.Controls.Add(this.doubleEdit1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private EditLayerLocation editControlPoint1;
		private EditLayerSize editControlSize1;
		private DoubleEdit doubleEdit1;
		private EditInt editInt1;
		private EditPoint editPoint1;
		private FloatEdit floatEdit1;
		private IntEdit intEdit1;
		private DoubleEdit doubleEdit2;
		private FloatEdit floatEdit2;
	}
}