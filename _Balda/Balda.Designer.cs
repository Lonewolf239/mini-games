namespace minigames._Balda
{
    partial class Balda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Balda));
            this.score_label = new System.Windows.Forms.Label();
            this.top_panel = new System.Windows.Forms.Panel();
            this.time_label = new System.Windows.Forms.Label();
            this.time_timer = new System.Windows.Forms.Timer(this.components);
            this.field_panel = new System.Windows.Forms.Panel();
            this.words_list = new System.Windows.Forms.ListBox();
            this.bottom_panel = new System.Windows.Forms.Panel();
            this.words_counter = new System.Windows.Forms.Label();
            this.question = new System.Windows.Forms.Button();
            this.left_panel = new System.Windows.Forms.Panel();
            this.by = new System.Windows.Forms.Label();
            this.developer_name = new System.Windows.Forms.Label();
            this.start_btn = new System.Windows.Forms.Button();
            this.show_settings = new System.Windows.Forms.PictureBox();
            this.top_panel.SuspendLayout();
            this.bottom_panel.SuspendLayout();
            this.left_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_settings)).BeginInit();
            this.SuspendLayout();
            // 
            // score_label
            // 
            this.score_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score_label.Location = new System.Drawing.Point(0, 0);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(209, 38);
            this.score_label.TabIndex = 0;
            this.score_label.Text = "Счёт: 0";
            this.score_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // top_panel
            // 
            this.top_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.top_panel.Controls.Add(this.time_label);
            this.top_panel.Controls.Add(this.score_label);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(390, 40);
            this.top_panel.TabIndex = 2;
            // 
            // time_label
            // 
            this.time_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.time_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_label.Location = new System.Drawing.Point(209, 0);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(179, 38);
            this.time_label.TabIndex = 2;
            this.time_label.Text = "Время: 00:00";
            this.time_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time_timer
            // 
            this.time_timer.Interval = 1000;
            this.time_timer.Tick += new System.EventHandler(this.Time_timer_Tick);
            // 
            // field_panel
            // 
            this.field_panel.BackColor = System.Drawing.Color.Gainsboro;
            this.field_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.field_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.field_panel.Location = new System.Drawing.Point(0, 40);
            this.field_panel.Name = "field_panel";
            this.field_panel.Size = new System.Drawing.Size(390, 390);
            this.field_panel.TabIndex = 3;
            // 
            // words_list
            // 
            this.words_list.BackColor = System.Drawing.SystemColors.Window;
            this.words_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.words_list.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.words_list.FormattingEnabled = true;
            this.words_list.ItemHeight = 24;
            this.words_list.Location = new System.Drawing.Point(0, 42);
            this.words_list.Name = "words_list";
            this.words_list.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.words_list.Size = new System.Drawing.Size(198, 432);
            this.words_list.Sorted = true;
            this.words_list.TabIndex = 0;
            this.words_list.TabStop = false;
            // 
            // bottom_panel
            // 
            this.bottom_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bottom_panel.Controls.Add(this.words_counter);
            this.bottom_panel.Controls.Add(this.words_list);
            this.bottom_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.bottom_panel.Location = new System.Drawing.Point(390, 0);
            this.bottom_panel.Name = "bottom_panel";
            this.bottom_panel.Size = new System.Drawing.Size(200, 476);
            this.bottom_panel.TabIndex = 5;
            // 
            // words_counter
            // 
            this.words_counter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.words_counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.words_counter.Location = new System.Drawing.Point(0, 0);
            this.words_counter.Name = "words_counter";
            this.words_counter.Size = new System.Drawing.Size(198, 42);
            this.words_counter.TabIndex = 1;
            this.words_counter.Text = "Осталось слов: 0";
            this.words_counter.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // question
            // 
            this.question.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.question.Location = new System.Drawing.Point(40, 436);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 25;
            this.question.TabStop = false;
            this.question.Text = "?";
            this.question.UseVisualStyleBackColor = true;
            this.question.Click += new System.EventHandler(this.Question_Click);
            // 
            // left_panel
            // 
            this.left_panel.Controls.Add(this.field_panel);
            this.left_panel.Controls.Add(this.top_panel);
            this.left_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.left_panel.Location = new System.Drawing.Point(0, 0);
            this.left_panel.Name = "left_panel";
            this.left_panel.Size = new System.Drawing.Size(390, 430);
            this.left_panel.TabIndex = 6;
            // 
            // by
            // 
            this.by.Cursor = System.Windows.Forms.Cursors.Default;
            this.by.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by.Location = new System.Drawing.Point(279, 436);
            this.by.Name = "by";
            this.by.Size = new System.Drawing.Size(111, 21);
            this.by.TabIndex = 31;
            this.by.Text = "By.";
            this.by.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // developer_name
            // 
            this.developer_name.AutoSize = true;
            this.developer_name.Cursor = System.Windows.Forms.Cursors.Help;
            this.developer_name.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developer_name.Location = new System.Drawing.Point(255, 455);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(134, 21);
            this.developer_name.TabIndex = 30;
            this.developer_name.Text = "Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.developer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Developer_name_MouseClick);
            // 
            // start_btn
            // 
            this.start_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_btn.Location = new System.Drawing.Point(80, 436);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(105, 40);
            this.start_btn.TabIndex = 32;
            this.start_btn.TabStop = false;
            this.start_btn.Text = "СТАРТ";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // show_settings
            // 
            this.show_settings.Image = global::minigames.Properties.Resources.setting_btn;
            this.show_settings.Location = new System.Drawing.Point(0, 436);
            this.show_settings.Name = "show_settings";
            this.show_settings.Size = new System.Drawing.Size(40, 40);
            this.show_settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.show_settings.TabIndex = 33;
            this.show_settings.TabStop = false;
            this.show_settings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Show_settings_MouseClick);
            this.show_settings.MouseEnter += new System.EventHandler(this.Show_settings_MouseEnter);
            this.show_settings.MouseLeave += new System.EventHandler(this.Show_settings_MouseLeave);
            // 
            // Balda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 476);
            this.Controls.Add(this.show_settings);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.by);
            this.Controls.Add(this.developer_name);
            this.Controls.Add(this.question);
            this.Controls.Add(this.left_panel);
            this.Controls.Add(this.bottom_panel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Balda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Балда";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyUp);
            this.top_panel.ResumeLayout(false);
            this.bottom_panel.ResumeLayout(false);
            this.left_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.show_settings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Timer time_timer;
        private System.Windows.Forms.Panel field_panel;
        private System.Windows.Forms.ListBox words_list;
        private System.Windows.Forms.Panel bottom_panel;
        private System.Windows.Forms.Label words_counter;
        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Panel left_panel;
        private System.Windows.Forms.Label by;
        private System.Windows.Forms.Label developer_name;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.PictureBox show_settings;
    }
}