namespace minigames.Math_o_light
{
    partial class MathOLight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MathOLight));
            this.top_panel = new System.Windows.Forms.Panel();
            this.time_left_panel = new System.Windows.Forms.Panel();
            this.time_left = new System.Windows.Forms.Panel();
            this.score_text = new System.Windows.Forms.Label();
            this.task_text = new System.Windows.Forms.Label();
            this.input = new System.Windows.Forms.TextBox();
            this.input_text = new System.Windows.Forms.Label();
            this.developer_name = new System.Windows.Forms.Label();
            this.question = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.enter_btn = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.top_panel.SuspendLayout();
            this.time_left_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enter_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.Gainsboro;
            this.top_panel.Controls.Add(this.time_left_panel);
            this.top_panel.Controls.Add(this.score_text);
            this.top_panel.Controls.Add(this.task_text);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Margin = new System.Windows.Forms.Padding(6);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(345, 90);
            this.top_panel.TabIndex = 0;
            // 
            // time_left_panel
            // 
            this.time_left_panel.Controls.Add(this.time_left);
            this.time_left_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.time_left_panel.Location = new System.Drawing.Point(0, 85);
            this.time_left_panel.Name = "time_left_panel";
            this.time_left_panel.Size = new System.Drawing.Size(345, 5);
            this.time_left_panel.TabIndex = 2;
            this.time_left_panel.Visible = false;
            // 
            // time_left
            // 
            this.time_left.BackColor = System.Drawing.Color.Gray;
            this.time_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.time_left.Location = new System.Drawing.Point(0, 0);
            this.time_left.Name = "time_left";
            this.time_left.Size = new System.Drawing.Size(300, 5);
            this.time_left.TabIndex = 0;
            // 
            // score_text
            // 
            this.score_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.score_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score_text.Location = new System.Drawing.Point(0, 45);
            this.score_text.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.score_text.Name = "score_text";
            this.score_text.Size = new System.Drawing.Size(345, 40);
            this.score_text.TabIndex = 1;
            this.score_text.Text = "счёт: 0\r\nмакс. счёт: 0";
            this.score_text.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // task_text
            // 
            this.task_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.task_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.task_text.Location = new System.Drawing.Point(0, 0);
            this.task_text.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.task_text.Name = "task_text";
            this.task_text.Size = new System.Drawing.Size(345, 45);
            this.task_text.TabIndex = 0;
            this.task_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(5, 124);
            this.input.MaxLength = 16;
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(219, 31);
            this.input.TabIndex = 1;
            this.input.TabStop = false;
            this.input.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // input_text
            // 
            this.input_text.AutoSize = true;
            this.input_text.Location = new System.Drawing.Point(0, 96);
            this.input_text.Name = "input_text";
            this.input_text.Size = new System.Drawing.Size(162, 25);
            this.input_text.TabIndex = 2;
            this.input_text.Text = "Введите ответ:";
            this.input_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // developer_name
            // 
            this.developer_name.AutoSize = true;
            this.developer_name.Cursor = System.Windows.Forms.Cursors.Help;
            this.developer_name.Font = new System.Drawing.Font("Lucida Handwriting", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developer_name.Location = new System.Drawing.Point(151, 174);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(194, 27);
            this.developer_name.TabIndex = 21;
            this.developer_name.Text = "By.Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.developer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Developer_name_MouseClick);
            // 
            // question
            // 
            this.question.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.question.Location = new System.Drawing.Point(0, 161);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 22;
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
            this.start_btn.Location = new System.Drawing.Point(40, 161);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(105, 40);
            this.start_btn.TabIndex = 23;
            this.start_btn.TabStop = false;
            this.start_btn.Text = "СТАРТ";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // enter_btn
            // 
            this.enter_btn.Image = global::minigames.Properties.Resources.enter;
            this.enter_btn.Location = new System.Drawing.Point(230, 117);
            this.enter_btn.Name = "enter_btn";
            this.enter_btn.Size = new System.Drawing.Size(80, 40);
            this.enter_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enter_btn.TabIndex = 24;
            this.enter_btn.TabStop = false;
            this.enter_btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Enter_btn_MouseClick);
            this.enter_btn.MouseEnter += new System.EventHandler(this.Enter_btn_MouseEnter);
            this.enter_btn.MouseLeave += new System.EventHandler(this.Enter_btn_MouseLeave);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MathOLight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 201);
            this.Controls.Add(this.enter_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.question);
            this.Controls.Add(this.developer_name);
            this.Controls.Add(this.input_text);
            this.Controls.Add(this.input);
            this.Controls.Add(this.top_panel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MathOLight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Матемагнит";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MathOLight_FormClosing);
            this.Load += new System.EventHandler(this.MathOLight_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MathOLight_KeyDown);
            this.top_panel.ResumeLayout(false);
            this.time_left_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.enter_btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Label task_text;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Label input_text;
        private System.Windows.Forms.Label score_text;
        private System.Windows.Forms.Label developer_name;
        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.PictureBox enter_btn;
        private System.Windows.Forms.Panel time_left_panel;
        private System.Windows.Forms.Panel time_left;
        private System.Windows.Forms.Timer timer;
    }
}