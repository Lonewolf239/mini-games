﻿namespace minigames._SLIL
{
    partial class SLIL_Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SLIL_Editor));
            this.editor_interface = new System.Windows.Forms.Panel();
            this.about = new System.Windows.Forms.Label();
            this.random_btn = new System.Windows.Forms.Button();
            this.reset_btn = new System.Windows.Forms.Button();
            this.export_btn = new System.Windows.Forms.Button();
            this.accept_button = new System.Windows.Forms.Button();
            this.import_btn = new System.Windows.Forms.Button();
            this.elements = new System.Windows.Forms.ComboBox();
            this.question = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editor_interface
            // 
            this.editor_interface.AutoSize = true;
            this.editor_interface.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editor_interface.Location = new System.Drawing.Point(0, 0);
            this.editor_interface.MinimumSize = new System.Drawing.Size(243, 243);
            this.editor_interface.Name = "editor_interface";
            this.editor_interface.Size = new System.Drawing.Size(243, 243);
            this.editor_interface.TabIndex = 0;
            // 
            // about
            // 
            this.about.AutoSize = true;
            this.about.Location = new System.Drawing.Point(12, 246);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(107, 24);
            this.about.TabIndex = 15;
            this.about.Text = "Элементы:";
            // 
            // random_btn
            // 
            this.random_btn.BackgroundImage = global::minigames.Properties.Resources.random;
            this.random_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.random_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.random_btn.Location = new System.Drawing.Point(342, 112);
            this.random_btn.Name = "random_btn";
            this.random_btn.Size = new System.Drawing.Size(50, 50);
            this.random_btn.TabIndex = 17;
            this.random_btn.TabStop = false;
            this.random_btn.UseVisualStyleBackColor = true;
            this.random_btn.Click += new System.EventHandler(this.Random_btn_Click);
            // 
            // reset_btn
            // 
            this.reset_btn.BackgroundImage = global::minigames.Properties.Resources.reset;
            this.reset_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.reset_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset_btn.Location = new System.Drawing.Point(342, 56);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(50, 50);
            this.reset_btn.TabIndex = 16;
            this.reset_btn.TabStop = false;
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.Reset_btn_Click);
            // 
            // export_btn
            // 
            this.export_btn.BackgroundImage = global::minigames.Properties.Resources.export;
            this.export_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.export_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.export_btn.Location = new System.Drawing.Point(342, 224);
            this.export_btn.Name = "export_btn";
            this.export_btn.Size = new System.Drawing.Size(50, 50);
            this.export_btn.TabIndex = 12;
            this.export_btn.TabStop = false;
            this.export_btn.UseVisualStyleBackColor = true;
            this.export_btn.Click += new System.EventHandler(this.Export_btn_Click);
            // 
            // accept_button
            // 
            this.accept_button.BackgroundImage = global::minigames.Properties.Resources.done;
            this.accept_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.accept_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accept_button.Location = new System.Drawing.Point(342, 0);
            this.accept_button.Name = "accept_button";
            this.accept_button.Size = new System.Drawing.Size(50, 50);
            this.accept_button.TabIndex = 13;
            this.accept_button.TabStop = false;
            this.accept_button.UseVisualStyleBackColor = true;
            this.accept_button.Click += new System.EventHandler(this.Accept_button_Click);
            // 
            // import_btn
            // 
            this.import_btn.BackgroundImage = global::minigames.Properties.Resources.import;
            this.import_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.import_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.import_btn.Location = new System.Drawing.Point(342, 168);
            this.import_btn.Name = "import_btn";
            this.import_btn.Size = new System.Drawing.Size(50, 50);
            this.import_btn.TabIndex = 11;
            this.import_btn.TabStop = false;
            this.import_btn.UseVisualStyleBackColor = true;
            this.import_btn.Click += new System.EventHandler(this.Import_btn_Click);
            // 
            // elements
            // 
            this.elements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.elements.FormattingEnabled = true;
            this.elements.Items.AddRange(new object[] {
            "Игрок",
            "Стена",
            "Дверь",
            "Окно",
            "Финиш",
            "Магазин",
            "Враг"});
            this.elements.Location = new System.Drawing.Point(12, 273);
            this.elements.Name = "elements";
            this.elements.Size = new System.Drawing.Size(187, 32);
            this.elements.TabIndex = 18;
            this.elements.TabStop = false;
            // 
            // question
            // 
            this.question.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.question.Location = new System.Drawing.Point(205, 265);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(40, 40);
            this.question.TabIndex = 40;
            this.question.TabStop = false;
            this.question.Text = "?";
            this.question.UseVisualStyleBackColor = true;
            this.question.Click += new System.EventHandler(this.Question_Click);
            // 
            // SLIL_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 441);
            this.Controls.Add(this.question);
            this.Controls.Add(this.elements);
            this.Controls.Add(this.random_btn);
            this.Controls.Add(this.reset_btn);
            this.Controls.Add(this.about);
            this.Controls.Add(this.export_btn);
            this.Controls.Add(this.accept_button);
            this.Controls.Add(this.import_btn);
            this.Controls.Add(this.editor_interface);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SLIL_Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SLIL_Editor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SLIL_Editor_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel editor_interface;
        private System.Windows.Forms.Button import_btn;
        private System.Windows.Forms.Button export_btn;
        private System.Windows.Forms.Button accept_button;
        private System.Windows.Forms.Label about;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.Button random_btn;
        private System.Windows.Forms.ComboBox elements;
        private System.Windows.Forms.Button question;
    }
}