namespace Linear_programm_task
{
    partial class StepSimplecsSolution_win
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_click = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 55);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_next);
            this.panel2.Controls.Add(this.btn_click);
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 78);
            this.panel2.TabIndex = 2;
            // 
            // btn_next
            // 
            this.btn_next.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_next.Location = new System.Drawing.Point(165, 0);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(57, 78);
            this.btn_next.TabIndex = 2;
            this.btn_next.Text = ">>>";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_click
            // 
            this.btn_click.Location = new System.Drawing.Point(63, 39);
            this.btn_click.Name = "btn_click";
            this.btn_click.Size = new System.Drawing.Size(96, 36);
            this.btn_click.TabIndex = 1;
            this.btn_click.Text = "Ок";
            this.btn_click.UseVisualStyleBackColor = true;
            this.btn_click.Click += new System.EventHandler(this.btn_click_Click);
            // 
            // btn_back
            // 
            this.btn_back.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_back.Location = new System.Drawing.Point(0, 0);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(57, 78);
            this.btn_back.TabIndex = 0;
            this.btn_back.Text = "<<<";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(63, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // StepSimplecsSolution_win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(222, 159);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "StepSimplecsSolution_win";
            this.Text = "StepSimplecsSolution_win";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_click;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label1;
    }
}