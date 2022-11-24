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
            this.Lab4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gr_edit = new System.Windows.Forms.Button();
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
            this.Lab1.Location = new System.Drawing.Point(66, 65);
            this.Lab1.Name = "Lab1";
            this.Lab1.Size = new System.Drawing.Size(123, 62);
            this.Lab1.TabIndex = 4;
            this.Lab1.Text = "Работа №1";
            this.Lab1.UseVisualStyleBackColor = true;
            this.Lab1.Click += new System.EventHandler(this.Lab1_Click);
            // 
            // Lab2
            // 
            this.Lab2.Location = new System.Drawing.Point(66, 164);
            this.Lab2.Name = "Lab2";
            this.Lab2.Size = new System.Drawing.Size(123, 62);
            this.Lab2.TabIndex = 5;
            this.Lab2.Text = "Работа №2";
            this.Lab2.UseVisualStyleBackColor = true;
            this.Lab2.Click += new System.EventHandler(this.Lab2_Click);
            // 
            // Lab3
            // 
            this.Lab3.Location = new System.Drawing.Point(66, 264);
            this.Lab3.Name = "Lab3";
            this.Lab3.Size = new System.Drawing.Size(123, 62);
            this.Lab3.TabIndex = 6;
            this.Lab3.Text = "Работа №3";
            this.Lab3.UseVisualStyleBackColor = true;
            this.Lab3.Click += new System.EventHandler(this.Lab3_Click);
            // 
            // Lab4
            // 
            this.Lab4.Location = new System.Drawing.Point(66, 362);
            this.Lab4.Name = "Lab4";
            this.Lab4.Size = new System.Drawing.Size(123, 62);
            this.Lab4.TabIndex = 7;
            this.Lab4.Text = "Работа №4";
            this.Lab4.UseVisualStyleBackColor = true;
            this.Lab4.Click += new System.EventHandler(this.Lab4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(339, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Список работ";
            // 
            // gr_edit
            // 
            this.gr_edit.Location = new System.Drawing.Point(466, 164);
            this.gr_edit.Name = "gr_edit";
            this.gr_edit.Size = new System.Drawing.Size(223, 134);
            this.gr_edit.TabIndex = 9;
            this.gr_edit.Text = "Графический редактор";
            this.gr_edit.UseVisualStyleBackColor = true;
            this.gr_edit.Click += new System.EventHandler(this.gr_edit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gr_edit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lab4);
            this.Controls.Add(this.Lab3);
            this.Controls.Add(this.Lab2);
            this.Controls.Add(this.Lab1);
            this.Controls.Add(this.button2);
            this.Name = "MainForm";
            this.Text = "Лабораторные работа по программированию графики";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Lab1;
        private System.Windows.Forms.Button Lab2;
        private System.Windows.Forms.Button Lab3;
        private System.Windows.Forms.Button Lab4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button gr_edit;
    }
}

