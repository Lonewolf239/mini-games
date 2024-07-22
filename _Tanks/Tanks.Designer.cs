namespace minigames._Tanks
{
    partial class Tanks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tanks));
            this.player1_timer = new System.Windows.Forms.Timer(this.components);
            this.player2_timer = new System.Windows.Forms.Timer(this.components);
            this.bullets_timer = new System.Windows.Forms.Timer(this.components);
            this.player1_hp_panel = new System.Windows.Forms.Panel();
            this.player1_hp3 = new System.Windows.Forms.Panel();
            this.player1_hp2 = new System.Windows.Forms.Panel();
            this.player1_hp1 = new System.Windows.Forms.Panel();
            this.player2_hp_panel = new System.Windows.Forms.Panel();
            this.player2_hp3 = new System.Windows.Forms.Panel();
            this.player2_hp2 = new System.Windows.Forms.Panel();
            this.player2_hp1 = new System.Windows.Forms.Panel();
            this.player1_reloading = new System.Windows.Forms.Timer(this.components);
            this.player2_reloading = new System.Windows.Forms.Timer(this.components);
            this.reloading1_background = new System.Windows.Forms.Panel();
            this.reloading1 = new System.Windows.Forms.Panel();
            this.reloading2_background = new System.Windows.Forms.Panel();
            this.reloading2 = new System.Windows.Forms.Panel();
            this.logic_timer = new System.Windows.Forms.Timer(this.components);
            this.game_interface = new System.Windows.Forms.Panel();
            this.ground_panel_1_water = new System.Windows.Forms.Panel();
            this.game_over_text = new System.Windows.Forms.Label();
            this.ground_panel_0 = new System.Windows.Forms.Panel();
            this.ground_panel_4 = new System.Windows.Forms.Panel();
            this.ground_panel_3 = new System.Windows.Forms.Panel();
            this.ground_panel_2 = new System.Windows.Forms.Panel();
            this.grass_panel_3 = new System.Windows.Forms.Panel();
            this.grass_panel_2 = new System.Windows.Forms.Panel();
            this.grass_panel_0 = new System.Windows.Forms.Panel();
            this.grass_panel_1 = new System.Windows.Forms.Panel();
            this.player1_tank = new System.Windows.Forms.PictureBox();
            this.player2_tank = new System.Windows.Forms.PictureBox();
            this.top_panel = new System.Windows.Forms.Panel();
            this.interface_panel = new System.Windows.Forms.Panel();
            this.player2_text = new System.Windows.Forms.Label();
            this.player1_text = new System.Windows.Forms.Label();
            this.start_btn = new System.Windows.Forms.Button();
            this.show_settings = new System.Windows.Forms.PictureBox();
            this.developer_name = new System.Windows.Forms.Label();
            this.player1_hp_panel.SuspendLayout();
            this.player2_hp_panel.SuspendLayout();
            this.reloading1_background.SuspendLayout();
            this.reloading2_background.SuspendLayout();
            this.game_interface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player1_tank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2_tank)).BeginInit();
            this.top_panel.SuspendLayout();
            this.interface_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_settings)).BeginInit();
            this.SuspendLayout();
            // 
            // player1_timer
            // 
            this.player1_timer.Interval = 12;
            this.player1_timer.Tick += new System.EventHandler(this.Player1_timer_Tick);
            // 
            // player2_timer
            // 
            this.player2_timer.Interval = 12;
            this.player2_timer.Tick += new System.EventHandler(this.Player2_timer_Tick);
            // 
            // bullets_timer
            // 
            this.bullets_timer.Interval = 25;
            this.bullets_timer.Tick += new System.EventHandler(this.Bullets_timer_Tick);
            // 
            // player1_hp_panel
            // 
            this.player1_hp_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.player1_hp_panel.Controls.Add(this.player1_hp3);
            this.player1_hp_panel.Controls.Add(this.player1_hp2);
            this.player1_hp_panel.Controls.Add(this.player1_hp1);
            this.player1_hp_panel.Location = new System.Drawing.Point(3, 6);
            this.player1_hp_panel.Name = "player1_hp_panel";
            this.player1_hp_panel.Size = new System.Drawing.Size(79, 29);
            this.player1_hp_panel.TabIndex = 3;
            // 
            // player1_hp3
            // 
            this.player1_hp3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player1_hp3.Dock = System.Windows.Forms.DockStyle.Left;
            this.player1_hp3.Location = new System.Drawing.Point(50, 0);
            this.player1_hp3.Name = "player1_hp3";
            this.player1_hp3.Size = new System.Drawing.Size(25, 25);
            this.player1_hp3.TabIndex = 6;
            // 
            // player1_hp2
            // 
            this.player1_hp2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player1_hp2.Dock = System.Windows.Forms.DockStyle.Left;
            this.player1_hp2.Location = new System.Drawing.Point(25, 0);
            this.player1_hp2.Name = "player1_hp2";
            this.player1_hp2.Size = new System.Drawing.Size(25, 25);
            this.player1_hp2.TabIndex = 5;
            // 
            // player1_hp1
            // 
            this.player1_hp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player1_hp1.Dock = System.Windows.Forms.DockStyle.Left;
            this.player1_hp1.Location = new System.Drawing.Point(0, 0);
            this.player1_hp1.Name = "player1_hp1";
            this.player1_hp1.Size = new System.Drawing.Size(25, 25);
            this.player1_hp1.TabIndex = 4;
            // 
            // player2_hp_panel
            // 
            this.player2_hp_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.player2_hp_panel.Controls.Add(this.player2_hp3);
            this.player2_hp_panel.Controls.Add(this.player2_hp2);
            this.player2_hp_panel.Controls.Add(this.player2_hp1);
            this.player2_hp_panel.Location = new System.Drawing.Point(430, 6);
            this.player2_hp_panel.Name = "player2_hp_panel";
            this.player2_hp_panel.Size = new System.Drawing.Size(79, 29);
            this.player2_hp_panel.TabIndex = 4;
            // 
            // player2_hp3
            // 
            this.player2_hp3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2_hp3.Dock = System.Windows.Forms.DockStyle.Left;
            this.player2_hp3.Location = new System.Drawing.Point(50, 0);
            this.player2_hp3.Name = "player2_hp3";
            this.player2_hp3.Size = new System.Drawing.Size(25, 25);
            this.player2_hp3.TabIndex = 6;
            // 
            // player2_hp2
            // 
            this.player2_hp2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2_hp2.Dock = System.Windows.Forms.DockStyle.Left;
            this.player2_hp2.Location = new System.Drawing.Point(25, 0);
            this.player2_hp2.Name = "player2_hp2";
            this.player2_hp2.Size = new System.Drawing.Size(25, 25);
            this.player2_hp2.TabIndex = 5;
            // 
            // player2_hp1
            // 
            this.player2_hp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2_hp1.Dock = System.Windows.Forms.DockStyle.Left;
            this.player2_hp1.Location = new System.Drawing.Point(0, 0);
            this.player2_hp1.Name = "player2_hp1";
            this.player2_hp1.Size = new System.Drawing.Size(25, 25);
            this.player2_hp1.TabIndex = 4;
            // 
            // player1_reloading
            // 
            this.player1_reloading.Interval = 1;
            this.player1_reloading.Tick += new System.EventHandler(this.Player1_reloading_Tick);
            // 
            // player2_reloading
            // 
            this.player2_reloading.Interval = 1;
            this.player2_reloading.Tick += new System.EventHandler(this.Player2_reloading_Tick);
            // 
            // reloading1_background
            // 
            this.reloading1_background.BackColor = System.Drawing.Color.Tomato;
            this.reloading1_background.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reloading1_background.Controls.Add(this.reloading1);
            this.reloading1_background.Location = new System.Drawing.Point(3, 39);
            this.reloading1_background.Name = "reloading1_background";
            this.reloading1_background.Size = new System.Drawing.Size(200, 13);
            this.reloading1_background.TabIndex = 5;
            // 
            // reloading1
            // 
            this.reloading1.BackColor = System.Drawing.Color.Lime;
            this.reloading1.Dock = System.Windows.Forms.DockStyle.Left;
            this.reloading1.Location = new System.Drawing.Point(0, 0);
            this.reloading1.Name = "reloading1";
            this.reloading1.Size = new System.Drawing.Size(0, 9);
            this.reloading1.TabIndex = 7;
            // 
            // reloading2_background
            // 
            this.reloading2_background.BackColor = System.Drawing.Color.Tomato;
            this.reloading2_background.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reloading2_background.Controls.Add(this.reloading2);
            this.reloading2_background.Location = new System.Drawing.Point(309, 39);
            this.reloading2_background.Name = "reloading2_background";
            this.reloading2_background.Size = new System.Drawing.Size(200, 13);
            this.reloading2_background.TabIndex = 6;
            // 
            // reloading2
            // 
            this.reloading2.BackColor = System.Drawing.Color.Lime;
            this.reloading2.Dock = System.Windows.Forms.DockStyle.Right;
            this.reloading2.Location = new System.Drawing.Point(196, 0);
            this.reloading2.Name = "reloading2";
            this.reloading2.Size = new System.Drawing.Size(0, 9);
            this.reloading2.TabIndex = 8;
            // 
            // logic_timer
            // 
            this.logic_timer.Interval = 1;
            this.logic_timer.Tick += new System.EventHandler(this.Logic_timer_Tick);
            // 
            // game_interface
            // 
            this.game_interface.BackColor = System.Drawing.Color.LightGray;
            this.game_interface.Controls.Add(this.ground_panel_1_water);
            this.game_interface.Controls.Add(this.game_over_text);
            this.game_interface.Controls.Add(this.ground_panel_0);
            this.game_interface.Controls.Add(this.ground_panel_4);
            this.game_interface.Controls.Add(this.ground_panel_3);
            this.game_interface.Controls.Add(this.ground_panel_2);
            this.game_interface.Controls.Add(this.grass_panel_3);
            this.game_interface.Controls.Add(this.grass_panel_2);
            this.game_interface.Controls.Add(this.grass_panel_0);
            this.game_interface.Controls.Add(this.grass_panel_1);
            this.game_interface.Controls.Add(this.player1_tank);
            this.game_interface.Controls.Add(this.player2_tank);
            this.game_interface.Dock = System.Windows.Forms.DockStyle.Top;
            this.game_interface.Location = new System.Drawing.Point(0, 0);
            this.game_interface.Name = "game_interface";
            this.game_interface.Size = new System.Drawing.Size(512, 271);
            this.game_interface.TabIndex = 8;
            // 
            // ground_panel_1_water
            // 
            this.ground_panel_1_water.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ground_panel_1_water.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ground_panel_1_water.Location = new System.Drawing.Point(0, 0);
            this.ground_panel_1_water.Margin = new System.Windows.Forms.Padding(0);
            this.ground_panel_1_water.Name = "ground_panel_1_water";
            this.ground_panel_1_water.Size = new System.Drawing.Size(512, 50);
            this.ground_panel_1_water.TabIndex = 5;
            this.ground_panel_1_water.Visible = false;
            // 
            // game_over_text
            // 
            this.game_over_text.AutoSize = true;
            this.game_over_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.game_over_text.Location = new System.Drawing.Point(501, 226);
            this.game_over_text.Name = "game_over_text";
            this.game_over_text.Size = new System.Drawing.Size(132, 42);
            this.game_over_text.TabIndex = 11;
            this.game_over_text.Text = "DRAW";
            this.game_over_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.game_over_text.Visible = false;
            // 
            // ground_panel_0
            // 
            this.ground_panel_0.BackColor = System.Drawing.Color.Black;
            this.ground_panel_0.Location = new System.Drawing.Point(376, 50);
            this.ground_panel_0.Margin = new System.Windows.Forms.Padding(0);
            this.ground_panel_0.Name = "ground_panel_0";
            this.ground_panel_0.Size = new System.Drawing.Size(29, 69);
            this.ground_panel_0.TabIndex = 2;
            this.ground_panel_0.Visible = false;
            // 
            // ground_panel_4
            // 
            this.ground_panel_4.BackColor = System.Drawing.Color.Black;
            this.ground_panel_4.Location = new System.Drawing.Point(229, 119);
            this.ground_panel_4.Margin = new System.Windows.Forms.Padding(0);
            this.ground_panel_4.Name = "ground_panel_4";
            this.ground_panel_4.Size = new System.Drawing.Size(25, 43);
            this.ground_panel_4.TabIndex = 10;
            this.ground_panel_4.Visible = false;
            // 
            // ground_panel_3
            // 
            this.ground_panel_3.BackColor = System.Drawing.Color.Black;
            this.ground_panel_3.Location = new System.Drawing.Point(78, 228);
            this.ground_panel_3.Margin = new System.Windows.Forms.Padding(0);
            this.ground_panel_3.Name = "ground_panel_3";
            this.ground_panel_3.Size = new System.Drawing.Size(25, 43);
            this.ground_panel_3.TabIndex = 9;
            this.ground_panel_3.Visible = false;
            // 
            // ground_panel_2
            // 
            this.ground_panel_2.BackColor = System.Drawing.Color.Black;
            this.ground_panel_2.Location = new System.Drawing.Point(376, 162);
            this.ground_panel_2.Margin = new System.Windows.Forms.Padding(0);
            this.ground_panel_2.Name = "ground_panel_2";
            this.ground_panel_2.Size = new System.Drawing.Size(29, 66);
            this.ground_panel_2.TabIndex = 7;
            this.ground_panel_2.Visible = false;
            // 
            // grass_panel_3
            // 
            this.grass_panel_3.BackColor = System.Drawing.Color.Green;
            this.grass_panel_3.Location = new System.Drawing.Point(137, 228);
            this.grass_panel_3.Margin = new System.Windows.Forms.Padding(0);
            this.grass_panel_3.Name = "grass_panel_3";
            this.grass_panel_3.Size = new System.Drawing.Size(268, 43);
            this.grass_panel_3.TabIndex = 8;
            this.grass_panel_3.Visible = false;
            // 
            // grass_panel_2
            // 
            this.grass_panel_2.BackColor = System.Drawing.Color.Green;
            this.grass_panel_2.Location = new System.Drawing.Point(0, 162);
            this.grass_panel_2.Margin = new System.Windows.Forms.Padding(0);
            this.grass_panel_2.Name = "grass_panel_2";
            this.grass_panel_2.Size = new System.Drawing.Size(376, 66);
            this.grass_panel_2.TabIndex = 6;
            this.grass_panel_2.Visible = false;
            // 
            // grass_panel_0
            // 
            this.grass_panel_0.BackColor = System.Drawing.Color.Green;
            this.grass_panel_0.Location = new System.Drawing.Point(269, 119);
            this.grass_panel_0.Margin = new System.Windows.Forms.Padding(0);
            this.grass_panel_0.Name = "grass_panel_0";
            this.grass_panel_0.Size = new System.Drawing.Size(136, 43);
            this.grass_panel_0.TabIndex = 3;
            this.grass_panel_0.Visible = false;
            // 
            // grass_panel_1
            // 
            this.grass_panel_1.BackColor = System.Drawing.Color.Green;
            this.grass_panel_1.Location = new System.Drawing.Point(0, 50);
            this.grass_panel_1.Margin = new System.Windows.Forms.Padding(0);
            this.grass_panel_1.Name = "grass_panel_1";
            this.grass_panel_1.Size = new System.Drawing.Size(376, 69);
            this.grass_panel_1.TabIndex = 4;
            this.grass_panel_1.Visible = false;
            // 
            // player1_tank
            // 
            this.player1_tank.Image = global::minigames.Properties.Resources.tank_pl1;
            this.player1_tank.Location = new System.Drawing.Point(26, 233);
            this.player1_tank.Margin = new System.Windows.Forms.Padding(0);
            this.player1_tank.Name = "player1_tank";
            this.player1_tank.Size = new System.Drawing.Size(35, 35);
            this.player1_tank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player1_tank.TabIndex = 0;
            this.player1_tank.TabStop = false;
            this.player1_tank.Visible = false;
            // 
            // player2_tank
            // 
            this.player2_tank.Image = global::minigames.Properties.Resources.tank_pl2;
            this.player2_tank.Location = new System.Drawing.Point(448, 122);
            this.player2_tank.Margin = new System.Windows.Forms.Padding(0);
            this.player2_tank.Name = "player2_tank";
            this.player2_tank.Size = new System.Drawing.Size(35, 35);
            this.player2_tank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player2_tank.TabIndex = 1;
            this.player2_tank.TabStop = false;
            this.player2_tank.Visible = false;
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.Gainsboro;
            this.top_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.top_panel.Controls.Add(this.interface_panel);
            this.top_panel.Controls.Add(this.game_interface);
            this.top_panel.Location = new System.Drawing.Point(12, 12);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(516, 330);
            this.top_panel.TabIndex = 9;
            // 
            // interface_panel
            // 
            this.interface_panel.BackColor = System.Drawing.Color.Gainsboro;
            this.interface_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.interface_panel.Controls.Add(this.player2_text);
            this.interface_panel.Controls.Add(this.player1_text);
            this.interface_panel.Controls.Add(this.player1_hp_panel);
            this.interface_panel.Controls.Add(this.reloading2_background);
            this.interface_panel.Controls.Add(this.reloading1_background);
            this.interface_panel.Controls.Add(this.player2_hp_panel);
            this.interface_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interface_panel.Location = new System.Drawing.Point(0, 271);
            this.interface_panel.Name = "interface_panel";
            this.interface_panel.Size = new System.Drawing.Size(512, 55);
            this.interface_panel.TabIndex = 9;
            // 
            // player2_text
            // 
            this.player2_text.AutoSize = true;
            this.player2_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player2_text.Location = new System.Drawing.Point(301, 6);
            this.player2_text.Name = "player2_text";
            this.player2_text.Size = new System.Drawing.Size(125, 29);
            this.player2_text.TabIndex = 11;
            this.player2_text.Text = "PLAYER 2";
            this.player2_text.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // player1_text
            // 
            this.player1_text.AutoSize = true;
            this.player1_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player1_text.Location = new System.Drawing.Point(86, 6);
            this.player1_text.Name = "player1_text";
            this.player1_text.Size = new System.Drawing.Size(125, 29);
            this.player1_text.TabIndex = 10;
            this.player1_text.Text = "PLAYER 1";
            this.player1_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // start_btn
            // 
            this.start_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_btn.Location = new System.Drawing.Point(40, 348);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(105, 40);
            this.start_btn.TabIndex = 27;
            this.start_btn.TabStop = false;
            this.start_btn.Text = "СТАРТ";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // show_settings
            // 
            this.show_settings.Image = global::minigames.Properties.Resources.setting_btn;
            this.show_settings.Location = new System.Drawing.Point(0, 348);
            this.show_settings.Name = "show_settings";
            this.show_settings.Size = new System.Drawing.Size(40, 40);
            this.show_settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.show_settings.TabIndex = 30;
            this.show_settings.TabStop = false;
            this.show_settings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Show_settings_MouseClick);
            this.show_settings.MouseEnter += new System.EventHandler(this.Show_settings_MouseEnter);
            this.show_settings.MouseLeave += new System.EventHandler(this.Show_settings_MouseLeave);
            // 
            // developer_name
            // 
            this.developer_name.AutoSize = true;
            this.developer_name.Cursor = System.Windows.Forms.Cursors.Help;
            this.developer_name.Font = new System.Drawing.Font("Lucida Handwriting", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developer_name.Location = new System.Drawing.Point(332, 361);
            this.developer_name.Name = "developer_name";
            this.developer_name.Size = new System.Drawing.Size(208, 27);
            this.developer_name.TabIndex = 7;
            this.developer_name.Text = "By.Lonewolf239";
            this.developer_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.developer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Developer_name_MouseClick);
            // 
            // Tanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 388);
            this.Controls.Add(this.developer_name);
            this.Controls.Add(this.show_settings);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.top_panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Tanks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Танчики";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tanks_FormClosing);
            this.Load += new System.EventHandler(this.Tanks_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tanks_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tanks_KeyUp);
            this.player1_hp_panel.ResumeLayout(false);
            this.player2_hp_panel.ResumeLayout(false);
            this.reloading1_background.ResumeLayout(false);
            this.reloading2_background.ResumeLayout(false);
            this.game_interface.ResumeLayout(false);
            this.game_interface.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player1_tank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2_tank)).EndInit();
            this.top_panel.ResumeLayout(false);
            this.interface_panel.ResumeLayout(false);
            this.interface_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_settings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player1_tank;
        private System.Windows.Forms.PictureBox player2_tank;
        private System.Windows.Forms.Timer player1_timer;
        private System.Windows.Forms.Timer player2_timer;
        private System.Windows.Forms.Timer bullets_timer;
        private System.Windows.Forms.Panel player1_hp_panel;
        private System.Windows.Forms.Panel player1_hp3;
        private System.Windows.Forms.Panel player1_hp2;
        private System.Windows.Forms.Panel player1_hp1;
        private System.Windows.Forms.Panel player2_hp_panel;
        private System.Windows.Forms.Panel player2_hp3;
        private System.Windows.Forms.Panel player2_hp2;
        private System.Windows.Forms.Panel player2_hp1;
        private System.Windows.Forms.Timer player1_reloading;
        private System.Windows.Forms.Timer player2_reloading;
        private System.Windows.Forms.Panel reloading1_background;
        private System.Windows.Forms.Panel reloading1;
        private System.Windows.Forms.Panel reloading2_background;
        private System.Windows.Forms.Panel reloading2;
        private System.Windows.Forms.Timer logic_timer;
        private System.Windows.Forms.Panel game_interface;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Panel interface_panel;
        private System.Windows.Forms.Label player1_text;
        private System.Windows.Forms.Label player2_text;
        private System.Windows.Forms.Panel ground_panel_0;
        private System.Windows.Forms.Panel grass_panel_1;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Panel ground_panel_1_water;
        private System.Windows.Forms.Panel grass_panel_2;
        private System.Windows.Forms.Panel grass_panel_3;
        private System.Windows.Forms.Panel ground_panel_2;
        private System.Windows.Forms.Panel ground_panel_3;
        private System.Windows.Forms.Panel ground_panel_4;
        private System.Windows.Forms.Panel grass_panel_0;
        private System.Windows.Forms.PictureBox show_settings;
        private System.Windows.Forms.Label game_over_text;
        private System.Windows.Forms.Label developer_name;
    }
}