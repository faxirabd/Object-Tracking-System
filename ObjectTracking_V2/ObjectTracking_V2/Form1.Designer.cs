namespace ObjectTracking_V2
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
            this.Cam_lbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.imagetrangle = new Emgu.CV.UI.ImageBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.imagecany = new Emgu.CV.UI.ImageBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.Rmax = new System.Windows.Forms.TextBox();
            this.Gmax = new System.Windows.Forms.TextBox();
            this.Bmax = new System.Windows.Forms.TextBox();
            this.Rmin = new System.Windows.Forms.TextBox();
            this.Gmin = new System.Windows.Forms.TextBox();
            this.Bmin = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.captureButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PolygontrackBar1 = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.areatrackBar = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Circlemaxsize = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Circleminsize_SLD = new System.Windows.Forms.TrackBar();
            this.Sharpness_LBL = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Brigtness_SLD = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.Brigthness_LBL = new System.Windows.Forms.Label();
            this.Contrast_LBL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Threshold_SLD = new System.Windows.Forms.TrackBar();
            this.Reset_Cam_Settings = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PosTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Shape_Selection = new System.Windows.Forms.ComboBox();
            this.flipHorizontalButton = new System.Windows.Forms.Button();
            this.flipVerticalButton = new System.Windows.Forms.Button();
            this.lstDeviceList = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagetrangle)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagecany)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PolygontrackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areatrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Circlemaxsize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Circleminsize_SLD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Brigtness_SLD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Threshold_SLD)).BeginInit();
            this.SuspendLayout();
            // 
            // Cam_lbl
            // 
            this.Cam_lbl.AutoSize = true;
            this.Cam_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cam_lbl.Location = new System.Drawing.Point(2, 9);
            this.Cam_lbl.Name = "Cam_lbl";
            this.Cam_lbl.Size = new System.Drawing.Size(99, 16);
            this.Cam_lbl.TabIndex = 2;
            this.Cam_lbl.Text = "Camera View";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.imagetrangle);
            this.groupBox2.Location = new System.Drawing.Point(5, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 299);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detect Shapes";
            // 
            // imagetrangle
            // 
            this.imagetrangle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.imagetrangle.Location = new System.Drawing.Point(3, 19);
            this.imagetrangle.Name = "imagetrangle";
            this.imagetrangle.Size = new System.Drawing.Size(443, 303);
            this.imagetrangle.TabIndex = 3;
            this.imagetrangle.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.imagecany);
            this.groupBox3.Location = new System.Drawing.Point(5, 333);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(452, 313);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cany detect";
            // 
            // imagecany
            // 
            this.imagecany.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.imagecany.Location = new System.Drawing.Point(3, 19);
            this.imagecany.Name = "imagecany";
            this.imagecany.Size = new System.Drawing.Size(437, 329);
            this.imagecany.TabIndex = 3;
            this.imagecany.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.lstDeviceList);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.captureButton);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.Reset_Cam_Settings);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PosTextBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Shape_Selection);
            this.groupBox1.Controls.Add(this.flipHorizontalButton);
            this.groupBox1.Controls.Add(this.flipVerticalButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(463, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 672);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(215, 105);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 20);
            this.checkBox1.TabIndex = 49;
            this.checkBox1.Text = "Detect by color";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.Rmax);
            this.groupBox4.Controls.Add(this.Gmax);
            this.groupBox4.Controls.Add(this.Bmax);
            this.groupBox4.Controls.Add(this.Rmin);
            this.groupBox4.Controls.Add(this.Gmin);
            this.groupBox4.Controls.Add(this.Bmin);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Location = new System.Drawing.Point(18, 127);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(468, 57);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Object Color Filter:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(433, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 16);
            this.label14.TabIndex = 84;
            this.label14.Text = "R:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(399, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 16);
            this.label15.TabIndex = 83;
            this.label15.Text = "G:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(369, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 16);
            this.label16.TabIndex = 82;
            this.label16.Text = "B:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(264, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 16);
            this.label17.TabIndex = 81;
            this.label17.Text = "R:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(232, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 16);
            this.label18.TabIndex = 80;
            this.label18.Text = "G:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(194, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 16);
            this.label19.TabIndex = 79;
            this.label19.Text = "B:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(295, 38);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 15);
            this.label20.TabIndex = 78;
            this.label20.Text = "BGR max";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(127, 37);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 15);
            this.label21.TabIndex = 77;
            this.label21.Text = "BGR min";
            // 
            // Rmax
            // 
            this.Rmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rmax.Location = new System.Drawing.Point(436, 37);
            this.Rmax.Name = "Rmax";
            this.Rmax.Size = new System.Drawing.Size(28, 20);
            this.Rmax.TabIndex = 75;
            this.Rmax.Text = "256";
            this.Rmax.TextChanged += new System.EventHandler(this.Rmax_TextChanged);
            // 
            // Gmax
            // 
            this.Gmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gmax.Location = new System.Drawing.Point(402, 37);
            this.Gmax.Name = "Gmax";
            this.Gmax.Size = new System.Drawing.Size(28, 20);
            this.Gmax.TabIndex = 74;
            this.Gmax.Text = "100";
            this.Gmax.TextChanged += new System.EventHandler(this.Gmax_TextChanged);
            // 
            // Bmax
            // 
            this.Bmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bmax.Location = new System.Drawing.Point(368, 37);
            this.Bmax.Name = "Bmax";
            this.Bmax.Size = new System.Drawing.Size(28, 20);
            this.Bmax.TabIndex = 73;
            this.Bmax.Text = "100";
            this.Bmax.TextChanged += new System.EventHandler(this.Bmax_TextChanged);
            // 
            // Rmin
            // 
            this.Rmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rmin.Location = new System.Drawing.Point(265, 34);
            this.Rmin.Name = "Rmin";
            this.Rmin.Size = new System.Drawing.Size(28, 20);
            this.Rmin.TabIndex = 72;
            this.Rmin.Text = "175";
            this.Rmin.TextChanged += new System.EventHandler(this.Rmin_TextChanged);
            // 
            // Gmin
            // 
            this.Gmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gmin.Location = new System.Drawing.Point(231, 34);
            this.Gmin.Name = "Gmin";
            this.Gmin.Size = new System.Drawing.Size(28, 20);
            this.Gmin.TabIndex = 71;
            this.Gmin.Text = "0";
            this.Gmin.TextChanged += new System.EventHandler(this.Gmin_TextChanged);
            // 
            // Bmin
            // 
            this.Bmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bmin.Location = new System.Drawing.Point(197, 34);
            this.Bmin.Name = "Bmin";
            this.Bmin.Size = new System.Drawing.Size(28, 20);
            this.Bmin.TabIndex = 70;
            this.Bmin.Text = "0";
            this.Bmin.TextChanged += new System.EventHandler(this.Bmin_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(5, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(162, 15);
            this.label23.TabIndex = 69;
            this.label23.Text = "B=Blue G=Green R=Red";
            // 
            // captureButton
            // 
            this.captureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureButton.Location = new System.Drawing.Point(215, 76);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(102, 23);
            this.captureButton.TabIndex = 48;
            this.captureButton.Text = "Start Capture";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.PolygontrackBar1);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.areatrackBar);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.Circlemaxsize);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.Circleminsize_SLD);
            this.panel2.Controls.Add(this.Sharpness_LBL);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.Brigtness_SLD);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.Brigthness_LBL);
            this.panel2.Controls.Add(this.Contrast_LBL);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.Threshold_SLD);
            this.panel2.Location = new System.Drawing.Point(25, 250);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(441, 292);
            this.panel2.TabIndex = 47;
            // 
            // PolygontrackBar1
            // 
            this.PolygontrackBar1.LargeChange = 1;
            this.PolygontrackBar1.Location = new System.Drawing.Point(104, 204);
            this.PolygontrackBar1.Name = "PolygontrackBar1";
            this.PolygontrackBar1.Size = new System.Drawing.Size(238, 45);
            this.PolygontrackBar1.TabIndex = 30;
            this.PolygontrackBar1.Value = 6;
            this.PolygontrackBar1.Scroll += new System.EventHandler(this.PolygontrackBar1_Scroll);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(348, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 16);
            this.label12.TabIndex = 31;
            this.label12.Text = "6";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(-2, 204);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 16);
            this.label13.TabIndex = 32;
            this.label13.Text = "Polygon_select:";
            // 
            // areatrackBar
            // 
            this.areatrackBar.LargeChange = 1;
            this.areatrackBar.Location = new System.Drawing.Point(104, 163);
            this.areatrackBar.Maximum = 100;
            this.areatrackBar.Name = "areatrackBar";
            this.areatrackBar.Size = new System.Drawing.Size(238, 45);
            this.areatrackBar.TabIndex = 27;
            this.areatrackBar.TickFrequency = 5;
            this.areatrackBar.Value = 50;
            this.areatrackBar.Scroll += new System.EventHandler(this.areatrackBar_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(348, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "50";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(58, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 16);
            this.label11.TabIndex = 29;
            this.label11.Text = "Area:";
            // 
            // Circlemaxsize
            // 
            this.Circlemaxsize.LargeChange = 1;
            this.Circlemaxsize.Location = new System.Drawing.Point(104, 124);
            this.Circlemaxsize.Maximum = 100;
            this.Circlemaxsize.Name = "Circlemaxsize";
            this.Circlemaxsize.Size = new System.Drawing.Size(238, 45);
            this.Circlemaxsize.TabIndex = 24;
            this.Circlemaxsize.TickFrequency = 5;
            this.Circlemaxsize.Value = 40;
            this.Circlemaxsize.Scroll += new System.EventHandler(this.Circlemaxsize_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(348, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "40";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(-3, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = "Circle_Mix_size:";
            // 
            // Circleminsize_SLD
            // 
            this.Circleminsize_SLD.LargeChange = 1;
            this.Circleminsize_SLD.Location = new System.Drawing.Point(104, 84);
            this.Circleminsize_SLD.Maximum = 100;
            this.Circleminsize_SLD.Name = "Circleminsize_SLD";
            this.Circleminsize_SLD.Size = new System.Drawing.Size(238, 45);
            this.Circleminsize_SLD.TabIndex = 21;
            this.Circleminsize_SLD.TickFrequency = 5;
            this.Circleminsize_SLD.Value = 5;
            this.Circleminsize_SLD.Scroll += new System.EventHandler(this.Circleminsize_SLD_Scroll);
            // 
            // Sharpness_LBL
            // 
            this.Sharpness_LBL.AutoSize = true;
            this.Sharpness_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sharpness_LBL.Location = new System.Drawing.Point(354, 84);
            this.Sharpness_LBL.Name = "Sharpness_LBL";
            this.Sharpness_LBL.Size = new System.Drawing.Size(16, 16);
            this.Sharpness_LBL.TabIndex = 22;
            this.Sharpness_LBL.Text = "5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(-4, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Circle_Min_size:";
            // 
            // Brigtness_SLD
            // 
            this.Brigtness_SLD.Location = new System.Drawing.Point(104, 3);
            this.Brigtness_SLD.Maximum = 100;
            this.Brigtness_SLD.Name = "Brigtness_SLD";
            this.Brigtness_SLD.Size = new System.Drawing.Size(238, 45);
            this.Brigtness_SLD.TabIndex = 14;
            this.Brigtness_SLD.TickFrequency = 5;
            this.Brigtness_SLD.Scroll += new System.EventHandler(this.Brigtness_SLD_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Threshold:";
            // 
            // Brigthness_LBL
            // 
            this.Brigthness_LBL.AutoSize = true;
            this.Brigthness_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Brigthness_LBL.Location = new System.Drawing.Point(346, 3);
            this.Brigthness_LBL.Name = "Brigthness_LBL";
            this.Brigthness_LBL.Size = new System.Drawing.Size(16, 16);
            this.Brigthness_LBL.TabIndex = 15;
            this.Brigthness_LBL.Text = "0";
            // 
            // Contrast_LBL
            // 
            this.Contrast_LBL.AutoSize = true;
            this.Contrast_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contrast_LBL.Location = new System.Drawing.Point(346, 44);
            this.Contrast_LBL.Name = "Contrast_LBL";
            this.Contrast_LBL.Size = new System.Drawing.Size(32, 16);
            this.Contrast_LBL.TabIndex = 19;
            this.Contrast_LBL.Text = "150";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Brightness:";
            // 
            // Threshold_SLD
            // 
            this.Threshold_SLD.Location = new System.Drawing.Point(104, 44);
            this.Threshold_SLD.Maximum = 255;
            this.Threshold_SLD.Minimum = 3;
            this.Threshold_SLD.Name = "Threshold_SLD";
            this.Threshold_SLD.Size = new System.Drawing.Size(238, 45);
            this.Threshold_SLD.TabIndex = 18;
            this.Threshold_SLD.TickFrequency = 5;
            this.Threshold_SLD.Value = 150;
            this.Threshold_SLD.Scroll += new System.EventHandler(this.Threshold_SLD_Scroll);
            // 
            // Reset_Cam_Settings
            // 
            this.Reset_Cam_Settings.Location = new System.Drawing.Point(305, 548);
            this.Reset_Cam_Settings.Name = "Reset_Cam_Settings";
            this.Reset_Cam_Settings.Size = new System.Drawing.Size(102, 23);
            this.Reset_Cam_Settings.TabIndex = 46;
            this.Reset_Cam_Settings.Text = "Reset";
            this.Reset_Cam_Settings.UseVisualStyleBackColor = true;
            this.Reset_Cam_Settings.Click += new System.EventHandler(this.Reset_Cam_Settings_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "Settings";
            // 
            // PosTextBox1
            // 
            this.PosTextBox1.Location = new System.Drawing.Point(25, 574);
            this.PosTextBox1.Name = "PosTextBox1";
            this.PosTextBox1.Size = new System.Drawing.Size(382, 100);
            this.PosTextBox1.TabIndex = 44;
            this.PosTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 555);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "Info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "View";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "Chose shape";
            // 
            // Shape_Selection
            // 
            this.Shape_Selection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shape_Selection.FormattingEnabled = true;
            this.Shape_Selection.Items.AddRange(new object[] {
            "Rectangle",
            "Circle ",
            "Line",
            "Trangle",
            "Pentagon",
            "Polygon"});
            this.Shape_Selection.Location = new System.Drawing.Point(23, 58);
            this.Shape_Selection.Name = "Shape_Selection";
            this.Shape_Selection.Size = new System.Drawing.Size(180, 24);
            this.Shape_Selection.TabIndex = 40;
            // 
            // flipHorizontalButton
            // 
            this.flipHorizontalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flipHorizontalButton.Location = new System.Drawing.Point(131, 205);
            this.flipHorizontalButton.Name = "flipHorizontalButton";
            this.flipHorizontalButton.Size = new System.Drawing.Size(102, 23);
            this.flipHorizontalButton.TabIndex = 38;
            this.flipHorizontalButton.Text = "Flip Horizontal";
            this.flipHorizontalButton.UseVisualStyleBackColor = true;
            this.flipHorizontalButton.Click += new System.EventHandler(this.flipHorizontalButton_Click);
            // 
            // flipVerticalButton
            // 
            this.flipVerticalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flipVerticalButton.Location = new System.Drawing.Point(23, 205);
            this.flipVerticalButton.Name = "flipVerticalButton";
            this.flipVerticalButton.Size = new System.Drawing.Size(102, 23);
            this.flipVerticalButton.TabIndex = 39;
            this.flipVerticalButton.Text = "Flip Vertical";
            this.flipVerticalButton.UseVisualStyleBackColor = true;
            this.flipVerticalButton.Click += new System.EventHandler(this.flipVerticalButton_Click);
            // 
            // lstDeviceList
            // 
            this.lstDeviceList.FormattingEnabled = true;
            this.lstDeviceList.Location = new System.Drawing.Point(23, 97);
            this.lstDeviceList.Name = "lstDeviceList";
            this.lstDeviceList.Size = new System.Drawing.Size(182, 24);
            this.lstDeviceList.TabIndex = 50;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(23, 83);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(110, 16);
            this.label22.TabIndex = 51;
            this.label22.Text = "Camera Select";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(963, 692);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Cam_lbl);
            this.Name = "Form1";
            this.Text = "ObjectTracking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagetrangle)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagecany)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PolygontrackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areatrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Circlemaxsize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Circleminsize_SLD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Brigtness_SLD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Threshold_SLD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Cam_lbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private Emgu.CV.UI.ImageBox imagetrangle;
        private System.Windows.Forms.GroupBox groupBox3;
        private Emgu.CV.UI.ImageBox imagecany;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar PolygontrackBar1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar areatrackBar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar Circlemaxsize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar Circleminsize_SLD;
        private System.Windows.Forms.Label Sharpness_LBL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar Brigtness_SLD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Brigthness_LBL;
        private System.Windows.Forms.Label Contrast_LBL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar Threshold_SLD;
        private System.Windows.Forms.Button Reset_Cam_Settings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox PosTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Shape_Selection;
        private System.Windows.Forms.Button flipHorizontalButton;
        private System.Windows.Forms.Button flipVerticalButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox Rmax;
        private System.Windows.Forms.TextBox Gmax;
        private System.Windows.Forms.TextBox Bmax;
        private System.Windows.Forms.TextBox Rmin;
        private System.Windows.Forms.TextBox Gmin;
        private System.Windows.Forms.TextBox Bmin;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox lstDeviceList;
    }
}

