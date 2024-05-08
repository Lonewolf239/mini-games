namespace minigames
{
    partial class test
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
            this.tank_tracks_timer = new System.Windows.Forms.Timer(this.components);
            this.cannon_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tank_tracks_timer
            // 
            this.tank_tracks_timer.Interval = 1;
            this.tank_tracks_timer.Tick += new System.EventHandler(this.Tank_tracks_timer_Tick);
            // 
            // cannon_timer
            // 
            this.cannon_timer.Interval = 1;
            this.cannon_timer.Tick += new System.EventHandler(this.Cannon_timer_Tick);
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "test";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "test";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Test_FormClosing);
            this.Load += new System.EventHandler(this.Test_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Test_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Test_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Test_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tank_tracks_timer;
        private System.Windows.Forms.Timer cannon_timer;
    }
}