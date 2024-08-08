using System;
using System.Drawing;
using System.Windows.Forms;

namespace minigames._Balda.user_controls
{
    public partial class CellFields : UserControl
    {
        public CellFields()
        {
            InitializeComponent();
        }

        public int FontSize;
        public string Letter;

        private void CellFields_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (sender is Control control)
            {
                using (Font font = new Font("Arial", FontSize, FontStyle.Regular, GraphicsUnit.Pixel))
                {
                    SizeF textSize = g.MeasureString(Letter, font);
                    float scaleWidth = control.Width / textSize.Width;
                    float scaleHeight = control.Height / textSize.Height;
                    float scale = Math.Min(scaleWidth, scaleHeight);
                    using (Font scaledFont = new Font(font.FontFamily, FontSize * scale, font.Style, GraphicsUnit.Pixel))
                    {
                        SizeF scaledTextSize = g.MeasureString(Letter, scaledFont);
                        float x = (control.Width - scaledTextSize.Width) / 2;
                        float y = (control.Height - scaledTextSize.Height) / 2;
                        g.DrawString(Letter, scaledFont, new SolidBrush(Color.Black), new PointF(x, y));
                    }
                }
            }
        }
    }
}