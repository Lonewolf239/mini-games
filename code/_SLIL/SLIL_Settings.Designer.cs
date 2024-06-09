namespace minigames._SLIL
{
    partial class SLIL_Settings
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
            this.look_speed_text = new System.Windows.Forms.Label();
            this.look_speed = new System.Windows.Forms.TrackBar();
            this.difficulty_text = new System.Windows.Forms.Label();
            this.difficulty_list = new System.Windows.Forms.ComboBox();
            this.show_finish = new System.Windows.Forms.CheckBox();
            this.width_map_input = new System.Windows.Forms.NumericUpDown();
            this.height_map_text = new System.Windows.Forms.Label();
            this.width_map_text = new System.Windows.Forms.Label();
            this.height_map_input = new System.Windows.Forms.NumericUpDown();
            this.reset_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.look_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width_map_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height_map_input)).BeginInit();
            this.SuspendLayout();
            // 
            // look_speed_text
            // 
            this.look_speed_text.AutoSize = true;
            this.look_speed_text.Location = new System.Drawing.Point(3, 21);
            this.look_speed_text.Name = "look_speed_text";
            this.look_speed_text.Size = new System.Drawing.Size(178, 24);
            this.look_speed_text.TabIndex = 0;
            this.look_speed_text.Text = "Чувствительность";
            this.look_speed_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // look_speed
            // 
            this.look_speed.Location = new System.Drawing.Point(187, 12);
            this.look_speed.Maximum = 450;
            this.look_speed.Minimum = 100;
            this.look_speed.Name = "look_speed";
            this.look_speed.Size = new System.Drawing.Size(131, 45);
            this.look_speed.TabIndex = 1;
            this.look_speed.TabStop = false;
            this.look_speed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.look_speed.Value = 175;
            this.look_speed.Scroll += new System.EventHandler(this.Look_speed_Scroll);
            this.look_speed.Enter += new System.EventHandler(this.Look_speed_Enter);
            this.look_speed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Look_speed_MouseUp);
            // 
            // difficulty_text
            // 
            this.difficulty_text.AutoSize = true;
            this.difficulty_text.Location = new System.Drawing.Point(3, 69);
            this.difficulty_text.Name = "difficulty_text";
            this.difficulty_text.Size = new System.Drawing.Size(111, 24);
            this.difficulty_text.TabIndex = 2;
            this.difficulty_text.Text = "Сложность";
            this.difficulty_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // difficulty_list
            // 
            this.difficulty_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficulty_list.FormattingEnabled = true;
            this.difficulty_list.Items.AddRange(new object[] {
            "Очень сложно",
            "Сложно",
            "Нормально",
            "Легко",
            "Custom"});
            this.difficulty_list.Location = new System.Drawing.Point(161, 66);
            this.difficulty_list.Name = "difficulty_list";
            this.difficulty_list.Size = new System.Drawing.Size(157, 32);
            this.difficulty_list.TabIndex = 3;
            this.difficulty_list.TabStop = false;
            this.difficulty_list.SelectedIndexChanged += new System.EventHandler(this.Difficulty_list_SelectedIndexChanged);
            // 
            // show_finish
            // 
            this.show_finish.AutoSize = true;
            this.show_finish.Location = new System.Drawing.Point(7, 104);
            this.show_finish.Name = "show_finish";
            this.show_finish.Size = new System.Drawing.Size(208, 28);
            this.show_finish.TabIndex = 4;
            this.show_finish.TabStop = false;
            this.show_finish.Text = "Отображать финиш";
            this.show_finish.UseVisualStyleBackColor = true;
            // 
            // width_map_input
            // 
            this.width_map_input.Location = new System.Drawing.Point(94, 184);
            this.width_map_input.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.width_map_input.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.width_map_input.Name = "width_map_input";
            this.width_map_input.Size = new System.Drawing.Size(120, 29);
            this.width_map_input.TabIndex = 5;
            this.width_map_input.TabStop = false;
            this.width_map_input.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // height_map_text
            // 
            this.height_map_text.AutoSize = true;
            this.height_map_text.Location = new System.Drawing.Point(12, 151);
            this.height_map_text.Name = "height_map_text";
            this.height_map_text.Size = new System.Drawing.Size(76, 24);
            this.height_map_text.TabIndex = 6;
            this.height_map_text.Text = "Высота";
            this.height_map_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // width_map_text
            // 
            this.width_map_text.AutoSize = true;
            this.width_map_text.Location = new System.Drawing.Point(12, 186);
            this.width_map_text.Name = "width_map_text";
            this.width_map_text.Size = new System.Drawing.Size(78, 24);
            this.width_map_text.TabIndex = 7;
            this.width_map_text.Text = "Ширина";
            this.width_map_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // height_map_input
            // 
            this.height_map_input.Location = new System.Drawing.Point(94, 149);
            this.height_map_input.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.height_map_input.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.height_map_input.Name = "height_map_input";
            this.height_map_input.Size = new System.Drawing.Size(120, 29);
            this.height_map_input.TabIndex = 8;
            this.height_map_input.TabStop = false;
            this.height_map_input.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // reset_btn
            // 
            this.reset_btn.AutoSize = true;
            this.reset_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset_btn.Location = new System.Drawing.Point(240, 102);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(78, 36);
            this.reset_btn.TabIndex = 9;
            this.reset_btn.TabStop = false;
            this.reset_btn.Text = "Сброс";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.Reset_btn_Click);
            // 
            // SLIL_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 233);
            this.Controls.Add(this.reset_btn);
            this.Controls.Add(this.height_map_input);
            this.Controls.Add(this.width_map_text);
            this.Controls.Add(this.height_map_text);
            this.Controls.Add(this.width_map_input);
            this.Controls.Add(this.show_finish);
            this.Controls.Add(this.difficulty_list);
            this.Controls.Add(this.difficulty_text);
            this.Controls.Add(this.look_speed);
            this.Controls.Add(this.look_speed_text);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SLIL_Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SLIL_Settings_FormClosing);
            this.Load += new System.EventHandler(this.SLIL_Settings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SLIL_Settings_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.look_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.width_map_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.height_map_input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label look_speed_text;
        private System.Windows.Forms.TrackBar look_speed;
        private System.Windows.Forms.Label difficulty_text;
        private System.Windows.Forms.ComboBox difficulty_list;
        private System.Windows.Forms.CheckBox show_finish;
        private System.Windows.Forms.NumericUpDown width_map_input;
        private System.Windows.Forms.Label height_map_text;
        private System.Windows.Forms.NumericUpDown height_map_input;
        private System.Windows.Forms.Label width_map_text;
        private System.Windows.Forms.Button reset_btn;
    }
}