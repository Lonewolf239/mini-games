using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly string folder = @"sounds\";
        private int unlocked_sounds = 0, index = 0, player_index = 0;
        public static int score = 0, max_score = 0;
        private float difficult = 0;
        private readonly string[][] wav_files =
        {
            //piano
            new string[] { @"piano\piano_do.wav", @"piano\piano_re.wav", @"piano\piano_mi.wav"},
            //guitar
            new string[] { @"guitar\guitar_do.wav", @"guitar\guitar_re.wav", @"guitar\guitar_mi.wav"},
            //drum
            new string[] { @"drum\drum_do.wav", @"drum\drum_re.wav", @"drum\drum_mi.wav"},
            //violin
            new string[] { @"violin\violin_do.wav", @"violin\violin_re.wav", @"violin\violin_mi.wav"},
            //clarinet
            new string[] { @"clarinet\clarinet_do.wav", @"clarinet\clarinet_re.wav", @"clarinet\clarinet_mi.wav"},
        };
        private string[] sounds = new string[8], player_sounds = new string[8];
        private bool unlocked = false;

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Question_Click(object sender, EventArgs e)
        {
            score_text.Focus();
            if (MainMenu.Language)
                MessageBox.Show("Управление:\nЛКМ — выбрать звук\nПКМ — прослушать звук", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Controls:\nLMB — select sound\nRMB — listen to sound", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Play_Sound(folder + wav_files[0][0]);
                Add_Sound(0, 0);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[0][0]);
        }

        private void Piano_re_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[0][1]);
                Add_Sound(0, 1);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[0][1]);
        }

        private void Piano_mi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[0][2]);
                Add_Sound(0, 2);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[0][2]);
        }

        private void Guitar_do_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[1][0]);
                Add_Sound(1, 0);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[1][0]);
        }

        private void Guitar_re_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[1][1]);
                Add_Sound(1, 1);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[1][1]);
        }

        private void Guitar_mi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[1][2]);
                Add_Sound(1, 2);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[1][2]);
        }

        private void Drum_do_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[2][0]);
                Add_Sound(2, 0);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[2][0]);
        }

        private void Drum_re_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[2][1]);
                Add_Sound(2, 1);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[2][1]);
        }

        private void Drum_mi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[2][2]);
                Add_Sound(2, 2);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[2][2]);
        }

        private void Violin_do_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[3][0]);
                Add_Sound(3, 0);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[3][0]);
        }

        private void Violin_re_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[3][1]);
                Add_Sound(3, 1);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[3][1]);
        }

        private void Violin_mi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[3][2]);
                Add_Sound(3, 2);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[3][2]);
        }

        private void Clarinet_do_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[4][0]);
                Add_Sound(4, 0);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[4][0]);
        }

        private void Clarinet_re_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[4][1]);
                Add_Sound(4, 1);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[4][1]);
        }

        private void Clarinet_mi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Play_Sound(folder + wav_files[4][2]);
                Add_Sound(4, 2);
            }
            else if (e.Button == MouseButtons.Right)
                Play_Sound(folder + wav_files[4][2]);
        }

        private void SoundoTron_Load(object sender, EventArgs e)
        {
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
            piano_panel.Top = guitar_panel.Top = drum_panel.Top = violin_panel.Top = clarinet_panel.Top = 62;
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
            sound = new PlaySound(path);
            sound.Play();
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
                Play_Sound(folder + wav_files[albom][track]);
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