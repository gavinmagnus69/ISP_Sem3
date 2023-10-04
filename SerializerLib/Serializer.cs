
using System.Xml.Serialization;
using Akhmetov2.Domain;
using System.Xml.Linq;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SerializerLib;
public class Serializer<T> : ISerializer<T> where T : Hospital
{
    
    public IEnumerable<T> DeSerializeByLINQ(string fileName)
    {
        
        List<Hospital> hospitals = new List<Hospital>();
        XDocument doc = XDocument.Load(fileName);
        
        XElement? root = doc.Element("Hospitals");
        
            foreach (var i in root.Elements("hospital"))
            {
                XAttribute? name = i.Attribute("name");
                //Console.WriteLine(name.Value);
                List<EmergencyDep> tmp = new List<EmergencyDep>();
                foreach (var dep in i.Elements("department_name"))
                {
                    tmp.Add(new EmergencyDep(dep.Value));
                }
                hospitals.Add(new Hospital(name.Value, tmp));
                
                
            }

            return hospitals as IEnumerable<T>;

    
    
        //throw new NotImplementedException();
    }

    public IEnumerable<T> DeSerializeXML(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
        FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
        return serializer.Deserialize(fs) as IEnumerable<T>;
        //throw new NotImplementedException();
    }

    public IEnumerable<T> DeSerializeJSON(string fileName)
    {
        string s = File.ReadAllText(fileName);
        var v = JsonConvert.DeserializeObject<IEnumerable<T>>(s);
        return v;
    }

    public void SerializeByLINQ(IEnumerable<T> xxx, string fileName)
    {
        XDocument doc = new XDocument();
        XElement hospitals = new XElement("Hospitals");
        foreach (var i in xxx)
        {
            XElement hospital = new XElement("hospital");
            XAttribute name = new XAttribute("name", i.hospital_name);
            hospital.Add(name);
            foreach (var j in i.departments)
            {
                XElement dep = new XElement("department_name",j.name);
                hospital.Add(dep);
            }
            hospitals.Add(hospital);
        }
        doc.Add(hospitals);
        doc.Save(fileName);

        //throw new NotImplementedException();
    }

    public void SerializeXML(IEnumerable<T> xxx, string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
        FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
        serializer.Serialize(fs, xxx);
        fs.Close();

    }

    public void SerializeJSON(IEnumerable<T> xxx, string fileName)
    {
       
        
        string json = JsonConvert.SerializeObject(xxx);
        //Console.WriteLine(json);
        File.WriteAllText(fileName, json);
    }   
}