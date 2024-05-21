namespace minigames._Sapper
{
    partial class Sapper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sapper));
            this.top_panel = new System.Windows.Forms.Panel();
            this.show_settings = new System.Windows.Forms.PictureBox();
            this.start_btn = new System.Windows.Forms.Button();
            this.question = new System.Windows.Forms.Button();
            this.by = new System.Windows.Forms.Label();
            this.developer_name = new System.Windows.Forms.Label();
            this.its_bomb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.show_settings)).BeginInit();
            this.SuspendLayout();
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(50)))));
            this.top_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(364, 364);
            this.top_panel.TabIndex = 0;
            // 
            // show_settings
            // 
            this.show_settings.Image = global::minigames.Properties.Resources.icon2;
            this.show_settings.Location = new System.Drawing.Point(0, 373);
            this.show_settings.Name = "show_settings";
            this.show_settings.Size = new System.Drawing.Size(40, 40);
            this.show_settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.show_settings.TabIndex = 33;
            this.show_settings.TabStop = false;
            this.show_settings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Show_settings_MouseClick);
            this.show_settings.MouseEnter += new System.EventHandler(this.Show_settings_MouseEnter);
            this.show_settings.MouseLeave += new System.EventHandler(this.Show_settings_MouseLeave);
            // 
            // start_btn
            // 
            this.start_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_btn.Location = new System.Drawing.Point(80, 373);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(105, 40);
            this.start_btn.TabIndex = 31;
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
            this.question.Location = new System.Drawing.Point(40, 373);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 30;
            this.question.TabStop = false;
            this.question.Text = "?";
            this.question.UseVisualStyleBackColor = true;
            this.question.Click += new System.EventHandler(this.Question_Click);
            // 
            // by
            // 
            this.by.Cursor = System.Windows.Forms.Cursors.Default;
            this.by.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by.Location = new System.Drawing.Point(253, 371);
            this.by.Name = "by";
            this.by.Size = new System.Drawing.Size(111, 21);
            this.by.TabIndex = 35;
            this.by.Text = "By.";
            this.by.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // developer_name
            // 
            this.developer_name.AutoSize = true;
            this.developer_name.Cursor = System.Windows.Forms.Cursors.Help;
            this.developer_name.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developer_name.Location = new System.Drawing.Point(230, 392);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(134, 21);
            this.developer_name.TabIndex = 34;
            this.developer_name.Text = "Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // its_bomb
            // 
            this.its_bomb.AutoSize = true;
            this.its_bomb.Location = new System.Drawing.Point(191, 373);
            this.its_bomb.Name = "its_bomb";
            this.its_bomb.Size = new System.Drawing.Size(0, 24);
            this.its_bomb.TabIndex = 36;
            this.its_bomb.Visible = false;
            // 
            // Sapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 413);
            this.Controls.Add(this.its_bomb);
            this.Controls.Add(this.by);
            this.Controls.Add(this.developer_name);
            this.Controls.Add(this.show_settings);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.question);
            this.Controls.Add(this.top_panel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Sapper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сапёр";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sapper_FormClosing);
            this.Load += new System.EventHandler(this.Sapper_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Sapper_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.show_settings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.PictureBox show_settings;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Label by;
        private System.Windows.Forms.Label developer_name;
        private System.Windows.Forms.Label its_bomb;
    }
}