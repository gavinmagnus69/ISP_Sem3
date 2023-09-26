namespace _253502_AKHMETOV_LAB4;

public class FileService<T> : IFIleService<T> 
{
    public IEnumerable<T> ReadFile(string fileName)
    {
        using (var stream = new FileStream(fileName,
                   FileMode.OpenOrCreate,
                   FileAccess.ReadWrite))
        {
            var binReader = new BinaryReader(stream);
            
            
            
            
            
            
        }
    

    
    }
    

    public void SaveData(IEnumerable<T> data, string fileName)
    {
        using (var stream = File.OpenWrite("binDemo.file"))
        {
            var binWriter = new BinaryWriter(stream);
            foreach (var obj in data)
            {
                binWriter.Write(obj);
                
            }

        }

        
        
        
        //throw new NotImplementedException();
    }
    public void SaveData(IEnumerable<Passangers> data, string fileName)
    {
        using (var stream = File.OpenWrite("binDemo.file"))
        {
            var binWriter = new BinaryWriter(stream);
            foreach (var obj in data)
            {
                binWriter.Write(obj.name);
                binWriter.Write(obj.age);
                binWriter.Write(obj.married);
            }

        }

        
        
        
        //throw new NotImplementedException();
    }
}