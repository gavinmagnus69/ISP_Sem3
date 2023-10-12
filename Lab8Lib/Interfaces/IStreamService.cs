namespace Lab8Lib;

public interface IStreamService<T>
{
    public Task WriteToStreamAsync(Stream stream, IEnumerable<T> data, IProgress<string> progress);

    public Task CopyFromStreamAsync(Stream stream, string filename, IProgress<string> progress);

    public Task<int> GetStatisticsAsync(string fileName, Func<T, bool> filter);
}