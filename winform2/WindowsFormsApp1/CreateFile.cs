using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace DiplomaWork
{
    public partial class CreateFile : Form
    {
        public CreateFile()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(360, 400);
            this.Text = "Создать новый документ";

            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#A8A8A8");
        }

        private void NewFile(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(widthGrid, sizeOnePixel, heightGrid);
            this.Close();
            form1.ShowDialog();
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }

        private void widthGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
