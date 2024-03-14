namespace minigames.Hacker_man
{
    partial class Hackerman
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hackerman));
            this.start_btn = new System.Windows.Forms.Button();
            this.developer_name = new System.Windows.Forms.Label();
            this.question = new System.Windows.Forms.Button();
            this.num1_panel = new System.Windows.Forms.Panel();
            this.num1_input = new System.Windows.Forms.TextBox();
            this.num2_panel = new System.Windows.Forms.Panel();
            this.num2_input = new System.Windows.Forms.TextBox();
            this.num3_panel = new System.Windows.Forms.Panel();
            this.num3_input = new System.Windows.Forms.TextBox();
            this.num4_panel = new System.Windows.Forms.Panel();
            this.num4_input = new System.Windows.Forms.TextBox();
            this.top_panel = new System.Windows.Forms.Panel();
            this.attemps_text = new System.Windows.Forms.Label();
            this.by_text = new System.Windows.Forms.Label();
            this.score_text = new System.Windows.Forms.Label();
            this.win_timer = new System.Windows.Forms.Timer(this.components);
            this.num1_panel.SuspendLayout();
            this.num2_panel.SuspendLayout();
            this.num3_panel.SuspendLayout();
            this.num4_panel.SuspendLayout();
            this.top_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_btn.Location = new System.Drawing.Point(40, 120);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(105, 40);
            this.start_btn.TabIndex = 24;
            this.start_btn.TabStop = false;
            this.start_btn.Text = "СТАРТ";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // developer_name
            // 
            this.developer_name.AutoSize = true;
            this.developer_name.Cursor = System.Windows.Forms.Cursors.Help;
            this.developer_name.Font = new System.Drawing.Font("Lucida Handwriting", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developer_name.Location = new System.Drawing.Point(143, 140);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(124, 20);
            this.developer_name.TabIndex = 23;
            this.developer_name.Text = "Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.developer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Developer_name_MouseClick);
            // 
            // question
            // 
            this.question.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.question.Location = new System.Drawing.Point(0, 120);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 22;
            this.question.TabStop = false;
            this.question.Text = "?";
            this.question.UseVisualStyleBackColor = true;
            this.question.Click += new System.EventHandler(this.Question_Click);
            // 
            // num1_panel
            // 
            this.num1_panel.Controls.Add(this.num1_input);
            this.num1_panel.Location = new System.Drawing.Point(25, 0);
            this.num1_panel.Name = "num1_panel";
            this.num1_panel.Size = new System.Drawing.Size(50, 50);
            this.num1_panel.TabIndex = 25;
            // 
            // num1_input
            // 
            this.num1_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num1_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num1_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.num1_input.Location = new System.Drawing.Point(0, 0);
            this.num1_input.MaxLength = 1;
            this.num1_input.Name = "num1_input";
            this.num1_input.Size = new System.Drawing.Size(50, 49);
            this.num1_input.TabIndex = 0;
            this.num1_input.TabStop = false;
            this.num1_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num1_input.TextChanged += new System.EventHandler(this.Num1_input_TextChanged);
            this.num1_input.Enter += new System.EventHandler(this.Num1_input_Enter);
            // 
            // num2_panel
            // 
            this.num2_panel.Controls.Add(this.num2_input);
            this.num2_panel.Location = new System.Drawing.Point(81, 0);
            this.num2_panel.Name = "num2_panel";
            this.num2_panel.Size = new System.Drawing.Size(50, 50);
            this.num2_panel.TabIndex = 26;
            // 
            // num2_input
            // 
            this.num2_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num2_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num2_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.num2_input.Location = new System.Drawing.Point(0, 0);
            this.num2_input.MaxLength = 1;
            this.num2_input.Name = "num2_input";
            this.num2_input.Size = new System.Drawing.Size(50, 49);
            this.num2_input.TabIndex = 0;
            this.num2_input.TabStop = false;
            this.num2_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num2_input.TextChanged += new System.EventHandler(this.Num2_input_TextChanged);
            this.num2_input.Enter += new System.EventHandler(this.Num2_input_Enter);
            // 
            // num3_panel
            // 
            this.num3_panel.Controls.Add(this.num3_input);
            this.num3_panel.Location = new System.Drawing.Point(137, 0);
            this.num3_panel.Name = "num3_panel";
            this.num3_panel.Size = new System.Drawing.Size(50, 50);
            this.num3_panel.TabIndex = 26;
            // 
            // num3_input
            // 
            this.num3_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num3_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num3_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.num3_input.Location = new System.Drawing.Point(0, 0);
            this.num3_input.MaxLength = 1;
            this.num3_input.Name = "num3_input";
            this.num3_input.Size = new System.Drawing.Size(50, 49);
            this.num3_input.TabIndex = 0;
            this.num3_input.TabStop = false;
            this.num3_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num3_input.TextChanged += new System.EventHandler(this.Num3_input_TextChanged);
            this.num3_input.Enter += new System.EventHandler(this.Num3_input_Enter);
            // 
            // num4_panel
            // 
            this.num4_panel.Controls.Add(this.num4_input);
            this.num4_panel.Location = new System.Drawing.Point(193, 0);
            this.num4_panel.Name = "num4_panel";
            this.num4_panel.Size = new System.Drawing.Size(50, 50);
            this.num4_panel.TabIndex = 26;
            // 
            // num4_input
            // 
            this.num4_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num4_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num4_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.num4_input.Location = new System.Drawing.Point(0, 0);
            this.num4_input.MaxLength = 1;
            this.num4_input.Name = "num4_input";
            this.num4_input.Size = new System.Drawing.Size(50, 49);
            this.num4_input.TabIndex = 0;
            this.num4_input.TabStop = false;
            this.num4_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num4_input.TextChanged += new System.EventHandler(this.Num4_input_TextChanged);
            this.num4_input.Enter += new System.EventHandler(this.Num4_input_Enter);
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.Gainsboro;
            this.top_panel.Controls.Add(this.num1_panel);
            this.top_panel.Controls.Add(this.num3_panel);
            this.top_panel.Controls.Add(this.attemps_text);
            this.top_panel.Controls.Add(this.num2_panel);
            this.top_panel.Controls.Add(this.num4_panel);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(267, 77);
            this.top_panel.TabIndex = 27;
            this.top_panel.Visible = false;
            // 
            // attemps_text
            // 
            this.attemps_text.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.attemps_text.Location = new System.Drawing.Point(0, 53);
            this.attemps_text.Name = "attemps_text";
            this.attemps_text.Size = new System.Drawing.Size(267, 24);
            this.attemps_text.TabIndex = 28;
            this.attemps_text.Text = "Попытки: 8";
            this.attemps_text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // by_text
            // 
            this.by_text.AutoSize = true;
            this.by_text.Cursor = System.Windows.Forms.Cursors.Default;
            this.by_text.Font = new System.Drawing.Font("Lucida Handwriting", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by_text.Location = new System.Drawing.Point(230, 120);
            this.by_text.Name = "by_text";
            this.by_text.Size = new System.Drawing.Size(37, 20);
            this.by_text.TabIndex = 29;
            this.by_text.Text = "By.";
            this.by_text.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // score_text
            // 
            this.score_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score_text.Location = new System.Drawing.Point(0, 77);
            this.score_text.Name = "score_text";
            this.score_text.Size = new System.Drawing.Size(267, 40);
            this.score_text.TabIndex = 30;
            this.score_text.Text = "счёт: 0\r\nмакс. счёт: 0";
            this.score_text.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // win_timer
            // 
            this.win_timer.Interval = 2000;
            this.win_timer.Tick += new System.EventHandler(this.Win_timer_Tick);
            // 
            // Hackerman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 160);
            this.Controls.Add(this.score_text);
            this.Controls.Add(this.by_text);
            this.Controls.Add(this.top_panel);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.developer_name);
            this.Controls.Add(this.question);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Hackerman";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Хацкер";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Hackerman_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Hackerman_KeyPress);
            this.num1_panel.ResumeLayout(false);
            this.num1_panel.PerformLayout();
            this.num2_panel.ResumeLayout(false);
            this.num2_panel.PerformLayout();
            this.num3_panel.ResumeLayout(false);
            this.num3_panel.PerformLayout();
            this.num4_panel.ResumeLayout(false);
            this.num4_panel.PerformLayout();
            this.top_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Label developer_name;
        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Panel num1_panel;
        private System.Windows.Forms.TextBox num1_input;
        private System.Windows.Forms.Panel num2_panel;
        private System.Windows.Forms.TextBox num2_input;
        private System.Windows.Forms.Panel num3_panel;
        private System.Windows.Forms.TextBox num3_input;
        private System.Windows.Forms.Panel num4_panel;
        private System.Windows.Forms.TextBox num4_input;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Label attemps_text;
        private System.Windows.Forms.Label by_text;
        private System.Windows.Forms.Label score_text;
        private System.Windows.Forms.Timer win_timer;
    }
}