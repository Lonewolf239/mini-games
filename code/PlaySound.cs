using System;
using System.IO;
using System.Threading.Tasks;
using NAudio.Wave;

namespace minigames
{
    public class PlaybackState
    {
        public bool IsPlaying { get; set; }
    }

    public class PlaySound : IDisposable
    {
        private WaveFileReader file;
        private WaveOutEvent playing;
        private bool stopped = false;

        public PlaySound(byte[] fileBytes)
        {
            try
            {
                file = new WaveFileReader(new MemoryStream(fileBytes));
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

        public void PlayFromThe(float volume, long position)
        {
            try
            {
                file.Position = position;
                playing.Volume = volume;
                playing.Play();
            }
            catch { }
        }

        public async Task<bool> PlayWithWait(float volume, PlaybackState state)
        {
            if (state.IsPlaying)
                return false;
            try
            {
                file.Position = 0;
                playing.Volume = volume;
                var tcs = new TaskCompletionSource<bool>();
                EventHandler<StoppedEventArgs> handler = null;
                handler = (sender, e) =>
                {
                    tcs.TrySetResult(true);
                    state.IsPlaying = false;
                    playing.PlaybackStopped -= handler;
                };
                playing.PlaybackStopped += handler;
                playing.Play();
                state.IsPlaying = true;
                await tcs.Task;
                return true;
            }
            catch
            {
                state.IsPlaying = false;
                return false;
            }
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

        private void Stoped(object sender, EventArgs e) => Dispose();

        public void LoopPlay(float volume)
        {
            try
            {
                stopped = false;
                playing.Volume = volume;
                playing.Play();
                playing.PlaybackStopped += new EventHandler<StoppedEventArgs>(Loop);
            }
            catch { }
        }

        private void Loop(object sender, EventArgs e)
        {
            if (stopped)
                return;
            try
            {
                file.Position = 0;
                playing.Play();
            }
            catch { }
        }

        public long Check() => playing.GetPosition();

        public void Stop()
        {
            stopped = true;
            playing.Stop();
            file.Position = 0;
        }

        public void Dispose()
        {
            file?.Dispose();
            playing?.Dispose();
        }
    }
}