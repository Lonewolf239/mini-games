namespace minigames.Math_o_light
{
    partial class MathOLight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MathOLight));
            this.player_base_panel = new System.Windows.Forms.Panel();
            this.start_btn = new System.Windows.Forms.Button();
            this.question = new System.Windows.Forms.Button();
            this.by = new System.Windows.Forms.Label();
            this.developer_name = new System.Windows.Forms.Label();
            this.barrier_progressbar_background = new System.Windows.Forms.Panel();
            this.barrier_progressbar = new System.Windows.Forms.Panel();
            this.barrier_icon = new System.Windows.Forms.PictureBox();
            this.clear_btn = new System.Windows.Forms.Button();
            this.hp_progressbar_background = new System.Windows.Forms.Panel();
            this.hp_progressbar = new System.Windows.Forms.Panel();
            this.hp_icon = new System.Windows.Forms.PictureBox();
            this.Cscore_text = new System.Windows.Forms.Label();
            this.Cmath_example_text = new System.Windows.Forms.TextBox();
            this.Ckeyboard_panel = new System.Windows.Forms.Panel();
            this.Cminus_btn = new System.Windows.Forms.Button();
            this.Center_btn = new System.Windows.Forms.Button();
            this.Cbtn_0 = new System.Windows.Forms.Button();
            this.Cbtn_9 = new System.Windows.Forms.Button();
            this.Cbtn_8 = new System.Windows.Forms.Button();
            this.Cbtn_7 = new System.Windows.Forms.Button();
            this.Cbtn_6 = new System.Windows.Forms.Button();
            this.Cbtn_5 = new System.Windows.Forms.Button();
            this.Cbtn_4 = new System.Windows.Forms.Button();
            this.Cbtn_3 = new System.Windows.Forms.Button();
            this.Cbtn_2 = new System.Windows.Forms.Button();
            this.Cbtn_1 = new System.Windows.Forms.Button();
            this.progressbars_timer = new System.Windows.Forms.Timer(this.components);
            this.refresh_timer = new System.Windows.Forms.Timer(this.components);
            this.mines_timer = new System.Windows.Forms.Timer(this.components);
            this.add_mine_timer = new System.Windows.Forms.Timer(this.components);
            this.field_picture = new System.Windows.Forms.PictureBox();
            this.player_base_panel.SuspendLayout();
            this.barrier_progressbar_background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barrier_icon)).BeginInit();
            this.hp_progressbar_background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hp_icon)).BeginInit();
            this.Ckeyboard_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.field_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // player_base_panel
            // 
            this.player_base_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player_base_panel.Controls.Add(this.start_btn);
            this.player_base_panel.Controls.Add(this.question);
            this.player_base_panel.Controls.Add(this.by);
            this.player_base_panel.Controls.Add(this.developer_name);
            this.player_base_panel.Controls.Add(this.barrier_progressbar_background);
            this.player_base_panel.Controls.Add(this.barrier_icon);
            this.player_base_panel.Controls.Add(this.clear_btn);
            this.player_base_panel.Controls.Add(this.hp_progressbar_background);
            this.player_base_panel.Controls.Add(this.hp_icon);
            this.player_base_panel.Controls.Add(this.Cscore_text);
            this.player_base_panel.Controls.Add(this.Cmath_example_text);
            this.player_base_panel.Controls.Add(this.Ckeyboard_panel);
            this.player_base_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.player_base_panel.Location = new System.Drawing.Point(0, 262);
            this.player_base_panel.Margin = new System.Windows.Forms.Padding(6);
            this.player_base_panel.Name = "player_base_panel";
            this.player_base_panel.Size = new System.Drawing.Size(411, 179);
            this.player_base_panel.TabIndex = 0;
            // 
            // start_btn
            // 
            this.start_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.start_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_btn.Location = new System.Drawing.Point(40, 138);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(105, 40);
            this.start_btn.TabIndex = 44;
            this.start_btn.TabStop = false;
            this.start_btn.Text = "СТАРТ";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // question
            // 
            this.question.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.question.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.question.Location = new System.Drawing.Point(0, 138);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 43;
            this.question.TabStop = false;
            this.question.Text = "?";
            this.question.UseVisualStyleBackColor = true;
            this.question.Click += new System.EventHandler(this.Question_Click);
            // 
            // by
            // 
            this.by.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.by.Cursor = System.Windows.Forms.Cursors.Default;
            this.by.Font = new System.Drawing.Font("Lucida Handwriting", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by.Location = new System.Drawing.Point(163, 133);
            this.by.Name = "by";
            this.by.Size = new System.Drawing.Size(108, 21);
            this.by.TabIndex = 42;
            this.by.Text = "By.";
            this.by.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // developer_name
            // 
            this.developer_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.developer_name.AutoSize = true;
            this.developer_name.Cursor = System.Windows.Forms.Cursors.Help;
            this.developer_name.Font = new System.Drawing.Font("Lucida Handwriting", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developer_name.Location = new System.Drawing.Point(160, 154);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(111, 17);
            this.developer_name.TabIndex = 41;
            this.developer_name.Text = "Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // barrier_progressbar_background
            // 
            this.barrier_progressbar_background.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.barrier_progressbar_background.Controls.Add(this.barrier_progressbar);
            this.barrier_progressbar_background.Location = new System.Drawing.Point(47, 111);
            this.barrier_progressbar_background.Name = "barrier_progressbar_background";
            this.barrier_progressbar_background.Size = new System.Drawing.Size(179, 7);
            this.barrier_progressbar_background.TabIndex = 7;
            // 
            // barrier_progressbar
            // 
            this.barrier_progressbar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.barrier_progressbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.barrier_progressbar.Location = new System.Drawing.Point(0, 0);
            this.barrier_progressbar.Name = "barrier_progressbar";
            this.barrier_progressbar.Size = new System.Drawing.Size(50, 3);
            this.barrier_progressbar.TabIndex = 0;
            // 
            // barrier_icon
            // 
            this.barrier_icon.Image = global::minigames.Properties.Resources.math_mana;
            this.barrier_icon.Location = new System.Drawing.Point(11, 100);
            this.barrier_icon.Name = "barrier_icon";
            this.barrier_icon.Size = new System.Drawing.Size(30, 30);
            this.barrier_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.barrier_icon.TabIndex = 6;
            this.barrier_icon.TabStop = false;
            // 
            // clear_btn
            // 
            this.clear_btn.BackgroundImage = global::minigames.Properties.Resources.clear;
            this.clear_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clear_btn.Location = new System.Drawing.Point(236, 37);
            this.clear_btn.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(35, 29);
            this.clear_btn.TabIndex = 5;
            this.clear_btn.TabStop = false;
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // hp_progressbar_background
            // 
            this.hp_progressbar_background.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hp_progressbar_background.Controls.Add(this.hp_progressbar);
            this.hp_progressbar_background.Location = new System.Drawing.Point(47, 75);
            this.hp_progressbar_background.Name = "hp_progressbar_background";
            this.hp_progressbar_background.Size = new System.Drawing.Size(179, 7);
            this.hp_progressbar_background.TabIndex = 4;
            // 
            // hp_progressbar
            // 
            this.hp_progressbar.BackColor = System.Drawing.Color.Tomato;
            this.hp_progressbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.hp_progressbar.Location = new System.Drawing.Point(0, 0);
            this.hp_progressbar.Name = "hp_progressbar";
            this.hp_progressbar.Size = new System.Drawing.Size(50, 3);
            this.hp_progressbar.TabIndex = 0;
            // 
            // hp_icon
            // 
            this.hp_icon.Image = global::minigames.Properties.Resources.math_hp;
            this.hp_icon.Location = new System.Drawing.Point(11, 64);
            this.hp_icon.Name = "hp_icon";
            this.hp_icon.Size = new System.Drawing.Size(30, 30);
            this.hp_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hp_icon.TabIndex = 3;
            this.hp_icon.TabStop = false;
            // 
            // Cscore_text
            // 
            this.Cscore_text.AutoEllipsis = true;
            this.Cscore_text.Location = new System.Drawing.Point(7, 37);
            this.Cscore_text.Name = "Cscore_text";
            this.Cscore_text.Size = new System.Drawing.Size(221, 24);
            this.Cscore_text.TabIndex = 2;
            this.Cscore_text.Text = "макс счёт: 0";
            // 
            // Cmath_example_text
            // 
            this.Cmath_example_text.BackColor = System.Drawing.Color.Gainsboro;
            this.Cmath_example_text.Cursor = System.Windows.Forms.Cursors.Default;
            this.Cmath_example_text.Location = new System.Drawing.Point(11, 5);
            this.Cmath_example_text.MaxLength = 22;
            this.Cmath_example_text.Name = "Cmath_example_text";
            this.Cmath_example_text.ReadOnly = true;
            this.Cmath_example_text.Size = new System.Drawing.Size(260, 29);
            this.Cmath_example_text.TabIndex = 1;
            this.Cmath_example_text.TabStop = false;
            this.Cmath_example_text.Enter += new System.EventHandler(this.Math_example_text_Enter);
            // 
            // Ckeyboard_panel
            // 
            this.Ckeyboard_panel.BackColor = System.Drawing.Color.Gainsboro;
            this.Ckeyboard_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ckeyboard_panel.Controls.Add(this.Cminus_btn);
            this.Ckeyboard_panel.Controls.Add(this.Center_btn);
            this.Ckeyboard_panel.Controls.Add(this.Cbtn_0);
            this.Ckeyboard_panel.Controls.Add(this.Cbtn_9);
            this.Ckeyboard_panel.Controls.Add(this.Cbtn_8);
            this.Ckeyboard_panel.Controls.Add(this.Cbtn_7);
            this.Ckeyboard_panel.Controls.Add(this.Cbtn_6);
            this.Ckeyboard_panel.Controls.Add(this.Cbtn_5);
            this.Ckeyboard_panel.Controls.Add(this.Cbtn_4);
            this.Ckeyboard_panel.Controls.Add(this.Cbtn_3);
            this.Ckeyboard_panel.Controls.Add(this.Cbtn_2);
            this.Ckeyboard_panel.Controls.Add(this.Cbtn_1);
            this.Ckeyboard_panel.Location = new System.Drawing.Point(279, 5);
            this.Ckeyboard_panel.Margin = new System.Windows.Forms.Padding(5);
            this.Ckeyboard_panel.Name = "Ckeyboard_panel";
            this.Ckeyboard_panel.Size = new System.Drawing.Size(125, 167);
            this.Ckeyboard_panel.TabIndex = 0;
            // 
            // Cminus_btn
            // 
            this.Cminus_btn.AutoSize = true;
            this.Cminus_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Cminus_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cminus_btn.Location = new System.Drawing.Point(45, 125);
            this.Cminus_btn.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Cminus_btn.Name = "Cminus_btn";
            this.Cminus_btn.Size = new System.Drawing.Size(34, 34);
            this.Cminus_btn.TabIndex = 11;
            this.Cminus_btn.TabStop = false;
            this.Cminus_btn.Text = "-";
            this.Cminus_btn.UseVisualStyleBackColor = false;
            this.Cminus_btn.Click += new System.EventHandler(this.Minus_btn_Click);
            // 
            // Center_btn
            // 
            this.Center_btn.AutoSize = true;
            this.Center_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Center_btn.BackgroundImage = global::minigames.Properties.Resources.enter;
            this.Center_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Center_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Center_btn.Location = new System.Drawing.Point(85, 125);
            this.Center_btn.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Center_btn.Name = "Center_btn";
            this.Center_btn.Size = new System.Drawing.Size(34, 34);
            this.Center_btn.TabIndex = 10;
            this.Center_btn.TabStop = false;
            this.Center_btn.UseVisualStyleBackColor = false;
            this.Center_btn.Click += new System.EventHandler(this.Enter_btn_Click);
            // 
            // Cbtn_0
            // 
            this.Cbtn_0.AutoSize = true;
            this.Cbtn_0.BackColor = System.Drawing.SystemColors.Control;
            this.Cbtn_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cbtn_0.Location = new System.Drawing.Point(5, 125);
            this.Cbtn_0.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Cbtn_0.Name = "Cbtn_0";
            this.Cbtn_0.Size = new System.Drawing.Size(34, 34);
            this.Cbtn_0.TabIndex = 9;
            this.Cbtn_0.TabStop = false;
            this.Cbtn_0.Text = "0";
            this.Cbtn_0.UseVisualStyleBackColor = false;
            this.Cbtn_0.Click += new System.EventHandler(this.KeyboardButton_Click);
            // 
            // Cbtn_9
            // 
            this.Cbtn_9.AutoSize = true;
            this.Cbtn_9.BackColor = System.Drawing.SystemColors.Control;
            this.Cbtn_9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cbtn_9.Location = new System.Drawing.Point(85, 85);
            this.Cbtn_9.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Cbtn_9.Name = "Cbtn_9";
            this.Cbtn_9.Size = new System.Drawing.Size(34, 34);
            this.Cbtn_9.TabIndex = 8;
            this.Cbtn_9.TabStop = false;
            this.Cbtn_9.Text = "9";
            this.Cbtn_9.UseVisualStyleBackColor = false;
            this.Cbtn_9.Click += new System.EventHandler(this.KeyboardButton_Click);
            // 
            // Cbtn_8
            // 
            this.Cbtn_8.AutoSize = true;
            this.Cbtn_8.BackColor = System.Drawing.SystemColors.Control;
            this.Cbtn_8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cbtn_8.Location = new System.Drawing.Point(45, 85);
            this.Cbtn_8.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Cbtn_8.Name = "Cbtn_8";
            this.Cbtn_8.Size = new System.Drawing.Size(34, 34);
            this.Cbtn_8.TabIndex = 7;
            this.Cbtn_8.TabStop = false;
            this.Cbtn_8.Text = "8";
            this.Cbtn_8.UseVisualStyleBackColor = false;
            this.Cbtn_8.Click += new System.EventHandler(this.KeyboardButton_Click);
            // 
            // Cbtn_7
            // 
            this.Cbtn_7.AutoSize = true;
            this.Cbtn_7.BackColor = System.Drawing.SystemColors.Control;
            this.Cbtn_7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cbtn_7.Location = new System.Drawing.Point(5, 85);
            this.Cbtn_7.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Cbtn_7.Name = "Cbtn_7";
            this.Cbtn_7.Size = new System.Drawing.Size(34, 34);
            this.Cbtn_7.TabIndex = 6;
            this.Cbtn_7.TabStop = false;
            this.Cbtn_7.Text = "7";
            this.Cbtn_7.UseVisualStyleBackColor = false;
            this.Cbtn_7.Click += new System.EventHandler(this.KeyboardButton_Click);
            // 
            // Cbtn_6
            // 
            this.Cbtn_6.AutoSize = true;
            this.Cbtn_6.BackColor = System.Drawing.SystemColors.Control;
            this.Cbtn_6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cbtn_6.Location = new System.Drawing.Point(85, 45);
            this.Cbtn_6.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Cbtn_6.Name = "Cbtn_6";
            this.Cbtn_6.Size = new System.Drawing.Size(34, 34);
            this.Cbtn_6.TabIndex = 5;
            this.Cbtn_6.TabStop = false;
            this.Cbtn_6.Text = "6";
            this.Cbtn_6.UseVisualStyleBackColor = false;
            this.Cbtn_6.Click += new System.EventHandler(this.KeyboardButton_Click);
            // 
            // Cbtn_5
            // 
            this.Cbtn_5.AutoSize = true;
            this.Cbtn_5.BackColor = System.Drawing.SystemColors.Control;
            this.Cbtn_5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cbtn_5.Location = new System.Drawing.Point(45, 45);
            this.Cbtn_5.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Cbtn_5.Name = "Cbtn_5";
            this.Cbtn_5.Size = new System.Drawing.Size(34, 34);
            this.Cbtn_5.TabIndex = 4;
            this.Cbtn_5.TabStop = false;
            this.Cbtn_5.Text = "5";
            this.Cbtn_5.UseVisualStyleBackColor = false;
            this.Cbtn_5.Click += new System.EventHandler(this.KeyboardButton_Click);
            // 
            // Cbtn_4
            // 
            this.Cbtn_4.AutoSize = true;
            this.Cbtn_4.BackColor = System.Drawing.SystemColors.Control;
            this.Cbtn_4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cbtn_4.Location = new System.Drawing.Point(5, 45);
            this.Cbtn_4.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Cbtn_4.Name = "Cbtn_4";
            this.Cbtn_4.Size = new System.Drawing.Size(34, 34);
            this.Cbtn_4.TabIndex = 3;
            this.Cbtn_4.TabStop = false;
            this.Cbtn_4.Text = "4";
            this.Cbtn_4.UseVisualStyleBackColor = false;
            this.Cbtn_4.Click += new System.EventHandler(this.KeyboardButton_Click);
            // 
            // Cbtn_3
            // 
            this.Cbtn_3.AutoSize = true;
            this.Cbtn_3.BackColor = System.Drawing.SystemColors.Control;
            this.Cbtn_3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cbtn_3.Location = new System.Drawing.Point(85, 5);
            this.Cbtn_3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 3);
            this.Cbtn_3.Name = "Cbtn_3";
            this.Cbtn_3.Size = new System.Drawing.Size(34, 34);
            this.Cbtn_3.TabIndex = 2;
            this.Cbtn_3.TabStop = false;
            this.Cbtn_3.Text = "3";
            this.Cbtn_3.UseVisualStyleBackColor = false;
            this.Cbtn_3.Click += new System.EventHandler(this.KeyboardButton_Click);
            // 
            // Cbtn_2
            // 
            this.Cbtn_2.AutoSize = true;
            this.Cbtn_2.BackColor = System.Drawing.SystemColors.Control;
            this.Cbtn_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cbtn_2.Location = new System.Drawing.Point(45, 5);
            this.Cbtn_2.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Cbtn_2.Name = "Cbtn_2";
            this.Cbtn_2.Size = new System.Drawing.Size(34, 34);
            this.Cbtn_2.TabIndex = 1;
            this.Cbtn_2.TabStop = false;
            this.Cbtn_2.Text = "2";
            this.Cbtn_2.UseVisualStyleBackColor = false;
            this.Cbtn_2.Click += new System.EventHandler(this.KeyboardButton_Click);
            // 
            // Cbtn_1
            // 
            this.Cbtn_1.AutoSize = true;
            this.Cbtn_1.BackColor = System.Drawing.SystemColors.Control;
            this.Cbtn_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cbtn_1.Location = new System.Drawing.Point(5, 5);
            this.Cbtn_1.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Cbtn_1.Name = "Cbtn_1";
            this.Cbtn_1.Size = new System.Drawing.Size(34, 34);
            this.Cbtn_1.TabIndex = 0;
            this.Cbtn_1.TabStop = false;
            this.Cbtn_1.Text = "1";
            this.Cbtn_1.UseVisualStyleBackColor = false;
            this.Cbtn_1.Click += new System.EventHandler(this.KeyboardButton_Click);
            // 
            // progressbars_timer
            // 
            this.progressbars_timer.Enabled = true;
            this.progressbars_timer.Interval = 1;
            this.progressbars_timer.Tick += new System.EventHandler(this.Progressbar_timer_Tick);
            // 
            // refresh_timer
            // 
            this.refresh_timer.Interval = 1;
            this.refresh_timer.Tick += new System.EventHandler(this.Refresh_timer_Tick);
            // 
            // mines_timer
            // 
            this.mines_timer.Interval = 250;
            this.mines_timer.Tick += new System.EventHandler(this.Mines_timer_Tick);
            // 
            // add_mine_timer
            // 
            this.add_mine_timer.Interval = 1500;
            this.add_mine_timer.Tick += new System.EventHandler(this.Add_mine_timer_Tick);
            // 
            // field_picture
            // 
            this.field_picture.BackColor = System.Drawing.Color.Gainsboro;
            this.field_picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.field_picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.field_picture.Location = new System.Drawing.Point(0, 0);
            this.field_picture.Name = "field_picture";
            this.field_picture.Size = new System.Drawing.Size(411, 262);
            this.field_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.field_picture.TabIndex = 1;
            this.field_picture.TabStop = false;
            // 
            // MathOLight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 441);
            this.Controls.Add(this.field_picture);
            this.Controls.Add(this.player_base_panel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MathOLight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Матемангнит";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.player_base_panel.ResumeLayout(false);
            this.player_base_panel.PerformLayout();
            this.barrier_progressbar_background.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barrier_icon)).EndInit();
            this.hp_progressbar_background.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hp_icon)).EndInit();
            this.Ckeyboard_panel.ResumeLayout(false);
            this.Ckeyboard_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.field_picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel player_base_panel;
        private System.Windows.Forms.Panel Ckeyboard_panel;
        private System.Windows.Forms.Button Cbtn_1;
        private System.Windows.Forms.Button Center_btn;
        private System.Windows.Forms.Button Cbtn_0;
        private System.Windows.Forms.Button Cbtn_9;
        private System.Windows.Forms.Button Cbtn_8;
        private System.Windows.Forms.Button Cbtn_7;
        private System.Windows.Forms.Button Cbtn_6;
        private System.Windows.Forms.Button Cbtn_5;
        private System.Windows.Forms.Button Cbtn_4;
        private System.Windows.Forms.Button Cbtn_3;
        private System.Windows.Forms.Button Cbtn_2;
        private System.Windows.Forms.TextBox Cmath_example_text;
        private System.Windows.Forms.PictureBox hp_icon;
        private System.Windows.Forms.Label Cscore_text;
        private System.Windows.Forms.Panel hp_progressbar_background;
        private System.Windows.Forms.Panel hp_progressbar;
        private System.Windows.Forms.Timer progressbars_timer;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.PictureBox field_picture;
        private System.Windows.Forms.Timer mines_timer;
        private System.Windows.Forms.Timer add_mine_timer;
        private System.Windows.Forms.Panel barrier_progressbar_background;
        private System.Windows.Forms.Panel barrier_progressbar;
        private System.Windows.Forms.PictureBox barrier_icon;
        private System.Windows.Forms.Button Cminus_btn;
        private System.Windows.Forms.Timer refresh_timer;
        private System.Windows.Forms.Label developer_name;
        private System.Windows.Forms.Label by;
        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Button start_btn;
    }
}

