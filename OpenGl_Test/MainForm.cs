using System;
using System.Windows.Forms;
using Tao.FreeGlut;

namespace OpenGl_Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Работы по порядку
        private void Lab1_Click(object sender, EventArgs e)
        {
            var laba1=new Laba1();
            laba1.Show();
            this.Hide();
        }

        private void Lab2_Click(object sender, EventArgs e)
        {
            var laba2 = new Laba2();
            laba2.Show();
            this.Hide();
        }

        private void Lab3_Click(object sender, EventArgs e)
        {
            var laba3=new Laba3();
            laba3.Show();
            this.Hide();
        }

        private void Lab4_Click(object sender, EventArgs e)
        {
            var laba4 = new Laba4();
            laba4.Show();
            this.Hide();
        }
        #endregion

    }
    
}
