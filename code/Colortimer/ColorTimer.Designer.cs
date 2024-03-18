namespace minigames.Colortimer
{
    partial class ColorTimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorTimer));
            this.question = new System.Windows.Forms.Button();
            this.yellow_btn = new System.Windows.Forms.Button();
            this.red_btn = new System.Windows.Forms.Button();
            this.green_btn = new System.Windows.Forms.Button();
            this.purple_btn = new System.Windows.Forms.Button();
            this.black_btn = new System.Windows.Forms.Button();
            this.blue_btn = new System.Windows.Forms.Button();
            this.btn_panel = new System.Windows.Forms.Panel();
            this.gray_btn = new System.Windows.Forms.Button();
            this.orange_btn = new System.Windows.Forms.Button();
            this.top_panel = new System.Windows.Forms.Panel();
            this.color_panel = new System.Windows.Forms.Panel();
            this.combo_text = new System.Windows.Forms.Label();
            this.color_text = new System.Windows.Forms.Label();
            this.time_left_panel = new System.Windows.Forms.Panel();
            this.time_left = new System.Windows.Forms.Panel();
            this.start_btn = new System.Windows.Forms.Button();
            this.developer_name = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_panel.SuspendLayout();
            this.top_panel.SuspendLayout();
            this.color_panel.SuspendLayout();
            this.time_left_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // question
            // 
            this.question.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.question.Location = new System.Drawing.Point(0, 150);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 8;
            this.question.TabStop = false;
            this.question.Text = "?";
            this.question.UseVisualStyleBackColor = true;
            this.question.Click += new System.EventHandler(this.Question_Click);
            // 
            // yellow_btn
            // 
            this.yellow_btn.BackColor = System.Drawing.Color.Gold;
            this.yellow_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.yellow_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.yellow_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.yellow_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yellow_btn.ForeColor = System.Drawing.Color.White;
            this.yellow_btn.Location = new System.Drawing.Point(100, 0);
            this.yellow_btn.Name = "yellow_btn";
            this.yellow_btn.Size = new System.Drawing.Size(50, 50);
            this.yellow_btn.TabIndex = 10;
            this.yellow_btn.TabStop = false;
            this.yellow_btn.Text = "3";
            this.yellow_btn.UseVisualStyleBackColor = false;
            this.yellow_btn.Click += new System.EventHandler(this.Yellow_btn_Click);
            // 
            // red_btn
            // 
            this.red_btn.BackColor = System.Drawing.Color.Red;
            this.red_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.red_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.red_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.red_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.red_btn.ForeColor = System.Drawing.Color.White;
            this.red_btn.Location = new System.Drawing.Point(150, 0);
            this.red_btn.Name = "red_btn";
            this.red_btn.Size = new System.Drawing.Size(50, 50);
            this.red_btn.TabIndex = 11;
            this.red_btn.TabStop = false;
            this.red_btn.Text = "4";
            this.red_btn.UseVisualStyleBackColor = false;
            this.red_btn.Click += new System.EventHandler(this.Red_btn_Click);
            // 
            // green_btn
            // 
            this.green_btn.BackColor = System.Drawing.Color.Green;
            this.green_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.green_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.green_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.green_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.green_btn.ForeColor = System.Drawing.Color.White;
            this.green_btn.Location = new System.Drawing.Point(50, 0);
            this.green_btn.Name = "green_btn";
            this.green_btn.Size = new System.Drawing.Size(50, 50);
            this.green_btn.TabIndex = 12;
            this.green_btn.TabStop = false;
            this.green_btn.Text = "2";
            this.green_btn.UseVisualStyleBackColor = false;
            this.green_btn.Click += new System.EventHandler(this.Green_btn_Click);
            // 
            // purple_btn
            // 
            this.purple_btn.BackColor = System.Drawing.Color.Purple;
            this.purple_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.purple_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.purple_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.purple_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.purple_btn.ForeColor = System.Drawing.Color.White;
            this.purple_btn.Location = new System.Drawing.Point(300, 0);
            this.purple_btn.Name = "purple_btn";
            this.purple_btn.Size = new System.Drawing.Size(50, 50);
            this.purple_btn.TabIndex = 13;
            this.purple_btn.TabStop = false;
            this.purple_btn.Text = "7";
            this.purple_btn.UseVisualStyleBackColor = false;
            this.purple_btn.Click += new System.EventHandler(this.Purple_btn_Click);
            // 
            // black_btn
            // 
            this.black_btn.BackColor = System.Drawing.Color.Black;
            this.black_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.black_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.black_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.black_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.black_btn.ForeColor = System.Drawing.Color.White;
            this.black_btn.Location = new System.Drawing.Point(0, 0);
            this.black_btn.Name = "black_btn";
            this.black_btn.Size = new System.Drawing.Size(50, 50);
            this.black_btn.TabIndex = 14;
            this.black_btn.TabStop = false;
            this.black_btn.Text = "1";
            this.black_btn.UseVisualStyleBackColor = false;
            this.black_btn.Click += new System.EventHandler(this.Black_btn_Click);
            // 
            // blue_btn
            // 
            this.blue_btn.BackColor = System.Drawing.Color.Blue;
            this.blue_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.blue_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.blue_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.blue_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.blue_btn.ForeColor = System.Drawing.Color.White;
            this.blue_btn.Location = new System.Drawing.Point(350, 0);
            this.blue_btn.Name = "blue_btn";
            this.blue_btn.Size = new System.Drawing.Size(50, 50);
            this.blue_btn.TabIndex = 9;
            this.blue_btn.TabStop = false;
            this.blue_btn.Text = "8";
            this.blue_btn.UseVisualStyleBackColor = false;
            this.blue_btn.Click += new System.EventHandler(this.Blue_btn_Click);
            // 
            // btn_panel
            // 
            this.btn_panel.Controls.Add(this.blue_btn);
            this.btn_panel.Controls.Add(this.purple_btn);
            this.btn_panel.Controls.Add(this.gray_btn);
            this.btn_panel.Controls.Add(this.orange_btn);
            this.btn_panel.Controls.Add(this.red_btn);
            this.btn_panel.Controls.Add(this.yellow_btn);
            this.btn_panel.Controls.Add(this.green_btn);
            this.btn_panel.Controls.Add(this.black_btn);
            this.btn_panel.Location = new System.Drawing.Point(0, 100);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(400, 50);
            this.btn_panel.TabIndex = 15;
            // 
            // gray_btn
            // 
            this.gray_btn.BackColor = System.Drawing.Color.Gray;
            this.gray_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gray_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.gray_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gray_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gray_btn.ForeColor = System.Drawing.Color.White;
            this.gray_btn.Location = new System.Drawing.Point(250, 0);
            this.gray_btn.Name = "gray_btn";
            this.gray_btn.Size = new System.Drawing.Size(50, 50);
            this.gray_btn.TabIndex = 16;
            this.gray_btn.TabStop = false;
            this.gray_btn.Text = "6";
            this.gray_btn.UseVisualStyleBackColor = false;
            this.gray_btn.Click += new System.EventHandler(this.Gray_btn_Click);
            // 
            // orange_btn
            // 
            this.orange_btn.BackColor = System.Drawing.Color.DarkOrange;
            this.orange_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.orange_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.orange_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.orange_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orange_btn.ForeColor = System.Drawing.Color.White;
            this.orange_btn.Location = new System.Drawing.Point(200, 0);
            this.orange_btn.Name = "orange_btn";
            this.orange_btn.Size = new System.Drawing.Size(50, 50);
            this.orange_btn.TabIndex = 17;
            this.orange_btn.TabStop = false;
            this.orange_btn.Text = "5";
            this.orange_btn.UseVisualStyleBackColor = false;
            this.orange_btn.Click += new System.EventHandler(this.Orange_btn_Click);
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.Gainsboro;
            this.top_panel.Controls.Add(this.color_panel);
            this.top_panel.Controls.Add(this.time_left_panel);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(399, 100);
            this.top_panel.TabIndex = 16;
            // 
            // color_panel
            // 
            this.color_panel.Controls.Add(this.combo_text);
            this.color_panel.Controls.Add(this.color_text);
            this.color_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.color_panel.Location = new System.Drawing.Point(0, 0);
            this.color_panel.Name = "color_panel";
            this.color_panel.Size = new System.Drawing.Size(399, 95);
            this.color_panel.TabIndex = 1;
            // 
            // combo_text
            // 
            this.combo_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.combo_text.Location = new System.Drawing.Point(0, 50);
            this.combo_text.Name = "combo_text";
            this.combo_text.Size = new System.Drawing.Size(399, 45);
            this.combo_text.TabIndex = 1;
            this.combo_text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // color_text
            // 
            this.color_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.color_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.color_text.ForeColor = System.Drawing.Color.Black;
            this.color_text.Location = new System.Drawing.Point(0, 0);
            this.color_text.Name = "color_text";
            this.color_text.Size = new System.Drawing.Size(399, 50);
            this.color_text.TabIndex = 0;
            this.color_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time_left_panel
            // 
            this.time_left_panel.BackColor = System.Drawing.Color.Gainsboro;
            this.time_left_panel.Controls.Add(this.time_left);
            this.time_left_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.time_left_panel.Location = new System.Drawing.Point(0, 95);
            this.time_left_panel.Name = "time_left_panel";
            this.time_left_panel.Size = new System.Drawing.Size(399, 5);
            this.time_left_panel.TabIndex = 0;
            // 
            // time_left
            // 
            this.time_left.BackColor = System.Drawing.Color.Gray;
            this.time_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.time_left.Location = new System.Drawing.Point(0, 0);
            this.time_left.Name = "time_left";
            this.time_left.Size = new System.Drawing.Size(400, 5);
            this.time_left.TabIndex = 1;
            this.time_left.Visible = false;
            // 
            // start_btn
            // 
            this.start_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_btn.Location = new System.Drawing.Point(40, 150);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(105, 40);
            this.start_btn.TabIndex = 18;
            this.start_btn.TabStop = false;
            this.start_btn.Text = "START";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // developer_name
            // 
            this.developer_name.AutoSize = true;
            this.developer_name.Cursor = System.Windows.Forms.Cursors.Help;
            this.developer_name.Font = new System.Drawing.Font("Lucida Handwriting", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developer_name.Location = new System.Drawing.Point(192, 163);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(208, 27);
            this.developer_name.TabIndex = 19;
            this.developer_name.Text = "By.Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.developer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Developer_name_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // ColorTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 190);
            this.Controls.Add(this.developer_name);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.top_panel);
            this.Controls.Add(this.btn_panel);
            this.Controls.Add(this.question);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "ColorTimer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Секундоцвет";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColorTimer_FormClosing);
            this.Load += new System.EventHandler(this.ColorTimer_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ColorTimer_KeyPress);
            this.btn_panel.ResumeLayout(false);
            this.top_panel.ResumeLayout(false);
            this.color_panel.ResumeLayout(false);
            this.time_left_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Button yellow_btn;
        private System.Windows.Forms.Button red_btn;
        private System.Windows.Forms.Button green_btn;
        private System.Windows.Forms.Button purple_btn;
        private System.Windows.Forms.Button black_btn;
        private System.Windows.Forms.Button blue_btn;
        private System.Windows.Forms.Panel btn_panel;
        private System.Windows.Forms.Button orange_btn;
        private System.Windows.Forms.Button gray_btn;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Panel time_left_panel;
        private System.Windows.Forms.Panel time_left;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Label developer_name;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel color_panel;
        private System.Windows.Forms.Label color_text;
        private System.Windows.Forms.Label combo_text;
    }
}