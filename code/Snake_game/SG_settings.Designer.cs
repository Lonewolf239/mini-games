namespace minigames.Snake_game
{
    partial class SG_settings
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
            this.size_text = new System.Windows.Forms.Label();
            this.size_list = new System.Windows.Forms.ComboBox();
            this.speed_text = new System.Windows.Forms.Label();
            this.speed_list = new System.Windows.Forms.ComboBox();
            this.walls_killing = new System.Windows.Forms.CheckBox();
            this.accept_button = new System.Windows.Forms.Button();
            this.style_list = new System.Windows.Forms.ComboBox();
            this.style_text = new System.Windows.Forms.Label();
            this.dark_theme = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // size_text
            // 
            this.size_text.AutoSize = true;
            this.size_text.Location = new System.Drawing.Point(0, 3);
            this.size_text.Name = "size_text";
            this.size_text.Size = new System.Drawing.Size(129, 24);
            this.size_text.TabIndex = 0;
            this.size_text.Text = "Размер поля:";
            // 
            // size_list
            // 
            this.size_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.size_list.FormattingEnabled = true;
            this.size_list.Items.AddRange(new object[] {
            "Большой",
            "Средний",
            "Маленький"});
            this.size_list.Location = new System.Drawing.Point(135, 0);
            this.size_list.Name = "size_list";
            this.size_list.Size = new System.Drawing.Size(157, 32);
            this.size_list.TabIndex = 1;
            this.size_list.TabStop = false;
            this.size_list.SelectedIndexChanged += new System.EventHandler(this.Size_list_SelectedIndexChanged);
            // 
            // speed_text
            // 
            this.speed_text.AutoSize = true;
            this.speed_text.Location = new System.Drawing.Point(0, 41);
            this.speed_text.Name = "speed_text";
            this.speed_text.Size = new System.Drawing.Size(101, 24);
            this.speed_text.TabIndex = 2;
            this.speed_text.Text = "Скорость:";
            // 
            // speed_list
            // 
            this.speed_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speed_list.FormattingEnabled = true;
            this.speed_list.Items.AddRange(new object[] {
            "Большая",
            "Средняя",
            "Маленькая"});
            this.speed_list.Location = new System.Drawing.Point(135, 38);
            this.speed_list.Name = "speed_list";
            this.speed_list.Size = new System.Drawing.Size(157, 32);
            this.speed_list.TabIndex = 3;
            this.speed_list.TabStop = false;
            this.speed_list.SelectedIndexChanged += new System.EventHandler(this.Speed_list_SelectedIndexChanged);
            // 
            // walls_killing
            // 
            this.walls_killing.AutoSize = true;
            this.walls_killing.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.walls_killing.Location = new System.Drawing.Point(0, 146);
            this.walls_killing.Name = "walls_killing";
            this.walls_killing.Size = new System.Drawing.Size(168, 28);
            this.walls_killing.TabIndex = 4;
            this.walls_killing.TabStop = false;
            this.walls_killing.Text = "Стены убивают";
            this.walls_killing.UseVisualStyleBackColor = true;
            this.walls_killing.CheckedChanged += new System.EventHandler(this.Walls_killing_CheckedChanged);
            // 
            // accept_button
            // 
            this.accept_button.AutoSize = true;
            this.accept_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accept_button.Location = new System.Drawing.Point(180, 141);
            this.accept_button.Name = "accept_button";
            this.accept_button.Size = new System.Drawing.Size(124, 36);
            this.accept_button.TabIndex = 5;
            this.accept_button.TabStop = false;
            this.accept_button.Text = "Применить";
            this.accept_button.UseVisualStyleBackColor = true;
            this.accept_button.Click += new System.EventHandler(this.Accept_button_Click);
            // 
            // style_list
            // 
            this.style_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.style_list.FormattingEnabled = true;
            this.style_list.Items.AddRange(new object[] {
            "Классический",
            "Границы",
            "3D"});
            this.style_list.Location = new System.Drawing.Point(135, 76);
            this.style_list.Name = "style_list";
            this.style_list.Size = new System.Drawing.Size(157, 32);
            this.style_list.TabIndex = 6;
            this.style_list.TabStop = false;
            this.style_list.SelectedIndexChanged += new System.EventHandler(this.Style_list_SelectedIndexChanged);
            // 
            // style_text
            // 
            this.style_text.AutoSize = true;
            this.style_text.Location = new System.Drawing.Point(0, 79);
            this.style_text.Name = "style_text";
            this.style_text.Size = new System.Drawing.Size(70, 24);
            this.style_text.TabIndex = 7;
            this.style_text.Text = "Стиль:";
            // 
            // dark_theme
            // 
            this.dark_theme.AutoSize = true;
            this.dark_theme.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dark_theme.Location = new System.Drawing.Point(0, 114);
            this.dark_theme.Name = "dark_theme";
            this.dark_theme.Size = new System.Drawing.Size(145, 28);
            this.dark_theme.TabIndex = 9;
            this.dark_theme.TabStop = false;
            this.dark_theme.Text = "Тёмная тема";
            this.dark_theme.UseVisualStyleBackColor = true;
            this.dark_theme.CheckedChanged += new System.EventHandler(this.Dark_theme_CheckedChanged);
            // 
            // SG_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 177);
            this.Controls.Add(this.dark_theme);
            this.Controls.Add(this.style_text);
            this.Controls.Add(this.style_list);
            this.Controls.Add(this.accept_button);
            this.Controls.Add(this.walls_killing);
            this.Controls.Add(this.speed_list);
            this.Controls.Add(this.speed_text);
            this.Controls.Add(this.size_list);
            this.Controls.Add(this.size_text);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SG_settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SG_settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label size_text;
        private System.Windows.Forms.ComboBox size_list;
        private System.Windows.Forms.Label speed_text;
        private System.Windows.Forms.ComboBox speed_list;
        private System.Windows.Forms.CheckBox walls_killing;
        private System.Windows.Forms.Button accept_button;
        private System.Windows.Forms.ComboBox style_list;
        private System.Windows.Forms.Label style_text;
        private System.Windows.Forms.CheckBox dark_theme;
    }
}