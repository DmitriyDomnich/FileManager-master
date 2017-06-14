namespace FileManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ViewTwo = new System.Windows.Forms.ListView();
            this.Name2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastModified2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bBack = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bCopy = new System.Windows.Forms.Button();
            this.bCut = new System.Windows.Forms.Button();
            this.bPaste = new System.Windows.Forms.Button();
            this.bProperties = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ViewOne = new System.Windows.Forms.ListView();
            this.listBoxForFirstView = new System.Windows.Forms.ListBox();
            this.listBoxForSecondView = new System.Windows.Forms.ListBox();
            this.bDelete = new System.Windows.Forms.Button();
            this.textBoxForFirstView = new System.Windows.Forms.TextBox();
            this.textBoxForSecondView = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folders.jpeg");
            this.imageList1.Images.SetKeyName(1, "Files.jpg");
            // 
            // ViewTwo
            // 
            this.ViewTwo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name2,
            this.Size2,
            this.LastModified2});
            this.ViewTwo.Location = new System.Drawing.Point(497, 106);
            this.ViewTwo.Name = "ViewTwo";
            this.ViewTwo.Size = new System.Drawing.Size(445, 399);
            this.ViewTwo.SmallImageList = this.imageList1;
            this.ViewTwo.TabIndex = 1;
            this.ViewTwo.UseCompatibleStateImageBehavior = false;
            this.ViewTwo.View = System.Windows.Forms.View.Details;
            this.ViewTwo.DoubleClick += new System.EventHandler(this.ViewTwo_DoubleClick);
            // 
            // Name2
            // 
            this.Name2.Text = "Name";
            this.Name2.Width = 167;
            // 
            // Size2
            // 
            this.Size2.Text = "Size";
            this.Size2.Width = 114;
            // 
            // LastModified2
            // 
            this.LastModified2.Text = "LastModified";
            this.LastModified2.Width = 158;
            // 
            // bBack
            // 
            this.bBack.Location = new System.Drawing.Point(430, 12);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(93, 34);
            this.bBack.TabIndex = 2;
            this.bBack.Text = "<<";
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // bCopy
            // 
            this.bCopy.Location = new System.Drawing.Point(194, 12);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(93, 34);
            this.bCopy.TabIndex = 3;
            this.bCopy.Text = "Copy";
            this.bCopy.UseVisualStyleBackColor = true;
            this.bCopy.Click += new System.EventHandler(this.bCopy_Click);
            // 
            // bCut
            // 
            this.bCut.Location = new System.Drawing.Point(316, 12);
            this.bCut.Name = "bCut";
            this.bCut.Size = new System.Drawing.Size(93, 34);
            this.bCut.TabIndex = 4;
            this.bCut.Text = "Cut";
            this.bCut.UseVisualStyleBackColor = true;
            this.bCut.Click += new System.EventHandler(this.bCut_Click);
            // 
            // bPaste
            // 
            this.bPaste.Location = new System.Drawing.Point(544, 12);
            this.bPaste.Name = "bPaste";
            this.bPaste.Size = new System.Drawing.Size(93, 34);
            this.bPaste.TabIndex = 5;
            this.bPaste.Text = "Paste";
            this.bPaste.UseVisualStyleBackColor = true;
            this.bPaste.Click += new System.EventHandler(this.bPaste_Click);
            // 
            // bProperties
            // 
            this.bProperties.Location = new System.Drawing.Point(661, 12);
            this.bProperties.Name = "bProperties";
            this.bProperties.Size = new System.Drawing.Size(93, 34);
            this.bProperties.TabIndex = 6;
            this.bProperties.Text = "Properties";
            this.bProperties.UseVisualStyleBackColor = true;
            this.bProperties.Click += new System.EventHandler(this.bProperties_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 155;
            // 
            // Size
            // 
            this.Size.Text = "Size";
            this.Size.Width = 83;
            // 
            // LastModified
            // 
            this.LastModified.Text = "LastModified";
            this.LastModified.Width = 165;
            // 
            // ViewOne
            // 
            this.ViewOne.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Size,
            this.LastModified});
            this.ViewOne.Location = new System.Drawing.Point(6, 106);
            this.ViewOne.Name = "ViewOne";
            this.ViewOne.Size = new System.Drawing.Size(445, 401);
            this.ViewOne.SmallImageList = this.imageList1;
            this.ViewOne.TabIndex = 0;
            this.ViewOne.UseCompatibleStateImageBehavior = false;
            this.ViewOne.View = System.Windows.Forms.View.Details;
            this.ViewOne.DoubleClick += new System.EventHandler(this.ViewOne_DoubleClick);
            // 
            // listBoxForFirstView
            // 
            this.listBoxForFirstView.FormattingEnabled = true;
            this.listBoxForFirstView.Location = new System.Drawing.Point(6, 513);
            this.listBoxForFirstView.Name = "listBoxForFirstView";
            this.listBoxForFirstView.Size = new System.Drawing.Size(445, 95);
            this.listBoxForFirstView.TabIndex = 7;
            // 
            // listBoxForSecondView
            // 
            this.listBoxForSecondView.FormattingEnabled = true;
            this.listBoxForSecondView.Location = new System.Drawing.Point(497, 513);
            this.listBoxForSecondView.Name = "listBoxForSecondView";
            this.listBoxForSecondView.Size = new System.Drawing.Size(445, 95);
            this.listBoxForSecondView.TabIndex = 8;
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(773, 12);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(87, 34);
            this.bDelete.TabIndex = 9;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // textBoxForFirstView
            // 
            this.textBoxForFirstView.Location = new System.Drawing.Point(6, 52);
            this.textBoxForFirstView.Name = "textBoxForFirstView";
            this.textBoxForFirstView.Size = new System.Drawing.Size(445, 20);
            this.textBoxForFirstView.TabIndex = 10;
            // 
            // textBoxForSecondView
            // 
            this.textBoxForSecondView.Location = new System.Drawing.Point(497, 52);
            this.textBoxForSecondView.Name = "textBoxForSecondView";
            this.textBoxForSecondView.Size = new System.Drawing.Size(445, 20);
            this.textBoxForSecondView.TabIndex = 11;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(243, 83);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(479, 17);
            this.listBox1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 615);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBoxForSecondView);
            this.Controls.Add(this.textBoxForFirstView);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.listBoxForSecondView);
            this.Controls.Add(this.listBoxForFirstView);
            this.Controls.Add(this.bProperties);
            this.Controls.Add(this.bPaste);
            this.Controls.Add(this.bCut);
            this.Controls.Add(this.bCopy);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.ViewTwo);
            this.Controls.Add(this.ViewOne);
            this.Text = "File Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView ViewTwo;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.ColumnHeader Name2;
        private System.Windows.Forms.ColumnHeader Size2;
        private System.Windows.Forms.ColumnHeader LastModified2;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button bCopy;
        private System.Windows.Forms.Button bCut;
        private System.Windows.Forms.Button bPaste;
        private System.Windows.Forms.Button bProperties;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ColumnHeader LastModified;
        private System.Windows.Forms.ListView ViewOne;
        public System.Windows.Forms.ListBox listBoxForFirstView;
        public System.Windows.Forms.ListBox listBoxForSecondView;
        private System.Windows.Forms.Button bDelete;
        public System.Windows.Forms.TextBox textBoxForFirstView;
        public System.Windows.Forms.TextBox textBoxForSecondView;
        public System.Windows.Forms.ListBox listBox1;
    }
}

