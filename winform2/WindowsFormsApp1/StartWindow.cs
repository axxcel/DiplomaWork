using DiplomaWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
            PrivateFontCollection privateFonts = new PrivateFontCollection();
            string currentDirr = Directory.GetCurrentDirectory();  // получаем корневую папку
            DirectoryInfo projectRoott = Directory.GetParent(currentDirr)?.Parent; // поднимаемся на два уровня выше
            string fontsPath = Path.Combine(projectRoott.FullName, "fonts", "Puzzle.ttf");
            privateFonts.AddFontFile(fontsPath);

            Font myFont = new Font(privateFonts.Families[0], 72, FontStyle.Regular);
            Font twoFont = new Font(privateFonts.Families[0], 18, FontStyle.Regular);
            label1.Font = myFont;
            button1.Font = twoFont;
        }

        private void CreateDock(object sender, EventArgs e)
        {
            CreateFile createFile = new CreateFile();
            createFile.Show();

        }
    }
}
