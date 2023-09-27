namespace _253502_AKHMETOV_LAB4;

public interface IFIleService<T>  where T : Passangers 
{
    IEnumerable<Passangers> ReadFile(string fileName);
    void SaveData(IEnumerable<T> data, string fileName);
}