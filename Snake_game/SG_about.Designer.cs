namespace minigames.Snake_game
{
    partial class SG_about
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
            this.control_panel = new System.Windows.Forms.Panel();
            this.control_space = new System.Windows.Forms.Label();
            this.control_pic = new System.Windows.Forms.PictureBox();
            this.control_text = new System.Windows.Forms.Label();
            this.fruit_panel = new System.Windows.Forms.Panel();
            this.cut_fruit_text = new System.Windows.Forms.Label();
            this.cut_fruit_panel = new System.Windows.Forms.Panel();
            this.super_puper_fruit_text = new System.Windows.Forms.Label();
            this.super_puper_fruit_panel = new System.Windows.Forms.Panel();
            this.super_fruit_text = new System.Windows.Forms.Label();
            this.super_fruit_panel = new System.Windows.Forms.Panel();
            this.red_fruit_text = new System.Windows.Forms.Label();
            this.red_fruit_panel = new System.Windows.Forms.Panel();
            this.fruit_name_text = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.control_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.control_pic)).BeginInit();
            this.fruit_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // control_panel
            // 
            this.control_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.control_panel.Controls.Add(this.control_space);
            this.control_panel.Controls.Add(this.control_pic);
            this.control_panel.Controls.Add(this.control_text);
            this.control_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_panel.Location = new System.Drawing.Point(0, 0);
            this.control_panel.Margin = new System.Windows.Forms.Padding(2);
            this.control_panel.Name = "control_panel";
            this.control_panel.Size = new System.Drawing.Size(526, 166);
            this.control_panel.TabIndex = 0;
            // 
            // control_space
            // 
            this.control_space.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_space.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.control_space.Location = new System.Drawing.Point(0, 144);
            this.control_space.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.control_space.Name = "control_space";
            this.control_space.Size = new System.Drawing.Size(524, 20);
            this.control_space.TabIndex = 2;
            this.control_space.Text = "Для остановки игры нажмите: SPACE";
            this.control_space.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // control_pic
            // 
            this.control_pic.BackColor = System.Drawing.Color.White;
            this.control_pic.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_pic.Image = global::minigames.Properties.Resources.control;
            this.control_pic.Location = new System.Drawing.Point(0, 20);
            this.control_pic.Margin = new System.Windows.Forms.Padding(2);
            this.control_pic.Name = "control_pic";
            this.control_pic.Size = new System.Drawing.Size(524, 124);
            this.control_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.control_pic.TabIndex = 0;
            this.control_pic.TabStop = false;
            // 
            // control_text
            // 
            this.control_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.control_text.Location = new System.Drawing.Point(0, 0);
            this.control_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.control_text.Name = "control_text";
            this.control_text.Size = new System.Drawing.Size(524, 20);
            this.control_text.TabIndex = 1;
            this.control_text.Text = "Управление:";
            this.control_text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // fruit_panel
            // 
            this.fruit_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fruit_panel.Controls.Add(this.cut_fruit_text);
            this.fruit_panel.Controls.Add(this.cut_fruit_panel);
            this.fruit_panel.Controls.Add(this.super_puper_fruit_text);
            this.fruit_panel.Controls.Add(this.super_puper_fruit_panel);
            this.fruit_panel.Controls.Add(this.super_fruit_text);
            this.fruit_panel.Controls.Add(this.super_fruit_panel);
            this.fruit_panel.Controls.Add(this.red_fruit_text);
            this.fruit_panel.Controls.Add(this.red_fruit_panel);
            this.fruit_panel.Controls.Add(this.fruit_name_text);
            this.fruit_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fruit_panel.Location = new System.Drawing.Point(0, 166);
            this.fruit_panel.Margin = new System.Windows.Forms.Padding(2);
            this.fruit_panel.Name = "fruit_panel";
            this.fruit_panel.Size = new System.Drawing.Size(526, 168);
            this.fruit_panel.TabIndex = 1;
            // 
            // cut_fruit_text
            // 
            this.cut_fruit_text.AutoEllipsis = true;
            this.cut_fruit_text.Location = new System.Drawing.Point(31, 122);
            this.cut_fruit_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cut_fruit_text.Name = "cut_fruit_text";
            this.cut_fruit_text.Size = new System.Drawing.Size(493, 42);
            this.cut_fruit_text.TabIndex = 8;
            this.cut_fruit_text.Text = "ядовитый фрукт, при употреблении отнимает 3 очка и уменьшает хвост змеи на 5";
            this.cut_fruit_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cut_fruit_panel
            // 
            this.cut_fruit_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(195)))), ((int)(((byte)(123)))));
            this.cut_fruit_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cut_fruit_panel.Location = new System.Drawing.Point(3, 122);
            this.cut_fruit_panel.Margin = new System.Windows.Forms.Padding(2);
            this.cut_fruit_panel.Name = "cut_fruit_panel";
            this.cut_fruit_panel.Size = new System.Drawing.Size(25, 25);
            this.cut_fruit_panel.TabIndex = 7;
            // 
            // super_puper_fruit_text
            // 
            this.super_puper_fruit_text.AutoEllipsis = true;
            this.super_puper_fruit_text.Location = new System.Drawing.Point(32, 80);
            this.super_puper_fruit_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.super_puper_fruit_text.Name = "super_puper_fruit_text";
            this.super_puper_fruit_text.Size = new System.Drawing.Size(492, 42);
            this.super_puper_fruit_text.TabIndex = 6;
            this.super_puper_fruit_text.Text = "искаженный фрукт, при употреблении добавляет 2 очка и позволяет телепортироваться" +
    " к курсору мыши";
            this.super_puper_fruit_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.super_puper_fruit_text.MouseEnter += new System.EventHandler(this.Super_puper_fruit_panel_MouseEnter);
            this.super_puper_fruit_text.MouseLeave += new System.EventHandler(this.Super_puper_fruit_panel_MouseLeave);
            // 
            // super_puper_fruit_panel
            // 
            this.super_puper_fruit_panel.BackColor = System.Drawing.Color.Navy;
            this.super_puper_fruit_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.super_puper_fruit_panel.Location = new System.Drawing.Point(3, 80);
            this.super_puper_fruit_panel.Margin = new System.Windows.Forms.Padding(2);
            this.super_puper_fruit_panel.Name = "super_puper_fruit_panel";
            this.super_puper_fruit_panel.Size = new System.Drawing.Size(25, 25);
            this.super_puper_fruit_panel.TabIndex = 5;
            this.super_puper_fruit_panel.MouseEnter += new System.EventHandler(this.Super_puper_fruit_panel_MouseEnter);
            this.super_puper_fruit_panel.MouseLeave += new System.EventHandler(this.Super_puper_fruit_panel_MouseLeave);
            // 
            // super_fruit_text
            // 
            this.super_fruit_text.AutoEllipsis = true;
            this.super_fruit_text.Location = new System.Drawing.Point(32, 51);
            this.super_fruit_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.super_fruit_text.Name = "super_fruit_text";
            this.super_fruit_text.Size = new System.Drawing.Size(492, 25);
            this.super_fruit_text.TabIndex = 4;
            this.super_fruit_text.Text = "супер фрукт, при употреблении добавляет 10 очков";
            this.super_fruit_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // super_fruit_panel
            // 
            this.super_fruit_panel.BackColor = System.Drawing.Color.Purple;
            this.super_fruit_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.super_fruit_panel.Location = new System.Drawing.Point(3, 51);
            this.super_fruit_panel.Margin = new System.Windows.Forms.Padding(2);
            this.super_fruit_panel.Name = "super_fruit_panel";
            this.super_fruit_panel.Size = new System.Drawing.Size(25, 25);
            this.super_fruit_panel.TabIndex = 3;
            // 
            // red_fruit_text
            // 
            this.red_fruit_text.AutoEllipsis = true;
            this.red_fruit_text.Location = new System.Drawing.Point(32, 22);
            this.red_fruit_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.red_fruit_text.Name = "red_fruit_text";
            this.red_fruit_text.Size = new System.Drawing.Size(493, 25);
            this.red_fruit_text.TabIndex = 2;
            this.red_fruit_text.Text = "обычный фрукт, при употреблении добавляет 1 очко";
            this.red_fruit_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // red_fruit_panel
            // 
            this.red_fruit_panel.BackColor = System.Drawing.Color.Tomato;
            this.red_fruit_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.red_fruit_panel.Location = new System.Drawing.Point(3, 22);
            this.red_fruit_panel.Margin = new System.Windows.Forms.Padding(2);
            this.red_fruit_panel.Name = "red_fruit_panel";
            this.red_fruit_panel.Size = new System.Drawing.Size(25, 25);
            this.red_fruit_panel.TabIndex = 1;
            // 
            // fruit_name_text
            // 
            this.fruit_name_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.fruit_name_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fruit_name_text.Location = new System.Drawing.Point(0, 0);
            this.fruit_name_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fruit_name_text.Name = "fruit_name_text";
            this.fruit_name_text.Size = new System.Drawing.Size(524, 20);
            this.fruit_name_text.TabIndex = 0;
            this.fruit_name_text.Text = "Виды фруктов:";
            this.fruit_name_text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.AutoSize = true;
            this.ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ok.Location = new System.Drawing.Point(431, 337);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(95, 41);
            this.ok.TabIndex = 26;
            this.ok.TabStop = false;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // SG_about
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 381);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.fruit_panel);
            this.Controls.Add(this.control_panel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SG_about";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Правила игры";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SG_about_Load);
            this.control_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.control_pic)).EndInit();
            this.fruit_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel control_panel;
        private System.Windows.Forms.PictureBox control_pic;
        private System.Windows.Forms.Label control_text;
        private System.Windows.Forms.Panel fruit_panel;
        private System.Windows.Forms.Label fruit_name_text;
        private System.Windows.Forms.Panel red_fruit_panel;
        private System.Windows.Forms.Label red_fruit_text;
        private System.Windows.Forms.Label super_fruit_text;
        private System.Windows.Forms.Panel super_fruit_panel;
        private System.Windows.Forms.Label super_puper_fruit_text;
        private System.Windows.Forms.Panel super_puper_fruit_panel;
        private System.Windows.Forms.Label cut_fruit_text;
        private System.Windows.Forms.Panel cut_fruit_panel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label control_space;
    }
}