namespace minigames._Sapper
{
    partial class SP_settings
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
            this.field_size_text = new System.Windows.Forms.Label();
            this.field_size_list = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // field_size_text
            // 
            this.field_size_text.AutoSize = true;
            this.field_size_text.Location = new System.Drawing.Point(7, 9);
            this.field_size_text.Name = "field_size_text";
            this.field_size_text.Size = new System.Drawing.Size(129, 24);
            this.field_size_text.TabIndex = 0;
            this.field_size_text.Text = "Размер поля:";
            this.field_size_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // field_size_list
            // 
            this.field_size_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.field_size_list.FormattingEnabled = true;
            this.field_size_list.Items.AddRange(new object[] {
            "8x8",
            "12x12",
            "18x18",
            "24x24"});
            this.field_size_list.Location = new System.Drawing.Point(142, 6);
            this.field_size_list.Name = "field_size_list";
            this.field_size_list.Size = new System.Drawing.Size(162, 32);
            this.field_size_list.TabIndex = 1;
            this.field_size_list.TabStop = false;
            this.field_size_list.SelectedIndexChanged += new System.EventHandler(this.Field_size_list_SelectedIndexChanged);
            // 
            // SP_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 44);
            this.Controls.Add(this.field_size_list);
            this.Controls.Add(this.field_size_text);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SP_settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SP_settings_FormClosing);
            this.Load += new System.EventHandler(this.SP_settings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SP_settings_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label field_size_text;
        private System.Windows.Forms.ComboBox field_size_list;
    }
}