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
                playing.Volume = volume;
                playing.Play();
                playing.PlaybackStopped += new EventHandler<StoppedEventArgs>(Stoped);
            }
            catch (Exception)
            {
                Dispose();
            }
        }

        public void LoopPlay(float volume)
        {
            try
            {
                playing.Volume = volume;
                playing.Play();
                playing.PlaybackStopped += new EventHandler<StoppedEventArgs>(Loop);
            }
            catch (Exception)
            {
                Dispose();
            }
        }

        private void Loop(object sender, EventArgs e)
        {
            try
            {
                file.Position = 0;
                playing.Play();
            }
            catch (Exception)
            {
                Dispose();
            }
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