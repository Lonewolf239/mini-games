using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minigames
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private float angle = 565;
        private float x = 50, y = 50;
        private enum Direction { STOP, UP, DOWN };
        private Direction left_track = Direction.STOP, rigth_track = Direction.STOP, cannon_direction = Direction.STOP;

        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            cannon_timer.Enabled = tank_tracks_timer.Enabled = false;
        }

        private void Test_Load(object sender, EventArgs e)
        {
            cannon_timer.Enabled = tank_tracks_timer.Enabled = true;
        }

        private void Test_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Navy, 5);
            float cannon_x = x + 25f, cannon_y = y + 25f,
                cannon_x1 = (float)(cannon_x + (Math.Sin(angle / 360) * 75)), cannon_y1 = (float)(cannon_y + (Math.Cos(angle / 360) * 75));
            Font font = new Font("Microsoft Sans Serif", 15.75F);
            StringFormat stringFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            g.DrawString($"DEBUG\nx: {x:0.#}\ny: {y:0.#}\n" +
                $"cannon_x: {cannon_x:0.#}\ncannon_y: {cannon_y:0.#}\n" +
                $"cannon_x1: {cannon_x1:0.#}\ncannon_y1: {cannon_y1:0.#}\n" +
                $"angle: {angle / 360}", font, brush, 800, 0, stringFormat);
            brush = new SolidBrush(Color.Blue);
            g.FillRectangle(brush, x, y, 50, 50);
            g.DrawLine(pen, cannon_x, cannon_y, cannon_x1, cannon_y1);
            g.DrawEllipse(pen, cannon_x - 15, cannon_y - 15, 30, 30);
        }

        private void Test_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                left_track = Direction.UP;
               // rigth_track = Direction.UP;
            }
            else if (e.KeyCode == Keys.S)
            {
                left_track = Direction.DOWN;
               // rigth_track = Direction.DOWN;
            }
            else if (e.KeyCode == Keys.A)
            {
               // left_track = Direction.DOWN;
                rigth_track = Direction.UP;
            }
            else if (e.KeyCode == Keys.D)
            {
               // left_track = Direction.UP;
                rigth_track = Direction.DOWN;
            }

            if (e.KeyCode == Keys.Up)
                cannon_direction = Direction.UP;
            else if (e.KeyCode == Keys.Down)
                cannon_direction = Direction.DOWN;

            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void Cannon_timer_Tick(object sender, EventArgs e)
        {
            if (cannon_direction == Direction.UP)
                angle += 5;
            else if (cannon_direction == Direction.DOWN)
                angle -= 5;

            if (angle > 2255)
                angle = 0;
            else if (angle < 0)
                angle = 2255;
            Refresh();
        }

        private void Tank_tracks_timer_Tick(object sender, EventArgs e)
        {
            if (left_track == Direction.UP)
            {
                y--;
            }
            if (rigth_track == Direction.UP)
            {
                x--;
            }
            if (left_track == Direction.DOWN)
            {
                y++;
            }
            if (rigth_track == Direction.DOWN)
            {
                x++;
            }

            if (x < 0)
                x = 0;
            else if (x > 751)
                x = 751;
            if (y < 0)
                y = 0;
            else if (y > 400)
                y = 400;
        }

        private void Test_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                cannon_direction = Direction.STOP;
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.S || e.KeyCode == Keys.A|| e.KeyCode == Keys.D)
            {
                left_track = Direction.STOP;
                rigth_track = Direction.STOP;
            }
        }
    }
}
