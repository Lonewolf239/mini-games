namespace minigames
{
    partial class Form2
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
            this.dificult_panel = new System.Windows.Forms.Panel();
            this.hard = new System.Windows.Forms.RadioButton();
            this.midle = new System.Windows.Forms.RadioButton();
            this.ez = new System.Windows.Forms.RadioButton();
            this.speed = new System.Windows.Forms.CheckBox();
            this.unposible = new System.Windows.Forms.CheckBox();
            this.practic_mode = new System.Windows.Forms.CheckBox();
            this.settings_panel = new System.Windows.Forms.Panel();
            this.dificult_panel.SuspendLayout();
            this.settings_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dificult_panel
            // 
            this.dificult_panel.Controls.Add(this.hard);
            this.dificult_panel.Controls.Add(this.midle);
            this.dificult_panel.Controls.Add(this.ez);
            this.dificult_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.dificult_panel.Location = new System.Drawing.Point(0, 0);
            this.dificult_panel.Name = "dificult_panel";
            this.dificult_panel.Size = new System.Drawing.Size(100, 74);
            this.dificult_panel.TabIndex = 1;
            // 
            // hard
            // 
            this.hard.AutoSize = true;
            this.hard.Dock = System.Windows.Forms.DockStyle.Top;
            this.hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hard.Location = new System.Drawing.Point(0, 48);
            this.hard.Name = "hard";
            this.hard.Size = new System.Drawing.Size(100, 24);
            this.hard.TabIndex = 2;
            this.hard.Text = "Сложно";
            this.hard.UseVisualStyleBackColor = true;
            this.hard.CheckedChanged += new System.EventHandler(this.Hard_CheckedChanged);
            // 
            // midle
            // 
            this.midle.AutoSize = true;
            this.midle.Checked = true;
            this.midle.Dock = System.Windows.Forms.DockStyle.Top;
            this.midle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.midle.Location = new System.Drawing.Point(0, 24);
            this.midle.Name = "midle";
            this.midle.Size = new System.Drawing.Size(100, 24);
            this.midle.TabIndex = 1;
            this.midle.TabStop = true;
            this.midle.Text = "Средняя";
            this.midle.UseVisualStyleBackColor = true;
            this.midle.CheckedChanged += new System.EventHandler(this.Midle_CheckedChanged);
            // 
            // ez
            // 
            this.ez.AutoSize = true;
            this.ez.Dock = System.Windows.Forms.DockStyle.Top;
            this.ez.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ez.Location = new System.Drawing.Point(0, 0);
            this.ez.Name = "ez";
            this.ez.Size = new System.Drawing.Size(100, 24);
            this.ez.TabIndex = 0;
            this.ez.Text = "Легко";
            this.ez.UseVisualStyleBackColor = true;
            this.ez.CheckedChanged += new System.EventHandler(this.Ez_CheckedChanged);
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.Dock = System.Windows.Forms.DockStyle.Top;
            this.speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.speed.Location = new System.Drawing.Point(0, 24);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(177, 24);
            this.speed.TabIndex = 2;
            this.speed.TabStop = false;
            this.speed.Text = "Высокая скорость";
            this.speed.UseVisualStyleBackColor = true;
            this.speed.CheckedChanged += new System.EventHandler(this.speed_CheckedChanged);
            // 
            // unposible
            // 
            this.unposible.AutoSize = true;
            this.unposible.Dock = System.Windows.Forms.DockStyle.Top;
            this.unposible.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unposible.Location = new System.Drawing.Point(0, 0);
            this.unposible.Name = "unposible";
            this.unposible.Size = new System.Drawing.Size(177, 24);
            this.unposible.TabIndex = 3;
            this.unposible.TabStop = false;
            this.unposible.Text = "Unposible 99.9%";
            this.unposible.UseVisualStyleBackColor = true;
            this.unposible.CheckedChanged += new System.EventHandler(this.Unposible_CheckedChanged);
            // 
            // practic_mode
            // 
            this.practic_mode.AutoSize = true;
            this.practic_mode.BackColor = System.Drawing.SystemColors.Control;
            this.practic_mode.Dock = System.Windows.Forms.DockStyle.Top;
            this.practic_mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.practic_mode.Location = new System.Drawing.Point(0, 48);
            this.practic_mode.Name = "practic_mode";
            this.practic_mode.Size = new System.Drawing.Size(177, 24);
            this.practic_mode.TabIndex = 4;
            this.practic_mode.TabStop = false;
            this.practic_mode.Text = "Режим практики";
            this.practic_mode.UseVisualStyleBackColor = false;
            this.practic_mode.CheckedChanged += new System.EventHandler(this.practic_mode_CheckedChanged);
            // 
            // settings_panel
            // 
            this.settings_panel.Controls.Add(this.practic_mode);
            this.settings_panel.Controls.Add(this.speed);
            this.settings_panel.Controls.Add(this.unposible);
            this.settings_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.settings_panel.Location = new System.Drawing.Point(100, 0);
            this.settings_panel.Name = "settings_panel";
            this.settings_panel.Size = new System.Drawing.Size(177, 74);
            this.settings_panel.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 74);
            this.Controls.Add(this.settings_panel);
            this.Controls.Add(this.dificult_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки сложности";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.dificult_panel.ResumeLayout(false);
            this.dificult_panel.PerformLayout();
            this.settings_panel.ResumeLayout(false);
            this.settings_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel dificult_panel;
        private System.Windows.Forms.RadioButton hard;
        private System.Windows.Forms.RadioButton midle;
        private System.Windows.Forms.RadioButton ez;
        private System.Windows.Forms.CheckBox speed;
        private System.Windows.Forms.CheckBox unposible;
        private System.Windows.Forms.CheckBox practic_mode;
        private System.Windows.Forms.Panel settings_panel;
    }
}