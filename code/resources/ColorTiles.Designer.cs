namespace minigames.Colortiles
{
    partial class ColorTiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorTiles));
            this.question = new System.Windows.Forms.Button();
            this.top_panel = new System.Windows.Forms.Panel();
            this.time_panel = new System.Windows.Forms.Panel();
            this.time_left_panel = new System.Windows.Forms.Panel();
            this.answer_panel = new System.Windows.Forms.Panel();
            this.answer_8 = new System.Windows.Forms.Panel();
            this.answer_7 = new System.Windows.Forms.Panel();
            this.answer_6 = new System.Windows.Forms.Panel();
            this.answer_5 = new System.Windows.Forms.Panel();
            this.answer_4 = new System.Windows.Forms.Panel();
            this.answer_2 = new System.Windows.Forms.Panel();
            this.answer_3 = new System.Windows.Forms.Panel();
            this.answer_1 = new System.Windows.Forms.Panel();
            this.taskpanel = new System.Windows.Forms.Panel();
            this.task_8 = new System.Windows.Forms.Panel();
            this.task_7 = new System.Windows.Forms.Panel();
            this.task_6 = new System.Windows.Forms.Panel();
            this.task_5 = new System.Windows.Forms.Panel();
            this.task_4 = new System.Windows.Forms.Panel();
            this.task_2 = new System.Windows.Forms.Panel();
            this.task_3 = new System.Windows.Forms.Panel();
            this.task_1 = new System.Windows.Forms.Panel();
            this.btn_panel = new System.Windows.Forms.Panel();
            this.color_btn_8 = new System.Windows.Forms.Button();
            this.color_btn_1 = new System.Windows.Forms.Button();
            this.color_btn_7 = new System.Windows.Forms.Button();
            this.color_btn_5 = new System.Windows.Forms.Button();
            this.color_btn_6 = new System.Windows.Forms.Button();
            this.color_btn_2 = new System.Windows.Forms.Button();
            this.color_btn_3 = new System.Windows.Forms.Button();
            this.color_btn_4 = new System.Windows.Forms.Button();
            this.developer_name = new System.Windows.Forms.Label();
            this.start_btn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.top_panel.SuspendLayout();
            this.time_panel.SuspendLayout();
            this.answer_panel.SuspendLayout();
            this.taskpanel.SuspendLayout();
            this.btn_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // question
            // 
            this.question.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.question.Location = new System.Drawing.Point(0, 160);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 9;
            this.question.TabStop = false;
            this.question.Text = "?";
            this.question.UseVisualStyleBackColor = true;
            this.question.Click += new System.EventHandler(this.Question_Click);
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.Gainsboro;
            this.top_panel.Controls.Add(this.time_panel);
            this.top_panel.Controls.Add(this.answer_panel);
            this.top_panel.Controls.Add(this.taskpanel);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(400, 110);
            this.top_panel.TabIndex = 10;
            // 
            // time_panel
            // 
            this.time_panel.Controls.Add(this.time_left_panel);
            this.time_panel.Location = new System.Drawing.Point(0, 50);
            this.time_panel.Name = "time_panel";
            this.time_panel.Size = new System.Drawing.Size(400, 10);
            this.time_panel.TabIndex = 3;
            // 
            // time_left_panel
            // 
            this.time_left_panel.BackColor = System.Drawing.Color.Gray;
            this.time_left_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.time_left_panel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.time_left_panel.Location = new System.Drawing.Point(0, 0);
            this.time_left_panel.Name = "time_left_panel";
            this.time_left_panel.Size = new System.Drawing.Size(400, 10);
            this.time_left_panel.TabIndex = 0;
            this.time_left_panel.Visible = false;
            // 
            // answer_panel
            // 
            this.answer_panel.Controls.Add(this.answer_8);
            this.answer_panel.Controls.Add(this.answer_7);
            this.answer_panel.Controls.Add(this.answer_6);
            this.answer_panel.Controls.Add(this.answer_5);
            this.answer_panel.Controls.Add(this.answer_4);
            this.answer_panel.Controls.Add(this.answer_2);
            this.answer_panel.Controls.Add(this.answer_3);
            this.answer_panel.Controls.Add(this.answer_1);
            this.answer_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.answer_panel.Location = new System.Drawing.Point(0, 60);
            this.answer_panel.Name = "answer_panel";
            this.answer_panel.Size = new System.Drawing.Size(400, 50);
            this.answer_panel.TabIndex = 2;
            this.answer_panel.Visible = false;
            // 
            // answer_8
            // 
            this.answer_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answer_8.Location = new System.Drawing.Point(350, 0);
            this.answer_8.Name = "answer_8";
            this.answer_8.Size = new System.Drawing.Size(50, 50);
            this.answer_8.TabIndex = 6;
            // 
            // answer_7
            // 
            this.answer_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answer_7.Location = new System.Drawing.Point(300, 0);
            this.answer_7.Name = "answer_7";
            this.answer_7.Size = new System.Drawing.Size(50, 50);
            this.answer_7.TabIndex = 5;
            // 
            // answer_6
            // 
            this.answer_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answer_6.Location = new System.Drawing.Point(250, 0);
            this.answer_6.Name = "answer_6";
            this.answer_6.Size = new System.Drawing.Size(50, 50);
            this.answer_6.TabIndex = 4;
            // 
            // answer_5
            // 
            this.answer_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answer_5.Location = new System.Drawing.Point(200, 0);
            this.answer_5.Name = "answer_5";
            this.answer_5.Size = new System.Drawing.Size(50, 50);
            this.answer_5.TabIndex = 3;
            // 
            // answer_4
            // 
            this.answer_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answer_4.Location = new System.Drawing.Point(150, 0);
            this.answer_4.Name = "answer_4";
            this.answer_4.Size = new System.Drawing.Size(50, 50);
            this.answer_4.TabIndex = 2;
            // 
            // answer_2
            // 
            this.answer_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answer_2.Location = new System.Drawing.Point(50, 0);
            this.answer_2.Name = "answer_2";
            this.answer_2.Size = new System.Drawing.Size(50, 50);
            this.answer_2.TabIndex = 1;
            // 
            // answer_3
            // 
            this.answer_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answer_3.Location = new System.Drawing.Point(100, 0);
            this.answer_3.Name = "answer_3";
            this.answer_3.Size = new System.Drawing.Size(50, 50);
            this.answer_3.TabIndex = 1;
            // 
            // answer_1
            // 
            this.answer_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answer_1.Location = new System.Drawing.Point(0, 0);
            this.answer_1.Name = "answer_1";
            this.answer_1.Size = new System.Drawing.Size(50, 50);
            this.answer_1.TabIndex = 0;
            // 
            // taskpanel
            // 
            this.taskpanel.Controls.Add(this.task_8);
            this.taskpanel.Controls.Add(this.task_7);
            this.taskpanel.Controls.Add(this.task_6);
            this.taskpanel.Controls.Add(this.task_5);
            this.taskpanel.Controls.Add(this.task_4);
            this.taskpanel.Controls.Add(this.task_2);
            this.taskpanel.Controls.Add(this.task_3);
            this.taskpanel.Controls.Add(this.task_1);
            this.taskpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.taskpanel.Location = new System.Drawing.Point(0, 0);
            this.taskpanel.Name = "taskpanel";
            this.taskpanel.Size = new System.Drawing.Size(400, 50);
            this.taskpanel.TabIndex = 1;
            this.taskpanel.Visible = false;
            // 
            // task_8
            // 
            this.task_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.task_8.Location = new System.Drawing.Point(350, 0);
            this.task_8.Name = "task_8";
            this.task_8.Size = new System.Drawing.Size(50, 50);
            this.task_8.TabIndex = 6;
            // 
            // task_7
            // 
            this.task_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.task_7.Location = new System.Drawing.Point(300, 0);
            this.task_7.Name = "task_7";
            this.task_7.Size = new System.Drawing.Size(50, 50);
            this.task_7.TabIndex = 5;
            // 
            // task_6
            // 
            this.task_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.task_6.Location = new System.Drawing.Point(250, 0);
            this.task_6.Name = "task_6";
            this.task_6.Size = new System.Drawing.Size(50, 50);
            this.task_6.TabIndex = 4;
            // 
            // task_5
            // 
            this.task_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.task_5.Location = new System.Drawing.Point(200, 0);
            this.task_5.Name = "task_5";
            this.task_5.Size = new System.Drawing.Size(50, 50);
            this.task_5.TabIndex = 3;
            // 
            // task_4
            // 
            this.task_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.task_4.Location = new System.Drawing.Point(150, 0);
            this.task_4.Name = "task_4";
            this.task_4.Size = new System.Drawing.Size(50, 50);
            this.task_4.TabIndex = 2;
            // 
            // task_2
            // 
            this.task_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.task_2.Location = new System.Drawing.Point(50, 0);
            this.task_2.Name = "task_2";
            this.task_2.Size = new System.Drawing.Size(50, 50);
            this.task_2.TabIndex = 1;
            // 
            // task_3
            // 
            this.task_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.task_3.Location = new System.Drawing.Point(100, 0);
            this.task_3.Name = "task_3";
            this.task_3.Size = new System.Drawing.Size(50, 50);
            this.task_3.TabIndex = 1;
            // 
            // task_1
            // 
            this.task_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.task_1.Location = new System.Drawing.Point(0, 0);
            this.task_1.Name = "task_1";
            this.task_1.Size = new System.Drawing.Size(50, 50);
            this.task_1.TabIndex = 0;
            // 
            // btn_panel
            // 
            this.btn_panel.Controls.Add(this.color_btn_8);
            this.btn_panel.Controls.Add(this.color_btn_1);
            this.btn_panel.Controls.Add(this.color_btn_7);
            this.btn_panel.Controls.Add(this.color_btn_5);
            this.btn_panel.Controls.Add(this.color_btn_6);
            this.btn_panel.Controls.Add(this.color_btn_2);
            this.btn_panel.Controls.Add(this.color_btn_3);
            this.btn_panel.Controls.Add(this.color_btn_4);
            this.btn_panel.Location = new System.Drawing.Point(0, 110);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(400, 50);
            this.btn_panel.TabIndex = 16;
            // 
            // color_btn_8
            // 
            this.color_btn_8.BackColor = System.Drawing.Color.Blue;
            this.color_btn_8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.color_btn_8.Enabled = false;
            this.color_btn_8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.color_btn_8.Location = new System.Drawing.Point(350, 0);
            this.color_btn_8.Name = "color_btn_8";
            this.color_btn_8.Size = new System.Drawing.Size(50, 50);
            this.color_btn_8.TabIndex = 107;
            this.color_btn_8.TabStop = false;
            this.color_btn_8.UseVisualStyleBackColor = false;
            this.color_btn_8.Click += new System.EventHandler(this.Color_btn_8_Click);
            // 
            // color_btn_1
            // 
            this.color_btn_1.BackColor = System.Drawing.Color.Black;
            this.color_btn_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.color_btn_1.Enabled = false;
            this.color_btn_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.color_btn_1.Location = new System.Drawing.Point(0, 0);
            this.color_btn_1.Name = "color_btn_1";
            this.color_btn_1.Size = new System.Drawing.Size(50, 50);
            this.color_btn_1.TabIndex = 100;
            this.color_btn_1.TabStop = false;
            this.color_btn_1.UseVisualStyleBackColor = false;
            this.color_btn_1.Click += new System.EventHandler(this.Color_btn_1_Click);
            // 
            // color_btn_7
            // 
            this.color_btn_7.BackColor = System.Drawing.Color.Purple;
            this.color_btn_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.color_btn_7.Enabled = false;
            this.color_btn_7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.color_btn_7.Location = new System.Drawing.Point(300, 0);
            this.color_btn_7.Name = "color_btn_7";
            this.color_btn_7.Size = new System.Drawing.Size(50, 50);
            this.color_btn_7.TabIndex = 106;
            this.color_btn_7.TabStop = false;
            this.color_btn_7.UseVisualStyleBackColor = false;
            this.color_btn_7.Click += new System.EventHandler(this.Color_btn_7_Click);
            // 
            // color_btn_5
            // 
            this.color_btn_5.BackColor = System.Drawing.Color.Orange;
            this.color_btn_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.color_btn_5.Enabled = false;
            this.color_btn_5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.color_btn_5.Location = new System.Drawing.Point(200, 0);
            this.color_btn_5.Name = "color_btn_5";
            this.color_btn_5.Size = new System.Drawing.Size(50, 50);
            this.color_btn_5.TabIndex = 104;
            this.color_btn_5.TabStop = false;
            this.color_btn_5.UseVisualStyleBackColor = false;
            this.color_btn_5.Click += new System.EventHandler(this.Color_btn_5_Click);
            // 
            // color_btn_6
            // 
            this.color_btn_6.BackColor = System.Drawing.Color.Gray;
            this.color_btn_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.color_btn_6.Enabled = false;
            this.color_btn_6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.color_btn_6.Location = new System.Drawing.Point(250, 0);
            this.color_btn_6.Name = "color_btn_6";
            this.color_btn_6.Size = new System.Drawing.Size(50, 50);
            this.color_btn_6.TabIndex = 105;
            this.color_btn_6.TabStop = false;
            this.color_btn_6.UseVisualStyleBackColor = false;
            this.color_btn_6.Click += new System.EventHandler(this.Color_btn_6_Click);
            // 
            // color_btn_2
            // 
            this.color_btn_2.BackColor = System.Drawing.Color.Green;
            this.color_btn_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.color_btn_2.Enabled = false;
            this.color_btn_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.color_btn_2.Location = new System.Drawing.Point(50, 0);
            this.color_btn_2.Name = "color_btn_2";
            this.color_btn_2.Size = new System.Drawing.Size(50, 50);
            this.color_btn_2.TabIndex = 101;
            this.color_btn_2.TabStop = false;
            this.color_btn_2.UseVisualStyleBackColor = false;
            this.color_btn_2.Click += new System.EventHandler(this.Color_btn_2_Click);
            // 
            // color_btn_3
            // 
            this.color_btn_3.BackColor = System.Drawing.Color.Yellow;
            this.color_btn_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.color_btn_3.Enabled = false;
            this.color_btn_3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.color_btn_3.Location = new System.Drawing.Point(100, 0);
            this.color_btn_3.Name = "color_btn_3";
            this.color_btn_3.Size = new System.Drawing.Size(50, 50);
            this.color_btn_3.TabIndex = 102;
            this.color_btn_3.TabStop = false;
            this.color_btn_3.UseVisualStyleBackColor = false;
            this.color_btn_3.Click += new System.EventHandler(this.Color_btn_3_Click);
            // 
            // color_btn_4
            // 
            this.color_btn_4.BackColor = System.Drawing.Color.Red;
            this.color_btn_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.color_btn_4.Enabled = false;
            this.color_btn_4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.color_btn_4.Location = new System.Drawing.Point(150, 0);
            this.color_btn_4.Name = "color_btn_4";
            this.color_btn_4.Size = new System.Drawing.Size(50, 50);
            this.color_btn_4.TabIndex = 103;
            this.color_btn_4.TabStop = false;
            this.color_btn_4.UseVisualStyleBackColor = false;
            this.color_btn_4.Click += new System.EventHandler(this.Color_btn_4_Click);
            // 
            // developer_name
            // 
            this.developer_name.AutoSize = true;
            this.developer_name.Cursor = System.Windows.Forms.Cursors.Help;
            this.developer_name.Font = new System.Drawing.Font("Lucida Handwriting", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developer_name.Location = new System.Drawing.Point(206, 173);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(194, 27);
            this.developer_name.TabIndex = 20;
            this.developer_name.Text = "By.Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.developer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Developer_name_MouseClick);
            // 
            // start_btn
            // 
            this.start_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_btn.Location = new System.Drawing.Point(40, 160);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(105, 40);
            this.start_btn.TabIndex = 21;
            this.start_btn.TabStop = false;
            this.start_btn.Text = "START";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // timer
            // 
            this.timer.Interval = 15;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // ColorTiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.developer_name);
            this.Controls.Add(this.btn_panel);
            this.Controls.Add(this.top_panel);
            this.Controls.Add(this.question);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "ColorTiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Цветнашки";
            this.Load += new System.EventHandler(this.ColorTiles_Load);
            this.top_panel.ResumeLayout(false);
            this.time_panel.ResumeLayout(false);
            this.answer_panel.ResumeLayout(false);
            this.taskpanel.ResumeLayout(false);
            this.btn_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Panel task_1;
        private System.Windows.Forms.Panel btn_panel;
        private System.Windows.Forms.Button color_btn_8;
        private System.Windows.Forms.Button color_btn_1;
        private System.Windows.Forms.Button color_btn_7;
        private System.Windows.Forms.Button color_btn_5;
        private System.Windows.Forms.Button color_btn_6;
        private System.Windows.Forms.Button color_btn_2;
        private System.Windows.Forms.Button color_btn_3;
        private System.Windows.Forms.Button color_btn_4;
        private System.Windows.Forms.Panel answer_panel;
        private System.Windows.Forms.Panel answer_8;
        private System.Windows.Forms.Panel answer_7;
        private System.Windows.Forms.Panel answer_6;
        private System.Windows.Forms.Panel answer_5;
        private System.Windows.Forms.Panel answer_4;
        private System.Windows.Forms.Panel answer_2;
        private System.Windows.Forms.Panel answer_3;
        private System.Windows.Forms.Panel answer_1;
        private System.Windows.Forms.Panel taskpanel;
        private System.Windows.Forms.Panel task_8;
        private System.Windows.Forms.Panel task_7;
        private System.Windows.Forms.Panel task_6;
        private System.Windows.Forms.Panel task_5;
        private System.Windows.Forms.Panel task_4;
        private System.Windows.Forms.Panel task_2;
        private System.Windows.Forms.Panel task_3;
        private System.Windows.Forms.Label developer_name;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Panel time_panel;
        private System.Windows.Forms.Panel time_left_panel;
        private System.Windows.Forms.Timer timer;
    }
}