namespace minigames._Tetris
{
    partial class Tetris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tetris));
            this.top_panel = new System.Windows.Forms.Panel();
            this.game_over_text = new System.Windows.Forms.Label();
            this.next_figure_panel = new System.Windows.Forms.Panel();
            this.next_figure_picture = new System.Windows.Forms.PictureBox();
            this.next_figure_text = new System.Windows.Forms.Label();
            this.score_text = new System.Windows.Forms.Label();
            this.game_interface = new System.Windows.Forms.Panel();
            this.question = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.by = new System.Windows.Forms.Label();
            this.developer_name = new System.Windows.Forms.Label();
            this.refresh_timer = new System.Windows.Forms.Timer(this.components);
            this.logic_timer = new System.Windows.Forms.Timer(this.components);
            this.falling_tiles_timer = new System.Windows.Forms.Timer(this.components);
            this.move_tiles = new System.Windows.Forms.Timer(this.components);
            this.top_panel.SuspendLayout();
            this.next_figure_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.next_figure_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.top_panel.Controls.Add(this.game_over_text);
            this.top_panel.Controls.Add(this.next_figure_panel);
            this.top_panel.Controls.Add(this.next_figure_text);
            this.top_panel.Controls.Add(this.score_text);
            this.top_panel.Controls.Add(this.game_interface);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.top_panel.ForeColor = System.Drawing.Color.White;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(288, 324);
            this.top_panel.TabIndex = 0;
            // 
            // game_over_text
            // 
            this.game_over_text.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.game_over_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.game_over_text.Location = new System.Drawing.Point(0, 185);
            this.game_over_text.Name = "game_over_text";
            this.game_over_text.Size = new System.Drawing.Size(124, 139);
            this.game_over_text.TabIndex = 4;
            this.game_over_text.Text = "GAME\r\nOVER";
            this.game_over_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.game_over_text.Visible = false;
            // 
            // next_figure_panel
            // 
            this.next_figure_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.next_figure_panel.Controls.Add(this.next_figure_picture);
            this.next_figure_panel.Location = new System.Drawing.Point(24, 108);
            this.next_figure_panel.Name = "next_figure_panel";
            this.next_figure_panel.Size = new System.Drawing.Size(75, 75);
            this.next_figure_panel.TabIndex = 3;
            // 
            // next_figure_picture
            // 
            this.next_figure_picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.next_figure_picture.Location = new System.Drawing.Point(0, 0);
            this.next_figure_picture.Name = "next_figure_picture";
            this.next_figure_picture.Size = new System.Drawing.Size(73, 73);
            this.next_figure_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.next_figure_picture.TabIndex = 0;
            this.next_figure_picture.TabStop = false;
            // 
            // next_figure_text
            // 
            this.next_figure_text.AutoSize = true;
            this.next_figure_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.next_figure_text.Location = new System.Drawing.Point(0, 84);
            this.next_figure_text.Name = "next_figure_text";
            this.next_figure_text.Size = new System.Drawing.Size(95, 20);
            this.next_figure_text.TabIndex = 2;
            this.next_figure_text.Text = "Next figure:";
            // 
            // score_text
            // 
            this.score_text.AutoSize = true;
            this.score_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.score_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score_text.Location = new System.Drawing.Point(0, 0);
            this.score_text.Name = "score_text";
            this.score_text.Size = new System.Drawing.Size(92, 80);
            this.score_text.TabIndex = 1;
            this.score_text.Text = "score:\r\n0\r\nmax score:\r\n0";
            // 
            // game_interface
            // 
            this.game_interface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(50)))));
            this.game_interface.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.game_interface.Dock = System.Windows.Forms.DockStyle.Right;
            this.game_interface.Location = new System.Drawing.Point(124, 0);
            this.game_interface.Name = "game_interface";
            this.game_interface.Size = new System.Drawing.Size(164, 324);
            this.game_interface.TabIndex = 0;
            // 
            // question
            // 
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.question.Location = new System.Drawing.Point(0, 330);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 9;
            this.question.TabStop = false;
            this.question.Text = "?";
            this.question.UseVisualStyleBackColor = true;
            this.question.Click += new System.EventHandler(this.Question_Click);
            // 
            // start_btn
            // 
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_btn.Location = new System.Drawing.Point(40, 330);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(105, 40);
            this.start_btn.TabIndex = 8;
            this.start_btn.TabStop = false;
            this.start_btn.Text = "СТАРТ";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // by
            // 
            this.by.Cursor = System.Windows.Forms.Cursors.Default;
            this.by.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by.Location = new System.Drawing.Point(177, 328);
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
            this.developer_name.Location = new System.Drawing.Point(154, 349);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(134, 21);
            this.developer_name.TabIndex = 30;
            this.developer_name.Text = "Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.developer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Developer_name_MouseClick);
            // 
            // refresh_timer
            // 
            this.refresh_timer.Interval = 1;
            this.refresh_timer.Tick += new System.EventHandler(this.Refresh_timer_Tick);
            // 
            // logic_timer
            // 
            this.logic_timer.Interval = 1;
            this.logic_timer.Tick += new System.EventHandler(this.Logic_timer_Tick);
            // 
            // falling_tiles_timer
            // 
            this.falling_tiles_timer.Interval = 500;
            this.falling_tiles_timer.Tick += new System.EventHandler(this.Falling_tiles_timer_Tick);
            // 
            // move_tiles
            // 
            this.move_tiles.Interval = 200;
            this.move_tiles.Tick += new System.EventHandler(this.Move_tiles_Tick);
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 370);
            this.Controls.Add(this.by);
            this.Controls.Add(this.developer_name);
            this.Controls.Add(this.question);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.top_panel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Tetris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тутрис";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tetris_FormClosing);
            this.Load += new System.EventHandler(this.Tetris_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tetris_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tetris_KeyUp);
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            this.next_figure_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.next_figure_picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Panel game_interface;
        private System.Windows.Forms.Label score_text;
        private System.Windows.Forms.Panel next_figure_panel;
        private System.Windows.Forms.Label next_figure_text;
        private System.Windows.Forms.Label by;
        private System.Windows.Forms.Label developer_name;
        private System.Windows.Forms.Timer refresh_timer;
        private System.Windows.Forms.Timer logic_timer;
        private System.Windows.Forms.Timer falling_tiles_timer;
        private System.Windows.Forms.PictureBox next_figure_picture;
        private System.Windows.Forms.Label game_over_text;
        private System.Windows.Forms.Timer move_tiles;
    }
}