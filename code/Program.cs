using System;
using System.Threading;
using System.Windows.Forms;

namespace minigames
{
    internal static class Program
    {
        public static Mutex mutex;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            mutex = new Mutex(true, "Mini_Games_Unique_Mutex");
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainMenu());
                mutex.ReleaseMutex();
            }
        }
    }
}