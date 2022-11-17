using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace OpenGl_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OpenGlWindow.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация Glut 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            // отчитка окна 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, OpenGlWindow.Width, OpenGlWindow.Height);


            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            if ((float) OpenGlWindow.Width <= (float)OpenGlWindow.Height)
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)OpenGlWindow.Height / (float)OpenGlWindow.Width, 0.0, 30.0);
            }
            else
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)OpenGlWindow.Width / (float)OpenGlWindow.Height, 0.0, 30.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            // настройка параметров OpenGL для визуализации 
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

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
            OpenGlWindow.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //очистка буфера цвета
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            //очищение текущей матрицы
            Gl.glLoadIdentity();

            //установление цвета (красный)
            Gl.glColor3f(1.0f, 0, 0);

            //режим рисования линий, путём последовательного соединения вершин в отрезки
            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(8, 5);
            Gl.glVertex2d(8, 25);
            Gl.glVertex2d(12, 25);
            Gl.glVertex2d(12, 16);
            Gl.glVertex2d(20, 16);
            Gl.glVertex2d(20, 25);
            Gl.glVertex2d(24, 25);
            Gl.glVertex2d(24, 5);
            Gl.glVertex2d(20, 5);
            Gl.glVertex2d(20, 14);
            Gl.glVertex2d(12, 14);
            Gl.glVertex2d(12, 5);



            Gl.glEnd();
            Gl.glFlush();
            OpenGlWindow.Invalidate();
        }
    }
}
