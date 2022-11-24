using System.Drawing;

namespace OpenGl_Test
{
    class Brush
    {
        public Bitmap myBrush;

        public Brush()
        {
            // создаем плоскость 5х5 пикселей 
            myBrush = new Bitmap(5, 5);

            // заполняем все пиксели красным цветом (все пиксели красного цвета мы будем считать не значимыми, 
            // а черного – значимыми при рисования кистью 
            // для установки пискеля, как видно из кода, используется функция SetPixel. 
            for (int ax = 0; ax < 5; ax++)
                for (int bx = 0; bx < 5; bx++)
                    myBrush.SetPixel(ax, bx, Color.Red);

            // далее в данном массиве мы рисуем крестик 
            myBrush.SetPixel(0, 2, Color.Black);
            myBrush.SetPixel(1, 2, Color.Black);

            myBrush.SetPixel(2, 0, Color.Black);
            myBrush.SetPixel(2, 1, Color.Black);
            myBrush.SetPixel(2, 2, Color.Black);
            myBrush.SetPixel(2, 3, Color.Black);
            myBrush.SetPixel(2, 4, Color.Black);

            myBrush.SetPixel(3, 2, Color.Black);
            myBrush.SetPixel(4, 2, Color.Black);
        }

    }
}
