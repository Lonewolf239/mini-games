namespace minigames._Tetris
{
    partial class T_about
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(T_about));
            this.control_panel = new System.Windows.Forms.Panel();
            this.difficult_list = new System.Windows.Forms.ComboBox();
            this.difficult_text = new System.Windows.Forms.Label();
            this.control_space = new System.Windows.Forms.Label();
            this.control_pic = new System.Windows.Forms.PictureBox();
            this.control_text = new System.Windows.Forms.Label();
            this.rules_text = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.fruit_panel = new System.Windows.Forms.Panel();
            this.control_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.control_pic)).BeginInit();
            this.fruit_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // control_panel
            // 
            this.control_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.control_panel.Controls.Add(this.difficult_list);
            this.control_panel.Controls.Add(this.control_space);
            this.control_panel.Controls.Add(this.control_pic);
            this.control_panel.Controls.Add(this.difficult_text);
            this.control_panel.Controls.Add(this.control_text);
            this.control_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_panel.Location = new System.Drawing.Point(0, 0);
            this.control_panel.Margin = new System.Windows.Forms.Padding(2);
            this.control_panel.Name = "control_panel";
            this.control_panel.Size = new System.Drawing.Size(526, 162);
            this.control_panel.TabIndex = 1;
            // 
            // difficult_list
            // 
            this.difficult_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficult_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.difficult_list.FormattingEnabled = true;
            this.difficult_list.Items.AddRange(new object[] {
            "Легко",
            "Нормально",
            "Сложно"});
            this.difficult_list.Location = new System.Drawing.Point(318, 46);
            this.difficult_list.Name = "difficult_list";
            this.difficult_list.Size = new System.Drawing.Size(195, 28);
            this.difficult_list.TabIndex = 1;
            this.difficult_list.TabStop = false;
            this.difficult_list.SelectedIndexChanged += new System.EventHandler(this.Difficult_list_SelectedIndexChanged);
            // 
            // difficult_text
            // 
            this.difficult_text.AutoSize = true;
            this.difficult_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.difficult_text.Location = new System.Drawing.Point(226, 49);
            this.difficult_text.Name = "difficult_text";
            this.difficult_text.Size = new System.Drawing.Size(94, 20);
            this.difficult_text.TabIndex = 0;
            this.difficult_text.Text = "Сложность";
            // 
            // control_space
            // 
            this.control_space.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_space.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.control_space.Location = new System.Drawing.Point(221, 20);
            this.control_space.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.control_space.Name = "control_space";
            this.control_space.Size = new System.Drawing.Size(303, 20);
            this.control_space.TabIndex = 2;
            this.control_space.Text = "Для поворота фигуры нажмите: Space";
            this.control_space.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // control_pic
            // 
            this.control_pic.BackColor = System.Drawing.Color.White;
            this.control_pic.Dock = System.Windows.Forms.DockStyle.Left;
            this.control_pic.Image = global::minigames.Properties.Resources.t_control;
            this.control_pic.Location = new System.Drawing.Point(0, 20);
            this.control_pic.Margin = new System.Windows.Forms.Padding(2);
            this.control_pic.Name = "control_pic";
            this.control_pic.Size = new System.Drawing.Size(221, 140);
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
            // rules_text
            // 
            this.rules_text.AutoEllipsis = true;
            this.rules_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rules_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rules_text.Location = new System.Drawing.Point(0, 0);
            this.rules_text.Name = "rules_text";
            this.rules_text.Size = new System.Drawing.Size(524, 146);
            this.rules_text.TabIndex = 0;
            this.rules_text.Text = resources.GetString("rules_text.Text");
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.AutoSize = true;
            this.ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ok.Location = new System.Drawing.Point(430, 316);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(95, 41);
            this.ok.TabIndex = 27;
            this.ok.TabStop = false;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // fruit_panel
            // 
            this.fruit_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fruit_panel.Controls.Add(this.rules_text);
            this.fruit_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fruit_panel.Location = new System.Drawing.Point(0, 162);
            this.fruit_panel.Margin = new System.Windows.Forms.Padding(2);
            this.fruit_panel.Name = "fruit_panel";
            this.fruit_panel.Size = new System.Drawing.Size(526, 148);
            this.fruit_panel.TabIndex = 2;
            // 
            // T_about
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ok;
            this.ClientSize = new System.Drawing.Size(526, 361);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.fruit_panel);
            this.Controls.Add(this.control_panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "T_about";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Правила игры";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.About_Load);
            this.control_panel.ResumeLayout(false);
            this.control_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.control_pic)).EndInit();
            this.fruit_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel control_panel;
        private System.Windows.Forms.Label control_space;
        private System.Windows.Forms.PictureBox control_pic;
        private System.Windows.Forms.Label control_text;
        private System.Windows.Forms.Label rules_text;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Panel fruit_panel;
        private System.Windows.Forms.Label difficult_text;
        private System.Windows.Forms.ComboBox difficult_list;
    }
}