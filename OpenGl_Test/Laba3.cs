using System;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace OpenGl_Test
{
    public partial class Laba3 : Form
    {
        double a = 1, b = 0, c = 0;

        public Laba3()
        {
            InitializeComponent();
            Window.InitializeContexts();
        }

        private void Laba3_Load(object sender, EventArgs e)
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
            RenderTime.Start();
        }

        private void Laba3_FormClosed(object sender, FormClosedEventArgs e)
        {
            var main = Application.OpenForms[0];
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var main= Application.OpenForms[0];
            main.Show();
            Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            a = (double)trackBar1.Value / 1000;
            label4.Text=Convert.ToString(a);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            b = (double)trackBar2.Value / 1000;
            label5.Text = Convert.ToString(b);
        }

        private void RenderTime_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            c = (double)trackBar3.Value / 1000;
            label6.Text = Convert.ToString(c);
        }

        public void Draw()
        {
            // очищаем буфер цвета 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            // активируем рисование в режиме GL_TRIANGLES, при котором задание 
            // трех вершин с помощью функции glVertex2d или glVertex3d 
            // будет объединяться в трехгранный полигон (треугольник) 

            Gl.glBegin(Gl.GL_TRIANGLES);

            // устанавливаем параметр цвета, основанный на параметрах a b c 
            Gl.glColor3d(a, b, c);
            // рисуем вершину в координатах 5,5 
            Gl.glVertex2d(5.0, 5.0);
            // устанавливаем параметр цвета, основанный на параметрах с a b 
            Gl.glColor3d(c, a, b);
            // рисуем вершину в координатах 25,5 
            Gl.glVertex2d(25.0, 5.0);
            // устанавливаем параметр цвета, основанный на параметрах b c a 
            Gl.glColor3d(b, c, a);
            // рисуем вершину в координатах 25,5 
            Gl.glVertex2d(5.0, 25.0);

            // завершаем режим рисования примитивов 
            Gl.glEnd();

            // дожидаемся завершения визуализации кадра 
            Gl.glFlush();

            // обновляем изображение в элементе AnT 
            Window.Invalidate();

        }
    }
}
