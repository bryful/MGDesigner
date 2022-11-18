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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mgCircle1 = new MGDesigner.MGCircle();
			this.mgGrid1 = new MGDesigner.MGGrid();
			this.SuspendLayout();
			// 
			// mgCircle1
			// 
			this.mgCircle1.Anti = true;
			this.mgCircle1.BackColor = System.Drawing.Color.Transparent;
			this.mgCircle1.CenterPos = ((System.Drawing.PointF)(resources.GetObject("mgCircle1.CenterPos")));
			this.mgCircle1.CenterX = 396.5F;
			this.mgCircle1.CenterY = 276F;
			this.mgCircle1.Circle = MGDesigner.MG_COLOR.White;
			this.mgCircle1.CircleFill = MGDesigner.MG_COLOR.Gray;
			this.mgCircle1.CircleFillOpacity = 0D;
			this.mgCircle1.CircleOpacity = 100D;
			this.mgCircle1.ForeColor = System.Drawing.Color.White;
			this.mgCircle1.Location = new System.Drawing.Point(231, 147);
			this.mgCircle1.MGForm = this;
			this.mgCircle1.Name = "mgCircle1";
			this.mgCircle1.Size = new System.Drawing.Size(331, 258);
			this.mgCircle1.TabIndex = 0;
			this.mgCircle1.Text = "mgCircle1";
			this.mgCircle1.Weight = 4F;
			// 
			// mgGrid1
			// 
			this.mgGrid1.Anti = false;
			this.mgGrid1.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgGrid1.BackColor = System.Drawing.Color.Transparent;
			this.mgGrid1.BackOpacity = 100D;
			this.mgGrid1.CenterPos = ((System.Drawing.PointF)(resources.GetObject("mgGrid1.CenterPos")));
			this.mgGrid1.CenterX = 487F;
			this.mgGrid1.CenterY = 175.5F;
			this.mgGrid1.ForeColor = System.Drawing.Color.White;
			this.mgGrid1.Frame = MGDesigner.MG_COLOR.White;
			this.mgGrid1.FramedWeight = 2;
			this.mgGrid1.FrameOpacity = 100D;
			this.mgGrid1.Grid = MGDesigner.MG_COLOR.Gray;
			this.mgGrid1.GridHeight = 50F;
			this.mgGrid1.GridOpacity = 100D;
			this.mgGrid1.GridWeight = 1F;
			this.mgGrid1.GridWidth = 50F;
			this.mgGrid1.Location = new System.Drawing.Point(423, 126);
			this.mgGrid1.MGForm = null;
			this.mgGrid1.Name = "mgGrid1";
			this.mgGrid1.Size = new System.Drawing.Size(128, 99);
			this.mgGrid1.TabIndex = 1;
			this.mgGrid1.Text = "mgGrid1";
			// 
			// MainForm
			// 
			this.Anti = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Back = MGDesigner.MG_COLOR.Black;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(723, 574);
			this.Controls.Add(this.mgGrid1);
			this.Controls.Add(this.mgCircle1);
			this.Edge = MGDesigner.MG_COLOR.BlueLight;
			this.EdgeHeight = 5F;
			this.EdgeOpacity = 100D;
			this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Frame = MGDesigner.MG_COLOR.Gray;
			this.FrameWeight = 2;
			this.Grid = MGDesigner.MG_COLOR.Gray;
			this.GridHeight = 25F;
			this.GridOpacity = 25D;
			this.GridWeight = 2F;
			this.GridWidth = 25F;
			this.Kagi = MGDesigner.MG_COLOR.GrayLight;
			this.KagiOpacity = 100D;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private MGCircle mgCircle1;
		private MGGrid mgGrid1;
	}
}