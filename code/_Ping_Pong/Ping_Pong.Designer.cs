namespace minigames._Ping_Pong
{
    partial class Ping_Pong
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ping_Pong));
            this.developer_name = new System.Windows.Forms.Label();
            this.question = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.top_panel = new System.Windows.Forms.Panel();
            this.pause_text = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.Panel();
            this.separator = new System.Windows.Forms.Panel();
            this.player_1 = new System.Windows.Forms.Panel();
            this.player_0 = new System.Windows.Forms.Panel();
            this.player_0_timer = new System.Windows.Forms.Timer(this.components);
            this.player_1_timer = new System.Windows.Forms.Timer(this.components);
            this.ball_timer = new System.Windows.Forms.Timer(this.components);
            this.top_background = new System.Windows.Forms.Panel();
            this.speed_panel = new System.Windows.Forms.Panel();
            this.speed_progress = new System.Windows.Forms.Panel();
            this.pl1_score_text = new System.Windows.Forms.Label();
            this.pl0_score_text = new System.Windows.Forms.Label();
            this.color_timer = new System.Windows.Forms.Timer(this.components);
            this.finish_input = new System.Windows.Forms.NumericUpDown();
            this.finish_text = new System.Windows.Forms.Label();
            this.top_panel.SuspendLayout();
            this.top_background.SuspendLayout();
            this.speed_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finish_input)).BeginInit();
            this.SuspendLayout();
            // 
            // developer_name
            // 
            this.developer_name.AutoSize = true;
            this.developer_name.Cursor = System.Windows.Forms.Cursors.Help;
            this.developer_name.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developer_name.Location = new System.Drawing.Point(173, 198);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(163, 21);
            this.developer_name.TabIndex = 28;
            this.developer_name.Text = "By.Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.developer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Developer_name_MouseClick);
            // 
            // question
            // 
            this.question.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.question.Location = new System.Drawing.Point(0, 179);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 27;
            this.question.TabStop = false;
            this.question.Text = "?";
            this.question.UseVisualStyleBackColor = true;
            this.question.Click += new System.EventHandler(this.Question_Click);
            // 
            // start_btn
            // 
            this.start_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_btn.Location = new System.Drawing.Point(40, 179);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(105, 40);
            this.start_btn.TabIndex = 26;
            this.start_btn.TabStop = false;
            this.start_btn.Text = "СТАРТ";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.top_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.top_panel.Controls.Add(this.pause_text);
            this.top_panel.Controls.Add(this.ball);
            this.top_panel.Controls.Add(this.separator);
            this.top_panel.Controls.Add(this.player_1);
            this.top_panel.Controls.Add(this.player_0);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(330, 140);
            this.top_panel.TabIndex = 29;
            // 
            // pause_text
            // 
            this.pause_text.AutoSize = true;
            this.pause_text.BackColor = System.Drawing.Color.Transparent;
            this.pause_text.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pause_text.ForeColor = System.Drawing.Color.White;
            this.pause_text.Location = new System.Drawing.Point(100, 54);
            this.pause_text.Name = "pause_text";
            this.pause_text.Size = new System.Drawing.Size(89, 32);
            this.pause_text.TabIndex = 3;
            this.pause_text.Text = "PAUSE";
            this.pause_text.Visible = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.White;
            this.ball.Location = new System.Drawing.Point(157, 40);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(10, 10);
            this.ball.TabIndex = 2;
            // 
            // separator
            // 
            this.separator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(75)))));
            this.separator.Location = new System.Drawing.Point(212, 0);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(2, 140);
            this.separator.TabIndex = 4;
            // 
            // player_1
            // 
            this.player_1.BackColor = System.Drawing.Color.Gainsboro;
            this.player_1.Location = new System.Drawing.Point(317, 0);
            this.player_1.Name = "player_1";
            this.player_1.Size = new System.Drawing.Size(5, 50);
            this.player_1.TabIndex = 1;
            // 
            // player_0
            // 
            this.player_0.BackColor = System.Drawing.Color.Gainsboro;
            this.player_0.Location = new System.Drawing.Point(8, 0);
            this.player_0.Name = "player_0";
            this.player_0.Size = new System.Drawing.Size(5, 50);
            this.player_0.TabIndex = 0;
            // 
            // player_0_timer
            // 
            this.player_0_timer.Interval = 18;
            this.player_0_timer.Tick += new System.EventHandler(this.Player_0_timer_Tick);
            // 
            // player_1_timer
            // 
            this.player_1_timer.Interval = 18;
            this.player_1_timer.Tick += new System.EventHandler(this.Player_1_timer_Tick);
            // 
            // ball_timer
            // 
            this.ball_timer.Interval = 25;
            this.ball_timer.Tick += new System.EventHandler(this.Ball_timer_Tick);
            // 
            // top_background
            // 
            this.top_background.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.top_background.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.top_background.Controls.Add(this.speed_panel);
            this.top_background.Controls.Add(this.pl1_score_text);
            this.top_background.Controls.Add(this.pl0_score_text);
            this.top_background.Controls.Add(this.top_panel);
            this.top_background.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_background.Location = new System.Drawing.Point(0, 0);
            this.top_background.Name = "top_background";
            this.top_background.Size = new System.Drawing.Size(334, 173);
            this.top_background.TabIndex = 30;
            // 
            // speed_panel
            // 
            this.speed_panel.Controls.Add(this.speed_progress);
            this.speed_panel.Location = new System.Drawing.Point(0, 162);
            this.speed_panel.Name = "speed_panel";
            this.speed_panel.Size = new System.Drawing.Size(330, 6);
            this.speed_panel.TabIndex = 32;
            // 
            // speed_progress
            // 
            this.speed_progress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.speed_progress.Dock = System.Windows.Forms.DockStyle.Left;
            this.speed_progress.Location = new System.Drawing.Point(0, 0);
            this.speed_progress.Name = "speed_progress";
            this.speed_progress.Size = new System.Drawing.Size(0, 6);
            this.speed_progress.TabIndex = 0;
            // 
            // pl1_score_text
            // 
            this.pl1_score_text.AutoSize = true;
            this.pl1_score_text.Dock = System.Windows.Forms.DockStyle.Right;
            this.pl1_score_text.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pl1_score_text.ForeColor = System.Drawing.Color.White;
            this.pl1_score_text.Location = new System.Drawing.Point(213, 140);
            this.pl1_score_text.Name = "pl1_score_text";
            this.pl1_score_text.Size = new System.Drawing.Size(117, 19);
            this.pl1_score_text.TabIndex = 31;
            this.pl1_score_text.Text = "PL2 score: 0";
            // 
            // pl0_score_text
            // 
            this.pl0_score_text.AutoSize = true;
            this.pl0_score_text.Dock = System.Windows.Forms.DockStyle.Left;
            this.pl0_score_text.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pl0_score_text.ForeColor = System.Drawing.Color.White;
            this.pl0_score_text.Location = new System.Drawing.Point(0, 140);
            this.pl0_score_text.Name = "pl0_score_text";
            this.pl0_score_text.Size = new System.Drawing.Size(117, 19);
            this.pl0_score_text.TabIndex = 30;
            this.pl0_score_text.Text = "PL1 score: 0";
            // 
            // color_timer
            // 
            this.color_timer.Interval = 750;
            this.color_timer.Tick += new System.EventHandler(this.Color_timer_Tick);
            // 
            // finish_input
            // 
            this.finish_input.Location = new System.Drawing.Point(287, 175);
            this.finish_input.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.finish_input.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.finish_input.Name = "finish_input";
            this.finish_input.Size = new System.Drawing.Size(45, 20);
            this.finish_input.TabIndex = 31;
            this.finish_input.TabStop = false;
            this.finish_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.finish_input.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // finish_text
            // 
            this.finish_text.AutoSize = true;
            this.finish_text.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.finish_text.Location = new System.Drawing.Point(182, 173);
            this.finish_text.Name = "finish_text";
            this.finish_text.Size = new System.Drawing.Size(99, 19);
            this.finish_text.TabIndex = 32;
            this.finish_text.Text = "Играть до:";
            // 
            // Ping_Pong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 219);
            this.Controls.Add(this.finish_text);
            this.Controls.Add(this.finish_input);
            this.Controls.Add(this.top_background);
            this.Controls.Add(this.developer_name);
            this.Controls.Add(this.question);
            this.Controls.Add(this.start_btn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Ping_Pong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пинг-Понг";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ping_Pong_FormClosing);
            this.Load += new System.EventHandler(this.Ping_Pong_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ping_Pong_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Ping_Pong_KeyUp);
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            this.top_background.ResumeLayout(false);
            this.top_background.PerformLayout();
            this.speed_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.finish_input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label developer_name;
        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Panel player_0;
        private System.Windows.Forms.Panel player_1;
        private System.Windows.Forms.Timer player_0_timer;
        private System.Windows.Forms.Timer player_1_timer;
        private System.Windows.Forms.Panel ball;
        private System.Windows.Forms.Timer ball_timer;
        private System.Windows.Forms.Panel top_background;
        private System.Windows.Forms.Label pl0_score_text;
        private System.Windows.Forms.Label pl1_score_text;
        private System.Windows.Forms.Timer color_timer;
        private System.Windows.Forms.Label pause_text;
        private System.Windows.Forms.Panel speed_panel;
        private System.Windows.Forms.Panel speed_progress;
        private System.Windows.Forms.NumericUpDown finish_input;
        private System.Windows.Forms.Label finish_text;
        private System.Windows.Forms.Panel separator;
    }
}