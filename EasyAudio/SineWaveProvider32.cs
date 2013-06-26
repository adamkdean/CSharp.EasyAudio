using System;
using NAudio.Wave;

namespace EasyAudio
{
    public class SineWaveProvider32 : WaveProvider32
    {
        private int sample = 0;

        public float Frequency { get; set; }
        public float Amplitude { get; set; }

        public SineWaveProvider32(float frequency, float amplitude = 0.25f, int sampleRate = 16000, int channels = 1)
        {
            Frequency = frequency;
            Amplitude = amplitude;
            this.SetWaveFormat(sampleRate, channels);
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++)
            {
                buffer[n + offset] = (float)(Amplitude * Math.Sin((2 * Math.PI * sample * Frequency) / sampleRate));
                sample++;
                if (sample >= sampleRate) sample = 0;
            }
            return sampleCount;
        }
    }
}
