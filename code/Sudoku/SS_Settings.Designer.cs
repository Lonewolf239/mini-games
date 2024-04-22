namespace minigames._Sudoku
{
    partial class SS_Settings
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
            this.difficulty_list = new System.Windows.Forms.ComboBox();
            this.difficulty_text = new System.Windows.Forms.Label();
            this.disable_prefill = new System.Windows.Forms.CheckBox();
            this.death_timer = new System.Windows.Forms.CheckBox();
            this.accept_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // difficulty_list
            // 
            this.difficulty_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficulty_list.FormattingEnabled = true;
            this.difficulty_list.Items.AddRange(new object[] {
            "Сложно",
            "Нормально",
            "Легко"});
            this.difficulty_list.Location = new System.Drawing.Point(171, 0);
            this.difficulty_list.Name = "difficulty_list";
            this.difficulty_list.Size = new System.Drawing.Size(170, 32);
            this.difficulty_list.TabIndex = 3;
            this.difficulty_list.TabStop = false;
            this.difficulty_list.SelectedIndexChanged += new System.EventHandler(this.Difficulty_list_SelectedIndexChanged);
            // 
            // difficulty_text
            // 
            this.difficulty_text.AutoSize = true;
            this.difficulty_text.Location = new System.Drawing.Point(0, 3);
            this.difficulty_text.Name = "difficulty_text";
            this.difficulty_text.Size = new System.Drawing.Size(165, 24);
            this.difficulty_text.TabIndex = 2;
            this.difficulty_text.Text = "Сложность игры:";
            // 
            // disable_prefill
            // 
            this.disable_prefill.AutoSize = true;
            this.disable_prefill.Checked = true;
            this.disable_prefill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disable_prefill.Location = new System.Drawing.Point(4, 38);
            this.disable_prefill.Name = "disable_prefill";
            this.disable_prefill.Size = new System.Drawing.Size(337, 28);
            this.disable_prefill.TabIndex = 5;
            this.disable_prefill.Text = "Автоматическое предзаполнение";
            this.disable_prefill.UseVisualStyleBackColor = true;
            this.disable_prefill.CheckedChanged += new System.EventHandler(this.Disable_prefill_CheckedChanged);
            // 
            // death_timer
            // 
            this.death_timer.AutoSize = true;
            this.death_timer.Location = new System.Drawing.Point(4, 72);
            this.death_timer.Name = "death_timer";
            this.death_timer.Size = new System.Drawing.Size(205, 28);
            this.death_timer.TabIndex = 6;
            this.death_timer.Text = "Гонки со временем";
            this.death_timer.UseVisualStyleBackColor = true;
            this.death_timer.CheckedChanged += new System.EventHandler(this.Death_timer_CheckedChanged);
            // 
            // accept_button
            // 
            this.accept_button.AutoSize = true;
            this.accept_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accept_button.Location = new System.Drawing.Point(217, 67);
            this.accept_button.Name = "accept_button";
            this.accept_button.Size = new System.Drawing.Size(124, 36);
            this.accept_button.TabIndex = 7;
            this.accept_button.TabStop = false;
            this.accept_button.Text = "Применить";
            this.accept_button.UseVisualStyleBackColor = true;
            this.accept_button.Click += new System.EventHandler(this.Accept_button_Click);
            // 
            // SS_Settings
            // 
            this.AcceptButton = this.accept_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 103);
            this.Controls.Add(this.accept_button);
            this.Controls.Add(this.death_timer);
            this.Controls.Add(this.disable_prefill);
            this.Controls.Add(this.difficulty_list);
            this.Controls.Add(this.difficulty_text);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SS_Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SS_Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox difficulty_list;
        private System.Windows.Forms.Label difficulty_text;
        private System.Windows.Forms.CheckBox disable_prefill;
        private System.Windows.Forms.CheckBox death_timer;
        private System.Windows.Forms.Button accept_button;
    }
}