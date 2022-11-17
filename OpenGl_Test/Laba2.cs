using System;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace OpenGl_Test
{
    public partial class Laba2 : Form
    {
        public Laba2()
        {
            InitializeComponent();
            Window.InitializeContexts();
        }
        private void Laba2_Load(object sender, EventArgs e)
        {
            // инициализация Glut 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_SINGLE);

            // очистка окна 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, Window.Width, Window.Height);

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            // теперь необходимо корректно настроить 2D ортогональную проекцию 
            // в зависимости от того, какая сторона больше 
            // мы немного варьируем то, как будет сконфигурированный настройки проекции 
            if ((float)Window.Width <= (float)Window.Height)
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)Window.Height / (float)Window.Width, 0.0, 30.0);
            }
            else
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)Window.Width / (float)Window.Height, 0.0, 30.0);
            }

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //очистка буфера цвета
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            //очищение текущей матрицы
            Gl.glLoadIdentity();

            //установление цвета (красный)
            Gl.glColor3f(1.0f, 0, 0);

            //режим рисования линий, путём последовательного соединения вершин в отрезки
            Gl.glBegin(Gl.GL_LINE_LOOP);


            Gl.glVertex2d(8, 7);
            Gl.glVertex2d(15, 27);
            Gl.glVertex2d(17, 27);
            Gl.glVertex2d(23, 7);
            Gl.glVertex2d(21, 7);
            Gl.glVertex2d(19, 14);
            Gl.glVertex2d(12.5, 14);
            Gl.glVertex2d(10, 7);

            // завершаем режим рисования 
            Gl.glEnd();

            // вторая линия 

            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(18.5, 16);
            Gl.glVertex2d(16, 25);
            Gl.glVertex2d(13.2, 16);

            //завершение режима рисования
            Gl.glEnd();
            //ожидание конца визуализации
            Gl.glFlush();
            //сигнал для перерисовка элемента 
            Window.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //очистка буфера цвета
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            //очищение текущей матрицы
            Gl.glLoadIdentity();

            //установление цвета (красный)
            Gl.glColor3f(1.0f, 0, 0);

            //режим рисования линий, путём последовательного соединения вершин в отрезки
            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(38, 5);
            Gl.glVertex2d(38, 25);
            Gl.glVertex2d(42, 25);
            Gl.glVertex2d(42, 16);
            Gl.glVertex2d(50, 16);
            Gl.glVertex2d(50, 25);
            Gl.glVertex2d(54, 25);
            Gl.glVertex2d(54, 5);
            Gl.glVertex2d(50, 5);
            Gl.glVertex2d(50, 14);
            Gl.glVertex2d(42, 14);
            Gl.glVertex2d(42, 5);

            //завершение режима рисования
            Gl.glEnd();
            //ожидание конца визуализации
            Gl.glFlush();
            //сигнал для перерисовка элемента 
            Window.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var main = Application.OpenForms[0];
            main.Show();
            Close();
        }

        private void Laba2_FormClosed(object sender, FormClosedEventArgs e)
        {
            var main = Application.OpenForms[0];
            main.Show();
        }

        
    }
}
