using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;

namespace DiplomaWork
{
    public class CustomPanel : Control // кастомная панель, наследник класса Panel
    {
        public readonly int GridWidth;
        public readonly int GridHeight;
        public int PixelSize;
        public List<int[,]> listLayers = new List<int[,]>();
        private Brush ColorPixel = Brushes.Pink;
        public int currentLayerIndex = 0;
        public CustomPanel(int gridWidth, int gridHeight, int pixelSize)
        {
            DoubleBuffered = true; // активация двойной буферизации
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            GridHeight = gridHeight;
            PixelSize = pixelSize;
            GridWidth = gridWidth;

            AddNewLayer();
        }
        public void ChangeColor(Brush color)
        {
            ColorPixel = color;
        }
        public void AddNewLayer()
        {
            int[,] newLayer = new int[GridWidth, GridHeight];
            listLayers.Add(newLayer);
        }

        public void SelectLayer(int index)
        {
            if(index >= 0 && index < listLayers.Count)
            {
                currentLayerIndex = index;
            }
        }

        public void DeleteLayer(int index)
        {
            if (index >= 0 && index < listLayers.Count)
            {
                listLayers.RemoveAt(index);
            }
        }

        public void SwapPlaces(int firstIndex, int secondIndex)
        {
            if ((firstIndex > 0 ) || (secondIndex > 0))
            {
                int[,] buferForLayer = listLayers[firstIndex];
                listLayers[firstIndex] = listLayers[secondIndex];
                listLayers[secondIndex] = buferForLayer;

            }

        }

        public void DublicateLayer(int index)
        {
            listLayers.Add(listLayers[index]);
        }

        public int[,] GetCurrentLayer()
        {
            return listLayers[currentLayerIndex];
        }

        protected override void OnPaint(PaintEventArgs e) { 
            base.OnPaint(e);
            DrawGrid(e.Graphics); // метод очищает холст
        }

        private void DrawGrid(Graphics g)
        {
            if (GetCurrentLayer().Length > 0)
            {
                foreach (var layer in listLayers)
                {
                    for (int x = 0; x < GridWidth; x++)
                    {
                        for (int y = 0; y < GridHeight; y++)
                        {
                            if (layer[x, y] != 0)
                            {
                                // Получаем цвет из массива
                                Color pixelColor = Color.FromArgb(layer[x, y]);

                                // Создаем временную кисть
                                using (Brush brush = new SolidBrush(pixelColor))
                                {
                                    Rectangle rect = new Rectangle(x * PixelSize, y * PixelSize, PixelSize, PixelSize);
                                    g.FillRectangle(brush, rect); // Применяем кисть для рисования
                                }
                            }
                        }
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
