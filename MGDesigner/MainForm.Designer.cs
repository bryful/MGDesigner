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
			this.components = new System.ComponentModel.Container();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.mgFrame1 = new MGDesigner.MGFrame();
			this.mgScale1 = new MGDesigner.MGScale();
			this.mgScale2 = new MGDesigner.MGScale();
			this.mgFrame2 = new MGDesigner.MGFrame();
			this.mgKagi1 = new MGDesigner.MGKagi();
			this.mgSheet1 = new MGDesigner.MGSheet();
			this.mgSheet2 = new MGDesigner.MGSheet();
			this.mgCircle1 = new MGDesigner.MGCircle();
			this.mgKagi2 = new MGDesigner.MGKagi();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.exportPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportMixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mgTriangle1 = new MGDesigner.MGTriangle();
			this.mgPlate1 = new MGDesigner.MGPlate();
			this.mgFrame3 = new MGDesigner.MGFrame();
			this.mgPlate2 = new MGDesigner.MGPlate();
			this.mgPlate3 = new MGDesigner.MGPlate();
			this.mgCircle2 = new MGDesigner.MGCircle();
			this.mgTriangle2 = new MGDesigner.MGTriangle();
			this.mgTriangle3 = new MGDesigner.MGTriangle();
			this.mgTriangle4 = new MGDesigner.MGTriangle();
			this.mgTriangle5 = new MGDesigner.MGTriangle();
			this.mgPolygon1 = new MGDesigner.MGPolygon();
			this.mgPolygon2 = new MGDesigner.MGPolygon();
			this.mgLabel1 = new MGDesigner.MGLabel();
			this.mgLabel2 = new MGDesigner.MGLabel();
			this.mgCircleScale1 = new MGDesigner.MGCircleScale();
			this.mgCircleScale2 = new MGDesigner.MGCircleScale();
			this.mgCross1 = new MGDesigner.MGCross();
			this.mgEdge1 = new MGDesigner.MGKagiEdge();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(12, 118);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(608, 102);
			this.textBox2.TabIndex = 7;
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(9, 226);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(608, 102);
			this.textBox3.TabIndex = 8;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(506, 372);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(90, 41);
			this.button2.TabIndex = 9;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// mgFrame1
			// 
			this.mgFrame1.Back = MGDesigner.MG_COLOR.Black;
			this.mgFrame1.BackColor = System.Drawing.Color.Transparent;
			this.mgFrame1.BackOpacity = 100D;
			this.mgFrame1.ForeColor = System.Drawing.Color.White;
			this.mgFrame1.Frame = MGDesigner.MG_COLOR.White;
			this.mgFrame1.FrameOpacity = 100D;
			this.mgFrame1.FrameWeight = 2;
			this.mgFrame1.Location = new System.Drawing.Point(69, 291);
			this.mgFrame1.MGForm = this;
			this.mgFrame1.Name = "mgFrame1";
			this.mgFrame1.Size = new System.Drawing.Size(101, 197);
			this.mgFrame1.TabIndex = 1;
			this.mgFrame1.Text = "mgFrame1";
			// 
			// mgScale1
			// 
			this.mgScale1.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgScale1.BackColor = System.Drawing.Color.Transparent;
			this.mgScale1.BackOpacity = 100D;
			this.mgScale1.ForeColor = System.Drawing.Color.White;
			this.mgScale1.Inter = 7F;
			this.mgScale1.LengthPers = new float[] {
        100F,
        40F,
        40F,
        60F,
        40F,
        40F};
			this.mgScale1.Location = new System.Drawing.Point(12, 503);
			this.mgScale1.MGForm = this;
			this.mgScale1.Name = "mgScale1";
			this.mgScale1.Offset = 0F;
			this.mgScale1.ScaleColor = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.Gray,
        System.Drawing.Color.Gray,
        System.Drawing.Color.LightGray,
        System.Drawing.Color.Gray,
        System.Drawing.Color.Gray};
			this.mgScale1.ScaleStlye = MGDesigner.ScaleStlye.Bottom;
			this.mgScale1.Size = new System.Drawing.Size(896, 16);
			this.mgScale1.TabIndex = 2;
			this.mgScale1.Text = "mgScale1";
			this.mgScale1.Weight = 3F;
			this.mgScale1.WeightPers = new float[] {
        100F,
        50F,
        50F,
        75F,
        50F,
        50F};
			// 
			// mgScale2
			// 
			this.mgScale2.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgScale2.BackColor = System.Drawing.Color.Transparent;
			this.mgScale2.BackOpacity = 100D;
			this.mgScale2.ForeColor = System.Drawing.Color.White;
			this.mgScale2.Inter = 30F;
			this.mgScale2.LengthPers = new float[] {
        100F,
        50F,
        50F,
        75F,
        50F,
        50F};
			this.mgScale2.Location = new System.Drawing.Point(12, 12);
			this.mgScale2.MGForm = this;
			this.mgScale2.Name = "mgScale2";
			this.mgScale2.Offset = 0F;
			this.mgScale2.ScaleColor = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.Gray,
        System.Drawing.Color.Gray,
        System.Drawing.Color.LightGray,
        System.Drawing.Color.Gray,
        System.Drawing.Color.Gray};
			this.mgScale2.ScaleStlye = MGDesigner.ScaleStlye.Left;
			this.mgScale2.Size = new System.Drawing.Size(23, 485);
			this.mgScale2.TabIndex = 3;
			this.mgScale2.Text = "mgScale2";
			this.mgScale2.Weight = 6F;
			this.mgScale2.WeightPers = new float[] {
        100F,
        50F,
        50F,
        75F,
        50F,
        50F};
			// 
			// mgFrame2
			// 
			this.mgFrame2.Back = MGDesigner.MG_COLOR.Black;
			this.mgFrame2.BackColor = System.Drawing.Color.Transparent;
			this.mgFrame2.BackOpacity = 100D;
			this.mgFrame2.ForeColor = System.Drawing.Color.White;
			this.mgFrame2.Frame = MGDesigner.MG_COLOR.White;
			this.mgFrame2.FrameOpacity = 100D;
			this.mgFrame2.FrameWeight = 2;
			this.mgFrame2.Location = new System.Drawing.Point(69, 263);
			this.mgFrame2.MGForm = this;
			this.mgFrame2.Name = "mgFrame2";
			this.mgFrame2.Size = new System.Drawing.Size(101, 22);
			this.mgFrame2.TabIndex = 4;
			this.mgFrame2.Text = "mgFrame2";
			// 
			// mgKagi1
			// 
			this.mgKagi1.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgKagi1.BackColor = System.Drawing.Color.Transparent;
			this.mgKagi1.BackOpacity = 100D;
			this.mgKagi1.ForeColor = System.Drawing.Color.White;
			this.mgKagi1.Kagi = MGDesigner.MG_COLOR.Green;
			this.mgKagi1.KagiOpacity = 100D;
			this.mgKagi1.kagiStyle = MGDesigner.KagiStyle.TopRight;
			this.mgKagi1.kagiWeightH = 10;
			this.mgKagi1.kagiWeightV = 10;
			this.mgKagi1.Location = new System.Drawing.Point(531, 137);
			this.mgKagi1.MGForm = this;
			this.mgKagi1.Name = "mgKagi1";
			this.mgKagi1.Size = new System.Drawing.Size(48, 43);
			this.mgKagi1.TabIndex = 5;
			this.mgKagi1.Text = "mgKagi1";
			// 
			// mgSheet1
			// 
			this.mgSheet1.Back = MGDesigner.MG_COLOR.Black;
			this.mgSheet1.BackColor = System.Drawing.Color.Transparent;
			this.mgSheet1.BackOpacity = 100D;
			this.mgSheet1.Col = 80;
			this.mgSheet1.Cols = new int[] {
        20,
        80,
        300};
			this.mgSheet1.ForeColor = System.Drawing.Color.White;
			this.mgSheet1.Frame = MGDesigner.MG_COLOR.White;
			this.mgSheet1.FrameOpacity = 100D;
			this.mgSheet1.FrameWeight = 2;
			this.mgSheet1.Line = MGDesigner.MG_COLOR.GrayLight;
			this.mgSheet1.LineOpacity = 100D;
			this.mgSheet1.LineWeight = 2;
			this.mgSheet1.Location = new System.Drawing.Point(471, 291);
			this.mgSheet1.MGForm = this;
			this.mgSheet1.Name = "mgSheet1";
			this.mgSheet1.Row = 25;
			this.mgSheet1.Rows = new int[] {
        25,
        25};
			this.mgSheet1.Size = new System.Drawing.Size(441, 27);
			this.mgSheet1.TabIndex = 6;
			this.mgSheet1.Text = "mgSheet1";
			// 
			// mgSheet2
			// 
			this.mgSheet2.Back = MGDesigner.MG_COLOR.Black;
			this.mgSheet2.BackColor = System.Drawing.Color.Transparent;
			this.mgSheet2.BackOpacity = 100D;
			this.mgSheet2.Col = 80;
			this.mgSheet2.Cols = new int[] {
        20,
        80,
        300};
			this.mgSheet2.ForeColor = System.Drawing.Color.White;
			this.mgSheet2.Frame = MGDesigner.MG_COLOR.Yellow;
			this.mgSheet2.FrameOpacity = 100D;
			this.mgSheet2.FrameWeight = 2;
			this.mgSheet2.Line = MGDesigner.MG_COLOR.Orange;
			this.mgSheet2.LineOpacity = 100D;
			this.mgSheet2.LineWeight = 2;
			this.mgSheet2.Location = new System.Drawing.Point(471, 334);
			this.mgSheet2.MGForm = this;
			this.mgSheet2.Name = "mgSheet2";
			this.mgSheet2.Row = 25;
			this.mgSheet2.Rows = new int[] {
        25,
        25,
        25,
        25,
        25,
        25};
			this.mgSheet2.Size = new System.Drawing.Size(441, 151);
			this.mgSheet2.TabIndex = 7;
			this.mgSheet2.Text = "mgSheet2";
			// 
			// mgCircle1
			// 
			this.mgCircle1.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgCircle1.BackColor = System.Drawing.Color.Transparent;
			this.mgCircle1.BackOpacity = 100D;
			this.mgCircle1.CircleFill = MGDesigner.MG_COLOR.Gray;
			this.mgCircle1.CircleFillOpacity = 50D;
			this.mgCircle1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.Gray};
			this.mgCircle1.ForeColor = System.Drawing.Color.White;
			this.mgCircle1.Location = new System.Drawing.Point(359, 12);
			this.mgCircle1.MGForm = this;
			this.mgCircle1.Name = "mgCircle1";
			this.mgCircle1.Radius = new int[] {
        75,
        51,
        34};
			this.mgCircle1.Size = new System.Drawing.Size(188, 152);
			this.mgCircle1.TabIndex = 8;
			this.mgCircle1.Text = "mgCircle1";
			this.mgCircle1.Weight = new int[] {
        2,
        4,
        3};
			// 
			// mgKagi2
			// 
			this.mgKagi2.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgKagi2.BackColor = System.Drawing.Color.Transparent;
			this.mgKagi2.BackOpacity = 100D;
			this.mgKagi2.ForeColor = System.Drawing.Color.White;
			this.mgKagi2.Kagi = MGDesigner.MG_COLOR.White;
			this.mgKagi2.KagiOpacity = 100D;
			this.mgKagi2.kagiStyle = MGDesigner.KagiStyle.BottomRight;
			this.mgKagi2.kagiWeightH = 10;
			this.mgKagi2.kagiWeightV = 10;
			this.mgKagi2.Location = new System.Drawing.Point(381, 226);
			this.mgKagi2.MGForm = this;
			this.mgKagi2.Name = "mgKagi2";
			this.mgKagi2.Size = new System.Drawing.Size(58, 59);
			this.mgKagi2.TabIndex = 9;
			this.mgKagi2.Text = "mgKagi2";
			this.mgKagi2.Click += new System.EventHandler(this.mgKagi2_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportPartsToolStripMenuItem,
            this.exportMixToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(135, 70);
			// 
			// exportPartsToolStripMenuItem
			// 
			this.exportPartsToolStripMenuItem.Name = "exportPartsToolStripMenuItem";
			this.exportPartsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.exportPartsToolStripMenuItem.Text = "ExportParts";
			this.exportPartsToolStripMenuItem.Click += new System.EventHandler(this.exportPartsToolStripMenuItem_Click);
			// 
			// exportMixToolStripMenuItem
			// 
			this.exportMixToolStripMenuItem.Name = "exportMixToolStripMenuItem";
			this.exportMixToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.exportMixToolStripMenuItem.Text = "ExportMix";
			this.exportMixToolStripMenuItem.Click += new System.EventHandler(this.exportMixToolStripMenuItem_Click);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click_1);
			// 
			// mgTriangle1
			// 
			this.mgTriangle1.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgTriangle1.BackColor = System.Drawing.Color.Transparent;
			this.mgTriangle1.BackOpacity = 100D;
			this.mgTriangle1.ForeColor = System.Drawing.Color.White;
			this.mgTriangle1.Length = 100F;
			this.mgTriangle1.Location = new System.Drawing.Point(289, 324);
			this.mgTriangle1.MGForm = this;
			this.mgTriangle1.Name = "mgTriangle1";
			this.mgTriangle1.Rot = 30F;
			this.mgTriangle1.Size = new System.Drawing.Size(51, 72);
			this.mgTriangle1.TabIndex = 10;
			this.mgTriangle1.Text = "mgTriangle1";
			this.mgTriangle1.TrainglrStyle = MGDesigner.MG.TrainglrStyle.Right;
			this.mgTriangle1.Triangle = MGDesigner.MG_COLOR.White;
			this.mgTriangle1.TriangleFill = MGDesigner.MG_COLOR.Gray;
			this.mgTriangle1.TriangleFillOpacity = 50D;
			this.mgTriangle1.TriangleOpacity = 100D;
			this.mgTriangle1.Weight = 2F;
			// 
			// mgPlate1
			// 
			this.mgPlate1.Back = MGDesigner.MG_COLOR.Red;
			this.mgPlate1.BackColor = System.Drawing.Color.Transparent;
			this.mgPlate1.BackOpacity = 100D;
			this.mgPlate1.ForeColor = System.Drawing.Color.White;
			this.mgPlate1.Location = new System.Drawing.Point(618, 163);
			this.mgPlate1.MGForm = this;
			this.mgPlate1.Name = "mgPlate1";
			this.mgPlate1.Size = new System.Drawing.Size(272, 17);
			this.mgPlate1.TabIndex = 11;
			this.mgPlate1.Text = "mgPlate1";
			// 
			// mgFrame3
			// 
			this.mgFrame3.Back = MGDesigner.MG_COLOR.Black;
			this.mgFrame3.BackColor = System.Drawing.Color.Transparent;
			this.mgFrame3.BackOpacity = 100D;
			this.mgFrame3.ForeColor = System.Drawing.Color.White;
			this.mgFrame3.Frame = MGDesigner.MG_COLOR.White;
			this.mgFrame3.FrameOpacity = 100D;
			this.mgFrame3.FrameWeight = 2;
			this.mgFrame3.Location = new System.Drawing.Point(597, 135);
			this.mgFrame3.MGForm = this;
			this.mgFrame3.Name = "mgFrame3";
			this.mgFrame3.Size = new System.Drawing.Size(314, 138);
			this.mgFrame3.TabIndex = 12;
			this.mgFrame3.Text = "mgFrame3";
			// 
			// mgPlate2
			// 
			this.mgPlate2.Back = MGDesigner.MG_COLOR.Red;
			this.mgPlate2.BackColor = System.Drawing.Color.Transparent;
			this.mgPlate2.BackOpacity = 100D;
			this.mgPlate2.ForeColor = System.Drawing.Color.White;
			this.mgPlate2.Location = new System.Drawing.Point(618, 196);
			this.mgPlate2.MGForm = this;
			this.mgPlate2.Name = "mgPlate2";
			this.mgPlate2.Size = new System.Drawing.Size(272, 17);
			this.mgPlate2.TabIndex = 13;
			this.mgPlate2.Text = "mgPlate2";
			// 
			// mgPlate3
			// 
			this.mgPlate3.Back = MGDesigner.MG_COLOR.Red;
			this.mgPlate3.BackColor = System.Drawing.Color.Transparent;
			this.mgPlate3.BackOpacity = 100D;
			this.mgPlate3.ForeColor = System.Drawing.Color.White;
			this.mgPlate3.Location = new System.Drawing.Point(618, 233);
			this.mgPlate3.MGForm = this;
			this.mgPlate3.Name = "mgPlate3";
			this.mgPlate3.Size = new System.Drawing.Size(272, 17);
			this.mgPlate3.TabIndex = 14;
			this.mgPlate3.Text = "mgPlate3";
			// 
			// mgCircle2
			// 
			this.mgCircle2.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgCircle2.BackColor = System.Drawing.Color.Transparent;
			this.mgCircle2.BackOpacity = 100D;
			this.mgCircle2.CircleFill = MGDesigner.MG_COLOR.Gray;
			this.mgCircle2.CircleFillOpacity = 50D;
			this.mgCircle2.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.Gray};
			this.mgCircle2.ForeColor = System.Drawing.Color.White;
			this.mgCircle2.Location = new System.Drawing.Point(203, 12);
			this.mgCircle2.MGForm = this;
			this.mgCircle2.Name = "mgCircle2";
			this.mgCircle2.Radius = new int[] {
        74};
			this.mgCircle2.Size = new System.Drawing.Size(150, 152);
			this.mgCircle2.TabIndex = 15;
			this.mgCircle2.Text = "mgCircle2";
			this.mgCircle2.Weight = new int[] {
        2,
        4,
        3};
			this.mgCircle2.Click += new System.EventHandler(this.mgCircle2_Click);
			// 
			// mgTriangle2
			// 
			this.mgTriangle2.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgTriangle2.BackColor = System.Drawing.Color.Transparent;
			this.mgTriangle2.BackOpacity = 50D;
			this.mgTriangle2.ForeColor = System.Drawing.Color.White;
			this.mgTriangle2.Length = 30F;
			this.mgTriangle2.Location = new System.Drawing.Point(597, 88);
			this.mgTriangle2.MGForm = this;
			this.mgTriangle2.Name = "mgTriangle2";
			this.mgTriangle2.Rot = 0F;
			this.mgTriangle2.Size = new System.Drawing.Size(53, 41);
			this.mgTriangle2.TabIndex = 16;
			this.mgTriangle2.Text = "mgTriangle2";
			this.mgTriangle2.TrainglrStyle = MGDesigner.MG.TrainglrStyle.Top;
			this.mgTriangle2.Triangle = MGDesigner.MG_COLOR.Yellow;
			this.mgTriangle2.TriangleFill = MGDesigner.MG_COLOR.Yellow;
			this.mgTriangle2.TriangleFillOpacity = 50D;
			this.mgTriangle2.TriangleOpacity = 100D;
			this.mgTriangle2.Weight = 2F;
			// 
			// mgTriangle3
			// 
			this.mgTriangle3.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgTriangle3.BackColor = System.Drawing.Color.Transparent;
			this.mgTriangle3.BackOpacity = 50D;
			this.mgTriangle3.ForeColor = System.Drawing.Color.White;
			this.mgTriangle3.Length = 30F;
			this.mgTriangle3.Location = new System.Drawing.Point(630, 88);
			this.mgTriangle3.MGForm = this;
			this.mgTriangle3.Name = "mgTriangle3";
			this.mgTriangle3.Rot = 0F;
			this.mgTriangle3.Size = new System.Drawing.Size(53, 41);
			this.mgTriangle3.TabIndex = 17;
			this.mgTriangle3.Text = "mgTriangle3";
			this.mgTriangle3.TrainglrStyle = MGDesigner.MG.TrainglrStyle.Bottom;
			this.mgTriangle3.Triangle = MGDesigner.MG_COLOR.Yellow;
			this.mgTriangle3.TriangleFill = MGDesigner.MG_COLOR.Yellow;
			this.mgTriangle3.TriangleFillOpacity = 50D;
			this.mgTriangle3.TriangleOpacity = 100D;
			this.mgTriangle3.Weight = 2F;
			// 
			// mgTriangle4
			// 
			this.mgTriangle4.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgTriangle4.BackColor = System.Drawing.Color.Transparent;
			this.mgTriangle4.BackOpacity = 75D;
			this.mgTriangle4.ForeColor = System.Drawing.Color.White;
			this.mgTriangle4.Length = 30F;
			this.mgTriangle4.Location = new System.Drawing.Point(698, 88);
			this.mgTriangle4.MGForm = this;
			this.mgTriangle4.Name = "mgTriangle4";
			this.mgTriangle4.Rot = 0F;
			this.mgTriangle4.Size = new System.Drawing.Size(53, 41);
			this.mgTriangle4.TabIndex = 19;
			this.mgTriangle4.Text = "mgTriangle4";
			this.mgTriangle4.TrainglrStyle = MGDesigner.MG.TrainglrStyle.Bottom;
			this.mgTriangle4.Triangle = MGDesigner.MG_COLOR.Yellow;
			this.mgTriangle4.TriangleFill = MGDesigner.MG_COLOR.Yellow;
			this.mgTriangle4.TriangleFillOpacity = 50D;
			this.mgTriangle4.TriangleOpacity = 100D;
			this.mgTriangle4.Weight = 2F;
			// 
			// mgTriangle5
			// 
			this.mgTriangle5.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgTriangle5.BackColor = System.Drawing.Color.Transparent;
			this.mgTriangle5.BackOpacity = 50D;
			this.mgTriangle5.ForeColor = System.Drawing.Color.White;
			this.mgTriangle5.Length = 30F;
			this.mgTriangle5.Location = new System.Drawing.Point(665, 88);
			this.mgTriangle5.MGForm = this;
			this.mgTriangle5.Name = "mgTriangle5";
			this.mgTriangle5.Rot = 0F;
			this.mgTriangle5.Size = new System.Drawing.Size(53, 41);
			this.mgTriangle5.TabIndex = 18;
			this.mgTriangle5.Text = "mgTriangle5";
			this.mgTriangle5.TrainglrStyle = MGDesigner.MG.TrainglrStyle.Top;
			this.mgTriangle5.Triangle = MGDesigner.MG_COLOR.Yellow;
			this.mgTriangle5.TriangleFill = MGDesigner.MG_COLOR.Yellow;
			this.mgTriangle5.TriangleFillOpacity = 50D;
			this.mgTriangle5.TriangleOpacity = 100D;
			this.mgTriangle5.Weight = 2F;
			// 
			// mgPolygon1
			// 
			this.mgPolygon1.Back = MGDesigner.MG_COLOR.Black;
			this.mgPolygon1.BackColor = System.Drawing.Color.Transparent;
			this.mgPolygon1.BackOpacity = 100D;
			this.mgPolygon1.ForeColor = System.Drawing.Color.White;
			this.mgPolygon1.Length = 50F;
			this.mgPolygon1.Location = new System.Drawing.Point(162, 334);
			this.mgPolygon1.MGForm = this;
			this.mgPolygon1.Name = "mgPolygon1";
			this.mgPolygon1.Polygon = MGDesigner.MG_COLOR.White;
			this.mgPolygon1.PolygonCount = 6;
			this.mgPolygon1.PolygonFill = MGDesigner.MG_COLOR.Gray;
			this.mgPolygon1.PolygonFillOpacity = 0D;
			this.mgPolygon1.PolygonOpacity = 100D;
			this.mgPolygon1.Rot = 0F;
			this.mgPolygon1.Size = new System.Drawing.Size(138, 121);
			this.mgPolygon1.TabIndex = 20;
			this.mgPolygon1.Text = "mgPolygon1";
			this.mgPolygon1.Weight = 3F;
			// 
			// mgPolygon2
			// 
			this.mgPolygon2.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgPolygon2.BackColor = System.Drawing.Color.Transparent;
			this.mgPolygon2.BackOpacity = 100D;
			this.mgPolygon2.ForeColor = System.Drawing.Color.White;
			this.mgPolygon2.Length = 50F;
			this.mgPolygon2.Location = new System.Drawing.Point(333, 364);
			this.mgPolygon2.MGForm = this;
			this.mgPolygon2.Name = "mgPolygon2";
			this.mgPolygon2.Polygon = MGDesigner.MG_COLOR.White;
			this.mgPolygon2.PolygonCount = 5;
			this.mgPolygon2.PolygonFill = MGDesigner.MG_COLOR.Gray;
			this.mgPolygon2.PolygonFillOpacity = 50D;
			this.mgPolygon2.PolygonOpacity = 100D;
			this.mgPolygon2.Rot = 0F;
			this.mgPolygon2.Size = new System.Drawing.Size(132, 121);
			this.mgPolygon2.TabIndex = 21;
			this.mgPolygon2.Text = "mgPolygon2";
			this.mgPolygon2.Weight = 2F;
			// 
			// mgLabel1
			// 
			this.mgLabel1.Back = MGDesigner.MG_COLOR.Black;
			this.mgLabel1.BackColor = System.Drawing.Color.Transparent;
			this.mgLabel1.BackOpacity = 100D;
			this.mgLabel1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.mgLabel1.ForeColor = System.Drawing.Color.White;
			this.mgLabel1.Frame = MGDesigner.MG_COLOR.Gray;
			this.mgLabel1.FramelOpacity = 100D;
			this.mgLabel1.FrameWeight = 0;
			this.mgLabel1.Label = MGDesigner.MG_COLOR.White;
			this.mgLabel1.LabelOpacity = 100D;
			this.mgLabel1.LeftBox = new System.Drawing.Size(12, 12);
			this.mgLabel1.Location = new System.Drawing.Point(597, 12);
			this.mgLabel1.MGFont = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.mgLabel1.MGForm = this;
			this.mgLabel1.MGText = "mgLabel1";
			this.mgLabel1.MGTextMargion = 0;
			this.mgLabel1.Name = "mgLabel1";
			this.mgLabel1.RightBox = new System.Drawing.Size(0, 0);
			this.mgLabel1.Size = new System.Drawing.Size(154, 30);
			this.mgLabel1.StringAlignment = System.Drawing.StringAlignment.Near;
			this.mgLabel1.StringLineAlignment = System.Drawing.StringAlignment.Center;
			this.mgLabel1.TabIndex = 22;
			this.mgLabel1.Text = "mgLabel1";
			// 
			// mgLabel2
			// 
			this.mgLabel2.Back = MGDesigner.MG_COLOR.Black;
			this.mgLabel2.BackColor = System.Drawing.Color.Transparent;
			this.mgLabel2.BackOpacity = 100D;
			this.mgLabel2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.mgLabel2.ForeColor = System.Drawing.Color.White;
			this.mgLabel2.Frame = MGDesigner.MG_COLOR.Gray;
			this.mgLabel2.FramelOpacity = 100D;
			this.mgLabel2.FrameWeight = 1;
			this.mgLabel2.Label = MGDesigner.MG_COLOR.White;
			this.mgLabel2.LabelOpacity = 100D;
			this.mgLabel2.LeftBox = new System.Drawing.Size(12, 12);
			this.mgLabel2.Location = new System.Drawing.Point(597, 48);
			this.mgLabel2.MGFont = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.mgLabel2.MGForm = this;
			this.mgLabel2.MGText = "mgLabel2";
			this.mgLabel2.MGTextMargion = 0;
			this.mgLabel2.Name = "mgLabel2";
			this.mgLabel2.RightBox = new System.Drawing.Size(0, 0);
			this.mgLabel2.Size = new System.Drawing.Size(154, 30);
			this.mgLabel2.StringAlignment = System.Drawing.StringAlignment.Near;
			this.mgLabel2.StringLineAlignment = System.Drawing.StringAlignment.Center;
			this.mgLabel2.TabIndex = 23;
			this.mgLabel2.Text = "mgLabel2";
			// 
			// mgCircleScale1
			// 
			this.mgCircleScale1.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgCircleScale1.BackColor = System.Drawing.Color.Transparent;
			this.mgCircleScale1.BackOpacity = 100D;
			this.mgCircleScale1.ForeColor = System.Drawing.Color.White;
			this.mgCircleScale1.LineWeight = 2F;
			this.mgCircleScale1.Location = new System.Drawing.Point(216, 196);
			this.mgCircleScale1.MGForm = this;
			this.mgCircleScale1.Name = "mgCircleScale1";
			this.mgCircleScale1.RotValue = MGDesigner.RotValue.Rot2_5;
			this.mgCircleScale1.ScaleA = MGDesigner.MG_COLOR.White;
			this.mgCircleScale1.ScaleB = MGDesigner.MG_COLOR.White;
			this.mgCircleScale1.ScaleC = MGDesigner.MG_COLOR.White;
			this.mgCircleScale1.Size = new System.Drawing.Size(137, 115);
			this.mgCircleScale1.TabIndex = 24;
			this.mgCircleScale1.Text = "mgCircleScale1";
			this.mgCircleScale1.Weight = 15F;
			// 
			// mgCircleScale2
			// 
			this.mgCircleScale2.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgCircleScale2.BackColor = System.Drawing.Color.Transparent;
			this.mgCircleScale2.BackOpacity = 100D;
			this.mgCircleScale2.ForeColor = System.Drawing.Color.White;
			this.mgCircleScale2.LineWeight = 4F;
			this.mgCircleScale2.Location = new System.Drawing.Point(445, 158);
			this.mgCircleScale2.MGForm = this;
			this.mgCircleScale2.Name = "mgCircleScale2";
			this.mgCircleScale2.RotValue = MGDesigner.RotValue.Rot30;
			this.mgCircleScale2.ScaleA = MGDesigner.MG_COLOR.White;
			this.mgCircleScale2.ScaleB = MGDesigner.MG_COLOR.White;
			this.mgCircleScale2.ScaleC = MGDesigner.MG_COLOR.White;
			this.mgCircleScale2.Size = new System.Drawing.Size(120, 115);
			this.mgCircleScale2.TabIndex = 25;
			this.mgCircleScale2.Text = "mgCircleScale2";
			this.mgCircleScale2.Weight = 15F;
			// 
			// mgCross1
			// 
			this.mgCross1.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgCross1.BackColor = System.Drawing.Color.Transparent;
			this.mgCross1.BackOpacity = 100D;
			this.mgCross1.CrossFill = MGDesigner.MG_COLOR.White;
			this.mgCross1.CrossFillOpacity = 25D;
			this.mgCross1.CrossLine = MGDesigner.MG_COLOR.White;
			this.mgCross1.CrossLineOpacity = 50D;
			this.mgCross1.CrossLineWeight = 4F;
			this.mgCross1.CrossWeight = 10;
			this.mgCross1.ForeColor = System.Drawing.Color.White;
			this.mgCross1.Location = new System.Drawing.Point(362, 291);
			this.mgCross1.MGForm = this;
			this.mgCross1.Name = "mgCross1";
			this.mgCross1.Size = new System.Drawing.Size(83, 67);
			this.mgCross1.TabIndex = 26;
			this.mgCross1.Text = "mgCross1";
			// 
			// mgEdge1
			// 
			this.mgEdge1.Back = MGDesigner.MG_COLOR.Transparent;
			this.mgEdge1.BackColor = System.Drawing.Color.Transparent;
			this.mgEdge1.BackOpacity = 100D;
			this.mgEdge1.ForeColor = System.Drawing.Color.White;
			this.mgEdge1.Kagi = MGDesigner.MG_COLOR.White;
			this.mgEdge1.KagiEnabled = new bool[] {
        true,
        true,
        true,
        true};
			this.mgEdge1.kagiHeight = 20;
			this.mgEdge1.kagiMarginH = 10;
			this.mgEdge1.kagiMarginV = 10;
			this.mgEdge1.KagiOpacity = 100D;
			this.mgEdge1.kagiWeightH = 6;
			this.mgEdge1.kagiWeightV = 6;
			this.mgEdge1.kagiWidth = 20;
			this.mgEdge1.Location = new System.Drawing.Point(53, 68);
			this.mgEdge1.MGForm = this;
			this.mgEdge1.Name = "mgEdge1";
			this.mgEdge1.Size = new System.Drawing.Size(144, 160);
			this.mgEdge1.TabIndex = 27;
			this.mgEdge1.Text = "mgEdge1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Back = MGDesigner.MG_COLOR.Black;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(960, 545);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.mgEdge1);
			this.Controls.Add(this.mgCross1);
			this.Controls.Add(this.mgCircleScale2);
			this.Controls.Add(this.mgCircleScale1);
			this.Controls.Add(this.mgLabel2);
			this.Controls.Add(this.mgLabel1);
			this.Controls.Add(this.mgPolygon2);
			this.Controls.Add(this.mgPolygon1);
			this.Controls.Add(this.mgTriangle4);
			this.Controls.Add(this.mgTriangle5);
			this.Controls.Add(this.mgTriangle3);
			this.Controls.Add(this.mgTriangle2);
			this.Controls.Add(this.mgPlate3);
			this.Controls.Add(this.mgPlate2);
			this.Controls.Add(this.mgPlate1);
			this.Controls.Add(this.mgTriangle1);
			this.Controls.Add(this.mgKagi2);
			this.Controls.Add(this.mgCircle1);
			this.Controls.Add(this.mgSheet2);
			this.Controls.Add(this.mgSheet1);
			this.Controls.Add(this.mgKagi1);
			this.Controls.Add(this.mgFrame2);
			this.Controls.Add(this.mgScale2);
			this.Controls.Add(this.mgScale1);
			this.Controls.Add(this.mgFrame1);
			this.Controls.Add(this.mgFrame3);
			this.Controls.Add(this.mgCircle2);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.FrameWeight = 2;
			this.Grid = MGDesigner.MG_COLOR.Gray;
			this.GridHeight = 50F;
			this.GridOpacity = 25D;
			this.GridWeight = 2F;
			this.GridWidth = 50F;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private TextBox textBox2;
		private TextBox textBox3;
		private Button button2;
		private MGFrame mgFrame1;
		private MGScale mgScale1;
		private MGScale mgScale2;
		private MGKagi mgKagi1;
		private MGFrame mgFrame2;
		private MGSheet mgSheet1;
		private MGSheet mgSheet2;
		private MGCircle mgCircle1;
		private MGKagi mgKagi2;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem exportPartsToolStripMenuItem;
		private ToolStripMenuItem exportMixToolStripMenuItem;
		private ToolStripMenuItem quitToolStripMenuItem;
		private MGTriangle mgTriangle1;
		private MGTriangle mgTriangle4;
		private MGTriangle mgTriangle5;
		private MGTriangle mgTriangle3;
		private MGTriangle mgTriangle2;
		private MGCircle mgCircle2;
		private MGPlate mgPlate3;
		private MGPlate mgPlate2;
		private MGPlate mgPlate1;
		private MGFrame mgFrame3;
		private MGPolygon mgPolygon1;
		private MGPolygon mgPolygon2;
		private MGLabel mgLabel1;
		private MGLabel mgLabel2;
		private MGCircleScale mgCircleScale1;
		private MGCircleScale mgCircleScale2;
		private MGCross mgCross1;
		private MGKagiEdge mgEdge1;
	}
}