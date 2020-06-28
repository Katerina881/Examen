namespace View
{
    partial class FormOsns
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.изделиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCh = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.сохранитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изделиеToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.сохранитьФайлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(647, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // изделиеToolStripMenuItem
            // 
            this.изделиеToolStripMenuItem.Name = "изделиеToolStripMenuItem";
            this.изделиеToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.изделиеToolStripMenuItem.Text = "изделие";
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.отчетыToolStripMenuItem.Text = "отчеты";
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 26);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(508, 334);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(512, 46);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(105, 33);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonCh
            // 
            this.buttonCh.Location = new System.Drawing.Point(512, 108);
            this.buttonCh.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCh.Name = "buttonCh";
            this.buttonCh.Size = new System.Drawing.Size(105, 34);
            this.buttonCh.TabIndex = 3;
            this.buttonCh.Text = "Изменить";
            this.buttonCh.UseVisualStyleBackColor = true;
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(512, 171);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(105, 30);
            this.buttonDel.TabIndex = 4;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(512, 233);
            this.buttonUpd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(105, 32);
            this.buttonUpd.TabIndex = 5;
            this.buttonUpd.Text = "Обновить";
            this.buttonUpd.UseVisualStyleBackColor = true;
            // 
            // сохранитьФайлToolStripMenuItem
            // 
            this.сохранитьФайлToolStripMenuItem.Name = "сохранитьФайлToolStripMenuItem";
            this.сохранитьФайлToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.сохранитьФайлToolStripMenuItem.Text = "сохранить файл";
            this.сохранитьФайлToolStripMenuItem.Click += new System.EventHandler(this.сохранитьФайлToolStripMenuItem_Click);
            // 
            // FormOsns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 383);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonCh);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormOsns";
            this.Text = "FormOsns";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem изделиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCh;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.ToolStripMenuItem сохранитьФайлToolStripMenuItem;
    }
}