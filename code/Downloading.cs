using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace minigames
{
    public partial class Downloading : Form
    {
        public Downloading()
        {
            InitializeComponent();
        }

        private readonly string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\Setup_Mini_Games.exe";
        private bool complete = false, canceled = false;
        public static bool language = true;
        private readonly WebClient client = new WebClient();

        private void Downloading_Load(object sender, EventArgs e)
        {
            if (!language)
            {
                Text = "Downloading...";
                title.Text = "Downloading update...";
                cancel.Text = "Cancel";
            }
            if (File.Exists(downloadsPath))
                File.Delete(downloadsPath);
            try
            {
                client.DownloadFileAsync(new Uri("https://base-escape.ru/downloads/Setup_Mini_Games.exe"), downloadsPath);
            }
            catch (Exception error)
            {
                Error(error);
            }
            client.DownloadProgressChanged += (Sender, E) =>
            {
                download_progress.Width = (int)((double)E.BytesReceived / E.TotalBytesToReceive * download_progress_panel.Width);
                progress.Text = $"{(Convert.ToDouble(E.BytesReceived) / E.TotalBytesToReceive) * 100:0.#}%";
                size_label.Text = $"{Convert.ToDouble(E.BytesReceived) / 1024 / 1024:0.##}MB / {Convert.ToDouble(E.TotalBytesToReceive) / 1024 / 1024:0.##}MB";
            };
            client.DownloadFileCompleted += (Sender, E) =>
            {
                if (!canceled)
                {
                    try
                    {
                        complete = true;
                        Close();
                        Process.Start(new ProcessStartInfo(downloadsPath) { UseShellExecute = true });
                        Application.Exit();
                    }
                    catch (Exception error)
                    {
                        Error(error);
                    }
                }
            };
        }

        private void Error(Exception error)
        {
            string message = $"Во время загрузки обновления произошла ошибка! {error.Message}.", title = $"Ошибка {error.HResult}!";
            if (!language)
            {
                message = $"An error occurred while downloading the update! {error.Message}.";
                title = $"Error {error.HResult}!";
            }
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            complete = true;
            Application.Exit();
        }

        private void Downloading_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!complete)
                e.Cancel = true;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            canceled = complete = true;
            client.CancelAsync();
            Application.Exit();
        }
    }
}
