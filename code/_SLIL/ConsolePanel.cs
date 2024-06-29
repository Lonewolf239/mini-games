using IniReader;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace minigames._SLIL
{
    public partial class ConsolePanel : UserControl
    {
        public ConsolePanel()
        {
            InitializeComponent();
        }

        private static bool ImHonest = false;
        private int cheat_index = 0;
        private readonly List<string> previous_cheat = new List<string>();
        public Gun[] GUNS;
        public Player player;
        private readonly Dictionary<string, Color> colorMap = new Dictionary<string, Color>
        {
            { "-", Color.Yellow },
            { "*", Color.Tomato },
            { "~", Color.Cyan },
        };

        private void GetFirstAidKit()
        {
            if (player.FirstAidKits.Count == 0)
                player.FirstAidKits.Add(GUNS[8]);
            player.FirstAidKits[0].AmmoCount = player.FirstAidKits[0].CartridgesClip;
            player.FirstAidKits[0].MaxAmmoCount = player.FirstAidKits[0].CartridgesClip;
            player.FirstAidKits[0].HasIt = true;
        }

        private void Command_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                e.SuppressKeyPress = true;
            if (e.KeyCode == Keys.Enter)
            {
                Color color = Color.Lime;
                e.SuppressKeyPress = true;
                if (command_input.Text.Length > 0)
                {
                    bool show_date = true, show_message = true;
                    string message = null, time = null;
                    string cheat = command_input.Text.ToUpper();
                    if (!previous_cheat.Contains(cheat))
                        previous_cheat.Add(cheat);
                    cheat_index = previous_cheat.Count - 1;
                    command_input.Text = null;
                    if (cheat == "HELP")
                    {
                        show_date = false;
                        message = "\n" +
                         "~┌──────────┬─────────────────────────────────────────────┐~\n" +
                         "~│~ *Command*  ~│~ *Description*                                 ~│~\n" +
                         "~├──────────┼─────────────────────────────────────────────┤~\n" +
                         "~│~ -CLS-      ~│~ Clearing the console                        ~│~\n" +
                         "~│~ -SLS-      ~│~ Clear console history                       ~│~\n" +
                         "~│~ -FPS-      ~│~ Show/hide FPS                               ~│~\n" +
                         "~│~ -VOL_-*X*    ~│~ Change volume of sounds to X                ~│~\n" +
                         "~│~ -SCOPE_-*X*  ~│~ Replace current sight                       ~│~\n" +
                         "~│~ -CCHANC_-*X* ~│~ Set the probability of cursed treatment     ~│~\n" +
                         "~│~ -MONEY_-*X*  ~│~ Change the amount of money to X             ~│~\n" +
                         "~│~ -STAMIN_-*X* ~│~ Changing a player's maximum stamina         ~│~\n" +
                         "~│~ -GUNS-     ~│~ Viewing weapon parameters                   ~│~\n" +
                         "~│~ -KILL-     ~│~ Kill a player                               ~│~\n" +
                         "~│~ -IMHONEST- ~│~ Disable cheats                              ~│~\n" +
                         "~│~ -SOTLG-    ~│~ Maximum amount of money                     ~│~\n" +
                         "~│~ -BEFWK-    ~│~ Issue out all weapons                       ~│~\n" +
                         "~│~ -BIGGUY-   ~│~ Give out \"The Smallest Pistol in the World\" ~│~\n" +
                         "~│~ -EGTRE-    ~│~ Issue first aid kits                        ~│~\n" +
                         "~│~ -FYTLG-    ~│~ Maximum amount of ammunition                ~│~\n" +
                         "~│~ -GKIFK-    ~│~ Restore maximum health                      ~│~\n" +
                         "~│~ -IDDQD-    ~│~ Upgrade all weapons by one level            ~│~\n" +
                         "~│~ -LPFJY-    ~│~ Cause 99 damage                             ~│~\n" +
                         "~│~ -YHRII-    ~│~ Issue \"Fingershot\"                          ~│~\n" +
                         "~└──────────┴─────────────────────────────────────────────┘~";
                    }
                    else if (cheat == "GUNS")
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("\n~|───────────────────────|~");
                        sb.AppendLine("~|~      *Weapon Name*      ~|~");
                        sb.AppendLine("~|───────────────────────|~");
                        int maxLength = 21;
                        for (int i = 0; i < GUNS.Length; i++)
                        {
                            string paddedName = GUNS[i].Name[1].PadRight(maxLength);
                            sb.AppendLine($"~|~ {paddedName} ~|~");
                        }
                        sb.AppendLine("~|───────────────────────|~");
                        sb.AppendLine("To select a weapon, write GUN_*WeaponName*");
                        show_date = false;
                        message = sb.ToString();

                    }
                    else if (cheat.StartsWith("GUN_"))
                    {
                        string name = cheat.Split('_')[1];
                        Gun selected = null;
                        foreach (Gun gun in GUNS)
                        {
                            if (gun.Name[1].ToLower() == name.ToLower())
                            {
                                selected = gun;
                                break;
                            }
                        }
                        if (selected == null)
                        {
                            color = Color.Red;
                            message += "This weapon is not on the list.";
                        }
                        else
                        {
                            PropertyInfo[] properties = typeof(Gun).GetProperties();
                            int maxPropNameLength = properties.Max(p => p.Name.Length);
                            int maxValueLength = properties.Max(p => p.GetValue(selected)?.ToString().Length ?? 0);
                            int columnWidth = Math.Max(maxPropNameLength, maxValueLength);
                            string line = new string('─', columnWidth + 2);
                            StringBuilder table = new StringBuilder();
                            table.AppendLine($"\n~┌{line}┬{line}┐~");
                            table.AppendLine($"~│~ *{"Parameter".PadRight(columnWidth)}* ~│~ *{"Value".PadRight(columnWidth)}* ~│~");
                            table.AppendLine($"~├{line}┼{line}┤~");
                            foreach (PropertyInfo property in properties)
                            {
                                string propName = property.Name.PadRight(columnWidth);
                                object propValueObj = property.GetValue(selected);
                                string propValue = "";
                                if (propValueObj is string[] names && names.Length > 0)
                                    propValue = names[1];
                                else
                                    propValue = propValueObj?.ToString() ?? "";
                                propValue = propValue.PadRight(columnWidth);
                                table.AppendLine($"~│~ -{propName}- ~│~ {propValue} ~│~");
                            }
                            table.AppendLine($"~└{line}┴{line}┘~");
                            show_date = false;
                            message = table.ToString();
                        }
                    }
                    else if (cheat == "IMHONEST")
                    {
                        if (!ImHonest)
                        {
                            ImHonest = true;
                            message = "You're above the rest for choosing the -honest- path. Respect for keeping the game real!";
                        }
                        else
                            message = "This action cannot be undone! Are you -honest-?)";
                    }
                    else if (cheat == "CLS")
                    {
                        show_date = false;
                        console.Text = null;
                        message = "SLIL console *v1.0*\nType \"-help-\" for a list of commands...";
                        console.Refresh();
                    }
                    else if (cheat == "SLC")
                    {
                        show_message = false;
                        previous_cheat.Clear();
                    }
                    else if (cheat.StartsWith("SAY "))
                        message += cheat.Split(' ')[1];
                    else if (cheat == "FPS")
                    {
                        SLIL.ShowFPS = !SLIL.ShowFPS;
                        INIReader.SetKey(MainMenu.iniFolder, "SLIL", "show_fps", SLIL.ShowFPS);
                        if (SLIL.ShowFPS)
                            message += "FPS display enabled.";
                        else
                            message += "FPS display disabled.";
                    }
                    else if (cheat.StartsWith("VOL_"))
                    {
                        try
                        {
                            float x = Convert.ToSingle(cheat.Split('_')[1].Replace('.', ','));
                            if (x >= 0.1 && x <= 1)
                            {
                                message += $"Current volume is now {x}. *Default: 0,4*";
                                SLIL.Volume = x;
                                SLIL.SetVolume();
                            }
                            else
                            {
                                color = Color.Red;
                                message = "Incorrect value! X must be in the range from 0,1 to 1.";
                            }
                        }
                        catch
                        {
                            color = Color.Red;
                            message = "Incorrect data entered! X is not a number.";
                        }
                    }
                    else if (cheat.StartsWith("SCOPE_"))
                    {
                        try
                        {
                            int x = Convert.ToInt32(cheat.Split('_')[1]);
                            if (x > -1 && x < 3)
                            {
                                message += $"Current crosshair is now {x}. *Default: 0*";
                                SLIL.scope_type = x;
                                INIReader.SetKey(MainMenu.iniFolder, "SLIL", "scope_type", x);
                            }
                            else
                            {
                                color = Color.Red;
                                message = "Incorrect value! X must be in the range from 0 to 2.";
                            }
                        }
                        catch
                        {
                            color = Color.Red;
                            message = "Incorrect data entered! X is not a number.";
                        }
                    }
                    else if (cheat.StartsWith("CCHANC_"))
                    {
                        double x = 0.08;
                        bool error = false;
                        try
                        {
                            x = Convert.ToDouble(cheat.Split('_')[1].Replace('.', ','));
                        }
                        catch
                        {
                            error = true;
                        }
                        if (error || x < 0 || x > 1)
                        {
                            color = Color.Red;
                            message = "Incorrect range specified! Instead of X, enter a number between 0 and 1.";
                        }
                        else
                        {
                            message += $"Set chance of curse healing to {x * 100:0,##}% *Default: 8%*";
                            player.CurseCureChance = x;
                        }
                    }
                    else if (cheat.StartsWith("MONEY_"))
                    {
                        try
                        {
                            int x = Convert.ToInt32(cheat.Split('_')[1]);
                            message += $"The amount of money has been changed to {x}";
                            player.ChangeMoney(x);
                        }
                        catch
                        {
                            color = Color.Red;
                            message = "Incorrect data entered! X is not a number.";
                        }
                    }
                    else if (cheat.StartsWith("STAMIN_"))
                    {
                        try
                        {
                            int x = Convert.ToInt32(cheat.Split('_')[1]);
                            message += $"Player stamina is now {x}. *Default: 650*";
                            player.MAX_STAMINE = x;
                        }
                        catch
                        {
                            color = Color.Red;
                            message = "Incorrect data entered! X is not a number.";
                        }
                    }
                    else if (cheat == "KILL")
                    {
                        show_message = false;
                        player.HP = 0;
                    }
                    else if (cheat == "BEFWK" && !ImHonest)
                    {
                        if (player.Guns.Count < 5)
                        {
                            for (int i = 0; i < GUNS.Length; i++)
                            {
                                if (GUNS[i].GunType != GunTypes.EasterEgg && GUNS[i].GunType != GunTypes.Tank && GUNS[i].GunType != GunTypes.FirstAidKit)
                                {
                                    GUNS[i].MaxAmmoCount = GUNS[i].MaxAmmo;
                                    if (i > 0)
                                    {
                                        GUNS[i].HasIt = true;
                                        if (!player.Guns.Contains(GUNS[i]))
                                            player.Guns.Add(GUNS[i]);
                                    }
                                }
                            }
                            message += "All weapons have been issued.";
                        }
                        else
                        {
                            color = Color.Red;
                            message = "Code not applied! You already have all the weapons.";
                        }
                    }
                    else if (cheat == "IDDQD" && !ImHonest)
                    {
                        bool can_do_it = false;
                        for (int i = 0; i < player.Guns.Count; i++)
                        {
                            if (player.Guns[i].Level != Levels.LV3 &&
                            player.Guns[i].GunType != GunTypes.Flashlight &&
                            player.Guns[i].GunType != GunTypes.FirstAidKit &&
                            player.Guns[i].GunType != GunTypes.Sniper &&
                            player.Guns[i].GunType != GunTypes.EasterEgg &&
                                player.Guns[i].GunType != GunTypes.Tank)
                                can_do_it = true;
                        }
                        if (can_do_it)
                        {
                            for (int i = 0; i < player.Guns.Count; i++)
                                player.Guns[i].LevelUpdate();
                            player.LevelUpdated = true;
                            message += "All weapon levels increased by one.";
                        }
                        else
                        {
                            color = Color.Red;
                            message = "Code not applied! You have already pumped all your weapons to the maximum.";
                        }
                    }
                    else if (cheat == "FYTLG" && !ImHonest)
                    {
                        for (int i = 0; i < player.Guns.Count; i++)
                        {
                            if (GUNS[i].GunType != GunTypes.EasterEgg && GUNS[i].GunType != GunTypes.FirstAidKit)
                                player.Guns[i].MaxAmmoCount = player.Guns[i].MaxAmmo;
                        }
                        message += "Maximum ammunition provided.";
                    }
                    else if (cheat == "SOTLG" && !ImHonest)
                    {
                        player.Money = 9999;
                        message += "Maximum money granted.";
                    }
                    else if (cheat == "YHRII" && !ImHonest)
                    {
                        if (!GUNS[6].HasIt)
                        {
                            GUNS[6].HasIt = true;
                            GUNS[6].MaxAmmoCount = GUNS[6].MaxAmmo;
                            if (!player.Guns.Contains(GUNS[6]))
                                player.Guns.Add(GUNS[6]);
                            message += "\"Fingershot\" issued.";
                        }
                        else
                        {
                            color = Color.Red;
                            message = "Code not applied! You already have \"Fingershot\".";
                        }
                    }
                    else if (cheat == "BIGGUY" && !ImHonest)
                    {
                        if (!GUNS[7].HasIt)
                        {
                            GUNS[7].HasIt = true;
                            GUNS[7].MaxAmmoCount = GUNS[7].MaxAmmo;
                            if (!player.Guns.Contains(GUNS[7]))
                                player.Guns.Add(GUNS[7]);
                            message += "\"The Smallest Pistol in the World.\" has been issued.";
                        }
                        else
                        {
                            color = Color.Red;
                            message = "Code not applied! You already have \"The Smallest Pistol in the World.\"";
                        }
                    }
                    else if (cheat == "GKIFK" && !ImHonest)
                    {
                        player.HP = 999;
                        message += "Maximum HP granted.";
                    }
                    else if (cheat == "EGTRE" && !ImHonest)
                    {
                        GetFirstAidKit();
                        message += "First aid kits issued.";
                    }
                    else if (cheat == "LPFJY" && !ImHonest)
                    {
                        player.DealDamage(99);
                        message += "Health reduced by 99.";
                    }
                    else
                    {
                        previous_cheat.Remove(cheat);
                        cheat_index = previous_cheat.Count - 1;
                        color = Color.Red;
                        message = $"Unknown command: {cheat}";
                    }
                    if (show_date)
                        time = $"\n-<{DateTime.Now:HH:mm}>- ";
                    if (show_message)
                        ConsoleAppendText($"{time}{message}", color);
                }
            }
            if (previous_cheat.Count > 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    command_input.Text = previous_cheat[cheat_index];
                    cheat_index--;
                    if (cheat_index < 0)
                        cheat_index = previous_cheat.Count - 1;
                    command_input.SelectionStart = command_input.Text.Length;
                }
                if (e.KeyCode == Keys.Down)
                {
                    command_input.Text = previous_cheat[cheat_index];
                    cheat_index++;
                    if (cheat_index >= previous_cheat.Count)
                        cheat_index = 0;
                    command_input.SelectionStart = command_input.Text.Length;
                }
            }
        }

        private void ConsoleAppendText(string text, Color color)
        {
            string pattern = string.Join("|", colorMap.Keys.Select(k => $@"(\{k}.*?\{k})"));
            string[] parts = Regex.Split(text, pattern);
            foreach (string part in parts)
            {
                if (string.IsNullOrEmpty(part))
                    continue;
                var colorPair = colorMap.FirstOrDefault(pair => part.StartsWith(pair.Key) && part.EndsWith(pair.Key));
                if (colorPair.Key != null)
                {
                    string word = part.Trim(colorPair.Key.ToCharArray());
                    ConsoleAppendColoredText(word, colorPair.Value);
                }
                else
                    ConsoleAppendColoredText(part, color);
            }
            console.SelectionStart = console.Text.Length;
            console.ScrollToCaret();
        }

        private void ConsoleAppendColoredText(string text, Color color)
        {
            console.SelectionStart = console.Text.Length;
            console.SelectionLength = 0;
            console.SelectionColor = color;
            console.AppendText(text);
        }

        private void Console_panel_VisibleChanged(object sender, EventArgs e)
        {
            BringToFront();
            cheat_index = previous_cheat.Count - 1;
        }

        private void Console_Load(object sender, EventArgs e)
        {
            ConsoleAppendText("SLIL console *v1.0*\nType \"-help-\" for a list of commands...", Color.Lime);
            console.Refresh();
        }

        private void Console_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            command_input.Focus();
        }
    }
}