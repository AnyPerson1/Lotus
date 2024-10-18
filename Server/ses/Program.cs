using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

class Program
{
    private static WaveInEvent waveSource;
    private static WaveOutEvent waveOut;
    private static BufferedWaveProvider waveProvider;

    static void Main(string[] args)
    {
        waveSource = new WaveInEvent();
        waveSource.WaveFormat = new WaveFormat(192000, 32, 1); // 44.1 kHz, mono

        waveProvider = new BufferedWaveProvider(waveSource.WaveFormat);
        waveOut = new WaveOutEvent();
        waveOut.Init(waveProvider);

        waveSource.DataAvailable += OnDataAvailable;
        waveSource.RecordingStopped += OnRecordingStopped;

        Console.WriteLine("Ses kaydı başlatılıyor. Kaydı durdurmak için 'Enter' tuşuna basın.");
        waveSource.StartRecording();
        waveOut.Play(); // Ses çıkışını başlat

        Console.ReadLine();

        waveSource.StopRecording();
        Console.WriteLine("Ses kaydı durduruldu.");
    }

    private static void OnDataAvailable(object sender, WaveInEventArgs e)
    {
        // Gelen ses verisini waveProvider'a ekleyin
        waveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
    }

    private static void OnRecordingStopped(object sender, StoppedEventArgs e)
    {
        waveOut.Stop();
        waveOut.Dispose();
        waveSource.Dispose();
    }
}
