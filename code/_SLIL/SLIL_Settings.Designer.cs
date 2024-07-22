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
            this.width_map_input = new System.Windows.Forms.NumericUpDown();
            this.height_map_text = new System.Windows.Forms.Label();
            this.width_map_text = new System.Windows.Forms.Label();
            this.height_map_input = new System.Windows.Forms.NumericUpDown();
            this.show_fps = new System.Windows.Forms.CheckBox();
            this.scope_color_list = new System.Windows.Forms.ComboBox();
            this.scope_color_text = new System.Windows.Forms.Label();
            this.editor_btn = new System.Windows.Forms.Button();
            this.scope_type_list = new System.Windows.Forms.ComboBox();
            this.scope_type_text = new System.Windows.Forms.Label();
            this.resolution = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.look_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width_map_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height_map_input)).BeginInit();
            this.SuspendLayout();
            // 
            // look_speed_text
            // 
            this.look_speed_text.AutoSize = true;
            this.look_speed_text.Location = new System.Drawing.Point(12, 180);
            this.look_speed_text.Name = "look_speed_text";
            this.look_speed_text.Size = new System.Drawing.Size(178, 24);
            this.look_speed_text.TabIndex = 0;
            this.look_speed_text.Text = "Чувствительность";
            this.look_speed_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // look_speed
            // 
            this.look_speed.Location = new System.Drawing.Point(196, 171);
            this.look_speed.Maximum = 1000;
            this.look_speed.Minimum = 250;
            this.look_speed.Name = "look_speed";
            this.look_speed.Size = new System.Drawing.Size(131, 45);
            this.look_speed.TabIndex = 1;
            this.look_speed.TabStop = false;
            this.look_speed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.look_speed.Value = 275;
            this.look_speed.Scroll += new System.EventHandler(this.Look_speed_Scroll);
            this.look_speed.Enter += new System.EventHandler(this.Look_speed_Enter);
            this.look_speed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Look_speed_MouseUp);
            // 
            // difficulty_text
            // 
            this.difficulty_text.AutoSize = true;
            this.difficulty_text.Location = new System.Drawing.Point(12, 15);
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
            this.difficulty_list.Location = new System.Drawing.Point(129, 12);
            this.difficulty_list.Name = "difficulty_list";
            this.difficulty_list.Size = new System.Drawing.Size(157, 32);
            this.difficulty_list.TabIndex = 3;
            this.difficulty_list.TabStop = false;
            this.difficulty_list.SelectedIndexChanged += new System.EventHandler(this.Difficulty_list_SelectedIndexChanged);
            // 
            // width_map_input
            // 
            this.width_map_input.Location = new System.Drawing.Point(94, 257);
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
            this.width_map_input.Size = new System.Drawing.Size(60, 29);
            this.width_map_input.TabIndex = 5;
            this.width_map_input.TabStop = false;
            this.width_map_input.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.width_map_input.ValueChanged += new System.EventHandler(this.Map_input_ValueChanged);
            // 
            // height_map_text
            // 
            this.height_map_text.AutoSize = true;
            this.height_map_text.Location = new System.Drawing.Point(10, 224);
            this.height_map_text.Name = "height_map_text";
            this.height_map_text.Size = new System.Drawing.Size(76, 24);
            this.height_map_text.TabIndex = 6;
            this.height_map_text.Text = "Высота";
            this.height_map_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // width_map_text
            // 
            this.width_map_text.AutoSize = true;
            this.width_map_text.Location = new System.Drawing.Point(10, 259);
            this.width_map_text.Name = "width_map_text";
            this.width_map_text.Size = new System.Drawing.Size(78, 24);
            this.width_map_text.TabIndex = 7;
            this.width_map_text.Text = "Ширина";
            this.width_map_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // height_map_input
            // 
            this.height_map_input.Location = new System.Drawing.Point(94, 222);
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
            this.height_map_input.Size = new System.Drawing.Size(60, 29);
            this.height_map_input.TabIndex = 8;
            this.height_map_input.TabStop = false;
            this.height_map_input.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.height_map_input.ValueChanged += new System.EventHandler(this.Map_input_ValueChanged);
            // 
            // show_fps
            // 
            this.show_fps.AutoSize = true;
            this.show_fps.Checked = true;
            this.show_fps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_fps.Location = new System.Drawing.Point(16, 149);
            this.show_fps.Name = "show_fps";
            this.show_fps.Size = new System.Drawing.Size(183, 28);
            this.show_fps.TabIndex = 11;
            this.show_fps.Text = "Отображать FPS";
            this.show_fps.UseVisualStyleBackColor = true;
            // 
            // scope_color_list
            // 
            this.scope_color_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scope_color_list.FormattingEnabled = true;
            this.scope_color_list.Items.AddRange(new object[] {
            "Зелёный",
            "Красный",
            "Жёлтый",
            "Синий",
            "Пурпурный",
            "Голубой",
            "Оранжевый",
            "Белый",
            "Случайный"});
            this.scope_color_list.Location = new System.Drawing.Point(154, 88);
            this.scope_color_list.Name = "scope_color_list";
            this.scope_color_list.Size = new System.Drawing.Size(132, 32);
            this.scope_color_list.TabIndex = 12;
            this.scope_color_list.TabStop = false;
            // 
            // scope_color_text
            // 
            this.scope_color_text.AutoSize = true;
            this.scope_color_text.Location = new System.Drawing.Point(12, 91);
            this.scope_color_text.Name = "scope_color_text";
            this.scope_color_text.Size = new System.Drawing.Size(134, 24);
            this.scope_color_text.TabIndex = 13;
            this.scope_color_text.Text = "Цвет прицела";
            this.scope_color_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editor_btn
            // 
            this.editor_btn.BackgroundImage = global::minigames.Properties.Resources.editor;
            this.editor_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editor_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editor_btn.Location = new System.Drawing.Point(160, 229);
            this.editor_btn.Name = "editor_btn";
            this.editor_btn.Size = new System.Drawing.Size(50, 50);
            this.editor_btn.TabIndex = 10;
            this.editor_btn.TabStop = false;
            this.editor_btn.UseVisualStyleBackColor = true;
            this.editor_btn.EnabledChanged += new System.EventHandler(this.Editor_btn_EnabledChanged);
            this.editor_btn.Click += new System.EventHandler(this.Editor_btn_Click);
            // 
            // scope_type_list
            // 
            this.scope_type_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scope_type_list.FormattingEnabled = true;
            this.scope_type_list.Items.AddRange(new object[] {
            "Стандартный",
            "Крест",
            "Линия",
            "Точка",
            "Без прицела"});
            this.scope_type_list.Location = new System.Drawing.Point(129, 50);
            this.scope_type_list.Name = "scope_type_list";
            this.scope_type_list.Size = new System.Drawing.Size(157, 32);
            this.scope_type_list.TabIndex = 14;
            this.scope_type_list.TabStop = false;
            // 
            // scope_type_text
            // 
            this.scope_type_text.AutoSize = true;
            this.scope_type_text.Location = new System.Drawing.Point(12, 53);
            this.scope_type_text.Name = "scope_type_text";
            this.scope_type_text.Size = new System.Drawing.Size(77, 24);
            this.scope_type_text.TabIndex = 15;
            this.scope_type_text.Text = "Прицел";
            this.scope_type_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resolution
            // 
            this.resolution.AutoSize = true;
            this.resolution.Checked = true;
            this.resolution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.resolution.Location = new System.Drawing.Point(16, 121);
            this.resolution.Name = "resolution";
            this.resolution.Size = new System.Drawing.Size(222, 28);
            this.resolution.TabIndex = 16;
            this.resolution.Text = "Высокое разрешение";
            this.resolution.UseVisualStyleBackColor = true;
            // 
            // SLIL_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 300);
            this.Controls.Add(this.resolution);
            this.Controls.Add(this.scope_type_text);
            this.Controls.Add(this.scope_type_list);
            this.Controls.Add(this.scope_color_text);
            this.Controls.Add(this.scope_color_list);
            this.Controls.Add(this.show_fps);
            this.Controls.Add(this.editor_btn);
            this.Controls.Add(this.height_map_input);
            this.Controls.Add(this.width_map_text);
            this.Controls.Add(this.height_map_text);
            this.Controls.Add(this.width_map_input);
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
        private System.Windows.Forms.Label height_map_text;
        private System.Windows.Forms.NumericUpDown height_map_input;
        private System.Windows.Forms.Label width_map_text;
        private System.Windows.Forms.Button editor_btn;
        private System.Windows.Forms.NumericUpDown width_map_input;
        private System.Windows.Forms.CheckBox show_fps;
        private System.Windows.Forms.ComboBox scope_color_list;
        private System.Windows.Forms.Label scope_color_text;
        private System.Windows.Forms.ComboBox scope_type_list;
        private System.Windows.Forms.Label scope_type_text;
        private System.Windows.Forms.CheckBox resolution;
    }
}