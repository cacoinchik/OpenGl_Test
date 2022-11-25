using System;
using System.Drawing;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace OpenGl_Test
{
    public partial class GrUi : Form
    {
        private Engine programmDrawingEngine;
        public GrUi()
        {
            InitializeComponent();
            Window.InitializeContexts();
        }

        private void GrUi_Load(object sender, EventArgs e)
        {
            // инициализация Glut 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_SINGLE);

            // утсновка цвета очистки окна 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, Window.Width, Window.Height);

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluOrtho2D(0.0, Window.Width, 0.0, Window.Height);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            programmDrawingEngine = new Engine(Window.Width,Window.Height, Window.Width, Window.Height);

            renderTimer.Start();
        }

        private void GrUi_FormClosed(object sender, FormClosedEventArgs e)
        {
            var main = Application.OpenForms[0];
            main.Show();
        }

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            Drawing();
        }

        private void Drawing()
        {
            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            // очищение текущей матрицы 
            Gl.glLoadIdentity();
            // установка черного цвета 
            Gl.glColor3f(0, 0, 0);

            // визуализация изображения из движка 
            programmDrawingEngine.SwapImage();

            // дожидаемся завершения визуализации кадра 
            Gl.glFlush();
            // сигнал для обновление элемента, реализующего визуализацию. 
            Window.Invalidate();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                programmDrawingEngine.Drawing(e.X, Window.Height - e.Y);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // устанавливаем стандартную кисть 4х4 
            programmDrawingEngine.SetStandartBrush(4);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // устанавливаем специальную кисть 
            programmDrawingEngine.SetSpecialBrush(0);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // установить кисть из файла 
            programmDrawingEngine.SetBrushFromFile("brush-1.bmp");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var main=Application.OpenForms[0];
            main.Show();
            Close();
        }

        private void color1_MouseClick(object sender, MouseEventArgs e)
        {
            if (changeColor.ShowDialog() == DialogResult.OK)
            {
                color1.BackColor=changeColor.Color;
                programmDrawingEngine.SetColor(color1.BackColor);
            }
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            Color tmp = color1.BackColor;

            color1.BackColor = color2.BackColor;
            color2.BackColor = tmp;

            programmDrawingEngine.SetColor(color1.BackColor);
        }
    }
}
