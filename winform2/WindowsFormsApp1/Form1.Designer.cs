namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sizePen = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.слойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideClientsInterface = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.addLayerBtn = new System.Windows.Forms.Button();
            this.arrowUp = new System.Windows.Forms.Button();
            this.arrowDown = new System.Windows.Forms.Button();
            this.deleteLayerBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.palettePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sizePen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolsPanel
            // 
            this.toolsPanel.Location = new System.Drawing.Point(0, 69);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.toolsPanel.Size = new System.Drawing.Size(78, 492);
            this.toolsPanel.TabIndex = 1;
            // 
            // sizePen
            // 
            this.sizePen.Controls.Add(this.label3);
            this.sizePen.Controls.Add(this.trackBar1);
            this.sizePen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sizePen.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sizePen.Location = new System.Drawing.Point(0, 516);
            this.sizePen.Name = "sizePen";
            this.sizePen.Padding = new System.Windows.Forms.Padding(100, 0, 0, 0);
            this.sizePen.Size = new System.Drawing.Size(984, 45);
            this.sizePen.TabIndex = 3;
            this.sizePen.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label3.Size = new System.Drawing.Size(148, 35);
            this.label3.TabIndex = 1;
            this.label3.Text = "размер кисти";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trackBar1.LargeChange = 0;
            this.trackBar1.Location = new System.Drawing.Point(267, 3);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(432, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.слойToolStripMenuItem,
            this.видToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 10);
            this.menuStrip1.Size = new System.Drawing.Size(984, 46);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.сохранитьToolStripMenuItem1});
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.файлToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.файлToolStripMenuItem.Text = "файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.сохранитьToolStripMenuItem.Text = "экспорт";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.SaveFile);
            // 
            // сохранитьToolStripMenuItem1
            // 
            this.сохранитьToolStripMenuItem1.Name = "сохранитьToolStripMenuItem1";
            this.сохранитьToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.сохранитьToolStripMenuItem1.Text = "сохранить";
            // 
            // слойToolStripMenuItem
            // 
            this.слойToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLayerToolStripMenuItem,
            this.duplicateLayerToolStripMenuItem});
            this.слойToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.слойToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.слойToolStripMenuItem.Name = "слойToolStripMenuItem";
            this.слойToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.слойToolStripMenuItem.Text = "слои";
            // 
            // newLayerToolStripMenuItem
            // 
            this.newLayerToolStripMenuItem.Name = "newLayerToolStripMenuItem";
            this.newLayerToolStripMenuItem.Size = new System.Drawing.Size(218, 24);
            this.newLayerToolStripMenuItem.Text = "новый слой";
            this.newLayerToolStripMenuItem.Click += new System.EventHandler(this.newLayerToolStripMenuItem_Click);
            // 
            // duplicateLayerToolStripMenuItem
            // 
            this.duplicateLayerToolStripMenuItem.Name = "duplicateLayerToolStripMenuItem";
            this.duplicateLayerToolStripMenuItem.Size = new System.Drawing.Size(218, 24);
            this.duplicateLayerToolStripMenuItem.Text = "дублировать слой";
            this.duplicateLayerToolStripMenuItem.Click += new System.EventHandler(this.DuplicateLayerToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HideClientsInterface});
            this.видToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.видToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.видToolStripMenuItem.Text = "вид";
            // 
            // HideClientsInterface
            // 
            this.HideClientsInterface.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HideClientsInterface.Name = "HideClientsInterface";
            this.HideClientsInterface.Size = new System.Drawing.Size(222, 24);
            this.HideClientsInterface.Text = "скрыть интерфейс";
            this.HideClientsInterface.Click += new System.EventHandler(this.скрытьИнтерфейсToolStripMenuItem1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelLayers, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(848, 260);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(130, 304);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "слои";
            // 
            // panelLayers
            // 
            this.panelLayers.AutoScroll = true;
            this.panelLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLayers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelLayers.Location = new System.Drawing.Point(3, 72);
            this.panelLayers.Name = "panelLayers";
            this.panelLayers.Size = new System.Drawing.Size(124, 229);
            this.panelLayers.TabIndex = 3;
            this.panelLayers.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.addLayerBtn);
            this.flowLayoutPanel2.Controls.Add(this.arrowUp);
            this.flowLayoutPanel2.Controls.Add(this.arrowDown);
            this.flowLayoutPanel2.Controls.Add(this.deleteLayerBtn);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 39);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(124, 27);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // addLayerBtn
            // 
            this.addLayerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addLayerBtn.Location = new System.Drawing.Point(3, 3);
            this.addLayerBtn.Name = "addLayerBtn";
            this.addLayerBtn.Size = new System.Drawing.Size(25, 25);
            this.addLayerBtn.TabIndex = 0;
            this.addLayerBtn.Text = "+";
            this.addLayerBtn.UseVisualStyleBackColor = true;
            this.addLayerBtn.Click += new System.EventHandler(this.AddLayerBtn_Click);
            // 
            // arrowUp
            // 
            this.arrowUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arrowUp.Location = new System.Drawing.Point(34, 3);
            this.arrowUp.Name = "arrowUp";
            this.arrowUp.Size = new System.Drawing.Size(25, 25);
            this.arrowUp.TabIndex = 1;
            this.arrowUp.Text = "↑";
            this.arrowUp.UseVisualStyleBackColor = true;
            this.arrowUp.Click += new System.EventHandler(this.arrowUp_Click);
            // 
            // arrowDown
            // 
            this.arrowDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arrowDown.Location = new System.Drawing.Point(65, 3);
            this.arrowDown.Name = "arrowDown";
            this.arrowDown.Size = new System.Drawing.Size(25, 25);
            this.arrowDown.TabIndex = 2;
            this.arrowDown.Text = "↓";
            this.arrowDown.UseVisualStyleBackColor = true;
            this.arrowDown.Click += new System.EventHandler(this.arrowDown_Click);
            // 
            // deleteLayerBtn
            // 
            this.deleteLayerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteLayerBtn.Location = new System.Drawing.Point(96, 3);
            this.deleteLayerBtn.Name = "deleteLayerBtn";
            this.deleteLayerBtn.Size = new System.Drawing.Size(25, 25);
            this.deleteLayerBtn.TabIndex = 3;
            this.deleteLayerBtn.Text = "✖";
            this.deleteLayerBtn.UseVisualStyleBackColor = true;
            this.deleteLayerBtn.Click += new System.EventHandler(this.DeleteLayerBtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.palettePanel, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(848, 58);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.63415F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.36585F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(130, 205);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "палитра";
            // 
            // palettePanel
            // 
            this.palettePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.palettePanel.AutoScroll = true;
            this.palettePanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.palettePanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.palettePanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.palettePanel.Location = new System.Drawing.Point(5, 33);
            this.palettePanel.Name = "palettePanel";
            this.palettePanel.Size = new System.Drawing.Size(120, 169);
            this.palettePanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(704, 353);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 3, 23, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 136);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.sizePen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.toolsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Графический редактор (несохраненные изменения)";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.sizePen.ResumeLayout(false);
            this.sizePen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel toolsPanel;
        private System.Windows.Forms.FlowLayoutPanel sizePen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem слойToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HideClientsInterface;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel panelLayers;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button addLayerBtn;
        private System.Windows.Forms.Button arrowUp;
        private System.Windows.Forms.Button arrowDown;
        private System.Windows.Forms.Button deleteLayerBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel palettePanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

