namespace OpenGl_Test
{
    partial class MainForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.Lab1 = new System.Windows.Forms.Button();
            this.Lab2 = new System.Windows.Forms.Button();
            this.Lab3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(668, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Выйти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Lab1
            // 
            this.Lab1.Location = new System.Drawing.Point(12, 22);
            this.Lab1.Name = "Lab1";
            this.Lab1.Size = new System.Drawing.Size(75, 23);
            this.Lab1.TabIndex = 4;
            this.Lab1.Text = "Работа №1";
            this.Lab1.UseVisualStyleBackColor = true;
            this.Lab1.Click += new System.EventHandler(this.Lab1_Click);
            // 
            // Lab2
            // 
            this.Lab2.Location = new System.Drawing.Point(12, 86);
            this.Lab2.Name = "Lab2";
            this.Lab2.Size = new System.Drawing.Size(75, 23);
            this.Lab2.TabIndex = 5;
            this.Lab2.Text = "Работа №2";
            this.Lab2.UseVisualStyleBackColor = true;
            this.Lab2.Click += new System.EventHandler(this.Lab2_Click);
            // 
            // Lab3
            // 
            this.Lab3.Location = new System.Drawing.Point(12, 164);
            this.Lab3.Name = "Lab3";
            this.Lab3.Size = new System.Drawing.Size(75, 23);
            this.Lab3.TabIndex = 6;
            this.Lab3.Text = "Работа №3";
            this.Lab3.UseVisualStyleBackColor = true;
            this.Lab3.Click += new System.EventHandler(this.Lab3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Lab3);
            this.Controls.Add(this.Lab2);
            this.Controls.Add(this.Lab1);
            this.Controls.Add(this.button2);
            this.Name = "MainForm";
            this.Text = "Лабораторные работа по программированию графики";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Lab1;
        private System.Windows.Forms.Button Lab2;
        private System.Windows.Forms.Button Lab3;
    }
}

