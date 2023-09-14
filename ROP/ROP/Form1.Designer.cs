
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
            this.SuspendLayout();
            // 
            // buttonRight
            // 
            this.buttonRight.Enabled = false;
            this.buttonRight.Location = new System.Drawing.Point(713, 12);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(75, 23);
            this.buttonRight.TabIndex = 0;
            this.buttonRight.Text = "R";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Enabled = false;
            this.buttonLeft.Location = new System.Drawing.Point(713, 41);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(75, 23);
            this.buttonLeft.TabIndex = 1;
            this.buttonLeft.Text = "L";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Enabled = false;
            this.buttonBack.Location = new System.Drawing.Point(713, 70);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "B";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonTop
            // 
            this.buttonTop.Enabled = false;
            this.buttonTop.Location = new System.Drawing.Point(632, 12);
            this.buttonTop.Name = "buttonTop";
            this.buttonTop.Size = new System.Drawing.Size(75, 23);
            this.buttonTop.TabIndex = 3;
            this.buttonTop.Text = "U";
            this.buttonTop.UseVisualStyleBackColor = true;
            this.buttonTop.Click += new System.EventHandler(this.buttonTop_Click);
            // 
            // buttonBottom
            // 
            this.buttonBottom.Enabled = false;
            this.buttonBottom.Location = new System.Drawing.Point(632, 41);
            this.buttonBottom.Name = "buttonBottom";
            this.buttonBottom.Size = new System.Drawing.Size(75, 23);
            this.buttonBottom.TabIndex = 4;
            this.buttonBottom.Text = "D";
            this.buttonBottom.UseVisualStyleBackColor = true;
            this.buttonBottom.Click += new System.EventHandler(this.buttonBottom_Click);
            // 
            // buttonFront
            // 
            this.buttonFront.Enabled = false;
            this.buttonFront.Location = new System.Drawing.Point(632, 70);
            this.buttonFront.Name = "buttonFront";
            this.buttonFront.Size = new System.Drawing.Size(75, 23);
            this.buttonFront.TabIndex = 5;
            this.buttonFront.Text = "F";
            this.buttonFront.UseVisualStyleBackColor = true;
            this.buttonFront.Click += new System.EventHandler(this.buttonFront_Click);
            // 
            // buttonAlgorithm
            // 
            this.buttonAlgorithm.Enabled = false;
            this.buttonAlgorithm.Location = new System.Drawing.Point(673, 129);
            this.buttonAlgorithm.Name = "buttonAlgorithm";
            this.buttonAlgorithm.Size = new System.Drawing.Size(115, 23);
            this.buttonAlgorithm.TabIndex = 6;
            this.buttonAlgorithm.Text = "Proveď algoritmus";
            this.buttonAlgorithm.UseVisualStyleBackColor = true;
            this.buttonAlgorithm.Click += new System.EventHandler(this.buttonAlgorithm_Click);
            // 
            // textBoxAlgorithm
            // 
            this.textBoxAlgorithm.Enabled = false;
            this.textBoxAlgorithm.Location = new System.Drawing.Point(448, 103);
            this.textBoxAlgorithm.Name = "textBoxAlgorithm";
            this.textBoxAlgorithm.Size = new System.Drawing.Size(340, 20);
            this.textBoxAlgorithm.TabIndex = 7;
            // 
            // algorithm2
            // 
            this.algorithm2.Enabled = false;
            this.algorithm2.Location = new System.Drawing.Point(448, 69);
            this.algorithm2.Name = "algorithm2";
            this.algorithm2.Size = new System.Drawing.Size(89, 23);
            this.algorithm2.TabIndex = 8;
            this.algorithm2.Text = "Checker";
            this.algorithm2.UseVisualStyleBackColor = true;
            this.algorithm2.Click += new System.EventHandler(this.algorithm2_Click);
            // 
            // algorithm1
            // 
            this.algorithm1.Enabled = false;
            this.algorithm1.Location = new System.Drawing.Point(448, 40);
            this.algorithm1.Name = "algorithm1";
            this.algorithm1.Size = new System.Drawing.Size(89, 23);
            this.algorithm1.TabIndex = 9;
            this.algorithm1.Text = "Cube in a Cube";
            this.algorithm1.UseVisualStyleBackColor = true;
            this.algorithm1.Click += new System.EventHandler(this.algorithm1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(448, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Algoritmy:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
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
    }
}

