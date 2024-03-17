using System;
using NAudio.Wave;

namespace minigames
{
    internal class PlaySound : IDisposable
    {
        private WaveFileReader file;
        private WaveOutEvent playing;

        public PlaySound(string path)
        {
            file = new WaveFileReader(path);
            playing = new WaveOutEvent();
            playing.Init(file);
        }

        public void Play()
        {
            playing.Volume = 0.5f;
            playing.Play();
            playing.PlaybackStopped += new EventHandler<StoppedEventArgs>(Stoped);
        }

        public long Check()
        {
            return playing.GetPosition();
        }

        private void Stoped(object sender, EventArgs e)
        {
            Dispose();
        }

        public void Dispose()
        {
            file?.Dispose();
            playing?.Dispose();
        }
    }
}
