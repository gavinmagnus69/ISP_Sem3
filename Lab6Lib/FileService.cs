namespace Lab6Lib;
using Lab6;
using Newtonsoft.Json;
public class FileService<T> : IFileService<T> 
{
    public IEnumerable<T> ReadFile(string fileName)
    {
        string s = File.ReadAllText(fileName);
        return JsonConvert.DeserializeObject<IEnumerable<T>>(s);
    }

    public void SaveData(IEnumerable<T> data, string fileName)
    {
        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(fileName, json);
    }
}