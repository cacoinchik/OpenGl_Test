using System.Collections;
using System.Drawing;

namespace OpenGl_Test
{
    class Engine
    {
        // последний установленный цвет
        private Color LastColorInUse;

        // размеры изображения 
        private int picture_size_x, picture_size_y;

        // положение полос прокрутки будет использовано в будущем 
        private int scroll_x, scroll_y;

        // размер оконной части (объекта AnT) 
        private int screen_width, screen_height;

        // номер активного слоя 
        private int ActiveLayerNom;

        // массив слоев 
        private ArrayList Layers = new ArrayList();

        // стандартная кисть 
        private Brush standartBrush;

        // конструктор класса 
        public Engine(int size_x, int size_y, int screen_w, int screen_h)
        {

            // при инициализации экземпляра класса сохраним настройки 
            // размеров элементов и изображения в локальных переменных 

            picture_size_x = size_x;
            picture_size_y = size_y;

            screen_width = screen_w;
            screen_height = screen_h;

            // полосы прокрутки у нас пока отсутствуют, поэтому просто обнулим значение переменных 
            scroll_x = 0;
            scroll_y = 0;

            // добавим новый слой для работы, пока он будет единственным 
            Layers.Add(new Layer(picture_size_x, picture_size_y));

            // номер активного слоя - 0 
            ActiveLayerNom = 0;

            // и создадим стандартную кисть 
            standartBrush = new Brush(3,false);

        }

        // функция для установки номера активного слоя 
        public void SetActiveLayerNom(int nom)
        {
            ActiveLayerNom = nom;
        }

        // установка видимости / невидимости слоя 
        public void SetWisibilityLayerNom(int nom, bool visible)
        {
            // вернемся к этой функции в следующей части главы
        }

        // рисование текущей кистью 
        public void Drawing(int x, int y)
        {
            // транслируем координаты, в которых проходит рисование, стандартной кистью 
            ((Layer)Layers[0]).Draw(standartBrush, x, y);
        }

        // визуализация 
        public void SwapImage()
        {
            // вызываем функцию визуализации в нашем слое 
            ((Layer)Layers[0]).RenderImage();
        }

        // функция установки стандартной кисти, передается только размер 
        public void SetStandartBrush(int SizeB)
        {
            standartBrush = new Brush(SizeB, false);
        }

        // функция установки специальной кисти 
        public void SetSpecialBrush(int Nom)
        {
            standartBrush = new Brush(Nom, true);
        }

        // установка кисти из файла 
        public void SetBrushFromFile(string FileName)
        {
            standartBrush = new Brush(FileName);
        }

        //функция установки активного цвета
        public void SetColor(Color NewColor)
        {
            ((Layer)Layers[ActiveLayerNom]).SetColor(NewColor);
            LastColorInUse = NewColor;
        }
    }
}
