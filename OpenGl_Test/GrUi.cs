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
        // активный слой
        private int ActiveLayer = 0;

        // счетчик слоев
        private int LayersCount = 1;
        private int AllLayersCount = 1;
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

            programmDrawingEngine = new Engine(Window.Width, Window.Height, Window.Width, Window.Height);

            renderTimer.Start();

            //
            LayersControl.Items.Add("Главынй слой", true);
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
            var main = Application.OpenForms[0];
            main.Show();
            Close();
        }

        private void color1_MouseClick(object sender, MouseEventArgs e)
        {
            if (changeColor.ShowDialog() == DialogResult.OK)
            {
                color1.BackColor = changeColor.Color;
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

        private void LayersControl_SelectedValueChanged(object sender, EventArgs e)
        {
            // если отметили новый слой, необходимо снять галочку выделения со старого 
            if (LayersControl.SelectedIndex != ActiveLayer)
            {
                // если выделенный индекс является корректным (больше либо равен нулю и входит в диапазон элементов) 
                if (LayersControl.SelectedIndex != -1 && ActiveLayer < LayersControl.Items.Count)
                {
                    // снимаем галочку с предыдущего активного слоя 
                    LayersControl.SetItemCheckState(ActiveLayer, CheckState.Unchecked);
                    // сохраняем новый индекс выделенного элемента 
                    ActiveLayer = LayersControl.SelectedIndex;
                    // помечаем галочкой новый активный слой 
                    LayersControl.SetItemCheckState(LayersControl.SelectedIndex, CheckState.Checked);
                    // посылаем сигнал движку программы об изменении активного слоя 
                    programmDrawingEngine.SetActiveLayerNom(ActiveLayer);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
           добавитьСлойToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            удалитьСлойToolStripMenuItem_Click(sender, e);
        }

        private void добавитьСлойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // счетчик созданных слоев 
            LayersCount++; // вызываем функцию добавления слоя в движке графического редактора 
            programmDrawingEngine.AddLayer();

            // добавляем слой, генерирую имя "Слой №" в объекте LayersControl. 
            // обязательно после функции ProgrammDrawingEngine.AddLayer();, 
            // иначе произойдет попытка установки активного цвета для еще не существующего цвета 
            int AddingLayerNom = LayersControl.Items.Add("Слой" + LayersCount.ToString(), false);

            // выделяем его 
            LayersControl.SelectedIndex = AddingLayerNom;

            // устанавливаем его как активный 
            ActiveLayer = AddingLayerNom;
        }

        private void удалитьСлойToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // запрашиваем подтверждение действия с помощью messageBox 
            DialogResult res = MessageBox.Show("Будет удален текущий активный слой, действительно продолжить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); // если пользователь нажал кнопку "ДА" в окне подтверждения 
            if (res == DialogResult.Yes)
            {
                // если удаляемый слой - начальный 
                if (ActiveLayer == 0)
                {
                    // сообщаем о невозможности удаления 
                    MessageBox.Show("Вы не можете удалить нулевой слой.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else // иначе 
                {
                    // уменьшаем значение счетчика слоев 
                    LayersCount--;
                    // сохраняем номер удаляемого слоя, т.к. SelectedIndex измениться после операций в LayersControl 
                    int LayerNomForDel = LayersControl.SelectedIndex;
                    // удаляем запись в элементе LayerControl (с индексом LayersControl.SelectedIndex - текущим выделенным слоем) 
                    LayersControl.Items.RemoveAt(LayerNomForDel);
                    // устанавливаем выделенным слоем нулевой (главный слой) 
                    LayersControl.SelectedIndex = 0;
                    // помечаем активный слой - нулевой 
                    ActiveLayer = 0;
                    // помечаем галочкой нулевой слой 
                    LayersControl.SetItemCheckState(0, CheckState.Checked);
                    // вызываем функцию удаления слоя в движке программы 
                    programmDrawingEngine.RemoveLayer(LayerNomForDel);
                }

            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            programmDrawingEngine.SetSpecialBrush(1);
        }

        private void карандашToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void кистьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }

        private void стеркаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton6_Click(sender, e);
        }
    }
}
