namespace minigames.Rodrocket
{
    partial class RodRocket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RodRocket));
            this.start_btn = new System.Windows.Forms.Button();
            this.question = new System.Windows.Forms.Button();
            this.right_panel = new System.Windows.Forms.Panel();
            this.right_game_panel = new System.Windows.Forms.Panel();
            this.cursor_panel = new System.Windows.Forms.Panel();
            this.task_panel = new System.Windows.Forms.Panel();
            this.progress_panel = new System.Windows.Forms.Panel();
            this.hp_text = new System.Windows.Forms.Label();
            this.progress_refresh = new System.Windows.Forms.Timer(this.components);
            this.score_text = new System.Windows.Forms.Label();
            this.max_score_text = new System.Windows.Forms.Label();
            this.game_timer = new System.Windows.Forms.Timer(this.components);
            this.score_timer = new System.Windows.Forms.Timer(this.components);
            this.hp_timer = new System.Windows.Forms.Timer(this.components);
            this.prog_name = new System.Windows.Forms.Label();
            this.prog_name_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.developer_name = new System.Windows.Forms.Label();
            this.hp_icons = new System.Windows.Forms.ImageList(this.components);
            this.hp_pic = new System.Windows.Forms.PictureBox();
            this.up_btn = new System.Windows.Forms.Button();
            this.by_text = new System.Windows.Forms.Label();
            this.right_panel.SuspendLayout();
            this.right_game_panel.SuspendLayout();
            this.prog_name_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hp_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Location = new System.Drawing.Point(40, 176);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(82, 40);
            this.start_btn.TabIndex = 0;
            this.start_btn.TabStop = false;
            this.start_btn.Text = "СТАРТ";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // question
            // 
            this.question.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.question.Location = new System.Drawing.Point(0, 176);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 26;
            this.question.TabStop = false;
            this.question.Text = "?";
            this.question.UseVisualStyleBackColor = true;
            this.question.Click += new System.EventHandler(this.Question_Click);
            // 
            // right_panel
            // 
            this.right_panel.BackColor = System.Drawing.Color.Gainsboro;
            this.right_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.right_panel.Controls.Add(this.right_game_panel);
            this.right_panel.Controls.Add(this.progress_panel);
            this.right_panel.Location = new System.Drawing.Point(127, 0);
            this.right_panel.Name = "right_panel";
            this.right_panel.Size = new System.Drawing.Size(45, 176);
            this.right_panel.TabIndex = 27;
            // 
            // right_game_panel
            // 
            this.right_game_panel.BackColor = System.Drawing.Color.Silver;
            this.right_game_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.right_game_panel.Controls.Add(this.cursor_panel);
            this.right_game_panel.Controls.Add(this.task_panel);
            this.right_game_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.right_game_panel.Location = new System.Drawing.Point(6, 0);
            this.right_game_panel.Name = "right_game_panel";
            this.right_game_panel.Size = new System.Drawing.Size(35, 172);
            this.right_game_panel.TabIndex = 1;
            // 
            // cursor_panel
            // 
            this.cursor_panel.BackColor = System.Drawing.Color.Red;
            this.cursor_panel.Location = new System.Drawing.Point(0, 166);
            this.cursor_panel.Name = "cursor_panel";
            this.cursor_panel.Size = new System.Drawing.Size(35, 4);
            this.cursor_panel.TabIndex = 0;
            // 
            // task_panel
            // 
            this.task_panel.BackColor = System.Drawing.Color.Lime;
            this.task_panel.Location = new System.Drawing.Point(0, 105);
            this.task_panel.Name = "task_panel";
            this.task_panel.Size = new System.Drawing.Size(33, 65);
            this.task_panel.TabIndex = 1;
            // 
            // progress_panel
            // 
            this.progress_panel.BackColor = System.Drawing.Color.Lime;
            this.progress_panel.Location = new System.Drawing.Point(0, 176);
            this.progress_panel.Name = "progress_panel";
            this.progress_panel.Size = new System.Drawing.Size(6, 0);
            this.progress_panel.TabIndex = 0;
            this.progress_panel.Resize += new System.EventHandler(this.Progress_panel_Resize);
            // 
            // hp_text
            // 
            this.hp_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hp_text.Location = new System.Drawing.Point(18, 53);
            this.hp_text.Name = "hp_text";
            this.hp_text.Size = new System.Drawing.Size(36, 20);
            this.hp_text.TabIndex = 28;
            this.hp_text.Text = "100";
            this.hp_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progress_refresh
            // 
            this.progress_refresh.Interval = 10;
            this.progress_refresh.Tick += new System.EventHandler(this.Progress_Refresh_Tick);
            // 
            // score_text
            // 
            this.score_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score_text.Location = new System.Drawing.Point(0, 33);
            this.score_text.Name = "score_text";
            this.score_text.Size = new System.Drawing.Size(127, 20);
            this.score_text.TabIndex = 30;
            this.score_text.Text = "счёт: 0";
            this.score_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // max_score_text
            // 
            this.max_score_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.max_score_text.Location = new System.Drawing.Point(0, 73);
            this.max_score_text.Name = "max_score_text";
            this.max_score_text.Size = new System.Drawing.Size(127, 20);
            this.max_score_text.TabIndex = 31;
            this.max_score_text.Text = "макс. счёт: 0";
            this.max_score_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // game_timer
            // 
            this.game_timer.Interval = 1;
            this.game_timer.Tick += new System.EventHandler(this.Game_timer_Tick);
            // 
            // score_timer
            // 
            this.score_timer.Interval = 1500;
            this.score_timer.Tick += new System.EventHandler(this.Score_timer_Tick);
            // 
            // hp_timer
            // 
            this.hp_timer.Interval = 1500;
            this.hp_timer.Tick += new System.EventHandler(this.Hp_timer_Tick);
            // 
            // prog_name
            // 
            this.prog_name.BackColor = System.Drawing.SystemColors.Control;
            this.prog_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.prog_name.Location = new System.Drawing.Point(0, 0);
            this.prog_name.MaximumSize = new System.Drawing.Size(127, 30);
            this.prog_name.Name = "prog_name";
            this.prog_name.Size = new System.Drawing.Size(127, 28);
            this.prog_name.TabIndex = 35;
            this.prog_name.Text = "Удочкомёт";
            // 
            // prog_name_panel
            // 
            this.prog_name_panel.BackColor = System.Drawing.Color.DimGray;
            this.prog_name_panel.Controls.Add(this.prog_name);
            this.prog_name_panel.Location = new System.Drawing.Point(0, 0);
            this.prog_name_panel.Name = "prog_name_panel";
            this.prog_name_panel.Size = new System.Drawing.Size(127, 30);
            this.prog_name_panel.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(0, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 2);
            this.panel1.TabIndex = 37;
            // 
            // developer_name
            // 
            this.developer_name.Cursor = System.Windows.Forms.Cursors.Help;
            this.developer_name.Font = new System.Drawing.Font("Lucida Handwriting", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developer_name.Location = new System.Drawing.Point(0, 151);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(127, 22);
            this.developer_name.TabIndex = 38;
            this.developer_name.Text = "Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.developer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Developer_name_MouseClick);
            // 
            // hp_icons
            // 
            this.hp_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("hp_icons.ImageStream")));
            this.hp_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.hp_icons.Images.SetKeyName(0, "100HP.png");
            this.hp_icons.Images.SetKeyName(1, "80HP.png");
            this.hp_icons.Images.SetKeyName(2, "60HP.png");
            this.hp_icons.Images.SetKeyName(3, "40HP.png");
            this.hp_icons.Images.SetKeyName(4, "20HP.png");
            this.hp_icons.Images.SetKeyName(5, "0HP.png");
            // 
            // hp_pic
            // 
            this.hp_pic.Image = global::minigames.Properties.Resources._100HP;
            this.hp_pic.Location = new System.Drawing.Point(2, 53);
            this.hp_pic.Name = "hp_pic";
            this.hp_pic.Size = new System.Drawing.Size(20, 20);
            this.hp_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hp_pic.TabIndex = 39;
            this.hp_pic.TabStop = false;
            // 
            // up_btn
            // 
            this.up_btn.BackgroundImage = global::minigames.Properties.Resources.arrow;
            this.up_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.up_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.up_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.up_btn.Location = new System.Drawing.Point(122, 176);
            this.up_btn.Name = "up_btn";
            this.up_btn.Size = new System.Drawing.Size(50, 40);
            this.up_btn.TabIndex = 32;
            this.up_btn.TabStop = false;
            this.up_btn.UseVisualStyleBackColor = true;
            this.up_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Up_btn_MouseDown);
            this.up_btn.MouseLeave += new System.EventHandler(this.Up_btn_MouseLeave);
            this.up_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Up_btn_MouseUp);
            // 
            // by_text
            // 
            this.by_text.Cursor = System.Windows.Forms.Cursors.Default;
            this.by_text.Font = new System.Drawing.Font("Lucida Handwriting", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by_text.Location = new System.Drawing.Point(0, 129);
            this.by_text.Name = "by_text";
            this.by_text.Size = new System.Drawing.Size(127, 22);
            this.by_text.TabIndex = 40;
            this.by_text.Text = "By.";
            this.by_text.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // RodRocket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 216);
            this.Controls.Add(this.hp_pic);
            this.Controls.Add(this.by_text);
            this.Controls.Add(this.developer_name);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.prog_name_panel);
            this.Controls.Add(this.up_btn);
            this.Controls.Add(this.max_score_text);
            this.Controls.Add(this.score_text);
            this.Controls.Add(this.hp_text);
            this.Controls.Add(this.right_panel);
            this.Controls.Add(this.question);
            this.Controls.Add(this.start_btn);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "RodRocket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RodRocket_FormClosing);
            this.Load += new System.EventHandler(this.RodRocket_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RodRocket_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RodRocket_KeyUp);
            this.right_panel.ResumeLayout(false);
            this.right_game_panel.ResumeLayout(false);
            this.prog_name_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hp_pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Panel right_panel;
        private System.Windows.Forms.Label hp_text;
        private System.Windows.Forms.Panel progress_panel;
        private System.Windows.Forms.Timer progress_refresh;
        private System.Windows.Forms.Panel right_game_panel;
        private System.Windows.Forms.Label score_text;
        private System.Windows.Forms.Label max_score_text;
        private System.Windows.Forms.Panel cursor_panel;
        private System.Windows.Forms.Button up_btn;
        private System.Windows.Forms.Timer game_timer;
        private System.Windows.Forms.Panel task_panel;
        private System.Windows.Forms.Timer score_timer;
        private System.Windows.Forms.Timer hp_timer;
        private System.Windows.Forms.Label prog_name;
        private System.Windows.Forms.Panel prog_name_panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label developer_name;
        private System.Windows.Forms.PictureBox hp_pic;
        private System.Windows.Forms.ImageList hp_icons;
        private System.Windows.Forms.Label by_text;
    }
}