
using System;
using System.Drawing;
using Tao.OpenGl;

namespace OpenGl_Test
{
    class Layer
    {
        // размеры экранной области 
        public int Width, Heigth;

        // массив, представляющий область рисунка (координаты пикселя и его цвет), 
        private int[,,] DrawPlace;

        // который будет хранить растровые данные для данного слоя
        public int[,,] GetDrawingPlace()
        {
            return DrawPlace;
        }

        // флаг видимости слоя: true - видимый, false - невидимый 
        private bool isVisible;

        // текущий установленный цвет 
        private Color ActiveColor;

        // конструктор класса, в качестве входных параметров 
        // мы получаем размеры изображения, чтобы создать в памяти массив, 
        // который будет хранить растровые данные для данного слоя 

        public Layer(int s_W, int s_H)
        {

            // запоминаем значения размеров рисунка 
            Width = s_W;
            Heigth = s_H;

            // создаем в памяти массив, соответствующий размерам рисунка 
            // каждая точка на плоскости массива будет иметь 3 составляющие цвета 
            // + 4 ячейка - флаг, о том что данный пиксель пуст (или полностью прозрачен) 
            DrawPlace = new int[Width, Heigth, 4];

            // проходим по всей плоскости и устанавливаем всем точкам флаг,
            // сигнализирующий, что они прозрачны 
            for (int ax = 0; ax < Width; ax++)
            {
                for (int bx = 0; bx < Heigth; bx++)
                {
                    // флаг прозрачности точки в координатах ax,bx. 
                    DrawPlace[ax, bx, 3] = 1;
                }
            }

            // устанавливаем флаг видимости слоя (по умолчанию создаваемый слой всегда видимый) 
            isVisible = true;

            // текущим активным цветом устанавливаем черный 
            // в следующей главе мы реализуем функции установки цветов из оболочки. 
            ActiveColor = Color.Black;
        }

        // функция установки режима видимости слоя 
        public void SetVisibility(bool visiblityState)
        {
            isVisible = visiblityState;
        }

        // функция получения текущего состояния видимости слоя 
        public bool GetVisibility()
        {
            return isVisible;
        }

        // функция рисования 
        // получает в качестве параметров кисть для рисования и координаты, 
        // где сейчас необходимо перерисовать пиксели заданной кистью 
        public void Draw(Brush BR, int x, int y)
        {
            // определяем позиция старта рисования 
            int real_pos_draw_start_x = x - BR.myBrush.Width / 2;
            int real_pos_draw_start_y = y - BR.myBrush.Height / 2;

            // корректируем ее для не выхода за границы массива 
            // проверка на отрицательные значения (граница "справа") 
            if (real_pos_draw_start_x < 0)
                real_pos_draw_start_x = 0;

            if (real_pos_draw_start_y < 0)
                real_pos_draw_start_y = 0;

            // проверки на выход за границу "справа" 
            int boundary_x = real_pos_draw_start_x + BR.myBrush.Width;
            int boundary_y = real_pos_draw_start_y + BR.myBrush.Height;


            if (boundary_x > Width)
                boundary_x = Width;

            if (boundary_y > Heigth)
                boundary_y = Heigth;

            // счетчик пройденных строк и столбцов массива, представляющий собой маску кисти 
            int count_x = 0, count_y = 0;

            // цикл по области с учетом смещения кисти и коррекции для невыхода за границы массива 
            for (int ax = real_pos_draw_start_x; ax < boundary_x; ax++, count_x++)
            {

                count_y = 0;

                for (int bx = real_pos_draw_start_y; bx < boundary_y; bx++, count_y++)
                {

                    // получаем текущий цвет пикселя маски 
                    Color ret = BR.myBrush.GetPixel(count_x, count_y);

                    // цвет не красный 
                    if (!(ret.R == 255 && ret.G == 0 && ret.B == 0))
                    {
                        // заполняем данный пиксель соответствующим из маски, используя активный цвет 
                        DrawPlace[ax, bx, 0] = ActiveColor.R;
                        DrawPlace[ax, bx, 1] = ActiveColor.G;
                        DrawPlace[ax, bx, 2] = ActiveColor.B;
                        DrawPlace[ax, bx, 3] = 0;
                    }
                }

            }

        }

        //установка текущего цвета для рисования в слое
        public void SetColor(Color newColor)
        {
            ActiveColor = newColor;
        }

        // функция визуализации слоя 
        public void RenderImage()
        {
            // данную функцию мы улучшим в следующих частях, для того чтобы получить более быструю визуализацию, 
            // но пока она будет выглядеть следующим образом 
            // активируем режим рисования точек 
            Gl.glBegin(Gl.GL_POINTS);

            // проходим по всем точкам рисунка 
            for (int ax = 0; ax < Width; ax++)
            {
                for (int bx = 0; bx < Heigth; bx++)
                {
                    // если точка в координатах ax,bx не помечена флагом "прозрачная",
                    if (DrawPlace[ax, bx, 3] != 1)
                    {
                        // устанавливаем заданный в ней цвет 
                        Gl.glColor3f(DrawPlace[ax, bx, 0], DrawPlace[ax, bx, 1], DrawPlace[ax, bx, 2]);
                        // и выводим ее на экран 
                        Gl.glVertex2i(ax, bx);
                    }

                }
            }
            // завершаем режим рисования 
            Gl.glEnd();
        }
    }
}
