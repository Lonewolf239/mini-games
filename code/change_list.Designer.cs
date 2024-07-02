namespace minigames
{
    partial class Change_list
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Change_list));
            this.changes_list = new System.Windows.Forms.ListBox();
            this.ok = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // changes_list
            // 
            this.changes_list.Dock = System.Windows.Forms.DockStyle.Top;
            this.changes_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changes_list.FormattingEnabled = true;
            this.changes_list.ItemHeight = 20;
            this.changes_list.Location = new System.Drawing.Point(0, 0);
            this.changes_list.Name = "changes_list";
            this.changes_list.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.changes_list.Size = new System.Drawing.Size(484, 264);
            this.changes_list.TabIndex = 0;
            this.changes_list.TabStop = false;
            this.changes_list.Enter += new System.EventHandler(this.Changes_list_Enter);
            // 
            // ok
            // 
            this.ok.AutoSize = true;
            this.ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ok.Location = new System.Drawing.Point(304, 274);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(95, 41);
            this.ok.TabIndex = 27;
            this.ok.TabStop = false;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 48);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(432, 170);
            this.richTextBox1.TabIndex = 29;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // change_list
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 321);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.changes_list);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "change_list";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List of changes";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Change_list_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Change_list_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox changes_list;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}