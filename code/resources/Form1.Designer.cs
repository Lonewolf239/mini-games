namespace minigames
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
            this.top_panel = new System.Windows.Forms.Panel();
            this.finish2_panel = new System.Windows.Forms.Panel();
            this.progress_panel = new System.Windows.Forms.Panel();
            this.hide_panel = new System.Windows.Forms.Panel();
            this.finish_panel = new System.Windows.Forms.Panel();
            this.start_btn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.show_settings = new System.Windows.Forms.PictureBox();
            this.developer_name = new System.Windows.Forms.Label();
            this.question = new System.Windows.Forms.Button();
            this.lose_text = new System.Windows.Forms.Label();
            this.games_text = new System.Windows.Forms.Label();
            this.accurate = new System.Windows.Forms.Label();
            this.top_panel.SuspendLayout();
            this.hide_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_settings)).BeginInit();
            this.SuspendLayout();
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.top_panel.Controls.Add(this.finish2_panel);
            this.top_panel.Controls.Add(this.progress_panel);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(409, 50);
            this.top_panel.TabIndex = 0;
            // 
            // finish2_panel
            // 
            this.finish2_panel.BackColor = System.Drawing.Color.Red;
            this.finish2_panel.Location = new System.Drawing.Point(50, 0);
            this.finish2_panel.Name = "finish2_panel";
            this.finish2_panel.Size = new System.Drawing.Size(10, 50);
            this.finish2_panel.TabIndex = 3;
            this.finish2_panel.Visible = false;
            // 
            // progress_panel
            // 
            this.progress_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.progress_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.progress_panel.Location = new System.Drawing.Point(0, 0);
            this.progress_panel.Name = "progress_panel";
            this.progress_panel.Size = new System.Drawing.Size(0, 50);
            this.progress_panel.TabIndex = 0;
            // 
            // hide_panel
            // 
            this.hide_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.hide_panel.Controls.Add(this.finish_panel);
            this.hide_panel.Location = new System.Drawing.Point(90, 0);
            this.hide_panel.Name = "hide_panel";
            this.hide_panel.Size = new System.Drawing.Size(319, 50);
            this.hide_panel.TabIndex = 1;
            this.hide_panel.Visible = false;
            this.hide_panel.VisibleChanged += new System.EventHandler(this.Hide_panel_VisibleChanged);
            // 
            // finish_panel
            // 
            this.finish_panel.BackColor = System.Drawing.Color.Red;
            this.finish_panel.Location = new System.Drawing.Point(109, 0);
            this.finish_panel.Name = "finish_panel";
            this.finish_panel.Size = new System.Drawing.Size(10, 50);
            this.finish_panel.TabIndex = 0;
            // 
            // start_btn
            // 
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_btn.Location = new System.Drawing.Point(80, 92);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(105, 40);
            this.start_btn.TabIndex = 2;
            this.start_btn.TabStop = false;
            this.start_btn.Text = "START";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // show_settings
            // 
            this.show_settings.Image = global::minigames.Properties.Resources.icon2;
            this.show_settings.Location = new System.Drawing.Point(0, 92);
            this.show_settings.Name = "show_settings";
            this.show_settings.Size = new System.Drawing.Size(40, 40);
            this.show_settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.show_settings.TabIndex = 4;
            this.show_settings.TabStop = false;
            this.show_settings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Show_settings_MouseClick);
            this.show_settings.MouseEnter += new System.EventHandler(this.Show_settings_MouseEnter);
            this.show_settings.MouseLeave += new System.EventHandler(this.Show_settings_MouseLeave);
            // 
            // developer_name
            // 
            this.developer_name.AutoSize = true;
            this.developer_name.Cursor = System.Windows.Forms.Cursors.Help;
            this.developer_name.Font = new System.Drawing.Font("Lucida Handwriting", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developer_name.Location = new System.Drawing.Point(215, 105);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(194, 27);
            this.developer_name.TabIndex = 6;
            this.developer_name.Text = "By.Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.developer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Developer_name_MouseClick);
            // 
            // question
            // 
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.question.Location = new System.Drawing.Point(40, 92);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 7;
            this.question.TabStop = false;
            this.question.Text = "?";
            this.question.UseVisualStyleBackColor = true;
            this.question.Click += new System.EventHandler(this.Question_Click);
            // 
            // lose_text
            // 
            this.lose_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lose_text.Location = new System.Drawing.Point(173, 53);
            this.lose_text.Name = "lose_text";
            this.lose_text.Size = new System.Drawing.Size(236, 24);
            this.lose_text.TabIndex = 2;
            this.lose_text.Text = "Вы проиграли 0 раз";
            this.lose_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // games_text
            // 
            this.games_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.games_text.Location = new System.Drawing.Point(3, 53);
            this.games_text.Name = "games_text";
            this.games_text.Size = new System.Drawing.Size(164, 24);
            this.games_text.TabIndex = 3;
            this.games_text.Text = "Выигрыш 0%";
            this.games_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // accurate
            // 
            this.accurate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.accurate.Location = new System.Drawing.Point(191, 77);
            this.accurate.Name = "accurate";
            this.accurate.Size = new System.Drawing.Size(218, 24);
            this.accurate.TabIndex = 8;
            this.accurate.Text = "Точность 0px";
            this.accurate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 132);
            this.Controls.Add(this.accurate);
            this.Controls.Add(this.games_text);
            this.Controls.Add(this.question);
            this.Controls.Add(this.lose_text);
            this.Controls.Add(this.developer_name);
            this.Controls.Add(this.show_settings);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.hide_panel);
            this.Controls.Add(this.top_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Глазастик";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.top_panel.ResumeLayout(false);
            this.hide_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.show_settings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Panel progress_panel;
        private System.Windows.Forms.Panel hide_panel;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel finish_panel;
        private System.Windows.Forms.Panel finish2_panel;
        private System.Windows.Forms.PictureBox show_settings;
        private System.Windows.Forms.Label developer_name;
        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Label lose_text;
        private System.Windows.Forms.Label games_text;
        private System.Windows.Forms.Label accurate;
    }
}

