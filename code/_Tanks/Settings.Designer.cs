namespace minigames._Tanks
{
    partial class Settings
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
            this.controls_group = new System.Windows.Forms.GroupBox();
            this.player2_group = new System.Windows.Forms.GroupBox();
            this.task_text2 = new System.Windows.Forms.Label();
            this.clear_btn_pl2 = new System.Windows.Forms.Button();
            this.shot_btn_pl2 = new System.Windows.Forms.Button();
            this.shot_text_pl2 = new System.Windows.Forms.Label();
            this.right_btn_pl2 = new System.Windows.Forms.Button();
            this.left_btn_pl2 = new System.Windows.Forms.Button();
            this.down_btn_pl2 = new System.Windows.Forms.Button();
            this.up_btn_pl2 = new System.Windows.Forms.Button();
            this.player1_group = new System.Windows.Forms.GroupBox();
            this.task_text1 = new System.Windows.Forms.Label();
            this.clear_btn_pl1 = new System.Windows.Forms.Button();
            this.shot_btn_pl1 = new System.Windows.Forms.Button();
            this.shot_text_pl1 = new System.Windows.Forms.Label();
            this.right_btn_pl1 = new System.Windows.Forms.Button();
            this.left_btn_pl1 = new System.Windows.Forms.Button();
            this.down_btn_pl1 = new System.Windows.Forms.Button();
            this.up_btn_pl1 = new System.Windows.Forms.Button();
            this.map_text = new System.Windows.Forms.Label();
            this.map_list = new System.Windows.Forms.ComboBox();
            this.inverted = new System.Windows.Forms.TrackBar();
            this.pl1_inverted_text = new System.Windows.Forms.Label();
            this.pl2_inverted_text = new System.Windows.Forms.Label();
            this.controls_group.SuspendLayout();
            this.player2_group.SuspendLayout();
            this.player1_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inverted)).BeginInit();
            this.SuspendLayout();
            // 
            // controls_group
            // 
            this.controls_group.Controls.Add(this.player2_group);
            this.controls_group.Controls.Add(this.player1_group);
            this.controls_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.controls_group.Location = new System.Drawing.Point(12, 12);
            this.controls_group.Name = "controls_group";
            this.controls_group.Size = new System.Drawing.Size(365, 179);
            this.controls_group.TabIndex = 0;
            this.controls_group.TabStop = false;
            this.controls_group.Text = "Управление";
            // 
            // player2_group
            // 
            this.player2_group.Controls.Add(this.task_text2);
            this.player2_group.Controls.Add(this.clear_btn_pl2);
            this.player2_group.Controls.Add(this.shot_btn_pl2);
            this.player2_group.Controls.Add(this.shot_text_pl2);
            this.player2_group.Controls.Add(this.right_btn_pl2);
            this.player2_group.Controls.Add(this.left_btn_pl2);
            this.player2_group.Controls.Add(this.down_btn_pl2);
            this.player2_group.Controls.Add(this.up_btn_pl2);
            this.player2_group.Location = new System.Drawing.Point(187, 28);
            this.player2_group.Name = "player2_group";
            this.player2_group.Size = new System.Drawing.Size(175, 145);
            this.player2_group.TabIndex = 1;
            this.player2_group.TabStop = false;
            this.player2_group.Text = "Игрок 2";
            this.player2_group.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player2_group_HelpRequested);
            // 
            // task_text2
            // 
            this.task_text2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.task_text2.Location = new System.Drawing.Point(6, 28);
            this.task_text2.Name = "task_text2";
            this.task_text2.Size = new System.Drawing.Size(169, 117);
            this.task_text2.TabIndex = 14;
            this.task_text2.Text = "Нажмите любую клавишу или ESC для отмены...";
            this.task_text2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.task_text2.Visible = false;
            // 
            // clear_btn_pl2
            // 
            this.clear_btn_pl2.AutoEllipsis = true;
            this.clear_btn_pl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clear_btn_pl2.Location = new System.Drawing.Point(104, 28);
            this.clear_btn_pl2.Name = "clear_btn_pl2";
            this.clear_btn_pl2.Size = new System.Drawing.Size(65, 34);
            this.clear_btn_pl2.TabIndex = 13;
            this.clear_btn_pl2.TabStop = false;
            this.clear_btn_pl2.Text = "Сброс";
            this.clear_btn_pl2.UseVisualStyleBackColor = true;
            this.clear_btn_pl2.Click += new System.EventHandler(this.Button_Click);
            this.clear_btn_pl2.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Clear_btn_pl2_HelpRequested);
            // 
            // shot_btn_pl2
            // 
            this.shot_btn_pl2.AutoEllipsis = true;
            this.shot_btn_pl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shot_btn_pl2.Location = new System.Drawing.Point(104, 104);
            this.shot_btn_pl2.Name = "shot_btn_pl2";
            this.shot_btn_pl2.Size = new System.Drawing.Size(65, 34);
            this.shot_btn_pl2.TabIndex = 12;
            this.shot_btn_pl2.TabStop = false;
            this.shot_btn_pl2.Text = "Enter";
            this.shot_btn_pl2.UseVisualStyleBackColor = true;
            this.shot_btn_pl2.Click += new System.EventHandler(this.Button_Click);
            this.shot_btn_pl2.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player2_group_HelpRequested);
            // 
            // shot_text_pl2
            // 
            this.shot_text_pl2.AutoSize = true;
            this.shot_text_pl2.Location = new System.Drawing.Point(6, 108);
            this.shot_text_pl2.Name = "shot_text_pl2";
            this.shot_text_pl2.Size = new System.Drawing.Size(92, 24);
            this.shot_text_pl2.TabIndex = 11;
            this.shot_text_pl2.Text = "Выстрел:";
            this.shot_text_pl2.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player2_group_HelpRequested);
            // 
            // right_btn_pl2
            // 
            this.right_btn_pl2.AutoEllipsis = true;
            this.right_btn_pl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.right_btn_pl2.Location = new System.Drawing.Point(86, 67);
            this.right_btn_pl2.Name = "right_btn_pl2";
            this.right_btn_pl2.Size = new System.Drawing.Size(34, 34);
            this.right_btn_pl2.TabIndex = 10;
            this.right_btn_pl2.TabStop = false;
            this.right_btn_pl2.Text = "→";
            this.right_btn_pl2.UseVisualStyleBackColor = true;
            this.right_btn_pl2.Click += new System.EventHandler(this.Button_Click);
            this.right_btn_pl2.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player2_group_HelpRequested);
            // 
            // left_btn_pl2
            // 
            this.left_btn_pl2.AutoEllipsis = true;
            this.left_btn_pl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.left_btn_pl2.Location = new System.Drawing.Point(6, 67);
            this.left_btn_pl2.Name = "left_btn_pl2";
            this.left_btn_pl2.Size = new System.Drawing.Size(34, 34);
            this.left_btn_pl2.TabIndex = 9;
            this.left_btn_pl2.TabStop = false;
            this.left_btn_pl2.Text = "←";
            this.left_btn_pl2.UseVisualStyleBackColor = true;
            this.left_btn_pl2.Click += new System.EventHandler(this.Button_Click);
            this.left_btn_pl2.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player2_group_HelpRequested);
            // 
            // down_btn_pl2
            // 
            this.down_btn_pl2.AutoEllipsis = true;
            this.down_btn_pl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.down_btn_pl2.Location = new System.Drawing.Point(46, 67);
            this.down_btn_pl2.Name = "down_btn_pl2";
            this.down_btn_pl2.Size = new System.Drawing.Size(34, 34);
            this.down_btn_pl2.TabIndex = 8;
            this.down_btn_pl2.TabStop = false;
            this.down_btn_pl2.Text = "↓";
            this.down_btn_pl2.UseVisualStyleBackColor = true;
            this.down_btn_pl2.Click += new System.EventHandler(this.Button_Click);
            this.down_btn_pl2.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player2_group_HelpRequested);
            // 
            // up_btn_pl2
            // 
            this.up_btn_pl2.AutoEllipsis = true;
            this.up_btn_pl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.up_btn_pl2.Location = new System.Drawing.Point(46, 27);
            this.up_btn_pl2.Name = "up_btn_pl2";
            this.up_btn_pl2.Size = new System.Drawing.Size(34, 34);
            this.up_btn_pl2.TabIndex = 7;
            this.up_btn_pl2.TabStop = false;
            this.up_btn_pl2.Text = "↑";
            this.up_btn_pl2.UseVisualStyleBackColor = true;
            this.up_btn_pl2.Click += new System.EventHandler(this.Button_Click);
            this.up_btn_pl2.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player2_group_HelpRequested);
            // 
            // player1_group
            // 
            this.player1_group.Controls.Add(this.task_text1);
            this.player1_group.Controls.Add(this.clear_btn_pl1);
            this.player1_group.Controls.Add(this.shot_btn_pl1);
            this.player1_group.Controls.Add(this.shot_text_pl1);
            this.player1_group.Controls.Add(this.right_btn_pl1);
            this.player1_group.Controls.Add(this.left_btn_pl1);
            this.player1_group.Controls.Add(this.down_btn_pl1);
            this.player1_group.Controls.Add(this.up_btn_pl1);
            this.player1_group.Location = new System.Drawing.Point(6, 28);
            this.player1_group.Name = "player1_group";
            this.player1_group.Size = new System.Drawing.Size(175, 145);
            this.player1_group.TabIndex = 0;
            this.player1_group.TabStop = false;
            this.player1_group.Text = "Игрок 1";
            this.player1_group.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player1_group_HelpRequested);
            // 
            // task_text1
            // 
            this.task_text1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.task_text1.Location = new System.Drawing.Point(6, 28);
            this.task_text1.Name = "task_text1";
            this.task_text1.Size = new System.Drawing.Size(169, 117);
            this.task_text1.TabIndex = 8;
            this.task_text1.Text = "Нажмите любую клавишу или ESC для отмены...";
            this.task_text1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.task_text1.Visible = false;
            // 
            // clear_btn_pl1
            // 
            this.clear_btn_pl1.AutoEllipsis = true;
            this.clear_btn_pl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clear_btn_pl1.Location = new System.Drawing.Point(104, 28);
            this.clear_btn_pl1.Name = "clear_btn_pl1";
            this.clear_btn_pl1.Size = new System.Drawing.Size(65, 34);
            this.clear_btn_pl1.TabIndex = 7;
            this.clear_btn_pl1.TabStop = false;
            this.clear_btn_pl1.Text = "Сброс";
            this.clear_btn_pl1.UseVisualStyleBackColor = true;
            this.clear_btn_pl1.Click += new System.EventHandler(this.Button_Click);
            this.clear_btn_pl1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Clear_btn_pl1_HelpRequested);
            // 
            // shot_btn_pl1
            // 
            this.shot_btn_pl1.AutoEllipsis = true;
            this.shot_btn_pl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shot_btn_pl1.Location = new System.Drawing.Point(104, 104);
            this.shot_btn_pl1.Name = "shot_btn_pl1";
            this.shot_btn_pl1.Size = new System.Drawing.Size(65, 34);
            this.shot_btn_pl1.TabIndex = 6;
            this.shot_btn_pl1.TabStop = false;
            this.shot_btn_pl1.Text = "Space";
            this.shot_btn_pl1.UseVisualStyleBackColor = true;
            this.shot_btn_pl1.Click += new System.EventHandler(this.Button_Click);
            this.shot_btn_pl1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player1_group_HelpRequested);
            // 
            // shot_text_pl1
            // 
            this.shot_text_pl1.AutoSize = true;
            this.shot_text_pl1.Location = new System.Drawing.Point(6, 108);
            this.shot_text_pl1.Name = "shot_text_pl1";
            this.shot_text_pl1.Size = new System.Drawing.Size(92, 24);
            this.shot_text_pl1.TabIndex = 5;
            this.shot_text_pl1.Text = "Выстрел:";
            this.shot_text_pl1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player1_group_HelpRequested);
            // 
            // right_btn_pl1
            // 
            this.right_btn_pl1.AutoEllipsis = true;
            this.right_btn_pl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.right_btn_pl1.Location = new System.Drawing.Point(86, 67);
            this.right_btn_pl1.Name = "right_btn_pl1";
            this.right_btn_pl1.Size = new System.Drawing.Size(34, 34);
            this.right_btn_pl1.TabIndex = 4;
            this.right_btn_pl1.TabStop = false;
            this.right_btn_pl1.Text = "D";
            this.right_btn_pl1.UseVisualStyleBackColor = true;
            this.right_btn_pl1.Click += new System.EventHandler(this.Button_Click);
            this.right_btn_pl1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player1_group_HelpRequested);
            // 
            // left_btn_pl1
            // 
            this.left_btn_pl1.AutoEllipsis = true;
            this.left_btn_pl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.left_btn_pl1.Location = new System.Drawing.Point(6, 67);
            this.left_btn_pl1.Name = "left_btn_pl1";
            this.left_btn_pl1.Size = new System.Drawing.Size(34, 34);
            this.left_btn_pl1.TabIndex = 3;
            this.left_btn_pl1.TabStop = false;
            this.left_btn_pl1.Text = "A";
            this.left_btn_pl1.UseVisualStyleBackColor = true;
            this.left_btn_pl1.Click += new System.EventHandler(this.Button_Click);
            this.left_btn_pl1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player1_group_HelpRequested);
            // 
            // down_btn_pl1
            // 
            this.down_btn_pl1.AutoEllipsis = true;
            this.down_btn_pl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.down_btn_pl1.Location = new System.Drawing.Point(46, 67);
            this.down_btn_pl1.Name = "down_btn_pl1";
            this.down_btn_pl1.Size = new System.Drawing.Size(34, 34);
            this.down_btn_pl1.TabIndex = 2;
            this.down_btn_pl1.TabStop = false;
            this.down_btn_pl1.Text = "S";
            this.down_btn_pl1.UseVisualStyleBackColor = true;
            this.down_btn_pl1.Click += new System.EventHandler(this.Button_Click);
            this.down_btn_pl1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player1_group_HelpRequested);
            // 
            // up_btn_pl1
            // 
            this.up_btn_pl1.AutoEllipsis = true;
            this.up_btn_pl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.up_btn_pl1.Location = new System.Drawing.Point(46, 27);
            this.up_btn_pl1.Name = "up_btn_pl1";
            this.up_btn_pl1.Size = new System.Drawing.Size(34, 34);
            this.up_btn_pl1.TabIndex = 1;
            this.up_btn_pl1.TabStop = false;
            this.up_btn_pl1.Text = "W";
            this.up_btn_pl1.UseVisualStyleBackColor = true;
            this.up_btn_pl1.Click += new System.EventHandler(this.Button_Click);
            this.up_btn_pl1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Player1_group_HelpRequested);
            // 
            // map_text
            // 
            this.map_text.AutoSize = true;
            this.map_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.map_text.Location = new System.Drawing.Point(8, 201);
            this.map_text.Name = "map_text";
            this.map_text.Size = new System.Drawing.Size(68, 24);
            this.map_text.TabIndex = 6;
            this.map_text.Text = "Карта:";
            this.map_text.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Map_list_HelpRequested);
            // 
            // map_list
            // 
            this.map_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.map_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.map_list.FormattingEnabled = true;
            this.map_list.Location = new System.Drawing.Point(82, 198);
            this.map_list.Name = "map_list";
            this.map_list.Size = new System.Drawing.Size(295, 32);
            this.map_list.TabIndex = 7;
            this.map_list.SelectedIndexChanged += new System.EventHandler(this.Map_list_SelectedIndexChanged);
            this.map_list.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Map_list_HelpRequested);
            // 
            // inverted
            // 
            this.inverted.Location = new System.Drawing.Point(160, 236);
            this.inverted.Maximum = 1;
            this.inverted.Name = "inverted";
            this.inverted.Size = new System.Drawing.Size(56, 45);
            this.inverted.TabIndex = 8;
            this.inverted.TabStop = false;
            this.inverted.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.inverted.Scroll += new System.EventHandler(this.Inverted_Scroll);
            this.inverted.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Inverted_HelpRequested);
            // 
            // pl1_inverted_text
            // 
            this.pl1_inverted_text.AutoSize = true;
            this.pl1_inverted_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.pl1_inverted_text.Location = new System.Drawing.Point(56, 245);
            this.pl1_inverted_text.Name = "pl1_inverted_text";
            this.pl1_inverted_text.Size = new System.Drawing.Size(98, 24);
            this.pl1_inverted_text.TabIndex = 9;
            this.pl1_inverted_text.Text = "PLAYER 1";
            this.pl1_inverted_text.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Inverted_HelpRequested);
            // 
            // pl2_inverted_text
            // 
            this.pl2_inverted_text.AutoSize = true;
            this.pl2_inverted_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.pl2_inverted_text.Location = new System.Drawing.Point(222, 245);
            this.pl2_inverted_text.Name = "pl2_inverted_text";
            this.pl2_inverted_text.Size = new System.Drawing.Size(98, 24);
            this.pl2_inverted_text.TabIndex = 10;
            this.pl2_inverted_text.Text = "PLAYER 2";
            this.pl2_inverted_text.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Inverted_HelpRequested);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 283);
            this.Controls.Add(this.pl2_inverted_text);
            this.Controls.Add(this.pl1_inverted_text);
            this.Controls.Add(this.inverted);
            this.Controls.Add(this.map_list);
            this.Controls.Add(this.map_text);
            this.Controls.Add(this.controls_group);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Settings_KeyDown);
            this.controls_group.ResumeLayout(false);
            this.player2_group.ResumeLayout(false);
            this.player2_group.PerformLayout();
            this.player1_group.ResumeLayout(false);
            this.player1_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inverted)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox controls_group;
        private System.Windows.Forms.GroupBox player2_group;
        private System.Windows.Forms.GroupBox player1_group;
        private System.Windows.Forms.Button shot_btn_pl1;
        private System.Windows.Forms.Label shot_text_pl1;
        private System.Windows.Forms.Button right_btn_pl1;
        private System.Windows.Forms.Button left_btn_pl1;
        private System.Windows.Forms.Button down_btn_pl1;
        private System.Windows.Forms.Button up_btn_pl1;
        private System.Windows.Forms.Button shot_btn_pl2;
        private System.Windows.Forms.Label shot_text_pl2;
        private System.Windows.Forms.Button right_btn_pl2;
        private System.Windows.Forms.Button left_btn_pl2;
        private System.Windows.Forms.Button down_btn_pl2;
        private System.Windows.Forms.Button up_btn_pl2;
        private System.Windows.Forms.Button clear_btn_pl2;
        private System.Windows.Forms.Button clear_btn_pl1;
        private System.Windows.Forms.Label map_text;
        private System.Windows.Forms.ComboBox map_list;
        private System.Windows.Forms.Label task_text1;
        private System.Windows.Forms.Label task_text2;
        private System.Windows.Forms.TrackBar inverted;
        private System.Windows.Forms.Label pl1_inverted_text;
        private System.Windows.Forms.Label pl2_inverted_text;
    }
}