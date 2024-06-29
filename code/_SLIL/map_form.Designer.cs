namespace minigames._SLIL
{
    partial class map_form
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
            this.map_refresh = new System.Windows.Forms.Timer(this.components);
            this.map_display = new minigames._SLIL.Display();
            this.SuspendLayout();
            // 
            // map_refresh
            // 
            this.map_refresh.Interval = 1;
            this.map_refresh.Tick += new System.EventHandler(this.Map_refresh_Tick);
            // 
            // map_display
            // 
            this.map_display.BackColor = System.Drawing.Color.Black;
            this.map_display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map_display.Location = new System.Drawing.Point(0, 0);
            this.map_display.Name = "map_display";
            this.map_display.Size = new System.Drawing.Size(250, 300);
            this.map_display.TabIndex = 0;
            // 
            // map_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(250, 300);
            this.Controls.Add(this.map_display);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "map_form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "map_form";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Map_form_FormClosing);
            this.Load += new System.EventHandler(this.Map_form_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer map_refresh;
        private Display map_display;
    }
}