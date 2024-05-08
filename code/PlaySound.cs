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
            try
            {
                file = new WaveFileReader(path);
                playing = new WaveOutEvent();
                playing.Init(file);
            }
            catch (Exception)
            {
                Dispose();
            }
        }

        public void Play(float volume)
        {
            try
            {
                file.Position = 0;
                playing.Volume = volume;
                playing.Play();
            }
            catch { }
        }

        public void PlayWithDispose(float volume)
        {
            try
            {
                file.Position = 0;
                playing.Volume = volume;
                playing.PlaybackStopped += new EventHandler<StoppedEventArgs>(Stoped);
                playing.Play();
            }
            catch { }
        }

        private void Stoped(object sender, EventArgs e)
        {
            Dispose();
        }

        public void LoopPlay(float volume)
        {
            playing.Volume = volume;
            playing.Play();
            playing.PlaybackStopped += new EventHandler<StoppedEventArgs>(Loop);
        }

        private void Loop(object sender, EventArgs e)
        {
            try
            {
                file.Position = 0;
                playing.Play();
            }
            catch { }
        }

        public long Check()
        {
            return playing.GetPosition();
        }

        public void Dispose()
        {
            file?.Dispose();
            playing?.Dispose();
        }
    }
}