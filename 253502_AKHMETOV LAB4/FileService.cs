namespace _253502_AKHMETOV_LAB4;

public class FileService<T>: IFIleService<T> where T : Passangers
{
    
    
    public IEnumerable<Passangers> ReadFile(string fileName)
    {




        List<Passangers> l = new List<Passangers>();
        using (var stream = new FileStream(fileName,
                   FileMode.Open,
                   FileAccess.Read))
        {
            try
            {
                var binReader = new BinaryReader(stream);
                for (int i = 0; i < 5; ++i)
                {

                    string name = binReader.ReadString();
                    int age = binReader.ReadInt32();
                    bool married = binReader.ReadBoolean();
                    l.Add(new Passangers(name, age,married));
                    //yield return new Passangers(name, age, married);
                }
                
            }
            catch (ArgumentException exep)
            {
                Console.WriteLine("Exception was thrown: ArgExcep");
            }


            foreach (var i in l)
            {
                yield return i;
            }




        }


        //return null;
    }
    

    public void SaveData(IEnumerable<T> data, string fileName)
    {
        using (var stream = new FileStream(fileName,
                   FileMode.Create,
                   FileAccess.ReadWrite))
        {
            try
            {
                var binWriter = new BinaryWriter(stream);
                foreach (var obj in data)
                {
                    //Console.WriteLine("name = {0}, age = {1}, married = {2}", obj.name, obj.age, obj.married);
                    binWriter.Write(obj.name);
                    binWriter.Write(obj.age);
                    binWriter.Write(obj.married);
                }
                
            }
            catch (ArgumentNullException exep)
            {
                Console.WriteLine("Exception was thrown: ArgNullExcep");
                
            }
            catch (ArgumentException exep)
            {
                Console.WriteLine("Exception was thrown: ArgExcep");
                
            }
            



        }

        
        
        
     
    }
    

        
        
      
}