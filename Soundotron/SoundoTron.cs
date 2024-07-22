using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace minigames.Soundotron
{
    public partial class SoundoTron : Form
    {
        public SoundoTron()
        {
            InitializeComponent();
        }

        private PlaySound sound;
        private readonly Random rand = new Random();
        private int unlocked_sounds = 0, index = 0, player_index = 0;
        public static int score = 0, max_score = 0;
        private float difficult = 0;
        private readonly string[][] wav_files =
        {
            //piano
            new string[] { @"piano_do.wav", @"piano_re.wav", @"piano_mi.wav"},
            //guitar
            new string[] { @"guitar_do.wav", @"guitar_re.wav", @"guitar_mi.wav"},
            //drum
            new string[] { @"drum_do.wav", @"drum_re.wav", @"drum_mi.wav"},
            //violin
            new string[] { @"violin_do.wav", @"violin_re.wav", @"violin_mi.wav"},
            //clarinet
            new string[] { @"clarinet_do.wav", @"clarinet_re.wav", @"clarinet_mi.wav"},
        };
        private string[] sounds = new string[8], player_sounds = new string[8];
        private bool unlocked = false;
        private readonly PlaySound win = new PlaySound(MainMenu.CGFReader.GetFile("win.wav"), false),
                        game_over = new PlaySound(MainMenu.CGFReader.GetFile("game_over.wav"), false);

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Question_Click(object sender, EventArgs e)
        {
            score_text.Focus();
            if (MainMenu.Language)
                MessageBox.Show("Ваша цель состоит в том, чтобы повторить последовательность нот разных инструментов. " +
                    "Чем дольше вы будете играть, тем больше инструментов будет открываться. " +
                    "Однако, если вы проиграете, ваш прогресс будет сброшен." +
                    "\nУправление:\nЛКМ — выбрать звук\nПКМ — прослушать звук", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Your goal is to repeat a sequence of notes played by different instruments. " +
                    "The longer you play, the more instruments will be unlocked. However, " +
                    "if you lose, your progress will be reset." +
                    "\nControls:\nLMB — select sound\nRMB — listen to sound", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Piano_icon_MouseEnter(object sender, EventArgs e)
        {
            if (unlocked)
            {
                piano_panel.Visible = guitar_panel.Visible = drum_panel.Visible = violin_panel.Visible = clarinet_panel.Visible = false;
                piano_panel.Visible = true;
            }
        }

        private void Guitar_icon_MouseEnter(object sender, EventArgs e)
        {
            piano_panel.Visible = guitar_panel.Visible = drum_panel.Visible = violin_panel.Visible = clarinet_panel.Visible = false;
            if (unlocked && unlocked_sounds >= 1)
                guitar_panel.Visible = true;
        }

        private void Drum_icon_MouseEnter(object sender, EventArgs e)
        {
            piano_panel.Visible = guitar_panel.Visible = drum_panel.Visible = violin_panel.Visible = clarinet_panel.Visible = false;
            if (unlocked && unlocked_sounds >= 2)
                drum_panel.Visible = true;
        }

        private void Violin_icon_MouseEnter(object sender, EventArgs e)
        {
            piano_panel.Visible = guitar_panel.Visible = drum_panel.Visible = violin_panel.Visible = clarinet_panel.Visible = false;
            if (unlocked && unlocked_sounds >= 3)
                violin_panel.Visible = true;
        }

        private void Trumpet_icon_MouseEnter(object sender, EventArgs e)
        {
            piano_panel.Visible = guitar_panel.Visible = drum_panel.Visible = violin_panel.Visible = clarinet_panel.Visible = false;
            if (unlocked && unlocked_sounds >= 4)
                clarinet_panel.Visible = true;
        }

        private void Piano_do_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[0][0]);
                Add_Sound(0, 0);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[0][0]);
        }

        private void Piano_re_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[0][1]);
                Add_Sound(0, 1);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[0][1]);
        }

        private void Piano_mi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[0][2]);
                Add_Sound(0, 2);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[0][2]);
        }

        private void Guitar_do_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[1][0]);
                Add_Sound(1, 0);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[1][0]);
        }

        private void Guitar_re_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[1][1]);
                Add_Sound(1, 1);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[1][1]);
        }

        private void Guitar_mi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[1][2]);
                Add_Sound(1, 2);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[1][2]);
        }

        private void Drum_do_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[2][0]);
                Add_Sound(2, 0);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[2][0]);
        }

        private void Drum_re_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[2][1]);
                Add_Sound(2, 1);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[2][1]);
        }

        private void Drum_mi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[2][2]);
                Add_Sound(2, 2);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[2][2]);
        }

        private void Violin_do_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[3][0]);
                Add_Sound(3, 0);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[3][0]);
        }

        private void Violin_re_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[3][1]);
                Add_Sound(3, 1);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[3][1]);
        }

        private void Violin_mi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[3][2]);
                Add_Sound(3, 2);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[3][2]);
        }

        private void Clarinet_do_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[4][0]);
                Add_Sound(4, 0);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[4][0]);
        }

        private void Clarinet_re_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[4][1]);
                Add_Sound(4, 1);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[4][1]);
        }

        private void Clarinet_mi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(wav_files[4][2]);
                Add_Sound(4, 2);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(wav_files[4][2]);
        }

        private void SoundoTron_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                foreach (Control text in bottom_interface.Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                developer_name.Left = Width - developer_name.Width - 16;
                Screen screen = Screen.FromPoint(Cursor.Position);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            Activate();
            score = 0;
            max_score = MainMenu.mg8_max_score;
            if (!MainMenu.Language)
            {
                Text = "Soundotron";
                start_btn.Text = "START";
                score_text.Text = $"score: 0   max score: {max_score}";
            }
            else
                score_text.Text = $"счёт: 0   макс. счёт: {max_score}";
            piano_panel.Top = guitar_panel.Top = drum_panel.Top = violin_panel.Top = clarinet_panel.Top = 5;
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            score_text.Focus();
            question.Enabled = start_btn.Enabled = false;
            difficult = player_index = index = unlocked_sounds = 0;
            player_sounds = sounds = null;
            sounds = new string[8];
            player_sounds = new string[8];
            sounds_generate.Start();
        }

        private void Play_Sound(string path)
        {
            sound = new PlaySound(MainMenu.CGFReader.GetFile(path), false);
            sound.PlayWithDispose(0.5f);
        }

        private void SoundoTron_FormClosing(object sender, FormClosingEventArgs e)
        {
            sounds_generate.Stop();
            time_timer.Stop();
            sound?.Dispose();
            win?.Dispose();
            game_over?.Dispose();
        }

        private void SoundoTron_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void Time_timer_Tick(object sender, EventArgs e)
        {
            time.Width--;
            if (time.Width == 0)
            {
                time_timer.Stop();
                if (score > max_score)
                    MainMenu.mg8_max_score = max_score = score;
                score = 0;
                if (!MainMenu.Language)
                    score_text.Text = $"score: {score}   max score: {max_score}";
                else
                    score_text.Text = $"счёт: {score}   макс. счёт: {max_score}";
                unlocked = piano_panel.Visible = guitar_panel.Visible = drum_panel.Visible = violin_panel.Visible = clarinet_panel.Visible = false;
                question.Enabled = start_btn.Enabled = true;
            }
        }

        private void Add_Sound(int albom, int track)
        {
            player_sounds[player_index] = wav_files[albom][track];
            player_index++;
            if (player_index >= index)
            {
                unlocked = false;
                piano_panel.Visible = guitar_panel.Visible = drum_panel.Visible = violin_panel.Visible = clarinet_panel.Visible = false;
                Check_Sounds();
            }
        }

        private void Check_Sounds()
        {
            bool all_right = true;
            for(int i = 0; i < index; i++)
            {
                if (player_sounds[i] != sounds[i])
                {
                    all_right = false;
                    break;
                }
            }
            if (!all_right)
            {
                if (MainMenu.sounds)
                    game_over.Play(1);
                time_timer.Stop();
                if (score > max_score)
                    max_score = score;
                time.Width = score = 0;
                if (!MainMenu.Language)
                    score_text.Text = $"score: {score}   max score: {max_score}";
                else
                    score_text.Text = $"счёт: {score}   макс. счёт: {max_score}";
                question.Enabled = start_btn.Enabled = true;
            }
            else
            {
                if (MainMenu.sounds)
                    win.Play(1);
                time_timer.Stop();
                time.Width = 0;
                difficult += 0.75f;
                score++;
                if (!MainMenu.Language)
                    score_text.Text = $"score: {score}   max score: {max_score}";
                else
                    score_text.Text = $"счёт: {score}   макс. счёт: {max_score}";
                if (difficult >= 1.5f && difficult < 2.5f)
                    unlocked_sounds = 1;
                else if (difficult >= 3.5f && difficult < 4.5f)
                    unlocked_sounds = 2;
                else if (difficult >= 5.5f && difficult < 6.5f)
                    unlocked_sounds = 3;
                else if(difficult >= 6.5f)
                    unlocked_sounds = 4;
                player_index = index = 0;
                player_sounds = sounds = null;
                sounds = new string[8];
                player_sounds = new string[8];
                sounds_generate.Start();
            }
        }

        private void Sounds_generate_Tick(object sender, EventArgs e)
        {
            try
            {
                sound.Check();
            }
            catch
            {
                int track = rand.Next(0, 3), albom = rand.Next(0, unlocked_sounds + 1);
                Play_Sound(wav_files[albom][track]);
                sounds[index] = wav_files[albom][track];
                index++;
                if (index > 1 && difficult < 1.5f)
                {
                    unlocked = true;
                    sounds_generate.Stop();
                }
                else if (index > 2 && difficult >= 1.5f && difficult < 2.5f)
                {
                    unlocked = true;
                    sounds_generate.Stop();
                }
                else if (index > 3 && difficult >= 2.5f && difficult < 3.5f)
                {
                    unlocked = true;
                    sounds_generate.Stop();
                }
                else if (index > 4 && difficult >= 3.5f && difficult < 4.5f)
                {
                    unlocked = true;
                    sounds_generate.Stop();
                }
                else if (index > 5 && difficult >= 4.5f && difficult < 5.5f)
                {
                    unlocked = true;
                    sounds_generate.Stop();
                }
                else if (index > 6 && difficult >= 5.5f && difficult < 6.5f)
                {
                    unlocked = true;
                    sounds_generate.Stop();
                }
                else if (index > 7 && difficult >= 6.5f)
                {
                    unlocked = true;
                    sounds_generate.Stop();
                }
                if (unlocked)
                {
                    time.Width = time_panel.Width;
                    time_timer.Start();
                }
            }
        }
    }
}