namespace Akhmetov2.Domain;
public interface ISerializer<T> where T : Hospital
{
    public IEnumerable<T> DeSerializeByLINQ(string fileName);
    public IEnumerable<T> DeSerializeXML(string fileName);
    public IEnumerable<T> DeSerializeJSON(string fileName);
    public void SerializeByLINQ(IEnumerable<T> xxx, string fileName);
    public void SerializeXML(IEnumerable<T> xxx, string fileName);
    public void SerializeJSON(IEnumerable<T> xxx, string fileName);
    
}