
namespace ROP
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonTop = new System.Windows.Forms.Button();
            this.buttonBottom = new System.Windows.Forms.Button();
            this.buttonFront = new System.Windows.Forms.Button();
            this.buttonAlgorithm = new System.Windows.Forms.Button();
            this.textBoxAlgorithm = new System.Windows.Forms.TextBox();
            this.algorithm2 = new System.Windows.Forms.Button();
            this.algorithm1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.scrambleButton = new System.Windows.Forms.Button();
            this.solveButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonEquator = new System.Windows.Forms.Button();
            this.buttonStanding = new System.Windows.Forms.Button();
            this.buttonMiddle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonHistory = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRight.Location = new System.Drawing.Point(653, 577);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(75, 23);
            this.buttonRight.TabIndex = 0;
            this.buttonRight.Text = "R";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonTurn);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLeft.Location = new System.Drawing.Point(653, 606);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(75, 23);
            this.buttonLeft.TabIndex = 1;
            this.buttonLeft.Text = "L";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonTurn);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.Location = new System.Drawing.Point(653, 635);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "B";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonTurn);
            // 
            // buttonTop
            // 
            this.buttonTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTop.Location = new System.Drawing.Point(572, 577);
            this.buttonTop.Name = "buttonTop";
            this.buttonTop.Size = new System.Drawing.Size(75, 23);
            this.buttonTop.TabIndex = 3;
            this.buttonTop.Text = "U";
            this.buttonTop.UseVisualStyleBackColor = true;
            this.buttonTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonTurn);
            // 
            // buttonBottom
            // 
            this.buttonBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBottom.Location = new System.Drawing.Point(572, 606);
            this.buttonBottom.Name = "buttonBottom";
            this.buttonBottom.Size = new System.Drawing.Size(75, 23);
            this.buttonBottom.TabIndex = 4;
            this.buttonBottom.Text = "D";
            this.buttonBottom.UseVisualStyleBackColor = true;
            this.buttonBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonTurn);
            // 
            // buttonFront
            // 
            this.buttonFront.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFront.Location = new System.Drawing.Point(572, 635);
            this.buttonFront.Name = "buttonFront";
            this.buttonFront.Size = new System.Drawing.Size(75, 23);
            this.buttonFront.TabIndex = 5;
            this.buttonFront.Text = "F";
            this.buttonFront.UseVisualStyleBackColor = true;
            this.buttonFront.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonTurn);
            // 
            // buttonAlgorithm
            // 
            this.buttonAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAlgorithm.Location = new System.Drawing.Point(613, 694);
            this.buttonAlgorithm.Name = "buttonAlgorithm";
            this.buttonAlgorithm.Size = new System.Drawing.Size(115, 23);
            this.buttonAlgorithm.TabIndex = 6;
            this.buttonAlgorithm.Text = "Proveď algoritmus";
            this.buttonAlgorithm.UseVisualStyleBackColor = true;
            this.buttonAlgorithm.Click += new System.EventHandler(this.buttonAlgorithm_Click);
            // 
            // textBoxAlgorithm
            // 
            this.textBoxAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAlgorithm.Location = new System.Drawing.Point(388, 668);
            this.textBoxAlgorithm.Name = "textBoxAlgorithm";
            this.textBoxAlgorithm.Size = new System.Drawing.Size(340, 20);
            this.textBoxAlgorithm.TabIndex = 7;
            // 
            // algorithm2
            // 
            this.algorithm2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.algorithm2.Location = new System.Drawing.Point(381, 634);
            this.algorithm2.Name = "algorithm2";
            this.algorithm2.Size = new System.Drawing.Size(96, 23);
            this.algorithm2.TabIndex = 8;
            this.algorithm2.Text = "Šachovnice";
            this.algorithm2.UseVisualStyleBackColor = true;
            this.algorithm2.Click += new System.EventHandler(this.algorithm2_Click);
            // 
            // algorithm1
            // 
            this.algorithm1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.algorithm1.Location = new System.Drawing.Point(381, 605);
            this.algorithm1.Name = "algorithm1";
            this.algorithm1.Size = new System.Drawing.Size(96, 23);
            this.algorithm1.TabIndex = 9;
            this.algorithm1.Text = "Kostka v kostce";
            this.algorithm1.UseVisualStyleBackColor = true;
            this.algorithm1.Click += new System.EventHandler(this.algorithm1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 582);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Algoritmy:";
            // 
            // scrambleButton
            // 
            this.scrambleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.scrambleButton.Location = new System.Drawing.Point(477, 605);
            this.scrambleButton.Name = "scrambleButton";
            this.scrambleButton.Size = new System.Drawing.Size(89, 23);
            this.scrambleButton.TabIndex = 11;
            this.scrambleButton.Text = "Zamíchat";
            this.scrambleButton.UseVisualStyleBackColor = true;
            this.scrambleButton.Click += new System.EventHandler(this.scrambleButton_Click);
            // 
            // solveButton
            // 
            this.solveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.solveButton.Location = new System.Drawing.Point(477, 634);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(89, 23);
            this.solveButton.TabIndex = 12;
            this.solveButton.Text = "Poskládat";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(550, 550);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Aa - ",
            "Ab - ",
            "E",
            "F",
            "Ga",
            "Gb",
            "Gc",
            "Gd",
            "H",
            "Ja",
            "Jb",
            "Na",
            "Nb",
            "Ra - RUR\'F\'RU2R\'U2R\'FRURU2R\'",
            "Rb - L\'U\'LFL\'U2LU2LF\'L\'U\'L\'U2L",
            "T - R U R\' U\' R\' F R2 U\' R\' U\' R U R\' F\'",
            "Ua - y2 M2 U M U2 M\' U M2",
            "Ub - y2 M2 U\' M U2 M\' U\' M2",
            "V - R\' U R\' U\' R D\' R\' D R\' U D\' R2 U\' R2 D R2",
            "Y - F R U\' R\' U\' R U R\' F\' R U R\' U\' R\' F R F\'",
            "Z - M\' U\' M2 U\' M2 U\' M\' U2 M2"});
            this.comboBox1.Location = new System.Drawing.Point(568, 425);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 21);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 694);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Historie:";
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.Location = new System.Drawing.Point(567, 12);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(160, 23);
            this.buttonHelp.TabIndex = 18;
            this.buttonHelp.Text = "Návod";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonEquator
            // 
            this.buttonEquator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEquator.Location = new System.Drawing.Point(572, 539);
            this.buttonEquator.Name = "buttonEquator";
            this.buttonEquator.Size = new System.Drawing.Size(75, 23);
            this.buttonEquator.TabIndex = 19;
            this.buttonEquator.Text = "E";
            this.buttonEquator.UseVisualStyleBackColor = true;
            this.buttonEquator.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonTurn);
            // 
            // buttonStanding
            // 
            this.buttonStanding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStanding.Location = new System.Drawing.Point(653, 539);
            this.buttonStanding.Name = "buttonStanding";
            this.buttonStanding.Size = new System.Drawing.Size(75, 23);
            this.buttonStanding.TabIndex = 20;
            this.buttonStanding.Text = "S";
            this.buttonStanding.UseVisualStyleBackColor = true;
            this.buttonStanding.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonTurn);
            // 
            // buttonMiddle
            // 
            this.buttonMiddle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMiddle.Location = new System.Drawing.Point(572, 510);
            this.buttonMiddle.Name = "buttonMiddle";
            this.buttonMiddle.Size = new System.Drawing.Size(75, 23);
            this.buttonMiddle.TabIndex = 21;
            this.buttonMiddle.Text = "M";
            this.buttonMiddle.UseVisualStyleBackColor = true;
            this.buttonMiddle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonTurn);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(565, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "PLL algoritmy:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(568, 373);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(159, 20);
            this.numericUpDown1.TabIndex = 23;
            this.numericUpDown1.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.ChangeSpeed);
            this.numericUpDown1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChangeSpeed);
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(565, 357);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(91, 13);
            this.labelSpeed.TabIndex = 24;
            this.labelSpeed.Text = "Rychlost otáčení:";
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(477, 577);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(89, 23);
            this.buttonReset.TabIndex = 25;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonHistory
            // 
            this.buttonHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHistory.Location = new System.Drawing.Point(15, 665);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(160, 23);
            this.buttonHistory.TabIndex = 26;
            this.buttonHistory.Text = "Zobrazit celou historii";
            this.buttonHistory.UseVisualStyleBackColor = true;
            this.buttonHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown2.DecimalPlaces = 1;
            this.numericUpDown2.Location = new System.Drawing.Point(569, 325);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(159, 20);
            this.numericUpDown2.TabIndex = 27;
            this.numericUpDown2.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.ChangeDistance);
            this.numericUpDown2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChangeDistance);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(566, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Vzdálenost od kamery";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 725);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.buttonHistory);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonMiddle);
            this.Controls.Add(this.buttonStanding);
            this.Controls.Add(this.buttonEquator);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.scrambleButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.algorithm1);
            this.Controls.Add(this.algorithm2);
            this.Controls.Add(this.textBoxAlgorithm);
            this.Controls.Add(this.buttonAlgorithm);
            this.Controls.Add(this.buttonFront);
            this.Controls.Add(this.buttonBottom);
            this.Controls.Add(this.buttonTop);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Simulátor Rubikovy kostky";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonTop;
        private System.Windows.Forms.Button buttonBottom;
        private System.Windows.Forms.Button buttonFront;
        private System.Windows.Forms.Button buttonAlgorithm;
        private System.Windows.Forms.TextBox textBoxAlgorithm;
        private System.Windows.Forms.Button algorithm2;
        private System.Windows.Forms.Button algorithm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button scrambleButton;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonEquator;
        private System.Windows.Forms.Button buttonStanding;
        private System.Windows.Forms.Button buttonMiddle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonHistory;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label4;
    }
}

