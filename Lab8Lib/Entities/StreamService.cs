using System.Globalization;
using System.Net.Mime;
using System.Reflection.Emit;

namespace Lab8Lib;
using Newtonsoft.Json;
public class StreamService<T> : IStreamService<T> where T : Passanger
{
    private readonly SemaphoreSlim writeSemaphore = new SemaphoreSlim(1);
    private readonly SemaphoreSlim copySemaphore = new SemaphoreSlim(0);
    public async Task WriteToStreamAsync(Stream stream, IEnumerable<T> data, IProgress<string> progress)
    {
        writeSemaphore.WaitAsync();
        progress.Report($"Stream {Thread.CurrentThread.ManagedThreadId}, started to write to stream");
        string json = JsonConvert.SerializeObject(data);
       
        StreamWriter writer = new StreamWriter(stream);
        
            await writer.WriteAsync(json);
            await writer.FlushAsync();
        
        await Task.Delay(4000);
        progress.Report($"Stream {Thread.CurrentThread.ManagedThreadId}, finished to write to stream");
        writeSemaphore.Release();
        copySemaphore.Release();
    }

    public async Task CopyFromStreamAsync(Stream stream, string filename, IProgress<string> progress)
    {
        copySemaphore.WaitAsync();
        progress.Report($"Stream {Thread.CurrentThread.ManagedThreadId}, started to coping from stream to another stream");
       
        stream.Position = 0;
        StreamReader reader = new StreamReader(stream);
        string s = await reader.ReadToEndAsync();
        await File.WriteAllTextAsync(filename, s);
     

        await Task.Delay(4000);
        progress.Report($"Stream {Thread.CurrentThread.ManagedThreadId}, finished to coping from stream to another stream");
        //throw new NotImplementedException();
        copySemaphore.Release();
    }

    public async Task<int> GetStatisticsAsync(string fileName, Func<T, bool> filter)
    {
        
        //var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        string info = await File.ReadAllTextAsync(fileName);
        //Console.WriteLine(info);
        IEnumerable<T> col = JsonConvert.DeserializeObject<IEnumerable<T>>(info);
        int num_of_pas = 0;
        //Console.WriteLine(col.Count());
        foreach (var i in col)
        {
            //Console.WriteLine($"name = {i.name}, id = {i.id}, luggage = {i.luggage}");
            if (filter(i))
            {
                ++num_of_pas;
            }
        }
        Console.WriteLine("number of passangers with luggage is {0}", num_of_pas);
        return 0;
        //throw new NotImplementedException();
    }
}