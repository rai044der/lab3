namespace lab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.randomCarGeneratorCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.carGeneratorTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tickTrackBar = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.ticksRemainingLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.fuelSpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carGeneratorTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tickTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelSpeedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // statBtn
            // 
            this.statBtn.Location = new System.Drawing.Point(39, 6);
            this.statBtn.Name = "statBtn";
            this.statBtn.Size = new System.Drawing.Size(176, 35);
            this.statBtn.TabIndex = 0;
            this.statBtn.Text = "Статистика";
            this.statBtn.UseVisualStyleBackColor = true;
            this.statBtn.Click += new System.EventHandler(this.statBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.fuelSpeedTrackBar);
            this.panel1.Controls.Add(this.ticksRemainingLabel);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.randomCarGeneratorCheckBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.carGeneratorTrackBar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tickTrackBar);
            this.panel1.Controls.Add(this.statBtn);
            this.panel1.Location = new System.Drawing.Point(1280, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 765);
            this.panel1.TabIndex = 1;
            // 
            // randomCarGeneratorCheckBox
            // 
            this.randomCarGeneratorCheckBox.AutoSize = true;
            this.randomCarGeneratorCheckBox.Location = new System.Drawing.Point(20, 211);
            this.randomCarGeneratorCheckBox.Name = "randomCarGeneratorCheckBox";
            this.randomCarGeneratorCheckBox.Size = new System.Drawing.Size(220, 17);
            this.randomCarGeneratorCheckBox.TabIndex = 9;
            this.randomCarGeneratorCheckBox.Text = "Случайное время появления машинки";
            this.randomCarGeneratorCheckBox.UseVisualStyleBackColor = true;
            this.randomCarGeneratorCheckBox.CheckedChanged += new System.EventHandler(this.randomCarGeneratorCheckBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Время появления новой машинки (такты)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "300";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "60";
            // 
            // carGeneratorTrackBar
            // 
            this.carGeneratorTrackBar.Location = new System.Drawing.Point(36, 160);
            this.carGeneratorTrackBar.Maximum = 300;
            this.carGeneratorTrackBar.Minimum = 60;
            this.carGeneratorTrackBar.Name = "carGeneratorTrackBar";
            this.carGeneratorTrackBar.Size = new System.Drawing.Size(179, 45);
            this.carGeneratorTrackBar.TabIndex = 5;
            this.carGeneratorTrackBar.Value = 60;
            this.carGeneratorTrackBar.Scroll += new System.EventHandler(this.carGeneratorTrackBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Скорость симуляции (такт в 25 мс)";
            // 
            // tickTrackBar
            // 
            this.tickTrackBar.Location = new System.Drawing.Point(36, 66);
            this.tickTrackBar.Maximum = 50;
            this.tickTrackBar.Minimum = 1;
            this.tickTrackBar.Name = "tickTrackBar";
            this.tickTrackBar.Size = new System.Drawing.Size(179, 45);
            this.tickTrackBar.TabIndex = 1;
            this.tickTrackBar.Value = 1;
            this.tickTrackBar.Scroll += new System.EventHandler(this.tickTrackBar_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Тиков до новой машинки:";
            // 
            // ticksRemainingLabel
            // 
            this.ticksRemainingLabel.AutoSize = true;
            this.ticksRemainingLabel.Location = new System.Drawing.Point(166, 231);
            this.ticksRemainingLabel.Name = "ticksRemainingLabel";
            this.ticksRemainingLabel.Size = new System.Drawing.Size(0, 13);
            this.ticksRemainingLabel.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "20";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 313);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(190, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Скорость заправка (литров за такт)";
            // 
            // fuelSpeedTrackBar
            // 
            this.fuelSpeedTrackBar.Location = new System.Drawing.Point(36, 281);
            this.fuelSpeedTrackBar.Maximum = 20;
            this.fuelSpeedTrackBar.Minimum = 1;
            this.fuelSpeedTrackBar.Name = "fuelSpeedTrackBar";
            this.fuelSpeedTrackBar.Size = new System.Drawing.Size(179, 45);
            this.fuelSpeedTrackBar.TabIndex = 12;
            this.fuelSpeedTrackBar.Value = 1;
            this.fuelSpeedTrackBar.Scroll += new System.EventHandler(this.fuelSpeedTrackBar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1532, 872);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carGeneratorTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tickTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelSpeedTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button statBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar tickTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar carGeneratorTrackBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox randomCarGeneratorCheckBox;
        private System.Windows.Forms.Label ticksRemainingLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar fuelSpeedTrackBar;
    }
}
