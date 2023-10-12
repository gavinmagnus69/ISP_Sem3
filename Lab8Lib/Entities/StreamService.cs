namespace Lab8Lib;

public class StreamService<T> : IStreamService<T>
{
    public async Task WriteToStreamAsync(Stream stream, IEnumerable<T> data, IProgress<string> progress)
    {
        throw new NotImplementedException();
    }

    public async Task CopyFromStreamAsync(Stream stream, string filename, IProgress<string> progress)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetStatisticsAsync(string fileName, Func<T, bool> filter)
    {
        throw new NotImplementedException();
    }
}