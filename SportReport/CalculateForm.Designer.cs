namespace SportReport
{
    partial class CalculateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.AvgCalories = new System.Windows.Forms.Label();
            this.AvgDistance = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.MinCalories = new System.Windows.Forms.Label();
            this.MaxCalories = new System.Windows.Forms.Label();
            this.MinDistance = new System.Windows.Forms.Label();
            this.MaxDistance = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(526, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "운동 기록 계산(평균 칼로리 소모량 및 이동 거리, 최소 및 최대 칼로리 소모량 및 이동 거리 계산)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "이번 달: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.AvgDistance);
            this.groupBox1.Controls.Add(this.AvgCalories);
            this.groupBox1.Location = new System.Drawing.Point(56, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "이번 달 평균 칼로리 소모량 및 이동 거리 계산 ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MaxDistance);
            this.groupBox2.Controls.Add(this.MinDistance);
            this.groupBox2.Controls.Add(this.MaxCalories);
            this.groupBox2.Controls.Add(this.MinCalories);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(54, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 172);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "이번 달 최소 및 최대 칼로리 소모량 및 이동 거리 계산 ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 47);
            this.button1.TabIndex = 5;
            this.button1.Text = "닫기 ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AvgCalories
            // 
            this.AvgCalories.AutoSize = true;
            this.AvgCalories.Location = new System.Drawing.Point(15, 32);
            this.AvgCalories.Name = "AvgCalories";
            this.AvgCalories.Size = new System.Drawing.Size(118, 15);
            this.AvgCalories.TabIndex = 0;
            this.AvgCalories.Text = "평균 칼로리 소모량: ";
            // 
            // AvgDistance
            // 
            this.AvgDistance.AutoSize = true;
            this.AvgDistance.Location = new System.Drawing.Point(15, 66);
            this.AvgDistance.Name = "AvgDistance";
            this.AvgDistance.Size = new System.Drawing.Size(66, 15);
            this.AvgDistance.TabIndex = 1;
            this.AvgDistance.Text = "이동 거리: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(407, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 49);
            this.button2.TabIndex = 2;
            this.button2.Text = "다시 계산 ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(409, 54);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 49);
            this.button3.TabIndex = 3;
            this.button3.Text = "다시 계산 ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MinCalories
            // 
            this.MinCalories.AutoSize = true;
            this.MinCalories.Location = new System.Drawing.Point(17, 37);
            this.MinCalories.Name = "MinCalories";
            this.MinCalories.Size = new System.Drawing.Size(143, 15);
            this.MinCalories.TabIndex = 4;
            this.MinCalories.Text = "최소 칼로리 소모량/날짜:";
            // 
            // MaxCalories
            // 
            this.MaxCalories.AutoSize = true;
            this.MaxCalories.Location = new System.Drawing.Point(17, 71);
            this.MaxCalories.Name = "MaxCalories";
            this.MaxCalories.Size = new System.Drawing.Size(147, 15);
            this.MaxCalories.TabIndex = 5;
            this.MaxCalories.Text = "최대 칼로리 소모량/날짜: ";
            // 
            // MinDistance
            // 
            this.MinDistance.AutoSize = true;
            this.MinDistance.Location = new System.Drawing.Point(17, 106);
            this.MinDistance.Name = "MinDistance";
            this.MinDistance.Size = new System.Drawing.Size(119, 15);
            this.MinDistance.TabIndex = 6;
            this.MinDistance.Text = "최소 이동 거리/날짜:";
            // 
            // MaxDistance
            // 
            this.MaxDistance.AutoSize = true;
            this.MaxDistance.Location = new System.Drawing.Point(17, 140);
            this.MaxDistance.Name = "MaxDistance";
            this.MaxDistance.Size = new System.Drawing.Size(123, 15);
            this.MaxDistance.TabIndex = 7;
            this.MaxDistance.Text = "최대 이동 거리/날짜: ";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(180, 413);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 47);
            this.button4.TabIndex = 6;
            this.button4.Text = "텍스트 문서로 저장 ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(353, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 15);
            this.label9.TabIndex = 7;
            // 
            // CalculateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 472);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculateForm";
            this.Text = "운동 기록 계산 ";
            this.Load += new System.EventHandler(this.CalculateForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label AvgDistance;
        private System.Windows.Forms.Label AvgCalories;
        private System.Windows.Forms.Label MaxDistance;
        private System.Windows.Forms.Label MinDistance;
        private System.Windows.Forms.Label MaxCalories;
        private System.Windows.Forms.Label MinCalories;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label9;
    }
}