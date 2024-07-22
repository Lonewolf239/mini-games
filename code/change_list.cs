﻿using System;
using System.Windows.Forms;

namespace minigames
{
    public partial class Change_list : Form
    {
        public Change_list()
        {
            InitializeComponent();
        }

        private string key = "";

        private void Changes_list_Enter(object sender, EventArgs e) => Focus();

        private void Ok_Click(object sender, EventArgs e) => Close();

        private void Change_list_Load(object sender, EventArgs e)
        {
            string[] list =
            {
                "\t\t\tv0.3.6",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added sprites for game objects",
                "   • Minor visual improvements",
                "   • Fixed some bugs",
                "\n",
                "\t\t\tv0.3.5.4",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added new weapon: [SECRET]",
                "   • Minor visual improvements",
                "\n",
                "\t\t\tv0.3.5.3",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added new healing animation",
                "\n",
                "\t\t\tv0.3.5.2a",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added description of difficulties",
                "   • Minor visual improvements",
                "\n",
                "\t\t\tv0.3.5.2",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added new weapon: M1911",
                "   • Minor visual improvements",
                "   • Fixed some bugs",
                "\n",
                "\t\t\tv0.3.5.1",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Minor visual improvements",
                "   • Fixed some bugs",
                "\n",
                "\t\t\tv0.3.5",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added player collision",
                "   • Added the ability to take a screenshot",
                "   • Fixed interaction with doors",
                "   • Fixed several critical bugs",
                "   • Minor visual improvements",
                "   • Fixed some bugs",
                "\n",
                "\t\t\tv0.3.4.9",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added new weapon: Knife",
                "   • Minor visual improvements",
                "   • Fixed some bugs",
                "\n",
                "\t\t\tv0.3.4.8",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added Windows up-to-date check",
                "   • Fixed some bugs",
                "\n",
                "\t\t\tv0.3.4.7b",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Fixed some bugs",
                "\n",
                "\t\t\tv0.3.4.7a",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Fixed some bugs",
                "\n",
                "\t\t\tv0.3.4.7",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Fixed fish eye effect",
                "   • Fixed wall texturing",
                "\n",
                "\t\t\tv0.3.4.6",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added pause",
                "   • Fixed some bugs",
                "\n",
                "\t\t\tv0.3.4.5",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Change progression and difficulty",
                "   • Rebalance the economy",
                "   • Minor visual improvements",
                "   • Fixed some bugs",
                "• Minor visual improvements",
                "\n",
                "\t\t\tv0.3.4.4",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Minor optimization improvements",
                "   • Improved stability",
                "   • Added the ability to enable higher resolution",
                "   • Some bugs have been fixed",
                "\n",
                "\t\t\tv0.3.4.3",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added textures for the ceiling and floor",
                "   • Fixed fish eye effect",
                "   • AddedMinor fixes and improvements",
                "\n",
                "\t\t\tv0.3.4.2",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added display of textures for windows",
                "\n",
                "\t\t\tv0.3.4.1",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Critical bug fixed",
                "\n",
                "\t\t\tv0.3.4",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added texture rendering",
                "   • Added textures to game objects",
                "   • Improved stability",
                "   • New types of sights have been added",
                "   • Some bugs have been fixed",
                "\n",
                "\t\t\tv0.3.3.1",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Critical bug fixed",
                "\n",
                "\t\t\tv0.3.3",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Console change:",
                "      • New commands added",
                "      • Visual improvements",
                "      • Improved stability",
                "   • Music reworked",
                "   • Visual improvements",
                "   • Some bugs fixed",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.3.2",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Console added",
                "   • Visual improvements",
                "   • Some bugs fixed",
                "\n",
                "\t\t\tv0.3.1.1",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Redesigned flashlight",
                "   • Some bugs have been fixed",
                "\n",
                "\t\t\tv0.3.1",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Visual improvements",
                "   • Added 2 new items:",
                "      • Flashlight",
                "      • First Aid Kit",
                "   • Some bugs have been fixed",
                "• Improved stability",
                "\n",
                "\t\t\tv0.3",
                "_______________________________________________________________",
                "• Changes to the game \"Mazeness\":",
                "   • Improved optimization",
                "   • Completely reworked rendering",
                "   • Visual enhancements",
                "   • Fixed some bugs",
                "• Enhanced stability",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.2.9",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Improved optimization",
                "   • Redesigned rendering",
                "   • Minor visual improvements",
                "   • Some bugs have been fixed",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.2.8",
                "_______________________________________________________________",
                "• Added support for .cgf format",
                "• Changing the game \"Mazeness\":",
                "   • Added weapon level system for:",
                "       • SMG",
                "       • Rifle",
                "       • Sniper",
                "   • Minor visual improvements",
                "   • Some bugs have been fixed",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.2.7",
                "_______________________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added weapon level system for:",
                "       • pistol",
                "       • shotgun",
                "   • Added 3 new types of weapons:",
                "       • SMG",
                "       • assault rifle",
                "       • sniper rifle",
                "   • Added 2 new types of enemies",
                "   • Minor visual improvements",
                "   • Some bugs have been fixed",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.2.6",
                "______________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Added 2 new weapons: Pistol and Shotgun",
                "   • Added enemies",
                "   • Minor visual improvements",
                "   • Some bugs have been fixed",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.2.5",
                "______________________________________________________",
                "• Changing the game \"Mazeness\":",
                "   • Camera redesigned",
                "   • Windows added",
                "   • Fixed some bugs",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.2.4.5",
                "______________________________________________________",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.2.4.4",
                "______________________________________________________",
                "• Added level editor for the game \"Mazeness\"",
                "\n",
                "\t\t\tv0.2.4.3",
                "______________________________________________________",
                "• Changed game controls \"Mazeness\"",
                "• Added scaling for the game \"Mazeness\"",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.2.4.2",
                "______________________________________________________",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.2.4.1",
                "______________________________________________________",
                "• Visual improvement",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.2.4",
                "______________________________________________________",
                "• Added a new game \"Sapper\"",
                "• Visual improvement",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.2.3.1",
                "______________________________________________________",
                "• Gameplay improvements to \"Mazeness\"",
                "• Visual improvement",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.2.3",
                "______________________________________________________",
                "• Added a new game \"Mazeness\"",
                "• Improved stability",
                "• Minor improvements for future changes",
                "• Visual improvement",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.2.2.1",
                "______________________________________________________",
                "• Gameplay improvements to \"Tetris\"",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.2.2",
                "______________________________________________________",
                "• Added a new game \"Tetris\"",
                "• Improved stability",
                "• Visual improvement",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.2.1",
                "______________________________________________________",
                "• Added a new game \"Tanks\"",
                "• Added bug reporting system",
                "• Minor improvements for future changes",
                "• Visual improvement",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.2",
                "______________________________________________________",
                "• Added 2 new games: \"2048\" and \"Ping-Pong\"",
                "• Improved stability",
                "• Minor improvements for future changes",
                "• Visual improvement",
                "• Some bugs fixed",
                "\n",
                "\t\t\tv0.1.9.6.1",
                "______________________________________________________",
                "• Developments have been made for future changes",
                "• Visual improvements",
                "• Improved stability",
                "\n",
                "\t\t\tv0.1.9.6",
                "______________________________________________________",
                "• Added new game \"SudoSaga\"",
                "• Visual improvements",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.1.9.5",
                "______________________________________________________",
                "• Redesigned support for ini files",
                "• Auto-update bugs fixed",
                "• Visual improvements",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.1.9.4",
                "______________________________________________________",
                "• Added checking for updates",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.1.9.3",
                "_____________________________________________________",
                "• Added support for .ini files",
                "• Visual improvements",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.1.9.2",
                "_____________________________________________________",
                "• Gameplay improvements to \"Mini-Snake\"",
                "• Added list of changes",
                "• Improved stability",
                "• Visual improvements",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.1.9.1",
                "_____________________________________________________",
                "• Gameplay improvements to \"Mini-Snake\"",
                "• Added the ability to scale the interface",
                "• Added new sounds",
                "• Improved stability",
                "• Visual improvements",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.1.9",
                "_____________________________________________________",
                "• Added new game \"Soundotron\"",
                "• Visual improvements",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.1.8",
                "_____________________________________________________",
                "• The game \"Mini-Snake\" has been redesigned",
                "• Visual improvements",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.1.7",
                "_____________________________________________________",
                "• Added new mini-game",
                "• Visual improvements",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.1.6",
                "_____________________________________________________",
                "• Added new mini-game",
                "• Visual improvements",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.1.5",
                "_____________________________________________________",
                "• Added new mini-game",
                "• Visual improvements",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.1.4",
                "_____________________________________________________",
                "• Added 2 new mini-games",
                "• Control improvements",
                "• Visual improvements",
                "• Fixed some bugs",
                "\n",
                "\t\t\tv0.1.3.1",
                "_____________________________________________________",
                "• Added dynamic difficulty for \"ColorTiles\"",
                "• Fixed some bugs",
                "\t\t\tv0.1.3",
                "_____________________________________________________",
                "• Added new game \"ColorTiles\"",
                "• Some bugs fixed"
            };
            foreach (string text in list)
            {
                if (text.Contains("\n"))
                    break;
                if (text.Contains("_____________________________________________________"))
                    continue;
                richTextBox1.Text += text.Replace("\t", "").Replace("• ", "- ") + "\n";
            }
            if (MainMenu.Language)
            {
                Text = "Список изменений";
                list = new string[]
                {
                    "\t\t\tv0.3.6",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлены спрайты для игровых объектов",
                    "   • Незначительные визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.5.4",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлено новое оружие: [СЕКРЕТНО]",
                    "   • Незначительные визуальные улучшения",
                    "\n",
                    "\t\t\tv0.3.5.3",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлена новая анимация лечения",
                    "\n",
                    "\t\t\tv0.3.5.2a",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлено описание сложностей",
                    "   • Незначительные визуальные улучшения",
                    "\n",
                    "\t\t\tv0.3.5.2",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлено новое оружие: M1911",
                    "   • Незначительные визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.5.1",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Незначительные визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.5",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлено столкновение игрока",
                    "   • Добавлена возможность делать скриншоты",
                    "   • Исправлено взаимодействие с дверями",
                    "   • Исправлено несколько критических ошибок",
                    "   • Незначительные визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.4.9",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлено новое оружие: Нож",
                    "   • Небольшие визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.4.8",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлена ​​проверка актуальности Windows",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.4.7b",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.4.7a",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.4.7",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Исправлен эффект рыбьего глаза",
                    "   • Исправлено текстурирование стен",
                    "\n",
                    "\t\t\tv0.3.4.6",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлена пауза",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.4.5",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Изменение прогресса и сложности",
                    "   • Ребалансировка экономики",
                    "   • Небольшие визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "• Небольшие визуальные улучшения",
                    "\n",
                    "\t\t\tv0.3.4.4",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Небольшое улучшение оптимизации",
                    "   • Улучшенная стабильность",
                    "   • Добавлена возможность включить повышенное разрешение",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.4.3",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлены текстуры для потолка и пола",
                    "   • Исправлен эффект рыбьего глаза",
                    "   • Добавлены мелкие исправления и улучшения",
                    "\n",
                    "\t\t\tv0.3.4.2",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлено отображение текстур для окон",
                    "\n",
                    "\t\t\tv0.3.4.1",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Исправлена ​​критическая ошибка",
                    "\n",
                    "\t\t\tv0.3.4",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлен рендеринг текстур",
                    "   • Добавлены текстуры к игровым объектам",
                    "   • Улучшенная стабильность",
                    "   • Добавлены новые типы прицелов",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.3.1",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Исправлена ​​критическая ошибка",
                    "\n",
                    "\t\t\tv0.3.3",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Изменение консоли:",
                    "      • Добавлены новые команды",
                    "      • Визуальные улучшения",
                    "      • Улучшенная стабильность",
                    "   • Переработана музыка",
                    "   • Визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.2",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлена консоль",
                    "   • Визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.1.1",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Переработан фонарик",
                    "   • Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.3.1",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Визуальные улучшения",
                    "   • Добавлены 2 новых предмета:",
                    "      • Фонарик",
                    "      • Аптечка",
                    "   • Исправлены некоторые ошибки",
                    "• Улучшение стабильности",
                    "\n",
                    "\t\t\tv0.3",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Улучшенная оптимизация",
                    "   • Полностью переработан рендеринг",
                    "   • Визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "• Улучшение стабильности",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.9",
                    "_______________________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Улучшенная оптимизация",
                    "   • Переработан рендеринг",
                    "   • Небольшие визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.8",
                    "_______________________________________________________________",
                    "• Добавлена ​​поддержка формата .cgf",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлена ​​система уровней оружия для:",
                    "      • Пистолет-пулемёт",
                    "      • Автомат",
                    "      • Снайперка",
                    "   • Небольшие визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.7",
                    "______________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлена ​​система уровней оружия для:",
                    "       • пистолет",
                    "       • дробовик",
                    "   • Добавлено 3 новых вида оружия:",
                    "       • пистолет-пулемет",
                    "       • штурмовая винтовка",
                    "       • снайперская винтовка",
                    "   • Добавлено 2 новых типа врагов",
                    "   • Небольшие визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.6",
                    "______________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Добавлено 2 новых оружия: пистолет и дробовик",
                    "   • Добавлены враги",
                    "   • Небольшие визуальные улучшения",
                    "   • Исправлены некоторые ошибки",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.5",
                    "______________________________________________________",
                    "• Изменение игры \"Лабезумие\":",
                    "   • Изменен дизайн камеры",
                    "   • Добавлены окна",
                    "   • Исправлены некоторые ошибки",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.4.5",
                    "______________________________________________________",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.4.4",
                    "______________________________________________________",
                    "• Добавлен редактор уровня для игры \"Лабезумие\"",
                    "\n",
                    "\t\t\tv0.2.4.3",
                    "______________________________________________________",
                    "• Изменено управление игры \"Лабезумие\"",
                    "• Добавлено масштабирование игры \"Лабезумие\"",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.4.2",
                    "______________________________________________________",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.4.1",
                    "______________________________________________________",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.4",
                    "______________________________________________________",
                    "• Добавлена ​​новая игра \"Сапёр\"",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.3.1",
                    "______________________________________________________",
                    "• Геймплейные улучшения \"Лабезумие\"",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.3",
                    "______________________________________________________",
                    "• Добавлена ​​новая игра \"Лабезумие\"",
                    "• Улучшена стабильность",
                    "• Небольшие улучшения для будущих изменений",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.2.1",
                    "______________________________________________________",
                    "• Геймплейные улучшения \"Тутрис\"",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.2",
                    "______________________________________________________",
                    "• Добавлена ​​новая игра \"Тутрис\"",
                    "• Улучшена стабильность",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2.1",
                    "______________________________________________________",
                    "• Добавлена ​​новая игра \"Танчики\"",
                    "• Добавлена ​​система отчетов об ошибках",
                    "• Небольшие улучшения для будущих изменений",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.2",
                    "______________________________________________________",
                    "• Добавлены 2 новые игры: \"2048\" и \"Пинг-Понг\"",
                    "• Улучшена стабильность",
                    "• Незначительные улучшения для будущих изменений",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.9.6.1",
                    "______________________________________________________",
                    "• Внесены изменения для будущих изменений",
                    "• Визуальные улучшения",
                    "• Улучшена стабильность",
                    "\n",
                    "\t\t\tv0.1.9.6",
                    "______________________________________________________",
                    "• Добавлена новая игра \"СудоСага\"",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.9.5",
                    "_____________________________________________________",
                    "• Переработанная поддержка ini-файлов.",
                    "• Исправлены ошибки автоматического обновления",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.9.4",
                    "_____________________________________________________",
                    "• Добавлена проверка наличия обновления",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.9.3",
                    "_____________________________________________________",
                    "• Добавлена поддержка .ini файлов",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.9.2",
                    "_____________________________________________________",
                    "• Улучшения игрового процесса \"Мини-Змейки\"",
                    "• Добавлен список изменений",
                    "• Улучшена стабильность",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.9.1",
                    "_____________________________________________________",
                    "• Улучшения игрового процесса \"Мини-Змейки\"",
                    "• Добавлена возможность масштабирования интерфейса",
                    "• Добавлены новые звуки",
                    "• Улучшена стабильность",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.9",
                    "_____________________________________________________",
                    "• Добавлена новая игра \"Саундотрон\"",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.8",
                    "_____________________________________________________",
                    "• Игра \"Мини-Змейка\" переработана",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.7",
                    "_____________________________________________________",
                    "• Добавлена новая мини-игра",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.6",
                    "_____________________________________________________",
                    "• Добавлена новая мини-игра",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.5",
                    "_____________________________________________________",
                    "• Добавлена новая мини-игра",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.4",
                    "_____________________________________________________",
                    "• Добавлены 2 новые мини-игры",
                    "• Улучшения управления",
                    "• Визуальные улучшения",
                    "• Исправлены некоторые ошибки",
                    "\n",
                    "\t\t\tv0.1.3.1",
                    "_____________________________________________________",
                    "• Добавлена динамическая сложность для \"Цветнашек\"",
                    "• Исправлены некоторые ошибки",
                    "\t\t\tv0.1.3",
                    "_____________________________________________________",
                    "• Добавлена новая игра \"Цветнашки\"",
                    "• Исправлены некоторые ошибки"
                };
            }
            changes_list.Items.AddRange(list);
            ok.Left = (Width - ok.Width) / 2;
        }

        private void Change_list_KeyDown(object sender, KeyEventArgs e)
        {
            key += e.KeyCode.ToString();
            if (key == "DEV")
                richTextBox1.Visible = !richTextBox1.Visible;
        }

        private void changes_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}