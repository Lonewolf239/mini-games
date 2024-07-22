using IniReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minigames._Tanks
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private bool in_rebind = false;
        private Keys[][] keys = 
        {
            new Keys[] { Keys.W, Keys.Up },
            new Keys[] { Keys.S, Keys.Down },
            new Keys[] { Keys.A, Keys.Left },
            new Keys[] { Keys.D, Keys.Right },
            new Keys[] { Keys.Space, Keys.Enter }
        };
        private string restore_name;
        private int index, key_index;

        private void Settings_Load(object sender, EventArgs e)
        {
            Button[][] btns =
            {
                new Button[] { up_btn_pl1, up_btn_pl2 },
                new Button[] { down_btn_pl1, down_btn_pl2 },
                new Button[] { left_btn_pl1, left_btn_pl2 },
                new Button[] { right_btn_pl1, right_btn_pl2 },
                new Button[] { shot_btn_pl1, shot_btn_pl2 },
                new Button[] { clear_btn_pl1, clear_btn_pl2 },
            };
            string[] maps =
            {
                "Линия фронта",
                "Танковая дуэль",
                "Защитный вал",
                "Непробиваемый рубеж"
            };
            if (!MainMenu.Language)
            {
                Text = "Settings";
                controls_group.Text = "Controls";
                player1_group.Text = "Player 1";
                player2_group.Text = "Player 2";
                shot_text_pl1.Text = shot_text_pl2.Text = "Shot:";
                shot_btn_pl1.Left = shot_text_pl1.Right + 6;
                shot_btn_pl2.Left = shot_text_pl2.Right + 6;
                clear_btn_pl1.Text = clear_btn_pl2.Text = "Reset";
                map_text.Text = "Map:";
                map_list.Left = map_text.Right + 6;
                map_list.Width += 16;
                task_text1.Text = task_text2.Text = "Press any key or ESC to cancel...";
                maps = new string[]
                {
                    "Front line",
                    "Tank duel",
                    "Protective shaft",
                    "Impenetrable line"
                };
                fast_reload.Text = "Fast recharge:";
            }
            map_list.Items.AddRange(maps);
            Activate();
            keys = Tanks.keys;
            map_list.SelectedIndex = Tanks.map_choice;
            fast_reload.Checked = Tanks.fast_reload;
            if (!Tanks.inverted)
            {
                inverted.Value = 0;
                if (map_list.SelectedIndex == 2)
                {
                    pl1_inverted_text.Text = "PLAYER 2";
                    pl2_inverted_text.Text = "PLAYER 1";
                }
                else
                {
                    pl1_inverted_text.Text = "PLAYER 1";
                    pl2_inverted_text.Text = "PLAYER 2";
                }
            }
            else
            {
                inverted.Value = 1;
                if (map_list.SelectedIndex == 2)
                {
                    pl1_inverted_text.Text = "PLAYER 1";
                    pl2_inverted_text.Text = "PLAYER 2";
                }
                else
                {
                    pl1_inverted_text.Text = "PLAYER 2";
                    pl2_inverted_text.Text = "PLAYER 1";
                }
            }
            for (int i = 0; i < btns.Length - 1; i++)
            {
                for (int j = 0; j < btns[i].Length; j++)
                {
                    if (keys[i][j] == Keys.Up)
                        btns[i][j].Text = "↑";
                    else if (keys[i][j] == Keys.Down)
                        btns[i][j].Text = "↓";
                    else if (keys[i][j] == Keys.Left)
                        btns[i][j].Text = "←";
                    else if (keys[i][j] == Keys.Right)
                        btns[i][j].Text = "→";
                    else if (keys[i][j] == Keys.Enter)
                        btns[i][j].Text = "Enter";
                    else
                        btns[i][j].Text = keys[i][j].ToString();
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            controls_group.Focus();
            Button[][] btns =
            {
                new Button[] { up_btn_pl1, up_btn_pl2 },
                new Button[] { down_btn_pl1, down_btn_pl2 },
                new Button[] { left_btn_pl1, left_btn_pl2 },
                new Button[] { right_btn_pl1, right_btn_pl2 },
                new Button[] { shot_btn_pl1, shot_btn_pl2 },
                new Button[] { clear_btn_pl1, clear_btn_pl2 },
            };
            Button btn = sender as Button;
            if (btn == btns[5][0])
            {
                in_rebind = false;
                up_btn_pl1.Text = "W";
                down_btn_pl1.Text = "S";
                left_btn_pl1.Text = "A";
                right_btn_pl1.Text = "D";
                shot_btn_pl1.Text = "Space";
                for (int i = 0; i < btns.Length - 1; i++)
                    keys[i][0] = (Keys)Enum.Parse(typeof(Keys), btns[i][0].Text);
            }
            else if (btn == btns[5][1])
            {
                in_rebind = false;
                up_btn_pl2.Text = "Up";
                down_btn_pl2.Text = "Down";
                left_btn_pl2.Text = "Left";
                right_btn_pl2.Text = "Right";
                shot_btn_pl2.Text = "Enter";
                for (int i = 0; i < btns.Length - 1; i++)
                    keys[i][1] = (Keys)Enum.Parse(typeof(Keys), btns[i][1].Text);
                up_btn_pl2.Text = "↑";
                down_btn_pl2.Text = "↓";
                left_btn_pl2.Text = "←";
                right_btn_pl2.Text = "→";
            }
            else
            {
                for (int i = 0; i < btns.Length; i++)
                {
                    for (int j = 0; j < btns[i].Length; j++)
                    {
                        btns[i][j].Enabled = false;
                        map_list.Enabled = false;
                        if (btn == btns[i][j])
                        {
                            index = i;
                            key_index = j;
                            restore_name = btn.Text;
                            btn.Text = "...";
                            if (key_index == 1)
                                task_text1.Visible = true;
                            else
                                task_text2.Visible = true;
                            in_rebind = true;
                        }
                    }
                }
            }
        }

        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            Button[][] btns =
            {
                new Button[] { up_btn_pl1, up_btn_pl2 },
                new Button[] { down_btn_pl1, down_btn_pl2 },
                new Button[] { left_btn_pl1, left_btn_pl2 },
                new Button[] { right_btn_pl1, right_btn_pl2 },
                new Button[] { shot_btn_pl1, shot_btn_pl2 },
                new Button[] { clear_btn_pl1, clear_btn_pl2 },
            };
            if (in_rebind)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    in_rebind = false;
                    btns[index][key_index].Text = restore_name;
                }
                else
                {
                    if (e.KeyCode == Keys.Up)
                        btns[index][key_index].Text = "↑";
                    else if (e.KeyCode == Keys.Down)
                        btns[index][key_index].Text = "↓";
                    else if (e.KeyCode == Keys.Left)
                        btns[index][key_index].Text = "←";
                    else if (e.KeyCode == Keys.Right)
                        btns[index][key_index].Text = "→";
                    else if (e.KeyCode == Keys.Enter)
                        btns[index][key_index].Text = "Enter";
                    else
                        btns[index][key_index].Text = e.KeyCode.ToString();
                    keys[index][key_index] = e.KeyCode;
                    in_rebind = false;
                }
                for (int i = 0; i < btns.Length; i++)
                {
                    for (int j = 0; j < btns[i].Length; j++)
                        btns[i][j].Enabled = true;
                }
                map_list.Enabled = true;
                task_text1.Visible = task_text2.Visible = false;
            }
            else
            {
                if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
                    Close();
            }
        }

        private void Map_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tanks.map_choice = map_list.SelectedIndex;
            if(map_list.SelectedIndex == 2)
            {
                if (inverted.Value == 0)
                {
                    pl1_inverted_text.Text = "PLAYER 2";
                    pl2_inverted_text.Text = "PLAYER 1";
                }
                else
                {
                    pl1_inverted_text.Text = "PLAYER 1";
                    pl2_inverted_text.Text = "PLAYER 2";
                }
            }
            else
            {
                if (inverted.Value == 1)
                {
                    pl1_inverted_text.Text = "PLAYER 2";
                    pl2_inverted_text.Text = "PLAYER 1";
                }
                else
                {
                    pl1_inverted_text.Text = "PLAYER 1";
                    pl2_inverted_text.Text = "PLAYER 2";
                }
            }
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "map", map_list.SelectedIndex);
        }

        private void Inverted_Scroll(object sender, EventArgs e)
        {
            string prev;
            if (inverted.Value == 0) Tanks.inverted = false;
            else Tanks.inverted = true;
            prev = pl1_inverted_text.Text;
            pl1_inverted_text.Text = pl2_inverted_text.Text;
            pl2_inverted_text.Text = prev;
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "inverted", Tanks.inverted);
        }

        private void Fast_reload_CheckedChanged(object sender, EventArgs e)
        {
            Tanks.fast_reload = fast_reload.Checked;
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "fast_reload", Tanks.fast_reload);
        }

        private void Player1_group_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (MainMenu.Language)
                MessageBox.Show("Настройки управления игрока 1", "Подсказка", MessageBoxButtons.OK);
            else
                MessageBox.Show("Player 1's Control Settings", "Hint", MessageBoxButtons.OK);
        }

        private void Clear_btn_pl1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (MainMenu.Language)
                MessageBox.Show("Сброс настроек управления игрока 1 к значениям по умолчанию", "Подсказка", MessageBoxButtons.OK);
            else
                MessageBox.Show("Resetting Player 1's Control Settings to Defaults", "Hint", MessageBoxButtons.OK);
        }

        private void Player2_group_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (MainMenu.Language)
                MessageBox.Show("Настройки управления игрока 2", "Подсказка", MessageBoxButtons.OK);
            else
                MessageBox.Show("Player 2's Control Settings", "Hint", MessageBoxButtons.OK);
        }

        private void Clear_btn_pl2_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (MainMenu.Language)
                MessageBox.Show("Сброс настроек управления игрока 2 к значениям по умолчанию", "Подсказка", MessageBoxButtons.OK);
            else
                MessageBox.Show("Resetting Player 2's Control Settings to Defaults", "Hint", MessageBoxButtons.OK);
        }

        private void Map_list_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (MainMenu.Language)
                MessageBox.Show("Выберите карту из списка ниже", "Подсказка", MessageBoxButtons.OK);
            else
                MessageBox.Show("Select a card from the list below", "Hint", MessageBoxButtons.OK);
        }

        private void Inverted_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (MainMenu.Language)
                MessageBox.Show("Используйте переключатель, чтобы поменять местами игрока 1 и игрока 2", "Подсказка", MessageBoxButtons.OK);
            else
                MessageBox.Show("Use the switch to invert the position of player 1 and player 2", "Hint", MessageBoxButtons.OK);
        }

        private void Fast_reload_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (MainMenu.Language)
                MessageBox.Show("Используйте переключатель, чтобы включить или отключить быструю перезарядку", "Подсказка", MessageBoxButtons.OK);
            else
                MessageBox.Show("Use the switch to enable or disable fast recharge", "Hint", MessageBoxButtons.OK);
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "up_pl1", keys[0][0]);
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "down_pl1", keys[1][0]);
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "left_pl1", keys[2][0]);
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "right_pl1", keys[3][0]);
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "shot_pl1", keys[4][0]);
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "up_pl2", keys[0][1]);
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "down_pl2", keys[1][1]);
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "left_pl2", keys[2][1]);
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "right_pl2", keys[3][1]);
            INIReader.SetKey(MainMenu.iniFolder, "Tanks", "shot_pl2", keys[4][1]);
            Tanks.keys = keys;
        }
    }
}