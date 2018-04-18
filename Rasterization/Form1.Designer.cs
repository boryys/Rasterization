namespace Rasterization
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.comboBoxT = new System.Windows.Forms.ComboBox();
            this.comboBoxA = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tLineButton = new System.Windows.Forms.RadioButton();
            this.antiAlButton = new System.Windows.Forms.RadioButton();
            this.CircleButton = new System.Windows.Forms.RadioButton();
            this.LineButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(962, 540);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.clearButton);
            this.panel1.Controls.Add(this.applyButton);
            this.panel1.Controls.Add(this.comboBoxT);
            this.panel1.Controls.Add(this.comboBoxA);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tLineButton);
            this.panel1.Controls.Add(this.antiAlButton);
            this.panel1.Controls.Add(this.CircleButton);
            this.panel1.Controls.Add(this.LineButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(814, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 536);
            this.panel1.TabIndex = 0;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(10, 479);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(126, 40);
            this.clearButton.TabIndex = 14;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(10, 420);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(126, 40);
            this.applyButton.TabIndex = 13;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // comboBoxT
            // 
            this.comboBoxT.FormattingEnabled = true;
            this.comboBoxT.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "7"});
            this.comboBoxT.Location = new System.Drawing.Point(86, 369);
            this.comboBoxT.Name = "comboBoxT";
            this.comboBoxT.Size = new System.Drawing.Size(46, 21);
            this.comboBoxT.TabIndex = 12;
            this.comboBoxT.Text = "1";
            // 
            // comboBoxA
            // 
            this.comboBoxA.FormattingEnabled = true;
            this.comboBoxA.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBoxA.Location = new System.Drawing.Point(86, 335);
            this.comboBoxA.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.comboBoxA.Name = "comboBoxA";
            this.comboBoxA.Size = new System.Drawing.Size(46, 21);
            this.comboBoxA.TabIndex = 11;
            this.comboBoxA.Text = "1";

            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 302);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Choose thickness";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Thick line";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Anti-aliasing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Choose points";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Silver;
            this.button2.Location = new System.Drawing.Point(76, 239);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 20, 10, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "second point";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Location = new System.Drawing.Point(10, 239);
            this.button1.Margin = new System.Windows.Forms.Padding(10, 20, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "first point";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tLineButton
            // 
            this.tLineButton.AutoSize = true;
            this.tLineButton.Location = new System.Drawing.Point(21, 166);
            this.tLineButton.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.tLineButton.Name = "tLineButton";
            this.tLineButton.Size = new System.Drawing.Size(111, 17);
            this.tLineButton.TabIndex = 4;
            this.tLineButton.TabStop = true;
            this.tLineButton.Text = "Thick line drawing";
            this.tLineButton.UseVisualStyleBackColor = true;
            this.tLineButton.CheckedChanged += new System.EventHandler(this.tLineButton_CheckedChanged);
            // 
            // antiAlButton
            // 
            this.antiAlButton.AutoSize = true;
            this.antiAlButton.Location = new System.Drawing.Point(21, 126);
            this.antiAlButton.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.antiAlButton.Name = "antiAlButton";
            this.antiAlButton.Size = new System.Drawing.Size(81, 17);
            this.antiAlButton.TabIndex = 3;
            this.antiAlButton.TabStop = true;
            this.antiAlButton.Text = "Anit-aliasing";
            this.antiAlButton.UseVisualStyleBackColor = true;
            this.antiAlButton.CheckedChanged += new System.EventHandler(this.antiAlButton_CheckedChanged);
            // 
            // CircleButton
            // 
            this.CircleButton.AutoSize = true;
            this.CircleButton.Location = new System.Drawing.Point(21, 86);
            this.CircleButton.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.CircleButton.Name = "CircleButton";
            this.CircleButton.Size = new System.Drawing.Size(91, 17);
            this.CircleButton.TabIndex = 2;
            this.CircleButton.TabStop = true;
            this.CircleButton.Text = "Circle drawing";
            this.CircleButton.UseVisualStyleBackColor = true;
            this.CircleButton.CheckedChanged += new System.EventHandler(this.CircleButton_CheckedChanged);
            // 
            // LineButton
            // 
            this.LineButton.AutoSize = true;
            this.LineButton.Location = new System.Drawing.Point(21, 46);
            this.LineButton.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(85, 17);
            this.LineButton.TabIndex = 1;
            this.LineButton.TabStop = true;
            this.LineButton.Text = "Line drawing";
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.CheckedChanged += new System.EventHandler(this.LineButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Options";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(810, 536);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rasterization";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.ComboBox comboBoxT;
        private System.Windows.Forms.ComboBox comboBoxA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton tLineButton;
        private System.Windows.Forms.RadioButton antiAlButton;
        private System.Windows.Forms.RadioButton CircleButton;
        private System.Windows.Forms.RadioButton LineButton;
        private System.Windows.Forms.Label label1;
    }
}

