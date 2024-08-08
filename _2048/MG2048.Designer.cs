namespace minigames._2048
{
    partial class MG2048
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MG2048));
            this.question = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.developer_name = new System.Windows.Forms.Label();
            this.top_panel = new System.Windows.Forms.Panel();
            this.game_interface = new System.Windows.Forms.Panel();
            this.score_text = new System.Windows.Forms.Label();
            this.by = new System.Windows.Forms.Label();
            this.top_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // question
            // 
            this.question.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.question.Location = new System.Drawing.Point(0, 314);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 26;
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
            this.start_btn.Location = new System.Drawing.Point(40, 314);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(105, 40);
            this.start_btn.TabIndex = 25;
            this.start_btn.TabStop = false;
            this.start_btn.Text = "СТАРТ";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // developer_name
            // 
            this.developer_name.AutoSize = true;
            this.developer_name.Cursor = System.Windows.Forms.Cursors.Help;
            this.developer_name.Font = new System.Drawing.Font("Lucida Handwriting", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developer_name.Location = new System.Drawing.Point(165, 337);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(111, 17);
            this.developer_name.TabIndex = 27;
            this.developer_name.Text = "Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.developer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Developer_name_MouseClick);
            // 
            // top_panel
            // 
            this.top_panel.Controls.Add(this.game_interface);
            this.top_panel.Controls.Add(this.score_text);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(276, 308);
            this.top_panel.TabIndex = 28;
            // 
            // game_interface
            // 
            this.game_interface.Location = new System.Drawing.Point(12, 12);
            this.game_interface.Name = "game_interface";
            this.game_interface.Size = new System.Drawing.Size(252, 252);
            this.game_interface.TabIndex = 1;
            // 
            // score_text
            // 
            this.score_text.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.score_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score_text.Location = new System.Drawing.Point(0, 268);
            this.score_text.Name = "score_text";
            this.score_text.Size = new System.Drawing.Size(276, 40);
            this.score_text.TabIndex = 0;
            this.score_text.Text = "score: 0\r\nmax score: 0";
            this.score_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // by
            // 
            this.by.Cursor = System.Windows.Forms.Cursors.Default;
            this.by.Font = new System.Drawing.Font("Lucida Handwriting", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by.Location = new System.Drawing.Point(165, 320);
            this.by.Name = "by";
            this.by.Size = new System.Drawing.Size(111, 17);
            this.by.TabIndex = 29;
            this.by.Text = "By.";
            this.by.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MG2048
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 354);
            this.Controls.Add(this.by);
            this.Controls.Add(this.top_panel);
            this.Controls.Add(this.developer_name);
            this.Controls.Add(this.question);
            this.Controls.Add(this.start_btn);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MG2048";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MG2048_FormClosing);
            this.Load += new System.EventHandler(this.MG2048_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MG2048_KeyDown);
            this.top_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Label developer_name;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Label score_text;
        private System.Windows.Forms.Panel game_interface;
        private System.Windows.Forms.Label by;
    }
}