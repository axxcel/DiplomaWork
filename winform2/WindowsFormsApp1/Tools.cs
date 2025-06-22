using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace DiplomaWork
{
    public class Tools
    {
        private string name;
        public CustomPanel panel;
        public int PixelSize;
        public int GridWidth;
        public int GridHeight;
        public int[,] Pixels;
        public int BrushSize { get; set; } = 0; // Размер кисти по умолчанию
        private List<List<int>> locationForLines = new List<List<int>>();

        public string GetName() { return name; }
        public Tools(string name, CustomPanel panel, int[,] layer)
        {
            this.name = name;
            this.panel = panel;
            this.PixelSize = panel.PixelSize;
            this.GridWidth = panel.GridWidth;
            this.GridHeight = panel.GridHeight;
            this.Pixels = layer;
        }

        public void UseTool(string name, Point location, Color currentColor)
        {
            if (name == "Карандаш")
            {
                DrawPixelAtPosition(location, currentColor);
                Form1.cursor = new Cursor(ChangeCursor(name));
            }
            else if (name == "Ластик")
            {
                ErasePixelAtPosition(location, currentColor);
                Form1.cursor = new Cursor(ChangeCursor(name));
            }
            else if(name == "Заливка")
            {
                FloodFill(location.X, location.Y, currentColor);
                Form1.cursor = new Cursor(ChangeCursor(name));
            }
            else if(name == "Линия")
            {
                Form1.cursor = new Cursor(ChangeCursor(name));
            }
            else if(name == "Пипетка")
            { 
                Form1.cursor = new Cursor(ChangeCursor(name));
                Form1.currentColor = TakeColor(location, currentColor);

            }
            else if (name == "Рука")
            {
                Form1.cursor = new Cursor(ChangeCursor(name));

            }
        }
        public void UseTool(string name, Point start, Point end, Color color)
        {
            if (name == "Квадрат")
            {
                DrawSquare(start, end, color);
                Form1.cursor = new Cursor(ChangeCursor(name));
            }
        }
        // РЕАЛИЗАЦИЯ АЛГОРИТМА ФИГУРЫ КВАДРАТ
        public void DrawSquare(Point firstPoint, Point secondPoint, Color color)
        {
            // Приводим координаты к сетке пикселей
            int xStart = firstPoint.X / PixelSize;
            int yStart = firstPoint.Y / PixelSize;
            int xEnd = secondPoint.X / PixelSize;
            int yEnd = secondPoint.Y / PixelSize;

            // Определяем ширину и высоту рамки
            int width = Math.Abs(xEnd - xStart);
            int height = Math.Abs(yEnd - yStart);

            // Верхний левый угол квадрата
            int topLeftX = Math.Min(xStart, xEnd);
            int topLeftY = Math.Min(yStart, yEnd);

            // Верхняя граница
            for (int x = topLeftX; x <= topLeftX + width; x++)
            {
                if (x >= 0 && x < GridWidth && topLeftY >= 0 && topLeftY < GridHeight)
                {
                    panel.GetCurrentLayer()[x, topLeftY] = color.ToArgb();
                }
            }

            // Нижняя граница
            for (int x = topLeftX; x <= topLeftX + width; x++)
            {
                if (x >= 0 && x < GridWidth && topLeftY + height >= 0 && topLeftY + height < GridHeight)
                {
                    panel.GetCurrentLayer()[x, topLeftY + height] = color.ToArgb();
                }
            }

            // Левая граница
            for (int y = topLeftY; y <= topLeftY + height; y++)
            {
                if (topLeftX >= 0 && topLeftX < GridWidth && y >= 0 && y < GridHeight)
                {
                    panel.GetCurrentLayer()[topLeftX, y] = color.ToArgb();
                }
            }

            // Правая граница
            for (int y = topLeftY; y <= topLeftY + height; y++)
            {
                if (topLeftX + width >= 0 && topLeftX + width < GridWidth && y >= 0 && y < GridHeight)
                {
                    panel.GetCurrentLayer()[topLeftX + width, y] = color.ToArgb();
                }
            }
            panel.Invalidate();

        }

        private string ChangeCursor(string name)
        {
            string currentDir = Directory.GetCurrentDirectory();  // получаем корневую папку
            DirectoryInfo projectRoot = Directory.GetParent(currentDir)?.Parent; // поднимаемся на два уровня выше
            string imagePath = Path.Combine(projectRoot.FullName, "img", "cursors", $"{name}.cur");

            return imagePath;
        }


        private Color TakeColor(Point location, Color oldColor)
        {
            int x = location.X / PixelSize;
            int y = location.Y / PixelSize;

            if (x >= 0 && x < GridWidth && y >= 0 && y < GridHeight)
            {
                int argbValue = panel.GetCurrentLayer()[x, y];
                return Color.FromArgb(argbValue); // Конвертирование целого значения в Color
            }
            return oldColor; // Возвращаем старый цвет, если точка вне границ
        }

        public void DrawPixelAtPosition(Point location, Color currentColor)
        {
            int x = location.X / PixelSize;
            int y = location.Y / PixelSize;

            if (x >= 0 && x < GridWidth && y >= 0 && y < GridHeight)
            {
                // Рисуем пиксели в радиусе кисти
                for (int dx = -BrushSize; dx <= BrushSize; dx++)
                {
                    for (int dy = -BrushSize; dy <= BrushSize; dy++)
                    {
                        int nx = x + dx;
                        int ny = y + dy;
                        if (nx >= 0 && nx < GridWidth && ny >= 0 && ny < GridHeight)
                        {
                            panel.GetCurrentLayer()[nx, ny] = currentColor.ToArgb();
                        }
                    }
                }
                panel.Invalidate();
            }
        }

        private void ErasePixelAtPosition(Point location, Color currentColorn)
        {
            int x = location.X / PixelSize;
            int y = location.Y / PixelSize;

            if (x >= 0 && x < GridWidth && y >= 0 && y < GridHeight)
            {
                // Стираем пиксели в радиусе кисти
                for (int dx = -BrushSize; dx <= BrushSize; dx++)
                {
                    for (int dy = -BrushSize; dy <= BrushSize; dy++)
                    {
                        int nx = x + dx;
                        int ny = y + dy;
                        if (nx >= 0 && nx < GridWidth && ny >= 0 && ny < GridHeight)
                        {
                            panel.GetCurrentLayer()[nx, ny] = Color.Transparent.ToArgb();
                        }
                    }
                }
                panel.Invalidate();
            }
        }

        // РЕАЛИЗАЦИЯ АЛГОРИТМА ЗАЛИВКИ
        public void FloodFill(int x, int y, Color newColor)
        {
            // Получаем текущий слой
            int[,] currentLayer = panel.GetCurrentLayer();

            // Нормализуем координаты на уровне пиксельной сетки
            x /= PixelSize;
            y /= PixelSize;

            // Проверяем, что координаты находятся в пределах сетки
            if (x < 0 || x >= GridWidth || y < 0 || y >= GridHeight)
                return;

            // Получаем цвет пикселя в начальной точке
            Color oldColor = Color.FromArgb(currentLayer[x, y]);

            // Если новый цвет совпадает со старым, ничего не делаем
            if (oldColor == newColor)
                return;

            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(new Point(x, y));

            while (queue.Count > 0)
            {
                Point p = queue.Dequeue();
                int px = p.X;
                int py = p.Y;

                // Прекращаем дальнейшее распространение, если вышли за пределы экрана
                if (px < 0 || px >= GridWidth || py < 0 || py >= GridHeight ||
                   Color.FromArgb(currentLayer[px, py]) != oldColor)
                {
                    continue;
                }

                // Закрашиваем текущий пиксель новым цветом
                currentLayer[px, py] = newColor.ToArgb();

                // Добавляем соседей в очередь
                queue.Enqueue(new Point(px + 1, py));     // Справа
                queue.Enqueue(new Point(px - 1, py));     // Слева
                queue.Enqueue(new Point(px, py + 1));     // Ниже
                queue.Enqueue(new Point(px, py - 1));     // Выше
            }

            // Обновляем изображение
            panel.Invalidate();
        }


    }
}
