using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiplomaWork;
using System.Reflection;
using System.IO;
using System.Drawing.Imaging;
using System.Reflection.Emit;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static private int GridHeight; // Ширина сетки
        static private int GridWidth; // Высота сетки
        static private int PixelSize; // размер одного пикселя
        private bool isDragging = false;
        private bool isDrawing = false; // флажок, указывающий что мышь зажата и мы рисуем
        public int brushSize = 0;
        private bool isFirstClick = true;
        private Point startPoint;      // Начальная точка линии
        private Point endPoint;        // Конечная точка линии
        private Point squareStartPoint;
        private bool drawingSquare = false;

        private readonly Color[] PaletteColors =
        {
            System.Drawing.ColorTranslator.FromHtml("#000"),
            System.Drawing.ColorTranslator.FromHtml("#2F2F32"),
            System.Drawing.ColorTranslator.FromHtml("#240D20"),
            System.Drawing.ColorTranslator.FromHtml("#541916"),
            System.Drawing.ColorTranslator.FromHtml("#84391E"),
            System.Drawing.ColorTranslator.FromHtml("#D55907"),
            System.Drawing.ColorTranslator.FromHtml("#D38E4A"),
            System.Drawing.ColorTranslator.FromHtml("#EFFE0C"),
            System.Drawing.ColorTranslator.FromHtml("#94FC32"),
            System.Drawing.ColorTranslator.FromHtml("#64DE0E"),
            System.Drawing.ColorTranslator.FromHtml("#209B62"),
            System.Drawing.ColorTranslator.FromHtml("#316711"),
            System.Drawing.ColorTranslator.FromHtml("#3A3906"),
            System.Drawing.ColorTranslator.FromHtml("#162620"),
            System.Drawing.ColorTranslator.FromHtml("#241D67"),
            System.Drawing.ColorTranslator.FromHtml("#125374"),
            System.Drawing.ColorTranslator.FromHtml("#4256DC"),
            System.Drawing.ColorTranslator.FromHtml("#4B8CEE"),
            System.Drawing.ColorTranslator.FromHtml("#4EDCE0"),
            System.Drawing.ColorTranslator.FromHtml("#C8D9ED"),
            System.Drawing.ColorTranslator.FromHtml("#fff"),
            System.Drawing.ColorTranslator.FromHtml("#92A6AB"),
            System.Drawing.ColorTranslator.FromHtml("#767578"),
            System.Drawing.ColorTranslator.FromHtml("#41433A"),
            System.Drawing.ColorTranslator.FromHtml("#63147F"),
            System.Drawing.ColorTranslator.FromHtml("#6D5F68"),
            System.Drawing.ColorTranslator.FromHtml("#CF2A4D"),
            System.Drawing.ColorTranslator.FromHtml("#CD52AC"),
            System.Drawing.ColorTranslator.FromHtml("#84982D"),
            System.Drawing.ColorTranslator.FromHtml("#7B6911"),
        };


        static public CustomPanel currentPanel;

        public static Color currentColor = Color.Black; // текущий цвет

        private Point initialLocation; // изначальные координаты

        private string choiseTools = "";

        public bool SaveEdit = false;

        public Tools[] ToolsArray;// список инструметов
        private CustomPanel SetupPanel(CustomPanel panel, int x)
        {
            panel.MouseDown += Panel1_MouseDown;
            panel.MouseMove += Panel1_MouseMove;
            panel.MouseUp += Panel1_MouseUp;
            //panel.MouseWheel += panel1_MouseWheel;
            panel.Width = PixelSize * GridWidth;
            panel.Height = PixelSize * GridHeight;
            panel.Location = new Point(x, 60);
            panel.BackColor = Color.White;
            Controls.Add(panel);
            panel.Invalidate();
            return panel;
        }

        public Panel mainColor = new Panel()
        {
            Margin = new Padding(3, 10, 0, 0),
            Size = new Size(35, 35),
            BackColor = currentColor,

        };

        public static Cursor cursor = Cursors.Default;
        private void SetupTools()
        {
            foreach (Tools tool in ToolsArray)
            {
                tool.PixelSize = PixelSize;
                tool.GridWidth = GridWidth;
                tool.GridHeight = GridHeight;
                tool.BrushSize = brushSize;
            }
        }

        public void CustomFonts()
        {
            PrivateFontCollection privateFonts = new PrivateFontCollection();
            string currentDirr = Directory.GetCurrentDirectory();  // получаем корневую папку
            DirectoryInfo projectRoott = Directory.GetParent(currentDirr)?.Parent; // поднимаемся на два уровня выше
            string fontsPath = Path.Combine(projectRoott.FullName, "fonts", "Puzzle.ttf");
            privateFonts.AddFontFile(fontsPath);

            Font myFont = new Font(privateFonts.Families[0], 20, FontStyle.Regular);
            label2.Font = myFont;
            label1.Font = myFont;
            label3.Font = myFont;
        }

        public Form1(TextBox wightGrid, TextBox sizeOnePixel, TextBox heightGrid)
        {
            InitializeComponent();
            SuspendLayout();


            CustomFonts();

            this.DoubleBuffered = true; // активация двойной буферизации
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true); // поддержка прозрачных цвето
            UpdateStyles(); // применение стилей для формы

            //замена панели на кастомную
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#949494");
            menuStrip1.BackColor = System.Drawing.ColorTranslator.FromHtml("#949494");
            GridWidth = Convert.ToInt32(wightGrid.Text);
            GridHeight = Convert.ToInt32(heightGrid.Text);
            PixelSize = Convert.ToInt32(sizeOnePixel.Text);

            currentPanel = new CustomPanel(GridWidth, GridHeight, PixelSize);
            currentPanel = SetupPanel(currentPanel, 250);
            CreateLayer();
            SelectTextBox(0);
            ToolsArray = new Tools[] // Создаем массив инструментов
            {
                new Tools("Карандаш", currentPanel, currentPanel.GetCurrentLayer()), // Карандаш
                new Tools("Ластик", currentPanel, currentPanel.GetCurrentLayer()),   // Ластик
                new Tools("Заливка", currentPanel, currentPanel.GetCurrentLayer()),  // Заливка
                new Tools("Линия", currentPanel, currentPanel.GetCurrentLayer()),    // Линия
                new Tools("Квадрат", currentPanel, currentPanel.GetCurrentLayer()),  // Квадрат
                new Tools("Рука", currentPanel, currentPanel.GetCurrentLayer()),     // Рука
                new Tools("Пипетка", currentPanel, currentPanel.GetCurrentLayer())   // Пипетка
            };

            SetupTools();

            palettePanel.Controls.Clear();
            foreach (var color in PaletteColors)
            {
                var button = new Button
                {
                    BackColor = color,
                    Size = new Size(20, 20),
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    UseVisualStyleBackColor = false,
                    UseMnemonic = false,
                    FlatStyle = FlatStyle.Flat

                };

                button.Click += (sender, e) =>
                {
                    currentColor = color;
                    mainColor.BackColor = color;
                    currentPanel.ChangeColor(new SolidBrush(color));
                };
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.BorderColor = Color.Brown;
                palettePanel.Controls.Add(button);
                palettePanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9d9d9");
            }

            toolsPanel.Controls.Clear();
            foreach (var tool in ToolsArray)
            {
                CreateTool(tool);
            }
            toolsPanel.Controls.Add(mainColor);
        }


        private void CreateTool(Tools tool)
        {
            var button = new Button
            {
                Size = new Size(35, 35),
                BackgroundImageLayout = ImageLayout.Stretch,
                Text = "",
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
                UseMnemonic = false,

            };
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.BorderColor = Color.Brown;
            string currentDir = Directory.GetCurrentDirectory();  // получаем корневую папку
            DirectoryInfo projectRoot = Directory.GetParent(currentDir)?.Parent; // поднимаемся на два уровня выше
            string imagePath = Path.Combine(projectRoot.FullName, "img", "tools", $"{tool.GetName()}.png");

            if (File.Exists(imagePath))
            {
                button.BackgroundImage = Image.FromFile(imagePath);
            }
            else
            {
                Text = tool.GetName();
            }

            button.Click += (sender, e) =>
            {
                choiseTools = tool.GetName();
                if (choiseTools == "Карандаш" || choiseTools == "Ластик")
                {
                    sizePen.Visible = true;
                }
                else
                {
                    sizePen.Visible = false;
                }
                string imageClickPath = Path.Combine(projectRoot.FullName, "img", "tools", $"{tool.GetName()}Click.png");
                ResetButtons();
                button.FlatAppearance.BorderSize = 2;
                button.FlatAppearance.BorderColor = Color.DeepPink;

            };
            toolsPanel.Controls.Add(button);
        }

        private void EditNameForm(string name)
        {
            this.Text = name;
        }

        private void ResetButtons()
        {
            if (toolsPanel != null)
            {
                foreach (Button tool in toolsPanel.Controls)
                {
                    if (toolsPanel.Controls.Count - toolsPanel.Controls.GetChildIndex(tool) == 2)
                    {
                        tool.FlatAppearance.BorderSize = 0;
                        break;
                    }
                    else
                    {
                        tool.FlatAppearance.BorderSize = 0;
                    }
                }
            }
        }

        private List<List<Color>> MergeLayers(List<List<List<Color>>> layers)
        {
            // Предположим, что все слои имеют одинаковый размер
            int width = layers[0].Count;
            int height = layers[0][0].Count;

            List<List<Color>> mergedMatrix = new List<List<Color>>();

            for (int y = 0; y < height; y++)
            {
                List<Color> row = new List<Color>();
                for (int x = 0; x < width; x++)
                {
                    // Объединяем пиксели из всех слоев
                    Color mergedColor = Color.Transparent;
                    foreach (var layer in layers)
                    {
                        Color layerColor = layer[y][x];
                        if (layerColor.A > 0) // Если пиксель непрозрачный
                        {
                            mergedColor = layerColor;
                            break; // Используем первый непрозрачный пиксель
                        }
                    }
                    row.Add(mergedColor);
                }
                mergedMatrix.Add(row);
            }

            return mergedMatrix;
        }

        private Bitmap CreateBitmap(List<List<Color>> matrix)
        {
            int width = matrix[0].Count;
            int height = matrix.Count;

            Bitmap bitmap = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color color = matrix[y][x];
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }

        private ImageFormat GetImageFormat(int filterIndex)
        {
            switch (filterIndex)
            {
                case 1: return ImageFormat.Png;
                case 2: return ImageFormat.Jpeg;
                case 3: return ImageFormat.Bmp;
                default: return ImageFormat.Png;
            }
        }

        public static List<List<List<Color>>> ConvertToListOfLists(List<int[,]> layers)
        {
            List<List<List<Color>>> result = new List<List<List<Color>>>();

            foreach (var layer in layers)
            {
                List<List<Color>> layerList = new List<List<Color>>();

                for (int y = 0; y < layer.GetLength(0); y++)
                {
                    List<Color> row = new List<Color>();
                    for (int x = 0; x < layer.GetLength(1); x++)
                    {
                        int argbValue = layer[y, x];
                        Color color = Color.FromArgb(argbValue);
                        row.Add(color);
                    }
                    layerList.Add(row);
                }

                result.Add(layerList);
            }

            return result;
        }


        private void SaveFile(object sender, EventArgs e)
        {
            // Преобразуем список двумерных массивов в список списков списков
            List<int[,]> layers = currentPanel.listLayers;
            List<List<List<Color>>> colorLayers = ConvertToListOfLists(layers);

            // Объединяем все слои в одну матрицу
            List<List<Color>> mergedMatrix = MergeLayers(colorLayers);

            // Создаем изображение из объединенной матрицы
            Bitmap bitmap = CreateBitmap(mergedMatrix);

            // Сохраняем изображение
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp|All files (*.*)|*.*";
                saveFileDialog.Title = "Сохранить изображение как...";
                saveFileDialog.FileName = "saved_image"; // Имя файла по умолчанию

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bitmap.Save(saveFileDialog.FileName, GetImageFormat(saveFileDialog.FilterIndex));
                        MessageBox.Show("Изображение сохранено успешно!");
                        EditNameForm("Графический редактор (изменения сохранены)");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении изображения: {ex.Message}");
                    }
                }
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && choiseTools == "Рука")
            {
                UseTools(e);
                initialLocation = e.Location;
                isDragging = true;
            }
            else if (e.Button == MouseButtons.Left && choiseTools == "Линия")
            {
                if (isFirstClick)
                {
                    startPoint = new Point(e.X/ PixelSize, e.Y/ PixelSize);
                    isFirstClick = false;
                    
                }
                else
                {
                    endPoint = new Point(e.X/ PixelSize, (e.Y/ PixelSize) );
                    DrawLine(startPoint, endPoint, currentColor);
                    isFirstClick = true;
                }
            }
            if (e.Button == MouseButtons.Left && !drawingSquare)
            {
                squareStartPoint = new Point(e.X,e.Y);
                drawingSquare = true;
            }
            else
            {
                Point endPoint = new Point(e.X, e.Y);
                int i = 0;
                foreach (Tools tool in ToolsArray)
                {
                    if (tool.GetName() == choiseTools)
                    {
                        isDrawing = true;
                        ToolsArray[i].UseTool(choiseTools, squareStartPoint, endPoint, currentColor);
                        mainColor.BackColor = currentColor;
                        Cursor = cursor;
                        break;
                    }
                    i++;
                }
                drawingSquare = false;
            }

            if (e.Button == MouseButtons.Left)
            {
                UseTools(e);
            }
        }
        public void DrawLine(Point start, Point end, Color color)
        {
            int x1 = start.X;
            int y1 = start.Y;
            int x2 = end.X;
            int y2 = end.Y;

            BresenhamAlgorithm(x1, y1, x2, y2, color);
        }
        private void BresenhamAlgorithm(int x1, int y1, int x2, int y2, Color color)
        {
            bool steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

            if (steep)
            {
                Swap(ref x1, ref y1);
                Swap(ref x2, ref y2);
            }

            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
            }

            int deltaX = x2 - x1;
            int deltaY = Math.Abs(y2 - y1);
            float error = 0f;
            float deltaError = ((float)deltaY) / deltaX;
            int yStep = (y1 < y2 ? 1 : -1);
            int y = y1;

            for (int x = x1; x <= x2; ++x)
            {
                SetPixel(steep ? y : x, steep ? x : y, color);
                error += deltaError;
                if (error >= 0.5f)
                {
                    y += yStep;
                    error -= 1.0f;
                }
            }
        }

        // Дополнительные вспомогательные методы
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && x < GridWidth && y >= 0 && y < GridHeight)
            {
                currentPanel.GetCurrentLayer()[x, y] = color.ToArgb();
            }
            currentPanel.Invalidate();
        }
        private void UseTools(MouseEventArgs e)
        {
            int i = 0;
            foreach (Tools tool in ToolsArray)
            {
                if (tool.GetName() == choiseTools)
                {
                    isDrawing = true;
                    ToolsArray[i].UseTool(choiseTools, e.Location, currentColor);
                    mainColor.BackColor = currentColor;
                    Cursor = cursor;
                    break;
                }
                i++;
            }
        }



        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.Button == MouseButtons.Left && choiseTools == "Рука")
            {
                // Рассчитываем новый центр панели относительно начальной точки

                int x = currentPanel.Location.X + (e.Location.X - initialLocation.X);
                int y = currentPanel.Location.Y + (e.Location.Y - initialLocation.Y);

                Point oldLocation = currentPanel.Location;

                //ограничение на перемещение
                if (x > 78 && x < 842 && y > 38)
                {
                    Point newLocation = new Point(x, y);
                    currentPanel.Location = newLocation;
                }
                else
                {
                    Point newLocation = new Point(x + currentPanel.Location.X, y + currentPanel.Location.Y);
                    currentPanel.Location = oldLocation;
                }
            }
            if (isDrawing)
            {
                UseTools(e);
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && choiseTools == "Рука")
            {
                isDragging = false;
                initialLocation = Point.Empty;
            }
            if (e.Button == MouseButtons.Left)
                isDrawing = false; // Завершаем рисование
        }


        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                HandleForwardScroll();
            else if (e.Delta < 0)
                HandleBackwardScroll();
        }

        private void HandleForwardScroll() // метод для увеличения (прокрутка вверх)
        {
            // Создаем копию старых пикселей
            int[,] oldPixels = currentPanel.GetCurrentLayer().Clone() as int[,]; // Используем клональное копирование

            // Определение новых размеров (увеличение примерно на 10%)
            int newGridWidth = (int)Math.Round(GridWidth * 1.1);
            int newGridHeight = (int)Math.Round(GridHeight * 1.1);

            // Создание нового слоя увеличенного размера
            int[,] newPixels = new int[newGridWidth, newGridHeight];

            // Переход от старой сетки к новой
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    // Интерполируем координаты и переносим пиксели
                    int newX = (int)Math.Floor((double)x * newGridWidth / GridWidth);
                    int newY = (int)Math.Floor((double)y * newGridHeight / GridHeight);
                    newPixels[newX, newY] = oldPixels[x, y];
                }
            }
            GridWidth = newGridWidth;
            GridHeight = newGridHeight;
            currentPanel.Width = PixelSize * GridWidth;
            currentPanel.Height = PixelSize * GridHeight;

            // Принудительная перерисовка панели
            currentPanel.Invalidate();
        }

        private void HandleBackwardScroll() // метод для уменьшения (прокрутка вниз)
        {
            // Создаем копию старых пикселей
            int[,] oldPixels = currentPanel.GetCurrentLayer().Clone() as int[,];

            // Определение новых размеров (уменьшение примерно на 10%)
            int newGridWidth = (int)Math.Round(GridWidth / 1.1);
            int newGridHeight = (int)Math.Round(GridHeight / 1.1);

            // Создание нового слоя уменьшенного размера
            int[,] newPixels = new int[newGridWidth, newGridHeight];

            // Переход от старой сетки к новой
            for (int y = 0; y < newGridHeight; y++)
            {
                for (int x = 0; x < newGridWidth; x++)
                {
                    // Интерполируем координаты и переносим пиксели
                    int oldX = (int)Math.Floor((double)x * GridWidth / newGridWidth);
                    int oldY = (int)Math.Floor((double)y * GridHeight / newGridHeight);
                    newPixels[x, y] = oldPixels[oldX, oldY];
                }
            }

            GridWidth = newGridWidth;
            GridHeight = newGridHeight;
            currentPanel.Width = PixelSize * GridWidth;
            currentPanel.Height = PixelSize * GridHeight;
            currentPanel.Invalidate();
        }

        public List<TextBox> TextBoxList = new List<TextBox>();

        private void TextBox1_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ResetTextBoxes();

                TextBox textbox = (TextBox)sender;

                ((TextBox)sender).BackColor = Color.Pink;
                ((TextBox)sender).Tag = 1;

                int index = panelLayers.Controls.IndexOf(textbox);
                currentPanel.SelectLayer(index);
            }
        }

        public void SelectTextBox(int index)
        {
            if (index > -1)
            {
                ResetTextBoxes();
                panelLayers.Controls[index].BackColor = Color.Pink;
                panelLayers.Controls[index].Tag = 1;
            }
        }

        private void ResetTextBoxes()
        {
            if (panelLayers != null)
            {
                foreach (TextBox textbox in panelLayers.Controls)
                {
                    textbox.BackColor = Color.White;
                    textbox.Tag = 0;
                }
            }
        }

        private TextBox CreateLayer()
        {
            TextBox layer = new TextBox()
            {
                Text = "cлой " + currentPanel.listLayers.Count,
                Name = "layer",
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                //Font = new Font(new FontFamily("TDAText"), 11),
                Tag = 0,
                Cursor = Cursors.Arrow,
                
            };
            ResetTextBoxes();
            layer.MouseDown += new MouseEventHandler(TextBox1_Click);
            panelLayers.Controls.Add(layer);
            SelectTextBox(panelLayers.Controls.Count - 1);
            return layer;
        }

        private TextBox CreateLayer(string text)
        {
            PrivateFontCollection privateFonts = new PrivateFontCollection();
            string currentDirr = Directory.GetCurrentDirectory();  // получаем корневую папку
            DirectoryInfo projectRoott = Directory.GetParent(currentDirr)?.Parent; // поднимаемся на два уровня выше
            string fontsPath = Path.Combine(projectRoott.FullName, "fonts", "TDAText.ttf");
            privateFonts.AddFontFile(fontsPath);

            Font myFont = new Font(privateFonts.Families[0], 20, FontStyle.Regular);

            TextBox layer = new TextBox()
            {
                Text = "cлой " + currentPanel.listLayers.Count + " " + text,
                Name = "layer",
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Font = myFont,
                Tag = 0,
                Cursor = Cursors.Arrow,
            };
            ResetTextBoxes();
            layer.MouseDown += new MouseEventHandler(TextBox1_Click);
            panelLayers.Controls.Add(layer);
            SelectTextBox(panelLayers.Controls.Count - 1);
            return layer;
        }

        private void AddLayerBtn_Click(object sender, EventArgs e)
        {
            currentPanel.AddNewLayer();
            CreateLayer();
            currentPanel.SelectLayer(currentPanel.listLayers.Count - 1);
            SelectTextBox(currentPanel.listLayers.Count - 1);
        }

        private void DeleteLayerBtn_Click(object sender, EventArgs e)
        {
            if (panelLayers.Controls.Count > 1)
            {
                bool success = false;
                foreach (TextBox textbox in panelLayers.Controls)
                {
                    if (textbox.Tag.ToString() == "1")
                    {

                        int i = panelLayers.Controls.IndexOf(textbox);
                        panelLayers.Controls.Remove(textbox);
                        currentPanel.DeleteLayer(i);
                        currentPanel.SelectLayer(i - 1);
                        SelectTextBox(i - 1);
                        success = true;
                        currentPanel.Invalidate();
                        break;
                    }
                }

                if (success == false)
                {
                    int lastChild = currentPanel.listLayers.Count - 1;
                    panelLayers.Controls.RemoveAt(lastChild);
                    currentPanel.DeleteLayer(lastChild);
                    currentPanel.SelectLayer(lastChild - 1);
                    SelectTextBox(lastChild - 1);
                    currentPanel.Invalidate();
                }
            }
            else
            {
                MessageBox.Show("Единственный слой удалить нельзя");
            }
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            brushSize = trackBar1.Value;
            SetupTools();
        }

        private void скрытьИнтерфейсToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (HideClientsInterface.Text == "скрыть интерфейс")
            {
                toolsPanel.Visible = false;
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel2.Visible = false;
                sizePen.Visible = false;
                HideClientsInterface.Text = "показать интерфейс";
            }
            else
            {
                toolsPanel.Visible = true;
                tableLayoutPanel1.Visible = true;
                tableLayoutPanel2.Visible = true;
                sizePen.Visible = true;
                HideClientsInterface.Text = "скрыть интерфейс";
            }
        }

        private void newLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPanel.AddNewLayer();
            CreateLayer();
            currentPanel.SelectLayer(currentPanel.listLayers.Count - 1);
            SelectTextBox(currentPanel.listLayers.Count - 1);
        }

        private void arrowUp_Click(object sender, EventArgs e)
        {
            if (panelLayers.Controls.Count > 1)
            {
                foreach (TextBox textbox in panelLayers.Controls)
                {
                    if (textbox.Tag.ToString() == "1")
                    {
                        int oldIndex = panelLayers.Controls.IndexOf(textbox);
                        int newIndex = oldIndex - 1;
                        panelLayers.Controls.SetChildIndex(textbox, newIndex);
                        currentPanel.SwapPlaces(oldIndex, newIndex);
                        currentPanel.Invalidate();
                        currentPanel.SelectLayer(newIndex);
                        ResetTextBoxes();
                        SelectTextBox(newIndex);
                        break;
                    }
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int newXPosition = (Width - 160);
            tableLayoutPanel1.Location = new Point(newXPosition, 254);
            tableLayoutPanel2.Location = new Point(newXPosition, 46);
            sizePen.Location = new Point(Width / 5, Height - 100);

            CustomFonts();
        }

        private void arrowDown_Click(object sender, EventArgs e)
        {
            if (panelLayers.Controls.Count > 1)
            {
                foreach (TextBox textbox in panelLayers.Controls)
                {
                    if (textbox.Tag.ToString() == "1")
                    {
                        int oldIndex = panelLayers.Controls.IndexOf(textbox);
                        int newIndex = oldIndex + 1;
                        if (newIndex > panelLayers.Controls.Count - 1)
                        {
                            newIndex = 0;
                        }
                        panelLayers.Controls.SetChildIndex(textbox, newIndex);
                        currentPanel.SwapPlaces(oldIndex, newIndex);
                        currentPanel.Invalidate();
                        currentPanel.SelectLayer(newIndex);
                        ResetTextBoxes();
                        SelectTextBox(newIndex);
                        break;
                    }
                }
            }
        }

        private void DuplicateLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelLayers.Controls.Count >= 1)
            {
                foreach (TextBox textbox in panelLayers.Controls)
                {
                    if (textbox.Tag.ToString() == "1")
                    {
                        int index = panelLayers.Controls.IndexOf(textbox);
                        CreateLayer("copy");
                        currentPanel.DublicateLayer(index);
                        break;
                    }
                }
            }

        }
    }
}
