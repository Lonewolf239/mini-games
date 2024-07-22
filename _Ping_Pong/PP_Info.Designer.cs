namespace minigames._Ping_Pong
{
    partial class PP_Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PP_Info));
            this.control_panel = new System.Windows.Forms.Panel();
            this.pause_text = new System.Windows.Forms.Label();
            this.control_pic = new System.Windows.Forms.PictureBox();
            this.pl2_text = new System.Windows.Forms.Label();
            this.pl1_text = new System.Windows.Forms.Label();
            this.control_text = new System.Windows.Forms.Label();
            this.rules_panel = new System.Windows.Forms.Panel();
            this.rules_pic = new System.Windows.Forms.PictureBox();
            this.rules_text = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.control_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.control_pic)).BeginInit();
            this.rules_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rules_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // control_panel
            // 
            this.control_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.control_panel.Controls.Add(this.pause_text);
            this.control_panel.Controls.Add(this.control_pic);
            this.control_panel.Controls.Add(this.pl2_text);
            this.control_panel.Controls.Add(this.pl1_text);
            this.control_panel.Controls.Add(this.control_text);
            this.control_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_panel.Location = new System.Drawing.Point(0, 0);
            this.control_panel.Name = "control_panel";
            this.control_panel.Size = new System.Drawing.Size(567, 131);
            this.control_panel.TabIndex = 0;
            // 
            // pause_text
            // 
            this.pause_text.BackColor = System.Drawing.Color.White;
            this.pause_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.pause_text.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pause_text.Location = new System.Drawing.Point(90, 110);
            this.pause_text.Name = "pause_text";
            this.pause_text.Size = new System.Drawing.Size(385, 19);
            this.pause_text.TabIndex = 3;
            this.pause_text.Text = "Чтобы поставить на паузу нажмите: ПРОБЕЛ";
            this.pause_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // control_pic
            // 
            this.control_pic.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_pic.Image = global::minigames.Properties.Resources.pp_control;
            this.control_pic.Location = new System.Drawing.Point(90, 22);
            this.control_pic.Name = "control_pic";
            this.control_pic.Size = new System.Drawing.Size(385, 88);
            this.control_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.control_pic.TabIndex = 1;
            this.control_pic.TabStop = false;
            // 
            // pl2_text
            // 
            this.pl2_text.BackColor = System.Drawing.Color.White;
            this.pl2_text.Dock = System.Windows.Forms.DockStyle.Right;
            this.pl2_text.Location = new System.Drawing.Point(475, 22);
            this.pl2_text.Name = "pl2_text";
            this.pl2_text.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pl2_text.Size = new System.Drawing.Size(90, 107);
            this.pl2_text.TabIndex = 2;
            this.pl2_text.Text = "Player 2";
            this.pl2_text.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pl1_text
            // 
            this.pl1_text.BackColor = System.Drawing.Color.White;
            this.pl1_text.Dock = System.Windows.Forms.DockStyle.Left;
            this.pl1_text.Location = new System.Drawing.Point(0, 22);
            this.pl1_text.Name = "pl1_text";
            this.pl1_text.Size = new System.Drawing.Size(90, 107);
            this.pl1_text.TabIndex = 1;
            this.pl1_text.Text = "Player 1";
            this.pl1_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // control_text
            // 
            this.control_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_text.Location = new System.Drawing.Point(0, 0);
            this.control_text.Name = "control_text";
            this.control_text.Size = new System.Drawing.Size(565, 22);
            this.control_text.TabIndex = 0;
            this.control_text.Text = "Управление:";
            this.control_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rules_panel
            // 
            this.rules_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rules_panel.Controls.Add(this.rules_pic);
            this.rules_panel.Controls.Add(this.rules_text);
            this.rules_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rules_panel.Location = new System.Drawing.Point(0, 131);
            this.rules_panel.Name = "rules_panel";
            this.rules_panel.Size = new System.Drawing.Size(567, 140);
            this.rules_panel.TabIndex = 1;
            // 
            // rules_pic
            // 
            this.rules_pic.Dock = System.Windows.Forms.DockStyle.Top;
            this.rules_pic.Image = global::minigames.Properties.Resources.speed;
            this.rules_pic.Location = new System.Drawing.Point(0, 116);
            this.rules_pic.Name = "rules_pic";
            this.rules_pic.Size = new System.Drawing.Size(565, 21);
            this.rules_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rules_pic.TabIndex = 1;
            this.rules_pic.TabStop = false;
            // 
            // rules_text
            // 
            this.rules_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.rules_text.Location = new System.Drawing.Point(0, 0);
            this.rules_text.Name = "rules_text";
            this.rules_text.Size = new System.Drawing.Size(565, 116);
            this.rules_text.TabIndex = 0;
            this.rules_text.Text = resources.GetString("rules_text.Text");
            // 
            // ok
            // 
            this.ok.AutoSize = true;
            this.ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ok.Location = new System.Drawing.Point(460, 276);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(95, 41);
            this.ok.TabIndex = 27;
            this.ok.TabStop = false;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // PP_Info
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ok;
            this.ClientSize = new System.Drawing.Size(567, 323);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.rules_panel);
            this.Controls.Add(this.control_panel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PP_Info";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Правила игры";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PP_Info_Load);
            this.control_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.control_pic)).EndInit();
            this.rules_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rules_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel control_panel;
        private System.Windows.Forms.Label control_text;
        private System.Windows.Forms.PictureBox control_pic;
        private System.Windows.Forms.Label pl2_text;
        private System.Windows.Forms.Label pl1_text;
        private System.Windows.Forms.Label pause_text;
        private System.Windows.Forms.Panel rules_panel;
        private System.Windows.Forms.Label rules_text;
        private System.Windows.Forms.PictureBox rules_pic;
        private System.Windows.Forms.Button ok;
    }
}