using NAudio.Wave;
using System;
using System.Timers;
using System.Threading;

namespace EasyAudio
{
    public class SineWave : IDisposable
    {
        private SineWaveProvider32 sineWave;
        private WaveOut waveOut;

        public float Frequency
        {
            get { return sineWave.Frequency; }
            set { sineWave.Frequency = value; }
        }

        public float Amplitude
        {
            get { return sineWave.Amplitude; }
            set { sineWave.Amplitude = value; }
        }
        
        public SineWave(float frequency, float amplitude = 0.25f, int sampleRate = 16000, int channels = 1)
        {
            sineWave = new SineWaveProvider32(frequency, amplitude, sampleRate, channels);
            waveOut = new WaveOut();
            waveOut.Init(sineWave);
        }

        public void PlayOnce(float duration)
        {
            waveOut.Play();
            Thread.Sleep((int)(duration * 1000f));
            waveOut.Stop();
        }

        public void PlayOnceAsync(float duration)
        {
            waveOut.Play();
            var timer = new System.Timers.Timer { Interval = (duration * 1000f) };
            timer.Elapsed += new ElapsedEventHandler((o, e) => waveOut.Stop());
            timer.Elapsed += new ElapsedEventHandler((o, e) => timer.Enabled = false);
            timer.Enabled = true;
        }

        public void Play()
        {
            waveOut.Play();
        }

        public void Stop()
        {
            waveOut.Stop();
        }

        public void Dispose()
        {            
            waveOut.Dispose();
            waveOut = null;
        }
    }    
}