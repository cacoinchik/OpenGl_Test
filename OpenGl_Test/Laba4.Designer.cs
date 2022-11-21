namespace OpenGl_Test
{
    partial class Laba4
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
            this.Window = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.PointInGrap = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Window
            // 
            this.Window.AccumBits = ((byte)(0));
            this.Window.AutoCheckErrors = false;
            this.Window.AutoFinish = false;
            this.Window.AutoMakeCurrent = true;
            this.Window.AutoSwapBuffers = true;
            this.Window.BackColor = System.Drawing.Color.Black;
            this.Window.ColorBits = ((byte)(32));
            this.Window.DepthBits = ((byte)(16));
            this.Window.Location = new System.Drawing.Point(12, 12);
            this.Window.Name = "Window";
            this.Window.Size = new System.Drawing.Size(663, 426);
            this.Window.StencilBits = ((byte)(0));
            this.Window.TabIndex = 0;
            this.Window.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Window_MouseMove);
            // 
            // PointInGrap
            // 
            this.PointInGrap.Interval = 30;
            this.PointInGrap.Tick += new System.EventHandler(this.PointInGrap_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(681, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выйти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Laba4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Window);
            this.Name = "Laba4";
            this.Text = "Laba4";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Laba4_FormClosed);
            this.Load += new System.EventHandler(this.Laba4_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl Window;
        private System.Windows.Forms.Timer PointInGrap;
        private System.Windows.Forms.Button button1;
    }
}